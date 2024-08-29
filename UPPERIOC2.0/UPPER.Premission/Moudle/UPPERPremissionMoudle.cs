
using System;
using System.Linq;
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
		public object CreateProxy(Type target )
		{
			var targetType = target;
			var assemblyName = new AssemblyName(targetType.Name + "ProxyAssembly");
			var assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
			var moduleBuilder = assemblyBuilder.DefineDynamicModule("MainModule");

			var typeBuilder = moduleBuilder.DefineType(
				targetType.Name + "Proxy",
				TypeAttributes.Public | TypeAttributes.Class,
				targetType
			);

			// 添加一个字段来保存被代理的实例
			var targetField = typeBuilder.DefineField("_target", targetType, FieldAttributes.Private);

			// 定义构造函数来初始化被代理的实例
			var constructorBuilder = typeBuilder.DefineConstructor(
				MethodAttributes.Public,
				CallingConventions.Standard,
				new[] { targetType }
			);

			var ilGenerator = constructorBuilder.GetILGenerator();
			ilGenerator.Emit(OpCodes.Ldarg_0);
			ilGenerator.Emit(OpCodes.Ldarg_1);
			ilGenerator.Emit(OpCodes.Stfld, targetField);
			ilGenerator.Emit(OpCodes.Ret);

			// 为每个方法生成代理逻辑
			foreach (var method in targetType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly))
			{
				var permissionAttribute = method.GetCustomAttribute<PremissionRequiredAttribute>();
				if (permissionAttribute == null)
				{
					continue;
				}

				var parameterTypes = Array.ConvertAll(method.GetParameters(), p => p.ParameterType);
				var methodBuilder = typeBuilder.DefineMethod(
					method.Name,
					MethodAttributes.Public | MethodAttributes.Virtual | MethodAttributes.HideBySig,
					method.ReturnType,
					parameterTypes
				);

				ilGenerator = methodBuilder.GetILGenerator();

				// Define permission check logic
				if (permissionAttribute != null)
				{
					var permissionCheckLabel = ilGenerator.DefineLabel();
					var endOfMethodLabel = ilGenerator.DefineLabel();

					// Push the required permission onto the stack
					ilGenerator.Emit(OpCodes.Ldc_I4, permissionAttribute.Permission);

					// Call the PermissionInterceptor.Intercept method
					ilGenerator.Emit(OpCodes.Call, typeof(PermissionInterceptor).GetMethod("Intercept", new[] { typeof(int) }));

					// If permission is granted, continue to the method body
					ilGenerator.Emit(OpCodes.Brtrue_S, permissionCheckLabel);

					// Permission denied, handle it
					if (method.ReturnType != typeof(void))
					{
						ilGenerator.Emit(OpCodes.Ldstr, "Unauthorized");
						ilGenerator.Emit(OpCodes.Newobj, typeof(UnauthorizedAccessException).GetConstructor(new[] { typeof(string) }));
						ilGenerator.Emit(OpCodes.Throw);
					}
					else
					{
						ilGenerator.Emit(OpCodes.Ret);
					}

					// Mark the label where the method body starts
					ilGenerator.MarkLabel(permissionCheckLabel);
				}

				// Load 'this' onto the evaluation stack
				ilGenerator.Emit(OpCodes.Ldarg_0);
				ilGenerator.Emit(OpCodes.Ldfld, targetField);

				// Load method arguments onto the evaluation stack
				for (int i = 0; i < parameterTypes.Length; i++)
				{
					ilGenerator.Emit(OpCodes.Ldarg, i + 1);
				}

				// Load the target object from the field and call the method
				ilGenerator.Emit(OpCodes.Call, method);

				// Return the result (if method has a return value)
				if (method.ReturnType != typeof(void))
				{
					ilGenerator.Emit(OpCodes.Ret);
				}
				else
				{
					ilGenerator.Emit(OpCodes.Ret);
				}

				// Define method override
				typeBuilder.DefineMethodOverride(methodBuilder, method);
			}

			var proxyType = typeBuilder.CreateTypeInfo();

			// 检查构造函数是否正确生成
			var constructors = proxyType.DeclaredConstructors;
			foreach (var constructor in constructors)
			{
				Console.WriteLine(constructor);
			}

			// Determine the constructor parameters
			var constructorsList = proxyType.GetConstructors();
			var constructorParams = constructorsList[0].GetParameters();
			object[] constructorArguments;

			if (constructorParams.Length > 0)
			{
				constructorArguments = new object[constructorParams.Length];
				for (int i = 0; i < constructorParams.Length; i++)
				{
					var paramType = constructorParams[i].ParameterType;
					constructorArguments[i] = containerProvider.GetInstance(paramType) ;
				}
			}
			else
			{
				constructorArguments = Array.Empty<object>();
			}

			// Create an instance of the proxy type
			var proxyInstance = constructorsList[0].Invoke(constructorArguments);

			// Ensure that the target instance is set if not null
			if (target != null)
			{
				var targetFieldInfo = proxyType.GetField("_target", BindingFlags.NonPublic | BindingFlags.Instance);
				containerProvider.Rigister(target);
				targetFieldInfo.SetValue(proxyInstance, containerProvider.GetInstance(target));
			}

			return proxyInstance;
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
					containerProvider.Rigister(item, obj);
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
