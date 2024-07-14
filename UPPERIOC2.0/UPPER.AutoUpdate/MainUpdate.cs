using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using UPPERIOC.UPPER.IOC.Center.IProvider;
using UPPERIOC2._0.UPPER.AutoUpdate.Interfaces;

namespace UPPERIOC2._0.UPPER.AutoUpdate
{
	public class MainUpdate
	{
		public static void InitUpdate(IContainerProvider containerProvider) 
		{
			var ccss =containerProvider.GetAllInstance(typeof(UpdateProcess)) ;
            foreach (var item in ccss)
            {
				var ups = item as UpdateProcess;
				bool r= ups.CheckUpdate();
				if (r)
				{
					bool  up = ups.Update();
					if (up)
					{
						ups.FinishUpdate();
					}
					else
					{
						ups.UpdateFail();

					}
				}
				else
				{
					ups.NeedNotFail();
				}
			}
        }

	}
}
