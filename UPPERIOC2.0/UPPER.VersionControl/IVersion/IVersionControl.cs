using System;
using System.Collections.Generic;
using System.Text;

namespace UPPERIOC2._0.UPPER.VersionControl.IVersion
{
	public interface IVersionControl
	{
        double Version { get; set; }
		void Update();
		void RollBack();
    }
}
