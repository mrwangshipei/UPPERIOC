
using COMIEEE;
using FCT.Model;
using FrmBase_;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FCT.MyControls
{
	public partial class LastResultControl : UserControl
	{
		public Color PassColor { get; set; } = Color.DarkGreen;
		public Color WaitColor{ get; set; } = Color.Orange;
		public Color FailColor { get; set; } = Color.FromArgb(128, 255, 255);
        private int result  = 2;

		public int NowResult
		{
			get { return result; }
			set {
				LastResult = result;

				result = value;
				if (value == 3)
				{
					SetBackColorChanged(WaitColor);
					NowText = "Test";
				}
				else if (value ==2)
				{
					SetBackColorChanged(WaitColor);
					NowText = "Wait";
				}
				else if (value == 1)
				{
					NowText = "Pass";

					SetBackColorChanged(PassColor);
				}
				else
				{
					NowText = "Fail";

					SetBackColorChanged(FailColor);

				}
			}
		}

		private int lastresult = 2;

		public int LastResult
		{
			get { return lastresult; }
			set
			{
				lastresult = value;
				if (value == 2)
				{
					panel_last.BackColor = WaitColor;
					label_last.Text = "Wait";

				}
				else if (value == 1)
				{
					label_last.Text = "Pass";

					panel_last.BackColor = PassColor;
				}
				else

				{
					label_last.Text = "Fail";
					panel_last.BackColor = WaitColor;

				}
			}
		}

		public LastResultControl()
		{
			InitializeComponent();
			SetRightClick(this);
		}

		private void SetRightClick(Control lastResultControl)
		{
			lastResultControl.MouseClick += ShowRightBox;
			foreach (Control item in lastResultControl.Controls)
			{
				SetRightClick(item);
			}
		}

		private void ShowRightBox(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				contextMenuStrip1.Show(MousePosition);
			}
		}

		public void SetResult(int r) {
			if (r == 1)
			{
			pnc.All++;
				pnc.Pass++;
			}
			else if (r == 0)
			{
			pnc.All++;
				pnc.Fail ++;
			}
			else
			{
				return;
			}
			DoInvoke(() =>{
			NowResult = r;
			DoInvoke(()=> Init( pnc));
			panel3.Invalidate();
			});
		}

		internal void StartTest()
		{
			var t = NowResult;
			NowResult = 3;
			result = t;
		}

		public PNCountModel pnc;
		public void Init( PNCountModel pnc) 
		{
			if (this.pnc != pnc)
			{
				this.pnc = pnc;
			}
			labelall.Text = "总数:" + pnc.All;
			labelpass.Text = "合格数:" + pnc.Pass;
			labelfail.Text = "不合格数:" + pnc.Fail;
			panel3.Invalidate();

		}
		public void DoInvoke(Action act)
		{
			if (InvokeRequired)
			{
				this.Invoke(new Action(() => {
					act.Invoke();
				}));
			}
			else
			{
				act.Invoke();
			}
		}

		private void SetBackColorChanged(Color color)
		{
			foreach (Control item in panel_now.Controls)
			{
				if (item  == label2)
				{
					continue;
				}
				NowBackColor = color;
			}
			
		}

	
		private void panel3_Paint(object sender, PaintEventArgs e)
		{
			
			if (pnc == null || pnc.All == 0)
			{
				label3.Text = "良率:0.00%";

				return;
			}
			var c = sender as Panel;
			var g = e.Graphics;
			var persent = (pnc.Pass * 1.0f)/pnc.All;
			g.FillRectangle(Brushes.LightGreen, new RectangleF( new  PointF(0 ,0),new SizeF(c.Width * persent,c.Height)));
			g.FillRectangle(new SolidBrush(FailColor), new RectangleF( new  PointF(c.Width * persent, 0),new SizeF(c.Width * (1 - persent),c.Height)));
			label3.Text = "良率:" + (Math.Round((double)persent * 100, 2)) + "%";
		}
		public void Clear() {
			pnc.All = 0;
			pnc.Pass = 0;
			pnc.Fail = 0;
			Init( pnc);

		}
		private void 清零测试数据ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (pnc == null)
			{
				return;
			}
			var r =FrmDialog.ShowDialog(this.FindForm(),"确认清除测试数据吗","警告");
			if (r != DialogResult.OK)
			{
				return;
			}
			Clear();		
			}
        public string NowText { get => nowText; set {
				panel_now.Invalidate();
				nowText = value;
			} }
        string nowText = "Wait";
		public Color NowBackColor
		{
			get => nowc; set
			{
				panel_now.Invalidate();
				nowc = value;
			}
		}
		Color nowc = Color.Orange;

		private void panel_now_Paint(object sender, PaintEventArgs e)
		{
			
			var g = e.Graphics;
			var ft =new Font("黑体", 12,FontStyle.Bold);
			var siz = g.MeasureString(NowText,ft);
			g.FillRectangle(new SolidBrush(NowBackColor),this.ClientRectangle);
			g.DrawString(NowText, ft,new SolidBrush(ForeColor),(panel_now.Width /2) - siz.Width /2,panel_now.Height / 2 - siz.Height /2 );
		}
	}
}
