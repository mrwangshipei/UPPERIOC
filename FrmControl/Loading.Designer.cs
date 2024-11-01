using System.Drawing;
using System.Windows.Forms;

namespace UpperComAutoTest.MyControls
{
	partial class Loading
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.loadingControl1 = new UpperComAutoTest.MyControls.LoadingControl();
			this.panel1 = new System.Windows.Forms.Panel();
			this.gradientProgressBar1 = new UpperComAutoTest.MyControls.GradientProgressBar();
			this.label1 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// loadingControl1
			// 
			this.loadingControl1.BackColor = System.Drawing.Color.Black;
			this.loadingControl1.Dock = System.Windows.Forms.DockStyle.Top;
			this.loadingControl1.Location = new System.Drawing.Point(0, 0);
			this.loadingControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.loadingControl1.Name = "loadingControl1";
			this.loadingControl1.Size = new System.Drawing.Size(406, 150);
			this.loadingControl1.TabIndex = 1;
			this.loadingControl1.Value = 0;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.gradientProgressBar1);
			this.panel1.Controls.Add(this.loadingControl1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(406, 169);
			this.panel1.TabIndex = 3;
			// 
			// gradientProgressBar1
			// 
			this.gradientProgressBar1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gradientProgressBar1.Location = new System.Drawing.Point(0, 150);
			this.gradientProgressBar1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.gradientProgressBar1.Maximum = 100;
			this.gradientProgressBar1.Minimum = 0;
			this.gradientProgressBar1.Name = "gradientProgressBar1";
			this.gradientProgressBar1.Size = new System.Drawing.Size(406, 19);
			this.gradientProgressBar1.TabIndex = 2;
			this.gradientProgressBar1.Text = "gradientProgressBar1";
			this.gradientProgressBar1.Value = 0;
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.Gray;
			this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.label1.Font = new System.Drawing.Font("微软雅黑", 14.25F);
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(0, 169);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(406, 57);
			this.label1.TabIndex = 4;
			this.label1.Text = "加载中，请稍后...";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// Loading
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(406, 226);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Name = "Loading";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Loading";
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private LoadingControl loadingControl1;
		private Panel panel1;
		private GradientProgressBar gradientProgressBar1;
		private Label label1;
	}
}