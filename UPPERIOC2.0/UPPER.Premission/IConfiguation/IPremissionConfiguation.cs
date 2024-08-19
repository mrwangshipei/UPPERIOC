using System;
using System.Collections.Generic;
using System.Text;
using UPPERIOC2.UPPER.Premission.Model;

namespace UPPERIOC2.UPPER.Premission.IConfiguation
{
	public  interface  IPremissionConfiguation
	{
		
		string ApplicationName { get; set; }
		string Solt{ get; set; }
		bool AllowNull { get; set; }

		User Login(PermissionModel pm);
	}
}
