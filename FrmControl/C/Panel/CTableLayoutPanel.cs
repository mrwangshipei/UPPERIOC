using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CustomControls
{
    public partial class CTableLayoutPanel : TableLayoutPanel
    {
        private Color _separatorColor = Color.Black;
        private int _separatorWidth = 1;

        public CTableLayoutPanel()
        {
            // 控件风格
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.UserPaint, true);
        }

        #region 分割线

        /// <summary>
        /// 获取或设置分割线颜色
        /// </summary>
        [Browsable(true), DefaultValue(typeof(Color), "Black"), Description("分割线颜色")]
        [Category("Appearance")]
        public Color SeparatorColor
        {
            get { return _separatorColor; }
            set
            {
                _separatorColor = value;
                Invalidate(); // 重绘面板
            }
        }

        /// <summary>
        /// 获取或设置分割线宽度
        /// </summary>
        [Browsable(true), DefaultValue(1), Description("分割线宽度")]
        [Category("Appearance")]
        public int SeparatorWidth
        {
            get { return _separatorWidth; }
            set
            {
                _separatorWidth = value;
                Invalidate(); // 重绘面板
            }
        }

        #endregion

        protected override void OnCellPaint(TableLayoutCellPaintEventArgs e)
        {
            base.OnCellPaint(e);
            var panel = this as TableLayoutPanel;
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

            using (Pen pen = new Pen(SeparatorColor, SeparatorWidth))
            {
                pen.Alignment = PenAlignment.Center;
                pen.DashStyle = DashStyle.Solid;

                // 绘制列分割线
                if (e.Column < panel.ColumnCount - 1)
                {
                    int x = e.CellBounds.Right - SeparatorWidth / 2;
                    e.Graphics.DrawLine(pen, x, e.CellBounds.Top, x, e.CellBounds.Bottom);
                }

                // 绘制行分割线
                if (e.Row < panel.RowCount - 1)
                {
                    int y = e.CellBounds.Bottom - SeparatorWidth / 2;
                    e.Graphics.DrawLine(pen, e.CellBounds.Left, y, e.CellBounds.Right, y);
                }
            }

        }
    }
}
