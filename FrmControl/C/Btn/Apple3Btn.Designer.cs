namespace FrmControl.C.Btn
{
	partial class Apple3Btn
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
			this.frmBtn3 = new FrmControl.C.Btn.FrmBtn();
			this.frmBtn2 = new FrmControl.C.Btn.FrmBtn();
			this.frmBtn1 = new FrmControl.C.Btn.FrmBtn();
			this.SuspendLayout();
			// 
			// frmBtn3
			// 
			this.frmBtn3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.frmBtn3.BackColor = System.Drawing.Color.Red;
			this.frmBtn3.BackImg = global::FrmControl.Properties.Resources.Shut_down_2;
			this.frmBtn3.BorderColor = System.Drawing.Color.Black;
			this.frmBtn3.BorderWidth = 0F;
			this.frmBtn3.defaultBackColor = System.Drawing.Color.Red;
			this.frmBtn3.FrmText = null;
			this.frmBtn3.hoverBackColor = System.Drawing.Color.LightBlue;
			this.frmBtn3.ImgPix = 1F;
			this.frmBtn3.Location = new System.Drawing.Point(138, 10);
			this.frmBtn3.Margin = new System.Windows.Forms.Padding(0);
			this.frmBtn3.Name = "frmBtn3";
			this.frmBtn3.pressedBackColor = System.Drawing.Color.LightGreen;
			this.frmBtn3.Radius = 17F;
			this.frmBtn3.Size = new System.Drawing.Size(34, 34);
			this.frmBtn3.smallimg = 0.7F;
			this.frmBtn3.TabIndex = 0;
			this.frmBtn3.Text = "frmBtn1";
			this.frmBtn3.Click += new System.EventHandler(this.frmBtn3_Click);
			// 
			// frmBtn2
			// 
			this.frmBtn2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.frmBtn2.BackColor = System.Drawing.Color.Lime;
			this.frmBtn2.BackImg = global::FrmControl.Properties.Resources.Maximize_2;
			this.frmBtn2.BorderColor = System.Drawing.Color.Black;
			this.frmBtn2.BorderWidth = 0F;
			this.frmBtn2.defaultBackColor = System.Drawing.Color.Lime;
			this.frmBtn2.FrmText = null;
			this.frmBtn2.hoverBackColor = System.Drawing.Color.LightBlue;
			this.frmBtn2.ImgPix = 1F;
			this.frmBtn2.Location = new System.Drawing.Point(81, 10);
			this.frmBtn2.Margin = new System.Windows.Forms.Padding(0);
			this.frmBtn2.Name = "frmBtn2";
			this.frmBtn2.pressedBackColor = System.Drawing.Color.LightGreen;
			this.frmBtn2.Radius = 17F;
			this.frmBtn2.Size = new System.Drawing.Size(34, 34);
			this.frmBtn2.smallimg = 0.7F;
			this.frmBtn2.TabIndex = 0;
			this.frmBtn2.Text = "frmBtn1";
			this.frmBtn2.Click += new System.EventHandler(this.frmBtn2_Click);
			// 
			// frmBtn1
			// 
			this.frmBtn1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.frmBtn1.BackColor = System.Drawing.Color.Yellow;
			this.frmBtn1.BackImg = global::FrmControl.Properties.Resources.Minimize_2;
			this.frmBtn1.BorderColor = System.Drawing.Color.Black;
			this.frmBtn1.BorderWidth = 0F;
			this.frmBtn1.defaultBackColor = System.Drawing.Color.Yellow;
			this.frmBtn1.FrmText = null;
			this.frmBtn1.hoverBackColor = System.Drawing.Color.LightBlue;
			this.frmBtn1.ImgPix = 1F;
			this.frmBtn1.Location = new System.Drawing.Point(22, 10);
			this.frmBtn1.Margin = new System.Windows.Forms.Padding(0);
			this.frmBtn1.Name = "frmBtn1";
			this.frmBtn1.pressedBackColor = System.Drawing.Color.LightGreen;
			this.frmBtn1.Radius = 17F;
			this.frmBtn1.Size = new System.Drawing.Size(34, 34);
			this.frmBtn1.smallimg = 0.7F;
			this.frmBtn1.TabIndex = 0;
			this.frmBtn1.Text = "frmBtn1";
			this.frmBtn1.Click += new System.EventHandler(this.frmBtn1_Click);
			// 
			// Apple3Btn
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Transparent;
			this.Controls.Add(this.frmBtn3);
			this.Controls.Add(this.frmBtn2);
			this.Controls.Add(this.frmBtn1);
			this.Name = "Apple3Btn";
			this.Size = new System.Drawing.Size(198, 54);
			this.ResumeLayout(false);

		}

		#endregion

		private FrmBtn frmBtn1;
		private FrmBtn frmBtn2;
		private FrmBtn frmBtn3;
	}
}
