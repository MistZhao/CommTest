using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Channel;
using InterfaceDll;
using Tools;

namespace hrcomm
{
    class Program
    {
        static void Main(string[] args)
        {
            // 因为GetExecutingAssembly获取的当前函数执行的exe/dll的程序名，所以不能放到工具类中，不然获得的永远是工具类的名称
            string strAssemblyName = Assembly.GetExecutingAssembly().Location.Substring(Assembly.GetExecutingAssembly().Location.LastIndexOf("\\"));
            Configuration config = ConfOperator.GetConfig(strAssemblyName); // 设置了该程序(exe/dll)的配置文件路径

            string strChannelsPath = ConfOperator.GetPath(config.AppSettings.Settings["ChannelPath"].Value);
            // 遍历指定文件夹下的通道文件夹，必须以.conf结尾
            foreach (string s in Directory.GetDirectories(strChannelsPath, "*.conf"))
            {
                BackgroundWorker bgwChannel = new BackgroundWorker();
                bgwChannel.DoWork += bgwChannel_DoWork;
                bgwChannel.RunWorkerCompleted += bgwChannel_RunWorkerCompleted;
                bgwChannel.RunWorkerAsync(s);
            }
            Console.ReadKey();
        }

        static void bgwChannel_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Channel.Channel objChannel = (Channel.Channel)e.Result;
            IProtocal objChannelProtocal = (IProtocal)objChannel.GetProtocal();
            objChannelProtocal.SendMsgEvent += objChannelProtocal_SendMsgEvent;
            objChannelProtocal.StartCreateData();
        }

        static void objChannelProtocal_SendMsgEvent(IProtocal sender, SendMsgEventArgs e)
        {
            Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff    ") + e.StrMsg);
        }

        static void bgwChannel_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string strChannelPath = (string)e.Argument;
                Channel.Channel objChannel = ChannelFactory.CreateChannel(strChannelPath);
                e.Result = objChannel;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }
    }
}
