
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
		/// ���ͽ�����ϣ������Ŷӿ���-
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Open(object sender, EventArgs e)
		{
			Loading.ShowForm(this, (loa) => {
				Thread.Sleep(1000);
				loa.SetMessage("����10", 10);
				Thread.Sleep(1000);
				loa.SetMessage("����20", 20);
				Thread.Sleep(1000);
				loa.SetMessage("����30", 30);
				Thread.Sleep(1000);
				loa.SetMessage("����40", 40);
				Thread.Sleep(1000);
				loa.SetMessage("����50", 50);
				Thread.Sleep(1000);
				loa.SetMessage("����60", 60);
				for (int i = 0; i < 40; i++)
				{

					Thread.Sleep(100);
					loa.SetMessage("����"+ (60+ i), (60 + i));
				}
				loa.SetMessage("����100", 100);
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
