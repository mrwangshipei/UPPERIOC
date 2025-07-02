using System.Drawing;
using System.Windows.Forms;
using FrmControl.C.ProgressBar;

namespace UpperComAutoTest.MyControls.Frm
{
	partial class TextLoading
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
            this.textProgressBar1 = new FrmControl.C.ProgressBar.TextProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(404, 212);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.textProgressBar1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(404, 212);
            this.panel2.TabIndex = 0;
            // 
            // textProgressBar1
            // 
            this.textProgressBar1.Animationspeed = 3F;
            this.textProgressBar1.BackColor = System.Drawing.Color.Black;
            this.textProgressBar1.BackgroundColor = System.Drawing.Color.Black;
            this.textProgressBar1.DisplayText = "Loading...";
            this.textProgressBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textProgressBar1.Font = new System.Drawing.Font("华文琥珀", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textProgressBar1.ForeColor = System.Drawing.Color.Black;
            this.textProgressBar1.Location = new System.Drawing.Point(0, 0);
            this.textProgressBar1.Name = "textProgressBar1";
            this.textProgressBar1.Progress = 0.75F;
            this.textProgressBar1.ProgressColor = System.Drawing.Color.DimGray;
            this.textProgressBar1.progressColor2 = System.Drawing.Color.Silver;
            this.textProgressBar1.ProgressColor2 = System.Drawing.Color.Silver;
            this.textProgressBar1.Radius = 0;
            this.textProgressBar1.Size = new System.Drawing.Size(404, 189);
            this.textProgressBar1.TabIndex = 2;
            this.textProgressBar1.TextColor = System.Drawing.Color.White;
            this.textProgressBar1.WaveHeight = 15F;
            this.textProgressBar1.WaveWidth = 50F;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.LightGray;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(0, 189);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(404, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "正在加载中，请稍后";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TextLoading
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(404, 212);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TextLoading";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion
		private Panel panel1;
        private Panel panel2;
        public TextProgressBar textProgressBar1;
        protected Label label1;
    }
}