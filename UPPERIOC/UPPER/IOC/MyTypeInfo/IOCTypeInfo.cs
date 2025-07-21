using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPPERIOC.UPPER.IOC.MyTypeInfo
{
    public class IOCTypeInfo
    {
        public Type Type { get; set; }
        public Type BaseType { get; set; }
		public bool SingleBean { get; set; } = true;
        public string TypeName { get; set; }

		public override bool Equals(object obj)
		{
			return obj is IOCTypeInfo info &&
				   EqualityComparer<Type>.Default.Equals(Type, info.Type) &&
				   TypeName == info.TypeName;
		}

		public override int GetHashCode()
		{
			int hashCode = -1262880317;
			hashCode = hashCode * -1521134295 + (Type).GetHashCode();
			hashCode = hashCode * -1521134295 + (TypeName).GetHashCode();
			if (BaseType != null)
			{
				hashCode = hashCode * -1521134295 + (BaseType).GetHashCode();
			}
			return hashCode;
		}
	}
}
