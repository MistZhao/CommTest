using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterfaceDll
{
    public interface IProtocal
    {
        Queue<string> SendMsg();
        void ReceiveMsg(string strMsg);
    }
}
