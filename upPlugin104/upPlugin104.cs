﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceDll;

namespace upPlugin104
{
    class upPlugin104 : AbstractIEC104
    {
        public upPlugin104()
        {              
        }

        public override void ReceiveMsg(string strMsg)
        {
            System.Threading.Thread.Sleep(1000);
        }
    }
}
