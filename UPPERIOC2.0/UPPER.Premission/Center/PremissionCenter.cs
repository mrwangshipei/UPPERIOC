using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using UPPERIOC.UPPER.IOC.Center.IProvider;
using UPPERIOC2.UPPER.Premission.IConfiguation;
using UPPERIOC2.UPPER.Premission.Model;
using UPPERIOC2.UPPER.Premission.Moudle;
using UPPERIOC2.UPPER.Util;

namespace UPPERIOC2.UPPER.Premission.Center
{
	public class PremissionCenter
	{
		public static IContainerProvider pd;
		public static PremissionCenter Instance { get => pd.GetInstance<PremissionCenter>(); } 
		List<User> users = new List<User>();
		string Locatstr = "HKEY_LOCAL_MACHINE\\SOFTWARE\\";
		public IPremissionConfiguation c;
		public PermissionModel pm;
		RigisterObjLoad rod;
		public User CurrentUser;
		internal void Load()
		{
			var r = pd.GetAllInstance<IPremissionConfiguation>();
			if (r == null || r.Length == 0)
			{
				throw new Exception("请配置至少一个IPremissionConfiguation实现类于容器中");
			}
			c = r[0];
			 rod = RigisterObjLoad.GetInstance(Locatstr+ c.ApplicationName);
			pm = rod.LoadObjectFromRegistry<PermissionModel>(c.ApplicationName);
			if (pm == null)
			{
				if (!c.AllowNull)
				{
					throw new Exception("配置异常，联系管理");
				}
				pm = new PermissionModel();
			}
			CurrentUser = c.Login(pm);
		
		}
		public void AddUserToGroup(User user, RoleGroup gp) 
		{
			gp.users.Add(user.id);

		}
		public void AddRoleToGroup(Role r,RoleGroup rp) 
		{
			rp.Roles.Add(r.id);

		}
		public List<RoleGroup> AddRoleGroup(string GroupName)
		{
			pm.rolegps.Add(new RoleGroup { id = (int)pm.RoleGPid, GpName= GroupName,Roles = new List<int>(), users = new List<int>()});
			pm.RoleGPid++;
			return pm.rolegps;
		}
		public List<Role> AddRole(string RoleName) 
		{
			pm.roles.Add(new Role { id = (int)pm.Roleid, Name = RoleName });
			pm.Roleid++;
			return pm.roles;
		}
		public List<User> AddUser(string UserName,string password)
		{
			string Token = HashHelper.EncryptWithSalt(c.Solt,password);
			pm.users.Add(new User {id  = (int)pm.Userid,Name = UserName,Token = password });
			pm.Userid++;
			return pm.users;

		}
		public bool CanInvoke(int Role) 
		{
			if (CurrentUser == null&& !c.AllowNull)
			{
				CurrentUser = c.Login(pm);

				return false;
			}
			if (pm.rolegps == null && !c.AllowNull)
			{
				CurrentUser = c.Login(pm);

				return false;
			}
			if (pm.rolegps.Find(item => CurrentUser?.RoleGroup == item.id)?.Roles?.Contains(Role)== true )
			{
				return true;
			}
			CurrentUser = c.Login(pm);

			return false;

		}

		public void SaveChange() { 
		
			 rod.SaveObjectToRegistry(c.ApplicationName, pm);
		}
	}
}
