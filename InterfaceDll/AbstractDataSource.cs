using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterfaceDll
{
    abstract public class AbstractDataSource:IProtocal
    {
        private Queue<string> objMsgQueue = new Queue<string>();

        public virtual Queue<string> SendMsg()
        {
            return objMsgQueue; 
        }
        public virtual void ReceiveMsg(string strMsg)
        {

        }
    }
}
