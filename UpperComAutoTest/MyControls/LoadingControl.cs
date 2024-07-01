using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace UpperComAutoTest.MyControls
{
	public partial class LoadingControl : UserControl
	{
		private System.Windows.Forms.Timer animationTimer;
		private volatile List<PhysicalObject> objects;
		private PhysicalObject Mouse;
		private int value;
		private System.Windows.Forms.Timer animationTimer2;
		private float waveOffset;

		public int Value
		{
			get { return value; }
			set
			{
				if (value < 0) value = 0;
				if (value > 100) value = 100;
				this.value = value;
				this.Invalidate(); // 重新绘制控件
			}
		}
		protected override void OnHandleDestroyed(EventArgs e)
		{
			Visible = false;
			animationTimer2.Stop();

			base.OnHandleDestroyed(e);
		}
		protected override void OnVisibleChanged(EventArgs e)
		{
			base.OnVisibleChanged(e);

			if (!Visible)
			{
			animationTimer2.Stop();
				animationTimer2.Enabled = false;
			}
		}
		public LoadingControl()
		{
			// 初始化物体列表
			Mouse = new PhysicalObject(new PointF(50, 50), new PointF(2, 3), new PointF(0, 0.1f), 10f);
			objects = new List<PhysicalObject>
		{
				Mouse,
			new PhysicalObject(new PointF(50, 50), new PointF(2, 3), new PointF(0, 0.1f), 10f),
			new PhysicalObject(new PointF(100, 100), new PointF(-2, 1), new PointF(0, 0.1f), 15f)
		};
			base.SetStyle(ControlStyles.UserPaint, true);
			base.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			base.SetStyle(ControlStyles.DoubleBuffer, true);
			this.Value = 0;

			// 初始化定时器
			animationTimer2 = new System.Windows.Forms.Timer();
			animationTimer2.Interval = 10; // 控制动画速度
			animationTimer2.Tick += new EventHandler(OnAnimationTick2);
			animationTimer2.Start();
			// 设置定时器
			Task.Factory.StartNew(() => {
				while (!Created)
				{
					Thread.Sleep(10);
				}
			while (this.Visible)
			{
				this.Invoke(() => {

					if (this.Visible)
					{
						UpdateAnimation(null,null);

					}
				});
					Thread.Sleep(10);
			}
			});
		//	animationTimer = new System.Windows.Forms.Timer();
		//	animationTimer.Interval = 1; // 大约60 FPS
			//animationTimer.Tick += new EventHandler(UpdateAnimation);
		//	animationTimer.Start();
		}
		protected override void OnMouseMove(MouseEventArgs e)		
		{
			base.OnMouseMove(e);
			Mouse.Position = PointToClient(Control.MousePosition);
		}

		private void OnAnimationTick2(object sender, EventArgs e)
		{
			// 更新波浪偏移量以实现动画效果
			/*waveOffset += 0.1f;
			if (waveOffset > 2 * Math.PI)
			{
			waveOffset -=(float)( 2 * Math.PI);
			}*/
			this.Invalidate();
		}


		private void UpdateAnimation(object sender, EventArgs e)
		{
			// 更新所有物体的位置
			for (int i = 0; i < objects.Count; i++)
			{
				var obj = objects[i];
				obj.UpdatePosition(this.ClientSize);
			}
			// 检测并处理物体之间的碰撞
			for (int i = 0; i < objects.Count; i++)
			{
				for (int j = i + 1; j < objects.Count; j++)
				{
					if (objects[i].IsCollidingWith(objects[j]))
					{
						objects[i].ResolveCollision(objects[j]);
					}
				}
			}
		

			// 重新绘制控件
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
		
			/*// 计算绘制波浪的区域
			float progressWidth = this.ClientSize.Width * this.Value / 100f;

			// 设置绘图工具
			using (SolidBrush brush = new SolidBrush(Color.Blue))
			{
				for (int x = 0; x < progressWidth; x++)
				{
					float y = (float)(10 * Math.Sin((x + waveOffset) / 10) + this.ClientSize.Height / 2);
					e.Graphics.FillRectangle(brush, x, y, 1, this.ClientSize.Height - y);
				}
			}*/
			// 绘制所有物体
			Graphics g = e.Graphics;
			foreach (var obj in objects)
			{
				obj.Draw(g);
			}
		}
	}

	public class PhysicalObject
	{
		private readonly object lockObject = new object(); // 用于同步的锁对象
		private PointF position;
		private PointF velocity;
		
		public PointF Position
		{
			get
			{
				lock (lockObject)
				{
					return position;
				}
			}
			set
			{
				lock (lockObject)
				{
					position = value;
				}
			}
		}

		public PointF Velocity
		{
			get
			{
				lock (lockObject)
				{
					return velocity;
				}
			}
			set
			{
				lock (lockObject)
				{
					velocity = value;
				}
			}
		}
		public PointF Acceleration { get; set; }
		public float Radius { get; set; }

		public PhysicalObject(PointF position, PointF velocity, PointF acceleration, float radius)
		{
			Position = position;
			Velocity = velocity;
			Acceleration = acceleration;
			Radius = radius;
		}

		public void UpdatePosition(Size bounds)
		{
			// 更新速度和位置
			Velocity = new PointF(Velocity.X + Acceleration.X, Velocity.Y + Acceleration.Y);
			Position = new PointF(Position.X + Velocity.X, Position.Y + Velocity.Y);

			// 检测边界碰撞并反弹
			if (Position.X - Radius < 0 || Position.X + Radius > bounds.Width)
			{
				Velocity = new PointF(-Velocity.X, Velocity.Y);
				Position = new PointF(Math.Max(Radius, Math.Min(bounds.Width - Radius, Position.X)), Position.Y);
			}
			if (Position.Y - Radius < 0 || Position.Y + Radius > bounds.Height)
			{
				Velocity = new PointF(Velocity.X, -Velocity.Y);
				Position = new PointF(Position.X, Math.Max(Radius, Math.Min(bounds.Height - Radius, Position.Y)));
			}
		}

		public bool IsCollidingWith(PhysicalObject other)
		{
			float dx = Position.X - other.Position.X;
			float dy = Position.Y - other.Position.Y;
			float distance = (float)Math.Sqrt(dx * dx + dy * dy);
			return distance < Radius + other.Radius;
		}

		public void ResolveCollision(PhysicalObject other)
		{
			// 简单弹性碰撞处理
			float dx = other.Position.X - Position.X;
			float dy = other.Position.Y - Position.Y;
			float distance = (float)Math.Sqrt(dx * dx + dy * dy);
			if (distance == 0) return; // 避免除以零

			// 计算碰撞法线向量
			float nx = dx / distance;
			float ny = dy / distance;

			// 计算相对速度
			float vx = Velocity.X - other.Velocity.X;
			float vy = Velocity.Y - other.Velocity.Y;

			// 计算沿法线方向的速度分量
			float vn = vx * nx + vy * ny;

			// 如果物体正在远离，则不处理
			if (vn > 0) return;

			// 简单弹性碰撞响应
			float impulse = 2 * vn / (1 / Radius + 1 / other.Radius);
			Velocity = new PointF(Velocity.X - impulse * nx / Radius, Velocity.Y - impulse * ny / Radius);
			other.Velocity = new PointF(other.Velocity.X + impulse * nx / other.Radius, other.Velocity.Y + impulse * ny / other.Radius);

			/*// 引入阻尼效果，模拟能量损失
			float damping = 0.9f;
			Velocity = new PointF(Velocity.X * damping, Velocity.Y * damping);
			other.Velocity = new PointF(other.Velocity.X * damping, other.Velocity.Y * damping);
*/
			// 调整位置避免重叠，逐步调整以减少生硬感
			float overlap = (Radius + other.Radius - distance) / 2;
			Position = new PointF(Position.X - overlap * nx * 0.5f, Position.Y - overlap * ny * 0.5f);
			other.Position = new PointF(other.Position.X + overlap * nx * 0.5f, other.Position.Y + overlap * ny * 0.5f);
		}

		public void Draw(Graphics g)
		{
			g.FillEllipse(Brushes.White, Position.X - Radius, Position.Y - Radius, Radius * 2, Radius * 2);
		}
	}

}
