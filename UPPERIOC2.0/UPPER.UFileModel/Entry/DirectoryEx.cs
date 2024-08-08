using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Kernal
{
	#region 可序列化字典类 + public class DictionaryEx<TKey, TValue>
	/// <summary>
	/// 可序列化字典类
	/// </summary>
	/// <typeparam name="TKey">键泛型</typeparam>
	/// <typeparam name="TValue">值泛型</typeparam>
	[System.Serializable]
	public class DictionaryEx<TKey, TValue>
	  : Dictionary<TKey, TValue>, IXmlSerializable
	{
		#region 构造函数

		#region 默认构造函数 + public DictionaryEx()
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public DictionaryEx()
			: base()
		{

		}
		#endregion

		#region 构造函数 + public DictionaryEx(int capacity)
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="capacity">可包含的初始元素数</param>
		public DictionaryEx(int capacity)
			: base(capacity)
		{

		}
		#endregion

		#region 构造函数 + public DictionaryEx(IEqualityComparer<TKey> comparer)
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="comparer">比较键时要使用的 比较器 实现，或者为 null，以便为键类型使用默认的 比较器</param>
		public DictionaryEx(IEqualityComparer<TKey> comparer)
			: base(comparer)
		{

		}
		#endregion

		#region 构造函数 + public DictionaryEx(IDictionary<TKey, TValue> dictionary)
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="dictionary">初始数据</param>
		public DictionaryEx(IDictionary<TKey, TValue> dictionary)
			: base(dictionary)
		{

		}
		#endregion

		#region 构造函数 + public DictionaryEx(int capacity, IEqualityComparer<TKey> comparer)
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="capacity">可包含的初始元素数</param>
		/// <param name="comparer">比较键时要使用的 比较器 实现，或者为 null，以便为键类型使用默认的 比较器</param>
		public DictionaryEx(int capacity, IEqualityComparer<TKey> comparer)
			: base(capacity, comparer)
		{

		}
		#endregion

		#region 构造函数 + public DictionaryEx(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer)
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="dictionary">初始数据</param>
		/// <param name="comparer">比较键时要使用的 比较器 实现，或者为 null，以便为键类型使用默认的 比较器</param>
		public DictionaryEx(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer)
			: base(dictionary, comparer)
		{

		}
		#endregion

		#endregion

		#region 取得概要 + public XmlSchema GetSchema()
		/// <summary>
		/// 取得概要
		/// 注：根据MSDN的文档，此方法为保留方法，一定返回 null。
		/// </summary>
		/// <returns>Xml概要</returns>
		public XmlSchema GetSchema()
		{
			return null;
		}
		#endregion

		#region 从 XML 对象中反序列化生成本对象 + public void ReadXml(XmlReader reader)
		/// <summary>  
		/// 从 XML 对象中反序列化生成本对象
		/// </summary>  
		/// <param name="reader">包含反序列化对象的 XmlReader 流</param>  
		public void ReadXml(XmlReader reader)
		{
			XmlSerializer keySerializer = new XmlSerializer(typeof(TKey));
			XmlSerializer valueSerializer = new XmlSerializer(typeof(TValue));
			bool wasEmpty = reader.IsEmptyElement;
			reader.Read();
			if (wasEmpty) return;

			while (reader.NodeType != XmlNodeType.EndElement)
			{
				reader.ReadStartElement("Item");
				reader.ReadStartElement("Key");
				TKey key = (TKey)keySerializer.Deserialize(reader);
				reader.ReadEndElement();
				reader.ReadStartElement("Value");
				TValue value = (TValue)valueSerializer.Deserialize(reader);
				reader.ReadEndElement();
				this.Add(key, value);
				reader.ReadEndElement();
				reader.MoveToContent();
			}

			reader.ReadEndElement();
		}
		#endregion

		#region 将本对象序列化为 XML 对象 + public void WriteXml(XmlWriter writer)
		/// <summary>  
		/// 将本对象序列化为 XML 对象
		/// </summary>  
		/// <param name="writer">待写入的 XmlWriter 对象</param>  
		public void WriteXml(XmlWriter writer)
		{
			XmlSerializer keySerializer = new XmlSerializer(typeof(TKey));
			XmlSerializer valueSerializer = new XmlSerializer(typeof(TValue));
			foreach (TKey key in this.Keys)
			{
				writer.WriteStartElement("Item");
				writer.WriteStartElement("Key");
				keySerializer.Serialize(writer, key);
				writer.WriteEndElement();
				writer.WriteStartElement("Value");
				TValue value = this[key];
				valueSerializer.Serialize(writer, value);
				writer.WriteEndElement();
				writer.WriteEndElement();
			}
		}
		#endregion
	}
	#endregion
}