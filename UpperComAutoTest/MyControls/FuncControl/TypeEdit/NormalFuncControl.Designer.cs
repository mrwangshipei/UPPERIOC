namespace UpperComAutoTest.MyControls.FuncControl.TypeEdit
{
	partial class NormalFuncControl
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
			tableLayoutPanel1 = new TableLayoutPanel();
			label2 = new Label();
			label1 = new Label();
			richTextBox1 = new RichTextBox();
			richTextBox2 = new RichTextBox();
			tableLayoutPanel1.SuspendLayout();
			SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.ColumnCount = 1;
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
			tableLayoutPanel1.Controls.Add(label2, 0, 2);
			tableLayoutPanel1.Controls.Add(label1, 0, 0);
			tableLayoutPanel1.Controls.Add(richTextBox1, 0, 1);
			tableLayoutPanel1.Controls.Add(richTextBox2, 0, 3);
			tableLayoutPanel1.Dock = DockStyle.Fill;
			tableLayoutPanel1.Location = new Point(0, 0);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 4;
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
			tableLayoutPanel1.Size = new Size(297, 260);
			tableLayoutPanel1.TabIndex = 0;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Dock = DockStyle.Fill;
			label2.Location = new Point(3, 130);
			label2.Name = "label2";
			label2.Size = new Size(291, 40);
			label2.TabIndex = 3;
			label2.Text = "就发送";
			label2.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// label1
			// 
			label1.Dock = DockStyle.Fill;
			label1.Location = new Point(3, 0);
			label1.Name = "label1";
			label1.Size = new Size(291, 40);
			label1.TabIndex = 0;
			label1.Text = "当检测到";
			label1.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// richTextBox1
			// 
			richTextBox1.Dock = DockStyle.Fill;
			richTextBox1.Location = new Point(3, 43);
			richTextBox1.Name = "richTextBox1";
			richTextBox1.Size = new Size(291, 84);
			richTextBox1.TabIndex = 1;
			richTextBox1.Text = "";
			richTextBox1.TextChanged += richTextBox1_TextChanged;
			// 
			// richTextBox2
			// 
			richTextBox2.Dock = DockStyle.Fill;
			richTextBox2.Location = new Point(3, 173);
			richTextBox2.Name = "richTextBox2";
			richTextBox2.Size = new Size(291, 84);
			richTextBox2.TabIndex = 2;
			richTextBox2.Text = "";
			richTextBox2.TextChanged += richTextBox2_TextChanged;
			// 
			// NormalFuncControl
			// 
			AutoScaleDimensions = new SizeF(7F, 17F);
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(tableLayoutPanel1);
			Name = "NormalFuncControl";
			Size = new Size(297, 260);
			tableLayoutPanel1.ResumeLayout(false);
			tableLayoutPanel1.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private TableLayoutPanel tableLayoutPanel1;
		private Label label2;
		private Label label1;
		private RichTextBox richTextBox1;
		private RichTextBox richTextBox2;
	}
}
