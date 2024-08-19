using System;
using System.Collections.Generic;
using System.Text;

namespace UPPERIOC2.UPPER.Premission.Model
{
	public  class RoleGroup
	{
        public int id { get; set; }
        public string GpName { get; set; }
        public List<int> Roles { get; set; }
        public List<int> users{ get; set; }
    }
}
