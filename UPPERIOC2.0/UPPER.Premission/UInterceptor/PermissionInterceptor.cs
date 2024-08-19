
using System;
using System.Reflection;
using UPPERIOC;
using UPPERIOC2.UPPER.Premission.Center;

public class PermissionInterceptor 
{

	public bool Intercept(int p)
	{
		PremissionCenter cen  =UPPERIOCApplication.Container.GetInstance<PremissionCenter>();
		if (cen.c.AllowNull)
		{
			return true;
		}
			if (!cen.CanInvoke(p))
			{
				// 处理验证失败的情况，比如提示用户登录
				
				return true;
			}
				return false;

		// 调用被拦截的方法

	}
}
