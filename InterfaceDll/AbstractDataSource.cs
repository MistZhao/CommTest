using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterfaceDll
{
    /// <summary>
    /// 所有数据源，接口基本一样
    /// </summary>
    abstract public class AbstractDataSource:IProtocal
    {
        public event SendMsgEventHandler SendMsgEvent;

        protected Queue<string> objMsgQueue = new Queue<string>();

        public AbstractDataSource()
        {
            objMsgQueue.Clear();
        }
        public virtual void StartCreateData()
        {
            CreateYX();
            CreateYC();
        }
        public virtual void ReceiveMsg(string strMsg)
        {
        }

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
        private void CreateYX()
        {
            System.Timers.Timer objYXTimer = new System.Timers.Timer();
            objYXTimer.Interval = 30000;
            objYXTimer.Elapsed += objYXTimer_Elapsed;
            objYXTimer.Start();
        }
        private void objYXTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            YXCreator();
            SendMsg();
        }
        protected virtual void YXCreator()
        {
            objMsgQueue.Enqueue("YX01=0,YX02=1");
        }

        private void CreateYC()
        {
            System.Timers.Timer objYCTimer = new System.Timers.Timer();
            objYCTimer.Interval = 5000;
            objYCTimer.Elapsed += objYCTimer_Elapsed;
            objYCTimer.Start();
        }
        private void objYCTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            YCCreator();
            SendMsg();
        }
        protected virtual void YCCreator()
        {
            objMsgQueue.Enqueue("YC01=0.155,YX02=10.101");
        }
    }
}
