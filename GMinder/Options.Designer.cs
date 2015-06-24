namespace ReflectiveCode.GMinder
{
    partial class Options
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Options));
            this.refreshRateLabel = new System.Windows.Forms.Label();
            this.buttonOk = new System.Windows.Forms.Button();
            this.PreloadDaysLabel = new System.Windows.Forms.Label();
            this.soonColorDialog = new System.Windows.Forms.ColorDialog();
            this.eventsSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.eventSettingsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.SoonAlertOptionsFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.soonPopupCheckBox = new System.Windows.Forms.CheckBox();
            this.soonSoundCheckBox = new System.Windows.Forms.CheckBox();
            this.soonVerbalCheckBox = new System.Windows.Forms.CheckBox();
            this.soonTimeInteger = new ReflectiveCode.GMinder.Controls.IntegerUpDown();
            this.soonMinutesLabel = new System.Windows.Forms.Label();
            this.futureEventsColorButton = new ReflectiveCode.GMinder.Controls.ColorButton();
            this.FutureEventsLabel = new System.Windows.Forms.Label();
            this.SoonEventsLabel = new System.Windows.Forms.Label();
            this.NowEventsLabel = new System.Windows.Forms.Label();
            this.PastEventsLabel = new System.Windows.Forms.Label();
            this.NowAlertOptionsFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.nowPopupCheckBox = new System.Windows.Forms.CheckBox();
            this.nowSoundCheckBox = new System.Windows.Forms.CheckBox();
            this.nowVerbalCheckBox = new System.Windows.Forms.CheckBox();
            this.pastDismissOptionFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.pastDismissCheckBox = new System.Windows.Forms.CheckBox();
            this.SoonEventsColorButton = new ReflectiveCode.GMinder.Controls.ColorButton();
            this.nowEventsColorButton = new ReflectiveCode.GMinder.Controls.ColorButton();
            this.pastEventsColorButton = new ReflectiveCode.GMinder.Controls.ColorButton();
            this.soundSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.soundSettingsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.soundPlayButton = new System.Windows.Forms.Button();
            this.soundBrowseButton = new ReflectiveCode.GMinder.Controls.OpenFileButton();
            this.openSoundFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.soundPathTextBox = new System.Windows.Forms.TextBox();
            this.agendaSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.agendaSettingsFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.startAtLoginCheckBox = new System.Windows.Forms.CheckBox();
            this.onTopCheckBox = new System.Windows.Forms.CheckBox();
            this.refreshRateInteger = new ReflectiveCode.GMinder.Controls.IntegerUpDown();
            this.preloadDaysInteger = new ReflectiveCode.GMinder.Controls.IntegerUpDown();
            this.doPingCheckBox = new System.Windows.Forms.CheckBox();
            this.optionsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.okCancelFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.eventsSettingsGroupBox.SuspendLayout();
            this.eventSettingsTableLayoutPanel.SuspendLayout();
            this.SoonAlertOptionsFlowLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.soonTimeInteger)).BeginInit();
            this.NowAlertOptionsFlowLayoutPanel.SuspendLayout();
            this.pastDismissOptionFlowLayoutPanel.SuspendLayout();
            this.soundSettingsGroupBox.SuspendLayout();
            this.soundSettingsTableLayoutPanel.SuspendLayout();
            this.agendaSettingsGroupBox.SuspendLayout();
            this.agendaSettingsFlowLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.refreshRateInteger)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.preloadDaysInteger)).BeginInit();
            this.optionsTableLayoutPanel.SuspendLayout();
            this.okCancelFlowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // refreshRateLabel
            // 
            resources.ApplyResources(this.refreshRateLabel, "refreshRateLabel");
            this.agendaSettingsFlowLayoutPanel.SetFlowBreak(this.refreshRateLabel, true);
            this.refreshRateLabel.Name = "refreshRateLabel";
            // 
            // buttonOk
            // 
            resources.ApplyResources(this.buttonOk, "buttonOk");
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.UseVisualStyleBackColor = true;
            // 
            // PreloadDaysLabel
            // 
            resources.ApplyResources(this.PreloadDaysLabel, "PreloadDaysLabel");
            this.agendaSettingsFlowLayoutPanel.SetFlowBreak(this.PreloadDaysLabel, true);
            this.PreloadDaysLabel.Name = "PreloadDaysLabel";
            // 
            // eventsSettingsGroupBox
            // 
            resources.ApplyResources(this.eventsSettingsGroupBox, "eventsSettingsGroupBox");
            this.eventsSettingsGroupBox.Controls.Add(this.eventSettingsTableLayoutPanel);
            this.eventsSettingsGroupBox.Name = "eventsSettingsGroupBox";
            this.eventsSettingsGroupBox.TabStop = false;
            // 
            // eventSettingsTableLayoutPanel
            // 
            resources.ApplyResources(this.eventSettingsTableLayoutPanel, "eventSettingsTableLayoutPanel");
            this.eventSettingsTableLayoutPanel.Controls.Add(this.SoonAlertOptionsFlowLayoutPanel, 2, 1);
            this.eventSettingsTableLayoutPanel.Controls.Add(this.futureEventsColorButton, 1, 0);
            this.eventSettingsTableLayoutPanel.Controls.Add(this.FutureEventsLabel, 0, 0);
            this.eventSettingsTableLayoutPanel.Controls.Add(this.SoonEventsLabel, 0, 1);
            this.eventSettingsTableLayoutPanel.Controls.Add(this.NowEventsLabel, 0, 2);
            this.eventSettingsTableLayoutPanel.Controls.Add(this.PastEventsLabel, 0, 3);
            this.eventSettingsTableLayoutPanel.Controls.Add(this.NowAlertOptionsFlowLayoutPanel, 2, 2);
            this.eventSettingsTableLayoutPanel.Controls.Add(this.pastDismissOptionFlowLayoutPanel, 2, 3);
            this.eventSettingsTableLayoutPanel.Controls.Add(this.SoonEventsColorButton, 1, 1);
            this.eventSettingsTableLayoutPanel.Controls.Add(this.nowEventsColorButton, 1, 2);
            this.eventSettingsTableLayoutPanel.Controls.Add(this.pastEventsColorButton, 1, 3);
            this.eventSettingsTableLayoutPanel.Name = "eventSettingsTableLayoutPanel";
            // 
            // SoonAlertOptionsFlowLayoutPanel
            // 
            resources.ApplyResources(this.SoonAlertOptionsFlowLayoutPanel, "SoonAlertOptionsFlowLayoutPanel");
            this.SoonAlertOptionsFlowLayoutPanel.Controls.Add(this.soonPopupCheckBox);
            this.SoonAlertOptionsFlowLayoutPanel.Controls.Add(this.soonSoundCheckBox);
            this.SoonAlertOptionsFlowLayoutPanel.Controls.Add(this.soonVerbalCheckBox);
            this.SoonAlertOptionsFlowLayoutPanel.Controls.Add(this.soonTimeInteger);
            this.SoonAlertOptionsFlowLayoutPanel.Controls.Add(this.soonMinutesLabel);
            this.SoonAlertOptionsFlowLayoutPanel.Name = "SoonAlertOptionsFlowLayoutPanel";
            // 
            // soonPopupCheckBox
            // 
            resources.ApplyResources(this.soonPopupCheckBox, "soonPopupCheckBox");
            this.soonPopupCheckBox.Checked = global::ReflectiveCode.GMinder.Properties.Settings.Default.SoonPopup;
            this.soonPopupCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.soonPopupCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ReflectiveCode.GMinder.Properties.Settings.Default, "SoonPopup", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.soonPopupCheckBox.Name = "soonPopupCheckBox";
            this.soonPopupCheckBox.UseVisualStyleBackColor = true;
            // 
            // soonSoundCheckBox
            // 
            resources.ApplyResources(this.soonSoundCheckBox, "soonSoundCheckBox");
            this.soonSoundCheckBox.Checked = global::ReflectiveCode.GMinder.Properties.Settings.Default.SoonSound;
            this.soonSoundCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.soonSoundCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ReflectiveCode.GMinder.Properties.Settings.Default, "SoonSound", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.soonSoundCheckBox.Name = "soonSoundCheckBox";
            this.soonSoundCheckBox.UseVisualStyleBackColor = true;
            // 
            // soonVerbalCheckBox
            // 
            resources.ApplyResources(this.soonVerbalCheckBox, "soonVerbalCheckBox");
            this.soonVerbalCheckBox.Checked = global::ReflectiveCode.GMinder.Properties.Settings.Default.SoonVerbal;
            this.soonVerbalCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ReflectiveCode.GMinder.Properties.Settings.Default, "SoonVerbal", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.soonVerbalCheckBox.Name = "soonVerbalCheckBox";
            this.soonVerbalCheckBox.UseVisualStyleBackColor = true;
            // 
            // soonTimeInteger
            // 
            resources.ApplyResources(this.soonTimeInteger, "soonTimeInteger");
            this.soonTimeInteger.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::ReflectiveCode.GMinder.Properties.Settings.Default, "SoonTime", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.soonTimeInteger.Maximum = new decimal(new int[] {
            1440,
            0,
            0,
            0});
            this.soonTimeInteger.Name = "soonTimeInteger";
            this.soonTimeInteger.Value = global::ReflectiveCode.GMinder.Properties.Settings.Default.SoonTime;
            // 
            // soonMinutesLabel
            // 
            resources.ApplyResources(this.soonMinutesLabel, "soonMinutesLabel");
            this.soonMinutesLabel.Name = "soonMinutesLabel";
            // 
            // futureEventsColorButton
            // 
            resources.ApplyResources(this.futureEventsColorButton, "futureEventsColorButton");
            this.futureEventsColorButton.BackColor = System.Drawing.Color.White;
            this.futureEventsColorButton.Color = global::ReflectiveCode.GMinder.Properties.Settings.Default.FutureColor;
            this.futureEventsColorButton.ColorDialog = this.soonColorDialog;
            this.futureEventsColorButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.futureEventsColorButton.DataBindings.Add(new System.Windows.Forms.Binding("Color", global::ReflectiveCode.GMinder.Properties.Settings.Default, "FutureColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.futureEventsColorButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.futureEventsColorButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.futureEventsColorButton.Name = "futureEventsColorButton";
            this.futureEventsColorButton.UseVisualStyleBackColor = false;
            // 
            // FutureEventsLabel
            // 
            resources.ApplyResources(this.FutureEventsLabel, "FutureEventsLabel");
            this.FutureEventsLabel.Name = "FutureEventsLabel";
            // 
            // SoonEventsLabel
            // 
            resources.ApplyResources(this.SoonEventsLabel, "SoonEventsLabel");
            this.SoonEventsLabel.Name = "SoonEventsLabel";
            // 
            // NowEventsLabel
            // 
            resources.ApplyResources(this.NowEventsLabel, "NowEventsLabel");
            this.NowEventsLabel.Name = "NowEventsLabel";
            // 
            // PastEventsLabel
            // 
            resources.ApplyResources(this.PastEventsLabel, "PastEventsLabel");
            this.PastEventsLabel.Name = "PastEventsLabel";
            // 
            // NowAlertOptionsFlowLayoutPanel
            // 
            resources.ApplyResources(this.NowAlertOptionsFlowLayoutPanel, "NowAlertOptionsFlowLayoutPanel");
            this.NowAlertOptionsFlowLayoutPanel.Controls.Add(this.nowPopupCheckBox);
            this.NowAlertOptionsFlowLayoutPanel.Controls.Add(this.nowSoundCheckBox);
            this.NowAlertOptionsFlowLayoutPanel.Controls.Add(this.nowVerbalCheckBox);
            this.NowAlertOptionsFlowLayoutPanel.Name = "NowAlertOptionsFlowLayoutPanel";
            // 
            // nowPopupCheckBox
            // 
            resources.ApplyResources(this.nowPopupCheckBox, "nowPopupCheckBox");
            this.nowPopupCheckBox.Checked = global::ReflectiveCode.GMinder.Properties.Settings.Default.NowPopup;
            this.nowPopupCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.nowPopupCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ReflectiveCode.GMinder.Properties.Settings.Default, "NowPopup", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nowPopupCheckBox.Name = "nowPopupCheckBox";
            this.nowPopupCheckBox.UseVisualStyleBackColor = true;
            // 
            // nowSoundCheckBox
            // 
            resources.ApplyResources(this.nowSoundCheckBox, "nowSoundCheckBox");
            this.nowSoundCheckBox.Checked = global::ReflectiveCode.GMinder.Properties.Settings.Default.NowSound;
            this.nowSoundCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.nowSoundCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ReflectiveCode.GMinder.Properties.Settings.Default, "NowSound", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.NowAlertOptionsFlowLayoutPanel.SetFlowBreak(this.nowSoundCheckBox, true);
            this.nowSoundCheckBox.Name = "nowSoundCheckBox";
            this.nowSoundCheckBox.UseVisualStyleBackColor = true;
            // 
            // nowVerbalCheckBox
            // 
            resources.ApplyResources(this.nowVerbalCheckBox, "nowVerbalCheckBox");
            this.nowVerbalCheckBox.Checked = global::ReflectiveCode.GMinder.Properties.Settings.Default.NowVerbal;
            this.nowVerbalCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ReflectiveCode.GMinder.Properties.Settings.Default, "NowVerbal", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nowVerbalCheckBox.Name = "nowVerbalCheckBox";
            this.nowVerbalCheckBox.UseVisualStyleBackColor = true;
            // 
            // pastDismissOptionFlowLayoutPanel
            // 
            resources.ApplyResources(this.pastDismissOptionFlowLayoutPanel, "pastDismissOptionFlowLayoutPanel");
            this.pastDismissOptionFlowLayoutPanel.Controls.Add(this.pastDismissCheckBox);
            this.pastDismissOptionFlowLayoutPanel.Name = "pastDismissOptionFlowLayoutPanel";
            // 
            // pastDismissCheckBox
            // 
            resources.ApplyResources(this.pastDismissCheckBox, "pastDismissCheckBox");
            this.pastDismissCheckBox.Checked = global::ReflectiveCode.GMinder.Properties.Settings.Default.PastDismiss;
            this.pastDismissCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ReflectiveCode.GMinder.Properties.Settings.Default, "PastDismiss", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.pastDismissCheckBox.Name = "pastDismissCheckBox";
            this.pastDismissCheckBox.UseVisualStyleBackColor = true;
            // 
            // SoonEventsColorButton
            // 
            resources.ApplyResources(this.SoonEventsColorButton, "SoonEventsColorButton");
            this.SoonEventsColorButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.SoonEventsColorButton.Color = global::ReflectiveCode.GMinder.Properties.Settings.Default.SoonColor;
            this.SoonEventsColorButton.ColorDialog = this.soonColorDialog;
            this.SoonEventsColorButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SoonEventsColorButton.DataBindings.Add(new System.Windows.Forms.Binding("Color", global::ReflectiveCode.GMinder.Properties.Settings.Default, "SoonColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.SoonEventsColorButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.SoonEventsColorButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.SoonEventsColorButton.Name = "SoonEventsColorButton";
            this.SoonEventsColorButton.UseVisualStyleBackColor = false;
            // 
            // nowEventsColorButton
            // 
            resources.ApplyResources(this.nowEventsColorButton, "nowEventsColorButton");
            this.nowEventsColorButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.nowEventsColorButton.Color = global::ReflectiveCode.GMinder.Properties.Settings.Default.NowColor;
            this.nowEventsColorButton.ColorDialog = this.soonColorDialog;
            this.nowEventsColorButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nowEventsColorButton.DataBindings.Add(new System.Windows.Forms.Binding("Color", global::ReflectiveCode.GMinder.Properties.Settings.Default, "NowColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nowEventsColorButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.nowEventsColorButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.nowEventsColorButton.Name = "nowEventsColorButton";
            this.nowEventsColorButton.UseVisualStyleBackColor = false;
            // 
            // pastEventsColorButton
            // 
            resources.ApplyResources(this.pastEventsColorButton, "pastEventsColorButton");
            this.pastEventsColorButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.pastEventsColorButton.Color = global::ReflectiveCode.GMinder.Properties.Settings.Default.PastColor;
            this.pastEventsColorButton.ColorDialog = this.soonColorDialog;
            this.pastEventsColorButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pastEventsColorButton.DataBindings.Add(new System.Windows.Forms.Binding("Color", global::ReflectiveCode.GMinder.Properties.Settings.Default, "PastColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.pastEventsColorButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.pastEventsColorButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.pastEventsColorButton.Name = "pastEventsColorButton";
            this.pastEventsColorButton.UseVisualStyleBackColor = false;
            // 
            // soundSettingsGroupBox
            // 
            resources.ApplyResources(this.soundSettingsGroupBox, "soundSettingsGroupBox");
            this.soundSettingsGroupBox.Controls.Add(this.soundSettingsTableLayoutPanel);
            this.soundSettingsGroupBox.Name = "soundSettingsGroupBox";
            this.soundSettingsGroupBox.TabStop = false;
            // 
            // soundSettingsTableLayoutPanel
            // 
            resources.ApplyResources(this.soundSettingsTableLayoutPanel, "soundSettingsTableLayoutPanel");
            this.soundSettingsTableLayoutPanel.Controls.Add(this.soundPlayButton, 0, 1);
            this.soundSettingsTableLayoutPanel.Controls.Add(this.soundBrowseButton, 1, 1);
            this.soundSettingsTableLayoutPanel.Controls.Add(this.soundPathTextBox, 2, 1);
            this.soundSettingsTableLayoutPanel.Name = "soundSettingsTableLayoutPanel";
            // 
            // soundPlayButton
            // 
            resources.ApplyResources(this.soundPlayButton, "soundPlayButton");
            this.soundPlayButton.Name = "soundPlayButton";
            this.soundPlayButton.UseVisualStyleBackColor = true;
            this.soundPlayButton.Click += new System.EventHandler(this.soundPlay_Click);
            // 
            // soundBrowseButton
            // 
            resources.ApplyResources(this.soundBrowseButton, "soundBrowseButton");
            this.soundBrowseButton.FileName = "First Run";
            this.soundBrowseButton.Name = "soundBrowseButton";
            this.soundBrowseButton.OpenFileDialog = this.openSoundFileDialog;
            this.soundBrowseButton.TextBox = this.soundPathTextBox;
            this.soundBrowseButton.UseVisualStyleBackColor = true;
            // 
            // openSoundFileDialog
            // 
            this.openSoundFileDialog.FileName = "openSoundFileDialog";
            resources.ApplyResources(this.openSoundFileDialog, "openSoundFileDialog");
            // 
            // soundPathTextBox
            // 
            resources.ApplyResources(this.soundPathTextBox, "soundPathTextBox");
            this.soundPathTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ReflectiveCode.GMinder.Properties.Settings.Default, "SoundPath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.soundPathTextBox.Name = "soundPathTextBox";
            this.soundPathTextBox.Text = global::ReflectiveCode.GMinder.Properties.Settings.Default.SoundPath;
            // 
            // agendaSettingsGroupBox
            // 
            resources.ApplyResources(this.agendaSettingsGroupBox, "agendaSettingsGroupBox");
            this.agendaSettingsGroupBox.Controls.Add(this.agendaSettingsFlowLayoutPanel);
            this.agendaSettingsGroupBox.Name = "agendaSettingsGroupBox";
            this.agendaSettingsGroupBox.TabStop = false;
            // 
            // agendaSettingsFlowLayoutPanel
            // 
            resources.ApplyResources(this.agendaSettingsFlowLayoutPanel, "agendaSettingsFlowLayoutPanel");
            this.agendaSettingsFlowLayoutPanel.Controls.Add(this.startAtLoginCheckBox);
            this.agendaSettingsFlowLayoutPanel.Controls.Add(this.onTopCheckBox);
            this.agendaSettingsFlowLayoutPanel.Controls.Add(this.refreshRateInteger);
            this.agendaSettingsFlowLayoutPanel.Controls.Add(this.refreshRateLabel);
            this.agendaSettingsFlowLayoutPanel.Controls.Add(this.preloadDaysInteger);
            this.agendaSettingsFlowLayoutPanel.Controls.Add(this.PreloadDaysLabel);
            this.agendaSettingsFlowLayoutPanel.Controls.Add(this.doPingCheckBox);
            this.agendaSettingsFlowLayoutPanel.Name = "agendaSettingsFlowLayoutPanel";
            // 
            // startAtLoginCheckBox
            // 
            resources.ApplyResources(this.startAtLoginCheckBox, "startAtLoginCheckBox");
            this.agendaSettingsFlowLayoutPanel.SetFlowBreak(this.startAtLoginCheckBox, true);
            this.startAtLoginCheckBox.Name = "startAtLoginCheckBox";
            this.startAtLoginCheckBox.UseVisualStyleBackColor = true;
            this.startAtLoginCheckBox.CheckedChanged += new System.EventHandler(this.startAtLogin_CheckedChanged);
            // 
            // onTopCheckBox
            // 
            resources.ApplyResources(this.onTopCheckBox, "onTopCheckBox");
            this.onTopCheckBox.Checked = global::ReflectiveCode.GMinder.Properties.Settings.Default.OnTop;
            this.onTopCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.onTopCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ReflectiveCode.GMinder.Properties.Settings.Default, "OnTop", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.agendaSettingsFlowLayoutPanel.SetFlowBreak(this.onTopCheckBox, true);
            this.onTopCheckBox.Name = "onTopCheckBox";
            this.onTopCheckBox.UseVisualStyleBackColor = true;
            // 
            // refreshRateInteger
            // 
            resources.ApplyResources(this.refreshRateInteger, "refreshRateInteger");
            this.refreshRateInteger.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::ReflectiveCode.GMinder.Properties.Settings.Default, "RefreshRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.refreshRateInteger.Maximum = new decimal(new int[] {
            1440,
            0,
            0,
            0});
            this.refreshRateInteger.Name = "refreshRateInteger";
            this.refreshRateInteger.Value = global::ReflectiveCode.GMinder.Properties.Settings.Default.RefreshRate;
            // 
            // preloadDaysInteger
            // 
            resources.ApplyResources(this.preloadDaysInteger, "preloadDaysInteger");
            this.preloadDaysInteger.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::ReflectiveCode.GMinder.Properties.Settings.Default, "LoadDays", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.preloadDaysInteger.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.preloadDaysInteger.Name = "preloadDaysInteger";
            this.preloadDaysInteger.Value = global::ReflectiveCode.GMinder.Properties.Settings.Default.LoadDays;
            // 
            // doPingCheckBox
            // 
            resources.ApplyResources(this.doPingCheckBox, "doPingCheckBox");
            this.doPingCheckBox.Checked = global::ReflectiveCode.GMinder.Properties.Settings.Default.DoPing;
            this.doPingCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.doPingCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ReflectiveCode.GMinder.Properties.Settings.Default, "DoPing", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.agendaSettingsFlowLayoutPanel.SetFlowBreak(this.doPingCheckBox, true);
            this.doPingCheckBox.Name = "doPingCheckBox";
            this.doPingCheckBox.UseVisualStyleBackColor = true;
            // 
            // optionsTableLayoutPanel
            // 
            resources.ApplyResources(this.optionsTableLayoutPanel, "optionsTableLayoutPanel");
            this.optionsTableLayoutPanel.Controls.Add(this.agendaSettingsGroupBox, 0, 0);
            this.optionsTableLayoutPanel.Controls.Add(this.eventsSettingsGroupBox, 0, 1);
            this.optionsTableLayoutPanel.Controls.Add(this.soundSettingsGroupBox, 0, 2);
            this.optionsTableLayoutPanel.Controls.Add(this.okCancelFlowLayoutPanel, 0, 3);
            this.optionsTableLayoutPanel.Name = "optionsTableLayoutPanel";
            // 
            // okCancelFlowLayoutPanel
            // 
            resources.ApplyResources(this.okCancelFlowLayoutPanel, "okCancelFlowLayoutPanel");
            this.okCancelFlowLayoutPanel.Controls.Add(this.buttonCancel);
            this.okCancelFlowLayoutPanel.Controls.Add(this.buttonOk);
            this.okCancelFlowLayoutPanel.Name = "okCancelFlowLayoutPanel";
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.buttonCancel, "buttonCancel");
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // Options
            // 
            this.AcceptButton = this.buttonOk;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.Controls.Add(this.optionsTableLayoutPanel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Options";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Options_FormClosed);
            this.Shown += new System.EventHandler(this.Options_Shown);
            this.eventsSettingsGroupBox.ResumeLayout(false);
            this.eventsSettingsGroupBox.PerformLayout();
            this.eventSettingsTableLayoutPanel.ResumeLayout(false);
            this.eventSettingsTableLayoutPanel.PerformLayout();
            this.SoonAlertOptionsFlowLayoutPanel.ResumeLayout(false);
            this.SoonAlertOptionsFlowLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.soonTimeInteger)).EndInit();
            this.NowAlertOptionsFlowLayoutPanel.ResumeLayout(false);
            this.NowAlertOptionsFlowLayoutPanel.PerformLayout();
            this.pastDismissOptionFlowLayoutPanel.ResumeLayout(false);
            this.pastDismissOptionFlowLayoutPanel.PerformLayout();
            this.soundSettingsGroupBox.ResumeLayout(false);
            this.soundSettingsGroupBox.PerformLayout();
            this.soundSettingsTableLayoutPanel.ResumeLayout(false);
            this.soundSettingsTableLayoutPanel.PerformLayout();
            this.agendaSettingsGroupBox.ResumeLayout(false);
            this.agendaSettingsGroupBox.PerformLayout();
            this.agendaSettingsFlowLayoutPanel.ResumeLayout(false);
            this.agendaSettingsFlowLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.refreshRateInteger)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.preloadDaysInteger)).EndInit();
            this.optionsTableLayoutPanel.ResumeLayout(false);
            this.optionsTableLayoutPanel.PerformLayout();
            this.okCancelFlowLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label refreshRateLabel;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Label PreloadDaysLabel;
        private System.Windows.Forms.GroupBox eventsSettingsGroupBox;
        private System.Windows.Forms.GroupBox soundSettingsGroupBox;
        private System.Windows.Forms.TextBox soundPathTextBox;
        private System.Windows.Forms.Button soundPlayButton;
        private ReflectiveCode.GMinder.Controls.OpenFileButton soundBrowseButton;
        private System.Windows.Forms.ColorDialog soonColorDialog;
        private System.Windows.Forms.OpenFileDialog openSoundFileDialog;
        private ReflectiveCode.GMinder.Controls.IntegerUpDown refreshRateInteger;
        private ReflectiveCode.GMinder.Controls.IntegerUpDown preloadDaysInteger;
        private System.Windows.Forms.TableLayoutPanel soundSettingsTableLayoutPanel;
        private System.Windows.Forms.GroupBox agendaSettingsGroupBox;
        private System.Windows.Forms.FlowLayoutPanel agendaSettingsFlowLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel optionsTableLayoutPanel;
        private System.Windows.Forms.FlowLayoutPanel okCancelFlowLayoutPanel;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TableLayoutPanel eventSettingsTableLayoutPanel;
        private System.Windows.Forms.FlowLayoutPanel SoonAlertOptionsFlowLayoutPanel;
        private System.Windows.Forms.CheckBox soonPopupCheckBox;
        private System.Windows.Forms.CheckBox soonSoundCheckBox;
        private ReflectiveCode.GMinder.Controls.IntegerUpDown soonTimeInteger;
        private System.Windows.Forms.Label soonMinutesLabel;
        private ReflectiveCode.GMinder.Controls.ColorButton futureEventsColorButton;
        private System.Windows.Forms.Label FutureEventsLabel;
        private System.Windows.Forms.Label SoonEventsLabel;
        private System.Windows.Forms.Label NowEventsLabel;
        private System.Windows.Forms.Label PastEventsLabel;
        private System.Windows.Forms.FlowLayoutPanel NowAlertOptionsFlowLayoutPanel;
        private System.Windows.Forms.CheckBox nowPopupCheckBox;
        private System.Windows.Forms.CheckBox nowSoundCheckBox;
        private System.Windows.Forms.FlowLayoutPanel pastDismissOptionFlowLayoutPanel;
        private System.Windows.Forms.CheckBox pastDismissCheckBox;
        private ReflectiveCode.GMinder.Controls.ColorButton SoonEventsColorButton;
        private ReflectiveCode.GMinder.Controls.ColorButton nowEventsColorButton;
        private ReflectiveCode.GMinder.Controls.ColorButton pastEventsColorButton;
        private System.Windows.Forms.CheckBox onTopCheckBox;
        private System.Windows.Forms.CheckBox doPingCheckBox;
        private System.Windows.Forms.CheckBox soonVerbalCheckBox;
        private System.Windows.Forms.CheckBox nowVerbalCheckBox;
        private System.Windows.Forms.CheckBox startAtLoginCheckBox;
    }
}