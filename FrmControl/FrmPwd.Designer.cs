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
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.panel6 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox_un = new System.Windows.Forms.TextBox();
			this.panel7 = new System.Windows.Forms.Panel();
			this.label5 = new System.Windows.Forms.Label();
			this.textBoxpwd = new System.Windows.Forms.TextBox();
			this.panel4 = new System.Windows.Forms.Panel();
			this.panel5 = new System.Windows.Forms.Panel();
			this.label4 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel6.SuspendLayout();
			this.panel7.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel2.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.panel3);
			this.panel1.Controls.Add(this.panel4);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(492, 304);
			this.panel1.TabIndex = 0;
			// 
			// panel3
			// 
			this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel3.Controls.Add(this.panel6);
			this.panel3.Controls.Add(this.panel7);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(0, 49);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new System.Windows.Forms.Padding(30);
			this.panel3.Size = new System.Drawing.Size(492, 162);
			this.panel3.TabIndex = 2;
			// 
			// panel6
			// 
			this.panel6.Controls.Add(this.label1);
			this.panel6.Controls.Add(this.textBox_un);
			this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel6.Location = new System.Drawing.Point(30, 30);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(430, 53);
			this.panel6.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Left;
			this.label1.Font = new System.Drawing.Font("宋体", 14F);
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(73, 53);
			this.label1.TabIndex = 2;
			this.label1.Text = "用户名";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label1.UseWaitCursor = true;
			// 
			// textBox_un
			// 
			this.textBox_un.Font = new System.Drawing.Font("宋体", 16F);
			this.textBox_un.Location = new System.Drawing.Point(82, 15);
			this.textBox_un.Name = "textBox_un";
			this.textBox_un.Size = new System.Drawing.Size(333, 32);
			this.textBox_un.TabIndex = 1;
			this.textBox_un.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmPwd_KeyDown);
			// 
			// panel7
			// 
			this.panel7.Controls.Add(this.label5);
			this.panel7.Controls.Add(this.textBoxpwd);
			this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel7.Location = new System.Drawing.Point(30, 83);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(430, 47);
			this.panel7.TabIndex = 3;
			// 
			// label5
			// 
			this.label5.Dock = System.Windows.Forms.DockStyle.Left;
			this.label5.Font = new System.Drawing.Font("宋体", 14F);
			this.label5.Location = new System.Drawing.Point(0, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(73, 47);
			this.label5.TabIndex = 2;
			this.label5.Text = "密码";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label5.UseWaitCursor = true;
			// 
			// textBoxpwd
			// 
			this.textBoxpwd.Font = new System.Drawing.Font("宋体", 16F);
			this.textBoxpwd.Location = new System.Drawing.Point(79, 3);
			this.textBoxpwd.Name = "textBoxpwd";
			this.textBoxpwd.PasswordChar = '*';
			this.textBoxpwd.Size = new System.Drawing.Size(336, 32);
			this.textBoxpwd.TabIndex = 1;
			this.textBoxpwd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmPwd_KeyDown);
			// 
			// panel4
			// 
			this.panel4.BackColor = System.Drawing.Color.White;
			this.panel4.Controls.Add(this.panel5);
			this.panel4.Controls.Add(this.label4);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel4.Location = new System.Drawing.Point(0, 0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(492, 49);
			this.panel4.TabIndex = 1;
			// 
			// panel5
			// 
			this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.panel5.BackgroundImage = global::FrmControl.Properties.Resources.取消;
			this.panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.panel5.Location = new System.Drawing.Point(443, 0);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(37, 49);
			this.panel5.TabIndex = 1;
			this.panel5.Click += new System.EventHandler(this.panel5_Paint);
			// 
			// label4
			// 
			this.label4.Dock = System.Windows.Forms.DockStyle.Left;
			this.label4.Font = new System.Drawing.Font("宋体", 14F);
			this.label4.Location = new System.Drawing.Point(0, 0);
			this.label4.Name = "label4";
			this.label4.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
			this.label4.Size = new System.Drawing.Size(131, 49);
			this.label4.TabIndex = 0;
			this.label4.Text = "确认框";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label4.UseWaitCursor = true;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.tableLayoutPanel1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new System.Drawing.Point(0, 211);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(492, 93);
			this.panel2.TabIndex = 1;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.label3, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Font = new System.Drawing.Font("宋体", 14F);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(492, 93);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// label3
			// 
			this.label3.BackColor = System.Drawing.Color.White;
			this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label3.Font = new System.Drawing.Font("宋体", 14F);
			this.label3.ForeColor = System.Drawing.Color.Red;
			this.label3.Location = new System.Drawing.Point(246, 0);
			this.label3.Margin = new System.Windows.Forms.Padding(0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(246, 93);
			this.label3.TabIndex = 1;
			this.label3.Text = "取消";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.label3.Click += new System.EventHandler(this.button2_Click);
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.White;
			this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			this.label2.Location = new System.Drawing.Point(0, 0);
			this.label2.Margin = new System.Windows.Forms.Padding(0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(246, 93);
			this.label2.TabIndex = 0;
			this.label2.Text = "确定";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.label2.Click += new System.EventHandler(this.button1_Click);
			// 
			// FrmPwd
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(492, 304);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("宋体", 12F);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "FrmPwd";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "FrmDialog";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmPwd_KeyDown);
			this.panel1.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel6.ResumeLayout(false);
			this.panel6.PerformLayout();
			this.panel7.ResumeLayout(false);
			this.panel7.PerformLayout();
			this.panel4.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.ResumeLayout(false);

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