using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace UPPERIOC2.UPPER.UFileModel.IModel
{
	[Serializable]
	[XmlRoot]

	[XmlInclude(typeof(IModel))]
	public class IModel
	{
        public virtual string ModelName { get; set; }

    }
}
