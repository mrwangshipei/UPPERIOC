
using UpperComAutoTest.MyControls;
using UPPERIOC.UPPER.IOC.Moudle;
using UPPERIOC.UPPER.IOC.Provider;
using UPPERIOC.UPPER.Sendor.Model;
using UPPERIOC.UPPERIOCCenter;

namespace UpperComAutoTest
{
    internal static class Program
	{
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{

			// To customize application configuration such as set high DPI settings or default font,
			// see https://aka.ms/applicationconfiguration.
			ApplicationConfiguration.Initialize();
			var config = new UPPERIOC.UPPER.IOC.Center.Configuation.MoudleConfiguaion();
			config.AddMoudle<UPPERIOCMoudle>();
			config.AddMoudle<UPPERLogFileMoudle>();
			config.AddMoudle<UPPERSendorMoudle>();
			config.SetProvider<UPPerContainerProvider>();
			UPPERIOCContain.RunInstance(config);
			Application.Run(new Form1());
		}


	}
}