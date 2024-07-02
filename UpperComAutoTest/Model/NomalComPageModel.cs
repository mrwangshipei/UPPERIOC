using FCT;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPPERIOC.UPPER.IOC.Annaiation;

namespace UpperComAutoTest.Model
{
	[IOCObject]
	public  class NomalComPageModel 
	{
        public bool Timestamp { get; set; }
        public bool Send16x { get; set; }
        public bool Receve16x { get; set; }
		private string[] pn;
		public string[] PortName { get => pn; set =>  pn= value; }

		private string[] btv;

		public string[] Btv
		{
			get { return btv; }
			set { btv = value; }
		}

		private CurrentSerialPort ser;
		public CurrentSerialPort SerialPort { get => ser;
			set
			{
				 ser= value;


			} 
		}

		public string[] DataBits { get; internal set; }
		public bool Blackback { get; internal set; }
		public string SendMsg { get; internal set; }

		public NomalComPageModel() {
			DataBits = new string[]{  "5", "6", "7", "8" };
			PortName = System.IO.Ports.SerialPort.GetPortNames();
			 Btv = new string[]
			{
	"300",
	"600",
	"1200",
	"2400",
	"4800",
	"9600",
	"14400",
	"19200",
	"38400",
	"57600",
	"115200",
	"230400",
	"460800",
	"921600"
			};
			ser = new CurrentSerialPort();
		}

		
	}
}
