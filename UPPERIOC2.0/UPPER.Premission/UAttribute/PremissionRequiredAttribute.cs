using System;

[AttributeUsage(AttributeTargets.Method)]
public class PremissionRequiredAttribute : Attribute
{
	public int Permission { get; }

	public PremissionRequiredAttribute(int permission)
	{
		Permission = permission;
	}
}
