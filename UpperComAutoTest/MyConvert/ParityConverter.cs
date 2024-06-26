//using ReactiveUI;
//using System;
//using System.Globalization;
//using System.IO.Ports;

//public class ParityConverter : IBindingTypeConverter
//{
//	public int GetAffinityForObjects(Type fromType, Type toType)
//	{
//		if (fromType == typeof(string) && toType == typeof(Parity) ||
//			fromType == typeof(Parity) && toType == typeof(string))
//		{
//			return 10; // 返回大于0的值表示我们支持这个转换
//		}
//		return 0;
//	}

//	public bool TryConvert(object from, Type toType, object conversionHint, out object result)
//	{
//		if (from is string parityString && toType == typeof(Parity))
//		{
//			if (Enum.TryParse(parityString, out Parity parity))
//			{
//				result = parity;
//				return true;
//			}
//		}
//		else if (from is Parity parity && toType == typeof(string))
//		{
//			result = parity.ToString();
//			return true;
//		}

//		result = null;
//		return false;
//	}
//}
