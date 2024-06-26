
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using UpperComAutoTest.Model;

namespace UpperComAutoTest.ModelView
{
	public  class NomalComPageViewModel
	{
		public NomalComPageModel m;

		
		public NomalComPageModel NomalModel { get => m; set =>  m= value; }
	
		public NomalComPageViewModel() {
			// 初始化命令和其他属性  
		
		
		}

		
	}
}
