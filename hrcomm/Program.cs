using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hrcomm
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfOperator.SetConfPath();
            string strChannelPath = Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.LastIndexOf('\\')) + "\\" + ConfigurationManager.AppSettings["ChannelPath"];
            if(Directory.Exists(strChannelPath))
            {
                Console.WriteLine("true "+strChannelPath);
            }
            else
            {
                Console.WriteLine("false "+strChannelPath);
            }
            Console.ReadKey();
        }
    }
}
