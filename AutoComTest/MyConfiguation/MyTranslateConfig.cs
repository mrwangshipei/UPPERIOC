using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPPERIOC.UPPER.IOC.Annaiation;
using UPPERIOC2.UPPER.Util.IConfiguation;

namespace AutoComTest.MyConfiguation
{
	[IOCObject]
	public class MyTranslateConfig : ITranslateConfig
	{
		public string APPKey => "46731e6c4dd6e7e4";


		public string APPSeret => "uW0gp5TFsNw6OTZxnxyFeXEu12xhNuHb";

		public string FromLanguage { get => "zh-CHS";  }
		public string ToLanguage { get => "en";  }
	}
}
