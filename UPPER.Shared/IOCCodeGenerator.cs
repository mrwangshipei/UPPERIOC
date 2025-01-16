
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

    public void Execute(GeneratorExecutionContext context)
    {
           
        // 获取语法接收器
        if (context.SyntaxReceiver is not SyntaxReceiver receiver)
            return;

        // 收集类和命名空间
        var iocClasses = new List<(string ClassName, string Namespace)>();
        foreach (var classDecl in receiver.CandidateClasses)
        {
            // 获取类所在命名空间
          /*  var namespaceDecl = classDecl.Ancestors()
                .OfType<NamespaceDeclarationSyntax>()
                .FirstOrDefault();
            var namespaceName = namespaceDecl?.Name.ToString() ?? string.Empty;
          */      var namespaceDecl = classDecl.Ancestors()
           .OfType<BaseNamespaceDeclarationSyntax>()
            .FirstOrDefault();
            var namespaceName = namespaceDecl?.Name.ToString() ?? "GlobalNamespace";

            // 添加到列表
            iocClasses.Add((classDecl.Identifier.Text, namespaceName));
        }
        // 生成代码
        var generatedCode = GenerateRegistrationCode(iocClasses);

        // 将代码添加到生成结果中
        context.AddSource("IOCGeneratedRegistration.g.cs", generatedCode);
    }

    private static string GenerateRegistrationCode(List<(string ClassName, string Namespace)> classInfo)
    {
        var builder = new StringBuilder();

        // 生成命名空间和注册代码
        builder.AppendLine("using System;");
        builder.AppendLine("using UPPERIOC.UPPER.IOC.Center.IProvider;");
        builder.AppendLine("");
        builder.AppendLine("namespace UPPER.Generated");
        builder.AppendLine("{");
        builder.AppendLine("    public static class IOCGeneratedRegistration");
        builder.AppendLine("    {");
        builder.AppendLine("        public static void RegisterAll(this IContainerProvider container)");
        builder.AppendLine("        {");
            int i = 0;
        foreach (var (className, namespaceName) in classInfo)
        {
                i++;
            builder.AppendLine($"            var type{i} = Type.GetType(\"{namespaceName}.{className}\");");
            builder.AppendLine($"            container.Rigister(type{i} );");
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

            public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
            {
                
                // 判断是否是类声明
                if (syntaxNode is ClassDeclarationSyntax classDecl)
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
        }

        }
    }