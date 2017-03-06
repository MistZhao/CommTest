using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceDll;

namespace upPlugin104
{
    class upPlugin104 : AbstractIEC104
    {
        public override Queue<string> SendMsg()
        {
            return base.SendMsg();
        }
    }
}
