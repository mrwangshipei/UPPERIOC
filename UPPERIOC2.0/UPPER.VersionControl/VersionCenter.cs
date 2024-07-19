using System;
using System.Collections.Generic;
using System.Text;
using UPPERIOC2._0.UPPER.VersionControl.IVersion;

namespace UPPERIOC2._0.UPPER.VersionControl
{
	public class VersionCenter
	{
		public static IEnumerable<IVersionControl> IVersions { get; internal set; }

		void NowVersion(double version)
		{
			if (IVersions == null)
			{
				throw new Exception("请先调用");
			}
		}
	}
}
