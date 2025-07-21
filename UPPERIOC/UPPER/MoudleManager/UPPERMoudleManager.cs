using System;
using UPPERIOC.UPPER.IOC.Center.Configuation;
using UPPERIOC.UPPER.IOC.Moudle;
using UPPERIOC.UPPER.Translate.IConfigration;
using UPPERIOC.UPPER.UFileLog.IConfiguation;
using UPPERIOC.UPPER.UFILELOG.Moudle;
using UPPERIOC2.UPPER.MLOCK.IConfiguation;
using UPPERIOC2.UPPER.Translate.Moudle;
using UPPERIOC2.UPPER.UFileModel.IConfiguaion;
using UPPERIOC2.UPPER.UFileModel.Moudle;

namespace UPPERIOC.UPPER.IOC.Center.Configuation
{
    public static class UPPERMoudleManager
    {
        public static void UPPERIOCMoudle(this ModuleConfiguaion md)
        {
            md.AddModule<UPPERIOCModule>();
        }

        public static void UPPERMLockMoudle(this ModuleConfiguaion md,MLockConfiguation conf)
        {
            if (conf != null)
            {
                md.Provider.Rigister(conf.GetType(),conf);
            }
            md.AddModule<UPPERMLockModule>();
        }

        public static void UPPERTranslateMoudle(this ModuleConfiguaion md,ITranslateConfig conf)
        {
            if (conf != null)
            {
                md.Provider.Rigister(conf.GetType(), conf);
            }

            md.AddModule<UPPERTranslateModule>();
        }

        public static void UPPERLogFileMoudle(this ModuleConfiguaion md,IFileLogConfiguation conf)
        {
            if (conf != null)
            {
                md.Provider.Rigister(conf.GetType(), conf);
            }
            md.AddModule<UPPERLogFileModule>();
        }

        public static void UPPERFileModelMoudle(this ModuleConfiguaion md,IUFileModelConfiguation conf)
        {

            if (conf != null)
            {
                md.Provider.Rigister(conf.GetType(), conf);
            }
            md.AddModule<UPPERFileModelModule>();
        }
    }
}
