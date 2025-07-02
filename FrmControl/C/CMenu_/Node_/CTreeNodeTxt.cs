using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrmControl.C.CMenu_.Node_
{
    public class CTreeNodeTxt : ICTreeNode
    {



        public override void OnPaint(Rectangle rect, Graphics g, Color nodeBackColor, Color nodeForeColor, Color selectedNodeBackColor, Color selectedNodeForeColor, Font font)
        {
            // 选择背景色与前景色
            Color backColor = Selected ? selectedNodeBackColor : nodeBackColor;
            Color foreColor = Selected ? selectedNodeForeColor : nodeForeColor;

            // 填充背景
            using (Brush backBrush = new SolidBrush(backColor))
            {
                g.FillRectangle(backBrush, rect);
            }

            // 测量文本
            SizeF textSize = g.MeasureString(Text, font);

            // 计算居中的绘制位置
            float x = rect.X + (rect.Width - textSize.Width) / 2;
            float y = rect.Y + (rect.Height - textSize.Height) / 2;

            // 设置文本绘制格式
            using (Brush textBrush = new SolidBrush(foreColor))
            {
                g.DrawString(Text, font, textBrush, x, y);
            }

            // 可选：绘制边框（调试或美观用）
            // g.DrawRectangle(Pens.Gray, rect);
        }
    }
}
