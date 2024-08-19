using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using UPPERIOC.UPPER.IOC.Annaiation;
using UPPERIOC.UPPER.IOC.Center.IProvider;
using UPPERIOC2.UPPER.UFileModel.IConfiguaion;
using static System.Net.WebRequestMethods;

namespace UPPERIOC2.UPPER.UFileModel.Center
{
	[IOCObject]
	public class UFileModelCenter
	{
		internal static IContainerProvider pdr;
				
		public I GetModel<I>(I T)where I: IModel.IModel 
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
			string dp = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, cfg.SaveModelPath);

			var xs = new XmlSerializer(typeof(I));
			string p = Path.Combine(dp ,T.ModelName);
			try
			{
				using (var fs = new FileStream(p, FileMode.Open,FileAccess.Read))
			{
				var obj = xs.Deserialize(fs);
					if (obj == null)
					{
						return T;
					}
					return obj as I;

				}
			}
			catch (Exception ex)
			{
				//throw ex;
				return T;

			}
			finally
			{
			}

		}
		public void SaveModel<I>(I T) where I : IModel.IModel 
		{
			lock (this)
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
			string dp = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, cfg.SaveModelPath);

			var xs = new XmlSerializer(typeof(I));
			string p = Path.Combine(dp, T.ModelName);
				
			using (var fs = new FileStream(p, FileMode.Create))
			{
				try
				{
						
					xs.Serialize(fs,T);
				}
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
					fs.Close();
				}

			}
			}

		}
		private void CheckPathExist(IUFileModelConfiguation cfg)
		{
			string dp = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, cfg.SaveModelPath);
			if (!Directory.Exists(dp))
			{
				Directory.CreateDirectory(dp);
			}
			
		}
	}
}
