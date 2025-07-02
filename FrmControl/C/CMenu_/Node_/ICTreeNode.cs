using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrmControl.C.CMenu_.Paint_;

namespace FrmControl.C.CMenu_.Node_
{
    public abstract class ICTreeNode: IPaint
    {
        public string Text { get; set; }
        public bool Selected { get; set; }
        public abstract void OnPaint(Rectangle rect, Graphics g, Color nodeBackColor, Color nodeForeColor, Color selectedNodeBackColor, Color selectedNodeForeColor,Font Font);
    }
}
