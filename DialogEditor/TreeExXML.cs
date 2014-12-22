using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;
using DialogEditor;

namespace TreeExXML
{
    internal class TreeExXMLCls
    {
        private readonly XmlDocument textdoc;
        private XmlNode Xmlroot;
        private XmlTextWriter textWriter;
        private TreeView thetreeview;
        private string xmlfilepath;

        public TreeExXMLCls()
        {
            textdoc = new XmlDocument();
        }

        ~TreeExXMLCls()
        {
        }

        #region 遍历treeview并实现向XML的转化

        /// <summary>
        ///     遍历treeview并实现向XML的转化
        /// </summary>
        /// <param name="TheTreeView">树控件对象</param>
        /// <param name="XMLFilePath">XML输出路径</param>
        /// <returns>
        ///     0表示函数顺利执行
        /// </returns>
        public int TreeToXML(TreeView TheTreeView, string XMLFilePath)
        {
            //-------初始化转换环境变量
            thetreeview = TheTreeView;
            xmlfilepath = XMLFilePath;
            textWriter = new XmlTextWriter(xmlfilepath, null);

            //-------创建XML写操作对象
            textWriter.Formatting = Formatting.Indented;

            //-------开始写过程，调用WriteStartDocument方法
            textWriter.WriteStartDocument();


            ////-------添加第一个根节点
            textWriter.WriteStartElement((thetreeview.Nodes[0].Tag as Dialog.AttType).Type);


            var attType = new Dialog.AttType();

            var dic = new Dictionary<string, string>
            {
                {"A", "Root"},
                {"B", "Root"},
                {"E", "0000000000000000"},
                {"N", "Default"},
                {"C", "Default"},
                {"D", "Default"},
                {"F", "Default"},
                {"G", "0"},
                {"H", "Default"},
                {"I", "0"},
                {"J", "Default"},
                {"K", "0"},
                {"L", "Default"},
                {"M", "0"}
            };

            foreach (var pair in dic)
            {
                textWriter.WriteStartAttribute(pair.Key);
                textWriter.WriteString(pair.Value);
                textWriter.WriteEndAttribute();
            }


            textWriter.WriteEndElement();

            //------ 写文档结束，调用WriteEndDocument方法
            textWriter.WriteEndDocument();

            //-----关闭输入流
            textWriter.Close();

            //-------创建XMLDocument对象
            textdoc.Load(xmlfilepath);

            //------选中根节点
            XmlElement Xmlnode = textdoc.CreateElement(thetreeview.Nodes[0].Text);
            Xmlroot = textdoc.SelectSingleNode((thetreeview.Nodes[0].Tag as Dialog.AttType).Type);

            //------遍历原treeview控件，并生成相应的XML
            TransTreeSav(thetreeview.Nodes[0].Nodes, (XmlElement) Xmlroot);

            textdoc.Save(xmlfilepath);

            return 0;
        }

        private int TransTreeSav(TreeNodeCollection nodes, XmlElement ParXmlnode)
        {
            //-------遍历树的各个故障节点，同时添加节点至XML
            XmlElement xmlnode;
            //string nodeName = (thetreeview.Nodes[0].Tag as Dialog.AttType).Type;
            //if (nodeName == "Dialog")
            //{
            Xmlroot = textdoc.SelectSingleNode((thetreeview.Nodes[0].Tag as Dialog.AttType).Type);
            var att = new Dialog.AttType();
            foreach (TreeNode node in nodes)
            {
                xmlnode = textdoc.CreateElement((node.Tag as Dialog.AttType).Type);


                att = node.Tag as Dialog.AttType;

                if (xmlnode.Name == "Dialog")
                {
                    att.MapID = node.Parent.Parent.Parent.Parent.Parent.Parent.Parent.Index;
                    att.PlaceID = node.Parent.Parent.Parent.Parent.Parent.Parent.Index;
                    att.TaskID = node.Parent.Parent.Parent.Parent.Parent.Index;
                    att.DifficultyID = node.Parent.Parent.Parent.Parent.Index;
                    att.ActorID = node.Parent.Parent.Parent.Index;
                    att.ObjectID = node.Parent.Parent.Index;
                    att.TaskIndex = node.Parent.Index;
                    string Info = att.MapID < 10 ? "0" + att.MapID : att.MapID.ToString();
                    Info += att.PlaceID < 10 ? "0" + att.PlaceID : att.PlaceID.ToString();
                    Info += att.TaskID < 10 ? "0" + att.TaskID : att.TaskID.ToString();
                    Info += att.DifficultyID < 10 ? "0" + att.DifficultyID : att.DifficultyID.ToString();
                    Info += att.ActorID < 10 ? "0" + att.ActorID : att.ActorID.ToString();
                    Info += att.ObjectID < 10 ? "0" + att.ObjectID : att.ObjectID.ToString();
                    Info += att.TaskIndex < 10 ? "0" + att.TaskIndex : att.TaskIndex.ToString();
                    Info += att.Pos == "Left" ? "1" : "0";
                    Info += att.IsOption ? "1" : "0";

                    xmlnode.SetAttribute("A", att.Type);
                    xmlnode.SetAttribute("B", att.Tag);
                    xmlnode.SetAttribute("C", att.SpeakerName);
                    xmlnode.SetAttribute("D", att.Content);
                    xmlnode.SetAttribute("E", Info);
                    xmlnode.SetAttribute("F", att.OptionName1);
                    xmlnode.SetAttribute("G", att.OptionAction1);
                    xmlnode.SetAttribute("H", att.OptionName2);
                    xmlnode.SetAttribute("I", att.OptionAction2);
                    xmlnode.SetAttribute("J", att.OptionName3);
                    xmlnode.SetAttribute("K", att.OptionAction3);
                    xmlnode.SetAttribute("L", att.OptionName4);
                    xmlnode.SetAttribute("M", att.OptionAction4);
                    xmlnode.SetAttribute("N", att.SpeakerProfile);
                }
                else
                {
                    xmlnode.SetAttribute("A", att.Type);
                    xmlnode.SetAttribute("B", att.Tag);
                }
                ParXmlnode.AppendChild(xmlnode);

                if (node.Nodes.Count > 0)
                {
                    TransTreeSav(node.Nodes, xmlnode);
                }
            }

            return 0;
        }

        #endregion

        #region 遍历XML并实现向tree的转化

        /// <summary>
        ///     遍历treeview并实现向XML的转化
        /// </summary>
        /// <param name="XMLFilePath">XML输出路径</param>
        /// <param name="TheTreeView">树控件对象</param>
        /// <returns>
        ///     0表示函数顺利执行
        /// </returns>
        public int XMLToTree(string XMLFilePath, TreeView TheTreeView)
        {
            //-------重新初始化转换环境变量
            thetreeview = TheTreeView;
            xmlfilepath = XMLFilePath;

            //-------重新对XMLDocument对象赋值
            textdoc.Load(xmlfilepath);

            XmlNode root = textdoc.SelectSingleNode("TreeExXMLCls");

            foreach (XmlNode subXmlnod in root.ChildNodes)
            {
                var trerotnod = new TreeNode();
                trerotnod.Text = subXmlnod.Name;
                thetreeview.Nodes.Add(trerotnod);
                TransXML(subXmlnod.ChildNodes, trerotnod);
            }

            return 0;
        }

        private int TransXML(XmlNodeList Xmlnodes, TreeNode partrenod)
        {
            //------遍历XML中的所有节点，仿照treeview节点遍历函数
            foreach (XmlNode xmlnod in Xmlnodes)
            {
                var subtrnod = new TreeNode();
                subtrnod.Text = xmlnod.Name;
                partrenod.Nodes.Add(subtrnod);

                if (xmlnod.ChildNodes.Count > 0)
                {
                    TransXML(xmlnod.ChildNodes, subtrnod);
                }
            }

            return 0;
        }

        #endregion
    }
}