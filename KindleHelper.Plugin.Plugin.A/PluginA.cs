﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KindleHelper.Plugin.Interface;

namespace KindleHelper.Plugin.Plugin.A
{
    public class PluginA : IPlugin
    {
        public string GetName()
        {
            return "插件A";
        }
        public void ShowForm()
        {
            
            f.Show();
        }
        Form1 f = new Form1();
        public void ShowFormAsDialog()
        {
            f.Visible = false;
            f.ShowDialog();
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
            System.Windows.Forms.Form ff = new System.Windows.Forms.Form();
            ff.ShowDialog();
            return "222";
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
