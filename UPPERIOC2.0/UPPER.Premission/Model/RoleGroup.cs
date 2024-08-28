using System;
using System.Collections.Generic;
using System.Text;

namespace UPPERIOC2.UPPER.Premission.Model
{
	[Serializable]

	public class RoleGroup
	{
        public int id { get; set; }
        public string GpName { get; set; }
        public string Backup{ get; set; }
        public List<int> Roles { get; set; } = new List<int>();
        //public List<int> users{ get; set; }
    }
}
