using System;
using System.Collections.Generic;
using System.Text;

namespace UPPERIOC2.UPPER.Premission.UAttribute
{
	[AttributeUsage ( AttributeTargets.Class)]
	public class ProxyClassAttribute : Attribute
	{
		public ProxyClassAttribute()
		{
		}
	}
}
