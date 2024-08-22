
using UpperComAutoTest.MyControls;
using UPPERIOC;
using UPPERIOC.UPPER.IOC.Moudle;
using UPPERIOC.UPPER.Sendor.Moudle;
using UPPERIOC.UPPER.UFILELOG.Moudle;
using UPPERIOC2.UPPER.Premission.Moudle;
using UPPERIOC2.UPPER.UFileModel.Moudle;
using UPPERIOC2.UPPER.UIOC.DefaultProvider;

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
			config.AddMoudle<UPPERMLockMoudle>();
			config.AddMoudle<UPPERPremissionMoudle>();
			config.AddMoudle<UPPERFileModelMoudle>();
			config.SetProvider<UPPerContainerProvider>();
			UPPERIOCApplication.RunInstance(config);
			Application.Run(new Form1());
		}


	}
}