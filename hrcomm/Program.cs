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

namespace hrcomm
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfOperator.SetConfPath();
            string strChannelPath = Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.LastIndexOf('\\')) + "\\" + ConfigurationManager.AppSettings["ChannelPath"];
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
            
        }

        static void bgwChannel_DoWork(object sender, DoWorkEventArgs e)
        {
            string strChannelPath = (string)e.Argument;
            Channel.Channel objChannel = ChannelFactory.CreateChannel(strChannelPath);
        }
    }
}
