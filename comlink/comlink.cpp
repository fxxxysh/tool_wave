// comlink.cpp: 定义 DLL 应用程序的导出函数。
//

#include "stdafx.h"
#include "string.h"
#include "stdint.h"
#include <stdio.h>

#ifndef COMLINKL_DEBUG
#include "comlink.h"
#endif // COMLINKL_DEBUG

using namespace std;

#define _MSG_PAYLOAD(msg) ((uint8_t *)(&((msg)->payload64[0])))
#define _MSG_PAYLOAD_NON_CONST(msg) ((uint8_t *)(&((msg)->payload64[0])))

#define ck_a(msg) *((msg)->len + (uint8_t *)_MSG_PAYLOAD(msg))
#define ck_b(msg) *(((msg)->len+(uint16_t)1) + (uint8_t *)_MSG_PAYLOAD(msg))

#define STX 0xFE          // marker for old protocol

#define MAX_PAYLOAD_LEN  255
#define NUM_CHECKSUM_uint8_tS  2

#define COMM_NUM_BUFFERS  16
#define HEADER_LEN  5
#define MSG_ID_HEARTBEAT  0

class comlink
{
public :

	comlink() {};
	virtual ~comlink() {};

	enum parse_state_t
	{
		PARSE_STATE_UNINIT = 0,
		PARSE_STATE_IDLE,
		PARSE_STATE_GOT_STX,
		PARSE_STATE_GOT_LENGTH,
		PARSE_STATE_GOT_COMPAT_FLAGS,
		PARSE_STATE_GOT_SEQ,
		PARSE_STATE_GOT_SYSID,
		PARSE_STATE_GOT_COMPID,
		PARSE_STATE_GOT_MSGID,
		PARSE_STATE_GOT_PAYLOAD,
		PARSE_STATE_GOT_CRC1,
		PARSE_STATE_GOT_BAD_CRC1,
	};

	typedef enum {
		FRAMING_INCOMPLETE = 0,
		FRAMING_OK = 1,
		FRAMING_BAD_CRC = 2,
		FRAMING_BAD_SIGNATURE = 3
	} framing_t;

	enum channel_t
	{
		COMM_0,
		COMM_1,
		COMM_2,
		COMM_3
	};

	struct system_t
	{
		uint8_t sysid;
		uint8_t compid;
	};

	typedef struct
	{
		uint32_t custom_mode;
		uint8_t type; //设备类型
		uint8_t version; //设备型号
		uint8_t base_mode;
		uint8_t system_status;
		uint8_t comversion;
	}heartbeat_t;

	typedef struct
	{
		uint16_t checksum;
		uint8_t magic;
		uint8_t len; //负载长度
		uint8_t seq; //序列码
		uint8_t sysid; //系统ID
		uint8_t compid; //组件ID
		uint8_t msgid; //消息ID
		uint64_t payload64[(MAX_PAYLOAD_LEN + NUM_CHECKSUM_uint8_tS + 7) / 8];
		uint8_t ck[2];
	}message_t;

	typedef struct
	{
		uint8_t msg_received;
		uint8_t buffer_overrun;
		uint8_t parse_error;
		parse_state_t parse_state;
		uint8_t packet_idx;
		uint8_t current_rx_seq;
		uint8_t current_tx_seq;
		uint16_t packet_rx_success_count;
		uint16_t packet_rx_drop_count;
		//uint8_t flags;
		//uint8_t signature_wait;
	}status_t;

	static inline void mav_parse_error(status_t *status)
	{
		status->parse_error++;
	}

	/*---------------------------------------------------------------crc---------------------------------------------------------------*/
	static inline void crc_init(uint16_t* crcAccum)
	{
		*crcAccum = 0xffff;
	}

	void start_checksum(message_t* msg)
	{
		crc_init(&msg->checksum);
	}

	static inline void crc_accumulate(uint8_t data, uint16_t *crcAccum)
	{
		//将一个字节的数据累加到CRC
		uint8_t tmp;

		tmp = data ^ (uint8_t)(*crcAccum & 0xff);
		tmp ^= (tmp << 4);
		*crcAccum = (*crcAccum >> 8) ^ (tmp << 8) ^ (tmp << 3) ^ (tmp >> 4);
	}

	static inline uint16_t crc_calculate(const uint8_t* pBuffer, uint16_t length)
	{
		uint16_t crcTmp;
		crc_init(&crcTmp);

		while (length--)
		{
			crc_accumulate(*pBuffer++, &crcTmp);
		}
		return crcTmp;
	}

	static inline void crc_accumulate_buffer(uint16_t *crcAccum, const uint8_t *pBuffer, uint16_t length)
	{
		const uint8_t *p = (const uint8_t *)pBuffer;
		while (length--) 
		{
			crc_accumulate(*p++, crcAccum);
		}
	}

	 void update_checksum(message_t* msg, uint8_t c)
	{
		crc_accumulate(c, &msg->checksum);
	}

	/*---------------------------------------------------------------pkg to buff---------------------------------------------------------------*/
	void mav_finalize_message_chan_send(channel_t chan, uint32_t msgid,
		const uint8_t *packet,
		uint8_t min_length, uint8_t length, uint8_t crc_extra)
	{
		status_t *status = get_channel_status(chan);
		uint8_t buf[HEADER_LEN + 1];
		uint8_t header_len = HEADER_LEN;
		uint16_t checksum;
		uint8_t ck[2];

		length = min_length;

		buf[0] = STX;
		buf[1] = length;
		buf[2] = status->current_tx_seq;
		buf[3] = system.sysid;
		buf[4] = system.compid;
		buf[5] = msgid;

		status->current_tx_seq++;
		checksum = crc_calculate((const uint8_t*)&buf[1], header_len);
		crc_accumulate_buffer(&checksum, packet, length);
		crc_accumulate(crc_extra, &checksum);
		ck[0] = (uint8_t)(checksum & 0xFF);
		ck[1] = (uint8_t)(checksum >> 8);

		_send_uart(chan, (const uint8_t *)buf, header_len + 1);
		_send_uart(chan, packet, length);
		_send_uart(chan, (const uint8_t *)ck, 2);
	}

	/*---------------------------------------------------------------msg to buff---------------------------------------------------------------*/
	uint16_t msg_to_send_buffer(uint8_t *buf, const message_t *msg)
	{
		uint8_t header_len;
		uint8_t *ck;
		uint8_t length = msg->len;

		header_len = HEADER_LEN;

		buf[0] = msg->magic;
		buf[1] = length;
		buf[2] = msg->seq;
		buf[3] = msg->sysid;
		buf[4] = msg->compid;
		buf[5] = msg->msgid;
		memcpy(&buf[6], _MSG_PAYLOAD(msg), msg->len);
		ck = buf + header_len + 1 + (uint16_t)msg->len;

		ck[0] = (uint8_t)(msg->checksum & 0xFF);
		ck[1] = (uint8_t)(msg->checksum >> 8);

		return header_len + 1 + 2 + (uint16_t)length;
	}

	/*---------------------------------------------------------------decode meseage---------------------------------------------------------------*/
	//static inline void msg_change_operator_control_decode(const message_t* msg, change_operator_control_t* change_operator_control)
	//{
	//uint8_t len = msg->len;
	//memset(change_operator_control, 0, MSG_ID_CHANGE_OPERATOR_CONTROL_LEN);
	//memcpy(change_operator_control, _MSG_PAYLOAD(msg), len);
	//}

	/*---------------------------------------------------------------finalize meseage---------------------------------------------------------------*/
	 uint16_t finalize_message_buffer(message_t* msg, uint8_t system_id, uint8_t component_id,
		 status_t* status, uint8_t min_length, uint8_t length, uint8_t crc_extra)
	{
		uint8_t header_len = HEADER_LEN + 1;
		uint8_t buf[HEADER_LEN + 1];

		msg->magic = STX;
		header_len = HEADER_LEN + 1;

		msg->len = min_length;
		msg->sysid = system_id;
		msg->compid = component_id;
		msg->seq = status->current_tx_seq;
		status->current_tx_seq = status->current_tx_seq + 1;

		buf[0] = msg->magic;
		buf[1] = msg->len;
		buf[2] = msg->seq;
		buf[3] = msg->sysid;
		buf[4] = msg->compid;
		buf[5] = msg->msgid;

		msg->checksum = crc_calculate(&buf[1], header_len - 1);
		crc_accumulate_buffer(&msg->checksum, _MSG_PAYLOAD(msg), msg->len);
		crc_accumulate(crc_extra, &msg->checksum);
		ck_a(msg) = (uint8_t)(msg->checksum & 0xFF);
		ck_b(msg) = (uint8_t)(msg->checksum >> 8);

		return msg->len + header_len + 2;
	}

	 uint16_t finalize_message_chan(message_t* msg, uint8_t system_id, uint8_t component_id,
		uint8_t chan, uint8_t min_length, uint8_t length, uint8_t crc_extra)
	{
		 status_t *status = get_channel_status(chan);
		return finalize_message_buffer(msg, system_id, component_id, status, min_length, length, crc_extra);
	}

	 uint16_t finalize_message(message_t* msg, uint8_t system_id, uint8_t component_id,
			 uint8_t min_length, uint8_t length, uint8_t crc_extra)
	 {
		 return finalize_message_chan(msg, system_id, component_id, COMM_0, min_length, length, crc_extra);
	 }

	 static inline uint16_t msg_change_operator_control_pack(uint8_t system_id, uint8_t component_id, message_t* msg,
		 uint8_t target_system, uint8_t control_request, uint8_t version, const char *passkey)
	 {
		 //change_operator_control_t packet;
		 //packet.target_system = target_system;
		 //packet.control_request = control_request;
		 //packet.version = version;
		 //mav_array_memcpy(packet.passkey, passkey, sizeof(char) * 25);
		 //memcpy(_MSG_PAYLOAD_NON_CONST(msg), &packet, MSG_ID_CHANGE_OPERATOR_CONTROL_LEN);

		 //msg->msgid = MSG_ID_CHANGE_OPERATOR_CONTROL;
		 //return finalize_message(msg, system_id, component_id, 
			// MSG_ID_CHANGE_OPERATOR_CONTROL_MIN_LEN, 
			// MSG_ID_CHANGE_OPERATOR_CONTROL_LEN, 
			// MSG_ID_CHANGE_OPERATOR_CONTROL_CRC);
	 }

	 /*---------------------------------------------------------------resend---------------------------------------------------------------*/
	 void resend_uart(channel_t chan, const message_t *msg)
	 {
		 uint8_t header_len = HEADER_LEN + 1;
		 uint8_t buf[HEADER_LEN + 1];

		 uint8_t ck[2];
		 ck[0] = (uint8_t)(msg->checksum & 0xFF);
		 ck[1] = (uint8_t)(msg->checksum >> 8);

		 buf[0] = msg->magic;
		 buf[1] = msg->len;
		 buf[2] = msg->seq;
		 buf[3] = msg->sysid;
		 buf[4] = msg->compid;
		 buf[5] = msg->msgid;

		 _send_uart(chan, (uint8_t*)buf, header_len);
		 _send_uart(chan, _MSG_PAYLOAD(msg), msg->len);
		 _send_uart(chan, (uint8_t *)ck, 2);
	 }

	 /*---------------------------------------------------------------msg id---------------------------------------------------------------*/
	 typedef struct __msg_entry {
		 uint32_t msgid;
		 uint8_t crc_extra;
		 uint8_t msg_len;
		 uint8_t flags;             // MAV_MSG_ENTRY_FLAG_*
		 uint8_t target_system_ofs; // payload offset to target_system, or 0
		 uint8_t target_component_ofs; // payload offset to target_component, or 0
	 } msg_entry_t;

#define MESSAGE_CRCS {{0, 50, 9, 0, 0, 0}, {1, 124, 31, 0, 0, 0}, {2, 137, 12, 0, 0, 0}, {4, 237, 14, 3, 12, 13}}

	 const msg_entry_t *get_msg_entry(uint32_t msgid)
	 {
		 static const msg_entry_t message_crcs[] = MESSAGE_CRCS;
		 /*
		 use a bisection search to find the right entry. A perfect hash may be better
		 Note that this assumes the table is sorted by msgid
		 */
		 uint32_t low = 0, high = sizeof(message_crcs) / sizeof(message_crcs[0]);
		 while (low < high) {
			 uint32_t mid = (low + 1 + high) / 2;
			 if (msgid < message_crcs[mid].msgid) {
				 high = mid - 1;
				 continue;
			 }
			 if (msgid > message_crcs[mid].msgid) {
				 low = mid;
				 continue;
			 }
			 low = mid;
			 break;
		 }
		 if (message_crcs[low].msgid != msgid) {
			 // msgid is not in the table
			 return NULL;
		 }
		 return &message_crcs[low];
	 }

	 /*---------------------------------------------------------------chan---------------------------------------------------------------*/
	 message_t* get_channel_buffer(uint8_t chan)
	 {
		 static message_t m_buffer[COMM_NUM_BUFFERS];
		 return &m_buffer[chan];
	 }

	 status_t* get_channel_status(uint8_t chan)
	 {
		 static status_t m_status[COMM_NUM_BUFFERS];
		 return &m_status[chan];
	 }

	 /*---------------------------------------------------------------parse---------------------------------------------------------------*/
	 uint8_t frame_char_buffer(message_t* rxmsg,
		 status_t* status,
		 uint8_t c,
		 message_t* r_message,
		 status_t* r_status)
	 {
		 status->msg_received = FRAMING_INCOMPLETE;

		 switch (status->parse_state)
		 {
		 case PARSE_STATE_UNINIT:
		 case PARSE_STATE_IDLE:

			 if (c == STX)
			 {
				 status->parse_state = PARSE_STATE_GOT_STX;
				 rxmsg->len = 0;
				 rxmsg->magic = c;
				 start_checksum(rxmsg);
			 }
			 break;

		 case PARSE_STATE_GOT_STX:
			 // NOT counting STX, LENGTH, SEQ, SYSID, COMPID, MSGID, CRC1 and CRC2
			 rxmsg->len = c;
			 status->packet_idx = 0;
			 update_checksum(rxmsg, c);
			 status->parse_state = PARSE_STATE_GOT_COMPAT_FLAGS;
			 break;

		 case PARSE_STATE_GOT_COMPAT_FLAGS:
			 rxmsg->seq = c;
			 update_checksum(rxmsg, c);
			 status->parse_state = PARSE_STATE_GOT_SEQ;
			 break;

		 case PARSE_STATE_GOT_SEQ:
			 rxmsg->sysid = c;
			 update_checksum(rxmsg, c);
			 status->parse_state = PARSE_STATE_GOT_SYSID;
			 break;

		 case PARSE_STATE_GOT_SYSID:
			 rxmsg->compid = c;
			 update_checksum(rxmsg, c);
			 status->parse_state = PARSE_STATE_GOT_COMPID;
			 break;

		 case PARSE_STATE_GOT_COMPID:
			 rxmsg->msgid = c;
			 update_checksum(rxmsg, c);
			 status->parse_state = PARSE_STATE_GOT_MSGID;
			 break;

		 case PARSE_STATE_GOT_MSGID:
			 _MSG_PAYLOAD_NON_CONST(rxmsg)[status->packet_idx++] = (char)c;
			 update_checksum(rxmsg, c);
			 if (status->packet_idx == rxmsg->len)
			 {
				 status->parse_state = PARSE_STATE_GOT_PAYLOAD;
			 }
			 break;

		 case PARSE_STATE_GOT_PAYLOAD: {
			 const msg_entry_t *e = get_msg_entry(rxmsg->msgid);

			 uint8_t crc_extra = e ? e->crc_extra : 0;
			 update_checksum(rxmsg, crc_extra);

			 if (c != (rxmsg->checksum & 0xFF)) {
				 status->parse_state = PARSE_STATE_GOT_BAD_CRC1;
			 }
			 else {
				 status->parse_state = PARSE_STATE_GOT_CRC1;
			 }
			 rxmsg->ck[0] = c;

			 // 传入包小于解析包，其余置零
			 if (e && status->packet_idx < e->msg_len) {
				 memset(&_MSG_PAYLOAD_NON_CONST(rxmsg)[status->packet_idx], 0, e->msg_len - status->packet_idx);
			 }
			 break;
		 }

		 case PARSE_STATE_GOT_CRC1:
		 case PARSE_STATE_GOT_BAD_CRC1:
			 if (status->parse_state == PARSE_STATE_GOT_BAD_CRC1 || c != (rxmsg->checksum >> 8)) {
				 // got a bad CRC message
				 status->msg_received = FRAMING_BAD_CRC;
			 }
			 else {
				 // Successfully got message
				 status->msg_received = FRAMING_OK;
			 }
			 rxmsg->ck[1] = c;

			 status->parse_state = PARSE_STATE_IDLE;
			 memcpy(r_message, rxmsg, sizeof(message_t));
			 break;
		 }

		 // If a message has been sucessfully decoded, check index
		 if (status->msg_received == FRAMING_OK)
		 {
			 status->current_rx_seq = rxmsg->seq;
			 // 如果到目前为止还没有收到数据包，则丢弃计数未定义
			 if (status->packet_rx_success_count == 0) status->packet_rx_drop_count = 0;
			 // 将此包计数为已接收
			 status->packet_rx_success_count++; 
		 }

		 r_message->len = rxmsg->len;
		 r_status->parse_state = status->parse_state;
		 r_status->packet_idx = status->packet_idx;
		 r_status->current_rx_seq = status->current_rx_seq + 1;
		 r_status->packet_rx_success_count = status->packet_rx_success_count;
		 r_status->packet_rx_drop_count = status->parse_error;
		 status->parse_error = 0;

		 if (status->msg_received == FRAMING_BAD_CRC) {	
			 r_message->checksum = rxmsg->ck[0] | (rxmsg->ck[1] << 8); //替换正确的校验码
		 }
		 return status->msg_received;
	 }

	 uint8_t frame_char(uint8_t chan, uint8_t c, message_t* r_message, status_t* r_status)
	 {
		 return frame_char_buffer(get_channel_buffer(chan),
			 get_channel_status(chan),
			 c,
			 r_message,
			 r_status);
	 }

	 uint8_t parse_char(uint8_t chan, uint8_t c, message_t* r_message, status_t* r_status)
	 {
		 uint8_t msg_received = frame_char(chan, c, r_message, r_status);
		 if (msg_received == FRAMING_BAD_CRC ||
			 msg_received == FRAMING_BAD_SIGNATURE) {

			 //解析失败
			 message_t* rxmsg = get_channel_buffer(chan);
			 status_t* status = get_channel_status(chan);
			 mav_parse_error(status);
			 status->msg_received = FRAMING_INCOMPLETE;
			 status->parse_state = PARSE_STATE_IDLE;
			 if (c == STX)
			 {
				 status->parse_state = PARSE_STATE_GOT_STX;
				 rxmsg->len = 0;
				 start_checksum(rxmsg);
			 }
			 return 0;
		 }
		 return msg_received;
	 }

	 void read_byte()
	 {
		 int bytesAvailable = 0;
		 message_t msg;
		 status_t msg_status;

		 int chan = 0;
		 while (bytesAvailable > 0)
		 {
			 uint8_t byte = 0;
			 if (parse_char(chan, byte, &msg, &msg_status))
			 {
				 printf("Received message with ID %d, sequence: %d from component %d of system %d", msg.msgid, msg.seq, msg.compid, msg.sysid);
			 }
		 }
	 }

	/*---------------------------------------------------------------send---------------------------------------------------------------*/
	void _send_uart(channel_t chan, const uint8_t *buf, uint16_t len)
	{
		for (int i = 0; i < len; i++)
		{
			printf("%02X ", buf[i]);
		}
	}

	status_t m_status[COMM_NUM_BUFFERS];
	system_t system = { 12,13 };

	void commsg_test()
	{
		heartbeat_t packet;

		packet.custom_mode = 0;
		packet.type = 17;
		packet.version = 84;
		packet.base_mode = 151;
		packet.system_status = 218;
		packet.comversion = 3;

		//message_chan_send(COMM_1,
		//	MSG_ID_HEARTBEAT,
		//	(uint8_t*)&packet,
		//	MSG_ID_HEARTBEAT_MIN_LEN,
		//	MSG_ID_HEARTBEAT_LEN,
		//	50);
	}
};

uint8_t data_cache[4096];
bool comlink_parse(uint8_t *buffer, int buffer_size)
{
	comlink *_comlink = new comlink();
	memcpy(data_cache, buffer, buffer_size);

	_comlink->commsg_test();

	delete _comlink;
	return true;
}

bool comget_msg(uint8_t* msg_number, uint8_t* now_msg,
	uint16_t* len, uint8_t* payload, uint8_t* seq, uint8_t* sysid, uint8_t* compid, uint8_t* msgid)
{
	return true;
}