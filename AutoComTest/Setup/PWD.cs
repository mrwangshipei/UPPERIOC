using System;
using System.Windows.Forms;

namespace Setup
{
    public partial class PWD : Form
    {
        DateTime f;
        public PWD()
        {
            f = DateTime.Now;
            InitializeComponent();
            label3.Text = f.ToLongTimeString();
        }

        private void pictureBox_KeyBoard_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox_PWD.Text == string.Empty)
                textBox_PWD.Text = "123456";
            var x = f.Hour + f.Hour;

			if (("AX127007" + x).Equals(textBox_PWD.Text.Trim()))
                this.DialogResult = DialogResult.Yes;
            else
                label_Err.Visible = true;
        }

        private void textBox_PWD_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(null, null);
            }
        }
    }
}
