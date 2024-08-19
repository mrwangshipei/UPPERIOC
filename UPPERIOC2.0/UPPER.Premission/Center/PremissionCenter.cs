using System;
using System.Collections.Generic;
using System.Text;
using UPPERIOC.UPPER.IOC.Center.IProvider;
using UPPERIOC2.UPPER.Premission.Model;

namespace UPPERIOC2.UPPER.Premission.Center
{
	public class PremissionCenter
	{
		public static IContainerProvider pd;
		public static PremissionCenter Instance = pd.GetInstance< PremissionCenter>();
		List<User> users = new List<User>();
		internal void LoadUser()
		{
		
		}
	}
}
