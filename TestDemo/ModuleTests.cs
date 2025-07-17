using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPPERIOC;
using UPPERIOC.UPPER.IOC.Center.Interface;
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
