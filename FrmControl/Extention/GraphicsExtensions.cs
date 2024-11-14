
// 扩展Graphics类以支持绘制圆角矩形
using System.Drawing.Drawing2D;
using System.Drawing;

public static class GraphicsExtensions
{
	public static GraphicsPath GetRoundedRectangle( Rectangle rect, float radius)
	{
		GraphicsPath path = new GraphicsPath();
		if (radius == 0)
		{
				path.AddRectangle(rect);
			return path;
		}
		{
			path.AddArc(rect.Left, rect.Top, radius * 2, radius * 2, 180, 90);
			path.AddArc(rect.Right - radius * 2, rect.Top, radius * 2, radius * 2, 270, 90);
			path.AddArc(rect.Right - radius * 2, rect.Bottom - radius * 2, radius * 2, radius * 2, 0, 90);
			path.AddArc(rect.Left, rect.Bottom - radius * 2, radius * 2, radius * 2, 90, 90);
			path.CloseFigure();
			return path;
		}
	}
	public static void DrawRoundedRectangle(this Graphics graphics, Pen pen, Rectangle rect, int radius)
	{
		using (GraphicsPath path = new GraphicsPath())
		{
			path.AddArc(rect.Left, rect.Top, radius * 2, radius * 2, 180, 90);
			path.AddArc(rect.Right - radius * 2, rect.Top, radius * 2, radius * 2, 270, 90);
			path.AddArc(rect.Right - radius * 2, rect.Bottom - radius * 2, radius * 2, radius * 2, 0, 90);
			path.AddArc(rect.Left, rect.Bottom - radius * 2, radius * 2, radius * 2, 90, 90);
			path.CloseFigure();
			graphics.DrawPath(pen, path);
		}
	}

	public static void FillRoundedRectangle(this Graphics graphics, Brush brush, Rectangle rect, int radius)
	{
		using (GraphicsPath path = new GraphicsPath())
		{
			path.AddArc(rect.Left, rect.Top, radius * 2, radius * 2, 180, 90);
			path.AddArc(rect.Right - radius * 2, rect.Top, radius * 2, radius * 2, 270, 90);
			path.AddArc(rect.Right - radius * 2, rect.Bottom - radius * 2, radius * 2, radius * 2, 0, 90);
			path.AddArc(rect.Left, rect.Bottom - radius * 2, radius * 2, radius * 2, 90, 90);
			path.CloseFigure();
			graphics.FillPath(brush, path);
		}
	}
}