using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UpperComAutoTest.View.Page.Interface;

namespace UpperComAutoTest.View.Page.Center
{
    public static class PageCenter
    {
        private static Dictionary<string, IPage> Pages = new Dictionary<string, IPage>();
        static PageCenter()
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            var items = asm.DefinedTypes.Where(type => type.IsSubclassOf(typeof(IPage)));
            var ipages = items.Select(item =>
            {
                return Assembly.GetAssembly(item).CreateInstance(item.FullName) as IPage;
            });
            foreach (var item in ipages)
            {
                item.Dock = DockStyle.Fill;
                Pages[item.PageName] = item;
            }
        }

        public static IPage GetPage(string PageName)
        {
            lock (Pages)
            {

                if (Pages.ContainsKey(PageName))
                {
                    return Pages[PageName];
                }
                else
                {
                    return null;
                }

            }
        }

        public static void InvokeIn(Action<IPage> act, string PageName)
        {
            lock (Pages)
            {

                if (Pages.ContainsKey(PageName))
                {
                    act.Invoke(Pages[PageName]);
                }

            }
        }
    }
}
