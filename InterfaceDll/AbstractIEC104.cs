using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterfaceDll
{
    /// <summary>
    /// 所有IEC104协议的抽象类，基本功能都一样，只是可能解析方式不同
    /// </summary>
    abstract public class AbstractIEC104:IProtocal
    {
        public event SendMsgEventHandler SendMsgEvent;
        protected Queue<string> objMsgQueue = new Queue<string>();

        public AbstractIEC104()
        {
            objMsgQueue.Clear();
        }
        public virtual void StartCreateData()
        {
            CreateFR();
            CreateFW();
        }
        public virtual void ReceiveMsg(string strMsg)
        {
            if(strMsg.ToUpper().Contains("YX"))
            {
                HandleYX(strMsg);
            }
            else if(strMsg.ToUpper().Contains("YC"))
            {
                HandleYC(strMsg);
            }
            SendMsg();
        }
        protected virtual void HandleYX(string strMsg)
        {
            System.Threading.Thread.Sleep(1000);
            objMsgQueue.Enqueue("104YX:" + strMsg);

        }
        protected virtual void HandleYC(string strMsg)
        {
            System.Threading.Thread.Sleep(1000);
            objMsgQueue.Enqueue("104YC:" + strMsg);
        }

        /// <summary>
        /// 触发事件，传出产生的数据
        /// </summary>
        protected void SendMsg()
        {
            lock (objMsgQueue)
            {
                if (SendMsgEvent != null && objMsgQueue.Count > 0)
                {
                    SendMsgEventArgs e = new SendMsgEventArgs(objMsgQueue.Dequeue());
                    SendMsgEvent(this, e);
                }
            }
        }
        private void CreateFR()
        {
            System.Timers.Timer objFRTimer = new System.Timers.Timer();
            objFRTimer.Interval = 30000;
            objFRTimer.Elapsed += objFRTimer_Elapsed;
            objFRTimer.Start();
        }
        private void objFRTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            FRCreator();
            SendMsg();
        }
        /// <summary>
        /// 把实际生成数据的函数单独封装出来，方便派生类重写
        /// </summary>
        protected virtual void FRCreator()
        {
            System.Threading.Thread.Sleep(1500);
            objMsgQueue.Enqueue("AbIEC104产生故障报告");            
        }

        private void CreateFW()
        {
            System.Timers.Timer objFWTimer = new System.Timers.Timer();
            objFWTimer.Interval = 60000;
            objFWTimer.Elapsed += objFWTimer_Elapsed;
            objFWTimer.Start();
        }
        private void objFWTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            FWCreator();
            SendMsg();
        }
        /// <summary>
        /// 把实际生成数据的函数单独封装出来，方便派生类重写
        /// </summary>
        protected virtual void FWCreator()
        {
            System.Threading.Thread.Sleep(3000);
            objMsgQueue.Enqueue("AbIEC104产生故障录波");
        }
    }
}
