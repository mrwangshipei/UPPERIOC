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
        private UCBtnCheckBox ucBtnCheckBox1;

        public TempForm()
		{
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TempForm));
            this.ucBtnCheckBox1 = new FrmControl.C.UCBtnCheckBox();
            this.SuspendLayout();
            // 
            // ucBtnCheckBox1
            // 
            this.ucBtnCheckBox1.BackColor = System.Drawing.Color.Silver;
            this.ucBtnCheckBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ucBtnCheckBox1.BackgroundImage")));
            this.ucBtnCheckBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ucBtnCheckBox1.BtnBackColor = System.Drawing.Color.White;
            this.ucBtnCheckBox1.BtnFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucBtnCheckBox1.BtnForeColor = System.Drawing.Color.White;
            this.ucBtnCheckBox1.BtnText = null;
            this.ucBtnCheckBox1.Checked = false;
            this.ucBtnCheckBox1.CheckLabel = null;
            this.ucBtnCheckBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucBtnCheckBox1.EnabledMouseEffect = false;
            this.ucBtnCheckBox1.FillColor = System.Drawing.Color.Silver;
            this.ucBtnCheckBox1.IsShowTips = false;
            this.ucBtnCheckBox1.Location = new System.Drawing.Point(49, 65);
            this.ucBtnCheckBox1.Margin = new System.Windows.Forms.Padding(0);
            this.ucBtnCheckBox1.Name = "ucBtnCheckBox1";
            this.ucBtnCheckBox1.Radio = false;
            this.ucBtnCheckBox1.Size = new System.Drawing.Size(180, 56);
            this.ucBtnCheckBox1.TabIndex = 0;
            this.ucBtnCheckBox1.TabStop = false;
            this.ucBtnCheckBox1.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.ucBtnCheckBox1.TipsText = "";
            this.ucBtnCheckBox1.UnCheckLabel = null;
            // 
            // TempForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.ucBtnCheckBox1);
            this.Name = "TempForm";
            this.ResumeLayout(false);

        }
    }
}
