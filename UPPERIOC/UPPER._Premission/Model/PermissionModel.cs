using System;
using System.Collections.Generic;
using System.Text;

namespace UPPERIOC2.UPPER.Premission.Model
{
	[Serializable]

	public class PermissionModel
	{
        public List<User> users { get; set; } = new List<User>();
        public List<Role> roles { get; set; } = new List<Role>();
        public List<RoleGroup> rolegps { get; set; } = new List<RoleGroup>();
        public int Userid { get; set; }
        public int Roleid { get; set; }
        public int RoleGPid { get; set; }
		public int  PicNum { get;  set; }
	}
}
