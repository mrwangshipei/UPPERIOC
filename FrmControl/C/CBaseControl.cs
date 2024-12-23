using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmControl.C
{
    public class CBaseControl : Control
    {
        public void DoInvoke(Action Invoker) {
            if (InvokeRequired) { 
            this.Invoke(Invoker);
            }
            else
            {
                Invoker?.Invoke(); ;
            }
        }
    }
}
