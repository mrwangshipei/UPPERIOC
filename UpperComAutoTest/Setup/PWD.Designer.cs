namespace Setup
{
    partial class PWD
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PWD));
			label1 = new Label();
			label_Err = new Label();
			textBox_PWD = new TextBox();
			button1 = new Button();
			pictureBox_KeyBoard = new PictureBox();
			label2 = new Label();
			label3 = new Label();
			((System.ComponentModel.ISupportInitialize)pictureBox_KeyBoard).BeginInit();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(62, 27);
			label1.Margin = new Padding(4, 0, 4, 0);
			label1.Name = "label1";
			label1.Size = new Size(39, 16);
			label1.TabIndex = 0;
			label1.Text = "密码";
			// 
			// label_Err
			// 
			label_Err.AutoSize = true;
			label_Err.ForeColor = Color.Red;
			label_Err.Location = new Point(124, 65);
			label_Err.Margin = new Padding(4, 0, 4, 0);
			label_Err.Name = "label_Err";
			label_Err.Size = new Size(71, 16);
			label_Err.TabIndex = 1;
			label_Err.Text = "密码错误";
			label_Err.Visible = false;
			// 
			// textBox_PWD
			// 
			textBox_PWD.Location = new Point(121, 24);
			textBox_PWD.MaxLength = 16;
			textBox_PWD.Name = "textBox_PWD";
			textBox_PWD.PasswordChar = '*';
			textBox_PWD.Size = new Size(155, 26);
			textBox_PWD.TabIndex = 2;
			textBox_PWD.KeyUp += textBox_PWD_KeyUp;
			// 
			// button1
			// 
			button1.Location = new Point(121, 90);
			button1.Name = "button1";
			button1.Size = new Size(75, 27);
			button1.TabIndex = 3;
			button1.Text = "确 定";
			button1.UseVisualStyleBackColor = true;
			button1.Click += button1_Click;
			// 
			// pictureBox_KeyBoard
			// 
			pictureBox_KeyBoard.BorderStyle = BorderStyle.FixedSingle;
			pictureBox_KeyBoard.Image = (Image)resources.GetObject("pictureBox_KeyBoard.Image");
			pictureBox_KeyBoard.Location = new Point(228, 90);
			pictureBox_KeyBoard.Name = "pictureBox_KeyBoard";
			pictureBox_KeyBoard.Size = new Size(48, 27);
			pictureBox_KeyBoard.SizeMode = PictureBoxSizeMode.Zoom;
			pictureBox_KeyBoard.TabIndex = 4;
			pictureBox_KeyBoard.TabStop = false;
			pictureBox_KeyBoard.Click += pictureBox_KeyBoard_Click;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(2, 121);
			label2.Margin = new Padding(4, 0, 4, 0);
			label2.Name = "label2";
			label2.Size = new Size(119, 16);
			label2.TabIndex = 5;
			label2.Text = "默认密码123456";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Dock = DockStyle.Right;
			label3.Location = new Point(296, 0);
			label3.Name = "label3";
			label3.Size = new Size(55, 16);
			label3.TabIndex = 6;
			label3.Text = "label3";
			// 
			// PWD
			// 
			AutoScaleDimensions = new SizeF(8F, 16F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(351, 139);
			Controls.Add(label3);
			Controls.Add(label2);
			Controls.Add(pictureBox_KeyBoard);
			Controls.Add(button1);
			Controls.Add(textBox_PWD);
			Controls.Add(label_Err);
			Controls.Add(label1);
			Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point);
			Margin = new Padding(4);
			MaximizeBox = false;
			MaximumSize = new Size(367, 178);
			MinimizeBox = false;
			MinimumSize = new Size(367, 178);
			Name = "PWD";
			ShowIcon = false;
			ShowInTaskbar = false;
			StartPosition = FormStartPosition.CenterParent;
			Text = "请输入密码以继续...";
			((System.ComponentModel.ISupportInitialize)pictureBox_KeyBoard).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_Err;
        private System.Windows.Forms.TextBox textBox_PWD;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox_KeyBoard;
        private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
	}
}