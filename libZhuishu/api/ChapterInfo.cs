namespace libZhuishu
{
    public class ChapterInfo
    {
        public string title;
        public string body;
        public string id;
        public static implicit operator ChapterInfo2(ChapterInfo info)
        {
            ChapterInfo2 cf2 = new ChapterInfo2() {body=info.body,id=info.id,title=info.title };
            return cf2;
        }
    }
}
