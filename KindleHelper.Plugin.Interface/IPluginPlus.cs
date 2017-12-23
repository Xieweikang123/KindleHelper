using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace KindleHelper.Plugin.Interface
{
    #region 插件的拓展接口，新插件只需实现此接口就行
    /// <summary>
    /// 插件的拓展接口，新插件只需实现此接口就行
    /// </summary>
    public interface IPluginPlus
    {
        /// <summary>
        /// 返回插件版本
        /// </summary>
        /// <returns>插件版本</returns>
        string version();
        /// <summary>
        /// 返回插件名称
        /// </summary>
        /// <returns>插件名称</returns>
        string GetName();
        /// <summary>
        /// 调用接口，注意非此方法一定要抛出未实现异常
        /// </summary>
        /// <param name="env"></param>
        void Invoke(Enviroment env);
        /// <summary>
        /// 调用接口，注意非此方法一定要抛出未实现异常
        /// </summary>
        /// <param name="env"></param>
        object Invoke2(Enviroment env,out MethodInfo info);
        /// <summary>
        /// 处理返回值
        /// </summary>
        /// <param name="returnaddlistbox">返回值显示框</param>
        void DealReturnValue(ListBox returnaddlistbox,object returnvalue);
    }
    #endregion
    #region 返回值相关信息
    /// <summary>
    /// 返回值相关信息
    /// </summary>
    public class MethodInfo
    {
        /// <summary>
        /// 返回类型
        /// </summary>
        Type _returntype;
        public MethodInfo(Type returntype)
        {
            _returntype = returntype;
        }
        public Type returntypoe { get { return _returntype; } }
    }
    #endregion
}
