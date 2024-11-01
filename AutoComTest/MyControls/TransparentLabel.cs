using System;
using System.Drawing;
using System.Windows.Forms;
namespace UpperComAutoTest.MyControls
{
	public partial class TransparentLabel : Control
	{
		public TransparentLabel()
		{
			// 使控件支持透明背景
			this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
			this.BackColor = Color.Transparent;

		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			// 设置文本格式
			TextFormatFlags flags = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPadding;

			// 设置文本颜色
			Color textColor = Color.Black;

			// 设置文本背景色透明
			e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;

			// 使用 TextRenderer 绘制文本
			TextRenderer.DrawText(e.Graphics, this.Text, this.Font, this.ClientRectangle, textColor, flags);
		}
	}
}

