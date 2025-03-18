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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Loading));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.loadingControl1 = new UpperComAutoTest.MyControls.LoadingControl();
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
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.loadingControl1);
            this.panel2.Controls.Add(this.label1);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Name = "label1";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.gradientProgressBar1);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // loadingControl1
            // 
            this.loadingControl1.AAA = 20;
            this.loadingControl1.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.loadingControl1, "loadingControl1");
            this.loadingControl1.Image = global::FrmControl.Properties.Resources.菊花加载;
            this.loadingControl1.Name = "loadingControl1";
            this.loadingControl1.Onems = 400F;
            this.loadingControl1.SpeedMultiplier = 5F;
            this.loadingControl1.Click += new System.EventHandler(this.loadingControl1_Click);
            // 
            // gradientProgressBar1
            // 
            resources.ApplyResources(this.gradientProgressBar1, "gradientProgressBar1");
            this.gradientProgressBar1.EndColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            this.gradientProgressBar1.Maximum = 100;
            this.gradientProgressBar1.Minimum = 0;
            this.gradientProgressBar1.Name = "gradientProgressBar1";
            this.gradientProgressBar1.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gradientProgressBar1.Value = 0;
            // 
            // Loading
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Loading";
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