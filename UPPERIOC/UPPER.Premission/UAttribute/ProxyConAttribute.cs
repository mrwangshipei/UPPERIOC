using System;
using System.Collections.Generic;
using System.Text;

namespace UPPERIOC2.UPPER.Premission.UAttribute
{
	[AttributeUsage ( AttributeTargets.Constructor)]
	public class ProxyConAttribute : Attribute
	{
		public ProxyConAttribute()
		{
		}
	}
}
