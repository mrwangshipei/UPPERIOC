using System;
using System.Collections.Generic;
using System.IO;
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
				else
				{
					pm = c.InitModel();
					SaveChange();
				}
				//pm = new PermissionModel();
			}
			CurrentUser = c.Login(pm);
			if (CurrentUser == null && !c.AllowNull)
			{
				throw new Exception("登录失败");
			}
		}
		public void AddUserToGroup(User user, RoleGroup gp) 
		{
			user.RoleGroup = gp.id;
			//gp.users.Add(user.id);

		}
		public void AddRoleToGroup(Role r,RoleGroup rp) 
		{
			rp.Roles.Add(r.id);

		}
		public void Must(int premission) {
			User Cu = CurrentUser;
			while(!PermissionInterceptor.Intercept(premission))
			{
			}
			CurrentUser = Cu;



		}
		public List<Role> GetRoleByRoleGroup(RoleGroup rp)
		{
			List<Role> lr = new List<Role>();


			foreach (var item in rp.Roles)
            {
				var i = pm.roles.Find(item1 => item == item1.id);
				if (i != null)
				{
				lr.Add(i);

				}
            }
			return lr;
        }
		public RoleGroup AddRoleGroup(RoleGroup GroupName)
		{
			GroupName.id = pm.RoleGPid;
			pm.rolegps.Add(GroupName);
			pm.RoleGPid++;
			return GroupName;
		}
		public Role AddRole(Role Role) 
		{
			Role.id = pm.Roleid;
			pm.roles.Add(Role);
			pm.Roleid++;
			return Role;
		}
		public User UpdateById(User us,string pwd = null) {
			var changeu = pm.users.Find(item=> item.id == us.id);
			changeu.Name = us.Name;
			changeu.RoleGroup = us.RoleGroup;
			if (!string.IsNullOrWhiteSpace(pwd))
			{
			string Token = HashHelper.EncryptWithSalt(c.Solt, pwd);
				changeu.Token = Token;

			}
			changeu.UserName = us.UserName;
			//changeu.ActPath = us.ActPath;
			if (changeu.ActPath != us.ActPath)
			{
				changeu.ActPath = AddPic(us.ActPath);

			}
			return changeu;

		}

		public Role UpdateById(Role us)
		{
			var changeu = pm.roles.Find(item => item.id == us.id);
			changeu.Name = us.Name;
			changeu.Backup = us.Backup;
			return changeu;

		}
		public RoleGroup UpdateById(RoleGroup us)
		{
			var changeu = pm.rolegps.Find(item => item.id == us.id);
			changeu.Backup= us.Backup;
			changeu.GpName= us.GpName;
			changeu.Roles= us.Roles;
			//changeu.users= us.users;
			return changeu;

		}

		public void RemoveChange() {
			pm = rod.LoadObjectFromRegistry<PermissionModel>(c.ApplicationName);

		}
		public string AddPic(string str)
		{
			var fi = FileUtil.RelativePathToFileInfo(str);
			if (fi== null || !fi.Exists)
			{
				return "";
			}
			var dpa = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, c.PicSavePath);
			if (!Directory.Exists(dpa))
			{
				Directory.CreateDirectory(dpa);
			}
			var dstr = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, c.PicSavePath, pm.PicNum + "");
			fi.CopyTo(dstr,true);
			pm.PicNum++;
			return FileUtil.FileInfoToRelativePath(new FileInfo(dstr));
		}
		public User AddUser(string UserName,string password,string ActPath,string Name)
		{
			string Token = HashHelper.EncryptWithSalt(c.Solt, password);
			
			var user= 			new User { id = (int)pm.Userid, UserName = UserName, Token = Token, ActPath = ActPath, Name = Name };
			pm.users.Add(user);
			pm.Userid++;
			user.ActPath = AddPic(user.ActPath);
			return user;

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
			bool r = c.NotPremission();
			if (r)
			{
				CurrentUser = c.Login(pm);
				return CanInvoke(Role);
			}

			return false;

		}

		public void SaveChange() { 
		
			 rod.SaveObjectToRegistry(c.ApplicationName, pm);
		}
	}
}
