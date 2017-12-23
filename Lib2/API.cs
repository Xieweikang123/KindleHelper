using libZhuishu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib2
{
    public static class API
    {
        public static ChapterInfo2[] Convert(ChapterInfo[] info1)
        {
            int lenght = info1.Length;
            ChapterInfo2[] info2 = new ChapterInfo2[lenght];
            for (int i = 0; i < lenght; i++)
            {
                info2[i] = info1[i];
            }
            return info2;
        }
        public static ChapterInfo2[] Convert(List<ChapterInfo> info1)
        {
            return Convert(info1.ToArray());
        }
        public static List<ChapterInfo2> Convert(List<ChapterInfo> info1,object obj)
        {
            List<ChapterInfo2> info2 = new List<ChapterInfo2>();
            info2.AddRange(Convert(info1.ToArray()));
            return info2;
        }
    }
}
