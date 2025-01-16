using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPPERIOC.UPPER.IOC.Annaiation
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]

    public class IOCMvvmView : Attribute
    {
    }
}
