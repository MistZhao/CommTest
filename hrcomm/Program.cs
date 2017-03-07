using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
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
            ConfOperator.SetConfPath();
            string strConfPath = ConfOperator.GetConfPath();
            Configuration config = ConfigurationManager.OpenExeConfiguration(strConfPath);
            string strChannelsPath = ConfOperator.GetPath(config.AppSettings["ChannelPath"]);
            DebugTool.WriteLine(strChannelsPath);
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
            //Channel.Channel objChannel = (Channel.Channel)e.Result;
            //IProtocal objChannelProtocal = (IProtocal)objChannel.GetProtocal();
            //Console.WriteLine(objChannelProtocal.SendMsg());
        }

        static void bgwChannel_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string strChannelPath = (string)e.Argument;
                DebugTool.WriteLine(strChannelPath);
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
