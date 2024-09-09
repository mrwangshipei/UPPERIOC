using COMIEEE;
using FrmControl.BLL;
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
	public partial class UserEditControl : UserControl
	{
		FrmEditCBLL bll;
	//	List<User> users;
		public UserEditControl(List<User> users)
		{
			bll = UPPERIOCApplication.Container.GetInstance<FrmEditCBLL>("FrmEditCBLL");
		//	this.users = users;
			InitializeComponent();
			InitUsers(users);
		}

		private void InitUsers(List<User> users)
		{
			dataGridView1.Rows.Clear();
			for (int i = 0; i < users.Count; i++)
			{
				var user = users[i];
				ShowUser(user);

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
				if (!(item.Tag is User))
				{
					return;
				}
				bll.RemoveUser((User)item.Tag);
				//users.Remove((User)item.Tag);
				dataGridView1.Rows.Remove(item);
			}
			FrmDialog.ShowDialog(this.FindForm(), "删除成功", "提示");
		}
		int i = 0;
		public void ShowUser(User user) {
			int r = dataGridView1.Rows.Add(user.id, user.Name, user.Token, user.UserName, user.ActPath);
			var row = dataGridView1.Rows[r];
			row.Tag = user;
			i++;
			if (i % 2 == 0)
			{
				row.DefaultCellStyle.BackColor = Color.Gray;
			}
		}
		public User AddUser(User us, string pwd) {
			return bll.AddUser(us, pwd);//PremissionCenter.Instance.AddUser(us.UserName, pwd, us.ActPath, us.Name);
		}
		private void button1_Click(object sender, EventArgs e)
		{
			FrmUserEdit ed = new FrmUserEdit();
			var r = ed.ShowDialog();
			if (r == DialogResult.OK)
			{
				var u = bll.AddUser(ed.EUser, ed.passwordChange);
				ShowUser(u);
			}
		}
		private void UpdateUser(DataGridViewRow r,User u) {
			r.Cells[1].Value = u.Name;
			r.Cells[2].Value = u.Token;
			r.Cells[3].Value = u.UserName;
			r.Cells[4].Value = u.ActPath;
			
		}
		private void button3_Click(object sender, EventArgs e)
		{
			if (dataGridView1.SelectedRows.Count != 1)
			{
				FrmDialog.ShowDialog(this.FindForm(), "请选中且只选中一个用户", "提示");
				return;
			}
			DataGridViewRow r = dataGridView1.SelectedRows[0];
			var ur= (User)r.Tag;
			FrmUserEdit ed = new FrmUserEdit(ur);
			var re = ed.ShowDialog();
			if (re == DialogResult.OK)
			{
				User nu = nu = bll.UpdateUserbyid(ed.EUser, ed.passwordChange);
				//User nu = PremissionCenter.Instance.UpdateById(ed.EUser,ed.passwordChange);
				UpdateUser(r,nu);
			}
		}
	}
}
