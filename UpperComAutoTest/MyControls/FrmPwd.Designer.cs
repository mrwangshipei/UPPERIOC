using System;

namespace COMIEEE
{
	partial class FrmPwd
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
			panel1 = new Panel();
			panel3 = new Panel();
			panel6 = new Panel();
			label1 = new Label();
			textBox_un = new TextBox();
			panel7 = new Panel();
			label5 = new Label();
			textBoxpwd = new TextBox();
			panel4 = new Panel();
			panel5 = new Panel();
			label4 = new Label();
			panel2 = new Panel();
			tableLayoutPanel1 = new TableLayoutPanel();
			label3 = new Label();
			label2 = new Label();
			panel1.SuspendLayout();
			panel3.SuspendLayout();
			panel6.SuspendLayout();
			panel7.SuspendLayout();
			panel4.SuspendLayout();
			panel2.SuspendLayout();
			tableLayoutPanel1.SuspendLayout();
			SuspendLayout();
			// 
			// panel1
			// 
			panel1.Controls.Add(panel3);
			panel1.Controls.Add(panel4);
			panel1.Controls.Add(panel2);
			panel1.Dock = DockStyle.Fill;
			panel1.Location = new Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new Size(492, 304);
			panel1.TabIndex = 0;
			// 
			// panel3
			// 
			panel3.BorderStyle = BorderStyle.FixedSingle;
			panel3.Controls.Add(panel6);
			panel3.Controls.Add(panel7);
			panel3.Dock = DockStyle.Fill;
			panel3.Location = new Point(0, 49);
			panel3.Name = "panel3";
			panel3.Padding = new Padding(30);
			panel3.Size = new Size(492, 162);
			panel3.TabIndex = 2;
			// 
			// panel6
			// 
			panel6.Controls.Add(label1);
			panel6.Controls.Add(textBox_un);
			panel6.Dock = DockStyle.Fill;
			panel6.Location = new Point(30, 30);
			panel6.Name = "panel6";
			panel6.Size = new Size(430, 53);
			panel6.TabIndex = 2;
			// 
			// label1
			// 
			label1.Dock = DockStyle.Left;
			label1.Font = new Font("宋体", 14F, FontStyle.Regular, GraphicsUnit.Point);
			label1.Location = new Point(0, 0);
			label1.Name = "label1";
			label1.Size = new Size(73, 53);
			label1.TabIndex = 2;
			label1.Text = "用户名";
			label1.TextAlign = ContentAlignment.MiddleLeft;
			label1.UseWaitCursor = true;
			// 
			// textBox_un
			// 
			textBox_un.Font = new Font("宋体", 16F, FontStyle.Regular, GraphicsUnit.Point);
			textBox_un.Location = new Point(82, 15);
			textBox_un.Name = "textBox_un";
			textBox_un.Size = new Size(333, 32);
			textBox_un.TabIndex = 1;
			// 
			// panel7
			// 
			panel7.Controls.Add(label5);
			panel7.Controls.Add(textBoxpwd);
			panel7.Dock = DockStyle.Bottom;
			panel7.Location = new Point(30, 83);
			panel7.Name = "panel7";
			panel7.Size = new Size(430, 47);
			panel7.TabIndex = 3;
			// 
			// label5
			// 
			label5.Dock = DockStyle.Left;
			label5.Font = new Font("宋体", 14F, FontStyle.Regular, GraphicsUnit.Point);
			label5.Location = new Point(0, 0);
			label5.Name = "label5";
			label5.Size = new Size(73, 47);
			label5.TabIndex = 2;
			label5.Text = "密码";
			label5.TextAlign = ContentAlignment.MiddleLeft;
			label5.UseWaitCursor = true;
			// 
			// textBoxpwd
			// 
			textBoxpwd.Font = new Font("宋体", 16F, FontStyle.Regular, GraphicsUnit.Point);
			textBoxpwd.Location = new Point(79, 3);
			textBoxpwd.Name = "textBoxpwd";
			textBoxpwd.Size = new Size(336, 32);
			textBoxpwd.TabIndex = 1;
			// 
			// panel4
			// 
			panel4.BackColor = Color.White;
			panel4.Controls.Add(panel5);
			panel4.Controls.Add(label4);
			panel4.Dock = DockStyle.Top;
			panel4.Location = new Point(0, 0);
			panel4.Name = "panel4";
			panel4.Size = new Size(492, 49);
			panel4.TabIndex = 1;
			// 
			// panel5
			// 
			panel5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			panel5.BackgroundImage = UpperComAutoTest.Properties.Resources.错误;
			panel5.BackgroundImageLayout = ImageLayout.Zoom;
			panel5.Location = new Point(443, 0);
			panel5.Name = "panel5";
			panel5.Size = new Size(37, 49);
			panel5.TabIndex = 1;
			panel5.Click += panel5_Paint;
			// 
			// label4
			// 
			label4.Dock = DockStyle.Left;
			label4.Font = new Font("宋体", 14F, FontStyle.Regular, GraphicsUnit.Point);
			label4.Location = new Point(0, 0);
			label4.Name = "label4";
			label4.Padding = new Padding(30, 0, 0, 0);
			label4.Size = new Size(131, 49);
			label4.TabIndex = 0;
			label4.Text = "确认框";
			label4.TextAlign = ContentAlignment.MiddleLeft;
			label4.UseWaitCursor = true;
			// 
			// panel2
			// 
			panel2.Controls.Add(tableLayoutPanel1);
			panel2.Dock = DockStyle.Bottom;
			panel2.Location = new Point(0, 211);
			panel2.Name = "panel2";
			panel2.Size = new Size(492, 93);
			panel2.TabIndex = 1;
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.ColumnCount = 2;
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			tableLayoutPanel1.Controls.Add(label3, 1, 0);
			tableLayoutPanel1.Controls.Add(label2, 0, 0);
			tableLayoutPanel1.Dock = DockStyle.Fill;
			tableLayoutPanel1.Font = new Font("宋体", 14F, FontStyle.Regular, GraphicsUnit.Point);
			tableLayoutPanel1.Location = new Point(0, 0);
			tableLayoutPanel1.Margin = new Padding(0);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 1;
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
			tableLayoutPanel1.Size = new Size(492, 93);
			tableLayoutPanel1.TabIndex = 0;
			// 
			// label3
			// 
			label3.BackColor = Color.White;
			label3.Dock = DockStyle.Fill;
			label3.Font = new Font("宋体", 14F, FontStyle.Regular, GraphicsUnit.Point);
			label3.ForeColor = Color.Red;
			label3.Location = new Point(246, 0);
			label3.Margin = new Padding(0);
			label3.Name = "label3";
			label3.Size = new Size(246, 93);
			label3.TabIndex = 1;
			label3.Text = "取消";
			label3.TextAlign = ContentAlignment.MiddleCenter;
			label3.Click += button2_Click;
			// 
			// label2
			// 
			label2.BackColor = Color.White;
			label2.Dock = DockStyle.Fill;
			label2.ForeColor = Color.FromArgb(0, 192, 192);
			label2.Location = new Point(0, 0);
			label2.Margin = new Padding(0);
			label2.Name = "label2";
			label2.Size = new Size(246, 93);
			label2.TabIndex = 0;
			label2.Text = "确定";
			label2.TextAlign = ContentAlignment.MiddleCenter;
			label2.Click += button1_Click;
			// 
			// FrmPwd
			// 
			AutoScaleDimensions = new SizeF(8F, 16F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(492, 304);
			Controls.Add(panel1);
			Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point);
			FormBorderStyle = FormBorderStyle.None;
			Margin = new Padding(4);
			Name = "FrmPwd";
			StartPosition = FormStartPosition.CenterParent;
			Text = "FrmDialog";
			panel1.ResumeLayout(false);
			panel3.ResumeLayout(false);
			panel6.ResumeLayout(false);
			panel6.PerformLayout();
			panel7.ResumeLayout(false);
			panel7.PerformLayout();
			panel4.ResumeLayout(false);
			panel2.ResumeLayout(false);
			tableLayoutPanel1.ResumeLayout(false);
			ResumeLayout(false);
		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox_un;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBoxpwd;
	}
}