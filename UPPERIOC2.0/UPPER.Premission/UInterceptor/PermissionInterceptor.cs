
using System;
using System.Reflection;
using UPPERIOC;
using UPPERIOC2.UPPER.Premission.Center;

public static class PermissionInterceptor 
{

	public  static bool Intercept(int p)
	{
		PremissionCenter cen  =UPPERIOCApplication.Container.GetInstance<PremissionCenter>();
		if (cen.c.AllowNull)
		{
			return true;
		}
		return cen.CanInvoke(p);
		
				// 处理验证失败的情况，比如提示用户登录
				
			

		// 调用被拦截的方法

	}
}
