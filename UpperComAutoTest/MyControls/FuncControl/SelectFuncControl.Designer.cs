namespace UpperComAutoTest.MyControls.FuncControl
{
	partial class SelectFuncControl
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
			label1 = new Label();
			button1 = new Button();
			SuspendLayout();
			// 
			// label1
			// 
			label1.Dock = DockStyle.Left;
			label1.Location = new Point(0, 0);
			label1.Margin = new Padding(4, 0, 4, 0);
			label1.Name = "label1";
			label1.Size = new Size(116, 65);
			label1.TabIndex = 0;
			label1.Text = "label1";
			label1.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// button1
			// 
			button1.Dock = DockStyle.Fill;
			button1.Location = new Point(116, 0);
			button1.Margin = new Padding(4);
			button1.Name = "button1";
			button1.Size = new Size(260, 65);
			button1.TabIndex = 1;
			button1.Text = "编辑";
			button1.UseVisualStyleBackColor = true;
			// 
			// SelectFuncControl
			// 
			AutoScaleDimensions = new SizeF(10F, 21F);
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(button1);
			Controls.Add(label1);
			Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			Margin = new Padding(4);
			Name = "SelectFuncControl";
			Size = new Size(376, 65);
			ResumeLayout(false);
		}

		#endregion

		private Label label1;
		private Button button1;
	}
}
