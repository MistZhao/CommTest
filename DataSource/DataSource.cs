﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceDll;

namespace DataSource
{
    public class DataSource:AbstractDataSource
    {
        public override Queue<string> SendMsg()
        {
            return base.SendMsg();
        }
    }
}
