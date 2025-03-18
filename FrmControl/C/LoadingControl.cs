using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Xml;
using Timer = System.Windows.Forms.Timer;

namespace UpperComAutoTest.MyControls
{
    public partial class LoadingControl : UserControl
    {
        private class TrailSegment
        {
            public float X { get; set; }
            public float Y { get; set; }
            public float Alpha { get; set; }
        }

        private Timer timer;
        private float angle { get {
                return _angle;
            } set
            {
                if (value > 360)
                {
                    value -= 360;
                }
                _angle = value;
            } }
        private float _angle = 0;
        public int AAA { get; set; }
        private const float radius = 70;
        private const int qq= 0;
        private float speedFactor =15;
        private float baseSpeed = 10;
        public float SpeedMultiplier { get=> baseSpeed; set=> baseSpeed =value; } 
        public Image Image { get; set; }
        private const int LastCount = 10;
        private Queue<TrailSegment>[] trails;

        public LoadingControl()
        {
            this.DoubleBuffered = true;
            timer = new Timer { Interval = 50 };
            timer.Tick += (s, e) =>
            {
                speedFactor = (float)(AAA * Math.Sin((angle + qq * 360) / 920)); // Sinusoidal speed change
                angle += baseSpeed +  speedFactor ;

                //UpdateTrails();
                Invalidate();
            };
            timer.Start();

        }

   
        public float Onems { get; set; } = 5000f;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;


            // 获取当前的时间毫秒数，并计算在 Onems 范围内的余数
          //  float timeProgress = (DateTime.Now.Ticks % Onems) / (float)Onems; // 计算时间在周期内的进度，0 到 1 之间

            // 使用 Sin 函数来平滑计算角度
         //   float angle =(float)( 360 * timeProgress * Math.Sin(timeProgress * 2 * Math.PI));
            // Save the current graphics state
            GraphicsState state = g.Save();

            // Move the origin to the center of the control
            PointF center = new PointF(Width / 2, Height / 2);
            g.TranslateTransform(center.X, center.Y);

            // Rotate around the new origin (which is now the center of the control)
            g.RotateTransform(angle);

            // Draw the image centered at the origin
            if (Image != null)
            {
                int imgSize = (int)(radius * 1.2); // Fixed scaling to center image
                g.DrawImage(Image, -imgSize / 2, -imgSize / 2, imgSize, imgSize);
            }

            // Restore the original graphics state
            g.Restore(state);
        }


    }

    // Extension method for drawing rounded rectangles
    public static class GraphicsExtensions
    {
        public static void FillRoundedRectangle(this Graphics g, Brush brush, RectangleF rect, float radius)
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddLine(rect.X + radius, rect.Y, rect.X + rect.Width - radius, rect.Y);
                path.AddArc(rect.X + rect.Width - radius * 2, rect.Y, radius * 2, radius * 2, 270, 90);
                path.AddLine(rect.X + rect.Width, rect.Y + radius, rect.X + rect.Width, rect.Y + rect.Height - radius);
                path.AddArc(rect.X + rect.Width - radius * 2, rect.Y + rect.Height - radius * 2, radius * 2, radius * 2, 0, 90);
                path.AddLine(rect.X + rect.Width - radius, rect.Y + rect.Height, rect.X + radius, rect.Y + rect.Height);
                path.AddArc(rect.X, rect.Y + rect.Height - radius * 2, radius * 2, radius * 2, 90, 90);
                path.AddLine(rect.X, rect.Y + rect.Height - radius, rect.X, rect.Y + radius);
                path.AddArc(rect.X, rect.Y, radius * 2, radius * 2, 180, 90);
                path.CloseFigure();
                g.FillPath(brush, path);
            }
        }
    }
}
