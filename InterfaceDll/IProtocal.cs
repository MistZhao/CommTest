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

        /// <summary>
        /// 开始创建Timer，创建数据并传出数据
        /// </summary>
        void StartCreateData();
        /// <summary>
        /// 接收数据，处理后传出
        /// </summary>
        /// <param name="strMsg"></param>
        void ReceiveMsg(string strMsg);
    }
}
