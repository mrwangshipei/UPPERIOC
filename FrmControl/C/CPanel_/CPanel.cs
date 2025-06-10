using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FCT.Model;
using FrmControl.C.Base;
using UPPERIOC2.UPPER.MVVM.Extension;
using Timer = System.Windows.Forms.Timer;

namespace FrmControl.C.CPanel_
{
    public class CPanel:CBasePanel
    {
        public Color backTColor ;
        private float backTColorTran = 0.25f;
        private int radius = 5;

        public Color BackTColor 
        { 
            get => backTColor; 
            set 
            { 
                backTColor = value;
                Invalidate(); 
            } 
        }
        public float BackTColorTran 
        { 
            get => backTColorTran; 
            set 
            { 
                backTColorTran = value;
            Invalidate();

            }
        }
        public int Radius
        { 
            get => radius;
            set 
            {
                radius = value;
                Invalidate();
            }
        }
    
      
        // ------- 构造函数 -------
        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
          
        }
        // —— 私有字段 —— 

        private Bitmap _originalSnapshot = null;
        private Bitmap _currentBlurred = null;

        /// <summary>
        /// 动画进度：从 0.0f → 1.0f 线性增长。0 表示“最模糊+最小”；1 表示“无模糊+原始大小”。
        /// </summary>
        private float _animationProgress = 0f;

        private Timer _animationTimer;

        /// <summary>
        /// 每帧进度增量（你可以根据需要改成 0.02 或 0.04 等），
        /// 这决定了动画多少帧完成以及时长（Interval × 帧数 ≈ 总时长）。
        /// </summary>
        private const float ProgressStep = 0.05f; // 大约 20 帧从 0→1

        // —— 构造函数 —— 

        public CPanel()
        {
            // 打开双缓冲，减少闪烁
            this.SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.OptimizedDoubleBuffer|
                ControlStyles.SupportsTransparentBackColor,
                true);

         
        }

    
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            Invalidate();
        }
    

        protected override void OnPaddingChanged(EventArgs e)
        {
            base.OnPaddingChanged(e);
            Invalidate();            
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            var g = e.Graphics;
            Rectangle rectangle = this.ClientRectangle;
            rectangle.ChangeRectangle(this.Padding);
            using (var path = rectangle.CreateRoundedRectanglePath(Radius))
            {
                using (Brush br = new SolidBrush(Color.FromArgb((int)(255*BackTColorTran),BackTColor)))
                {
                    g.FillPath(br, path);
                }
            }

        }
    }
}
