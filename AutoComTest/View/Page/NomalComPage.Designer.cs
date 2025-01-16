using System.Drawing;
using System.Windows.Forms;

namespace UpperComAutoTest.Page
{
	partial class NomalComPage
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NomalComPage));
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel4 = new System.Windows.Forms.Panel();
			this.frmLinerGidentBtn1 = new FrmControl.C.Btn.FrmLinerGidentBtn();
			this.richTextBox_r = new System.Windows.Forms.RichTextBox();
			this.panel3 = new System.Windows.Forms.Panel();
			this.richTextBox_s = new System.Windows.Forms.RichTextBox();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.转16进制ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.查看字符ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.panel2 = new System.Windows.Forms.Panel();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.panel5 = new System.Windows.Forms.Panel();
			this.button5 = new System.Windows.Forms.Button();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.button4 = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.checkBox3 = new System.Windows.Forms.CheckBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.button2 = new System.Windows.Forms.Button();
			this.checkBox5 = new System.Windows.Forms.CheckBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.comboBox3 = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.checkBox8 = new System.Windows.Forms.CheckBox();
			this.checkBox7 = new System.Windows.Forms.CheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.comboBox5 = new System.Windows.Forms.ComboBox();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.comboBox4 = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.comboBox2 = new System.Windows.Forms.ComboBox();
			this.panel1.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel3.SuspendLayout();
			this.contextMenuStrip1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.panel5.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.panel4);
			this.panel1.Controls.Add(this.panel3);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(939, 859);
			this.panel1.TabIndex = 0;
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.frmLinerGidentBtn1);
			this.panel4.Controls.Add(this.richTextBox_r);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel4.Location = new System.Drawing.Point(0, 0);
			this.panel4.Name = "panel4";
			this.panel4.Padding = new System.Windows.Forms.Padding(15);
			this.panel4.Size = new System.Drawing.Size(939, 665);
			this.panel4.TabIndex = 1;
			this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
			// 
			// frmLinerGidentBtn1
			// 
			this.frmLinerGidentBtn1.Color1 = System.Drawing.Color.LightGray;
			this.frmLinerGidentBtn1.Color2 = System.Drawing.Color.DimGray;
			this.frmLinerGidentBtn1.Color3 = System.Drawing.Color.LightGray;
			this.frmLinerGidentBtn1.Direction = ((System.Drawing.PointF)(resources.GetObject("frmLinerGidentBtn1.Direction")));
			this.frmLinerGidentBtn1.Location = new System.Drawing.Point(208, 170);
			this.frmLinerGidentBtn1.Name = "frmLinerGidentBtn1";
			this.frmLinerGidentBtn1.Size = new System.Drawing.Size(421, 118);
			this.frmLinerGidentBtn1.SizeCLick = 70;
			this.frmLinerGidentBtn1.TabIndex = 4;
			this.frmLinerGidentBtn1.Text = "sss";
			// 
			// richTextBox_r
			// 
			this.richTextBox_r.Dock = System.Windows.Forms.DockStyle.Fill;
			this.richTextBox_r.Location = new System.Drawing.Point(15, 15);
			this.richTextBox_r.Name = "richTextBox_r";
			this.richTextBox_r.Size = new System.Drawing.Size(909, 635);
			this.richTextBox_r.TabIndex = 0;
			this.richTextBox_r.Text = "";
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.richTextBox_s);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel3.Location = new System.Drawing.Point(0, 665);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new System.Windows.Forms.Padding(15);
			this.panel3.Size = new System.Drawing.Size(939, 194);
			this.panel3.TabIndex = 0;
			// 
			// richTextBox_s
			// 
			this.richTextBox_s.ContextMenuStrip = this.contextMenuStrip1;
			this.richTextBox_s.Dock = System.Windows.Forms.DockStyle.Fill;
			this.richTextBox_s.Location = new System.Drawing.Point(15, 15);
			this.richTextBox_s.Name = "richTextBox_s";
			this.richTextBox_s.Size = new System.Drawing.Size(909, 164);
			this.richTextBox_s.TabIndex = 0;
			this.richTextBox_s.Text = "";
			this.richTextBox_s.TextChanged += new System.EventHandler(this.richTextBox_s_TextChanged_1);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.转16进制ToolStripMenuItem,
            this.查看字符ToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(127, 48);
			// 
			// 转16进制ToolStripMenuItem
			// 
			this.转16进制ToolStripMenuItem.Name = "转16进制ToolStripMenuItem";
			this.转16进制ToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
			this.转16进制ToolStripMenuItem.Text = "转16进制";
			// 
			// 查看字符ToolStripMenuItem
			// 
			this.查看字符ToolStripMenuItem.Name = "查看字符ToolStripMenuItem";
			this.查看字符ToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
			this.查看字符ToolStripMenuItem.Text = "查看字符";
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.groupBox5);
			this.panel2.Controls.Add(this.groupBox4);
			this.panel2.Controls.Add(this.groupBox3);
			this.panel2.Controls.Add(this.groupBox2);
			this.panel2.Controls.Add(this.groupBox1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel2.Location = new System.Drawing.Point(939, 0);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(5, 0, 15, 0);
			this.panel2.Size = new System.Drawing.Size(282, 859);
			this.panel2.TabIndex = 0;
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.flowLayoutPanel1);
			this.groupBox5.Controls.Add(this.panel5);
			this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox5.Location = new System.Drawing.Point(5, 524);
			this.groupBox5.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(262, 335);
			this.groupBox5.TabIndex = 4;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "函数";
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.AutoScroll = true;
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 24);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(256, 252);
			this.flowLayoutPanel1.TabIndex = 0;
			// 
			// panel5
			// 
			this.panel5.Controls.Add(this.button5);
			this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel5.Location = new System.Drawing.Point(3, 276);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(256, 56);
			this.panel5.TabIndex = 0;
			// 
			// button5
			// 
			this.button5.Dock = System.Windows.Forms.DockStyle.Right;
			this.button5.Location = new System.Drawing.Point(130, 0);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(126, 56);
			this.button5.TabIndex = 2;
			this.button5.Text = "添加";
			this.button5.UseVisualStyleBackColor = true;
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.button4);
			this.groupBox4.Controls.Add(this.label6);
			this.groupBox4.Controls.Add(this.textBox1);
			this.groupBox4.Controls.Add(this.checkBox3);
			this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox4.Enabled = false;
			this.groupBox4.Location = new System.Drawing.Point(5, 427);
			this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(262, 97);
			this.groupBox4.TabIndex = 4;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "发送";
			// 
			// button4
			// 
			this.button4.Dock = System.Windows.Forms.DockStyle.Right;
			this.button4.Location = new System.Drawing.Point(133, 24);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(126, 70);
			this.button4.TabIndex = 2;
			this.button4.Text = "发送";
			this.button4.UseVisualStyleBackColor = true;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(98, 32);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(32, 21);
			this.label6.TabIndex = 2;
			this.label6.Text = "ms";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(13, 29);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(81, 28);
			this.textBox1.TabIndex = 4;
			this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
			// 
			// checkBox3
			// 
			this.checkBox3.AutoSize = true;
			this.checkBox3.Location = new System.Drawing.Point(34, 63);
			this.checkBox3.Name = "checkBox3";
			this.checkBox3.Size = new System.Drawing.Size(93, 25);
			this.checkBox3.TabIndex = 5;
			this.checkBox3.Text = "自动发送";
			this.checkBox3.UseVisualStyleBackColor = true;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.button2);
			this.groupBox3.Controls.Add(this.checkBox5);
			this.groupBox3.Controls.Add(this.checkBox1);
			this.groupBox3.Controls.Add(this.checkBox2);
			this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox3.Location = new System.Drawing.Point(5, 321);
			this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(262, 106);
			this.groupBox3.TabIndex = 4;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "消息";
			// 
			// button2
			// 
			this.button2.Dock = System.Windows.Forms.DockStyle.Left;
			this.button2.Location = new System.Drawing.Point(3, 24);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(127, 79);
			this.button2.TabIndex = 2;
			this.button2.Text = "清理消息";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// checkBox5
			// 
			this.checkBox5.AutoSize = true;
			this.checkBox5.Location = new System.Drawing.Point(149, 79);
			this.checkBox5.Name = "checkBox5";
			this.checkBox5.Size = new System.Drawing.Size(77, 25);
			this.checkBox5.TabIndex = 3;
			this.checkBox5.Text = "时间戳";
			this.checkBox5.UseVisualStyleBackColor = true;
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(149, 26);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(95, 25);
			this.checkBox1.TabIndex = 3;
			this.checkBox1.Text = "转16进制";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// checkBox2
			// 
			this.checkBox2.AutoSize = true;
			this.checkBox2.Location = new System.Drawing.Point(149, 53);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(93, 25);
			this.checkBox2.TabIndex = 3;
			this.checkBox2.Text = "白底黑字";
			this.checkBox2.UseVisualStyleBackColor = true;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.button1);
			this.groupBox2.Controls.Add(this.button3);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox2.Location = new System.Drawing.Point(5, 238);
			this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(262, 83);
			this.groupBox2.TabIndex = 4;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "操作";
			// 
			// button1
			// 
			this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.button1.Location = new System.Drawing.Point(3, 24);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(127, 56);
			this.button1.TabIndex = 2;
			this.button1.Text = "启动";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// button3
			// 
			this.button3.Dock = System.Windows.Forms.DockStyle.Right;
			this.button3.Enabled = false;
			this.button3.Location = new System.Drawing.Point(130, 24);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(129, 56);
			this.button3.TabIndex = 2;
			this.button3.Text = "停止";
			this.button3.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.comboBox3);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.checkBox8);
			this.groupBox1.Controls.Add(this.checkBox7);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.comboBox5);
			this.groupBox1.Controls.Add(this.comboBox1);
			this.groupBox1.Controls.Add(this.comboBox4);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.comboBox2);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(5, 0);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(262, 238);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "串口";
			this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
			// 
			// comboBox3
			// 
			this.comboBox3.FormattingEnabled = true;
			this.comboBox3.Location = new System.Drawing.Point(89, 170);
			this.comboBox3.Name = "comboBox3";
			this.comboBox3.Size = new System.Drawing.Size(170, 29);
			this.comboBox3.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(11, 35);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(42, 21);
			this.label1.TabIndex = 0;
			this.label1.Text = "串口";
			// 
			// checkBox8
			// 
			this.checkBox8.AutoSize = true;
			this.checkBox8.Location = new System.Drawing.Point(167, 205);
			this.checkBox8.Name = "checkBox8";
			this.checkBox8.Size = new System.Drawing.Size(51, 25);
			this.checkBox8.TabIndex = 3;
			this.checkBox8.Text = "dtr";
			this.checkBox8.UseVisualStyleBackColor = true;
			// 
			// checkBox7
			// 
			this.checkBox7.AutoSize = true;
			this.checkBox7.Location = new System.Drawing.Point(46, 205);
			this.checkBox7.Name = "checkBox7";
			this.checkBox7.Size = new System.Drawing.Size(48, 25);
			this.checkBox7.TabIndex = 3;
			this.checkBox7.Text = "rts";
			this.checkBox7.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(11, 68);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(58, 21);
			this.label2.TabIndex = 0;
			this.label2.Text = "波特率";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(13, 101);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(58, 21);
			this.label3.TabIndex = 0;
			this.label3.Text = "数据位";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(11, 138);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(58, 21);
			this.label4.TabIndex = 0;
			this.label4.Text = "停止位";
			// 
			// comboBox5
			// 
			this.comboBox5.FormattingEnabled = true;
			this.comboBox5.Location = new System.Drawing.Point(89, 98);
			this.comboBox5.Name = "comboBox5";
			this.comboBox5.Size = new System.Drawing.Size(170, 29);
			this.comboBox5.TabIndex = 1;
			this.comboBox5.SelectedIndexChanged += new System.EventHandler(this.comboBox5_SelectedIndexChanged_1);
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(89, 27);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(170, 29);
			this.comboBox1.TabIndex = 1;
			// 
			// comboBox4
			// 
			this.comboBox4.FormattingEnabled = true;
			this.comboBox4.Location = new System.Drawing.Point(89, 135);
			this.comboBox4.Name = "comboBox4";
			this.comboBox4.Size = new System.Drawing.Size(170, 29);
			this.comboBox4.TabIndex = 1;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.label5.Location = new System.Drawing.Point(11, 173);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(74, 21);
			this.label5.TabIndex = 0;
			this.label5.Text = "基偶校验";
			// 
			// comboBox2
			// 
			this.comboBox2.FormattingEnabled = true;
			this.comboBox2.Location = new System.Drawing.Point(89, 62);
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.Size = new System.Drawing.Size(170, 29);
			this.comboBox2.TabIndex = 1;
			// 
			// NomalComPage
			// 
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.panel2);
			this.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
			this.MinimumSize = new System.Drawing.Size(1221, 859);
			this.Name = "NomalComPage";
			this.Size = new System.Drawing.Size(1221, 859);
			this.panel1.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.contextMenuStrip1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private Panel panel1;
		private Panel panel2;
		private Label label1;
		private ComboBox comboBox4;
		private ComboBox comboBox3;
		private ComboBox comboBox2;
		private ComboBox comboBox1;
		private Label label4;
		private Label label3;
		private Label label2;
		private Button button1;
		private ComboBox comboBox5;
		private Label label5;
		private CheckBox checkBox2;
		private CheckBox checkBox1;
		private Button button2;
		private GroupBox groupBox1;
		private GroupBox groupBox3;
		private GroupBox groupBox2;
		private Button button3;
		private CheckBox checkBox5;
		private GroupBox groupBox4;
		private Button button4;
		private Label label6;
		private TextBox textBox1;
		private CheckBox checkBox3;
		private GroupBox groupBox5;
		private Panel panel3;
		private RichTextBox richTextBox_s;
		private Panel panel4;
		private RichTextBox richTextBox_r;
		private CheckBox checkBox8;
		private CheckBox checkBox7;
		private MyControls.LoadingControl loading1;
		private ContextMenuStrip contextMenuStrip1;
		private ToolStripMenuItem 转16进制ToolStripMenuItem;
		private ToolStripMenuItem 查看字符ToolStripMenuItem;
		private FlowLayoutPanel flowLayoutPanel1;
		private Panel panel5;
		private Button button5;
        private FrmControl.C.Btn.FrmLinerGidentBtn frmLinerGidentBtn1;
    }
}