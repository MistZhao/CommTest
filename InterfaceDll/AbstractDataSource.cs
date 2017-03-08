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
