using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KindleHelper.Plugin.Interface;
using Ionic.Zip;
namespace KindleHelper.Plugin.Plugin.TestZip//比较特殊，既可以作为插件也可以单独运行
{
    class Program
    {
        static void Main(string[] args)
        {
            TestZip t = new TestZip();
            t.Run();
            Console.ReadKey();
        }
    }
    public class TestZip:IPlugin
    {
        public string GetName()
        {
            return "TestZip";
        }
        System.Diagnostics.Stopwatch _watch = new System.Diagnostics.Stopwatch();
        public void ShowForm()
        {
            
        }

        public void ShowFormAsDialog()
        {
            
        }

        public string Version()
        {
            return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        public object GetResult()
        {
            return "00";
        }
        public object Run()
        {
            _watch.Start();
            ZipFile file = new ZipFile("Desktop.zip");
            file.ExtractAll("./");
            _watch.Stop();
            return "解压完成";
        }

        public System.Diagnostics.Stopwatch Watch()
        {
            return _watch;
        }


        public bool IsNotNeedToShowAsDialog()
        {
            return false;
        }
    }
}
