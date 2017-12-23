using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KindleHelper.Plugin.Interface;
using System.Windows.Forms;
namespace KindleHelper.Plugin.Plus
{
    public class Class1:IPluginPlus
    {
        public string version()
        {
            return "1.0.0.0";
        }

        public string GetName()
        {
            return typeof(Class1).FullName;
        }

        public void Invoke(Enviroment env)
        {
            throw new NotImplementedException();
        }

        public object Invoke2(Enviroment env, out MethodInfo info)
        {
            MethodInfo mi = new MethodInfo(typeof(int));
            info = mi;
            return 100;
        }

        public void DealReturnValue(ListBox returnaddlistbox, object returnvalue)
        {
            returnaddlistbox.Items.Add((int)returnvalue);
        }
    }
}
