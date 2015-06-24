namespace ReflectiveCode.GMinder
{
    partial class Create
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Create));
            this.CreateFormTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.addButton = new System.Windows.Forms.Button();
            this.newEventNameTextBox = new System.Windows.Forms.TextBox();
            this.exampleLabel = new System.Windows.Forms.Label();
            this.calendarList = new System.Windows.Forms.ComboBox();
            this.dtPicker = new System.Windows.Forms.DateTimePicker();
            this.CreateFormTableLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // CreateFormTableLayout
            // 
            resources.ApplyResources(this.CreateFormTableLayout, "CreateFormTableLayout");
            this.CreateFormTableLayout.Controls.Add(this.addButton, 1, 1);
            this.CreateFormTableLayout.Controls.Add(this.newEventNameTextBox, 0, 1);
            this.CreateFormTableLayout.Controls.Add(this.exampleLabel, 0, 0);
            this.CreateFormTableLayout.Controls.Add(this.calendarList, 0, 3);
            this.CreateFormTableLayout.Controls.Add(this.dtPicker, 0, 2);
            this.CreateFormTableLayout.Name = "CreateFormTableLayout";
            // 
            // addButton
            // 
            resources.ApplyResources(this.addButton, "addButton");
            this.addButton.Name = "addButton";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.HandleAddButton);
            // 
            // newEventNameTextBox
            // 
            resources.ApplyResources(this.newEventNameTextBox, "newEventNameTextBox");
            this.newEventNameTextBox.Name = "newEventNameTextBox";
            this.newEventNameTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HandleKeyPress);
            // 
            // exampleLabel
            // 
            resources.ApplyResources(this.exampleLabel, "exampleLabel");
            this.CreateFormTableLayout.SetColumnSpan(this.exampleLabel, 2);
            this.exampleLabel.Name = "exampleLabel";
            // 
            // calendarList
            // 
            resources.ApplyResources(this.calendarList, "calendarList");
            this.calendarList.BackColor = System.Drawing.SystemColors.Window;
            this.CreateFormTableLayout.SetColumnSpan(this.calendarList, 2);
            this.calendarList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.calendarList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.calendarList.FormatString = "{Name}";
            this.calendarList.FormattingEnabled = true;
            this.calendarList.Name = "calendarList";
            this.calendarList.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.calendarList_DrawItem);
            // 
            // dtPicker
            // 
            resources.ApplyResources(this.dtPicker, "dtPicker");
            this.dtPicker.Checked = false;
            this.CreateFormTableLayout.SetColumnSpan(this.dtPicker, 2);
            this.dtPicker.Name = "dtPicker";
            this.dtPicker.ShowCheckBox = true;
            // 
            // Create
            // 
            this.AcceptButton = this.addButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CreateFormTableLayout);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Create";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HandleKeyPress);
            this.CreateFormTableLayout.ResumeLayout(false);
            this.CreateFormTableLayout.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel CreateFormTableLayout;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.TextBox newEventNameTextBox;
        private System.Windows.Forms.Label exampleLabel;
        private System.Windows.Forms.ComboBox calendarList;
        private System.Windows.Forms.DateTimePicker dtPicker;
    }
}