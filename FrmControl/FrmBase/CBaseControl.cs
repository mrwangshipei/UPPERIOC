using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmControl.FrmBase
{
    public class CBaseControl : Control
    {
        public void DoInvoke(Action Invoker)
        {
            if (InvokeRequired)
            {
                Invoke(Invoker);
            }
            else
            {
                Invoker?.Invoke(); ;
            }
        }
    }
}
