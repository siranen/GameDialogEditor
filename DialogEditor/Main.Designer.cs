namespace DialogEditor
{
    partial class Dialog
    {
        /// <summary>
        
        /// </summary>
       private System.ComponentModel.IContainer components = null;

        /// <summary>
        
        /// </summary>
        /// <param name="disposing"> false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
      
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.TV = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.NewchildnodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddsubnodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeletenodesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSeleteXML = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnDeleteNode = new System.Windows.Forms.Button();
            this.btnAddNode = new System.Windows.Forms.Button();
            this.btnAddSubNode = new System.Windows.Forms.Button();
            this.txtRole = new System.Windows.Forms.TextBox();
            this.btnRole = new System.Windows.Forms.Button();
            this.btnNewFile = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.剧情 = new System.Windows.Forms.GroupBox();
            this.Option4 = new System.Windows.Forms.TextBox();
            this.Option3 = new System.Windows.Forms.TextBox();
            this.Option2 = new System.Windows.Forms.TextBox();
            this.Option1 = new System.Windows.Forms.TextBox();
            this.cheakBoxIsOption = new System.Windows.Forms.CheckBox();
            this.txtProfileID = new System.Windows.Forms.TextBox();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.cbPos = new System.Windows.Forms.ComboBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbOption4 = new System.Windows.Forms.ComboBox();
            this.cbOption3 = new System.Windows.Forms.ComboBox();
            this.cbOption2 = new System.Windows.Forms.ComboBox();
            this.cbOption1 = new System.Windows.Forms.ComboBox();
            this.chbOption2 = new System.Windows.Forms.CheckBox();
            this.chbOption4 = new System.Windows.Forms.CheckBox();
            this.chbOption3 = new System.Windows.Forms.CheckBox();
            this.chbOption1 = new System.Windows.Forms.CheckBox();
            this.txtXMLPath = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.剧情.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TV
            // 
            this.TV.ContextMenuStrip = this.contextMenuStrip1;
            this.TV.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TV.LabelEdit = true;
            this.TV.Location = new System.Drawing.Point(0, 39);
            this.TV.Name = "TV";
            this.TV.Size = new System.Drawing.Size(299, 640);
            this.TV.TabIndex = 0;
            this.TV.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.TV_AfterLabelEdit);
            this.TV.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.TV_DrawNode);
            this.TV.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.TV_BeforeSelect);
            this.TV.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TV_AfterSelect);
            this.TV.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TV_NodeMouseClick);
            this.TV.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TV_KeyDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewchildnodeToolStripMenuItem,
            this.AddsubnodeToolStripMenuItem,
            this.DeletenodesToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(152, 70);
            // 
            // NewchildnodeToolStripMenuItem
            // 
            this.NewchildnodeToolStripMenuItem.Name = "NewchildnodeToolStripMenuItem";
            this.NewchildnodeToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.NewchildnodeToolStripMenuItem.Text = "Newchildnode";
            this.NewchildnodeToolStripMenuItem.Click += new System.EventHandler(this.NewchildnodeToolStripMenuItem_Click);
            // 
            // AddsubnodeToolStripMenuItem
            // 
            this.AddsubnodeToolStripMenuItem.Name = "AddsubnodeToolStripMenuItem";
            this.AddsubnodeToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.AddsubnodeToolStripMenuItem.Text = "AddSubNode";
            this.AddsubnodeToolStripMenuItem.Click += new System.EventHandler(this.AddsubnodeToolStripMenuItem_Click);
            // 
            // DeletenodesToolStripMenuItem
            // 
            this.DeletenodesToolStripMenuItem.Name = "DeletenodesToolStripMenuItem";
            this.DeletenodesToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.DeletenodesToolStripMenuItem.Text = "删除节点";
            this.DeletenodesToolStripMenuItem.Click += new System.EventHandler(this.DeletenodesToolStripMenuItem_Click);
            // 
            // btnSeleteXML
            // 
            this.btnSeleteXML.Location = new System.Drawing.Point(221, 10);
            this.btnSeleteXML.Name = "btnSeleteXML";
            this.btnSeleteXML.Size = new System.Drawing.Size(75, 25);
            this.btnSeleteXML.TabIndex = 2;
            this.btnSeleteXML.Text = "Select XML";
            this.btnSeleteXML.UseVisualStyleBackColor = true;
            this.btnSeleteXML.Click += new System.EventHandler(this.btnLoadXML_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnDeleteNode);
            this.splitContainer1.Panel1.Controls.Add(this.btnAddNode);
            this.splitContainer1.Panel1.Controls.Add(this.btnAddSubNode);
            this.splitContainer1.Panel1.Controls.Add(this.TV);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtRole);
            this.splitContainer1.Panel2.Controls.Add(this.btnRole);
            this.splitContainer1.Panel2.Controls.Add(this.btnNewFile);
            this.splitContainer1.Panel2.Controls.Add(this.btnPreview);
            this.splitContainer1.Panel2.Controls.Add(this.btnQuit);
            this.splitContainer1.Panel2.Controls.Add(this.btnSave);
            this.splitContainer1.Panel2.Controls.Add(this.剧情);
            this.splitContainer1.Panel2.Controls.Add(this.txtXMLPath);
            this.splitContainer1.Panel2.Controls.Add(this.btnSeleteXML);
            this.splitContainer1.Size = new System.Drawing.Size(897, 679);
            this.splitContainer1.SplitterDistance = 299;
            this.splitContainer1.TabIndex = 3;
            // 
            // btnDeleteNode
            // 
            this.btnDeleteNode.Location = new System.Drawing.Point(203, 0);
            this.btnDeleteNode.Name = "btnDeleteNode";
            this.btnDeleteNode.Size = new System.Drawing.Size(96, 40);
            this.btnDeleteNode.TabIndex = 1;
            this.btnDeleteNode.Text = "DeleteNode";
            this.btnDeleteNode.UseVisualStyleBackColor = true;
            this.btnDeleteNode.Click += new System.EventHandler(this.btnDeleteNode_Click);
            // 
            // btnAddNode
            // 
            this.btnAddNode.Location = new System.Drawing.Point(102, 0);
            this.btnAddNode.Name = "btnAddNode";
            this.btnAddNode.Size = new System.Drawing.Size(96, 40);
            this.btnAddNode.TabIndex = 1;
            this.btnAddNode.Text = "AddNode";
            this.btnAddNode.UseVisualStyleBackColor = true;
            this.btnAddNode.Click += new System.EventHandler(this.btnAddNode_Click);
            // 
            // btnAddSubNode
            // 
            this.btnAddSubNode.Location = new System.Drawing.Point(0, 0);
            this.btnAddSubNode.Name = "btnAddSubNode";
            this.btnAddSubNode.Size = new System.Drawing.Size(96, 40);
            this.btnAddSubNode.TabIndex = 1;
            this.btnAddSubNode.Text = "AddSubNode";
            this.btnAddSubNode.UseVisualStyleBackColor = true;
            this.btnAddSubNode.Click += new System.EventHandler(this.btnAddSubNode_Click);
            // 
            // txtRole
            // 
            this.txtRole.Location = new System.Drawing.Point(393, 13);
            this.txtRole.Name = "txtRole";
            this.txtRole.Size = new System.Drawing.Size(100, 20);
            this.txtRole.TabIndex = 13;
            // 
            // btnRole
            // 
            this.btnRole.Location = new System.Drawing.Point(311, 10);
            this.btnRole.Name = "btnRole";
            this.btnRole.Size = new System.Drawing.Size(75, 25);
            this.btnRole.TabIndex = 12;
            this.btnRole.Text = "Add Role";
            this.btnRole.UseVisualStyleBackColor = true;
            this.btnRole.Click += new System.EventHandler(this.btnRole_Click);
            // 
            // btnNewFile
            // 
            this.btnNewFile.Location = new System.Drawing.Point(104, 10);
            this.btnNewFile.Name = "btnNewFile";
            this.btnNewFile.Size = new System.Drawing.Size(111, 25);
            this.btnNewFile.TabIndex = 11;
            this.btnNewFile.Text = "New File";
            this.btnNewFile.UseVisualStyleBackColor = true;
            this.btnNewFile.Click += new System.EventHandler(this.btnNewFile_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Enabled = false;
            this.btnPreview.Location = new System.Drawing.Point(50, 558);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 25);
            this.btnPreview.TabIndex = 6;
            this.btnPreview.Text = "Preview";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(465, 558);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(75, 25);
            this.btnQuit.TabIndex = 5;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(375, 558);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // 剧情
            // 
            this.剧情.Controls.Add(this.Option4);
            this.剧情.Controls.Add(this.Option3);
            this.剧情.Controls.Add(this.Option2);
            this.剧情.Controls.Add(this.Option1);
            this.剧情.Controls.Add(this.cheakBoxIsOption);
            this.剧情.Controls.Add(this.txtProfileID);
            this.剧情.Controls.Add(this.txtContent);
            this.剧情.Controls.Add(this.cbPos);
            this.剧情.Controls.Add(this.txtName);
            this.剧情.Controls.Add(this.label12);
            this.剧情.Controls.Add(this.label11);
            this.剧情.Controls.Add(this.label10);
            this.剧情.Controls.Add(this.label9);
            this.剧情.Controls.Add(this.label3);
            this.剧情.Controls.Add(this.label2);
            this.剧情.Controls.Add(this.label4);
            this.剧情.Controls.Add(this.label1);
            this.剧情.Controls.Add(this.groupBox1);
            this.剧情.Location = new System.Drawing.Point(28, 61);
            this.剧情.Name = "剧情";
            this.剧情.Size = new System.Drawing.Size(537, 469);
            this.剧情.TabIndex = 4;
            this.剧情.TabStop = false;
            this.剧情.Text = "Story";
            // 
            // Option4
            // 
            this.Option4.Enabled = false;
            this.Option4.Location = new System.Drawing.Point(426, 363);
            this.Option4.Name = "Option4";
            this.Option4.Size = new System.Drawing.Size(60, 20);
            this.Option4.TabIndex = 7;
            // 
            // Option3
            // 
            this.Option3.Enabled = false;
            this.Option3.Location = new System.Drawing.Point(292, 363);
            this.Option3.Name = "Option3";
            this.Option3.Size = new System.Drawing.Size(60, 20);
            this.Option3.TabIndex = 7;
            // 
            // Option2
            // 
            this.Option2.Enabled = false;
            this.Option2.Location = new System.Drawing.Point(167, 363);
            this.Option2.Name = "Option2";
            this.Option2.Size = new System.Drawing.Size(60, 20);
            this.Option2.TabIndex = 7;
            // 
            // Option1
            // 
            this.Option1.Enabled = false;
            this.Option1.Location = new System.Drawing.Point(49, 363);
            this.Option1.Name = "Option1";
            this.Option1.Size = new System.Drawing.Size(60, 20);
            this.Option1.TabIndex = 7;
            // 
            // cheakBoxIsOption
            // 
            this.cheakBoxIsOption.AutoSize = true;
            this.cheakBoxIsOption.Location = new System.Drawing.Point(22, 302);
            this.cheakBoxIsOption.Name = "cheakBoxIsOption";
            this.cheakBoxIsOption.Size = new System.Drawing.Size(124, 17);
            this.cheakBoxIsOption.TabIndex = 6;
            this.cheakBoxIsOption.Text = "There are no options";
            this.cheakBoxIsOption.UseVisualStyleBackColor = true;
            this.cheakBoxIsOption.CheckedChanged += new System.EventHandler(this.cheakBoxIsOption_CheckedChanged);
            // 
            // txtProfileID
            // 
            this.txtProfileID.Location = new System.Drawing.Point(318, 30);
            this.txtProfileID.Name = "txtProfileID";
            this.txtProfileID.Size = new System.Drawing.Size(100, 20);
            this.txtProfileID.TabIndex = 4;
            // 
            // txtContent
            // 
            this.txtContent.Location = new System.Drawing.Point(97, 114);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(419, 147);
            this.txtContent.TabIndex = 3;
            // 
            // cbPos
            // 
            this.cbPos.FormattingEnabled = true;
            this.cbPos.Items.AddRange(new object[] {
            "NPC",
            "Crafter",
            "Musician"});
            this.cbPos.Location = new System.Drawing.Point(97, 69);
            this.cbPos.Name = "cbPos";
            this.cbPos.Size = new System.Drawing.Size(121, 21);
            this.cbPos.TabIndex = 2;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(97, 30);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 20);
            this.txtName.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(423, 400);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Next Steps";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(290, 400);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Next Steps";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(165, 400);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Next Steps";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(47, 400);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Next Steps";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Conversation:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Role:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(242, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Avatar name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Speaker Name:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbOption4);
            this.groupBox1.Controls.Add(this.cbOption3);
            this.groupBox1.Controls.Add(this.cbOption2);
            this.groupBox1.Controls.Add(this.cbOption1);
            this.groupBox1.Controls.Add(this.chbOption2);
            this.groupBox1.Controls.Add(this.chbOption4);
            this.groupBox1.Controls.Add(this.chbOption3);
            this.groupBox1.Controls.Add(this.chbOption1);
            this.groupBox1.Location = new System.Drawing.Point(18, 277);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(498, 185);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // cbOption4
            // 
            this.cbOption4.FormattingEnabled = true;
            this.cbOption4.Location = new System.Drawing.Point(408, 146);
            this.cbOption4.Name = "cbOption4";
            this.cbOption4.Size = new System.Drawing.Size(60, 21);
            this.cbOption4.TabIndex = 12;
            // 
            // cbOption3
            // 
            this.cbOption3.FormattingEnabled = true;
            this.cbOption3.Location = new System.Drawing.Point(274, 146);
            this.cbOption3.Name = "cbOption3";
            this.cbOption3.Size = new System.Drawing.Size(60, 21);
            this.cbOption3.TabIndex = 12;
            // 
            // cbOption2
            // 
            this.cbOption2.FormattingEnabled = true;
            this.cbOption2.Location = new System.Drawing.Point(149, 146);
            this.cbOption2.Name = "cbOption2";
            this.cbOption2.Size = new System.Drawing.Size(60, 21);
            this.cbOption2.TabIndex = 12;
            // 
            // cbOption1
            // 
            this.cbOption1.FormattingEnabled = true;
            this.cbOption1.Location = new System.Drawing.Point(31, 146);
            this.cbOption1.Name = "cbOption1";
            this.cbOption1.Size = new System.Drawing.Size(60, 21);
            this.cbOption1.TabIndex = 12;
            // 
            // chbOption2
            // 
            this.chbOption2.AutoSize = true;
            this.chbOption2.Checked = true;
            this.chbOption2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbOption2.Location = new System.Drawing.Point(149, 62);
            this.chbOption2.Name = "chbOption2";
            this.chbOption2.Size = new System.Drawing.Size(66, 17);
            this.chbOption2.TabIndex = 0;
            this.chbOption2.Text = "Option 2";
            this.chbOption2.UseVisualStyleBackColor = true;
            this.chbOption2.CheckedChanged += new System.EventHandler(this.chbOption2_CheckedChanged);
            // 
            // chbOption4
            // 
            this.chbOption4.AutoSize = true;
            this.chbOption4.Checked = true;
            this.chbOption4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbOption4.Location = new System.Drawing.Point(408, 62);
            this.chbOption4.Name = "chbOption4";
            this.chbOption4.Size = new System.Drawing.Size(66, 17);
            this.chbOption4.TabIndex = 0;
            this.chbOption4.Text = "Option 3";
            this.chbOption4.UseVisualStyleBackColor = true;
            this.chbOption4.CheckedChanged += new System.EventHandler(this.chbOption4_CheckedChanged);
            // 
            // chbOption3
            // 
            this.chbOption3.AutoSize = true;
            this.chbOption3.Checked = true;
            this.chbOption3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbOption3.Location = new System.Drawing.Point(274, 62);
            this.chbOption3.Name = "chbOption3";
            this.chbOption3.Size = new System.Drawing.Size(66, 17);
            this.chbOption3.TabIndex = 0;
            this.chbOption3.Text = "Option 3";
            this.chbOption3.UseVisualStyleBackColor = true;
            this.chbOption3.CheckedChanged += new System.EventHandler(this.chbOption3_CheckedChanged);
            // 
            // chbOption1
            // 
            this.chbOption1.AutoSize = true;
            this.chbOption1.Checked = true;
            this.chbOption1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbOption1.Location = new System.Drawing.Point(31, 62);
            this.chbOption1.Name = "chbOption1";
            this.chbOption1.Size = new System.Drawing.Size(66, 17);
            this.chbOption1.TabIndex = 0;
            this.chbOption1.Text = "Option 1";
            this.chbOption1.UseVisualStyleBackColor = true;
            this.chbOption1.CheckedChanged += new System.EventHandler(this.chbOption1_CheckedChanged);
            // 
            // txtXMLPath
            // 
            this.txtXMLPath.Location = new System.Drawing.Point(28, 13);
            this.txtXMLPath.Name = "txtXMLPath";
            this.txtXMLPath.Size = new System.Drawing.Size(61, 20);
            this.txtXMLPath.TabIndex = 3;
            this.txtXMLPath.Visible = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "XML文件(*.xml)|*.xml|All files(*.*)|*.*";
            // 
            // Dialog
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 679);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Dialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dialog";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Click += new System.EventHandler(this.主窗口_Click);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Dialog_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Dialog_DragEnter);
            this.contextMenuStrip1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.剧情.ResumeLayout(false);
            this.剧情.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView TV;
        private System.Windows.Forms.Button btnSeleteXML;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txtXMLPath;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnDeleteNode;
        private System.Windows.Forms.Button btnAddNode;
        private System.Windows.Forms.Button btnAddSubNode;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox 剧情;
        private System.Windows.Forms.TextBox Option4;
        private System.Windows.Forms.TextBox Option3;
        private System.Windows.Forms.TextBox Option2;
        private System.Windows.Forms.TextBox Option1;
        private System.Windows.Forms.CheckBox cheakBoxIsOption;
        private System.Windows.Forms.TextBox txtProfileID;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.ComboBox cbPos;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.CheckBox chbOption2;
        private System.Windows.Forms.CheckBox chbOption4;
        private System.Windows.Forms.CheckBox chbOption3;
        private System.Windows.Forms.CheckBox chbOption1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnNewFile;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem NewchildnodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddsubnodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeletenodesToolStripMenuItem;
        private System.Windows.Forms.ComboBox cbOption1;
        private System.Windows.Forms.ComboBox cbOption4;
        private System.Windows.Forms.ComboBox cbOption3;
        private System.Windows.Forms.ComboBox cbOption2;
        private System.Windows.Forms.Button btnRole;
        private System.Windows.Forms.TextBox txtRole;


    }
}

