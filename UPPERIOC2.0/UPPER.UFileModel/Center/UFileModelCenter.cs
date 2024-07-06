using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using UPPERIOC.UPPER.IOC.Center.IProvider;
using UPPERIOC2._0.UPPER.UFileModel.IConfiguaion;

namespace UPPERIOC2._0.UPPER.UFileModel.Center
{
	public class UFileModelCenter
	{
		internal IContainerProvider pdr;
		public static UFileModelCenter Instance;
		public IModel.IModel GetModel(IModel.IModel T) 
		{

			if (pdr == null)
			{
				throw new Exception("必须使用SetProvider注册一个Ioc管理器");
			}
			var arr = pdr.GetAllInstance(typeof(IConfiguaion.IUFileModelConfiguation));
			if (arr.Length == 0)
			{
				throw new Exception("必须注册一个IUFileModelConfiguation的实现");
			}
			var cfg = arr[0] as IUFileModelConfiguation;
			CheckPathExist(cfg);
			string dp = Path.Combine(Environment.CurrentDirectory, cfg.SaveModelPath);

			var xs = new XmlSerializer(typeof(IModel.IModel));
			using (var fs = new FileStream(dp + T.ModelName, FileMode.OpenOrCreate))
			{
				try
				{
					var obj = xs.Deserialize(fs);
					if (obj == null)
					{
						return T;
					}
					return obj as IModel.IModel;
				}
				catch (Exception)
				{
					return T;

				}
				finally {
					fs.Close();
				}

			}
		}
		public void SaveModel(IModel.IModel T) {

			if (pdr == null)
			{
				throw new Exception("必须使用SetProvider注册一个Ioc管理器");
			}
			var arr = pdr.GetAllInstance(typeof(IConfiguaion.IUFileModelConfiguation));
			if (arr.Length == 0)
			{
				throw new Exception("必须注册一个IUFileModelConfiguation的实现");
			}
			var cfg = arr[0] as IUFileModelConfiguation;
			CheckPathExist(cfg);
			string dp = Path.Combine(Environment.CurrentDirectory, cfg.SaveModelPath);

			var xs = new XmlSerializer(typeof(IModel.IModel));
			using (var fs = new FileStream(dp + T.ModelName, FileMode.OpenOrCreate))
			{
				try
				{
					xs.Serialize(fs,T);
				}
				catch (Exception)
				{

				}
				finally
				{
					fs.Close();
				}

			}
		}
		private void CheckPathExist(IUFileModelConfiguation cfg)
		{
			string dp = Path.Combine(Environment.CurrentDirectory, cfg.SaveModelPath);
			if (!Directory.Exists(dp))
			{
				Directory.CreateDirectory(dp);
			}
			
		}
	}
}
