
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
namespace UPPERIOC.Generators
{ 
[Generator]
public class IOCCodeGenerator : ISourceGenerator
{
    public void Initialize(GeneratorInitializationContext context)
    {
        // 注册语法接收器
        context.RegisterForSyntaxNotifications(() => new SyntaxReceiver());
          
        }

        private (string Namespace, string ParentName) GetNamespaceAndParent(ClassDeclarationSyntax classDecl)
        {
            var namespaceDecl = classDecl.Ancestors().OfType<BaseNamespaceDeclarationSyntax>().FirstOrDefault();
            var namespaceName = namespaceDecl?.Name.ToString() ?? "GlobalNamespace";

            var parent = classDecl.BaseList?.Types.FirstOrDefault()?.Type.ToString() ?? string.Empty;
            return (namespaceName, parent);
        }

        public void Execute(GeneratorExecutionContext context)
        {
           
            if (context.SyntaxReceiver is not SyntaxReceiver receiver)
                return;

            var iocClasses = receiver.CandidateClasses
                .Select(classDecl =>
                {
                    var (namespaceName, parentName) = GetNamespaceAndParent(classDecl);
                    return (classDecl.Identifier.Text, parentName, namespaceName);
                }).ToList();

            var listenerClasses = receiver.ListenerClasses
                .Select(classDecl =>
                {
                    var (namespaceName, parentName) = GetNamespaceAndParent(classDecl);
                    return (classDecl.Identifier.Text, parentName, namespaceName);
                }).ToList();

            var generatedCode = GenerateRegistrationCode(iocClasses, listenerClasses);
            context.AddSource("IOCGeneratedRegistration.g.cs", generatedCode);
           var generatedCodem = GenerateMClass(context);
          //  context.AddSource("M.g.cs", generatedCodem);

        }
        private static string GenerateMClass(GeneratorExecutionContext context)
        {
            var targetNamespace = "UPPERIOC.UPPER.IOC.Moudle";

            var moduleTypes = AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(asm =>
                {
                    try { return asm.GetTypes(); } catch { return Array.Empty<Type>(); }
                })
                .Where(t => t.IsClass && t.Namespace == targetNamespace)
                .ToList();

            var builder = new StringBuilder();
            builder.AppendLine("using System;");
            builder.AppendLine($"using {targetNamespace};");
            builder.AppendLine("");
            builder.AppendLine("namespace UPPER.Generated");
            builder.AppendLine("{");
            builder.AppendLine("    public class M");
            builder.AppendLine("    {");
            StringBuilder debugInfo = new StringBuilder();
            foreach (var type in moduleTypes)
            {
                try
                {
                    var fieldName = SanitizeName(type);
                    var typeName = GetTypeofExpression(type);

                    builder.AppendLine($"        public Type {fieldName} = typeof({typeName});");
                    debugInfo.Append($"//类型: {type.FullName}, 是否泛型: {type.IsGenericType}");
                    debugInfo.Append($"//        public Type {fieldName} = typeof({typeName});");
                    if (type.IsGenericType)
                    {
                        foreach (var arg in type.GetGenericArguments())
                        {
                            debugInfo.Append($"// - 泛型参数: {arg.FullName}");
                        }
                    }

                }
                catch(Exception ex)
                {
                    // 可选日志记录
                    debugInfo.Append($"// err {ex.Message} ,type {type}");

                }
            }
            context.AddSource($"IOC_Debug_M.g.cs", debugInfo.ToString());
            builder.AppendLine("    }");
            builder.AppendLine("}");

            return builder.ToString();
        }

        private static string SanitizeName(Type type)
        {
            if (!type.IsGenericType)
                return type.Name;

            var baseName = type.Name.Split('`')[0];
            return baseName + "_Generic";
        }

        //private static string GetTypeofExpression(Type type)
        //{
        //    if (!type.IsGenericType)
        //        return type.FullName;

        //    var genericType = type.GetGenericTypeDefinition();
        //    var baseName = genericType.FullName!.Split('`')[0];
        //    var arity = genericType.GetGenericArguments().Length;
        //    return $"{baseName}`{arity}";
        //}
        private static string GetTypeofExpression(Type type)
        {
            if (!type.IsGenericType)
                return type.FullName!;

            var genericTypeDef = type.GetGenericTypeDefinition();
            var baseTypeName = genericTypeDef.FullName!.Split('`')[0];
            var genericArgs = type.GetGenericArguments();

            var argNames = string.Join(", ", genericArgs.Select(arg => arg.FullName));
            return $"{baseTypeName}<{argNames}>";
        }


        private static string GenerateRegistrationCode(List<(string ClassName, string ParentName,string Namespace)> classInfo, List<(string ClassName, string ParentName, string Namespace)> LisclassInfo)
    {
        var builder = new StringBuilder();

        // 生成命名空间和注册代码
        builder.AppendLine("using System;");
        builder.AppendLine("using UPPERIOC.UPPER.IOC.Center.IProvider;");
        builder.AppendLine("using UPPERIOC.UPPER.Event.AppEvent;");
        builder.AppendLine("");
            builder.AppendLine("namespace UPPER.Generated");
        builder.AppendLine("{");
        builder.AppendLine("    public static class IOCGeneratedRegistration");
        builder.AppendLine("    {");
//        builder.AppendLine("        public static void InitListener(this IContainerProvider container)");

        builder.AppendLine("        public static void RegisterAll(this IContainerProvider container)");
        builder.AppendLine("        {");
          
            int i = 0;
        foreach (var (className, ParentName, namespaceName) in classInfo)
        {
          
                i++;
            builder.AppendLine($"            var type{i} = Type.GetType(\"{namespaceName}.{className}\");");
            builder.AppendLine($"            container.Rigister(type{i},true);");
        }

        builder.AppendLine("        }");


            builder.AppendLine("        public static void RegisterListener(this ApplicationEventManager container)");
            builder.AppendLine("        {");
            foreach (var (className, ParentName, namespaceName) in LisclassInfo)
            {
    
                i++;
                builder.AppendLine($"            var type{i} = Type.GetType(\"{namespaceName}.{className}\");");
                builder.AppendLine($"            container.RegisterListener(type{i});");
            }

            builder.AppendLine("        }");
            builder.AppendLine("    }");
        builder.AppendLine("}");

        return builder.ToString();
    }

    /// <summary>
    /// 语法接收器，用于收集标记为 [IOCObject] 的类
    /// </summary>
    private class SyntaxReceiver : ISyntaxReceiver
    {
        public List<ClassDeclarationSyntax> CandidateClasses { get; } = new List<ClassDeclarationSyntax>();
        public List<ClassDeclarationSyntax> ListenerClasses { get; } = new List<ClassDeclarationSyntax>();

            public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
            {
                
                // 判断是否是类声明
                if (syntaxNode is ClassDeclarationSyntax classDecl)
                {
                    try
                    {
                        var txt = GetTopLevelInterfaceName(classDecl);
                        if (txt.Contains("IUPPERApplicationListener<") )
                        {
                            ListenerClasses.Add(classDecl);
                        }
                        else
                        {
                            // 遍历该类的所有属性列表
                            foreach (var attributeList in classDecl.AttributeLists)
                            {
                                foreach (var attribute in attributeList.Attributes)
                                {
                                    // 获取特性名称，剔除命名空间前缀
                                    var attributeName = attribute.Name.ToString();

                                    if (attributeName.EndsWith("IOCObject") || attributeName.Contains(".IOCObject"))
                                    {
                                
                                        CandidateClasses.Add(classDecl);
                                    }
                                }
                            }
                            
                        }
                    }
                    catch (Exception)
                    {
                        if (!Debugger.IsAttached)
                        {
                            Debugger.Launch();
                        }
                    }
                    ;
                }
            }

            private string GetTopLevelInterfaceName(ClassDeclarationSyntax classDecl)
            {
                // Extract the base list (interfaces implemented by the class)
                var baseList = classDecl.BaseList?.Types;
                if (baseList != null && baseList.HasValue)
                {
                    // Return the first base type name, assuming it's the top-level interface
                    return baseList.Value.First().Type.ToString();
                }

                return string.Empty; // No interfaces found
            }


        }

    }
    }