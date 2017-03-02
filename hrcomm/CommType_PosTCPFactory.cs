using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceDll;

namespace hrcomm
{
    class CommType_PosTCPFactory:ICommTypeFactory
    {
        public ICommType CreateCommType()
        {
            return new CommType_PosTCP();
        }
    }
}
