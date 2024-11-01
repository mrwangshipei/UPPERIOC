using COMIEEE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UpperComAutoTest.MyControls;
using UPPERIOC;
using UPPERIOC2.UPPER.Premission.Center;
using UPPERIOC2.UPPER.Premission.Model;

namespace FrmControl.FrmPremission
{
	public partial class FrmUserGroupEdit : Form
	{
		FrmRoleGroupbll bll;
		public	RoleGroup rp;
		public FrmUserGroupEdit(RoleGroup rp)
		{
			this.rp = rp;
			bll = UPPERIOCApplication.Container.GetInstance<FrmRoleGroupbll>("FrmRoleGroupbll");
			InitializeComponent();
			InitGP();
		}
		public FrmUserGroupEdit( )
		{
			this.rp = new RoleGroup() ;
			bll = UPPERIOCApplication.Container.GetInstance<FrmRoleGroupbll>("FrmRoleGroupbll");
			InitializeComponent();
			InitGP();
		}

		private void InitGP()
		{
			textBox1.Text = rp.id + "";
			textBox2.Text = rp.GpName;
			textBox3.Text = rp.Backup;
			comboBox1.DrawItem += comboBox1_DrawItem;
			InitRole();
			if (rp.Roles == null)
			{
				return;
			}
			List<Role> rpg = bll.GetRolesByGp(rp);
            foreach (var item in rpg)
            {
				AddPremission(item);                
            }
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

		private void InitRole()
		{
			comboBox1.DataSource = bll.GetRoles();
			comboBox1.DisplayMember = "Name";
		}

		private void button3_Click(object sender, EventArgs e)
		{
			if (comboBox1.SelectedValue == null)
			{
				MyTips.ShowTips(this,Tipstype.Warn,"请先选择一个权限");
				return;
			}
			var sr = (Role)comboBox1.SelectedValue;
			AddPremission(sr);
			rp.Roles.Add(sr.id);
		}
		
		private void AddPremission(Role selectedValue)
		{
			Panel p = new Panel();
			p.Width = flowLayoutPanel1.Width - 10;
			p.Height = 50;
			p.Margin = new Padding(0,0,0,10);
			Label tip = new Label();
			tip.Font = Font;
			tip.Text = "权限:";
			tip.TextAlign = ContentAlignment.MiddleCenter;
			tip.AutoSize = false;
			tip.BackColor = Color.Gray;
			tip.Dock = DockStyle.Left;
			tip.Width = (int)(p.Width * 0.3);
			Label pro = new Label();
			pro .Font = Font;
			pro .Text = selectedValue.Name;
			pro .TextAlign = ContentAlignment.MiddleCenter;
			pro .AutoSize = false;
			pro .BackColor = Color.Gray;
			pro.Dock = DockStyle.Fill;
			Label Del= new Label();
			Del.Font = Font;
			Del.Text = "移除权限";
			Del.TextAlign = ContentAlignment.MiddleCenter;
			Del.AutoSize = false;
			Del.BackColor = Color.Orange;
			Del.Dock = DockStyle.Right;
			Del.Width = (int)(p.Width * 0.3);
			Del.Click += (ee, arg) =>
			{
				var r = FrmDialog.ShowDialog(this,"是否删除权限" + selectedValue.Name ,"警告");
				if (r == DialogResult.OK)
				{
					rp.Roles.Remove(selectedValue.id);
					flowLayoutPanel1.Controls.Remove(p);
				}
				
			};
			p.Controls.Add(pro);
			p.Controls.Add(tip);
			p.Controls.Add(Del);
			flowLayoutPanel1.Controls.Add(p);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void textBox2_TextChanged(object sender, EventArgs e)
		{
			rp.GpName = textBox2.Text;
		}

		private void textBox3_TextChanged(object sender, EventArgs e)
		{
			rp.Backup = textBox3.Text;
		}
	}
}
