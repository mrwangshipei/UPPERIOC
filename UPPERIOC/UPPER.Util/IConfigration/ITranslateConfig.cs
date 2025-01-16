using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPPERIOC2.UPPER.Util.IConfiguation
{
	public  interface ITranslateConfig
	{
        string APPKey { get; }
        string APPSeret { get; }
        string FromLanguage { get;  }
        string ToLanguage { get;  }
    }
}
