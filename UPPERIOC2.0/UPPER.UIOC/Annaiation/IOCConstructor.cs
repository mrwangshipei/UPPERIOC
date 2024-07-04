using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPPERIOC.UPPER.IOC.Annaiation
{
    [AttributeUsage(AttributeTargets.Constructor, AllowMultiple = false, Inherited = true)]

    public class IOCConstructor : Attribute
    {
    }
}
