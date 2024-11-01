using System.Drawing;
using System.Windows.Forms;

namespace UpperComAutoTest.MyControls
{
	partial class MyTips
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
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyTips));
			panel1 = new Panel();
			panel4 = new Panel();
			label1 = new Label();
			panel3 = new Panel();
			label2 = new Label();
			imageList1 = new ImageList(components);
			panel1.SuspendLayout();
			panel4.SuspendLayout();
			panel3.SuspendLayout();
			SuspendLayout();
			// 
			// panel1
			// 
			panel1.Controls.Add(panel4);
			panel1.Controls.Add(panel3);
			panel1.Dock = DockStyle.Fill;
			panel1.Location = new Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new Size(485, 73);
			panel1.TabIndex = 0;
			// 
			// panel4
			// 
			panel4.Controls.Add(label1);
			panel4.Dock = DockStyle.Fill;
			panel4.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			panel4.Location = new Point(72, 0);
			panel4.Name = "panel4";
			panel4.Size = new Size(413, 73);
			panel4.TabIndex = 1;
			// 
			// label1
			// 
			label1.Dock = DockStyle.Fill;
			label1.Font = new Font("幼圆", 18F, FontStyle.Regular, GraphicsUnit.Point);
			label1.Location = new Point(0, 0);
			label1.Name = "label1";
			label1.Size = new Size(413, 73);
			label1.TabIndex = 0;
			label1.Text = "label1";
			label1.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// panel3
			// 
			panel3.Controls.Add(label2);
			panel3.Dock = DockStyle.Left;
			panel3.Location = new Point(0, 0);
			panel3.Margin = new Padding(0);
			panel3.Name = "panel3";
			panel3.Size = new Size(72, 73);
			panel3.TabIndex = 0;
			// 
			// label2
			// 
			label2.BackColor = Color.LightGray;
			label2.Dock = DockStyle.Fill;
			label2.FlatStyle = FlatStyle.Flat;
			label2.Font = new Font("Microsoft YaHei UI", 19F, FontStyle.Regular, GraphicsUnit.Point);
			label2.ImageIndex = 2;
			label2.ImageList = imageList1;
			label2.Location = new Point(0, 0);
			label2.Name = "label2";
			label2.Size = new Size(72, 73);
			label2.TabIndex = 0;
			label2.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// imageList1
			// 
			imageList1.ColorDepth = ColorDepth.Depth32Bit;
			imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
			imageList1.TransparentColor = Color.Transparent;
			imageList1.Images.SetKeyName(0, "提示.png");
			imageList1.Images.SetKeyName(1, "警告.png");
			imageList1.Images.SetKeyName(2, "失败.png");
			imageList1.Images.SetKeyName(3, "成功.png");
			// 
			// MyTips
			// 
			AutoScaleDimensions = new SizeF(7F, 17F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(485, 73);
			Controls.Add(panel1);
			FormBorderStyle = FormBorderStyle.None;
			Name = "MyTips";
			panel1.ResumeLayout(false);
			panel4.ResumeLayout(false);
			panel3.ResumeLayout(false);
			ResumeLayout(false);
		}

		#endregion

		private Panel panel1;
		private ImageList imageList1;
		private Panel panel4;
		private Label label1;
		private Panel panel3;
		private Label label2;
	}
}
