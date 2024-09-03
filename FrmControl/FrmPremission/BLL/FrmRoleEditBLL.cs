using System;
using UPPERIOC2.UPPER.Premission.Center;
using UPPERIOC2.UPPER.Premission.Model;
using UPPERIOC2.UPPER.Premission.UAttribute;

namespace FrmControl
{
	[ProxyClass]
	public class FrmRoleEditBLL
	{
		[PremissionRequired(4)]
		public virtual void RemoveRole(Role tag)
		{
			PremissionCenter.Instance.pm.roles.Remove(tag);
		}
		[PremissionRequired(3)]

		public virtual Role AddRole(Role backupr)
		{
			return PremissionCenter.Instance.AddRole(backupr);

		}

		[PremissionRequired(3)]

		public virtual Role UpdateRolrbyid(Role backupr)
		{
			return PremissionCenter.Instance.UpdateById(backupr);

		}
	}
}