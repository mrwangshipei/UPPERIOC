using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UPPERIOC;
using UPPERIOC2.UPPER.VersionControl.IVersion;

namespace UPPERIOC2.UPPER.VersionControl
{
	public class VersionCenter
	{
		public static List<IVersionControl> IVersions { get; internal set; }

		void ToVersion(double version)
		{
			if (IVersions == null)
			{
				throw new Exception("请加载模块UPPERVersionControlMoudle");
			}
			if (UPPERIOCApplication.vm == null)
			{
				throw new Exception("模块初始版本失败，应用需要获取文件写入权限");
			}
			var dfv = UPPERIOCApplication.vm.NowVersion;
			var rollback = IVersions.Where(item => version < dfv && item.Version <= dfv && item.Version > version);
			var Update = IVersions.Where(item => version > dfv && item.Version <= version && item.Version > dfv);
            foreach (var item in rollback)
            {
				item.RollBack();
            }
			foreach (var item in Update)
			{
				item.Update();
			}
        }
	}
}
