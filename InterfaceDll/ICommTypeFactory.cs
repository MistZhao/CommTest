using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterfaceDll
{
    /// <summary>
    /// 抽象工厂模式（工厂是抽象类/接口，具体工厂必须继承/实现抽象工厂）创建通信类工厂
    /// </summary>
    public interface ICommTypeFactory
    {
        ICommType CreateCommType();
    }
}
