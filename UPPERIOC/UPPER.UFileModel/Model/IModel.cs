using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using UPPERIOC2.UPPER.UFileModel.Center;
using UPPERIOC2.UPPER.USendor.Center;

namespace UPPERIOC2.UPPER.UFileModel.Model
{
	[Serializable]
	[XmlRoot]

	[XmlInclude(typeof(IModel))]
	public class IModel
	{
        public virtual string ModelName { get; set; }
		public void SaveModel()
        {
            F.I.SaveModel(this);
		}
		
    }
}
