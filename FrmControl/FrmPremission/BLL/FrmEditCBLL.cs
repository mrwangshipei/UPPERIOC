using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPPERIOC2.UPPER.Premission.Center;
using UPPERIOC2.UPPER.Premission.Model;
using UPPERIOC2.UPPER.Premission.UAttribute;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FrmControl.BLL
{
	[ProxyClass]
	public class FrmEditCBLL
	{
		[PremissionRequired(1)]
		public virtual User UpdateUserbyid(User user, string passwordChange)
		{
			return  PremissionCenter.Instance.UpdateById(user, passwordChange);

		}
		[PremissionRequired(1)]

		public virtual User AddUser(User us, string pwd)
		{
			return PremissionCenter.Instance.AddUser(us.UserName, pwd, us.ActPath, us.Name);
		}
		[PremissionRequired(2)]
		public virtual void RemoveUser(User tag)
		{
			 PremissionCenter.Instance.pm.users.Remove(tag);
		}

		public virtual List<RoleGroup> GetRoleGroups()
		{
			return PremissionCenter.Instance.pm.rolegps;

		}
	}
}
