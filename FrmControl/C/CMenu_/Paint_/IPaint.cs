using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrmControl.C.CMenu_.Paint_
{
    public interface IPaint
    {

         void OnPaint(Rectangle rect, Graphics g, Color nodeBackColor, Color nodeForeColor, Color selectedNodeBackColor, Color selectedNodeForeColor,Font font);

    }
}
