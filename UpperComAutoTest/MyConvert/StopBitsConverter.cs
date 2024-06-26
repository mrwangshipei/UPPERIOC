//using ReactiveUI;
//using System;
//using System.Globalization;
//using System.IO.Ports;

//public class StopBitsConverter : IBindingTypeConverter
//{
//	public int GetAffinityForObjects(Type fromType, Type toType)
//	{
//		if (fromType == typeof(string) && toType == typeof(StopBits) ||
//			fromType == typeof(StopBits) && toType == typeof(string))
//		{
//			return 10; // 返回大于0的值表示我们支持这个转换
//		}
//		return 0;
//	}

//	public bool TryConvert(object from, Type toType, object conversionHint, out object result)
//	{
//		if (from is string stopBitsString && toType == typeof(StopBits))
//		{
//			if (Enum.TryParse(stopBitsString, out StopBits stopBits))
//			{
//				result = stopBits;
//				return true;
//			}
//		}
//		else if (from is StopBits stopBits && toType == typeof(string))
//		{
//			result = stopBits.ToString();
//			return true;
//		}

//		result = null;
//		return false;
//	}
//}
