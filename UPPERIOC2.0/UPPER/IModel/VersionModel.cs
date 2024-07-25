using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;

namespace UPPERIOC2.UPPER.IModel
{
    public class VersionModel
    {
        public VersionModel()
        {
            InitModel();
        }

        public virtual double NowVersion { get; set; }

        public virtual void SaveModel()
        {
            var serializer = new XmlSerializer(typeof(VersionModel));
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Version.xml");

            using (var writer = new StreamWriter(path))
            {
                serializer.Serialize(writer, this);
            }
        }

        public virtual void InitModel()
        {
            var serializer = new XmlSerializer(typeof(VersionModel));
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Version.xml");

            if (File.Exists(path))
            {
                using (var reader = new StreamReader(path))
                {
                    var loadedModel = (VersionModel)serializer.Deserialize(reader);
                    if (loadedModel != null)
                    {
                        NowVersion = loadedModel.NowVersion;
                    }
                }
            }
            // 如果文件不存在，可以设置一个默认值或抛出异常  
            else
            {
                Console.WriteLine("Version.xml file not found. Using default version.");
                // 设定一个默认值  
                NowVersion = 0.0;
            }
        }


    }
}
