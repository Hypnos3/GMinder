namespace ReflectiveCode.GMinder
{
    partial class Calendars
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Calendars));
            this.CalendarsFormTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.loginGroupBox = new System.Windows.Forms.GroupBox();
            this.loginSettingsFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.loginButton = new System.Windows.Forms.Button();
            this.calendarsGroupBox = new System.Windows.Forms.GroupBox();
            this.calendardsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.calendarNameLabel = new System.Windows.Forms.Label();
            this.calendarColorLabel = new System.Windows.Forms.Label();
            this.calendarUrlLabel = new System.Windows.Forms.Label();
            this.calendarsEditFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.calendarAddButton = new System.Windows.Forms.Button();
            this.calendarRemoveButton = new System.Windows.Forms.Button();
            this.calendarDownloadButton = new System.Windows.Forms.Button();
            this.calendarNameTextBox = new System.Windows.Forms.TextBox();
            this.calendarUrlTextBox = new System.Windows.Forms.TextBox();
            this.calendarList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.calendarColorBox = new ReflectiveCode.GMinder.Controls.ColorButton();
            this.okCancelFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.calendarClearButton = new System.Windows.Forms.Button();
            this.CalendarsFormTableLayoutPanel.SuspendLayout();
            this.loginGroupBox.SuspendLayout();
            this.loginSettingsFlowLayoutPanel.SuspendLayout();
            this.calendarsGroupBox.SuspendLayout();
            this.calendardsTableLayoutPanel.SuspendLayout();
            this.calendarsEditFlowLayoutPanel.SuspendLayout();
            this.okCancelFlowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // CalendarsFormTableLayoutPanel
            // 
            resources.ApplyResources(this.CalendarsFormTableLayoutPanel, "CalendarsFormTableLayoutPanel");
            this.CalendarsFormTableLayoutPanel.Controls.Add(this.loginGroupBox, 0, 0);
            this.CalendarsFormTableLayoutPanel.Controls.Add(this.calendarsGroupBox, 0, 1);
            this.CalendarsFormTableLayoutPanel.Controls.Add(this.okCancelFlowLayoutPanel, 0, 2);
            this.CalendarsFormTableLayoutPanel.Name = "CalendarsFormTableLayoutPanel";
            // 
            // loginGroupBox
            // 
            resources.ApplyResources(this.loginGroupBox, "loginGroupBox");
            this.loginGroupBox.Controls.Add(this.loginSettingsFlowLayoutPanel);
            this.loginGroupBox.Name = "loginGroupBox";
            this.loginGroupBox.TabStop = false;
            // 
            // loginSettingsFlowLayoutPanel
            // 
            resources.ApplyResources(this.loginSettingsFlowLayoutPanel, "loginSettingsFlowLayoutPanel");
            this.loginSettingsFlowLayoutPanel.Controls.Add(this.loginButton);
            this.loginSettingsFlowLayoutPanel.Name = "loginSettingsFlowLayoutPanel";
            // 
            // loginButton
            // 
            resources.ApplyResources(this.loginButton, "loginButton");
            this.loginButton.Name = "loginButton";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginSet_Click);
            // 
            // calendarsGroupBox
            // 
            this.calendarsGroupBox.Controls.Add(this.calendardsTableLayoutPanel);
            resources.ApplyResources(this.calendarsGroupBox, "calendarsGroupBox");
            this.calendarsGroupBox.Name = "calendarsGroupBox";
            this.calendarsGroupBox.TabStop = false;
            // 
            // calendardsTableLayoutPanel
            // 
            resources.ApplyResources(this.calendardsTableLayoutPanel, "calendardsTableLayoutPanel");
            this.calendardsTableLayoutPanel.Controls.Add(this.calendarNameLabel, 0, 1);
            this.calendardsTableLayoutPanel.Controls.Add(this.calendarColorLabel, 0, 3);
            this.calendardsTableLayoutPanel.Controls.Add(this.calendarUrlLabel, 0, 2);
            this.calendardsTableLayoutPanel.Controls.Add(this.calendarsEditFlowLayoutPanel, 0, 4);
            this.calendardsTableLayoutPanel.Controls.Add(this.calendarNameTextBox, 1, 1);
            this.calendardsTableLayoutPanel.Controls.Add(this.calendarUrlTextBox, 1, 2);
            this.calendardsTableLayoutPanel.Controls.Add(this.calendarList, 0, 0);
            this.calendardsTableLayoutPanel.Controls.Add(this.calendarColorBox, 1, 3);
            this.calendardsTableLayoutPanel.Name = "calendardsTableLayoutPanel";
            // 
            // calendarNameLabel
            // 
            resources.ApplyResources(this.calendarNameLabel, "calendarNameLabel");
            this.calendarNameLabel.Name = "calendarNameLabel";
            // 
            // calendarColorLabel
            // 
            resources.ApplyResources(this.calendarColorLabel, "calendarColorLabel");
            this.calendarColorLabel.Name = "calendarColorLabel";
            // 
            // calendarUrlLabel
            // 
            resources.ApplyResources(this.calendarUrlLabel, "calendarUrlLabel");
            this.calendarUrlLabel.Name = "calendarUrlLabel";
            // 
            // calendarsEditFlowLayoutPanel
            // 
            resources.ApplyResources(this.calendarsEditFlowLayoutPanel, "calendarsEditFlowLayoutPanel");
            this.calendardsTableLayoutPanel.SetColumnSpan(this.calendarsEditFlowLayoutPanel, 2);
            this.calendarsEditFlowLayoutPanel.Controls.Add(this.calendarAddButton);
            this.calendarsEditFlowLayoutPanel.Controls.Add(this.calendarRemoveButton);
            this.calendarsEditFlowLayoutPanel.Controls.Add(this.calendarClearButton);
            this.calendarsEditFlowLayoutPanel.Controls.Add(this.calendarDownloadButton);
            this.calendarsEditFlowLayoutPanel.Name = "calendarsEditFlowLayoutPanel";
            // 
            // calendarAddButton
            // 
            resources.ApplyResources(this.calendarAddButton, "calendarAddButton");
            this.calendarAddButton.Name = "calendarAddButton";
            this.calendarAddButton.UseVisualStyleBackColor = true;
            this.calendarAddButton.Click += new System.EventHandler(this.calendarAdd_Click);
            // 
            // calendarRemoveButton
            // 
            resources.ApplyResources(this.calendarRemoveButton, "calendarRemoveButton");
            this.calendarRemoveButton.Name = "calendarRemoveButton";
            this.calendarRemoveButton.UseVisualStyleBackColor = true;
            this.calendarRemoveButton.Click += new System.EventHandler(this.calendarRemove_Click);
            // 
            // calendarDownloadButton
            // 
            resources.ApplyResources(this.calendarDownloadButton, "calendarDownloadButton");
            this.calendarDownloadButton.Name = "calendarDownloadButton";
            this.calendarDownloadButton.UseVisualStyleBackColor = true;
            this.calendarDownloadButton.Click += new System.EventHandler(this.calendarDownload_Click);
            // 
            // calendarNameTextBox
            // 
            resources.ApplyResources(this.calendarNameTextBox, "calendarNameTextBox");
            this.calendarNameTextBox.Name = "calendarNameTextBox";
            this.calendarNameTextBox.TextChanged += new System.EventHandler(this.calendarName_TextChanged);
            // 
            // calendarUrlTextBox
            // 
            resources.ApplyResources(this.calendarUrlTextBox, "calendarUrlTextBox");
            this.calendarUrlTextBox.Name = "calendarUrlTextBox";
            this.calendarUrlTextBox.TextChanged += new System.EventHandler(this.calendarUrl_TextChanged);
            // 
            // calendarList
            // 
            this.calendarList.CheckBoxes = true;
            this.calendarList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.calendardsTableLayoutPanel.SetColumnSpan(this.calendarList, 2);
            resources.ApplyResources(this.calendarList, "calendarList");
            this.calendarList.FullRowSelect = true;
            this.calendarList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.calendarList.MultiSelect = false;
            this.calendarList.Name = "calendarList";
            this.calendarList.UseCompatibleStateImageBehavior = false;
            this.calendarList.View = System.Windows.Forms.View.Details;
            this.calendarList.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.calendarList_ItemChecked);
            this.calendarList.SelectedIndexChanged += new System.EventHandler(this.calendarList_SelectedIndexChanged);
            this.calendarList.ClientSizeChanged += new System.EventHandler(this.calendarList_ClientSizeChanged);
            this.calendarList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.calendarList_KeyDown);
            // 
            // columnHeader1
            // 
            resources.ApplyResources(this.columnHeader1, "columnHeader1");
            // 
            // calendarColorBox
            // 
            resources.ApplyResources(this.calendarColorBox, "calendarColorBox");
            this.calendarColorBox.BackColor = System.Drawing.Color.Black;
            this.calendarColorBox.Color = System.Drawing.Color.Black;
            this.calendarColorBox.ColorDialog = null;
            this.calendarColorBox.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.calendarColorBox.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.calendarColorBox.Name = "calendarColorBox";
            this.calendarColorBox.UseVisualStyleBackColor = false;
            this.calendarColorBox.Click += new System.EventHandler(this.calendarColor_Click);
            // 
            // okCancelFlowLayoutPanel
            // 
            resources.ApplyResources(this.okCancelFlowLayoutPanel, "okCancelFlowLayoutPanel");
            this.okCancelFlowLayoutPanel.Controls.Add(this.cancelButton);
            this.okCancelFlowLayoutPanel.Controls.Add(this.okButton);
            this.okCancelFlowLayoutPanel.Name = "okCancelFlowLayoutPanel";
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this.okButton, "okButton");
            this.okButton.Name = "okButton";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // calendarClearButton
            // 
            resources.ApplyResources(this.calendarClearButton, "calendarClearButton");
            this.calendarClearButton.Name = "calendarClearButton";
            this.calendarClearButton.UseVisualStyleBackColor = true;
            this.calendarClearButton.Click += new System.EventHandler(this.calendarClear_Click);
            // 
            // Calendars
            // 
            this.AcceptButton = this.okButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.Controls.Add(this.CalendarsFormTableLayoutPanel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Calendars";
            this.CalendarsFormTableLayoutPanel.ResumeLayout(false);
            this.CalendarsFormTableLayoutPanel.PerformLayout();
            this.loginGroupBox.ResumeLayout(false);
            this.loginGroupBox.PerformLayout();
            this.loginSettingsFlowLayoutPanel.ResumeLayout(false);
            this.calendarsGroupBox.ResumeLayout(false);
            this.calendardsTableLayoutPanel.ResumeLayout(false);
            this.calendardsTableLayoutPanel.PerformLayout();
            this.calendarsEditFlowLayoutPanel.ResumeLayout(false);
            this.okCancelFlowLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel CalendarsFormTableLayoutPanel;
        private System.Windows.Forms.GroupBox loginGroupBox;
        private System.Windows.Forms.FlowLayoutPanel loginSettingsFlowLayoutPanel;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.GroupBox calendarsGroupBox;
        private System.Windows.Forms.FlowLayoutPanel okCancelFlowLayoutPanel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.TableLayoutPanel calendardsTableLayoutPanel;
        private System.Windows.Forms.Label calendarNameLabel;
        private System.Windows.Forms.Label calendarColorLabel;
        private System.Windows.Forms.Label calendarUrlLabel;
        private System.Windows.Forms.FlowLayoutPanel calendarsEditFlowLayoutPanel;
        private System.Windows.Forms.Button calendarAddButton;
        private System.Windows.Forms.Button calendarRemoveButton;
        private System.Windows.Forms.Button calendarDownloadButton;
        private System.Windows.Forms.TextBox calendarNameTextBox;
        private System.Windows.Forms.TextBox calendarUrlTextBox;
        private System.Windows.Forms.ListView calendarList;
        private Controls.ColorButton calendarColorBox;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button calendarClearButton;
    }
}