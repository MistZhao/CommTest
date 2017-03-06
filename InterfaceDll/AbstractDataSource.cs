using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterfaceDll
{
    abstract public class AbstractDataSource:IProtocal
    {
        private Queue<string> objMsgQueue = new Queue<string>();
        private System.Timers.Timer objTimer = new System.Timers.Timer();

        public AbstractDataSource()
        {
            objTimer.Interval = 500;
            objTimer.Elapsed += ObjTimer_Elapsed;
            objTimer.Start();
        }

        private void ObjTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            string strMsg = "产生遥测遥信";
            ReceiveMsg(strMsg);
        }

        public virtual Queue<string> SendMsg()
        {
            return objMsgQueue; 
        }
        public virtual void ReceiveMsg(string strMsg)
        {
            objMsgQueue.Enqueue(strMsg);
        }
    }
}
