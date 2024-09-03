using System;
using System.Collections.Generic;
using UPPERIOC2.UPPER.Premission.Center;
using UPPERIOC2.UPPER.Premission.Model;
using UPPERIOC2.UPPER.Premission.UAttribute;

namespace FrmControl
{
	[ProxyClass]
	public class FrmRoleGroupbll
	{
		[PremissionRequired(6)]
		public virtual void RemoveRole(RoleGroup tag)
		{
			PremissionCenter.Instance.pm.rolegps.Remove(tag);
		}
		[PremissionRequired(5)]

		public virtual RoleGroup AddRole(RoleGroup backupr)
		{
			return PremissionCenter.Instance.AddRoleGroup(backupr);

		}

		public virtual List<Role> GetRoles()
		{
			return PremissionCenter.Instance.pm.roles;
		}

		public virtual List<Role> GetRolesByGp(RoleGroup rp)
		{
			return PremissionCenter.Instance.GetRoleByRoleGroup(rp);

		}

		[PremissionRequired(5)]

		public virtual RoleGroup UpdateRolrbyid(RoleGroup backupr)
		{
			return PremissionCenter.Instance.UpdateById(backupr);

		}
	}
}