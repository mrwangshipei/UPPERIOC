using System;
using UPPERIOC.UPPER.IOC.Center.Configuation;
using UPPERIOC.UPPER.IOC.Moudle;
using UPPERIOC.UPPER.Translate.IConfigration;
using UPPERIOC.UPPER.UFileLog.IConfiguation;
using UPPERIOC.UPPER.UFILELOG.Moudle;
using UPPERIOC2.UPPER.EmailErrorSender.Moudle;
using UPPERIOC2.UPPER.MLOCK.IConfiguation;
using UPPERIOC2.UPPER.Translate.Moudle;
using UPPERIOC2.UPPER.UFileModel.IConfiguaion;
using UPPERIOC2.UPPER.UFileModel.Moudle;

namespace UPPERIOC.UPPER.IOC.Center.Configuation
{
    public static class UPPERMoudleManager
    {
        public static void UPPERIOCMoudle(this MoudleConfiguaion md)
        {
            md.AddModule<UPPERIOCMoudle>();
        }

        public static void UPPERErrorMoudle(this MoudleConfiguaion md)
        {
            md.AddModule<UPPERErrorMoudle>();
        }

        public static void UPPERMLockMoudle(this MoudleConfiguaion md,MLockConfiguation conf)
        {
            if (conf != null)
            {
                md.Provider.Rigister(conf);
            }
            md.AddModule<UPPERMLockMoudle>();
        }

        public static void UPPERTranslateMoudle(this MoudleConfiguaion md,ITranslateConfig conf)
        {
            if (conf != null)
            {
                md.Provider.Rigister(conf);
            }

            md.AddModule<UPPERTranslateMoudle>();
        }

        public static void UPPERLogFileMoudle(this MoudleConfiguaion md,IFileLogConfiguation conf)
        {
            if (conf != null)
            {
                md.Provider.Rigister(conf);
            }
            md.AddModule<UPPERLogFileMoudle>();
        }

        public static void UPPERFileModelMoudle(this MoudleConfiguaion md,IUFileModelConfiguation conf)
        {

            if (conf != null)
            {
                md.Provider.Rigister(conf);
            }
            md.AddModule<UPPERFileModelMoudle>();
        }
    }
}
