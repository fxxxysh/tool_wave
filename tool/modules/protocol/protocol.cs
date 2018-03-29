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
        public void protocol_main()
        {
            int cnt = 0;

            ah_tool wave = new ah_tool();

            while (true)
            {
                cnt++;
                //wave.lable_func(cnt.ToString());
                Thread.Sleep(1000);
            }
        }
    }
}
