using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPPERIOC2.UPPER.Util
{
	public class MutiPageUtil
	{
		public static MutiPageUtil I = new MutiPageUtil();
		List<IPage> Pages = new List<IPage>();
		public IPage CurrentPage ;
		public void AddPage(IPage pa)
		{
			Pages.Add(pa);
		}

		public void ChangeCurrentPage(string pa) 
		{
			if (CurrentPage == null)
			{
				CurrentPage = Pages.Find(i=>i.PageName == pa);
			}
			else
			{
				CurrentPage.ToBack();
			}
			if (pa == null)
			{
				CurrentPage?.ToBack();
			}
			Pages.Find(i => i.PageName == pa).ToFront();
		}
	}
	public interface IPage 
	{
		string PageName { get; }
		void ToFront();
		void ToBack();
	}
}

