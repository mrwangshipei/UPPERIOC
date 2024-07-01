using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UpperComAutoTest.Entry;

namespace UpperComAutoTest.Extend
{
	public static  class StaticExtend
	{
		public static readonly char[] HexChars = new char[]
	   {
			'0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
			'A', 'B', 'C', 'D', 'E', 'F'
	   };
		public static byte[] ToBitArray(this string msgs,bool failthrow = true) {
			List<byte> bts = new List<byte>();
			msgs = msgs.ToUpper();
			string temp = "";
			for (int i = 0; i < msgs.Length; i++)
			{
				if (HexChars.Contains(msgs[i]))
				{
					temp += msgs[i];
				}
				else
				{
					if (byte.TryParse(temp, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out byte value1))
					{
						bts.Add(value1);
						temp = "";
					}
					else
					{
						if (failthrow)
						{
							throw new Exception("识别失败");

						}
					}
				}
			}

			if (byte.TryParse(temp, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out byte value))
			{
				bts.Add(value);
				temp = "";
			}
			else
			{
			
			}
			return bts.ToArray();
		}

		public static string ListByteDataToStr(this List<ByteMessage> msgs,bool x16 = true,bool Timestamp = false)
		{
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < msgs.Count; i++)
			{
				ByteMessage bts = msgs[i];
				if (Timestamp)
				{
					sb.Append(bts.Time.ToLongDateString() + " :");
				}
				if (x16)
				{
					sb.Append(string.Join(" ",bts.Data));
				}
				else
				{
					sb.Append(Encoding.Default.GetString(bts.Data));
				}
				if (Timestamp)
				{
					sb.Append("\n");
				}

			}
			return sb.ToString();
        }

		public static string ByteDataToStr(this ByteMessage msgs, bool x16 = true, bool Timestamp = false, bool receve = true)
		{
			StringBuilder sb = new StringBuilder();
			
				ByteMessage bts = msgs;
			
			if (receve)
			{
				sb.Append("Receive ");
			}
			else
			{
				sb.Append("Send ");

			}
			if (Timestamp)
			{
				sb.Append(bts.Time.ToLongDateString() + " :");
			}
			if (x16)
				{
					sb.Append(string.Join(" ", bts.Data));
				}
				else
				{
					sb.Append(Encoding.Default.GetString(bts.Data));
				}
				if (Timestamp)
				{
					sb.Append("\n");
				}

			
			return sb.ToString();
		}
	}
}
