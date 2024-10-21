using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPPERIOC2.UPPER.EmailErrorSender
{
	public interface IErrorConfiguation
	{
		string SenderEmail { get; }
		string ReceiveEmail { get; }
		string SMPTServer { get; }
		string SenderPWD { get; }
		int SMPTPort { get; }
		string SenderUserName { get; }
	}
}
