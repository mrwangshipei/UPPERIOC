using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPPER.Test.ApplicationEventTests;
using UPPERIOC;
using UPPERIOC.UPPER.IOC.Center.Interface;
using UPPERTest.Util;
using Xunit;

namespace UPPERTest
{
    namespace Sub {
        public class ModuleA : IUPPERModule
        {
            public override Type[] Dependencies => new Type[]
            {
              typeof(ModuleB)
            };
        }

        public class ModuleB : IUPPERModule
        {
            public override Type[] Dependencies => new Type[]
            {
               typeof(ModuleC)
            };
        }

        public class ModuleC : IUPPERModule
        {
            public override Type[] Dependencies => new Type[]
            {
                typeof(ModuleA)
            };
        }
        public class ModuleTests {
            [Fact]
            public void TestModuleLifecycle()
            {
                FileTempFile f = new FileTempFile();
                var assemblyPath = typeof(ProgramML).Assembly.Location;
                assemblyPath = assemblyPath.Replace(".dll", ".exe");
                //传入f._tempFile到程序中应该如何传;
                var process = Process.Start(new ProcessStartInfo
                {
                    FileName = assemblyPath,
                    Arguments = $"\"{f._tempFile}\"",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                });

                process.WaitForExit();

                Assert.True(File.Exists(f._tempFile), "ProcessExit 未触发或未生成文件");
                Assert.Equal(File.ReadAllText(f._tempFile), "ok");
            }
            [Fact]
            public void DetectsTripleCircularDependency()
            {
                string exm = "";
                try
                {
                    UPPERIOCApplication.RunInstance(md => {
                        md.AddModule<ModuleA>();
                        md.AddModule<ModuleB>();
                        md.AddModule<ModuleC>();
                    });
                }
                catch (Exception ex)
                {
                    exm = ex.Message;
                }
                Assert.Contains("存在循环依赖", exm);
            }
        }
    }
    public class ModuleTests
    {
        public class ModuleA : IUPPERModule
        {
            public override Type[] Dependencies => new Type[]
            {
              typeof(ModuleB)
            };
        }

        public class ModuleB : IUPPERModule
        {
            public override Type[] Dependencies => new Type[]
            {
              typeof(ModuleA)
            };
        }

        [Fact]
        public void DetectsCircularDependency() {
            string exm = "";
            try
            {
                UPPERIOCApplication.RunInstance(md => {
                    md.AddModule<ModuleA>();
                    md.AddModule<ModuleB>();
                });
            }
            catch (Exception ex)
            {
                exm = ex.Message;
            }
            Assert.Contains("存在循环依赖", exm);
        }
        
    }
}
