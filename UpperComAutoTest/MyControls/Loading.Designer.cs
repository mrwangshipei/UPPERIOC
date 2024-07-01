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
			loadingControl1 = new LoadingControl();
			panel1 = new Panel();
			gradientProgressBar1 = new GradientProgressBar();
			label1 = new Label();
			panel1.SuspendLayout();
			SuspendLayout();
			// 
			// loadingControl1
			// 
			loadingControl1.BackColor = Color.Black;
			loadingControl1.Dock = DockStyle.Top;
			loadingControl1.Location = new Point(0, 0);
			loadingControl1.Name = "loadingControl1";
			loadingControl1.Size = new Size(474, 204);
			loadingControl1.TabIndex = 1;
			loadingControl1.Value = 0;
			// 
			// panel1
			// 
			panel1.Controls.Add(gradientProgressBar1);
			panel1.Controls.Add(loadingControl1);
			panel1.Dock = DockStyle.Fill;
			panel1.Location = new Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new Size(474, 239);
			panel1.TabIndex = 3;
			// 
			// gradientProgressBar1
			// 
			gradientProgressBar1.Dock = DockStyle.Fill;
			gradientProgressBar1.Location = new Point(0, 204);
			gradientProgressBar1.Maximum = 100;
			gradientProgressBar1.Minimum = 0;
			gradientProgressBar1.Name = "gradientProgressBar1";
			gradientProgressBar1.Size = new Size(474, 35);
			gradientProgressBar1.TabIndex = 2;
			gradientProgressBar1.Text = "gradientProgressBar1";
			gradientProgressBar1.Value = 0;
			// 
			// label1
			// 
			label1.BackColor = Color.Gray;
			label1.Dock = DockStyle.Bottom;
			label1.Font = new Font("微软雅黑", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
			label1.ForeColor = Color.White;
			label1.Location = new Point(0, 239);
			label1.Name = "label1";
			label1.Size = new Size(474, 81);
			label1.TabIndex = 4;
			label1.Text = "加载中，请稍后...";
			label1.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// Loading
			// 
			AutoScaleDimensions = new SizeF(7F, 17F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(474, 320);
			Controls.Add(panel1);
			Controls.Add(label1);
			FormBorderStyle = FormBorderStyle.None;
			Name = "Loading";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Loading";
			panel1.ResumeLayout(false);
			ResumeLayout(false);
		}

		#endregion
		private LoadingControl loadingControl1;
		private Panel panel1;
		private GradientProgressBar gradientProgressBar1;
		private Label label1;
	}
}