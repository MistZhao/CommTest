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
        protected Queue<string> objMsgQueue = new Queue<string>();

        public AbstractIEC104()
        {
            objMsgQueue.Clear();
        }

        public virtual string SendMsg()
        {
            if (objMsgQueue.Count > 0)
            {
                return objMsgQueue.Dequeue();
            }
            else
            {
                return "";
            }
        }

        public virtual void ReceiveMsg(string strMsg)
        {
            System.Threading.Thread.Sleep(1000);
            objMsgQueue.Enqueue(strMsg);
        }
    }
}
