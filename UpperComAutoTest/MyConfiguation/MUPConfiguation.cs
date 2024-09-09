using COMIEEE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPPERIOC.UPPER.IOC.Annaiation;
using UPPERIOC2.UPPER.Premission.Center;
using UPPERIOC2.UPPER.Premission.IConfiguation;
using UPPERIOC2.UPPER.Premission.Model;
using UPPERIOC2.UPPER.Util;

namespace UpperComAutoTest.MyConfiguation
{
	[IOCObject]
	internal class MUPConfiguation : IPremissionConfiguation
	{
		public string ApplicationName { get => "AutoComTest"; set => throw new NotImplementedException(); }
		public string Solt { get => "0dfsasda"; set => throw new NotImplementedException(); }
		public bool AllowNull { get => false; set => throw new NotImplementedException(); }
		public string PicSavePath { get => "Pic"; set => throw new NotImplementedException(); }


		public PermissionModel InitModel()
		{
			PermissionModel pm = new PermissionModel();
			pm.users = new List<User>()
			{
				new User(){ Name = "管理", UserName = "admin",  Token =  HashHelper.EncryptWithSalt(Solt, "123456"), RoleGroup = 0}
			};
			pm.Userid = 1;
			pm.roles = new List<Role>()
			{
				new Role(){ id = 0 },
				new Role(){ id = 1 },
				new Role(){ id = 2 },
				new Role(){ id = 3},
				new Role(){ id = 4 },
				new Role(){ id = 5 },
				new Role(){ id = 6 },
				new Role(){ id = 7 },
				new Role(){ id = 8 },
			};
			pm.Roleid = 9;
			pm.rolegps = new List<RoleGroup>()
			{
			new RoleGroup(){  id  = 0
			, GpName  ="管理组"
, Roles  = new List<int>(){ 0,1,2,3,4,5,6,7,8}

			},
			};
			pm.RoleGPid = 1;
			return pm;
		}

		public User Login(PermissionModel pm)
		{
			;
			if (pm.users != null && pm.users.Count > 0)
			{
				
				var r = FrmPwd.Show("登录");
				User us;
				us = pm.users.Find(item => item.UserName == r[0] && item.Token == HashHelper.EncryptWithSalt(Solt, r[1]));
				return us;

			}
			else
			{
				PremissionCenter.Instance.AddUser("admin","123456","","");
				return Login(pm);
			}
			return null;
		}


		public bool NotPremission()
		{
			var r = FrmDialog.ShowDialog("对不起，您的权限不足,是否重新验证身份？", "提示");
			return (r == System.Windows.Forms.DialogResult.OK);


		}
	}
}
