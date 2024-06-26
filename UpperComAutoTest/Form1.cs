
using UpperComAutoTest.View.Page.Center;
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
