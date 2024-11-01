using System;
using System.Collections.Generic;
using System.Text;

namespace UPPERIOC2.UPPER.Premission.Model
{
	[Serializable]

	public class Role
	{
        public int id { get; set; }
        public string Name { get; set; }
        public string Backup { get; set; }
    }
}
