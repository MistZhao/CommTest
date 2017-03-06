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

namespace hrcomm
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfOperator.SetConfPath();
            string strChannelPath = ConfOperator.GetPath(ConfigurationManager.AppSettings["ChannelPath"]);
            foreach(string s in Directory.GetFiles(strChannelPath,"*.conf"))
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

        }

        static void bgwChannel_DoWork(object sender, DoWorkEventArgs e)
        {
            string strChannelPath = (string)e.Argument;
            Channel.Channel objChannel = ChannelFactory.CreateChannel(strChannelPath);
            e.Result = objChannel;
        }
    }
}
