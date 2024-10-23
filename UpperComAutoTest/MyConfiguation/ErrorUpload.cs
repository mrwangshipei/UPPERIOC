using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPPERIOC.UPPER.IOC.Annaiation;
using UPPERIOC2.UPPER.EmailErrorSender;

namespace UpperComAutoTest.MyConfiguation
{
	[IOCObject]
	public class ErrorUpload : IErrorConfiguation
	{
		public string SenderEmail => "13144874915@163.com";

		public string ReceiveEmail => "13712775799@163.com";

		public string SMPTServer => "smtp.163.com";

		public string SenderPWD => "HXi8gPV8gdeaPrKn";

		public int SMPTPort =>25;

	}
}
