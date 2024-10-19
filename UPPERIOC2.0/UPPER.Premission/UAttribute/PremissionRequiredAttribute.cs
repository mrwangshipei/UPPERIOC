using System;

[AttributeUsage(AttributeTargets.Method)]
public class PremissionRequiredAttribute : Attribute
{
	public int Permission { get; }
	public bool NeedLogin { get; }

	public PremissionRequiredAttribute(int permission,bool NeedLogin = false)
	{
		Permission = permission;
		this.NeedLogin = NeedLogin;
	}

}
