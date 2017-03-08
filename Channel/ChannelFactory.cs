using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using InterfaceDll;
using Tools;

namespace Channel
{
    /// <summary>
    /// 工厂方法模式实现通道工厂，区别于抽象工厂模式
    /// </summary>
    public class ChannelFactory
    {
        #region 公有函数
        public static Channel CreateChannel(string strChannelName)
        {
            string strAssemblyName = Assembly.GetExecutingAssembly().Location.Substring(Assembly.GetExecutingAssembly().Location.LastIndexOf("\\"));
            Configuration config = ConfOperator.GetConfig(strAssemblyName);

            Channel objChannel = new Channel(strChannelName);
            string strProtocalName = GetProtocalName(config,strChannelName);
            // 根据配置文件中的协议名称动态加载同名的dll，利用反射生成同名的协议类
            string strDLLPath = ConfOperator.GetPath(config.AppSettings.Settings["DLLPath"].Value) + "\\" +strProtocalName + ".dll";
            Assembly objAssembly = Assembly.LoadFrom(strDLLPath);
            Type objProtocalType = (from g in objAssembly.GetTypes() where g.Name == strProtocalName select g).First();
            IProtocal objProtocal = Activator.CreateInstance(objProtocalType) as IProtocal;

            objChannel.SetProtocal(objProtocal);
            return objChannel;
        }

        #endregion

        #region 私有函数
        /// <summary>
        /// 获取配置文件中配置的协议名称
        /// </summary>
        /// <param name="config"></param>
        /// <param name="strChannelName"></param>
        /// <returns></returns>
        private static string GetProtocalName(Configuration config, string strChannelName)
        {
            XMLHelper objXMLHelper = XMLHelper.GetInstance(strChannelName + "\\" + config.AppSettings.Settings["ChannelConf"].Value);
            return objXMLHelper.GetXmlNodeByXpath("//Channel/Protocal").InnerText;
        }
        #endregion

        #region 变量

        #endregion
    }
}
