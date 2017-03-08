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


        public virtual void SendMsg()
        {
            if (SendMsgEvent != null && objMsgQueue.Count > 0)
            {
                SendMsgEventArgs e = new SendMsgEventArgs(objMsgQueue.Dequeue());
                SendMsgEvent(this, e);
            }
        }

        public virtual void ReceiveMsg(string strMsg)
        {
        }

        private void CreateYX()
        {

        }
    }
}
