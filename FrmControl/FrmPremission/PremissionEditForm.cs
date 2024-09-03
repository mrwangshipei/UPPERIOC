using COMIEEE;
using FrmControl;
using FrmControl.FrmPremission.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UPPERIOC;
using UPPERIOC2.UPPER.Premission.Center;
using UPPERIOC2.UPPER.Premission.Model;
using UPPERIOC2.UPPER.Util;

namespace Scancodeupload.View
{
	public partial class PremissionEditForm : Form
	{
		PremissionBLL bll;
		public PremissionEditForm()
		{
			bll = UPPERIOCApplication.Container.GetInstance<PremissionBLL>();
			InitializeComponent();
			InitCurrentUser();
			InitUser();
			InitRole();
			InitRP();
		}

		private void InitRP()
		{
			var rec = new RoleGroupEditControl(PremissionCenter.Instance.pm.rolegps);
			rec.Dock = DockStyle.Fill;
			tabPage3.Controls.Add(rec);
		}

		private void InitRole()
		{
			var rec = new RoleEditControl(PremissionCenter.Instance.pm.roles);
			rec.Dock = DockStyle.Fill;
			tabPage2.Controls.Add(rec);
		}

		private void InitCurrentUser()
		{
			label3.Text = PremissionCenter.Instance.CurrentUser.Name;
			FileInfo i = FileUtil.RelativePathToFileInfo(PremissionCenter.Instance.CurrentUser.ActPath);
			if (i != null)
			{

				panel5.BackgroundImage = Image.FromFile(i.FullName);
			}
		}
		UserEditControl ud;
		private void InitUser()
		{
			ud = new UserEditControl(PremissionCenter.Instance.pm.users);
			ud.Dock = DockStyle.Fill;
			panel1.Controls.Add(ud);
		}

		private void PremissionEditForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			var r = FrmDialog.ShowDialog(this,"是否保存修改？","提示");
			if (r == DialogResult.OK)
			{
				bll.SaveChange();
			}
			else
			{
				bll.ReMoveChange();

			}
		}
	}
}
