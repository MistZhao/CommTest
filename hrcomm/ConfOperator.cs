using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hrcomm
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
            string strExePath = Application.ExecutablePath;
            string strConfPath = Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.LastIndexOf('\\')) + "\\" + "PrivateConf" +
                 strExePath.Substring(strExePath.LastIndexOf('\\')) + ".config";
            m_strConfPath = strConfPath;
            AppDomain.CurrentDomain.SetData("APP_CONFIG_FILE", strConfPath);
        }
    }
}
