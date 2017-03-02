using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InterfaceDll;

namespace Channel
{
    public class ChannelFactory
    {
        #region 公有函数
        public static Channel CreateChannel(string strChannelName)
        {
            Channel objChannel = new Channel(strChannelName);
            objChannel.SetCommTypes();
            return objChannel;
        }
        #endregion

        #region 私有函数

        #endregion

        #region 变量
        #endregion
    }
}
