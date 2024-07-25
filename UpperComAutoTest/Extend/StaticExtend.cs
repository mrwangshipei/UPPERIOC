using System;
using System.Collections.Concurrent;
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
		public static string ByteArrayToHex(this byte[] ba,string split)
		{
			StringBuilder hex = new StringBuilder(ba.Length * 2);
			int i = 0;
			foreach (byte b in ba)
			{
				if (i != 0)
				{

					hex.Append(split);
				}
				hex.AppendFormat("{0:x2}", b);
			    i++;
			}
			return hex.ToString();
		}
			public static string ListByteDataToStr(this ConcurrentQueue<ByteMessage> msgs,bool x16 = true,bool Timestamp = false)
		{
			StringBuilder sb = new StringBuilder();
			foreach (var bts in msgs)
			{
				if (bts.IsSend)
				{
					sb.Append("Send ");
				}
				else
				{
					sb.Append("Receive ");

				}
				if (Timestamp)
				{
					sb.Append(bts.Time.ToLongDateString() );
				}
				sb.Append(" :");

				if (x16)
				{
					sb.Append(bts.Data.ByteArrayToHex(" "));
				}
				else
				{
					sb.Append(Encoding.Default.GetString(bts.Data));
				}
				if (Timestamp)
				{
				}
				sb.Append("\n");

			}
			return sb.ToString();
        }

		public static string ByteDataToStr(this ByteMessage msgs, bool x16 = true, bool Timestamp = false, bool receve = true)
		{
			StringBuilder sb = new StringBuilder();
			
				ByteMessage bts = msgs;
			
			if (bts.IsSend)
			{
				sb.Append("Send ");
			}
			else
			{
				sb.Append("Receive ");

			}
			if (Timestamp)
			{
				sb.Append(bts.Time.ToLongDateString() );
			}
			sb.Append(" :");

			if (x16)
				{
					sb.Append( bts.Data.ByteArrayToHex(" "));
				}
				else
				{
					sb.Append(Encoding.Default.GetString(bts.Data));
				}
				if (Timestamp)
				{
				}

					sb.Append("\n");
			
			return sb.ToString();
		}
	}
}
