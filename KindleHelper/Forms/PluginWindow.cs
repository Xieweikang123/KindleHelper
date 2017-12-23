using GrapchLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KindleHelper.Plugin.Interface;
using KindleHelper;
using System.Reflection;
using System.IO;
using KindleHelper.lib;
namespace KindleHelper
{
    public partial class PluginWindow : Form
    {
        int a, b;
        GrapchHelper c;
        public PluginWindow()
        {
            InitializeComponent();
            using (g = this.CreateGraphics())
            {
              Global.env.Set(g);  
            }
            a = Width;
            b = Height;
            Graphics gq = this.CreateGraphics();
            c = new GrapchHelper(gq);
            c.Draw(b, a);
            g.Dispose();
            c.Dispose();
        }
        Graphics g;
        private void qc(object sender, EventArgs e)
        {
            a = Width;
            b = Height;
            Graphics g = this.CreateGraphics();
            c = new GrapchHelper(g);
            c.Draw(b, a);
            g.Dispose();
            c.Dispose();
        }
        private void p(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            c = new GrapchHelper(g);
            c.Draw(b, a);
            g.Dispose();
        }
        KindleHelper.Plugin.Interface.MethodInfo mi;
        bool[] bx = new bool[2]{true,true};
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                object obj = listBox1.SelectedItem;
                if (obj != null && (listBox1.SelectedIndex > 0 || listBox1.SelectedIndex < listBox1.Items.Count))
                {
                    IPluginPlus ips = ((IPluginPlus)obj);
                    try
                    {
                        ips.Invoke(Global.env);
                    }
                    catch (NotImplementedException)
                    {
                        bx[0] = false;
                        try
                        {
                            var result=ips.Invoke2(Global.env, out mi);
                            ips.DealReturnValue(this.listBox2,result);
                        }
                        catch (NotImplementedException)
                        {
                            bx[1] = false;
                            if (!bx[0]&&!bx[1])
                            {
                                throw new MyException("两个方法都未实现，请检查！");
                            }
                        }
                    }
                    loglibrary.LogHelper.Info("returntype:"+mi.returntypoe.FullName.ToString());
                    loglibrary.LogHelper.Flush();
                }
            }
            catch (Exception ec)
            {
                if (!(ec is MyException))
                {
                  loglibrary.LogHelper.Error(ec);
                  loglibrary.LogHelper.Flush();
                }
                else
                {

                }
            }
        }
        PluginHelper helper = new PluginHelper();
        private void button1_Click(object sender, EventArgs e)
        {
            List<string> pluginpath = helper.FindPlugin();
            pluginpath = helper.DeleteInvalidPlunginPlus(pluginpath);
            foreach (string filename in pluginpath)
            {
                try
                {
                    //获取文件名
                    string asmfile = filename;
                    string asmname = Path.GetFileNameWithoutExtension(asmfile);
                    if (asmname != string.Empty)
                    {
                        // 利用反射,构造DLL文件的实例
                        Assembly asm = Assembly.LoadFile(asmfile);
                        //利用反射,从程序集(DLL)中,提取类,并把此类实例化
                        Type[] t = asm.GetExportedTypes();
                        foreach (Type type in t)
                        {
                            if (type.GetInterface("IPluginPlus") != null)
                            {
                                IPluginPlus pluginitem = (IPluginPlus)Activator.CreateInstance(type);
                                listBox1.Items.Add(pluginitem);
                                listBox3.Items.AddRange(new[] {"name:"+pluginitem.GetName(),"Version:"+pluginitem.version() });

                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    loglibrary.LogHelper.Error(ex);
                    loglibrary.LogHelper.Flush();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex > 0 || listBox1.SelectedIndex < listBox1.Items.Count)
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listBox3.Items.Clear();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex > 0 || listBox2.SelectedIndex < listBox2.Items.Count)
            {
                listBox2.Items.RemoveAt(listBox2.SelectedIndex);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (listBox3.SelectedIndex > 0 || listBox3.SelectedIndex < listBox3.Items.Count)
            {
                listBox3.Items.RemoveAt(listBox3.SelectedIndex);
            }
        }
    }
}
