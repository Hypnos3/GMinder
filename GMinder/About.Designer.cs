namespace ReflectiveCode.GMinder
{
    partial class About
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.aboutTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.productNameLabel = new System.Windows.Forms.Label();
            this.versionLabel = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.linkLatest = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.linkOlder = new System.Windows.Forms.LinkLabel();
            this.linkOldest = new System.Windows.Forms.LinkLabel();
            this.description = new System.Windows.Forms.Label();
            this.aboutTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // aboutTableLayoutPanel
            // 
            resources.ApplyResources(this.aboutTableLayoutPanel, "aboutTableLayoutPanel");
            this.aboutTableLayoutPanel.Controls.Add(this.logoPictureBox, 0, 0);
            this.aboutTableLayoutPanel.Controls.Add(this.productNameLabel, 1, 0);
            this.aboutTableLayoutPanel.Controls.Add(this.versionLabel, 1, 2);
            this.aboutTableLayoutPanel.Controls.Add(this.okButton, 1, 7);
            this.aboutTableLayoutPanel.Controls.Add(this.linkLatest, 1, 3);
            this.aboutTableLayoutPanel.Controls.Add(this.label1, 1, 4);
            this.aboutTableLayoutPanel.Controls.Add(this.linkOlder, 1, 5);
            this.aboutTableLayoutPanel.Controls.Add(this.linkOldest, 1, 6);
            this.aboutTableLayoutPanel.Controls.Add(this.description, 1, 1);
            this.aboutTableLayoutPanel.Name = "aboutTableLayoutPanel";
            // 
            // logoPictureBox
            // 
            resources.ApplyResources(this.logoPictureBox, "logoPictureBox");
            this.logoPictureBox.Name = "logoPictureBox";
            this.aboutTableLayoutPanel.SetRowSpan(this.logoPictureBox, 8);
            this.logoPictureBox.TabStop = false;
            // 
            // productNameLabel
            // 
            resources.ApplyResources(this.productNameLabel, "productNameLabel");
            this.productNameLabel.Name = "productNameLabel";
            // 
            // versionLabel
            // 
            resources.ApplyResources(this.versionLabel, "versionLabel");
            this.versionLabel.Name = "versionLabel";
            // 
            // okButton
            // 
            resources.ApplyResources(this.okButton, "okButton");
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.okButton.Name = "okButton";
            // 
            // linkLatest
            // 
            resources.ApplyResources(this.linkLatest, "linkLatest");
            this.linkLatest.Name = "linkLatest";
            this.linkLatest.TabStop = true;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // linkOlder
            // 
            resources.ApplyResources(this.linkOlder, "linkOlder");
            this.linkOlder.Name = "linkOlder";
            this.linkOlder.TabStop = true;
            // 
            // linkOldest
            // 
            resources.ApplyResources(this.linkOldest, "linkOldest");
            this.linkOldest.Name = "linkOldest";
            this.linkOldest.TabStop = true;
            // 
            // description
            // 
            resources.ApplyResources(this.description, "description");
            this.description.Name = "description";
            // 
            // About
            // 
            this.AcceptButton = this.okButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.aboutTableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "About";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.aboutTableLayoutPanel.ResumeLayout(false);
            this.aboutTableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel aboutTableLayoutPanel;
        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.Label productNameLabel;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.LinkLabel linkLatest;
        private System.Windows.Forms.LinkLabel linkOldest;
        private System.Windows.Forms.LinkLabel linkOlder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label description;
    }
}
