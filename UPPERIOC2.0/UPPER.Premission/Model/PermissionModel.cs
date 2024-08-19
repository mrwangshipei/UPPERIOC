using System;
using System.Collections.Generic;
using System.Text;

namespace UPPERIOC2.UPPER.Premission.Model
{
	public class PermissionModel
	{
		public List<User> users { get; set; }
        public List<Role> roles{ get; set; }
        public List<RoleGroup> rolegps{ get; set; }
        public int Userid { get; set; }
        public int Roleid { get; set; }
        public int RoleGPid { get; set; }
    }
}
