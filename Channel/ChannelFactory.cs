using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using InterfaceDll;
using Tools;

namespace Channel
{
    public class ChannelFactory
    {
        #region 公有函数
        public static Channel CreateChannel(string strChannelName)
        {
            ConfOperator.SetConfPath();

            Channel objChannel = new Channel(strChannelName);
            string strProtocalName = GetProtocalName(strChannelName);
            objChannel.SetCommTypes();
            return objChannel;
        }

        #endregion

        #region 私有函数
        private static string GetProtocalName(string strChannelName)
        {
            XMLHelper objXMLHelper = XMLHelper.GetInstance(strChannelName + "\\" + ConfigurationManager.AppSettings["ChannelConf"]);
            return objXMLHelper.GetXmlNodeByXpath("//Channel/Protocal").InnerText;
        }
        #endregion

        #region 变量

        #endregion
    }
}
