using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmControl.C
{
	public class TempForm : Form
    {
        private Button button1;
        private Btn.SliderCtl sliderCtl1;
        private Btn.Apple3Btn apple3Btn1;
        private CCheckBox ucBtnCheckBox1;
        private CPanel_.CPanel cPanel1;

        public TempForm()
		{
            InitializeComponent();

            this.TopMost = true;
			this.VisibleChanged += VisableChanged;
			this.FormBorderStyle = FormBorderStyle.None;
			InitControl();

		}

		private void InitControl()
		{
			
		}

		protected override void OnClosing(CancelEventArgs e)
		{
			e.Cancel = true;
			this.Visible = false; 
		}
		private void VisableChanged(object sender, EventArgs e)
		{
			if (Visible == true)
			{
				this.Location = MousePosition;
				if (!Screen.PrimaryScreen.Bounds.Contains(this.Bounds))
				{
					AdjustFormPosition();
				}
			}
		}

		private void AdjustFormPosition()
		{
			// 获取当前屏幕的工作区域  
			Rectangle screenWorkArea = Screen.PrimaryScreen.WorkingArea;

			// 获取窗体的位置和大小  
			Rectangle formRect = this.RectangleToScreen(this.ClientRectangle);

			// 检查窗体的左边是否超出屏幕左边  
			if (formRect.Left < screenWorkArea.Left)
			{
				this.Left = screenWorkArea.Left;
			}

			// 检查窗体的右边是否超出屏幕右边  
			if (formRect.Right > screenWorkArea.Right)
			{
				this.Left = screenWorkArea.Right - formRect.Width;
			}

			// 检查窗体的顶部是否超出屏幕顶部  
			if (formRect.Top < screenWorkArea.Top)
			{
				this.Top = screenWorkArea.Top;
			}

			// 检查窗体的底部是否超出屏幕底部  
			if (formRect.Bottom > screenWorkArea.Bottom)
			{
				this.Top = screenWorkArea.Bottom - formRect.Height;
			}

			// 如果窗体可能被多个屏幕覆盖，你可能需要遍历所有屏幕并找到最合适的位置  
			// 这里为了简单起见，只考虑了主屏幕  
		}

        private void InitializeComponent()
        {
            this.cPanel1 = new FrmControl.C.CPanel_.CPanel();
            this.ucBtnCheckBox1 = new FrmControl.C.CCheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.sliderCtl1 = new FrmControl.C.Btn.SliderCtl();
            this.apple3Btn1 = new FrmControl.C.Btn.Apple3Btn();
            this.cPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cPanel1
            // 
            this.cPanel1.BackColor = System.Drawing.Color.White;
            this.cPanel1.BackTColor = System.Drawing.Color.Black;
            this.cPanel1.BackTColorTran = 0.25F;
            this.cPanel1.Controls.Add(this.ucBtnCheckBox1);
            this.cPanel1.Controls.Add(this.button1);
            this.cPanel1.Controls.Add(this.sliderCtl1);
            this.cPanel1.Controls.Add(this.apple3Btn1);
            this.cPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.cPanel1.Location = new System.Drawing.Point(0, 0);
            this.cPanel1.Name = "cPanel1";
            this.cPanel1.Padding = new System.Windows.Forms.Padding(4);
            this.cPanel1.Radius = 15;
            this.cPanel1.Size = new System.Drawing.Size(185, 261);
            this.cPanel1.TabIndex = 0;
            // 
            // ucBtnCheckBox1
            // 
            this.ucBtnCheckBox1.BackColor = System.Drawing.Color.Silver;
            this.ucBtnCheckBox1.BtnBackColor = System.Drawing.Color.White;
            this.ucBtnCheckBox1.BtnFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucBtnCheckBox1.BtnForeColor = System.Drawing.Color.White;
            this.ucBtnCheckBox1.BtnText = null;
            this.ucBtnCheckBox1.Checked = false;
            this.ucBtnCheckBox1.CheckLabel = "werwe";
            this.ucBtnCheckBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucBtnCheckBox1.EnabledMouseEffect = false;
            this.ucBtnCheckBox1.FillColor = System.Drawing.Color.Silver;
            this.ucBtnCheckBox1.IsShowTips = false;
            this.ucBtnCheckBox1.Location = new System.Drawing.Point(21, 185);
            this.ucBtnCheckBox1.Margin = new System.Windows.Forms.Padding(0);
            this.ucBtnCheckBox1.Name = "ucBtnCheckBox1";
            this.ucBtnCheckBox1.Radio = false;
            this.ucBtnCheckBox1.Radius = 20;
            this.ucBtnCheckBox1.Retlast = new System.Drawing.Rectangle(21, 185, 136, 67);
            this.ucBtnCheckBox1.Size = new System.Drawing.Size(136, 67);
            this.ucBtnCheckBox1.TabIndex = 3;
            this.ucBtnCheckBox1.TabStop = false;
            this.ucBtnCheckBox1.Text = "ucBtnCheckBox1";
            this.ucBtnCheckBox1.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.ucBtnCheckBox1.TipsText = "";
            this.ucBtnCheckBox1.UnCheckLabel = "ewr";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(34, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 53);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // sliderCtl1
            // 
            this.sliderCtl1.Location = new System.Drawing.Point(7, 138);
            this.sliderCtl1.MaxValue = 100D;
            this.sliderCtl1.MinUnit = 1D;
            this.sliderCtl1.MinValue = 0D;
            this.sliderCtl1.Name = "sliderCtl1";
            this.sliderCtl1.Radius = 0;
            this.sliderCtl1.Retlast = new System.Drawing.Rectangle(0, 0, 150, 72);
            this.sliderCtl1.Size = new System.Drawing.Size(150, 44);
            this.sliderCtl1.SliderColor = System.Drawing.Color.DarkGray;
            this.sliderCtl1.TabIndex = 1;
            this.sliderCtl1.TrackFillColor = System.Drawing.Color.LawnGreen;
            this.sliderCtl1.Value = 50D;
            // 
            // apple3Btn1
            // 
            this.apple3Btn1.BackColor = System.Drawing.Color.Transparent;
            this.apple3Btn1.BtnPad = new System.Windows.Forms.Padding(5);
            this.apple3Btn1.Location = new System.Drawing.Point(29, 82);
            this.apple3Btn1.Margin = new System.Windows.Forms.Padding(0);
            this.apple3Btn1.Name = "apple3Btn1";
            this.apple3Btn1.Size = new System.Drawing.Size(128, 44);
            this.apple3Btn1.TabIndex = 0;
            // 
            // TempForm
            // 
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.cPanel1);
            this.Name = "TempForm";
            this.Load += new System.EventHandler(this.TempForm_Load);
            this.cPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void TempForm_Load(object sender, EventArgs e)
        {
        }
    }
}
