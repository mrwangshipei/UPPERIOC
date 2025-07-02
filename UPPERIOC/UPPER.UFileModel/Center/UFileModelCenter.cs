using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using UPPERIOC.UPPER.IOC.Annaiation;
using UPPERIOC.UPPER.IOC.Center.IProvider;
using UPPERIOC2.UPPER.UFileModel.IConfiguaion;
using UPPERIOC2.UPPER.UIOC.Center;

namespace UPPERIOC2.UPPER.UFileModel.Center
{
	public static class F { 
		public static UFileModelCenter I { get => UFileModelCenter.Instance; }
	}
	public class UFileModelCenter
	{
		internal static IContainerProvider pdr;
		public static UFileModelCenter Instance;
        // 获取模型，支持版本号通过单独的文件来获取
        public I GetModel<I>(I T, bool findformContext = false) where I : Model.IModel
        {
            if (pdr == null)
            {
                throw new Exception("必须使用SetProvider注册一个Ioc管理器");
            }

            if (findformContext)
            {
                if (U.C.GetInstanceAndSub<I>() is I x)
                {
                    return x;
                }
            }

            var arr = pdr.GetAllInstance(typeof(IConfiguaion.IUFileModelConfiguation));
            if (arr.Length == 0)
            {
                throw new Exception("必须注册一个IUFileModelConfiguation的实现");
            }

            var cfg = arr[0] as IUFileModelConfiguation;
            CheckPathExist(cfg);

            string dp = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, cfg.SaveModelPath);
            string p = Path.Combine(dp, T.ModelName);

            try
            {
                // 读取版本号的文件
                string versionFilePath = Path.Combine(dp, T.ModelName + ".version");
                string version = "";
                if (File.Exists(versionFilePath))
                {
                    version= File.ReadAllText(versionFilePath).Trim();
                }

                string json = File.ReadAllText(p);

                // 根据版本号选择对应的序列化方式
                if (version == "2.0")
                {
                    var settings = new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.All
                    };
                    var obj = JsonConvert.DeserializeObject<I>(json, settings);
                    return obj ?? T;
                }
                else
                {
                    return DeserializeOldVersion<I>(p);
                }
            }
            catch
            {
                return T;
            }
        }

        public void SaveModel<I>(I T, bool andregister = false) where I : Model.IModel
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
                string fileName = T.ModelName;
                string targetFilePath = Path.Combine(dp, fileName);
                string targetVersionPath = Path.Combine(dp, fileName + ".version");

                // 创建 temp 文件夹用于临时写入
                string tempDir = Path.Combine(dp, "temp");
                if (!Directory.Exists(tempDir))
                {
                    Directory.CreateDirectory(tempDir);
                }

                string tempFilePath = Path.Combine(tempDir, fileName + ".tmp");
                string tempVersionPath = Path.Combine(tempDir, fileName + ".version.tmp");

                var settings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All,
                    Formatting = Newtonsoft.Json.Formatting.Indented
                };

                try
                {
                    // 序列化 JSON 到临时文件
                    string json = JsonConvert.SerializeObject(T, settings);
                    File.WriteAllText(tempFilePath, json);

                    // 写入版本信息到临时文件
                    File.WriteAllText(tempVersionPath, "2.0");

                    // 替换正式文件（确保原子操作）
                    File.Copy(tempFilePath, targetFilePath, true);
                    File.Copy(tempVersionPath, targetVersionPath, true);

                    // 可选：清理临时文件
                    File.Delete(tempFilePath);
                    File.Delete(tempVersionPath);
                }
                catch (Exception ex)
                {
                    throw new Exception("模型保存失败（写入临时文件或替换正式文件时出错）", ex);
                }

                if (andregister)
                {
                    pdr.Rigister<I>(T);
                }
            }
        }

        private I DeserializeOldVersion<I>(string filePath) where I : Model.IModel
        {
            try
            {
                // 使用 XmlSerializer 进行反序列化，旧版本的文件假定是 XML 格式
                var xs = new XmlSerializer(typeof(I));

                // 读取旧版本文件
                using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    // 执行反序列化，返回为 I 类型
                    var obj = xs.Deserialize(fs);
                    return obj as I;
                }
            }
            catch (Exception ex)
            {
                // 处理任何可能的异常，给出友好的提示
                throw new Exception("反序列化旧版本文件失败", ex);
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

//public I GetModel<I>(I T,bool findformContext = false) where I : Model.IModel
//{

//    if (pdr == null)
//    {
//        throw new Exception("必须使用SetProvider注册一个Ioc管理器");
//    }
//    if (findformContext)
//    {
//        if (U.C.GetInstanceAndSub<I>() is I x)
//        {
//            return x;
//        }
//    }
//    var arr = pdr.GetAllInstance(typeof(IConfiguaion.IUFileModelConfiguation));
//    if (arr.Length == 0)
//    {
//        throw new Exception("必须注册一个IUFileModelConfiguation的实现");
//    }
//    var cfg = arr[0] as IUFileModelConfiguation;
//    CheckPathExist(cfg);
//    string dp = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, cfg.SaveModelPath);

//    var xs = new XmlSerializer(T.GetType());
//    string p = Path.Combine(dp, T.ModelName);
//    try
//    {
//        using (var fs = new FileStream(p, FileMode.Open, FileAccess.Read))
//        {
//            var obj = xs.Deserialize(fs);
//            if (obj == null)
//            {
//                return T;
//            }
//            return obj as I;

//        }
//    }
//    catch (Exception ex)
//    {
//        return T;

//    }
//    finally
//    {
//    }

//}
//public void SaveModel<I>(I T,bool andregister = false) where I : Model.IModel
//{
//    lock (this)
//    {

//        if (pdr == null)
//        {
//            throw new Exception("必须使用SetProvider注册一个Ioc管理器");
//        }
//        var arr = pdr.GetAllInstance(typeof(IConfiguaion.IUFileModelConfiguation));
//        if (arr.Length == 0)
//        {
//            throw new Exception("必须注册一个IUFileModelConfiguation的实现");
//        }
//        var cfg = arr[0] as IUFileModelConfiguation;
//        CheckPathExist(cfg);
//        string dp = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, cfg.SaveModelPath);

//        var xs = new XmlSerializer(typeof(I));
//        string p = Path.Combine(dp, T.ModelName);

//        using (var fs = new FileStream(p, FileMode.Create))
//        {
//            try
//            {

//                xs.Serialize(fs, T);
//                if (andregister)
//                {
//                    pdr.Rigister<I>(T);
//                }
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//            finally
//            {
//                fs.Close();
//            }

//        }
//    }

//}


