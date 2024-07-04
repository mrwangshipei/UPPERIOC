using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using UPPERIOC.UPPER.IOC.MyTypeInfo;

namespace UPPERIOC.UPPER.IOC.Extend
{
    public static class UPPERStaticExtend
    {
        public static bool ContainsAll (this Array arr,Array Contailarr)
        {
            int i = 0;
            foreach (var item in Contailarr)
            {
				bool hasi = false;

				foreach (var item1 in arr)
                {
                    if (item == item1)
                    {
                        hasi = true;
                        i++;
                        break;
                    }

                }
                
            }

            if (i == Contailarr.Length)
            {
                return true;
            }
            return false;
        }
	}
}
