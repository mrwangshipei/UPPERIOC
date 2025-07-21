using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using UPPERIOC;
using UPPERIOC.UPPER.Event.AppEvent.Impl;
using UPPERIOC.UPPER.IOC.Center.Configuation;
using UPPERIOC2.UPPER.MLOCK.IConfiguation;
using UPPERIOC2.UPPER.UIOC.Center;
using Xunit;

namespace UPPERTest
{
    public class MLockTest
    {
        public class MLock:MLockConfiguation
        {
            public bool isre = true;
            public override string Solt { get; set; } = "UPPERIOC";
            public override string Listenaddr { get; set; } = "addr";
            public override string LockName { get; set; } = "xxx";
            public override void Noregister()
            {
                Console.Write("没有注册");
                isre = false;
            }
        }
        [Fact]
        public void MLockisok()
        {
            MLock m = new MLock();
            m.UnloadRegister();
            UPPERIOCApplication.RunInstance(md => {
                
                md.UPPERMLockMoudle(new MLock());
            });
            var mm = U.C.GetInstance<MLock>();
            Assert.Equal(false, mm.isre);
        }
        public class UnMLock : MLockConfiguation
        {
            public bool isre = false;
            public override string Solt { get; set; } = "UPPERIOC";
            public override string Listenaddr { get; set; } = "addr";
            public override string LockName { get; set; } = "xxx";
            public override void Noregister()
            {
                Console.Write("注册中");//模拟注册操作
                Register();
                isre = false;
            }
            protected override void Register()
            {
                base.Register();
                isre = true;
            }
        }
        [Fact]
        public void UnMLockisOk()
        {
            UPPERIOCApplication.RunInstance(md => {
                var xx = new MLock();
                md.UPPERMLockMoudle(xx);
                xx.UnloadRegister();

            });
            { 
                var mm = U.C.GetInstance<MLock>();
                Assert.Equal(false, mm.isre);
            }
            UnMLock m = new UnMLock();
            UPPERIOCApplication.RunInstance(md => {
                md.UPPERMLockMoudle(m);
            });
            UPPERIOCApplication.RunInstance(md => {
                md.UPPERMLockMoudle(new MLock());
            });
            { 
                var mm = U.C.GetInstance<MLock>();
                Assert.Equal(true, mm.isre);
                m.UnloadRegister();
            }

        }
    }
}
