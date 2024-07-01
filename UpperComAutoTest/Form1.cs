
using UpperComAutoTest.MyControls;
using UpperComAutoTest.MyControls.Center;
using UpperComAutoTest.View.Page.Interface;

namespace UpperComAutoTest
{
    public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
            foreach (ToolStripItem item in toolStrip1.Items)
            {
				item.Click += Open;
            }
        }

	

		/// <summary>
		/// 降低界面耦合，方便团队开发-
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Open(object sender, EventArgs e)
		{
			Loading.ShowForm(this, (loa) => {
				Thread.Sleep(1000);
				loa.SetMessage("加载10", 10);
				Thread.Sleep(1000);
				loa.SetMessage("加载20", 20);
				Thread.Sleep(1000);
				loa.SetMessage("加载30", 30);
				Thread.Sleep(1000);
				loa.SetMessage("加载40", 40);
				Thread.Sleep(1000);
				loa.SetMessage("加载50", 50);
				Thread.Sleep(1000);
				loa.SetMessage("加载60", 60);
				for (int i = 0; i < 40; i++)
				{

					Thread.Sleep(100);
					loa.SetMessage("加载"+ (60+ i), (60 + i));
				}
				loa.SetMessage("加载100", 100);
				Thread.Sleep(1000);

			});
			ToolStripItem send = sender as ToolStripItem;
			IPage page;
			if ((page = PageCenter.GetPage(send.Name)) != null)
			{
				panel1.Controls.Clear();
				panel1.Controls.Add(page);

			}
		}
	}
}
