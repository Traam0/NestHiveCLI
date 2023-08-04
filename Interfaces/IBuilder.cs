using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NestHive.ToolKit.Interfaces
{
    internal interface IBuilder<T>
    {
        T Build();
    }
}
