using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using KindleHelper;
using GrapchLibrary;
using System.Drawing;
using libZhuishu;
using KindleSender.Service;
namespace KindleHelper.Plugin.Interface
{
    #region 基础插件接口
    /// <summary>
    /// 基础插件接口
    /// </summary>
    public interface IPlugin
    {
        /// <summary>
        /// 返回插件名称
        /// </summary>
        /// <returns>插件名称</returns>
        string GetName();
        /// <summary>
        /// 显示窗体
        /// </summary>
        void ShowForm();
        /// <summary>
        /// 以对话框方式显示窗体
        /// </summary>
        void ShowFormAsDialog();
        /// <summary>
        /// 返回插件版本
        /// </summary>
        /// <returns>插件版本</returns>
        string Version();
        /// <summary>
        /// 运行特定方法并返回结果
        /// </summary>
        /// <returns>结果</returns>
        object GetResult();
        /// <summary>
        /// 返回结果
        /// </summary>
        /// <returns>结果</returns>
        object Run();
        /// <summary>
        /// 获取包含内部运行时间数据的对象
        /// </summary>
        /// <returns>包含内部运行时间数据的对象</returns>
        Stopwatch Watch();
        /// <summary>
        /// 确定是否需要以对话框方式显示窗体
        /// </summary>
        /// <returns>结果</returns>
        bool IsNotNeedToShowAsDialog();
    }
    #endregion
    #region 插件注入环境
    /// <summary>
    /// 插件注入环境
    /// </summary>
    public struct Enviroment
    {
        #region 主信息
        /// <summary>
        /// 书籍信息
        /// </summary>
        public QueryBookInfo[] results;
        /// <summary>
        /// 书本信息
        /// </summary>
        public Book2 book;
        /// <summary>
        /// 配置信息
        /// </summary>
        public Configuration config;
        #endregion
        //绘图部分成员
        #region Graphics
        Graphics _g;
        public Graphics get { get { return _g; } }
        public GrapchHelper gh;
        public void Set(Graphics g)
        {
            _g = g;
            gh = new GrapchHelper(g);
        }
       #endregion
    }
   #endregion 
}
