using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using tool;

namespace tool.modules
{
    class protocol
    {
        private ah_tool _handler;

        public void action(ah_tool handler)
        {
            _handler = handler;
        }

        public void write_lable(int cnt)
        {
            // _handler.Invoke(new Action(() => { write_lable(cnt); }));
            Action<int> write = (count) => { _handler.lable_func(count.ToString()); };
            _handler.Invoke(write, cnt);
        }

        public void task()
        {
            int cnt = 0;

            while (true)
            {
                cnt++;
                write_lable(cnt);
                Thread.Sleep(1000);
            }
        }
    }
}
