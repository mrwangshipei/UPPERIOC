using COMIEEE.Util;
using FrmControl.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UPPERIOC;
using UPPERIOC2.UPPER.Premission.Model;
using UPPERIOC2.UPPER.Util;

namespace FrmControl
{
	public partial class FrmUserEdit : Form
	{
		public User EUser;
		public string passwordChange;
		FrmEditCBLL bll;
		public FrmUserEdit()
		{
			bll = UPPERIOCApplication.Container.GetInstance<FrmEditCBLL>();
			EUser = new User();
			InitializeComponent();
			comboBox1.DrawItem += comboBox1_DrawItem;
			InitRoleGp();

		}

		private void comboBox1_DrawItem(object sender, DrawItemEventArgs e)
		{
			// Check if the index is valid
			if (e.Index < 0) return;

			// Get the item from the data source
			object item = comboBox1.Items[e.Index];

			// Get the value of the DisplayMember property
			string displayMember = comboBox1.DisplayMember;
			PropertyInfo property = item.GetType().GetProperty(displayMember);
			string text = property?.GetValue(item, null)?.ToString() ?? string.Empty;

			// Set background and text color
			e.DrawBackground();
			Brush brush = (e.State & DrawItemState.Selected) == DrawItemState.Selected
				? SystemBrushes.HighlightText : SystemBrushes.WindowText;

			// Draw the text with proper formatting
			StringFormat sf = new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
			e.Graphics.DrawString(text, e.Font, brush, e.Bounds, sf);

			// Draw focus rectangle if needed
			e.DrawFocusRectangle();
		}

		public FrmUserEdit(User user)
		{
			this.EUser = Deepcopy.DeepCopy(user);
			bll = UPPERIOCApplication.Container.GetInstance<FrmEditCBLL>();

			InitializeComponent();
			InitUser();
			comboBox1.DrawItem += comboBox1_DrawItem;

			InitRoleGp();
		}

		private void InitRoleGp()
		{
			List<RoleGroup> rps = bll.GetRoleGroups();
			comboBox1.DataSource = rps;
			comboBox1.DisplayMember = "GpName";
			comboBox1.SelectedItem = rps.Find(item => item.id == EUser.RoleGroup); 
			this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);

		}

		private void InitUser()
		{
			textBox1.Text = EUser.UserName;
		//	textBox2.Text = EUser.Token;
			textBox3.Text = EUser.Name;
			
		}

		private void panel1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			OpenFileDialog opf = new OpenFileDialog();
			opf.DefaultExt = "png|jpg|jpeg";
			opf.FileOk += (sss,eee) =>{
				var fif =  new FileInfo(opf.FileName);
				EUser.ActPath =FileUtil.FileInfoToRelativePath(fif);
				panel1.BackgroundImage = Image.FromFile(opf.FileName);	
			};
			opf.ShowDialog();
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			EUser.UserName = textBox1.Text;
		}

		private void textBox3_TextChanged(object sender, EventArgs e)
		{
			EUser.Name= textBox1.Text;

		}

		private void textBox2_TextChanged(object sender, EventArgs e)
		{
			passwordChange = textBox2.Text;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			var rp  = (RoleGroup)comboBox1.SelectedValue;
			EUser.RoleGroup = rp.id;
		}

		private void panel1_Paint(object sender, PaintEventArgs e)
		{

		}
	}
}
