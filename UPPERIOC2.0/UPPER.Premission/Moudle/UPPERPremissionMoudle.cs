
using System;

using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using UPPERIOC.UPPER.IOC.Center.Interface;
using UPPERIOC.UPPER.IOC.Center.IProvider;
using UPPERIOC.UPPER.IOC.Extend;
using UPPERIOC2.UPPER.Premission.Center;
using UPPERIOC2.UPPER.Premission.UAttribute;

namespace UPPERIOC2.UPPER.Premission.Moudle
{
	public class UPPERPremissionMoudle : IUPPERMoudle
	{
		public Type[] DependisMoudel { get => new Type[0]; set => throw new NotImplementedException(); }


	public object CreateProxy(Type target)
{
    var targetType = target;
    var assemblyName = new AssemblyName(targetType.Name + "ProxyAssembly");
    var assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
    var moduleBuilder = assemblyBuilder.DefineDynamicModule("MainModule");

    var typeBuilder = moduleBuilder.DefineType(targetType.Name + "Proxy", TypeAttributes.Public | TypeAttributes.Class, targetType);

    // 添加一个字段来保存被代理的实例
    var targetField = typeBuilder.DefineField("_target", targetType, FieldAttributes.Private);

    // 定义构造函数来初始化被代理的实例
    var constructorBuilder = typeBuilder.DefineDefaultConstructor(MethodAttributes.Public);
   /* var ctorIlGenerator = constructorBuilder.GetILGenerator();
    ctorIlGenerator.Emit(OpCodes.Ldarg_0); // this
    ctorIlGenerator.Emit(OpCodes.Ldarg_1); // target
    ctorIlGenerator.Emit(OpCodes.Stfld, targetField);
    ctorIlGenerator.Emit(OpCodes.Ret);*/

    // 为每个方法生成代理逻辑
    foreach (var method in targetType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly))
    {
        var permissionAttribute = method.GetCustomAttribute<PremissionRequiredAttribute>();
        if (permissionAttribute == null)
        {
            continue;
        }

        var parameterTypes = Array.ConvertAll(method.GetParameters(), p => p.ParameterType);
        var methodBuilder = typeBuilder.DefineMethod(method.Name, MethodAttributes.Public | MethodAttributes.Virtual, method.ReturnType, parameterTypes);
        var ilGenerator = methodBuilder.GetILGenerator();

        if (permissionAttribute != null)
        {
            var permissionCheckLabel = ilGenerator.DefineLabel();
            ilGenerator.Emit(OpCodes.Ldstr, permissionAttribute.Permission);
            ilGenerator.Emit(OpCodes.Call, typeof(PermissionInterceptor).GetMethod("Intercept", new[] { typeof(int) }));
            ilGenerator.Emit(OpCodes.Brtrue_S, permissionCheckLabel);

            if (method.ReturnType != typeof(void))
            {
                ilGenerator.Emit(OpCodes.Ldstr, "Unauthorized");
            }
            ilGenerator.Emit(OpCodes.Ret);

            ilGenerator.MarkLabel(permissionCheckLabel);
        }

        ilGenerator.Emit(OpCodes.Ldarg_0);
        ilGenerator.Emit(OpCodes.Ldfld, targetField);

        for (int i = 0; i < parameterTypes.Length; i++)
        {
            ilGenerator.Emit(OpCodes.Ldarg, i + 1);
        }

        ilGenerator.Emit(OpCodes.Call, method);

        if (method.ReturnType != typeof(void))
        {
            ilGenerator.Emit(OpCodes.Ret);
        }

        typeBuilder.DefineMethodOverride(methodBuilder, method);
    }

    var proxyType = typeBuilder.CreateTypeInfo();

    // 检查构造函数是否正确生成
    var constructors = proxyType.DeclaredConstructors;
    foreach (var constructor in constructors)
    {
        Console.WriteLine(constructor);
    }

    return //Activator.CreateInstance(proxyType, target);
}

		private void LoadClass()
		{
			// 获取当前执行的程序集  
			Assembly executingAssembly = Assembly.GetEntryAssembly();
			foreach (var item in executingAssembly.GetTypes())
			{
				var item1 = Assembly.GetAssembly(item);
				if (item.HasBaseClassWithAttribute<ProxyClassAttribute>())
				{
					//Contain[item] = null;
					/*	var proxyGenerator = new ProxyGenerator();
						var interceptor = new PermissionInterceptor(cen);
						var c = proxyGenerator.GetType().GetMethod("CreateClassProxy");
						var mgm = c.MakeGenericMethod(item);
						var obj = mgm.Invoke(proxyGenerator, new object[] { interceptor });*/
					var obj = CreateProxy(item);
					containerProvider.Rigister(item,obj);
				}
			}
			// 获取该程序集所依赖的所有程序集的名字  
			AssemblyName[] referencedAssemblies = executingAssembly.GetReferencedAssemblies();

			foreach (AssemblyName assemblyName in referencedAssemblies)
			{
				if (assemblyName.FullName == Assembly.GetExecutingAssembly().GetName().FullName)
				{

					continue;
				}
				try
				{
					// 尝试加载依赖的程序集  
					Assembly asm = Assembly.Load(assemblyName);
					foreach (var item in asm.GetTypes())
					{
						var item1 = Assembly.GetAssembly(item);
						if (item.HasBaseClassWithAttribute<ProxyClassAttribute>())
						{
							//	Contain[item] = null;
							//	containerProvider.Rigister(item);
							var obj = CreateProxy(item);
							containerProvider.Rigister(item, obj);
						}
					}
					// 输出加载的程序集的信息  
					Console.WriteLine("Loaded assembly: " + asm.FullName);

					// 现在你可以通过 loadedAssembly 变量来探索这个程序集中的类型和方法了  
				}
				catch (Exception ex)
				{
					// 如果加载失败，打印异常信息  
					Console.WriteLine("Failed to load assembly: " + assemblyName.FullName + ". Error: " + ex.Message);
				}
			}

		}
		PremissionCenter cen;
		IContainerProvider containerProvider;
		public void AfterCreateInstance(IContainerProvider containerProvider)
		{
			this.containerProvider = containerProvider;
			PremissionCenter.pd = containerProvider;
		 cen = PremissionCenter.pd.Rigister<PremissionCenter>();
			cen.Load();
			LoadClass();
		}

		public void InitEnd(IContainerProvider containerProvider)
		{
		}

		public void IniterAndLoadClass(IContainerProvider containerProvider)
		{
		}

		public void PreIniter(IContainerProvider containerProvider)
		{
		
		}

	}
}
