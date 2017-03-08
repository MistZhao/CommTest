using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Tools
{
    public class ConfOperator
    {
        #region 接口函数
        /// <summary>
        /// 获取程序所在的当前文件夹的同级别指定名称的目录路径
        /// </summary>
        /// <param name="strPathConf"></param>
        /// <returns></returns>
        public static string GetPath(string strPathConf)
        {
            string strPath = Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.LastIndexOf('\\')) + "\\" + strPathConf;
            return strPath;
        }

        /// <summary>
        /// 设置配置文件与程序的映射，并返回配置对象
        /// </summary>
        /// <param name="strAssemblyName"></param>
        /// <returns></returns>
        public static Configuration GetConfig(string strAssemblyName)
        {
            SetConfPath(strAssemblyName);
            ExeConfigurationFileMap map = new ExeConfigurationFileMap();
            map.ExeConfigFilename = m_strConfPath;
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
            if (config.Sections["appSettings"] == null)
            {
                throw new Exception("配置文件\'" + m_strConfPath + "\'中不存在appSettings节点");
            }
            return config;
        }
        #endregion

        #region 私有函数
        /// <summary>
        /// 设置配置路径
        /// </summary>
        /// <param name="strAssemblyName"></param>
        private static void SetConfPath(string strAssemblyName)
        {
            string strConfPath = Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.LastIndexOf('\\')) + "\\" + "PrivateConf" +
                 strAssemblyName + ".config";
            m_strConfPath = strConfPath;
        }
        #endregion

        #region 私有变量
        private static string m_strConfPath = "";
        #endregion
    }
}
