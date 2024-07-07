namespace UpperComAutoTest.MyControls.FuncControl
{
	partial class FunEdit
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
			panel2 = new Panel();
			label1 = new Label();
			comboBox1 = new ComboBox();
			label2 = new Label();
			textBox1 = new TextBox();
			panel3 = new Panel();
			tableLayoutPanel1 = new TableLayoutPanel();
			button1 = new Button();
			button2 = new Button();
			panel2.SuspendLayout();
			panel3.SuspendLayout();
			tableLayoutPanel1.SuspendLayout();
			SuspendLayout();
			// 
			// panel1
			// 
			panel1.Dock = DockStyle.Fill;
			panel1.Location = new Point(0, 134);
			panel1.Margin = new Padding(4, 4, 4, 4);
			panel1.Name = "panel1";
			panel1.Size = new Size(388, 280);
			panel1.TabIndex = 0;
			// 
			// panel2
			// 
			panel2.Controls.Add(textBox1);
			panel2.Controls.Add(label2);
			panel2.Controls.Add(comboBox1);
			panel2.Controls.Add(label1);
			panel2.Dock = DockStyle.Top;
			panel2.Location = new Point(0, 0);
			panel2.Margin = new Padding(4, 4, 4, 4);
			panel2.Name = "panel2";
			panel2.Size = new Size(388, 134);
			panel2.TabIndex = 0;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(50, 23);
			label1.Margin = new Padding(4, 0, 4, 0);
			label1.Name = "label1";
			label1.Size = new Size(42, 21);
			label1.TabIndex = 0;
			label1.Text = "类型";
			// 
			// comboBox1
			// 
			comboBox1.FormattingEnabled = true;
			comboBox1.Location = new Point(153, 22);
			comboBox1.Margin = new Padding(4, 4, 4, 4);
			comboBox1.Name = "comboBox1";
			comboBox1.Size = new Size(171, 29);
			comboBox1.TabIndex = 1;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(50, 88);
			label2.Margin = new Padding(4, 0, 4, 0);
			label2.Name = "label2";
			label2.Size = new Size(42, 21);
			label2.TabIndex = 2;
			label2.Text = "名称";
			// 
			// textBox1
			// 
			textBox1.Location = new Point(153, 88);
			textBox1.Margin = new Padding(4, 4, 4, 4);
			textBox1.Name = "textBox1";
			textBox1.Size = new Size(171, 28);
			textBox1.TabIndex = 3;
			// 
			// panel3
			// 
			panel3.Controls.Add(tableLayoutPanel1);
			panel3.Dock = DockStyle.Bottom;
			panel3.Location = new Point(0, 414);
			panel3.Margin = new Padding(4);
			panel3.Name = "panel3";
			panel3.Size = new Size(388, 86);
			panel3.TabIndex = 4;
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.ColumnCount = 2;
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			tableLayoutPanel1.Controls.Add(button1, 0, 0);
			tableLayoutPanel1.Controls.Add(button2, 1, 0);
			tableLayoutPanel1.Dock = DockStyle.Fill;
			tableLayoutPanel1.Location = new Point(0, 0);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 1;
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
			tableLayoutPanel1.Size = new Size(388, 86);
			tableLayoutPanel1.TabIndex = 0;
			// 
			// button1
			// 
			button1.Dock = DockStyle.Fill;
			button1.Location = new Point(3, 3);
			button1.Name = "button1";
			button1.Size = new Size(188, 80);
			button1.TabIndex = 0;
			button1.Text = "保存";
			button1.UseVisualStyleBackColor = true;
			// 
			// button2
			// 
			button2.Dock = DockStyle.Fill;
			button2.Location = new Point(197, 3);
			button2.Name = "button2";
			button2.Size = new Size(188, 80);
			button2.TabIndex = 1;
			button2.Text = "取消";
			button2.UseVisualStyleBackColor = true;
			// 
			// FunEdit
			// 
			AutoScaleDimensions = new SizeF(10F, 21F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(388, 500);
			Controls.Add(panel1);
			Controls.Add(panel3);
			Controls.Add(panel2);
			Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			Margin = new Padding(4, 4, 4, 4);
			Name = "FunEdit";
			StartPosition = FormStartPosition.CenterParent;
			Text = "FunEdit";
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			panel3.ResumeLayout(false);
			tableLayoutPanel1.ResumeLayout(false);
			ResumeLayout(false);
		}

		#endregion

		private Panel panel1;
		private Panel panel2;
		private TextBox textBox1;
		private Label label2;
		private ComboBox comboBox1;
		private Label label1;
		private Panel panel3;
		private TableLayoutPanel tableLayoutPanel1;
		private Button button1;
		private Button button2;
	}
}