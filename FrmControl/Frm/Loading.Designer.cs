using System.Drawing;
using System.Windows.Forms;

namespace UpperComAutoTest.MyControls.Frm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.loadingControl1 = new UpperComAutoTest.MyControls.LoadingControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.gradientProgressBar1 = new UpperComAutoTest.MyControls.GradientProgressBar();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(404, 212);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.loadingControl1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(404, 188);
            this.panel2.TabIndex = 0;
            // 
            // loadingControl1
            // 
            this.loadingControl1.AAA = 18;
            this.loadingControl1.BackColor = System.Drawing.Color.White;
            this.loadingControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loadingControl1.Image = global::FrmControl.Properties.Resources.菊花加载;
            this.loadingControl1.Location = new System.Drawing.Point(0, 0);
            this.loadingControl1.Name = "loadingControl1";
            this.loadingControl1.Onems = 360F;
            this.loadingControl1.Size = new System.Drawing.Size(404, 165);
            this.loadingControl1.SpeedMultiplier = 7.2F;
            this.loadingControl1.TabIndex = 0;
            this.loadingControl1.Click += new System.EventHandler(this.loadingControl1_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Font = new System.Drawing.Font("宋体", 12F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(0, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(404, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "正在加载中，请稍后";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.gradientProgressBar1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 188);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(404, 24);
            this.panel3.TabIndex = 1;
            // 
            // gradientProgressBar1
            // 
            this.gradientProgressBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gradientProgressBar1.EndColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            this.gradientProgressBar1.Location = new System.Drawing.Point(0, 0);
            this.gradientProgressBar1.Maximum = 100;
            this.gradientProgressBar1.Minimum = 0;
            this.gradientProgressBar1.Name = "gradientProgressBar1";
            this.gradientProgressBar1.Size = new System.Drawing.Size(404, 24);
            this.gradientProgressBar1.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gradientProgressBar1.TabIndex = 0;
            this.gradientProgressBar1.Value = 0;
            // 
            // Loading
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(404, 212);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Loading";
            this.Radius = 10;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion
		private LoadingControl loadingControl1;
		private Panel panel1;
		private GradientProgressBar gradientProgressBar1;
		private Label label1;
        private Panel panel2;
        private Panel panel3;
    }
}