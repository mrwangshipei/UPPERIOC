using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using UPPERIOC;

namespace UPPERIOC2.UPPER.Premission
{
    public class RigisterObjLoad
    {
        public static RigisterObjLoad GetInstance(string root)
        {
            RigisterObjLoad[] r = UPPERIOCApplication.Container.GetAllInstance<RigisterObjLoad>() ;
            if (r == null || r.Length == 0)
            {
                throw new Exception("至少注册一个RigisterObjLoad 的实现类，哪怕使用默认的方法");

			}
            r[0].RegistryRoot = root;
            return r[0];
        }
        private string RegistryRoot;

        public virtual void SaveObjectToRegistry(string keyName, object obj)
        {
            if (obj == null)
            {
                return;
            }
            XmlSerializer xml = new XmlSerializer(obj.GetType());
            StringWriter sw = new StringWriter();
            xml.Serialize(sw, obj);
            Registry.SetValue(RegistryRoot, keyName, sw.ToString());
        }

        public virtual T LoadObjectFromRegistry<T>(string keyName) where T : new()
        {
            XmlSerializer xml = new XmlSerializer(typeof(T));
            string t = (string)Registry.GetValue(RegistryRoot, keyName, null);
            if (t == null)
            {
                return default;
            }
            StringReader sw = new StringReader(t);
            return (T)xml.Deserialize(sw);

        }
    }
}
