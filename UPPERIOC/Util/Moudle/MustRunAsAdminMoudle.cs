#if NETFRAMEWORK
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using UPPERIOC.UPPER.IOC.Center.Interface;
using UPPERIOC.UPPER.IOC.Center.IProvider;
using static System.Net.Mime.MediaTypeNames;

namespace UPPERIOC2.UPPER.Util.Moudle
{
    [StructLayout(LayoutKind.Sequential)]
	struct TOKEN_ELEVATION_TYPE
	{
		public int TokenElevationType;
	}

	
}
#endif