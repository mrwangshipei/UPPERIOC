﻿namespace UpperComAutoTest
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			toolStrip1 = new ToolStrip();
			NomalComPage = new ToolStripButton();
			toolStripButton2 = new ToolStripButton();
			toolStripButton1 = new ToolStripButton();
			panel1 = new Panel();
			toolStripButton3 = new ToolStripButton();
			toolStrip1.SuspendLayout();
			SuspendLayout();
			// 
			// toolStrip1
			// 
			toolStrip1.Items.AddRange(new ToolStripItem[] { NomalComPage, toolStripButton3, toolStripButton2, toolStripButton1 });
			toolStrip1.Location = new Point(0, 0);
			toolStrip1.Name = "toolStrip1";
			toolStrip1.Size = new Size(1401, 25);
			toolStrip1.TabIndex = 0;
			toolStrip1.Text = "toolStrip1";
			toolStrip1.ItemClicked += toolStrip1_ItemClicked;
			// 
			// NomalComPage
			// 
			NomalComPage.DisplayStyle = ToolStripItemDisplayStyle.Text;
			NomalComPage.Image = (Image)resources.GetObject("NomalComPage.Image");
			NomalComPage.ImageTransparentColor = Color.Magenta;
			NomalComPage.Name = "NomalComPage";
			NomalComPage.Size = new Size(60, 22);
			NomalComPage.Text = "串口调试";
			NomalComPage.Click += NomalComPage_Click;
			// 
			// toolStripButton2
			// 
			toolStripButton2.DisplayStyle = ToolStripItemDisplayStyle.Text;
			toolStripButton2.Image = (Image)resources.GetObject("toolStripButton2.Image");
			toolStripButton2.ImageTransparentColor = Color.Magenta;
			toolStripButton2.Name = "toolStripButton2";
			toolStripButton2.Size = new Size(60, 22);
			toolStripButton2.Text = "添加权限";
			toolStripButton2.Click += toolStripButton3_Click;
			// 
			// toolStripButton1
			// 
			toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Text;
			toolStripButton1.Image = (Image)resources.GetObject("toolStripButton1.Image");
			toolStripButton1.ImageTransparentColor = Color.Magenta;
			toolStripButton1.Name = "toolStripButton1";
			toolStripButton1.Size = new Size(60, 22);
			toolStripButton1.Text = "日志位置";
			toolStripButton1.Click += toolStripButton1_Click;
			// 
			// panel1
			// 
			panel1.Dock = DockStyle.Fill;
			panel1.Location = new Point(0, 25);
			panel1.Name = "panel1";
			panel1.Size = new Size(1401, 871);
			panel1.TabIndex = 1;
			// 
			// toolStripButton3
			// 
			toolStripButton3.DisplayStyle = ToolStripItemDisplayStyle.Text;
			toolStripButton3.Image = (Image)resources.GetObject("toolStripButton3.Image");
			toolStripButton3.ImageTransparentColor = Color.Magenta;
			toolStripButton3.Name = "toolStripButton3";
			toolStripButton3.Size = new Size(60, 22);
			toolStripButton3.Text = "添加用户";
			toolStripButton3.Click += toolStripButton2_Click;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(7F, 17F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1401, 896);
			Controls.Add(panel1);
			Controls.Add(toolStrip1);
			Name = "Form1";
			Text = "Form1";
			toolStrip1.ResumeLayout(false);
			toolStrip1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private ToolStrip toolStrip1;
		private Panel panel1;
		private ToolStripButton NomalComPage;
		private ToolStripButton toolStripButton1;
		private ToolStripButton toolStripButton2;
		private ToolStripButton toolStripButton3;
	}
}
