using COMIEEE;
using FrmControl.BLL;
using FrmControl.FrmPremission;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UPPERIOC;
using UPPERIOC2.UPPER.Premission.Center;
using UPPERIOC2.UPPER.Premission.Model;

namespace FrmControl
{
	public partial class RoleEditControl : UserControl
	{
		FrmRoleEditBLL bll;
	//	List<User> users;
		public RoleEditControl(List<Role> users)
		{
			bll = UPPERIOCApplication.Container.GetInstance<FrmRoleEditBLL>("FrmRoleEditBLL");
		//	this.users = users;
			InitializeComponent();
			InitRole(users);
		}

		private void InitRole(List<Role> users)
		{
			dataGridView1.Rows.Clear();
			for (int i = 0; i < users.Count; i++)
			{
				var user = users[i];
				ShowRole(user);

			}
		}

		private void button2_Click(object sender, EventArgs e)
		{

			if (dataGridView1.SelectedRows.Count <= 0)
			{
				FrmDialog.ShowDialog(this.FindForm(), "为选中行", "提示");
				return;
			}
			var r = FrmDialog.ShowDialog(this.FindForm(), $"是否删除{dataGridView1.SelectedRows.Count}行数据", "警告");
			if (r != DialogResult.OK)
			{
				return;
			}
			foreach (DataGridViewRow item in dataGridView1.SelectedRows)
			{
				if (!(item.Tag is Role))
				{
					return;
				}
				bll.RemoveRole((Role)item.Tag);
				//users.Remove((User)item.Tag);
				dataGridView1.Rows.Remove(item);
			}
			FrmDialog.ShowDialog(this.FindForm(), "删除成功", "提示");
		}
		int i = 0;
		public void ShowRole(Role user) {
			int r = dataGridView1.Rows.Add(user.id, user.Name, user.Backup);
			var row = dataGridView1.Rows[r];
			row.Tag = user;
			i++;
			if (i % 2 == 0)
			{
				row.DefaultCellStyle.BackColor = Color.Gray;
			}
		}
	/*	public Role AddUser(Role us) {
			return bll.AddRole(us);//PremissionCenter.Instance.AddUser(us.UserName, pwd, us.ActPath, us.Name);
		}*/
		private void button1_Click(object sender, EventArgs e)
		{
			FrmRoleEdit ed = new FrmRoleEdit();
			var re = ed.ShowDialog();
			if (re == DialogResult.OK)
			{
				Role nu = nu = bll.AddRole(ed.Backupr);
				//User nu = PremissionCenter.Instance.UpdateById(ed.EUser,ed.passwordChange);
				var i = dataGridView1.Rows.Add();
				var r = dataGridView1.Rows[i];
				r.Tag = nu;
				UpdateRole(r, nu);
			}

		}
		private void UpdateRole(DataGridViewRow r, Role u) {
			r.Cells[0].Value = u.id;
			r.Cells[1].Value = u.Name;
			r.Cells[2].Value = u.Backup;
			
		}
		private void button3_Click(object sender, EventArgs e)
		{
			if (dataGridView1.SelectedRows.Count != 1)
			{
				FrmDialog.ShowDialog(this.FindForm(), "请选中且只选中一个用户", "提示");
				return;
			}
			DataGridViewRow r = dataGridView1.SelectedRows[0];
			var ur= (Role)r.Tag;
			FrmRoleEdit ed = new FrmRoleEdit(ur);
			var re = ed.ShowDialog();
			if (re == DialogResult.OK)
			{
				Role nu = nu = bll.UpdateRolrbyid(ed.Backupr);
				//User nu = PremissionCenter.Instance.UpdateById(ed.EUser,ed.passwordChange);
				UpdateRole(r, nu);
			}
		}
	}
}
