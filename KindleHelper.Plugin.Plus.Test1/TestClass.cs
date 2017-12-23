using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KindleHelper.Plugin.Interface;
namespace KindleHelper.Plugin.Plus.Test1
{
    public class TestClass:IPluginPlus
    {
        public string version()
        {
            return "1.0.0.0";
        }

        public string GetName()
        {
            return "TestClass";
        }

        public void Invoke(Enviroment env)
        {
            throw new NotImplementedException();
        }

        public object Invoke2(Enviroment env, out MethodInfo info)
        {
            MethodInfo mi = new MethodInfo(typeof(Enviroment));
            info = mi;
            return env;
        }

        public void DealReturnValue(System.Windows.Forms.ListBox returnaddlistbox, object returnvalue)
        {
            Enviroment env = (Enviroment)returnvalue;
            returnaddlistbox.Items.AddRange(new[]{env.get.GetType().ToString(),env.gh.GetType().ToString(),env.book.GetType().ToString(),env.results.GetType().ToString()});
        }
    }
}
