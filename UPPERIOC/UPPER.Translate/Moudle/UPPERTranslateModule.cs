using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPPERIOC.UPPER;
using UPPERIOC.UPPER.IOC.Center.Interface;
using UPPERIOC.UPPER.IOC.Center.IProvider;
using UPPERIOC.UPPER.Translate.IConfigration;
using UPPERIOC2.UPPER.Translate.Center;
using UPPERIOC2.UPPER.Translate.Model;
using UPPERIOC2.UPPER.UFileModel.Center;
using UPPERIOC2.UPPER.UFileModel.Model;
using UPPERIOC2.UPPER.UFileModel.Moudle;

namespace UPPERIOC2.UPPER.Translate.Moudle
{
    public class UPPERTranslateModule : IUPPERModule, IModulePostConstruction, IModuleInitialization, IModulePostInitialization, IModulePreInitialization
    {
		public override Type[] Dependencies { get => new Type[] { typeof(UFileModel.Moudle.UPPERFileModelModule) }; }

        public void OnPostConstruct(IContainerProvider containerProvider)
		{
			
		}

        public void OnPostInitialize(IContainerProvider containerProvider)
		{
            var cof = containerProvider.GetInstanceAndSub<ITranslateConfig>();

            TranslateCenter.Instance.SetLanguage(cof.ToLanguage);
        }

        public void OnInitialize(IContainerProvider containerProvider)
		{
			if (F.I == null)
			{
				var err = "TranslateMoudle使用到了UPPERFileModelMoudle，而UPPERFileModelMoudle未注册";
                LogCenter.Log(UPPERIOC.UPPER.enums.LogType.Error,err);
				throw new Exception(err);
			}
            TranslateModel tm = F.I.GetModel<TranslateModel>(new TranslateModel());
			TranslateCenter.Instance = new TranslateCenter(containerProvider);
		
			
			//TranslateCenter.Instance.TranslateModel = tm;
		//	if (TranslateCenter.Instance.TranslateBlock == null && string.IsNullOrWhiteSpace(TranslateCenter.Instance.L))
			{
			//	TranslateCenter.Instance.TranslateBlock = tm.Translateblocks.Find(x => x.Name == TranslateCenter.Instance.L);
			//	if (TranslateCenter.Instance.TranslateBlock == null)
			//	{
			//		TranslateCenter.Instance.TranslateBlock = new Translateblock();
			//		tm.Translateblocks.Add(TranslateCenter.Instance.TranslateBlock);
			//	}
			}
		}

        public void OnPreInitialize(IContainerProvider containerProvider)
		{
		}
	}
}
