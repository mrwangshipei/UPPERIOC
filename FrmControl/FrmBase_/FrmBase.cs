using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrmControl.FrmBase_
{
    public class FrmBase:Form
    {
        private int radius = 0;

        public int Radius
        {
            get => radius; set
            {

                radius = value;
                ResetRegion();
            }
        }

        private void ResetRegion()
        {
            this.Region = new Region(this.ClientRectangle.CreateRoundedRectanglePath(Radius));
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FrmBase
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "FrmBase";
            this.ResumeLayout(false);

        }
    }
}
