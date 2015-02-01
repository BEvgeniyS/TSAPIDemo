using Tsapi;
using System.Configuration;
namespace TSAPIDemo
{
    partial class mainForm
    {
        public static System.Configuration.Configuration config  = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        Acs.ACSHandle_t acsHandle;
        Acs.PrivateData_t privData;

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
            this.configTab = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.apiVer_textBox = new System.Windows.Forms.TextBox();
            this.appName_textBox = new System.Windows.Forms.TextBox();
            this.password_textBox = new System.Windows.Forms.TextBox();
            this.login_textBox = new System.Windows.Forms.TextBox();
            this.serverID_textBox = new System.Windows.Forms.TextBox();
            this.TestsTab = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.streamCheckbox = new System.Windows.Forms.CheckBox();
            this.snapShotDataTree = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.deviceTextBox = new System.Windows.Forms.TextBox();
            this.goButton = new System.Windows.Forms.Button();
            this.mainTabs = new System.Windows.Forms.TabControl();
            this.configTab.SuspendLayout();
            this.TestsTab.SuspendLayout();
            this.mainTabs.SuspendLayout();
            this.SuspendLayout();
            // 
            // configTab
            // 
            this.configTab.Controls.Add(this.label6);
            this.configTab.Controls.Add(this.label5);
            this.configTab.Controls.Add(this.label4);
            this.configTab.Controls.Add(this.label3);
            this.configTab.Controls.Add(this.label2);
            this.configTab.Controls.Add(this.apiVer_textBox);
            this.configTab.Controls.Add(this.appName_textBox);
            this.configTab.Controls.Add(this.password_textBox);
            this.configTab.Controls.Add(this.login_textBox);
            this.configTab.Controls.Add(this.serverID_textBox);
            this.configTab.Location = new System.Drawing.Point(4, 22);
            this.configTab.Name = "configTab";
            this.configTab.Padding = new System.Windows.Forms.Padding(3);
            this.configTab.Size = new System.Drawing.Size(595, 382);
            this.configTab.TabIndex = 1;
            this.configTab.Text = "Configuration";
            this.configTab.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(56, 158);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "ApiVer";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(56, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "AppName";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(56, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(56, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Login";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Server ID";
            // 
            // apiVer_textBox
            // 
            this.apiVer_textBox.Location = new System.Drawing.Point(130, 155);
            this.apiVer_textBox.Name = "apiVer_textBox";
            this.apiVer_textBox.Size = new System.Drawing.Size(300, 20);
            this.apiVer_textBox.TabIndex = 4;
            this.apiVer_textBox.Leave += new System.EventHandler(this.apiVer_textBox_Leave);
            // 
            // appName_textBox
            // 
            this.appName_textBox.Location = new System.Drawing.Point(130, 129);
            this.appName_textBox.Name = "appName_textBox";
            this.appName_textBox.Size = new System.Drawing.Size(300, 20);
            this.appName_textBox.TabIndex = 3;
            this.appName_textBox.Leave += new System.EventHandler(this.appName_textBox_Leave);
            // 
            // password_textBox
            // 
            this.password_textBox.Location = new System.Drawing.Point(130, 103);
            this.password_textBox.Name = "password_textBox";
            this.password_textBox.Size = new System.Drawing.Size(300, 20);
            this.password_textBox.TabIndex = 2;
            this.password_textBox.Leave += new System.EventHandler(this.password_textBox_Leave);
            // 
            // login_textBox
            // 
            this.login_textBox.Location = new System.Drawing.Point(130, 77);
            this.login_textBox.Name = "login_textBox";
            this.login_textBox.Size = new System.Drawing.Size(300, 20);
            this.login_textBox.TabIndex = 1;
            this.login_textBox.Leave += new System.EventHandler(this.login_textBox_Leave);
            // 
            // serverID_textBox
            // 
            this.serverID_textBox.Location = new System.Drawing.Point(130, 51);
            this.serverID_textBox.MaxLength = 64;
            this.serverID_textBox.Name = "serverID_textBox";
            this.serverID_textBox.Size = new System.Drawing.Size(300, 20);
            this.serverID_textBox.TabIndex = 0;
            this.serverID_textBox.Leave += new System.EventHandler(this.serverID_textBox_Leave);
            // 
            // TestsTab
            // 
            this.TestsTab.Controls.Add(this.button1);
            this.TestsTab.Controls.Add(this.label7);
            this.TestsTab.Controls.Add(this.streamCheckbox);
            this.TestsTab.Controls.Add(this.snapShotDataTree);
            this.TestsTab.Controls.Add(this.label1);
            this.TestsTab.Controls.Add(this.deviceTextBox);
            this.TestsTab.Controls.Add(this.goButton);
            this.TestsTab.Location = new System.Drawing.Point(4, 22);
            this.TestsTab.Name = "TestsTab";
            this.TestsTab.Padding = new System.Windows.Forms.Padding(3);
            this.TestsTab.Size = new System.Drawing.Size(595, 382);
            this.TestsTab.TabIndex = 0;
            this.TestsTab.Text = "Tests";
            this.TestsTab.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(26, 135);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "GetDeviceList";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 329);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "ACS stream status:";
            // 
            // streamCheckbox
            // 
            this.streamCheckbox.AutoSize = true;
            this.streamCheckbox.Location = new System.Drawing.Point(26, 345);
            this.streamCheckbox.Name = "streamCheckbox";
            this.streamCheckbox.Size = new System.Drawing.Size(95, 17);
            this.streamCheckbox.TabIndex = 9;
            this.streamCheckbox.Text = "not connected";
            this.streamCheckbox.UseVisualStyleBackColor = true;
            this.streamCheckbox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.connectionCheckbox_MouseClick);
            // 
            // snapShotDataTree
            // 
            this.snapShotDataTree.BackColor = System.Drawing.SystemColors.Window;
            this.snapShotDataTree.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.snapShotDataTree.Location = new System.Drawing.Point(156, 53);
            this.snapShotDataTree.Name = "snapShotDataTree";
            this.snapShotDataTree.Size = new System.Drawing.Size(393, 280);
            this.snapShotDataTree.TabIndex = 7;
            this.snapShotDataTree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.snapShotDataTree_NodeMouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Snapshot Device";
            // 
            // deviceTextBox
            // 
            this.deviceTextBox.Location = new System.Drawing.Point(26, 53);
            this.deviceTextBox.MaxLength = 4;
            this.deviceTextBox.Name = "deviceTextBox";
            this.deviceTextBox.Size = new System.Drawing.Size(100, 20);
            this.deviceTextBox.TabIndex = 5;
            this.deviceTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.deviceTextBox_KeyPress);
            // 
            // goButton
            // 
            this.goButton.Enabled = false;
            this.goButton.Location = new System.Drawing.Point(37, 79);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(75, 23);
            this.goButton.TabIndex = 4;
            this.goButton.Text = "go";
            this.goButton.UseVisualStyleBackColor = true;
            this.goButton.Click += new System.EventHandler(this.goButton_Click);
            // 
            // mainTabs
            // 
            this.mainTabs.Controls.Add(this.TestsTab);
            this.mainTabs.Controls.Add(this.configTab);
            this.mainTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTabs.Location = new System.Drawing.Point(0, 0);
            this.mainTabs.Name = "mainTabs";
            this.mainTabs.SelectedIndex = 0;
            this.mainTabs.Size = new System.Drawing.Size(603, 408);
            this.mainTabs.TabIndex = 4;
            this.mainTabs.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.mainTabs_Selecting);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 408);
            this.Controls.Add(this.mainTabs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "mainForm";
            this.Text = "TSAPI demo app";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.mainForm_FormClosed);
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.configTab.ResumeLayout(false);
            this.configTab.PerformLayout();
            this.TestsTab.ResumeLayout(false);
            this.TestsTab.PerformLayout();
            this.mainTabs.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage configTab;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox apiVer_textBox;
        private System.Windows.Forms.TextBox appName_textBox;
        private System.Windows.Forms.TextBox password_textBox;
        private System.Windows.Forms.TextBox login_textBox;
        private System.Windows.Forms.TextBox serverID_textBox;
        private System.Windows.Forms.TabPage TestsTab;
        private System.Windows.Forms.CheckBox streamCheckbox;
        private System.Windows.Forms.TreeView snapShotDataTree;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox deviceTextBox;
        private System.Windows.Forms.Button goButton;
        private System.Windows.Forms.TabControl mainTabs;
        public bool configured = false;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;



    }
}

