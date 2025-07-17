using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UPPERIOC;
using UPPERIOC.UPPER.Translate.IConfigration;

namespace UPPERIOC2.UPPER.Util
{
	public class TranslateUtil
	{
		public static string ExtractTranslation(string json,string key1)
		{
			if (string.IsNullOrWhiteSpace(json))
			{
				throw new ArgumentException("JSON cannot be null or empty", nameof(json));
			}

		    string key = "\"" + key1+"\"";
			int keyIndex = json.IndexOf(key, StringComparison.Ordinal);

			if (keyIndex == -1)
			{
				return "";
			}

			// Find the start of the value after the key
			int startIndex = json.IndexOf(':', keyIndex) + 1;

			// Ensure valid value extraction
			if (startIndex == 0)
			{
				return "";
			}

			// Handle nested braces or direct strings
			int braceCount = 0;
			int endIndex = startIndex;
			bool inQuotes = false;

			for (int i = startIndex; i < json.Length; i++)
			{
				char currentChar = json[i];

				if (currentChar == '"' && (i == 0 || json[i - 1] != '\\'))
				{
					inQuotes = !inQuotes;
				}

				if (!inQuotes)
				{
					if (currentChar == '{')
					{
						braceCount++;
					}
					else if (currentChar == '}')
					{
						braceCount--;
					}

					if (braceCount == 0 && (currentChar == '}' || currentChar == ','))
					{
						endIndex = i + 1;
						break;
					}
				}
			}
			string result = json.Substring(startIndex, endIndex - startIndex).Trim();

			// Return the result, or a message if no valid value was found
			return string.IsNullOrEmpty(result) ? "" : result.Replace("[", "").Replace("\"", "").Replace("\"", "").Replace("]", "").Replace(",", "");

		}
		static object tl  = new object();
		public static string Transcale(string q)
		{
			var cof = UPPERIOCApplication.Container.GetInstanceAndSub<ITranslateConfig>();
			if (cof == null)
			{
				return q;
			}
            if (cof.FromLanguage == cof.ToLanguage)
            {
                return q;
            }
            lock (tl)
			{
				Dictionary<String, String> dic = new Dictionary<string, string>();
				string url = "https://openapi.youdao.com/api";
				string appKey = cof.APPKey;
				string appSecret = cof.APPSeret;
				string salt = DateTime.Now.Millisecond.ToString();
				
				dic.Add("from", cof.FromLanguage);
				dic.Add("to", cof.ToLanguage);
				dic.Add("signType", "v3");
				TimeSpan ts = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc));
				long millis = (long)ts.TotalMilliseconds;
				string curtime = Convert.ToString(millis / 1000);
				dic.Add("curtime", curtime);
				string signStr = appKey + Truncate(q) + salt + curtime + appSecret; ;
				string sign = ComputeHash(signStr, new SHA256CryptoServiceProvider());
				dic.Add("q", UrlEncode(q));
				dic.Add("appKey", appKey);
				dic.Add("salt", salt);
				dic.Add("sign", sign);
				dic.Add("vocabId", "您的用户词表ID");
				string re = Post(url, dic);
				Thread.Sleep(1000);
				Console.WriteLine(re);
				return	ExtractTranslation(re, "translation");
			}
		}
		public static string UrlEncode(string value)
		{
			if (string.IsNullOrEmpty(value))
			{
				return string.Empty;
			}

			StringBuilder encoded = new StringBuilder();
			foreach (char c in value)
			{
				if (IsSafe(c))
				{
					encoded.Append(c);
				}
				else
				{
					// Convert character to its hexadecimal representation
					encoded.Append($"%{(int)c:X2}");
				}
			}
			return encoded.ToString();
		}

		private static bool IsSafe(char c)
		{
			// Safe characters as per URL encoding rules
			return char.IsLetterOrDigit(c) || "-_.~".IndexOf(c) >= 0;
		}

		protected static string ComputeHash(string input, HashAlgorithm algorithm)
		{
			Byte[] inputBytes = Encoding.UTF8.GetBytes(input);
			Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);
			return BitConverter.ToString(hashedBytes).Replace("-", "");
		}
		protected static string Post(string url, Dictionary<String, String> dic)
		{
			string result = "";
			HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
			req.Method = "POST";
			req.ContentType = "application/x-www-form-urlencoded";
			StringBuilder builder = new StringBuilder();
			int i = 0;
			foreach (var item in dic)
			{
				if (i > 0)
					builder.Append("&");
				builder.AppendFormat("{0}={1}", item.Key, item.Value);
				i++;
			}
			byte[] data = Encoding.UTF8.GetBytes(builder.ToString());
			req.ContentLength = data.Length;
			using (Stream reqStream = req.GetRequestStream())
			{
				reqStream.Write(data, 0, data.Length);
				reqStream.Close();
			}
			HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
			if (resp.ContentType.ToLower().Equals("audio/mp3"))
			{
				SaveBinaryFile(resp, "合成的音频存储路径");
			}
			else
			{
				Stream stream = resp.GetResponseStream();
				using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
				{
					result = reader.ReadToEnd();
				}
				return (result);
			}
			return null;
		}

		protected static string Truncate(string q)
		{
			if (q == null)
			{
				return null;
			}
			int len = q.Length;
			return len <= 20 ? q : (q.Substring(0, 10) + len + q.Substring(len - 10, 10));
		}

		private static bool SaveBinaryFile(WebResponse response, string FileName)
		{
			string FilePath = FileName + DateTime.Now.Millisecond.ToString() + ".mp3";
			bool Value = true;
			byte[] buffer = new byte[1024];

			try
			{
				if (File.Exists(FilePath))
					File.Delete(FilePath);
				Stream outStream = System.IO.File.Create(FilePath);
				Stream inStream = response.GetResponseStream();

				int l;
				do
				{
					l = inStream.Read(buffer, 0, buffer.Length);
					if (l > 0)
						outStream.Write(buffer, 0, l);
				}
				while (l > 0);

				outStream.Close();
				inStream.Close();
			}
			catch
			{
				Value = false;
			}
			return Value;
		}
	}
}
