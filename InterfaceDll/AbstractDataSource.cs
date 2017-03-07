using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterfaceDll
{
    abstract public class AbstractDataSource:IProtocal
    {
        public AbstractDataSource()
        {
        }


        public virtual string SendMsg()
        {
            return "产生遥信遥测"; 
        }
        public virtual void ReceiveMsg(string strMsg)
        {
        }
    }
}
