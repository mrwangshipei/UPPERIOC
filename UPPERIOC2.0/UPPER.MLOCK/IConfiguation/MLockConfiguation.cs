using System;
using System.Collections.Generic;
using System.Text;

namespace UPPERIOC2.UPPER.MLOCK.IConfiguation
{
	public class MLockConfiguation
	{
        public virtual string Solt { get; set; }
        public virtual string Listenaddr { get; set; }
        public virtual void Noregister() {
            Console.Write("没有注册");
            Environment.Exit(0);
        }
    }
}
