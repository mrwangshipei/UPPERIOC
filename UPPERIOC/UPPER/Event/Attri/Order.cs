using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPPERIOC.UPPER.Event.Attri
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    sealed class OrderAttribute : Attribute
    {
        // See the attribute guidelines at 
        //  http://go.microsoft.com/fwlink/?LinkId=85236
        readonly int order;

        // This is a positional argument
        public OrderAttribute(int order)
        {
            this.order = order;

            // TODO: Implement code here

            throw new NotImplementedException();
        }

        public int Order
        {
            get { return order; }
        }

    }
}
