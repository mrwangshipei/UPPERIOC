using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPPERIOC.UPPER.IOC.Center.Interface;
using UPPERIOC.UPPER.IOC.Center.IProvider;
using UPPERIOC2.UPPER.Translate.Center;
using UPPERIOC2.UPPER.Translate.Model;
using UPPERIOC2.UPPER.UFileModel.Center;
using UPPERIOC2.UPPER.UFileModel.Model;
using UPPERIOC2.UPPER.UFileModel.Moudle;

namespace UPPERIOC2.UPPER.Translate.Moudle
{
	public class UPPERTranslateMoudle : IUPPERMoudle
	{
        public Type[] DependisMoudel { get => new Type[] {typeof( UFileModel.Moudle.UPPERFileModelMoudle)}; set => throw new NotImplementedException(); }

		public void AfterCreateInstance(IContainerProvider containerProvider)
		{
			
		}

		public void InitEnd(IContainerProvider containerProvider)
		{
		}

		public void IniterAndLoadClass(IContainerProvider containerProvider)
		{
			TranslateModel tm = F.I.GetModel<TranslateModel>(new TranslateModel());
			TranslateCenter.Instance = new TranslateCenter(containerProvider);
			TranslateCenter.Instance.TranslateModel = tm;
			if (TranslateCenter.Instance.TranslateBlock == null && string.IsNullOrWhiteSpace(TranslateCenter.Instance.L))
			{
				TranslateCenter.Instance.TranslateBlock = tm.Translateblocks.Find(x => x.Name == TranslateCenter.Instance.L);
				if (TranslateCenter.Instance.TranslateBlock == null)
				{
					TranslateCenter.Instance.TranslateBlock = new Translateblock();
					tm.Translateblocks.Add(TranslateCenter.Instance.TranslateBlock);
				}
			}
		}

		public void PreIniter(IContainerProvider containerProvider)
		{
		}
	}
}
