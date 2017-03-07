using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Tools;

namespace Channel
{
    public class ConfOperator
    {
        private static string m_strConfPath="";

        public static string GetConfPath()
        {
            return m_strConfPath;
        }

        public static void SetConfPath()
        {
            try
            {
                string strExePath = Application.ExecutablePath;
                string strConfPath = Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.LastIndexOf('\\')) + "\\" + "PrivateConf" +
                     strExePath.Substring(strExePath.LastIndexOf('\\')) + ".config";
                m_strConfPath = strConfPath;
                DebugTool.WriteLine(m_strConfPath);
                //AppDomain.CurrentDomain.SetData("APP_CONFIG_FILE", strConfPath);
                ConfigurationManager.OpenExeConfiguration(strConfPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message+Environment.NewLine+ex.StackTrace);
            }
        }

        public static string GetPath(string strPathConf)
        {
            string strPath = Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.LastIndexOf('\\')) + "\\" + strPathConf;
            return strPath;
        }

        public static void SetDLLConfPath()
        {

        }
    }
}
