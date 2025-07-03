using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPPERIOC;
using UPPERIOC.UPPER.IOC.Center.Configuation;
using UPPERIOC2.UPPER.UFileModel.Center;
using UPPERIOC2.UPPER.UFileModel.IConfiguaion;
using UPPERIOC2.UPPER.UFileModel.Model;
using Xunit;

namespace UPPERTest
{
    public class UModelTests
    {
        public class FileModle : IUFileModelConfiguation
        {
            public string SaveModelPath { get =>"MOD"; set => throw new NotImplementedException(); }
        }
        [Fact]
        public void UModelTest() {
            UPPERIOCApplication.RunInstance(x => {
                x.UPPERFileModelMoudle(new FileModle());
            });
            var x = new XModel();
            x.xx = "123";
            F.I.SaveModel(x);
            var y = F.I.GetModel(x);
            Assert.NotEqual(x, y);
            Assert.Equal("123", y.xx);
            Assert.Equal("123", x.xx);
        }

        public class XModel : IModel
        {
            public override string ModelName { get { return "xmod.txt"; } set { } }
            public string xx { get; set; }
        }
    }
}
