using Kernal;
using UPPERIOC2.UPPER.UFileModel.Model;

namespace FCT.Model
{

	public class CountModel:IModel
	{
		public override string ModelName { get => "Count.xml"; set { 
				var s  = value; 
			} }
		public DictionaryEx<string, PNCountModel> PNCounts { get; set; } 

	

		// 字典项的包装类
		public class SerializableKeyValuePair<TKey, TValue>
		{
			public TKey Key { get; set; }

			public TValue Value { get; set; }
	}

	internal PNCountModel CreateOrDefaultModel(string v)
		{
			if (PNCounts == null)
			{
				PNCounts = new DictionaryEx<string, PNCountModel>();
				
			}
			if (PNCounts.ContainsKey(v))
			{
				return PNCounts[v];
			}
			else
			{
				PNCountModel pn = new PNCountModel();
				PNCounts[v] = pn;
				return pn;
			}

		}
	}
}
