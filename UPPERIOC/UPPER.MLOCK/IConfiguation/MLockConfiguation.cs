using System;
using System.Collections.Generic;
using System.Text;
using UPPERIOC2.UPPER.Util;

namespace UPPERIOC2.UPPER.MLOCK.IConfiguation
{
	public class MLockConfiguation
	{
        public virtual string Solt { get; set; }
        public virtual string Listenaddr { get; set; }
        public virtual string LockName { get; set; }
        public virtual void Noregister() {
            Console.Write("没有注册");
            Environment.Exit(0);
        }
        protected virtual void Register() {
            RigisterConsole.Rigister(this);
        }
    }
}
