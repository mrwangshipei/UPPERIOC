using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPPERIOC.UPPER.IOC.Center.Interface;
using UPPERIOC.UPPER.IOC.Center.IProvider;
using UPPERIOC2.UPPER.Model;
using UPPERIOC2.UPPER.VersionControl;
using UPPERIOC2.UPPER.VersionControl.IVersion;


namespace UPPERIOC.UPPER.Sendor.Moudle
{
    public class UPPERVersionControlMoudle : IUPPERMoudle
    {

        public UPPERVersionControlMoudle()
        {

        }

		public Type[] DependisMoudel { get; set; } = new Type[0];


        public override void AfterCreateInstance(IContainerProvider containerProvider)
		{

			VersionCenter.IVersions = containerProvider.GetAllInstance(typeof(IVersionControl)).Select(item => item as IVersionControl).ToList();
		}

        public override void PreIniter(IContainerProvider containerProvider)
		{
			UPPERIOC.UPPERIOCApplication.RigisterVersionModel(new VersionModel());
		}

        public override void InitEnd(IContainerProvider containerProvider)
		{
		}

		public override  void IniterAndLoadClass(IContainerProvider containerProvider)
		{
		}
	}
}
