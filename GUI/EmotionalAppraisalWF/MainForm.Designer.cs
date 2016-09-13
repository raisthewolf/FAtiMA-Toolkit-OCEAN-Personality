﻿namespace EmotionalAppraisalWF
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			this.mainFormTab = new System.Windows.Forms.TabControl();
			this.emotionalStateTabPage = new System.Windows.Forms.TabPage();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.richTextBoxDescription = new System.Windows.Forms.RichTextBox();
			this.groupBox9 = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.textBoxPerspective = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.moodGroupBox = new System.Windows.Forms.GroupBox();
			this.moodValueLabel = new System.Windows.Forms.Label();
			this.moodTrackBar = new System.Windows.Forms.TrackBar();
			this.emotionGroupBox = new System.Windows.Forms.GroupBox();
			this.buttonEditEmotion = new System.Windows.Forms.Button();
			this.addEmotionButton = new System.Windows.Forms.Button();
			this.buttonRemoveEmotion = new System.Windows.Forms.Button();
			this.emotionsDataGridView = new System.Windows.Forms.DataGridView();
			this.emotionDispositionTabPage = new System.Windows.Forms.TabPage();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.comboBoxDefaultThreshold = new System.Windows.Forms.ComboBox();
			this.comboBoxDefaultDecay = new System.Windows.Forms.ComboBox();
			this.label10 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.dataGridViewEmotionDispositions = new System.Windows.Forms.DataGridView();
			this.buttonEditEmotionDisposition = new System.Windows.Forms.Button();
			this.buttonAddEmotionDisposition = new System.Windows.Forms.Button();
			this.buttonRemoveEmotionDisposition = new System.Windows.Forms.Button();
			this.appraisalRulesTagePage = new System.Windows.Forms.TabPage();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.groupBox7 = new System.Windows.Forms.GroupBox();
			this.buttonEditAppraisalRule = new System.Windows.Forms.Button();
			this.buttonAddAppraisalRule = new System.Windows.Forms.Button();
			this.buttonRemoveAppraisalRule = new System.Windows.Forms.Button();
			this.dataGridViewAppraisalRules = new System.Windows.Forms.DataGridView();
			this.groupBox8 = new System.Windows.Forms.GroupBox();
			this.conditionSetEditor = new GAIPS.AssetEditorTools.ConditionSetEditorControl();
			this.knowledgeBaseTabPage = new System.Windows.Forms.TabPage();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.dataGridViewBeliefs = new System.Windows.Forms.DataGridView();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.editButton = new System.Windows.Forms.Button();
			this.addBeliefButton = new System.Windows.Forms.Button();
			this.removeBeliefButton = new System.Windows.Forms.Button();
			this.autobiographicalMemoryTabPage = new System.Windows.Forms.TabPage();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.dataGridViewAM = new System.Windows.Forms.DataGridView();
			this.buttonEditEvent = new System.Windows.Forms.Button();
			this.buttonAddEventRecord = new System.Windows.Forms.Button();
			this.buttonRemoveEventRecord = new System.Windows.Forms.Button();
			this.decayErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.emotionListItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.mainFormBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.StartTickField = new System.Windows.Forms.NumericUpDown();
			this.mainFormTab.SuspendLayout();
			this.emotionalStateTabPage.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox9.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.moodGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.moodTrackBar)).BeginInit();
			this.emotionGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.emotionsDataGridView)).BeginInit();
			this.emotionDispositionTabPage.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.groupBox5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmotionDispositions)).BeginInit();
			this.appraisalRulesTagePage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.groupBox7.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewAppraisalRules)).BeginInit();
			this.groupBox8.SuspendLayout();
			this.knowledgeBaseTabPage.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewBeliefs)).BeginInit();
			this.tableLayoutPanel2.SuspendLayout();
			this.autobiographicalMemoryTabPage.SuspendLayout();
			this.groupBox4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewAM)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.decayErrorProvider)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emotionListItemBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.mainFormBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.StartTickField)).BeginInit();
			this.SuspendLayout();
			// 
			// mainFormTab
			// 
			this.mainFormTab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.mainFormTab.Appearance = System.Windows.Forms.TabAppearance.Buttons;
			this.mainFormTab.Controls.Add(this.emotionalStateTabPage);
			this.mainFormTab.Controls.Add(this.emotionDispositionTabPage);
			this.mainFormTab.Controls.Add(this.appraisalRulesTagePage);
			this.mainFormTab.Controls.Add(this.knowledgeBaseTabPage);
			this.mainFormTab.Controls.Add(this.autobiographicalMemoryTabPage);
			this.mainFormTab.Location = new System.Drawing.Point(12, 26);
			this.mainFormTab.Name = "mainFormTab";
			this.mainFormTab.SelectedIndex = 0;
			this.mainFormTab.Size = new System.Drawing.Size(568, 483);
			this.mainFormTab.TabIndex = 1;
			this.mainFormTab.SelectedIndexChanged += new System.EventHandler(this.OnScreenChanged);
			// 
			// emotionalStateTabPage
			// 
			this.emotionalStateTabPage.Controls.Add(this.groupBox2);
			this.emotionalStateTabPage.Controls.Add(this.groupBox9);
			this.emotionalStateTabPage.Controls.Add(this.groupBox3);
			this.emotionalStateTabPage.Controls.Add(this.moodGroupBox);
			this.emotionalStateTabPage.Controls.Add(this.emotionGroupBox);
			this.emotionalStateTabPage.Location = new System.Drawing.Point(4, 25);
			this.emotionalStateTabPage.Name = "emotionalStateTabPage";
			this.emotionalStateTabPage.Padding = new System.Windows.Forms.Padding(3);
			this.emotionalStateTabPage.Size = new System.Drawing.Size(560, 454);
			this.emotionalStateTabPage.TabIndex = 0;
			this.emotionalStateTabPage.Text = "Emotional State";
			this.emotionalStateTabPage.UseVisualStyleBackColor = true;
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.richTextBoxDescription);
			this.groupBox2.Location = new System.Drawing.Point(7, 356);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(547, 92);
			this.groupBox2.TabIndex = 15;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Description";
			// 
			// richTextBoxDescription
			// 
			this.richTextBoxDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.richTextBoxDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.richTextBoxDescription.CausesValidation = false;
			this.richTextBoxDescription.Location = new System.Drawing.Point(9, 19);
			this.richTextBoxDescription.Multiline = false;
			this.richTextBoxDescription.Name = "richTextBoxDescription";
			this.richTextBoxDescription.Size = new System.Drawing.Size(532, 67);
			this.richTextBoxDescription.TabIndex = 0;
			this.richTextBoxDescription.Text = "";
			this.richTextBoxDescription.TextChanged += new System.EventHandler(this.richTextBoxDescription_TextChanged);
			// 
			// groupBox9
			// 
			this.groupBox9.Controls.Add(this.StartTickField);
			this.groupBox9.Controls.Add(this.label3);
			this.groupBox9.Location = new System.Drawing.Point(252, 6);
			this.groupBox9.Name = "groupBox9";
			this.groupBox9.Size = new System.Drawing.Size(112, 68);
			this.groupBox9.TabIndex = 14;
			this.groupBox9.TabStop = false;
			this.groupBox9.Text = "Time";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(7, 32);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(31, 13);
			this.label3.TabIndex = 11;
			this.label3.Text = "Tick:";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.textBoxPerspective);
			this.groupBox3.Controls.Add(this.label1);
			this.groupBox3.Location = new System.Drawing.Point(7, 6);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(239, 68);
			this.groupBox3.TabIndex = 14;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Perspective";
			// 
			// textBoxPerspective
			// 
			this.textBoxPerspective.Location = new System.Drawing.Point(50, 28);
			this.textBoxPerspective.Name = "textBoxPerspective";
			this.textBoxPerspective.Size = new System.Drawing.Size(183, 20);
			this.textBoxPerspective.TabIndex = 10;
			this.textBoxPerspective.TextChanged += new System.EventHandler(this.textBoxPerspective_TextChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(38, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Name:";
			// 
			// moodGroupBox
			// 
			this.moodGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.moodGroupBox.Controls.Add(this.moodValueLabel);
			this.moodGroupBox.Controls.Add(this.moodTrackBar);
			this.moodGroupBox.Location = new System.Drawing.Point(370, 6);
			this.moodGroupBox.Name = "moodGroupBox";
			this.moodGroupBox.Size = new System.Drawing.Size(184, 68);
			this.moodGroupBox.TabIndex = 13;
			this.moodGroupBox.TabStop = false;
			this.moodGroupBox.Text = "Mood";
			// 
			// moodValueLabel
			// 
			this.moodValueLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.moodValueLabel.AutoSize = true;
			this.moodValueLabel.Location = new System.Drawing.Point(151, 31);
			this.moodValueLabel.Name = "moodValueLabel";
			this.moodValueLabel.Size = new System.Drawing.Size(13, 13);
			this.moodValueLabel.TabIndex = 5;
			this.moodValueLabel.Text = "0";
			// 
			// moodTrackBar
			// 
			this.moodTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.moodTrackBar.Location = new System.Drawing.Point(6, 20);
			this.moodTrackBar.Minimum = -10;
			this.moodTrackBar.Name = "moodTrackBar";
			this.moodTrackBar.Size = new System.Drawing.Size(135, 45);
			this.moodTrackBar.TabIndex = 11;
			this.moodTrackBar.Scroll += new System.EventHandler(this.trackBar1_Scroll_1);
			// 
			// emotionGroupBox
			// 
			this.emotionGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.emotionGroupBox.Controls.Add(this.buttonEditEmotion);
			this.emotionGroupBox.Controls.Add(this.addEmotionButton);
			this.emotionGroupBox.Controls.Add(this.buttonRemoveEmotion);
			this.emotionGroupBox.Controls.Add(this.emotionsDataGridView);
			this.emotionGroupBox.Location = new System.Drawing.Point(7, 85);
			this.emotionGroupBox.Name = "emotionGroupBox";
			this.emotionGroupBox.Size = new System.Drawing.Size(547, 265);
			this.emotionGroupBox.TabIndex = 0;
			this.emotionGroupBox.TabStop = false;
			this.emotionGroupBox.Text = "Emotions";
			// 
			// buttonEditEmotion
			// 
			this.buttonEditEmotion.Location = new System.Drawing.Point(66, 19);
			this.buttonEditEmotion.Name = "buttonEditEmotion";
			this.buttonEditEmotion.Size = new System.Drawing.Size(70, 23);
			this.buttonEditEmotion.TabIndex = 9;
			this.buttonEditEmotion.Text = "Edit";
			this.buttonEditEmotion.UseVisualStyleBackColor = true;
			this.buttonEditEmotion.Click += new System.EventHandler(this.buttonEditEmotion_Click);
			// 
			// addEmotionButton
			// 
			this.addEmotionButton.Location = new System.Drawing.Point(6, 19);
			this.addEmotionButton.Name = "addEmotionButton";
			this.addEmotionButton.Size = new System.Drawing.Size(54, 23);
			this.addEmotionButton.TabIndex = 7;
			this.addEmotionButton.Text = "Add";
			this.addEmotionButton.UseVisualStyleBackColor = true;
			this.addEmotionButton.Click += new System.EventHandler(this.addEmotionButton_Click);
			// 
			// buttonRemoveEmotion
			// 
			this.buttonRemoveEmotion.Location = new System.Drawing.Point(142, 19);
			this.buttonRemoveEmotion.Name = "buttonRemoveEmotion";
			this.buttonRemoveEmotion.Size = new System.Drawing.Size(70, 23);
			this.buttonRemoveEmotion.TabIndex = 8;
			this.buttonRemoveEmotion.Text = "Remove";
			this.buttonRemoveEmotion.UseVisualStyleBackColor = true;
			this.buttonRemoveEmotion.Click += new System.EventHandler(this.buttonRemoveEmotion_Click);
			// 
			// emotionsDataGridView
			// 
			this.emotionsDataGridView.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
			this.emotionsDataGridView.AllowUserToAddRows = false;
			this.emotionsDataGridView.AllowUserToDeleteRows = false;
			this.emotionsDataGridView.AllowUserToOrderColumns = true;
			this.emotionsDataGridView.AllowUserToResizeRows = false;
			this.emotionsDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.emotionsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.emotionsDataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
			this.emotionsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.emotionsDataGridView.ImeMode = System.Windows.Forms.ImeMode.On;
			this.emotionsDataGridView.Location = new System.Drawing.Point(6, 54);
			this.emotionsDataGridView.Name = "emotionsDataGridView";
			this.emotionsDataGridView.ReadOnly = true;
			this.emotionsDataGridView.RowHeadersVisible = false;
			this.emotionsDataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.emotionsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.emotionsDataGridView.Size = new System.Drawing.Size(535, 205);
			this.emotionsDataGridView.TabIndex = 2;
			// 
			// emotionDispositionTabPage
			// 
			this.emotionDispositionTabPage.Controls.Add(this.groupBox6);
			this.emotionDispositionTabPage.Controls.Add(this.groupBox5);
			this.emotionDispositionTabPage.Location = new System.Drawing.Point(4, 25);
			this.emotionDispositionTabPage.Name = "emotionDispositionTabPage";
			this.emotionDispositionTabPage.Padding = new System.Windows.Forms.Padding(3);
			this.emotionDispositionTabPage.Size = new System.Drawing.Size(560, 454);
			this.emotionDispositionTabPage.TabIndex = 4;
			this.emotionDispositionTabPage.Text = "Emotion Dispositions";
			this.emotionDispositionTabPage.UseVisualStyleBackColor = true;
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.comboBoxDefaultThreshold);
			this.groupBox6.Controls.Add(this.comboBoxDefaultDecay);
			this.groupBox6.Controls.Add(this.label10);
			this.groupBox6.Controls.Add(this.label9);
			this.groupBox6.Location = new System.Drawing.Point(6, 6);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(509, 65);
			this.groupBox6.TabIndex = 1;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Default Values";
			// 
			// comboBoxDefaultThreshold
			// 
			this.comboBoxDefaultThreshold.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxDefaultThreshold.FormattingEnabled = true;
			this.comboBoxDefaultThreshold.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
			this.comboBoxDefaultThreshold.Location = new System.Drawing.Point(170, 27);
			this.comboBoxDefaultThreshold.Name = "comboBoxDefaultThreshold";
			this.comboBoxDefaultThreshold.Size = new System.Drawing.Size(36, 21);
			this.comboBoxDefaultThreshold.TabIndex = 3;
			this.comboBoxDefaultThreshold.SelectedIndexChanged += new System.EventHandler(this.comboBoxDefaultThreshold_SelectedIndexChanged);
			// 
			// comboBoxDefaultDecay
			// 
			this.comboBoxDefaultDecay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxDefaultDecay.FormattingEnabled = true;
			this.comboBoxDefaultDecay.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
			this.comboBoxDefaultDecay.Location = new System.Drawing.Point(56, 27);
			this.comboBoxDefaultDecay.Name = "comboBoxDefaultDecay";
			this.comboBoxDefaultDecay.Size = new System.Drawing.Size(36, 21);
			this.comboBoxDefaultDecay.TabIndex = 2;
			this.comboBoxDefaultDecay.SelectedIndexChanged += new System.EventHandler(this.comboBoxDefaultDecay_SelectedIndexChanged);
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(105, 31);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(57, 13);
			this.label10.TabIndex = 1;
			this.label10.Text = "Threshold:";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(6, 31);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(41, 13);
			this.label9.TabIndex = 0;
			this.label9.Text = "Decay:";
			// 
			// groupBox5
			// 
			this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox5.Controls.Add(this.dataGridViewEmotionDispositions);
			this.groupBox5.Controls.Add(this.buttonEditEmotionDisposition);
			this.groupBox5.Controls.Add(this.buttonAddEmotionDisposition);
			this.groupBox5.Controls.Add(this.buttonRemoveEmotionDisposition);
			this.groupBox5.Location = new System.Drawing.Point(6, 77);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(544, 371);
			this.groupBox5.TabIndex = 0;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Emotion Dispositions";
			// 
			// dataGridViewEmotionDispositions
			// 
			this.dataGridViewEmotionDispositions.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
			this.dataGridViewEmotionDispositions.AllowUserToAddRows = false;
			this.dataGridViewEmotionDispositions.AllowUserToDeleteRows = false;
			this.dataGridViewEmotionDispositions.AllowUserToOrderColumns = true;
			this.dataGridViewEmotionDispositions.AllowUserToResizeRows = false;
			this.dataGridViewEmotionDispositions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridViewEmotionDispositions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridViewEmotionDispositions.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
			this.dataGridViewEmotionDispositions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewEmotionDispositions.ImeMode = System.Windows.Forms.ImeMode.On;
			this.dataGridViewEmotionDispositions.Location = new System.Drawing.Point(6, 49);
			this.dataGridViewEmotionDispositions.Name = "dataGridViewEmotionDispositions";
			this.dataGridViewEmotionDispositions.ReadOnly = true;
			this.dataGridViewEmotionDispositions.RowHeadersVisible = false;
			this.dataGridViewEmotionDispositions.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewEmotionDispositions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewEmotionDispositions.Size = new System.Drawing.Size(532, 316);
			this.dataGridViewEmotionDispositions.TabIndex = 14;
			this.dataGridViewEmotionDispositions.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewEmotionDispositions_CellMouseDoubleClick);
			// 
			// buttonEditEmotionDisposition
			// 
			this.buttonEditEmotionDisposition.Location = new System.Drawing.Point(66, 20);
			this.buttonEditEmotionDisposition.Name = "buttonEditEmotionDisposition";
			this.buttonEditEmotionDisposition.Size = new System.Drawing.Size(70, 23);
			this.buttonEditEmotionDisposition.TabIndex = 13;
			this.buttonEditEmotionDisposition.Text = "Edit";
			this.buttonEditEmotionDisposition.UseVisualStyleBackColor = true;
			this.buttonEditEmotionDisposition.Click += new System.EventHandler(this.buttonEditEmotionDisposition_Click);
			// 
			// buttonAddEmotionDisposition
			// 
			this.buttonAddEmotionDisposition.Location = new System.Drawing.Point(6, 20);
			this.buttonAddEmotionDisposition.Name = "buttonAddEmotionDisposition";
			this.buttonAddEmotionDisposition.Size = new System.Drawing.Size(54, 23);
			this.buttonAddEmotionDisposition.TabIndex = 11;
			this.buttonAddEmotionDisposition.Text = "Add";
			this.buttonAddEmotionDisposition.UseVisualStyleBackColor = true;
			this.buttonAddEmotionDisposition.Click += new System.EventHandler(this.buttonAddEmotionDisposition_Click);
			// 
			// buttonRemoveEmotionDisposition
			// 
			this.buttonRemoveEmotionDisposition.Location = new System.Drawing.Point(142, 20);
			this.buttonRemoveEmotionDisposition.Name = "buttonRemoveEmotionDisposition";
			this.buttonRemoveEmotionDisposition.Size = new System.Drawing.Size(70, 23);
			this.buttonRemoveEmotionDisposition.TabIndex = 12;
			this.buttonRemoveEmotionDisposition.Text = "Remove";
			this.buttonRemoveEmotionDisposition.UseVisualStyleBackColor = true;
			this.buttonRemoveEmotionDisposition.Click += new System.EventHandler(this.buttonRemoveEmotionDisposition_Click);
			// 
			// appraisalRulesTagePage
			// 
			this.appraisalRulesTagePage.Controls.Add(this.splitContainer1);
			this.appraisalRulesTagePage.Location = new System.Drawing.Point(4, 25);
			this.appraisalRulesTagePage.Name = "appraisalRulesTagePage";
			this.appraisalRulesTagePage.Padding = new System.Windows.Forms.Padding(3);
			this.appraisalRulesTagePage.Size = new System.Drawing.Size(560, 454);
			this.appraisalRulesTagePage.TabIndex = 3;
			this.appraisalRulesTagePage.Text = "Appraisal Rules";
			this.appraisalRulesTagePage.UseVisualStyleBackColor = true;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(3, 3);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.groupBox7);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.groupBox8);
			this.splitContainer1.Size = new System.Drawing.Size(554, 448);
			this.splitContainer1.SplitterDistance = 224;
			this.splitContainer1.TabIndex = 11;
			// 
			// groupBox7
			// 
			this.groupBox7.Controls.Add(this.buttonEditAppraisalRule);
			this.groupBox7.Controls.Add(this.buttonAddAppraisalRule);
			this.groupBox7.Controls.Add(this.buttonRemoveAppraisalRule);
			this.groupBox7.Controls.Add(this.dataGridViewAppraisalRules);
			this.groupBox7.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox7.Location = new System.Drawing.Point(0, 0);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new System.Drawing.Size(554, 224);
			this.groupBox7.TabIndex = 1;
			this.groupBox7.TabStop = false;
			this.groupBox7.Text = "Rules";
			// 
			// buttonEditAppraisalRule
			// 
			this.buttonEditAppraisalRule.Location = new System.Drawing.Point(66, 19);
			this.buttonEditAppraisalRule.Name = "buttonEditAppraisalRule";
			this.buttonEditAppraisalRule.Size = new System.Drawing.Size(70, 23);
			this.buttonEditAppraisalRule.TabIndex = 9;
			this.buttonEditAppraisalRule.Text = "Edit";
			this.buttonEditAppraisalRule.UseVisualStyleBackColor = true;
			this.buttonEditAppraisalRule.Click += new System.EventHandler(this.buttonEditAppraisalRule_Click);
			// 
			// buttonAddAppraisalRule
			// 
			this.buttonAddAppraisalRule.Location = new System.Drawing.Point(6, 19);
			this.buttonAddAppraisalRule.Name = "buttonAddAppraisalRule";
			this.buttonAddAppraisalRule.Size = new System.Drawing.Size(54, 23);
			this.buttonAddAppraisalRule.TabIndex = 7;
			this.buttonAddAppraisalRule.Text = "Add";
			this.buttonAddAppraisalRule.UseVisualStyleBackColor = true;
			this.buttonAddAppraisalRule.Click += new System.EventHandler(this.buttonAddAppraisalRule_Click);
			// 
			// buttonRemoveAppraisalRule
			// 
			this.buttonRemoveAppraisalRule.Location = new System.Drawing.Point(142, 19);
			this.buttonRemoveAppraisalRule.Name = "buttonRemoveAppraisalRule";
			this.buttonRemoveAppraisalRule.Size = new System.Drawing.Size(70, 23);
			this.buttonRemoveAppraisalRule.TabIndex = 8;
			this.buttonRemoveAppraisalRule.Text = "Remove";
			this.buttonRemoveAppraisalRule.UseVisualStyleBackColor = true;
			this.buttonRemoveAppraisalRule.Click += new System.EventHandler(this.buttonRemoveAppraisalRule_Click);
			// 
			// dataGridViewAppraisalRules
			// 
			this.dataGridViewAppraisalRules.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
			this.dataGridViewAppraisalRules.AllowUserToAddRows = false;
			this.dataGridViewAppraisalRules.AllowUserToDeleteRows = false;
			this.dataGridViewAppraisalRules.AllowUserToOrderColumns = true;
			this.dataGridViewAppraisalRules.AllowUserToResizeRows = false;
			this.dataGridViewAppraisalRules.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridViewAppraisalRules.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridViewAppraisalRules.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
			this.dataGridViewAppraisalRules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewAppraisalRules.ImeMode = System.Windows.Forms.ImeMode.On;
			this.dataGridViewAppraisalRules.Location = new System.Drawing.Point(6, 54);
			this.dataGridViewAppraisalRules.Name = "dataGridViewAppraisalRules";
			this.dataGridViewAppraisalRules.ReadOnly = true;
			this.dataGridViewAppraisalRules.RowHeadersVisible = false;
			this.dataGridViewAppraisalRules.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewAppraisalRules.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewAppraisalRules.Size = new System.Drawing.Size(542, 164);
			this.dataGridViewAppraisalRules.TabIndex = 2;
			this.dataGridViewAppraisalRules.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewAppraisalRules_CellMouseDoubleClick);
			this.dataGridViewAppraisalRules.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewAppraisalRules_RowEnter);
			// 
			// groupBox8
			// 
			this.groupBox8.Controls.Add(this.conditionSetEditor);
			this.groupBox8.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox8.Location = new System.Drawing.Point(0, 0);
			this.groupBox8.Name = "groupBox8";
			this.groupBox8.Size = new System.Drawing.Size(554, 220);
			this.groupBox8.TabIndex = 10;
			this.groupBox8.TabStop = false;
			this.groupBox8.Text = "Rule Conditions";
			// 
			// conditionSetEditor
			// 
			this.conditionSetEditor.Dock = System.Windows.Forms.DockStyle.Fill;
			this.conditionSetEditor.Location = new System.Drawing.Point(3, 16);
			this.conditionSetEditor.Name = "conditionSetEditor";
			this.conditionSetEditor.Size = new System.Drawing.Size(548, 201);
			this.conditionSetEditor.TabIndex = 0;
			this.conditionSetEditor.View = null;
			// 
			// knowledgeBaseTabPage
			// 
			this.knowledgeBaseTabPage.Controls.Add(this.groupBox1);
			this.knowledgeBaseTabPage.Location = new System.Drawing.Point(4, 25);
			this.knowledgeBaseTabPage.Name = "knowledgeBaseTabPage";
			this.knowledgeBaseTabPage.Padding = new System.Windows.Forms.Padding(3);
			this.knowledgeBaseTabPage.Size = new System.Drawing.Size(560, 454);
			this.knowledgeBaseTabPage.TabIndex = 1;
			this.knowledgeBaseTabPage.Text = "Knowledge Base";
			this.knowledgeBaseTabPage.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.tableLayoutPanel1);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(554, 448);
			this.groupBox1.TabIndex = 8;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Beliefs";
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.dataGridViewBeliefs, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(548, 429);
			this.tableLayoutPanel1.TabIndex = 7;
			// 
			// dataGridViewBeliefs
			// 
			this.dataGridViewBeliefs.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
			this.dataGridViewBeliefs.AllowUserToAddRows = false;
			this.dataGridViewBeliefs.AllowUserToDeleteRows = false;
			this.dataGridViewBeliefs.AllowUserToOrderColumns = true;
			this.dataGridViewBeliefs.AllowUserToResizeRows = false;
			this.dataGridViewBeliefs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridViewBeliefs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridViewBeliefs.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
			this.dataGridViewBeliefs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewBeliefs.ImeMode = System.Windows.Forms.ImeMode.On;
			this.dataGridViewBeliefs.Location = new System.Drawing.Point(3, 38);
			this.dataGridViewBeliefs.Name = "dataGridViewBeliefs";
			this.dataGridViewBeliefs.ReadOnly = true;
			this.dataGridViewBeliefs.RowHeadersVisible = false;
			this.dataGridViewBeliefs.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewBeliefs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewBeliefs.Size = new System.Drawing.Size(542, 388);
			this.dataGridViewBeliefs.TabIndex = 4;
			this.dataGridViewBeliefs.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewBeliefs_CellMouseDoubleClick);
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 3;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.Controls.Add(this.editButton, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.addBeliefButton, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.removeBeliefButton, 2, 0);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutPanel2.MinimumSize = new System.Drawing.Size(0, 31);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(542, 31);
			this.tableLayoutPanel2.TabIndex = 3;
			// 
			// editButton
			// 
			this.editButton.Location = new System.Drawing.Point(63, 3);
			this.editButton.Name = "editButton";
			this.editButton.Size = new System.Drawing.Size(70, 23);
			this.editButton.TabIndex = 6;
			this.editButton.Text = "Edit";
			this.editButton.UseVisualStyleBackColor = true;
			this.editButton.Click += new System.EventHandler(this.editButton_Click);
			// 
			// addBeliefButton
			// 
			this.addBeliefButton.Location = new System.Drawing.Point(3, 3);
			this.addBeliefButton.Name = "addBeliefButton";
			this.addBeliefButton.Size = new System.Drawing.Size(54, 23);
			this.addBeliefButton.TabIndex = 4;
			this.addBeliefButton.Text = "Add";
			this.addBeliefButton.UseVisualStyleBackColor = true;
			this.addBeliefButton.Click += new System.EventHandler(this.addBeliefButton_Click);
			// 
			// removeBeliefButton
			// 
			this.removeBeliefButton.Location = new System.Drawing.Point(139, 3);
			this.removeBeliefButton.Name = "removeBeliefButton";
			this.removeBeliefButton.Size = new System.Drawing.Size(70, 23);
			this.removeBeliefButton.TabIndex = 5;
			this.removeBeliefButton.Text = "Remove";
			this.removeBeliefButton.UseVisualStyleBackColor = true;
			this.removeBeliefButton.Click += new System.EventHandler(this.removeBeliefButton_Click);
			// 
			// autobiographicalMemoryTabPage
			// 
			this.autobiographicalMemoryTabPage.Controls.Add(this.groupBox4);
			this.autobiographicalMemoryTabPage.Location = new System.Drawing.Point(4, 25);
			this.autobiographicalMemoryTabPage.Name = "autobiographicalMemoryTabPage";
			this.autobiographicalMemoryTabPage.Padding = new System.Windows.Forms.Padding(3);
			this.autobiographicalMemoryTabPage.Size = new System.Drawing.Size(560, 454);
			this.autobiographicalMemoryTabPage.TabIndex = 2;
			this.autobiographicalMemoryTabPage.Text = "Autobiographical Memory";
			this.autobiographicalMemoryTabPage.UseVisualStyleBackColor = true;
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.dataGridViewAM);
			this.groupBox4.Controls.Add(this.buttonEditEvent);
			this.groupBox4.Controls.Add(this.buttonAddEventRecord);
			this.groupBox4.Controls.Add(this.buttonRemoveEventRecord);
			this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox4.Location = new System.Drawing.Point(3, 3);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(554, 448);
			this.groupBox4.TabIndex = 0;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Event Records";
			// 
			// dataGridViewAM
			// 
			this.dataGridViewAM.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
			this.dataGridViewAM.AllowUserToAddRows = false;
			this.dataGridViewAM.AllowUserToDeleteRows = false;
			this.dataGridViewAM.AllowUserToOrderColumns = true;
			this.dataGridViewAM.AllowUserToResizeRows = false;
			this.dataGridViewAM.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridViewAM.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridViewAM.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
			this.dataGridViewAM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewAM.ImeMode = System.Windows.Forms.ImeMode.On;
			this.dataGridViewAM.Location = new System.Drawing.Point(0, 49);
			this.dataGridViewAM.Name = "dataGridViewAM";
			this.dataGridViewAM.ReadOnly = true;
			this.dataGridViewAM.RowHeadersVisible = false;
			this.dataGridViewAM.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewAM.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewAM.Size = new System.Drawing.Size(542, 393);
			this.dataGridViewAM.TabIndex = 10;
			this.dataGridViewAM.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewAM_CellMouseDoubleClick);
			// 
			// buttonEditEvent
			// 
			this.buttonEditEvent.Location = new System.Drawing.Point(66, 20);
			this.buttonEditEvent.Name = "buttonEditEvent";
			this.buttonEditEvent.Size = new System.Drawing.Size(70, 23);
			this.buttonEditEvent.TabIndex = 9;
			this.buttonEditEvent.Text = "Edit";
			this.buttonEditEvent.UseVisualStyleBackColor = true;
			this.buttonEditEvent.Click += new System.EventHandler(this.buttonEditEvent_Click);
			// 
			// buttonAddEventRecord
			// 
			this.buttonAddEventRecord.Location = new System.Drawing.Point(6, 20);
			this.buttonAddEventRecord.Name = "buttonAddEventRecord";
			this.buttonAddEventRecord.Size = new System.Drawing.Size(54, 23);
			this.buttonAddEventRecord.TabIndex = 7;
			this.buttonAddEventRecord.Text = "Add";
			this.buttonAddEventRecord.UseVisualStyleBackColor = true;
			this.buttonAddEventRecord.Click += new System.EventHandler(this.buttonAddEventRecord_Click);
			// 
			// buttonRemoveEventRecord
			// 
			this.buttonRemoveEventRecord.Location = new System.Drawing.Point(142, 20);
			this.buttonRemoveEventRecord.Name = "buttonRemoveEventRecord";
			this.buttonRemoveEventRecord.Size = new System.Drawing.Size(70, 23);
			this.buttonRemoveEventRecord.TabIndex = 8;
			this.buttonRemoveEventRecord.Text = "Remove";
			this.buttonRemoveEventRecord.UseVisualStyleBackColor = true;
			this.buttonRemoveEventRecord.Click += new System.EventHandler(this.buttonRemoveEventRecord_Click);
			// 
			// decayErrorProvider
			// 
			this.decayErrorProvider.ContainerControl = this;
			// 
			// StartTickField
			// 
			this.StartTickField.Location = new System.Drawing.Point(44, 28);
			this.StartTickField.Maximum = new decimal(new int[] {
            -1,
            -1,
            0,
            0});
			this.StartTickField.Name = "StartTickField";
			this.StartTickField.Size = new System.Drawing.Size(62, 20);
			this.StartTickField.TabIndex = 12;
			this.StartTickField.ThousandsSeparator = true;
			this.StartTickField.ValueChanged += new System.EventHandler(this.textBoxStartTick_TextChanged);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(592, 522);
			this.Controls.Add(this.mainFormTab);
			this.EditorName = "Emotional Appraisal Editor";
			this.MinimumSize = new System.Drawing.Size(450, 39);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Controls.SetChildIndex(this.mainFormTab, 0);
			this.mainFormTab.ResumeLayout(false);
			this.emotionalStateTabPage.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox9.ResumeLayout(false);
			this.groupBox9.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.moodGroupBox.ResumeLayout(false);
			this.moodGroupBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.moodTrackBar)).EndInit();
			this.emotionGroupBox.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.emotionsDataGridView)).EndInit();
			this.emotionDispositionTabPage.ResumeLayout(false);
			this.groupBox6.ResumeLayout(false);
			this.groupBox6.PerformLayout();
			this.groupBox5.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmotionDispositions)).EndInit();
			this.appraisalRulesTagePage.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.groupBox7.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewAppraisalRules)).EndInit();
			this.groupBox8.ResumeLayout(false);
			this.knowledgeBaseTabPage.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewBeliefs)).EndInit();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.autobiographicalMemoryTabPage.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewAM)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.decayErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emotionListItemBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.mainFormBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.StartTickField)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabControl mainFormTab;
        private System.Windows.Forms.TabPage emotionalStateTabPage;
        private System.Windows.Forms.TabPage knowledgeBaseTabPage;
        private System.Windows.Forms.TabPage autobiographicalMemoryTabPage;
        private System.Windows.Forms.TabPage appraisalRulesTagePage;
        private System.Windows.Forms.Button addBeliefButton;
        private System.Windows.Forms.Button removeBeliefButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.GroupBox emotionGroupBox;
        private System.Windows.Forms.DataGridView emotionsDataGridView;
        private System.Windows.Forms.Button buttonEditEmotion;
        private System.Windows.Forms.Button addEmotionButton;
        private System.Windows.Forms.Button buttonRemoveEmotion;
        private System.Windows.Forms.TabPage emotionDispositionTabPage;
        private System.Windows.Forms.TrackBar moodTrackBar;
        private System.Windows.Forms.GroupBox moodGroupBox;
        private System.Windows.Forms.BindingSource mainFormBindingSource;
        private System.Windows.Forms.Label moodValueLabel;
        private System.Windows.Forms.BindingSource emotionListItemBindingSource;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button buttonEditEvent;
        private System.Windows.Forms.Button buttonAddEventRecord;
        private System.Windows.Forms.Button buttonRemoveEventRecord;
        private System.Windows.Forms.DataGridView dataGridViewAM;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.DataGridView dataGridViewEmotionDispositions;
        private System.Windows.Forms.Button buttonEditEmotionDisposition;
        private System.Windows.Forms.Button buttonAddEmotionDisposition;
        private System.Windows.Forms.Button buttonRemoveEmotionDisposition;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBoxDefaultDecay;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBoxDefaultThreshold;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button buttonEditAppraisalRule;
        private System.Windows.Forms.Button buttonAddAppraisalRule;
        private System.Windows.Forms.Button buttonRemoveAppraisalRule;
        private System.Windows.Forms.DataGridView dataGridViewAppraisalRules;
        private System.Windows.Forms.ErrorProvider decayErrorProvider;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.DataGridView dataGridViewBeliefs;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBoxPerspective;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox richTextBoxDescription;
        private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.GroupBox groupBox8;
		private GAIPS.AssetEditorTools.ConditionSetEditorControl conditionSetEditor;
		private System.Windows.Forms.NumericUpDown StartTickField;
	}
}

