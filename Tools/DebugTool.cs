#define Test

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tools
{
    public class DebugTool
    {
        public static void WriteLine(string strMsg)
        {
#if Test
            Console.WriteLine(strMsg);
#endif
        }
    }
}
