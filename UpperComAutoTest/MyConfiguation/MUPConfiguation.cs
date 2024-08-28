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
			throw new NotImplementedException();
		}

		public User Login(PermissionModel pm)
		{
			
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
			throw new NotImplementedException();
		}
	}
}
