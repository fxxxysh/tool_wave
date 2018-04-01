using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Iocomp.Instrumentation.Plotting;
using tool;

namespace tool.modules
{
    public class protocol
    {
        public protocol()
        {
        }

        public void write_lable(int cnt)
        {
            // _handler.Invoke(new Action(() => { write_lable(cnt); }));
            //Action<int> write = (count) => { _handler.lable_func(count.ToString()); };
            //_handler.Invoke(write, cnt);

            //Action<int> write = (count) => { _handler.; };
            //_handler.Invoke(write, cnt);
        }
    }
}
