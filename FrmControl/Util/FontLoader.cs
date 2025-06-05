using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Reflection;

public class FontLoader
{
    private static PrivateFontCollection privateFonts = new PrivateFontCollection();

    public static Font LoadFont(float size, FontStyle style = FontStyle.Regular)
    {
        if (privateFonts.Families.Length == 0)
        {
            // 读取嵌入资源中的字体文件
            string fontResource = "FrmControl.resc.AlimamaDaoLiTi.ttf"; // 注意替换为你的命名空间 + 文件名

            using (Stream fontStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(fontResource))
            {
                if (fontStream == null)
                    throw new Exception("字体资源未找到：" + fontResource);

                byte[] fontData = new byte[fontStream.Length];
                fontStream.Read(fontData, 0, (int)fontStream.Length);

                IntPtr fontPtr = Marshal.AllocCoTaskMem(fontData.Length);
                Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
                privateFonts.AddMemoryFont(fontPtr, fontData.Length);
                Marshal.FreeCoTaskMem(fontPtr);
            }
        }

        return new Font(privateFonts.Families[0], size, style);
    }
}
