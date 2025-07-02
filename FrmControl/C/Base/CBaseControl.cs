using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private Padding radiusAngle;

        [Browsable(true)]
        [Category("外观")]
        [Description("设置圆角半径（分别代表左上、右上、右下、左下），0 表示无圆角")]
        [CornerRadius("每个值对应一个角的圆角大小，单位为像素")]
        public Padding RadiusAngle { get => radiusAngle; set{ radiusAngle = value; 
                ResetRegion();

            }
        }
        [Browsable(true)]
        [Category("外观")]
        [Description("设置总的圆角")]
        [CornerRadius("圆角大小，单位为像素")]
        public int Radius
        {
            get => radius; set
            {

                radius = value;
                ResetRegion();
            }
        }
        public CBaseControl() {
            SetStyle( ControlStyles.SupportsTransparentBackColor,true);
        }
        private Rectangle Retlast { get => retlast; set => retlast = value; }

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
                if (RadiusAngle == new Padding()) { 
                    this.Region = new Region(this.ClientRectangle.CreateRoundedRectanglePath(Radius));
                }
                else
                {
                    this.Region = new Region(this.ClientRectangle.CreateRoundedRectanglePath( RadiusAngle));

                }
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
