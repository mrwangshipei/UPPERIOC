using System.Drawing;
using System.Windows.Forms;

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
			this.label1 = new System.Windows.Forms.Label();
			this.label_Err = new System.Windows.Forms.Label();
			this.textBox_PWD = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.pictureBox_KeyBoard = new System.Windows.Forms.PictureBox();
			this.label3 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_KeyBoard)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(62, 27);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(39, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "密码";
			// 
			// label_Err
			// 
			this.label_Err.AutoSize = true;
			this.label_Err.ForeColor = System.Drawing.Color.Red;
			this.label_Err.Location = new System.Drawing.Point(124, 65);
			this.label_Err.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label_Err.Name = "label_Err";
			this.label_Err.Size = new System.Drawing.Size(71, 16);
			this.label_Err.TabIndex = 1;
			this.label_Err.Text = "密码错误";
			this.label_Err.Visible = false;
			// 
			// textBox_PWD
			// 
			this.textBox_PWD.Location = new System.Drawing.Point(121, 24);
			this.textBox_PWD.MaxLength = 16;
			this.textBox_PWD.Name = "textBox_PWD";
			this.textBox_PWD.PasswordChar = '*';
			this.textBox_PWD.Size = new System.Drawing.Size(155, 26);
			this.textBox_PWD.TabIndex = 2;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(121, 90);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 27);
			this.button1.TabIndex = 3;
			this.button1.Text = "确 定";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// pictureBox_KeyBoard
			// 
			this.pictureBox_KeyBoard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBox_KeyBoard.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_KeyBoard.Image")));
			this.pictureBox_KeyBoard.Location = new System.Drawing.Point(228, 90);
			this.pictureBox_KeyBoard.Name = "pictureBox_KeyBoard";
			this.pictureBox_KeyBoard.Size = new System.Drawing.Size(48, 27);
			this.pictureBox_KeyBoard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox_KeyBoard.TabIndex = 4;
			this.pictureBox_KeyBoard.TabStop = false;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Dock = System.Windows.Forms.DockStyle.Right;
			this.label3.Location = new System.Drawing.Point(296, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(55, 16);
			this.label3.TabIndex = 6;
			this.label3.Text = "label3";
			// 
			// PWD
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(351, 139);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.pictureBox_KeyBoard);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.textBox_PWD);
			this.Controls.Add(this.label_Err);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("宋体", 12F);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(367, 178);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(367, 178);
			this.Name = "PWD";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "请输入密码以继续...";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_KeyBoard)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_Err;
        private System.Windows.Forms.TextBox textBox_PWD;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox_KeyBoard;
		private System.Windows.Forms.Label label3;
	}
}