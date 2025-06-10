using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmControl.C.Base
{
    public class CBaseControl : Control
    {
        private int radius = 0;
        private Rectangle retlast;

        public int Radius
        {
            get => radius; set
            {

                radius = value;
                ResetRegion();
            }
        }

        public Rectangle Retlast { get => retlast; set => retlast = value; }

        private void ResetRegion()
        {

            if (Radius == 0) {
                return;
            }
            if (Retlast != this.Bounds) {
                if (this.Bounds.Height < 2|| this.Bounds.Width < 2)
                {
                    return;
                }
                this.Region?.Dispose();
                Retlast = this.Bounds;
                this.Region = new Region(this.ClientRectangle.CreateRoundedRectanglePath(Radius));
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            ResetRegion();  
            base.OnPaint(e);
        }
        public void DoInvoke(Action Invoker) {
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
