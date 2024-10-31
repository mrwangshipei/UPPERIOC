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
	}
}
