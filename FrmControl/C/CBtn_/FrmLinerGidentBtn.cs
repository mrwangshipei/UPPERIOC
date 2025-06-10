using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmControl.C.Btn
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using FrmControl.C.Base;
    using FrmControl.C.Btn.UPPERIOC2.UPPER.Util;
    using FrmControl.FrmBase_;

    namespace UPPERIOC2.UPPER.Util
    {
        public class AnimationUtil
        {

            private bool _isRunning = false;
            public static AnimationUtil Instance { get; private set; } = new AnimationUtil();
            public ConcurrentQueue<KeyValuePair<int, Action<int>>> Data = new ConcurrentQueue<KeyValuePair<int, Action<int>>>();
            public AnimationUtil()
            {
                _isRunning = true;
                Task.Factory.StartNew(() => {
                    List<KeyValuePair<int, Action<int>>> Data = new List<KeyValuePair<int, Action<int>>>();
                    List<KeyValuePair<int, Action<int>>> DelTemp = new List<KeyValuePair<int, Action<int>>>();
                    while (_isRunning)
                    {

                        if (this.Data.TryDequeue(out var x))
                        {
                            Data.Add(x);
                        }
                        using (var e = Data.GetEnumerator())
                        {
                            while (e.MoveNext())
                            {
                                e.Current.Key -= 20;
                                if (e.Current.Key <= 0)
                                {
                                    DelTemp.Add(e.Current);
                                }
                                e.Current.Value.Invoke(e.Current.Key);
                            }
                        }
                        Data.RemoveAll(item => DelTemp.Contains(item));
                        DelTemp.Clear();
                        Thread.Sleep(20);
                    }
                });
            }
            ~AnimationUtil()
            {
                _isRunning &= false;
            }
            public void SetAnimation(int AllTime, Action<int> Invoke)
            {
                Data.Enqueue(new KeyValuePair<int, Action<int>>(AllTime, Invoke));
            }
        }
        public class KeyValuePair<TKey, TValue>
        {
            public TKey Key { get; set; }
            public TValue Value { get; set; }
            public KeyValuePair(TKey key, TValue value)
            {
                Key = key;
                Value = value;
            }
        }
    }
    //渐变动画框
    [DefaultEvent("Click")]
    public partial class FrmLinerGidentBtn : CBaseControl
    {
        public int SizeCLick { get; set; } = 70;
        [Description("0~1的向量")]
        public PointF Direction { get; set; } = new PointF(0,1);
        public Color Color1 { get; set; } = Color.LightGray;
        public Color Color2 { get; set; } = Color.DimGray;
        public Color Color3 { get; set; } = Color.LightGray;
        public string BtnText { get;  set; }

        private PointF MousePosition = new PointF(-1,-1);
        private PointF Mousein = new PointF(0,0) ;
        private PointF Mousedown = new PointF(0,0) ;
        public FrmLinerGidentBtn()
        {
            SetStyle( ControlStyles.SupportsTransparentBackColor,true);
            this.DoubleBuffered = true;
            InitializeComponent();
        }
        protected override void OnMouseEnter(EventArgs e)

        {
             Mousein.Y = 1;
             MousePosition = Control.MousePosition;
            AnimationUtil.Instance.SetAnimation(100, x => {
                if (x % 20 == 0)
                {
                    DoInvoke(() =>{
                    Mousein.X = (100-x)*1.0f / 100;

                    this.Refresh();
                    });

                }
            });
            
            base.OnMouseEnter(e);

        }

        public void PreFormClick() {
            EventArgs e = new EventArgs();
            // 调用控件的OnClick方法，手动触发点击事件
            this.OnClick(e);
        }
        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
      
            Mousedown.Y = 1;
            MousePosition =(e.Location);
            AnimationUtil.Instance.SetAnimation(100, x => {
                Mousedown.X = (100-x) * 1.0f / 100;
                if (x % 10 == 0)
                {
                    DoInvoke(() => {

                        this.Refresh();
                    });

                }
            });
            //this.Invalidate();

            base.OnMouseDown(e);
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            Mousein.Y = 0;
            MousePosition = new PointF(-1, -1);
            this.Invalidate();
            base.OnMouseLeave(e);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);    
            var g = e.Graphics;
            if (Mousein.Y == 0)
            {
                using (var gb = new LinearGradientBrush(new PointF(0, 0), new PointF(Direction.X * Width, Direction.Y * Height), Color1, Color2))
                {
                    gb.InterpolationColors = new ColorBlend() { Colors = new Color[] { Color1, Color2, Color3 }, Positions = new float[] { Direction.X, 0.5f * (Direction.X + Direction.Y), Direction.Y } };
                    //gb.InterpolationColors.Colors ;
                    //gb.InterpolationColors.Positions= new float[] { Direction.X, 0.5f * (Direction.X + Direction.Y),Direction.Y};
                    g.FillRectangle(gb, this.ClientRectangle);
                }
            }
            else  if (Mousein.Y != 0)
            {
                using (var gb = new LinearGradientBrush(new PointF(0, 0), new PointF(Direction.X * Width, Direction.Y * Height), Color1, Color2))
                {
                    gb.InterpolationColors =  new ColorBlend() {
                        Colors = new Color[] { Color1, Color2, Color2, Color3 },
                        Positions = new float[] { Direction.X, 0.5f- (Mousein.X) * 0.25f * (Direction.X + Direction.Y) , 0.5f + (Mousein.X ) * 0.25f  * (Direction.X + Direction.Y), Direction.Y }
                    };

                   // gb.InterpolationColors.Colors = new Color[] { Color1, Color2, Color2, Color3 };
                  //  gb.InterpolationColors.Positions = new float[] { Direction.X, (1 - Mousein.X) * 0.25f * (Direction.X + Direction.Y), (1 - Mousein.X) * 0.75f * (Direction.X + Direction.Y), Direction.Y };
                    g.FillRectangle(gb, this.ClientRectangle);
                }

                // 创建一个图形路径
                if (Mousedown.Y != 0)
                {

                    using (GraphicsPath path = new GraphicsPath())
                    {
                        float wid = SizeCLick * Mousedown.X + 1, hei = SizeCLick * Mousedown.X + 1;
                        path.AddEllipse(MousePosition.X - wid/2,MousePosition.Y - hei/2, wid,hei); // 
                        // 创建一个PathGradientBrush，使用图形路径
                        using (PathGradientBrush pthGrBrush = new PathGradientBrush(path))
                        {
                            // 设置渐变的中心颜色和外围颜色
                            pthGrBrush.CenterColor = Color.FromArgb((int)(255 *(1- Mousedown.X)),Color1);
                            pthGrBrush.SurroundColors = new Color[] { Color.FromArgb((int)(255 * (1 - Mousedown.X)), Color2) };
                    // 使用画刷填充路径
                            g.FillPath(pthGrBrush, path);
                        }
                    } ;
                }

            }

            /* // 设置文本格式（如果需要）
             StringFormat sf = new StringFormat();
             sf.Alignment = StringAlignment.Center; // 水平居中
             sf.LineAlignment = StringAlignment.Center; // 垂直居中
 */
            // 计算文本尺寸
            SizeF textSize = g.MeasureString(BtnText, this.Font);

            // 计算文本位置
            PointF textLocation = new PointF(
                (ClientRectangle.Width - textSize.Width) / 2,
                (ClientRectangle.Height - textSize.Height) / 2);

            // 绘制文本
            using (var b = new SolidBrush(ForeColor))
            {
                g.DrawString(BtnText, this.Font, b, textLocation);
            }
         
        }
    }
}
