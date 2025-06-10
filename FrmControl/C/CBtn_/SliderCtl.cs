using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;
  using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;
using FrmControl.C.Base;

namespace FrmControl.C.Btn
{
    public class SliderCtl : CBaseControl
    {
        public event EventHandler<double> OnValueChanged;
        // 属性定义
        public double MaxValue { get; set; } = 100; // 默认最大值
        public double MinValue { get; set; } = 0;   // 默认最小值
        public double Value
        {
            get => _value;
            set
            {
                _value = ClampToMinUnit(value, MinValue, MaxValue, MinUnit);
                OnValueChanged?.Invoke(this, value);
                Invalidate(); // 触发重绘 
            }
        }
        private double _value = 50; // 默认值

        public double MinUnit { get; set; } = 1; // 最小单位，默认为 1

        public Color SliderColor { get; set; } = Color.DarkGray; // 滑块颜色
        public Color TrackFillColor { get; set; } = Color.LawnGreen; // 已划过区域的默认颜色

        private bool isDragging = false; // 标记是否正在拖动滑块
        private int sliderHeight = 30;   // 滑块高度
        private int sliderWidth = 20;    // 滑块宽度（固定大小）

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var gp = e.Graphics;
            gp.SmoothingMode = SmoothingMode.AntiAlias;

            // 计算轨道范围
            int trackWidth = Width - sliderWidth - 2; // 轨道宽度（减去滑块宽度）
            int trackX = sliderWidth / 2;         // 轨道 X 坐标
            int sliderX = CalculateSliderPosition(trackWidth, trackX);

            // 绘制已划过的部分
            int filledWidth = sliderX - trackX;
            using (var brush = new SolidBrush(TrackFillColor))
            {
                gp.FillRectangle(brush, new Rectangle(trackX, Height / 2 - sliderHeight / 2, filledWidth, sliderHeight));
            }

            // 绘制未划过的部分
            int unfilledWidth = trackWidth - filledWidth;
            using (var brush = new SolidBrush(Color.LightGray))
            {
                gp.FillRectangle(brush, new Rectangle(sliderX, Height / 2 - sliderHeight / 2, unfilledWidth, sliderHeight));
            }

            // 绘制滑块
            using (var brush = new SolidBrush(SliderColor))
            {
                gp.FillRectangle(brush, new Rectangle(sliderX - sliderWidth / 2, Height / 2 - sliderHeight / 2, sliderWidth, sliderHeight));
            }

            // 绘制滑块边框
            using (var pen = new Pen(Color.Black, 2))
            {
                gp.DrawRectangle(pen, new Rectangle(sliderX - sliderWidth / 2, Height / 2 - sliderHeight / 2, sliderWidth, sliderHeight));
            }
        }

        private int CalculateSliderPosition(int trackWidth, int trackX)
        {
            // 根据 Value 计算滑块的 X 坐标，并确保滑块不会超出轨道范围
            double normalizedValue = (Value - MinValue) / (MaxValue - MinValue);
            return trackX + (int)(trackWidth * normalizedValue);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                UpdateValueFromMouse(e.X);
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (isDragging && e.Button == MouseButtons.Left)
            {
                UpdateValueFromMouse(e.X);
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            isDragging = false;
        }

        private void UpdateValueFromMouse(int mouseX)
        {
            int trackWidth = Width - sliderWidth;
            int trackX = sliderWidth / 2;

            // 确保鼠标 X 坐标在轨道范围内
            mouseX = Clamp(mouseX, trackX, trackX + trackWidth);

            // 根据鼠标位置计算新的 Value
            double normalizedPosition = (mouseX - trackX) / (double)trackWidth;
            double newValue = MinValue + normalizedPosition * (MaxValue - MinValue);

            // 将 newValue 调整为 MinUnit 的倍数
            Value = ClampToMinUnit(newValue, MinValue, MaxValue, MinUnit);
        }

        // 替代 Math.Clamp 并确保值是 MinUnit 的倍数
        private static double ClampToMinUnit(double value, double min, double max, double minUnit)
        {
            // 确保 value 在 [min, max] 范围内
            value = value < min ? min : (value > max ? max : value);

            // 将 value 调整为 minUnit 的倍数
            double roundedValue = Math.Round((value - min) / minUnit) * minUnit + min;
            return roundedValue;
        }

        // 替代 Math.Clamp 的方法
        private static double Clamp(double value, double min, double max)
        {
            return value < min ? min : (value > max ? max : value);
        }

        private static int Clamp(int value, int min, int max)
        {
            return value < min ? min : (value > max ? max : value);
        }
    }
}
