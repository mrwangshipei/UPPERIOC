using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPPERIOC.UPPER.IOC.MyTypeInfo
{
    public class UpperTypeInfo
    {
        public Type Type { get; set; }
        public string TypeName { get; set; }

		public override bool Equals(object obj)
		{
			return obj is UpperTypeInfo info &&
				   EqualityComparer<Type>.Default.Equals(Type, info.Type) &&
				   TypeName == info.TypeName;
		}

		public override int GetHashCode()
		{
			int hashCode = -1262880317;
			hashCode = hashCode * -1521134295 + EqualityComparer<Type>.Default.GetHashCode(Type);
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(TypeName);
			return hashCode;
		}
	}
}
