using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Xml;
using Timer = System.Windows.Forms.Timer;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using FrmControl.C.Base;


namespace FrmControl.C.ProgressBar
{

    public  class TextProgressBar : CBaseControl
    {
        private float progress = 0.5f;
        private string displayText = "PROCESS";
        private Color progressColor = Color.LimeGreen;
        private Color textColor = Color.Black;
        private Color backgroundColor = Color.White;
        float waveWidth = 50f;    // 一个完整波长（包括上升+下降）
        float waveHeight = 15f;    // 波峰高度
        private float waveOffset = 0f; // 控制波浪的偏移位置（可随时间变化实现动画）
        private float waveOffset1  = 25;  // 控制波浪的偏移位置（可随时间变化实现动画）
        public Color progressColor2 { get;  set; } = Color.Gray;
        public float animationspeed = 3;
        public Timer tm = new Timer();
        public TextProgressBar()
        {
            DoubleBuffered = true;
            Font = new Font("Arial", 48, FontStyle.Bold);
            Size = new Size(300, 100);
            tm.Tick += (e, arg) => {
                waveOffset1 += Animationspeed * 2;
                waveOffset += Animationspeed;
                if (waveOffset < 0) {
                    waveOffset = 0;
                }
                if (waveOffset1 <0)
                {
                    waveOffset1 = 0;
                }
                Invalidate();
            };
            tm.Interval = 45;
        }
        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (Visible)
            {
                tm.Start();
            }
            else
            {
                tm.Stop();
            }
        }
        [Category("Behavior")]
        [Description("显示的文字")]
        public string DisplayText
        {
            get => displayText;
            set { displayText = value; Invalidate(); }
        }

        [Category("Behavior")]
        [Description("显示的文字")]
        public float Animationspeed
        {
            get => animationspeed;
            set { animationspeed = value; Invalidate(); }
        }
        [Category("Behavior")]
        [Description("波宽")]
        public float WaveWidth
        {
            get => waveWidth;
            set { waveWidth = value; Invalidate(); }
        }
        [Category("Behavior")]
        [Description("波高")]
        public float WaveHeight
        {
            get => waveHeight;
            set { waveHeight = value; Invalidate(); }
        }

        [Category("Behavior")]
        [Description("进度值（0.0 - 1.0）")]
        public float Progress
        {
            get => progress;
            set
            {
                progress = Math.Min(1.0f, Math.Max(0.0f, value));
                Invalidate();
            }
        }

        [Category("Appearance")]
        public Color ProgressColor
        {
            get => progressColor;
            set { progressColor = value; Invalidate(); }
        }

        [Category("Appearance")]
        public Color ProgressColor2
        {
            get => progressColor2;
            set { progressColor2 = value; Invalidate(); }
        }

        [Category("Appearance")]
        public Color TextColor
        {
            get => textColor;
            set { textColor = value; Invalidate(); }
        }

        [Category("Appearance")]
        public Color BackgroundColor
        {
            get => backgroundColor;
            set { backgroundColor = value; Invalidate(); }
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

            g.Clear(backgroundColor);

            // 测量文字位置
            SizeF textSize = g.MeasureString(displayText, Font);
            PointF textPos = new PointF((Width - textSize.Width) / 2, (Height - textSize.Height) / 2);

            // 创建文字路径
            GraphicsPath path = new GraphicsPath();
            path.AddString(displayText, Font.FontFamily, (int)Font.Style, g.DpiY * Font.Size / 72, textPos, StringFormat.GenericDefault);

            RectangleF bounds = path.GetBounds();
            float progressHeight = bounds.Height * progress;
            float startY = bounds.Y + bounds.Height - progressHeight;

            // 创建波浪路径
            GraphicsPath wavePath = new GraphicsPath();
           
            float startX = bounds.X - waveWidth + waveOffset % waveWidth;
            float endX = bounds.Right + waveWidth;

            PointF prevPoint = new PointF(startX, startY);
            // 用 sin 波形创建波浪路径
            wavePath.StartFigure();

            List<PointF> wavePoints = new List<PointF>();
            for (float x = startX; x <= endX; x += 1f) // 小步进，生成更多点更平滑
            {
                float y = (float)(Math.Sin((x + waveOffset) / waveWidth * 2 * Math.PI) * waveHeight / 2);
                wavePoints.Add(new PointF(x, startY + y));
            }
            wavePath.AddLines(wavePoints.ToArray());
            // 关闭底部（兼容旧版本）
            PointF lastPoint = wavePoints[wavePoints.Count - 1];
            wavePath.AddLine(lastPoint, new PointF(bounds.Right, bounds.Bottom));
            wavePath.AddLine(new PointF(bounds.Right, bounds.Bottom), new PointF(bounds.X, bounds.Bottom));
            wavePath.CloseFigure();
            //第二个波形
            GraphicsPath wavePath2 = new GraphicsPath();


            // 用 sin 波形创建波浪路径
            wavePath2.StartFigure();
            float startX2 = bounds.X - waveWidth + waveOffset1 % waveWidth;

            List<PointF> wavePoints2 = new List<PointF>();
            for (float x = startX2; x <= endX; x += 1f) // 小步进，生成更多点更平滑
            {
                float y = (float)(Math.Sin((x + waveOffset1) / waveWidth * 2 * Math.PI) * waveHeight / 2);
                wavePoints2.Add(new PointF(x, startY + y));
            }
            wavePath2.AddLines(wavePoints2.ToArray());
            // 关闭底部（兼容旧版本）
            PointF lastPoint2 = wavePoints2[wavePoints2.Count - 1];
            wavePath2.AddLine(lastPoint2, new PointF(bounds.Right, bounds.Bottom));
            wavePath2.AddLine(new PointF(bounds.Right, bounds.Bottom), new PointF(bounds.X, bounds.Bottom));
            wavePath2.CloseFigure();

            // 剪裁到文字形状
            using (Region clip = new Region(path))
            {
                g.SetClip(clip, CombineMode.Intersect);

           
                // 填充文字颜色（作为“轮廓填充”）
                using (Brush textBrush = new SolidBrush(textColor))
                {
                    g.FillPath(textBrush, path);
                }
                using (Brush waveBrush = new SolidBrush(progressColor2))
                {
                    g.FillPath(waveBrush, wavePath2);
                }

                // 填充波浪形状进度
                using (Brush waveBrush = new SolidBrush(progressColor))
                {
                    g.FillPath(waveBrush, wavePath);
                }

                g.ResetClip();
            }
            // 绘制右下角的百分比文字
            string percentText = $"{(int)(progress * 100)}%";
            using (Font percentFont = new Font(Font.FontFamily, 12f, FontStyle.Regular)) // 调整为实际约12像素高度
            using (Brush percentBrush = new SolidBrush(textColor))
            {
                SizeF percentSize = g.MeasureString(percentText, percentFont);
                PointF percentPos = new PointF(Width - percentSize.Width - 6, Height - percentSize.Height - 4); // 右下角偏移
                g.DrawString(percentText, percentFont, percentBrush, percentPos);
            }

            // 可选：绘制描边增强对比
            using (Pen outlinePen = new Pen(Color.Black, 1))
            {
                g.DrawPath(outlinePen, path);
            }
        }

    }


    // Extension method for drawing rounded rectangles

}
