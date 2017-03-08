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

        public virtual void SendMsg()
        {
            if(SendMsgEvent!=null&&objMsgQueue.Count>0)
            {
                SendMsgEventArgs e=new SendMsgEventArgs(objMsgQueue.Dequeue());
                SendMsgEvent(this, e);
            }
        }

        public virtual void ReceiveMsg(string strMsg)
        {
            System.Threading.Thread.Sleep(1000);
            objMsgQueue.Enqueue(strMsg);
            SendMsg();
        }
        
        private void CreateFR()
        {
            System.Threading.Thread.Sleep(1500);
            objMsgQueue.Enqueue("AbIEC104产生故障报告");
        }
    }
}
