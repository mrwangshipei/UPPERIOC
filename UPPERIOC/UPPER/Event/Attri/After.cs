using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPPERIOC.UPPER.Event.Attri
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    sealed class AfterAttribute : Attribute
    {
        // See the attribute guidelines at 
        //  http://go.microsoft.com/fwlink/?LinkId=85236
        readonly string after;

        // This is a positional argument
        public AfterAttribute(string after)
        {
            this.after = after;

            // TODO: Implement code here

            if (!Debugger.IsAttached)
            {
                Debugger.Launch();
            }
        }

        public string After
        {
            get { return after; }
        }

    }
}
