using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Xml;
using TreeExXML;

namespace DialogEditor
{
    /// <summary>
    /// </summary>
    [Serializable]
    public partial class Dialog : Form
    {
        public delegate void MyMethod();

        public AttType at = null;

        public Dialog()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            TV.HideSelection = false;
            TV.DrawMode = TreeViewDrawMode.OwnerDrawText;
        }

        private void btnLoadXML_Click(object sender, EventArgs e)
        {
            //try
            //{
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtXMLPath.Text = "";
                txtXMLPath.Text = openFileDialog1.FileName;
                LoadXML(txtXMLPath.Text);
                MessageBox.Show("Test！");
            }
            //}
        }

        private void LoadXML(object path)
        {
            var xDoc = new XmlDocument();
            xDoc.Load((string) path);
            TV.BeginUpdate();
            TV.Nodes.Clear();
            var tn = new TreeNode(xDoc.DocumentElement.Name);
            AttType at = SaveNodeToTag(xDoc.DocumentElement);
            tn.Tag = at;

            TV.Nodes.Add(tn);

            addTreeNode(xDoc.DocumentElement, TV.Nodes[0]);
            TV.EndUpdate();
        }

        private AttType SaveNodeToTag(XmlNode xmlnode)
        {
            var a = new AttType();
            a.ActorID = xmlnode.Attributes["E"] == null ? 0 : int.Parse(xmlnode.Attributes["E"].Value.Substring(8, 2));
            a.ObjectID = xmlnode.Attributes["E"] == null ? 0 : int.Parse(xmlnode.Attributes["E"].Value.Substring(10, 2));
            a.PlaceID = xmlnode.Attributes["E"] == null ? 0 : int.Parse(xmlnode.Attributes["E"].Value.Substring(2, 2));
            a.Content = xmlnode.Attributes["D"] == null ? "" : xmlnode.Attributes["D"].Value;
            a.DifficultyID = xmlnode.Attributes["E"] == null
                ? 0
                : int.Parse(xmlnode.Attributes["E"].Value.Substring(6, 2));
            a.IsOption = xmlnode.Attributes["E"] == null
                ? false
                : (xmlnode.Attributes["E"].Value.Substring(15, 1) == "1" ? true : false);
            a.TaskID = xmlnode.Attributes["E"] == null ? 0 : int.Parse(xmlnode.Attributes["E"].Value.Substring(4, 2));
            a.OptionAction1 = xmlnode.Attributes["G"] == null ? "0" : xmlnode.Attributes["G"].Value;
            a.OptionName1 = xmlnode.Attributes["F"] == null ? "" : xmlnode.Attributes["F"].Value;
            a.OptionAction2 = xmlnode.Attributes["I"] == null ? "0" : xmlnode.Attributes["I"].Value;
            a.OptionName2 = xmlnode.Attributes["H"] == null ? "" : xmlnode.Attributes["H"].Value;
            a.OptionAction3 = xmlnode.Attributes["K"] == null ? "0" : xmlnode.Attributes["K"].Value;
            a.OptionName3 = xmlnode.Attributes["J"] == null ? "" : xmlnode.Attributes["J"].Value;
            a.OptionAction4 = xmlnode.Attributes["M"] == null ? "0" : xmlnode.Attributes["M"].Value;
            a.OptionName4 = xmlnode.Attributes["L"] == null ? "" : xmlnode.Attributes["L"].Value;
            a.TaskIndex = xmlnode.Attributes["e"] == null
                ? 0
                : int.Parse(xmlnode.Attributes["e"].Value.Substring(12, 2));
            a.Pos = xmlnode.Attributes["E"] == null
                ? ""
                : xmlnode.Attributes["E"].Value.Substring(14, 1) == "1" ? "Left" : "Right";
            a.SpeakerName = xmlnode.Attributes["C"] == null ? "" : xmlnode.Attributes["C"].Value;
            a.SpeakerProfile = xmlnode.Attributes["N"] == null ? "" : xmlnode.Attributes["N"].Value;
            a.Tag = xmlnode.Attributes["B"] == null ? "" : xmlnode.Attributes["B"].Value;
            a.Type = xmlnode.Attributes["A"] == null ? "" : xmlnode.Attributes["A"].Value;
            a.MapID = xmlnode.Attributes["E"] == null ? 0 : int.Parse(xmlnode.Attributes["E"].Value.Substring(0, 2));
            return a;
        }

        private void addTreeNode(XmlNode xmlNode, TreeNode treeNode)
        {
            XmlNode xNode;
            TreeNode tNode;
            XmlNodeList xNodeList;
            if (xmlNode.HasChildNodes)
            {
                xNodeList = xmlNode.ChildNodes;
                for (int x = 0; x <= xNodeList.Count - 1; x++)
                {
                    xNode = xmlNode.ChildNodes[x];
                    treeNode.Nodes.Add(new TreeNode(xNode.Name));
                    tNode = treeNode.Nodes[x];
                    addTreeNode(xNode, tNode);
                    if (xmlNode.Name != "Root")
                    {
                        if (xmlNode.Attributes["B"] != null)
                        {
                            treeNode.Text = xmlNode.Attributes["B"].Value.Trim();
                        }
                        else
                        {
                            treeNode.Text = xmlNode.Name.Trim();
                        }
                        treeNode.Tag = SaveNodeToTag(xmlNode);
                    }
                }
            }
            else
            {
                if (xmlNode.Attributes["B"] != null)
                {
                    treeNode.Text = xmlNode.Attributes["B"].Value.Trim();
                }
                else
                {
                    treeNode.Text = xmlNode.Name.Trim();
                }
                treeNode.Tag = SaveNodeToTag(xmlNode);
            }
        }

        private void TV_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //AttType a = TV.SelectedNode.Tag as AttType;
            //MessageBox.Show(a.Tag + "" + a.Type);

            var OptionList1 = new List<string>();
            var OptionList2 = new List<string>();
            var OptionList3 = new List<string>();
            var OptionList4 = new List<string>();
            try
            {
                TreeNodeCollection nodes = TV.SelectedNode.Parent.Nodes;
                foreach (ICloneable node in nodes)
                {
                    var t = (TreeNode) node.Clone();
                    OptionList1.Add(t.Text);
                    OptionList2.Add(t.Text);
                    OptionList3.Add(t.Text);
                    OptionList4.Add(t.Text);
                }
                cbOption1.DataSource = OptionList1;
                cbOption2.DataSource = OptionList2;
                cbOption3.DataSource = OptionList3;
                cbOption4.DataSource = OptionList4;
            }
            catch (Exception)
            {
            }

            try
            {
                at = TV.SelectedNode.Tag as AttType;
                if (at.Type == "Dialog")
                {
                    txtName.Text = at.SpeakerName.Trim();
                    txtProfileID.Text = at.SpeakerProfile.Trim();
                    if (at.Pos.Trim() == "Left")
                    {
                        cbPos.SelectedIndex = 0;
                    }
                    else
                    {
                        cbPos.SelectedIndex = 1;
                    }
                    txtContent.Text = at.Content.Trim();
                    if (at.IsOption)
                    {
                        cheakBoxIsOption.Checked = true;
                        Option1.Text = at.OptionName1 == null ? "" : at.OptionName1.Trim();
                        Option2.Text = at.OptionName2 == null ? "" : at.OptionName2.Trim();
                        Option3.Text = at.OptionName3 == null ? "" : at.OptionName3.Trim();
                        Option4.Text = at.OptionName4 == null ? "" : at.OptionName4.Trim();
                        cbOption1.SelectedIndex = at.OptionAction1 == null ? 0 : int.Parse(at.OptionAction1);
                        cbOption2.SelectedIndex = at.OptionAction2 == null ? 0 : int.Parse(at.OptionAction2);
                        cbOption3.SelectedIndex = at.OptionAction3 == null ? 0 : int.Parse(at.OptionAction3);
                        cbOption4.SelectedIndex = at.OptionAction4 == null ? 0 : int.Parse(at.OptionAction4);
                        if (!string.IsNullOrEmpty(at.OptionName1))
                        {
                            chbOption1.Checked = true;
                        }
                        else
                        {
                            chbOption1.Checked = false;
                        }
                        if (!string.IsNullOrEmpty(at.OptionName2))
                        {
                            chbOption2.Checked = true;
                        }
                        else
                        {
                            chbOption2.Checked = false;
                        }
                        if (!string.IsNullOrEmpty(at.OptionName3))
                        {
                            chbOption3.Checked = true;
                        }
                        else
                        {
                            chbOption3.Checked = false;
                        }
                        if (!string.IsNullOrEmpty(at.OptionName4))
                        {
                            chbOption4.Checked = true;
                        }
                        else
                        {
                            chbOption4.Checked = false;
                        }
                        if (string.IsNullOrEmpty(Option1.Text))
                        {
                            Option1.Enabled = false;
                            cbOption1.Enabled = false;
                        }
                        else
                        {
                            Option1.Enabled = true;
                            cbOption1.Enabled = true;
                        }
                        if (string.IsNullOrEmpty(Option2.Text))
                        {
                            Option2.Enabled = false;
                            cbOption2.Enabled = false;
                        }
                        else
                        {
                            Option2.Enabled = true;
                            cbOption2.Enabled = true;
                        }
                        if (string.IsNullOrEmpty(Option3.Text))
                        {
                            Option3.Enabled = false;
                            cbOption3.Enabled = false;
                        }
                        else
                        {
                            Option3.Enabled = true;
                            cbOption3.Enabled = true;
                        }
                        if (string.IsNullOrEmpty(Option4.Text))
                        {
                            Option4.Enabled = false;
                            cbOption4.Enabled = false;
                        }
                        else
                        {
                            Option4.Enabled = true;
                            cbOption4.Enabled = true;
                        }
                    }
                    else
                    {
                        cheakBoxIsOption.Checked = false;
                        Option1.Text = null;
                        Option2.Text = null;
                        Option3.Text = null;
                        Option4.Text = null;
                        cbOption1.SelectedIndex = 0;
                        cbOption2.SelectedIndex = 0;
                        cbOption3.SelectedIndex = 0;
                        cbOption4.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception)
            {
                return;
            }
            if (at.Type == "Task")
            {
                btnPreview.Enabled = true;
            }
            else
            {
                btnPreview.Enabled = false;
            }

            //AttType xxx = TV.SelectedNode.Tag as AttType;
            //MessageBox.Show(xxx.Tag + ";" + xxx.Type);
        }

        private void btnAddSubNode_Click(object sender, EventArgs e)
        {
            if (TV.SelectedNode != null)
            {
                string SelectType = "";
                try
                {
                    SelectType = (TV.SelectedNode.Tag as AttType).Type;
                }
                catch (Exception)
                {
                    SelectType = "Root";
                }
                string CurrentType = "";
                TreeNode tr = null;


                switch (SelectType)
                {
                    case "Root":
                        CurrentType = "Map";
                        tr = new TreeNode();
                        tr.Text = "new" + CurrentType;
                        at = new AttType();
                        at.Type = CurrentType;
                        at.Tag = tr.Text;
                        at.MapID = TV.Nodes[0].Nodes.Count;

                        tr.Tag = at;
                        TV.SelectedNode.Nodes.Add(tr);
                        break;
                    case "Map":
                        CurrentType = "Chapter";
                        tr = new TreeNode();
                        tr.Text = "new" + CurrentType;
                        at = new AttType();
                        at.Type = CurrentType;
                        at.PlaceID = TV.SelectedNode.Nodes.Count;
                        at.Tag = tr.Text;
                        at.MapID = (TV.SelectedNode.Tag as AttType).MapID;
                        tr.Tag = at;
                        TV.SelectedNode.Nodes.Add(tr);
                        break;
                    case "Chapter":
                        CurrentType = "Level";
                        tr = new TreeNode();
                        tr.Text = "new" + CurrentType;
                        at = new AttType();
                        at.Type = CurrentType;
                        at.TaskID = TV.SelectedNode.Nodes.Count;
                        at.Tag = tr.Text;
                        at.MapID = (TV.SelectedNode.Tag as AttType).MapID;
                        at.PlaceID = (TV.SelectedNode.Tag as AttType).PlaceID;
                        tr.Tag = at;
                        TV.SelectedNode.Nodes.Add(tr);
                        break;
                    case "Level":
                        CurrentType = "Difficulty";
                        tr = new TreeNode();
                        tr.Text = "new" + CurrentType;
                        at = new AttType();
                        at.Type = CurrentType;
                        at.DifficultyID = TV.SelectedNode.Nodes.Count;
                        at.Tag = tr.Text;
                        at.MapID = (TV.SelectedNode.Tag as AttType).MapID;
                        at.PlaceID = (TV.SelectedNode.Tag as AttType).PlaceID;
                        at.TaskID = (TV.SelectedNode.Tag as AttType).TaskID;
                        tr.Tag = at;
                        TV.SelectedNode.Nodes.Add(tr);
                        break;
                    case "Difficulty":
                        CurrentType = "Actor";
                        tr = new TreeNode();
                        tr.Text = "new" + CurrentType;
                        at = new AttType();
                        at.Type = CurrentType;
                        at.ActorID = TV.SelectedNode.Nodes.Count;
                        at.Tag = tr.Text;
                        at.MapID = (TV.SelectedNode.Tag as AttType).MapID;
                        at.PlaceID = (TV.SelectedNode.Tag as AttType).PlaceID;
                        at.TaskID = (TV.SelectedNode.Tag as AttType).TaskID;
                        at.DifficultyID = (TV.SelectedNode.Tag as AttType).DifficultyID;
                        tr.Tag = at;
                        TV.SelectedNode.Nodes.Add(tr);
                        break;
                    case "Actor":
                        CurrentType = "Unform";
                        tr = new TreeNode();
                        tr.Text = "new" + CurrentType;
                        at = new AttType();
                        at.Type = CurrentType;
                        at.ObjectID = TV.SelectedNode.Nodes.Count;
                        at.Tag = tr.Text;
                        at.MapID = (TV.SelectedNode.Tag as AttType).MapID;
                        at.PlaceID = (TV.SelectedNode.Tag as AttType).PlaceID;
                        at.TaskID = (TV.SelectedNode.Tag as AttType).TaskID;
                        at.DifficultyID = (TV.SelectedNode.Tag as AttType).DifficultyID;
                        at.ActorID = (TV.SelectedNode.Tag as AttType).DifficultyID;
                        tr.Tag = at;
                        TV.SelectedNode.Nodes.Add(tr);
                        break;
                    case "Unform":
                        CurrentType = "Task";
                        tr = new TreeNode();
                        tr.Text = "new" + CurrentType;
                        at = new AttType();
                        at.Type = CurrentType;
                        at.TaskIndex = TV.SelectedNode.Nodes.Count;
                        at.Tag = tr.Text;
                        at.MapID = (TV.SelectedNode.Tag as AttType).MapID;
                        at.PlaceID = (TV.SelectedNode.Tag as AttType).PlaceID;
                        at.TaskID = (TV.SelectedNode.Tag as AttType).TaskID;
                        at.DifficultyID = (TV.SelectedNode.Tag as AttType).DifficultyID;
                        at.ActorID = (TV.SelectedNode.Tag as AttType).DifficultyID;
                        at.ObjectID = (TV.SelectedNode.Tag as AttType).ObjectID;
                        tr.Tag = at;
                        TV.SelectedNode.Nodes.Add(tr);
                        break;
                    case "Task":
                        CurrentType = "Dialog";
                        tr = new TreeNode();
                        tr.Text = "new" + CurrentType;
                        at = new AttType();
                        at.Type = CurrentType;
                        at.Tag = tr.Text;
                        at.MapID = (TV.SelectedNode.Tag as AttType).MapID;
                        at.PlaceID = (TV.SelectedNode.Tag as AttType).PlaceID;
                        at.TaskID = (TV.SelectedNode.Tag as AttType).TaskID;
                        at.DifficultyID = (TV.SelectedNode.Tag as AttType).DifficultyID;
                        at.ActorID = (TV.SelectedNode.Tag as AttType).DifficultyID;
                        at.ObjectID = (TV.SelectedNode.Tag as AttType).ObjectID;
                        at.TaskIndex = (TV.SelectedNode.Tag as AttType).TaskIndex;
                        tr.Tag = at;
                        TV.SelectedNode.Nodes.Add(tr);
                        break;
                    default:
                        break;
                }
                TV.SelectedNode.Expand();
            }
        }


        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TV_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
        }


        private void chbOption1_CheckedChanged(object sender, EventArgs e)
        {
            if (cheakBoxIsOption.Checked)
            {
                if (chbOption1.Checked)
                {
                    Option1.Enabled = true;
                    cbOption1.Enabled = true;
                }
                else
                {
                    Option1.Enabled = false;
                    cbOption1.Enabled = false;
                }
            }
        }

        private void chbOption2_CheckedChanged(object sender, EventArgs e)
        {
            if (cheakBoxIsOption.Checked)
            {
                if (chbOption2.Checked)
                {
                    Option2.Enabled = true;
                    cbOption2.Enabled = true;
                }
                else
                {
                    Option2.Enabled = false;
                    cbOption2.Enabled = false;
                }
            }
        }

        private void chbOption3_CheckedChanged(object sender, EventArgs e)
        {
            if (cheakBoxIsOption.Checked)
            {
                if (chbOption3.Checked)
                {
                    Option3.Enabled = true;
                    cbOption3.Enabled = true;
                }
                else
                {
                    Option3.Enabled = false;
                    cbOption3.Enabled = false;
                }
            }
        }

        private void chbOption4_CheckedChanged(object sender, EventArgs e)
        {
            if (cheakBoxIsOption.Checked)
            {
                if (chbOption4.Checked)
                {
                    Option4.Enabled = true;
                    cbOption4.Enabled = true;
                }
                else
                {
                    Option4.Enabled = false;
                    cbOption4.Enabled = false;
                }
            }
        }

        private void cheakBoxIsOption_CheckedChanged(object sender, EventArgs e)
        {
            if (cheakBoxIsOption.Checked)
            {
                Option1.Enabled = true;
                cbOption1.Enabled = true;
                Option2.Enabled = true;
                cbOption2.Enabled = true;
                Option3.Enabled = true;
                cbOption3.Enabled = true;
                Option4.Enabled = true;
                cbOption4.Enabled = true;
            }
            else
            {
                Option1.Enabled = false;
                cbOption1.Enabled = false;
                Option2.Enabled = false;
                cbOption2.Enabled = false;
                Option3.Enabled = false;
                cbOption3.Enabled = false;
                Option4.Enabled = false;
                cbOption4.Enabled = false;
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("是否保存？", "保存", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {
                SaveXML();
                Close();
            }
            else if (result == DialogResult.No)
            {
                Close();
            }
            else
            {
            }
        }

        private void btnDeleteNode_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("OK to delete it？", "Delete", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {
                TV.SelectedNode.Remove();
            }

            else
            {
            }
        }

        private void TV_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            TreeNode tn = TV.SelectedNode;
            var att = TV.SelectedNode.Tag as AttType;
            try
            {
                att.Tag = e.Label.Trim();
            }
            catch (Exception)
            {
            }
            tn.Tag = att;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var a = TV.SelectedNode.Tag as AttType;
                a.IsOption = cheakBoxIsOption.Checked;
                a.Content = txtContent.Text;
                a.OptionAction1 = cbOption1.SelectedIndex.ToString();
                a.OptionName1 = Option1.Text;
                a.OptionAction2 = cbOption2.SelectedIndex.ToString();
                a.OptionName2 = Option2.Text;
                a.OptionAction3 = cbOption3.SelectedIndex.ToString();
                a.OptionName3 = Option3.Text;
                a.OptionAction4 = cbOption4.SelectedIndex.ToString();
                a.OptionName4 = Option4.Text;
                a.Pos = cbPos.SelectedIndex == 0 ? "Left" : "Right";
                a.SpeakerName = txtName.Text;
                a.SpeakerProfile = txtProfileID.Text;
                TV.SelectedNode.Tag = a;
                SaveXML();
            }
            catch (Exception)
            {
                SaveXML();
            }
        }

        public void SaveXML()
        {
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;
            string path = txtXMLPath.Text;
            var tex = new TreeExXMLCls();
            try
            {
                tex.TreeToXML(TV, path);
                MessageBox.Show("Saved successfully！");
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to save！");
            }
        }

        private void btnNewFile_Click(object sender, EventArgs e)
        {
            var sf = new SaveFileDialog();
            sf.Filter = "XMLFile(*.xml)|*.xml|All files(*.*)|*.*";
            if (sf.ShowDialog() == DialogResult.OK)
            {
                var streamWriter = new StreamWriter(sf.FileName);
                streamWriter.WriteLine("<?xml version=\"1.0\"?>");
                streamWriter.WriteLine(
                    "<Root A=\"Root\" B=\"Root\" Info=\"\" N=\"Default\"  C=\"Default\" D=\"Default\"  F=\"Default\" G=\"Default\" H=\"Default\" I=\"Default\" J=\"Default\" K=\"Default\" L=\"Default\" M=\"Default\">");
                streamWriter.WriteLine("</Root>");
                streamWriter.Close();
                MessageBox.Show("Generate success! Automatically loaded!");
                var xDoc = new XmlDocument();
                xDoc.Load(sf.FileName);
                TV.Nodes.Clear();
                var tn = new TreeNode(xDoc.DocumentElement.Name);
                AttType at = SaveNodeToTag(xDoc.DocumentElement);

                tn.Tag = at;
                TV.Nodes.Add(tn);

                var tNode = new TreeNode();
                tNode = TV.Nodes[0];

                addTreeNode(xDoc.DocumentElement, tNode);
                txtXMLPath.Text = sf.FileName;
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            var f = new Preview(TV.SelectedNode);
            f.Show();
        }

        private void 主窗口_Click(object sender, EventArgs e)
        {
        }

        private void TV_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            try
            {
                at = TV.SelectedNode.Tag as AttType;

                if (at != null && at.Type == "Dialog")
                {
                    at.SpeakerName = txtName.Text.Trim();
                    at.SpeakerProfile = txtProfileID.Text.Trim();
                    if (cbPos.SelectedIndex == 0)
                    {
                        at.Pos = "Left";
                    }
                    else
                    {
                        at.Pos = "Right";
                    }
                    at.Content = txtContent.Text.Trim();
                    if (cheakBoxIsOption.Checked)
                    {
                        at.IsOption = true;
                        if (chbOption1.Checked)
                        {
                            at.OptionName1 = Option1.Text.Trim();
                            at.OptionAction1 = cbOption1.SelectedIndex.ToString();
                        }
                        else
                        {
                            at.OptionName1 = null;
                            at.OptionAction1 = null;
                        }
                        if (chbOption2.Checked)
                        {
                            at.OptionName2 = Option2.Text.Trim();
                            at.OptionAction2 = cbOption2.SelectedIndex.ToString();
                        }
                        else
                        {
                            at.OptionName2 = null;
                            at.OptionAction2 = null;
                        }
                        if (chbOption3.Checked)
                        {
                            at.OptionName3 = Option3.Text.Trim();
                            at.OptionAction3 = cbOption3.SelectedIndex.ToString();
                        }
                        else
                        {
                            at.OptionName3 = null;
                            at.OptionAction3 = null;
                        }
                        if (chbOption4.Checked)
                        {
                            at.OptionName4 = Option4.Text.Trim();
                            at.OptionAction4 = cbOption4.SelectedIndex.ToString();
                        }
                        else
                        {
                            at.OptionName4 = null;
                            at.OptionAction4 = null;
                        }
                    }
                    else
                    {
                        at.IsOption = false;
                        at.OptionName1 = null;
                        at.OptionAction1 = null;
                        at.OptionName2 = null;
                        at.OptionAction2 = null;
                        at.OptionName3 = null;
                        at.OptionAction3 = null;
                        at.OptionName4 = null;
                        at.OptionAction4 = null;
                    }
                    try
                    {
                        at.Tag = (TV.SelectedNode.Tag as AttType).Tag;
                    }
                    catch (Exception)
                    {
                        at.Tag = at.Tag;
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void Dialog_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                string DropPath = ((Array) e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
                txtXMLPath.Text = DropPath;
                var xDoc = new XmlDocument();
                xDoc.Load(txtXMLPath.Text);
                TV.Nodes.Clear();
                var tn = new TreeNode(xDoc.DocumentElement.Name);
                AttType at = SaveNodeToTag(xDoc.DocumentElement);

                tn.Tag = at;
                TV.Nodes.Add(tn);

                var tNode = new TreeNode();
                tNode = TV.Nodes[0];

                addTreeNode(xDoc.DocumentElement, tNode);
                //TV.ExpandAll();
                MessageBox.Show("Loaded successfully！");
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "The script file is not valid! The script file you want to get the standards, please click the New XML File button！");
            }
        }


        private void Dialog_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Link;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }


        private void TV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                TV.SelectedNode.BeginEdit();
            }
        }

        private void TV_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.White, e.Node.Bounds);
            if (e.State == TreeNodeStates.Selected)
            {
                e.Graphics.FillRectangle(Brushes.DodgerBlue,
                    new Rectangle(e.Node.Bounds.Left, e.Node.Bounds.Top, e.Node.Bounds.Width, e.Node.Bounds.Height));
                e.Graphics.DrawString(e.Node.Text, TV.Font, Brushes.White, e.Bounds);         
            }
            else
            {
                e.DrawDefault = true;
            }
        }

        private void btnAddNode_Click(object sender, EventArgs e)
        {
            var tn = new TreeNode();
            Object a = TV.SelectedNode.Tag;
            using (Stream objectStream = new MemoryStream())
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(objectStream, TV.SelectedNode.Clone());
                objectStream.Seek(0, SeekOrigin.Begin);
                tn = formatter.Deserialize(objectStream) as TreeNode;
            }
            using (Stream objectStream = new MemoryStream())
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(objectStream, a);
                objectStream.Seek(0, SeekOrigin.Begin);
                a = formatter.Deserialize(objectStream);
            }
            tn.Tag = a;
            TV.SelectedNode.Parent.Nodes.Insert(TV.SelectedNode.Index + 1, tn);
        }

        private void NewchildnodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAddSubNode_Click(sender, e);
        }

        private void AddsubnodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAddNode_Click(sender, e);
        }

        private void DeletenodesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnDeleteNode_Click(sender, e);
        }

        [Serializable]
        public class AttType
        {
            public int ActorID = 0;
            public string Content = "Default";
            public int DifficultyID = 0;
            public bool IsOption = false;
            public int MapID = 0;
            public int ObjectID = 0;
            public string OptionAction1 = null;
            public string OptionAction2 = null;
            public string OptionAction3 = null;
            public string OptionAction4 = null;
            public string OptionName1 = null;
            public string OptionName2 = null;
            public string OptionName3 = null;
            public string OptionName4 = null;
            public int PlaceID = 0;
            public string Pos = "Default";
            public string SpeakerName = "Default";
            public string SpeakerProfile = "Default";
            public string Tag = "Default";
            public int TaskID = 0;
            public int TaskIndex = 0;
            public string Type = "Default";
        }

        private void btnRole_Click(object sender, EventArgs e)
        {
            txtRole.Text.ToString();
             TextBox textBox = txtRole;
            if (txtRole.Text.Length == 0)
            {
                MessageBox.Show("Can't not be empty");
            }
            else
            {
                txtRole.Text = textBox.ToString(); 
            }

            cbPos.Items.Add(textBox);
        }
    }
}