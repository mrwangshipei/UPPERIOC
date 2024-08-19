using System;
using System.Collections.Generic;
using System.Text;

namespace UPPERIOC2.UPPER.Premission.Model
{
	public class User
	{
        public int id { get; set; }
        public string Name { get; set; }
		public string  Token { get; set; }

        public int RoleGroup { get; set; }

    }
}
