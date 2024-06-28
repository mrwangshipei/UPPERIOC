using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpperComAutoTest.Entry;

namespace UpperComAutoTest.Extend
{
	public static  class StaticExtend
	{
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

		public static string ByteDataToStr(this ByteMessage msgs, bool x16 = true, bool Timestamp = false)
		{
			StringBuilder sb = new StringBuilder();
			
				ByteMessage bts = msgs;
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
