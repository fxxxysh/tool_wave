// comlink.cpp: 定义 DLL 应用程序的导出函数。
//

#include "stdafx.h"
#include "string.h"
#include "stdint.h"
#include <stdio.h>

#ifndef COMLINKL_DEBUG
//#include "comlink.h"
#endif // COMLINKL_DEBUG

using namespace std;

#define _MAV_PAYLOAD(msg) ((uint8_t *)(&((msg)->payload64[0])))
#define _MAV_PAYLOAD_NON_CONST(msg) ((char *)(&((msg)->payload64[0])))

#define mavlink_ck_a(msg) *((msg)->len + (uint8_t *)_MAV_PAYLOAD(msg))
#define mavlink_ck_b(msg) *(((msg)->len+(uint16_t)1) + (uint8_t *)_MAV_PAYLOAD(msg))

#define MAVLINK_STX  0xFE
#define MAVLINK_STX_MAVLINK1 0xFE          // marker for old protocol

#define MAVLINK_MAX_PAYLOAD_LEN  255
#define MAVLINK_NUM_CHECKSUM_uint8_tS  2
//#define MAVLINK_CORE_HEADER_LEN  9
//#define MAVLINK_NUM_HEADER_uint8_tS (MAVLINK_CORE_HEADER_LEN + 1)

#define MAVLINK_MSG_ID_HEARTBEAT_LEN  9
#define MAVLINK_MSG_ID_HEARTBEAT_MIN_LEN  9

#define MAVLINK_COMM_NUM_BUFFERS  16
#define MAVLINK_CORE_HEADER_MAVLINK1_LEN  5
#define MAVLINK_MSG_ID_HEARTBEAT  0

class comlink
{
public :

	comlink() {};
	virtual ~comlink() {};

	typedef struct
	{
		uint32_t custom_mode;
		uint8_t type; //设备类型
		uint8_t version; //设备型号
		uint8_t base_mode;
		uint8_t system_status;
		uint8_t comlink_version;
	}mavlink_heartbeat_t;


	typedef struct
	{
		uint16_t checksum;
		uint8_t magic;
		uint8_t len; //负载长度
		uint8_t seq; //序列码
		uint8_t sysid; //系统ID
		uint8_t compid; //组件ID
		uint8_t msgid; //消息ID
		uint64_t payload64[(MAVLINK_MAX_PAYLOAD_LEN + MAVLINK_NUM_CHECKSUM_uint8_tS + 7) / 8];
		uint8_t ck[2];
	}mavlink_message_t;

	enum mavlink_parse_state_t
	{
		MAVLINK_PARSE_STATE_UNINIT = 0,
		MAVLINK_PARSE_STATE_IDLE,
		MAVLINK_PARSE_STATE_GOT_STX,
		MAVLINK_PARSE_STATE_GOT_LENGTH,
		MAVLINK_PARSE_STATE_GOT_INCOMPAT_FLAGS,
		MAVLINK_PARSE_STATE_GOT_COMPAT_FLAGS,
		MAVLINK_PARSE_STATE_GOT_SEQ,
		MAVLINK_PARSE_STATE_GOT_SYSID,
		MAVLINK_PARSE_STATE_GOT_COMPID,
		MAVLINK_PARSE_STATE_GOT_MSGID1,
		MAVLINK_PARSE_STATE_GOT_MSGID2,
		MAVLINK_PARSE_STATE_GOT_MSGID3,
		MAVLINK_PARSE_STATE_GOT_PAYLOAD,
		MAVLINK_PARSE_STATE_GOT_CRC1,
		MAVLINK_PARSE_STATE_GOT_BAD_CRC1,
		MAVLINK_PARSE_STATE_SIGNATURE_WAIT
	};

	typedef enum {
		MAVLINK_FRAMING_INCOMPLETE = 0,
		MAVLINK_FRAMING_OK = 1,
		MAVLINK_FRAMING_BAD_CRC = 2,
		MAVLINK_FRAMING_BAD_SIGNATURE = 3
	} mavlink_framing_t;


#define MAVLINK_STATUS_FLAG_IN_MAVLINK1  1 // last incoming packet was MAVLink1
#define MAVLINK_STATUS_FLAG_OUT_MAVLINK1 2 // generate MAVLink1 by default
#define MAVLINK_STATUS_FLAG_IN_SIGNED    4 // last incoming packet was signed and validated
#define MAVLINK_STATUS_FLAG_IN_BADSIG    8 // last incoming packet had a bad signature

	enum mavlink_channel_t
	{
		MAVLINK_COMM_0,
		MAVLINK_COMM_1,
		MAVLINK_COMM_2,
		MAVLINK_COMM_3
	};

	struct mavlink_system_t
	{
		uint8_t sysid;
		uint8_t compid;
	};

	typedef struct
	{
		uint8_t msg_received;
		uint8_t buffer_overrun;
		uint8_t parse_error;
		mavlink_parse_state_t parse_state;
		uint8_t packet_idx;
		uint8_t current_rx_seq;
		uint8_t current_tx_seq;
		uint16_t packet_rx_success_count;
		uint16_t packet_rx_drop_count;
		//uint8_t flags;
		//uint8_t signature_wait;
	}mavlink_status_t;

	static inline void _mav_parse_error(mavlink_status_t *status)
	{
		status->parse_error++;
	}

	mavlink_status_t* mavlink_get_channel_status(uint8_t chan)
	{
		static mavlink_status_t m_mavlink_status[MAVLINK_COMM_NUM_BUFFERS];
		return &m_mavlink_status[chan];
	}

	static inline void crc_accumulate(uint8_t data, uint16_t *crcAccum)
	{
		/*Accumulate one byte of data into the CRC*/
		uint8_t tmp;

		tmp = data ^ (uint8_t)(*crcAccum & 0xff);
		tmp ^= (tmp << 4);
		*crcAccum = (*crcAccum >> 8) ^ (tmp << 8) ^ (tmp << 3) ^ (tmp >> 4);
	}

	static inline uint16_t crc_calculate(const uint8_t* pBuffer, uint16_t length)
	{
		uint16_t crcTmp = 0xffff;

		while (length--)
		{
			crc_accumulate(*pBuffer++, &crcTmp);
		}
		return crcTmp;
	}

	static inline void crc_accumulate_buffer(uint16_t *crcAccum, uint8_t *pBuffer, uint16_t length)
	{
		const uint8_t *p = (const uint8_t *)pBuffer;
		while (length--) 
		{
			crc_accumulate(*p++, crcAccum);
		}

	}


		static inline void crc_init(uint16_t* crcAccum)
	{
		*crcAccum = 0xffff;
	}

	 void mavlink_start_checksum(mavlink_message_t* msg)
	{
		crc_init(&msg->checksum);
	}

	 void mavlink_update_checksum(mavlink_message_t* msg, uint8_t c)
	{
		crc_accumulate(c, &msg->checksum);
	}

	void message_chan_send(mavlink_channel_t chan, uint8_t msgid,
		uint8_t *packet, uint8_t min_length, uint8_t length, uint8_t crc_extra)
	{
		uint8_t header_len = MAVLINK_CORE_HEADER_MAVLINK1_LEN;
		uint8_t buf[MAVLINK_CORE_HEADER_MAVLINK1_LEN + 1];
		mavlink_status_t *status = mavlink_get_channel_status((uint8_t)chan);

		uint16_t checksum;
		uint8_t ck[2];

		length = min_length;
		if (msgid > 255) {
			// can't send 16 bit messages
			_mav_parse_error(status);
			return;
		}
	
		buf[0] = MAVLINK_STX;
		buf[1] = length;
		buf[2] = status->current_tx_seq;
		buf[3] = mavlink_system.sysid;
		buf[4] = mavlink_system.compid;
		buf[5] = msgid;

		status->current_tx_seq++;
		checksum = crc_calculate(( uint8_t*)&buf[1], header_len);
		crc_accumulate_buffer(&checksum, packet, length);
		crc_accumulate(crc_extra, &checksum);
		ck[0] = (uint8_t)(checksum & 0xFF);
		ck[1] = (uint8_t)(checksum >> 8);

		_mavlink_send_uart(chan, buf, header_len + 1);
		_mavlink_send_uart(chan, packet, length);
		_mavlink_send_uart(chan, ck, 2);
	}

	uint16_t mavlink_msg_to_send_buffer(uint8_t *buf, const mavlink_message_t *msg)
	{
		uint8_t header_len;
		uint8_t *ck;
		uint8_t length = msg->len;

		header_len = MAVLINK_CORE_HEADER_MAVLINK1_LEN;
		buf[0] = msg->magic;
		buf[1] = length;
		buf[2] = msg->seq;
		buf[3] = msg->sysid;
		buf[4] = msg->compid;
		buf[5] = msg->msgid;
		memcpy(&buf[6], _MAV_PAYLOAD(msg), msg->len);
		ck = buf + header_len + 1 + (uint16_t)msg->len;

		ck[0] = (uint8_t)(msg->checksum & 0xFF);
		ck[1] = (uint8_t)(msg->checksum >> 8);

		return header_len + 1 + 2 + (uint16_t)length;
	}

	 uint16_t mavlink_finalize_message_buffer(mavlink_message_t* msg, uint8_t system_id, uint8_t component_id,
		 mavlink_channel_t chan, uint8_t min_length, uint8_t length, uint8_t crc_extra)
	{
		uint8_t header_len = MAVLINK_CORE_HEADER_MAVLINK1_LEN + 1;
		uint8_t buf[MAVLINK_CORE_HEADER_MAVLINK1_LEN + 1];
		mavlink_status_t *status = mavlink_get_channel_status(chan);

		msg->len = min_length;
		msg->sysid = system_id;
		msg->compid = component_id;
		msg->seq = status->current_tx_seq;
		status->current_tx_seq = status->current_tx_seq + 1;

		// form the header as a byte array for the crc
		buf[0] = msg->magic;
		buf[1] = msg->len;
		buf[2] = msg->seq;
		buf[3] = msg->sysid;
		buf[4] = msg->compid;
		buf[5] = msg->msgid;

		msg->checksum = crc_calculate(&buf[1], header_len - 1);
		crc_accumulate_buffer(&msg->checksum, _MAV_PAYLOAD(msg), msg->len);
		crc_accumulate(crc_extra, &msg->checksum);
		mavlink_ck_a(msg) = (uint8_t)(msg->checksum & 0xFF);
		mavlink_ck_b(msg) = (uint8_t)(msg->checksum >> 8);

		return msg->len + header_len + 2;
	}

	 uint16_t mavlink_finalize_message_chan(mavlink_message_t* msg, uint8_t system_id, uint8_t component_id,
		uint8_t chan, uint8_t min_length, uint8_t length, uint8_t crc_extra)
	{
		return mavlink_finalize_message_buffer(msg, system_id, component_id, MAVLINK_COMM_0, min_length, length, crc_extra);
	}

	 void _mavlink_resend_uart(mavlink_channel_t chan, const mavlink_message_t *msg)
	 {
		 uint8_t ck[2];

		 ck[0] = (uint8_t)(msg->checksum & 0xFF);
		 ck[1] = (uint8_t)(msg->checksum >> 8);
		 // XXX use the right sequence here

		 uint8_t header_len;
		 uint8_t signature_len;

		 header_len = MAVLINK_CORE_HEADER_MAVLINK1_LEN + 1;
		 signature_len = 0;

		 // we can't send the structure directly as it has extra mavlink2 elements in it
		 uint8_t buf[MAVLINK_CORE_HEADER_MAVLINK1_LEN + 1];
		 buf[0] = msg->magic;
		 buf[1] = msg->len;
		 buf[2] = msg->seq;
		 buf[3] = msg->sysid;
		 buf[4] = msg->compid;
		 buf[5] = msg->msgid;

		 _mavlink_send_uart(chan, (uint8_t*)buf, header_len);
		 _mavlink_send_uart(chan, _MAV_PAYLOAD(msg), msg->len);
		 _mavlink_send_uart(chan, (uint8_t *)ck, 2);
	 }

	 typedef struct __mavlink_msg_entry {
		 uint32_t msgid;
		 uint8_t crc_extra;
		 uint8_t msg_len;
		 uint8_t flags;             // MAV_MSG_ENTRY_FLAG_*
		 uint8_t target_system_ofs; // payload offset to target_system, or 0
		 uint8_t target_component_ofs; // payload offset to target_component, or 0
	 } mavlink_msg_entry_t;

#define MAVLINK_MESSAGE_CRCS {{0, 50, 9, 0, 0, 0}, {1, 124, 31, 0, 0, 0}, {2, 137, 12, 0, 0, 0}, {4, 237, 14, 3, 12, 13}, {5, 217, 28, 1, 0, 0}, {6, 104, 3, 0, 0, 0}, {7, 119, 32, 0, 0, 0}, {11, 89, 6, 1, 4, 0}, {20, 214, 20, 3, 2, 3}, {21, 159, 2, 3, 0, 1}, {22, 220, 25, 0, 0, 0}, {23, 168, 23, 3, 4, 5}, {24, 24, 30, 0, 0, 0}, {25, 23, 101, 0, 0, 0}, {26, 170, 22, 0, 0, 0}, {27, 144, 26, 0, 0, 0}, {28, 67, 16, 0, 0, 0}, {29, 115, 14, 0, 0, 0}, {30, 39, 28, 0, 0, 0}, {31, 246, 32, 0, 0, 0}, {32, 185, 28, 0, 0, 0}, {33, 104, 28, 0, 0, 0}, {34, 237, 22, 0, 0, 0}, {35, 244, 22, 0, 0, 0}, {36, 222, 21, 0, 0, 0}, {37, 212, 6, 3, 4, 5}, {38, 9, 6, 3, 4, 5}, {39, 254, 37, 3, 32, 33}, {40, 230, 4, 3, 2, 3}, {41, 28, 4, 3, 2, 3}, {42, 28, 2, 0, 0, 0}, {43, 132, 2, 3, 0, 1}, {44, 221, 4, 3, 2, 3}, {45, 232, 2, 3, 0, 1}, {46, 11, 2, 0, 0, 0}, {47, 153, 3, 3, 0, 1}, {48, 41, 13, 1, 12, 0}, {49, 39, 12, 0, 0, 0}, {50, 78, 37, 3, 18, 19}, {51, 196, 4, 3, 2, 3}, {54, 15, 27, 3, 24, 25}, {55, 3, 25, 0, 0, 0}, {61, 167, 72, 0, 0, 0}, {62, 183, 26, 0, 0, 0}, {63, 119, 181, 0, 0, 0}, {64, 191, 225, 0, 0, 0}, {65, 118, 42, 0, 0, 0}, {66, 148, 6, 3, 2, 3}, {67, 21, 4, 0, 0, 0}, {69, 243, 11, 0, 0, 0}, {70, 124, 18, 3, 16, 17}, {73, 38, 37, 3, 32, 33}, {74, 20, 20, 0, 0, 0}, {75, 158, 35, 3, 30, 31}, {76, 152, 33, 3, 30, 31}, {77, 143, 3, 3, 8, 9}, {81, 106, 22, 0, 0, 0}, {82, 49, 39, 3, 36, 37}, {83, 22, 37, 0, 0, 0}, {84, 143, 53, 3, 50, 51}, {85, 140, 51, 0, 0, 0}, {86, 5, 53, 3, 50, 51}, {87, 150, 51, 0, 0, 0}, {89, 231, 28, 0, 0, 0}, {90, 183, 56, 0, 0, 0}, {91, 63, 42, 0, 0, 0}, {92, 54, 33, 0, 0, 0}, {93, 47, 81, 0, 0, 0}, {100, 175, 26, 0, 0, 0}, {101, 102, 32, 0, 0, 0}, {102, 158, 32, 0, 0, 0}, {103, 208, 20, 0, 0, 0}, {104, 56, 32, 0, 0, 0}, {105, 93, 62, 0, 0, 0}, {106, 138, 44, 0, 0, 0}, {107, 108, 64, 0, 0, 0}, {108, 32, 84, 0, 0, 0}, {109, 185, 9, 0, 0, 0}, {110, 84, 254, 3, 1, 2}, {111, 34, 16, 0, 0, 0}, {112, 174, 12, 0, 0, 0}, {113, 124, 36, 0, 0, 0}, {114, 237, 44, 0, 0, 0}, {115, 4, 64, 0, 0, 0}, {116, 76, 22, 0, 0, 0}, {117, 128, 6, 3, 4, 5}, {118, 56, 14, 0, 0, 0}, {119, 116, 12, 3, 10, 11}, {120, 134, 97, 0, 0, 0}, {121, 237, 2, 3, 0, 1}, {122, 203, 2, 3, 0, 1}, {123, 250, 113, 3, 0, 1}, {124, 87, 35, 0, 0, 0}, {125, 203, 6, 0, 0, 0}, {126, 220, 79, 0, 0, 0}, {127, 25, 35, 0, 0, 0}, {128, 226, 35, 0, 0, 0}, {129, 46, 22, 0, 0, 0}, {130, 29, 13, 0, 0, 0}, {131, 223, 255, 0, 0, 0}, {132, 85, 14, 0, 0, 0}, {133, 6, 18, 0, 0, 0}, {134, 229, 43, 0, 0, 0}, {135, 203, 8, 0, 0, 0}, {136, 1, 22, 0, 0, 0}, {137, 195, 14, 0, 0, 0}, {138, 109, 36, 0, 0, 0}, {139, 168, 43, 3, 41, 42}, {140, 181, 41, 0, 0, 0}, {141, 47, 32, 0, 0, 0}, {142, 72, 243, 0, 0, 0}, {143, 131, 14, 0, 0, 0}, {144, 127, 93, 0, 0, 0}, {146, 103, 100, 0, 0, 0}, {147, 154, 36, 0, 0, 0}, {148, 178, 60, 0, 0, 0}, {149, 200, 30, 0, 0, 0}, {230, 163, 42, 0, 0, 0}, {231, 105, 40, 0, 0, 0}, {232, 151, 63, 0, 0, 0}, {233, 35, 182, 0, 0, 0}, {234, 150, 40, 0, 0, 0}, {241, 90, 32, 0, 0, 0}, {242, 104, 52, 0, 0, 0}, {243, 85, 53, 1, 52, 0}, {244, 95, 6, 0, 0, 0}, {245, 130, 2, 0, 0, 0}, {246, 184, 38, 0, 0, 0}, {247, 81, 19, 0, 0, 0}, {248, 8, 254, 3, 3, 4}, {249, 204, 36, 0, 0, 0}, {250, 49, 30, 0, 0, 0}, {251, 170, 18, 0, 0, 0}, {252, 44, 18, 0, 0, 0}, {253, 83, 51, 0, 0, 0}, {254, 46, 9, 0, 0, 0}, {256, 71, 42, 3, 8, 9}, {257, 131, 9, 0, 0, 0}, {258, 187, 32, 3, 0, 1}, {259, 92, 235, 0, 0, 0}, {260, 146, 5, 0, 0, 0}, {261, 179, 27, 0, 0, 0}, {262, 12, 18, 0, 0, 0}, {263, 133, 255, 0, 0, 0}, {264, 49, 28, 0, 0, 0}, {265, 26, 16, 0, 0, 0}, {266, 193, 255, 3, 2, 3}, {267, 35, 255, 3, 2, 3}, {268, 14, 4, 3, 2, 3}, {269, 58, 246, 0, 0, 0}, {270, 232, 247, 3, 14, 15}, {299, 19, 96, 0, 0, 0}, {300, 217, 22, 0, 0, 0}, {310, 28, 17, 0, 0, 0}, {311, 95, 116, 0, 0, 0}, {320, 243, 20, 3, 2, 3}, {321, 88, 2, 3, 0, 1}, {322, 243, 149, 0, 0, 0}, {323, 78, 147, 3, 0, 1}, {324, 132, 146, 0, 0, 0}}

	 const mavlink_msg_entry_t *mavlink_get_msg_entry(uint32_t msgid)
	 {
		 static const mavlink_msg_entry_t mavlink_message_crcs[] = MAVLINK_MESSAGE_CRCS;
		 /*
		 use a bisection search to find the right entry. A perfect hash may be better
		 Note that this assumes the table is sorted by msgid
		 */
		 uint32_t low = 0, high = sizeof(mavlink_message_crcs) / sizeof(mavlink_message_crcs[0]);
		 while (low < high) {
			 uint32_t mid = (low + 1 + high) / 2;
			 if (msgid < mavlink_message_crcs[mid].msgid) {
				 high = mid - 1;
				 continue;
			 }
			 if (msgid > mavlink_message_crcs[mid].msgid) {
				 low = mid;
				 continue;
			 }
			 low = mid;
			 break;
		 }
		 if (mavlink_message_crcs[low].msgid != msgid) {
			 // msgid is not in the table
			 return NULL;
		 }
		 return &mavlink_message_crcs[low];
	 }

	  mavlink_message_t* mavlink_get_channel_buffer(uint8_t chan)
	 {
		  // has to be defined externally
		 static mavlink_message_t m_mavlink_buffer[MAVLINK_COMM_NUM_BUFFERS];
		 return &m_mavlink_buffer[chan];
	 }

	  uint8_t mavlink_parse_char(uint8_t chan, uint8_t c, mavlink_message_t* r_message, mavlink_status_t* r_mavlink_status)
	  {
		  uint8_t msg_received = mavlink_frame_char(chan, c, r_message, r_mavlink_status);
		  if (msg_received == MAVLINK_FRAMING_BAD_CRC ||
			  msg_received == MAVLINK_FRAMING_BAD_SIGNATURE) {
			  // we got a bad CRC. Treat as a parse failure
			  mavlink_message_t* rxmsg = mavlink_get_channel_buffer(chan);
			  mavlink_status_t* status = mavlink_get_channel_status(chan);
			  _mav_parse_error(status);
			  status->msg_received = MAVLINK_FRAMING_INCOMPLETE;
			  status->parse_state = MAVLINK_PARSE_STATE_IDLE;
			  if (c == MAVLINK_STX)
			  {
				  status->parse_state = MAVLINK_PARSE_STATE_GOT_STX;
				  rxmsg->len = 0;
				  mavlink_start_checksum(rxmsg);
			  }
			  return 0;
		  }
		  return msg_received;
	  }


	  //解析
	  void read_byte()
	  {
		  int bytesAvailable = 0;
		  mavlink_message_t msg;
		  mavlink_status_t msg_status;

		  int chan = 0;
		  while (bytesAvailable > 0)
		  {
			  uint8_t byte = 0;
			  if (mavlink_parse_char(chan, byte, &msg, &msg_status))
			  {
				  printf("Received message with ID %d, sequence: %d from component %d of system %d", msg.msgid, msg.seq, msg.compid, msg.sysid);

			  }
		  }
	  }

	  uint8_t mavlink_frame_char(uint8_t chan, uint8_t c, mavlink_message_t* r_message, mavlink_status_t* r_mavlink_status)
	 {
		 return mavlink_frame_char_buffer(mavlink_get_channel_buffer(chan),
			 mavlink_get_channel_status(chan),
			 c,
			 r_message,
			 r_mavlink_status);
	 }

	 uint8_t mavlink_frame_char_buffer(mavlink_message_t* rxmsg,
		 mavlink_status_t* status,
		 uint8_t c,
		 mavlink_message_t* r_message,
		 mavlink_status_t* r_mavlink_status)
	 {
		 status->msg_received = MAVLINK_FRAMING_INCOMPLETE;

		 switch (status->parse_state)
		 {
		 case MAVLINK_PARSE_STATE_UNINIT:
		 case MAVLINK_PARSE_STATE_IDLE:

			 if (c == MAVLINK_STX_MAVLINK1)
			 {
				 status->parse_state = MAVLINK_PARSE_STATE_GOT_STX;
				 rxmsg->len = 0;
				 rxmsg->magic = c;
				 mavlink_start_checksum(rxmsg);
			 }
			 break;

		 case MAVLINK_PARSE_STATE_GOT_STX:
			 // NOT counting STX, LENGTH, SEQ, SYSID, COMPID, MSGID, CRC1 and CRC2
			 rxmsg->len = c;
			 status->packet_idx = 0;
			 mavlink_update_checksum(rxmsg, c);
			 status->parse_state = MAVLINK_PARSE_STATE_GOT_COMPAT_FLAGS;
			 break;

		 case MAVLINK_PARSE_STATE_GOT_COMPAT_FLAGS:
			 rxmsg->seq = c;
			 mavlink_update_checksum(rxmsg, c);
			 status->parse_state = MAVLINK_PARSE_STATE_GOT_SEQ;
			 break;

		 case MAVLINK_PARSE_STATE_GOT_SEQ:
			 rxmsg->sysid = c;
			 mavlink_update_checksum(rxmsg, c);
			 status->parse_state = MAVLINK_PARSE_STATE_GOT_SYSID;
			 break;

		 case MAVLINK_PARSE_STATE_GOT_SYSID:
			 rxmsg->compid = c;
			 mavlink_update_checksum(rxmsg, c);
			 status->parse_state = MAVLINK_PARSE_STATE_GOT_COMPID;
			 break;

		 case MAVLINK_PARSE_STATE_GOT_COMPID:
			 rxmsg->msgid = c;
			 mavlink_update_checksum(rxmsg, c);
			 status->parse_state = MAVLINK_PARSE_STATE_GOT_MSGID3;
			 break;

		 case MAVLINK_PARSE_STATE_GOT_MSGID3:
			 _MAV_PAYLOAD_NON_CONST(rxmsg)[status->packet_idx++] = (char)c;
			 mavlink_update_checksum(rxmsg, c);
			 if (status->packet_idx == rxmsg->len)
			 {
				 status->parse_state = MAVLINK_PARSE_STATE_GOT_PAYLOAD;
			 }
			 break;

		 case MAVLINK_PARSE_STATE_GOT_PAYLOAD: {
			 const mavlink_msg_entry_t *e = mavlink_get_msg_entry(rxmsg->msgid);

			 uint8_t crc_extra = e ? e->crc_extra : 0;
			 mavlink_update_checksum(rxmsg, crc_extra);

			 if (c != (rxmsg->checksum & 0xFF)) {
				 status->parse_state = MAVLINK_PARSE_STATE_GOT_BAD_CRC1;
			 }
			 else {
				 status->parse_state = MAVLINK_PARSE_STATE_GOT_CRC1;
			 }
			 rxmsg->ck[0] = c;

			 // 传入包小于解析包，其余置零
			 if (e && status->packet_idx < e->msg_len) {
				 memset(&_MAV_PAYLOAD_NON_CONST(rxmsg)[status->packet_idx], 0, e->msg_len - status->packet_idx);
			 }
			 break;
		 }

		 case MAVLINK_PARSE_STATE_GOT_CRC1:
		 case MAVLINK_PARSE_STATE_GOT_BAD_CRC1:
			 if (status->parse_state == MAVLINK_PARSE_STATE_GOT_BAD_CRC1 || c != (rxmsg->checksum >> 8)) {
				 // got a bad CRC message
				 status->msg_received = MAVLINK_FRAMING_BAD_CRC;
			 }
			 else {
				 // Successfully got message
				 status->msg_received = MAVLINK_FRAMING_OK;
			 }
			 rxmsg->ck[1] = c;

			 status->parse_state = MAVLINK_PARSE_STATE_IDLE;
			 memcpy(r_message, rxmsg, sizeof(mavlink_message_t));
			 break;
		 }

		 // If a message has been sucessfully decoded, check index
		 if (status->msg_received == MAVLINK_FRAMING_OK)
		 {
			 status->current_rx_seq = rxmsg->seq;
			 // 如果到目前为止还没有收到数据包，则丢弃计数未定义
			 if (status->packet_rx_success_count == 0) status->packet_rx_drop_count = 0;
			 // 将此包计数为已接收
			 status->packet_rx_success_count++; 
		 }

		 r_message->len = rxmsg->len; // Provide visibility on how far we are into current msg
		 r_mavlink_status->parse_state = status->parse_state;
		 r_mavlink_status->packet_idx = status->packet_idx;
		 r_mavlink_status->current_rx_seq = status->current_rx_seq + 1;
		 r_mavlink_status->packet_rx_success_count = status->packet_rx_success_count;
		 r_mavlink_status->packet_rx_drop_count = status->parse_error;
		 status->parse_error = 0;

		 if (status->msg_received == MAVLINK_FRAMING_BAD_CRC) {	
			 r_message->checksum = rxmsg->ck[0] | (rxmsg->ck[1] << 8); //替换正确的校验码
		 }
		 return status->msg_received;
	 }

	void _mavlink_send_uart(mavlink_channel_t chan, uint8_t *buf, uint16_t len)
	{
		for (int i = 0; i < len; i++)
		{
			printf("%02X ", buf[i]);
		}
	}

	mavlink_status_t m_mavlink_status[MAVLINK_COMM_NUM_BUFFERS];
	mavlink_system_t mavlink_system = { 12,13 };

	void comlink_msg_test()
	{
		mavlink_heartbeat_t packet;

		packet.custom_mode = 0;
		packet.type = 17;
		packet.version = 84;
		packet.base_mode = 151;
		packet.system_status = 218;
		packet.comlink_version = 3;

		message_chan_send(MAVLINK_COMM_1,
			MAVLINK_MSG_ID_HEARTBEAT,
			(uint8_t*)&packet,
			MAVLINK_MSG_ID_HEARTBEAT_MIN_LEN,
			MAVLINK_MSG_ID_HEARTBEAT_LEN,
			50);
	}
};


uint8_t data_cache[4096];
bool comlink_parse(uint8_t *buffer, int buffer_size)
{
	comlink *_comlink = new comlink();
	memcpy(data_cache, buffer, buffer_size);

	_comlink->comlink_msg_test();

	delete _comlink;
	return true;
}

bool comlink_get_msg(uint8_t* msg_number, uint8_t* now_msg,
	uint16_t* len, uint8_t* payload, uint8_t* seq, uint8_t* sysid, uint8_t* compid, uint8_t* msgid)
{
	return true;
}