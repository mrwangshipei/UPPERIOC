namespace FCT.MyControls
{
	partial class LastResultControl
	{
		/// <summary> 
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region 组件设计器生成的代码

		/// <summary> 
		/// 设计器支持所需的方法 - 不要修改
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel_last = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.label_last = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel_now = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.label3 = new System.Windows.Forms.Label();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.清零测试数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.labelfail = new System.Windows.Forms.Label();
			this.labelpass = new System.Windows.Forms.Label();
			this.labelall = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.panel_last.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel_now.SuspendLayout();
			this.panel3.SuspendLayout();
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel1.Controls.Add(this.panel_last);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel1.Location = new System.Drawing.Point(0, 35);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(64, 208);
			this.panel1.TabIndex = 0;
			// 
			// panel_last
			// 
			this.panel_last.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
			this.panel_last.Controls.Add(this.label1);
			this.panel_last.Controls.Add(this.label_last);
			this.panel_last.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel_last.Location = new System.Drawing.Point(0, 0);
			this.panel_last.Name = "panel_last";
			this.panel_last.Size = new System.Drawing.Size(60, 204);
			this.panel_last.TabIndex = 3;
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.Gray;
			this.label1.Dock = System.Windows.Forms.DockStyle.Top;
			this.label1.Font = new System.Drawing.Font("宋体", 9F);
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(60, 14);
			this.label1.TabIndex = 1;
			this.label1.Text = "上次结果";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label_last
			// 
			this.label_last.BackColor = System.Drawing.Color.Transparent;
			this.label_last.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label_last.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Bold);
			this.label_last.Location = new System.Drawing.Point(0, 0);
			this.label_last.Name = "label_last";
			this.label_last.Size = new System.Drawing.Size(60, 204);
			this.label_last.TabIndex = 0;
			this.label_last.Text = "Wait";
			this.label_last.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.panel_now);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(64, 35);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(211, 208);
			this.panel2.TabIndex = 1;
			// 
			// panel_now
			// 
			this.panel_now.BackColor = System.Drawing.Color.Transparent;
			this.panel_now.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel_now.Controls.Add(this.labelall);
			this.panel_now.Controls.Add(this.labelpass);
			this.panel_now.Controls.Add(this.labelfail);
			this.panel_now.Controls.Add(this.label2);
			this.panel_now.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel_now.Location = new System.Drawing.Point(0, 0);
			this.panel_now.Name = "panel_now";
			this.panel_now.Size = new System.Drawing.Size(211, 208);
			this.panel_now.TabIndex = 2;
			this.panel_now.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_now_Paint);
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.label3);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(0, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(275, 35);
			this.panel3.TabIndex = 6;
			this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
			// 
			// label3
			// 
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label3.Font = new System.Drawing.Font("宋体", 12F);
			this.label3.Location = new System.Drawing.Point(0, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(275, 35);
			this.label3.TabIndex = 0;
			this.label3.Text = "良率: 0.00%";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.清零测试数据ToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(149, 26);
			// 
			// 清零测试数据ToolStripMenuItem
			// 
			this.清零测试数据ToolStripMenuItem.Name = "清零测试数据ToolStripMenuItem";
			this.清零测试数据ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
			this.清零测试数据ToolStripMenuItem.Text = "清零测试数据";
			this.清零测试数据ToolStripMenuItem.Click += new System.EventHandler(this.清零测试数据ToolStripMenuItem_Click);
			// 
			// labelfail
			// 
			this.labelfail.BackColor = System.Drawing.Color.Transparent;
			this.labelfail.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.labelfail.Font = new System.Drawing.Font("宋体", 9F);
			this.labelfail.Location = new System.Drawing.Point(0, 181);
			this.labelfail.Margin = new System.Windows.Forms.Padding(3, 0, 3, 5);
			this.labelfail.Name = "labelfail";
			this.labelfail.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
			this.labelfail.Size = new System.Drawing.Size(207, 23);
			this.labelfail.TabIndex = 3;
			this.labelfail.Text = "不合格数:";
			// 
			// labelpass
			// 
			this.labelpass.BackColor = System.Drawing.Color.Transparent;
			this.labelpass.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.labelpass.Font = new System.Drawing.Font("宋体", 9F);
			this.labelpass.Location = new System.Drawing.Point(0, 158);
			this.labelpass.Margin = new System.Windows.Forms.Padding(3, 0, 3, 5);
			this.labelpass.Name = "labelpass";
			this.labelpass.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
			this.labelpass.Size = new System.Drawing.Size(207, 23);
			this.labelpass.TabIndex = 4;
			this.labelpass.Text = "合格数:";
			// 
			// labelall
			// 
			this.labelall.BackColor = System.Drawing.Color.Transparent;
			this.labelall.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.labelall.Font = new System.Drawing.Font("宋体", 9F);
			this.labelall.Location = new System.Drawing.Point(0, 135);
			this.labelall.Margin = new System.Windows.Forms.Padding(3, 0, 3, 5);
			this.labelall.Name = "labelall";
			this.labelall.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
			this.labelall.Size = new System.Drawing.Size(207, 23);
			this.labelall.TabIndex = 5;
			this.labelall.Text = "总数:";
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.Gray;
			this.label2.Dock = System.Windows.Forms.DockStyle.Top;
			this.label2.Font = new System.Drawing.Font("宋体", 12F);
			this.label2.ForeColor = System.Drawing.Color.White;
			this.label2.Location = new System.Drawing.Point(0, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(207, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "这次结果";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// LastResultControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.panel3);
			this.Name = "LastResultControl";
			this.Size = new System.Drawing.Size(275, 243);
			this.panel1.ResumeLayout(false);
			this.panel_last.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel_now.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label_last;
		private System.Windows.Forms.Panel panel_last;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel_now;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem 清零测试数据ToolStripMenuItem;
		private System.Windows.Forms.Label labelall;
		private System.Windows.Forms.Label labelpass;
		private System.Windows.Forms.Label labelfail;
		private System.Windows.Forms.Label label2;
	}
}
