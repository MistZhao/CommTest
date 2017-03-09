using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceDll;

namespace upPlugin104
{
    class upPlugin104 : AbstractIEC104
    {
        public upPlugin104()
        {
        }

        public override void StartCreateData()
        {
            base.StartCreateData();
            CreateNTP();
        }

        protected override void FRCreator()
        {
            System.Threading.Thread.Sleep(1500);
            objMsgQueue.Enqueue("upPluginIEC104产生故障报告");
        }

        private void CreateNTP()
        {
            System.Timers.Timer objNTPTimer = new System.Timers.Timer();
            objNTPTimer.Interval = 30000;
            objNTPTimer.Elapsed += objNTPTimer_Elapsed;
            objNTPTimer.Start();
        }
        private void objNTPTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            objMsgQueue.Enqueue("upPluginIEC104产生对时报文");
            SendMsg();
        }
    }
}
