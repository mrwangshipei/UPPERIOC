using System;
using System.Collections.Generic;
using System.Text;

namespace UPPERIOC2.UPPER.Premission.Model
{
    [Serializable]
	public class User
	{
        public int id { get; set; }
        public string UserName { get; set; }
        public string ActPath{ get; set; }

        public string Name { get; set; }
        public string Backup { get; set; }
		public string  Token { get; set; }

        public int RoleGroup { get; set; }

    }
}
