﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
namespace LibImport
{
    public class Class1
    {
        /// <summary>
        /// 文件路径
        /// </summary>
        public string Path { get { return Environment.CurrentDirectory + "\\config.xml"; } }
        /// <summary>
        /// 读取文件
        /// </summary>
        /// <returns></returns>
        public string Read()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(Path);
            XmlNode xn = xmlDoc.SelectSingleNode("books");
            XmlNodeList xnl = xn.ChildNodes;
            foreach (XmlNode xnf in xnl)
            {
                XmlElement xe = (XmlElement)xnf;
                XmlNodeList xnf1 = xe.ChildNodes;
                foreach (XmlNode xn2 in xnf1)
                {
                    string text = xn2.InnerText;
                    return text;
                } 
            }
            return null;
        }
        /// <summary>
        /// 创建并写入文件
        /// </summary>
        public void CreatAndWriteFile()
        {
            XmlTextWriter writer = new XmlTextWriter(Path, null);
            //使用自动缩进便于阅读
            writer.WriteStartDocument();
            writer.Formatting = Formatting.Indented;
            //写入根元素
            writer.WriteStartElement("books");
            //加入子元素
            writer.WriteElementString("Name", "红楼梦");
            writer.WriteElementString("Name2", "水浒传");
            writer.WriteElementString("Name3", "西游记");
            writer.WriteElementString("Name4", "三国演义");
            //关闭根元素，并书写结束标签
            writer.WriteEndElement();
            //将XML写入文件并且关闭XmlTextWriter
            writer.Close();
        }
    }
}
