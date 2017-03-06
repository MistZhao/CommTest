using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterfaceDll
{
    abstract public class AbstractIEC104:IProtocal
    {
        private Queue<string> objMsgQueue = new Queue<string>();

        public AbstractIEC104()
        {
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
