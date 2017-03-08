using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterfaceDll
{
    public class SendMsgEventArgs : EventArgs
    {
        private string m_strMsg;

        public string StrMsg
        {
            get { return m_strMsg; }
        }

        public SendMsgEventArgs(string strMsg)
        {
            m_strMsg = strMsg;
        }
    }

    public delegate void SendMsgEventHandler(IProtocal sender,SendMsgEventArgs e);

    public interface IProtocal
    {
        event SendMsgEventHandler SendMsgEvent;

        void SendMsg();
        void ReceiveMsg(string strMsg);
    }
}
