using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPPERIOC.UPPER.IOC.Annaiation;
using UPPERIOC2.UPPER.UFileModel.IConfiguaion;

namespace UpperComAutoTest.MyConfiguation
{
	[IOCObject]
	internal class FileMoudleConfiguation : IUFileModelConfiguation
	{
		public string SaveModelPath { get => "Model"; set => throw new NotImplementedException(); }
	}
}
