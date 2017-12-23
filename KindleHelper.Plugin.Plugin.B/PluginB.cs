using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KindleHelper.Plugin.Interface;

namespace KindleHelper.Plugin.Plugin.B
{
    public class PluginB : IPlugin
    {
        public string GetName()
        {
            return "插件B";
        }

        System.Windows.Forms.Form ff = new System.Windows.Forms.Form();
        public void ShowForm()
        {
            ff.Show();
        }

        public void ShowFormAsDialog()
        {
            ff.Visible = false;
            ff.ShowDialog();
        }

        public string Version()
        {
            return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        public object GetResult()
        {
            return "111";
        }

        public object Run()
        {
            return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }
        public System.Diagnostics.Stopwatch Watch()
        {
            return new System.Diagnostics.Stopwatch();
        }


        public bool IsNotNeedToShowAsDialog()
        {
            return false;
        }
    }
}
