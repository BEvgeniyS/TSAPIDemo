using Tsapi;
using System.Configuration;
namespace TSAPIDemo
{
    partial class mainForm
    {
        public static System.Configuration.Configuration config  = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        public Acs.ACSHandle_t acsHandle;
        public Acs.PrivateData_t privData;

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
            this.enumServerNamesButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.apiVer_textBox = new System.Windows.Forms.TextBox();
            this.appName_textBox = new System.Windows.Forms.TextBox();
            this.password_textBox = new System.Windows.Forms.TextBox();
            this.login_textBox = new System.Windows.Forms.TextBox();
            this.serverId_textBox = new System.Windows.Forms.TextBox();
            this.TestsTab = new System.Windows.Forms.TabPage();
            this.deflectCallButton = new System.Windows.Forms.Button();
            this.cstaConsultantCallButton = new System.Windows.Forms.Button();
            this.cstaConferenceCallButton = new System.Windows.Forms.Button();
            this.cstaAnswerCallButton = new System.Windows.Forms.Button();
            this.cstaAlternateCallButton = new System.Windows.Forms.Button();
            this.cstaQueryCallMonitorButton = new System.Windows.Forms.Button();
            this.cstaGetAPICapsButton = new System.Windows.Forms.Button();
            this.acsSetHeartbeatIntervalButton = new System.Windows.Forms.Button();
            this.acsQueryAuthInfoButton = new System.Windows.Forms.Button();
            this.acsFlushEventQueueButton = new System.Windows.Forms.Button();
            this.cstaGetDeviceListButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.streamCheckbox = new System.Windows.Forms.CheckBox();
            this.deviceLabel = new System.Windows.Forms.Label();
            this.deviceTextBox = new System.Windows.Forms.TextBox();
            this.snapShotDeviceButton = new System.Windows.Forms.Button();
            this.mainTabs = new System.Windows.Forms.TabControl();
            this.cstaHoldButton = new System.Windows.Forms.Button();
            this.configTab.SuspendLayout();
            this.TestsTab.SuspendLayout();
            this.mainTabs.SuspendLayout();
            this.SuspendLayout();
            // 
            // configTab
            // 
            this.configTab.Controls.Add(this.enumServerNamesButton);
            this.configTab.Controls.Add(this.label6);
            this.configTab.Controls.Add(this.label5);
            this.configTab.Controls.Add(this.label4);
            this.configTab.Controls.Add(this.label3);
            this.configTab.Controls.Add(this.label2);
            this.configTab.Controls.Add(this.apiVer_textBox);
            this.configTab.Controls.Add(this.appName_textBox);
            this.configTab.Controls.Add(this.password_textBox);
            this.configTab.Controls.Add(this.login_textBox);
            this.configTab.Controls.Add(this.serverId_textBox);
            this.configTab.Location = new System.Drawing.Point(4, 22);
            this.configTab.Name = "configTab";
            this.configTab.Padding = new System.Windows.Forms.Padding(3);
            this.configTab.Size = new System.Drawing.Size(940, 501);
            this.configTab.TabIndex = 1;
            this.configTab.Text = "Configuration";
            this.configTab.UseVisualStyleBackColor = true;
            // 
            // enumServerNamesButton
            // 
            this.enumServerNamesButton.Location = new System.Drawing.Point(355, 48);
            this.enumServerNamesButton.Name = "enumServerNamesButton";
            this.enumServerNamesButton.Size = new System.Drawing.Size(75, 23);
            this.enumServerNamesButton.TabIndex = 13;
            this.enumServerNamesButton.Text = "EnumServerNames";
            this.enumServerNamesButton.UseVisualStyleBackColor = true;
            this.enumServerNamesButton.Click += new System.EventHandler(this.enumServerNamesButton_Click);
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
            // serverId_textBox
            // 
            this.serverId_textBox.Location = new System.Drawing.Point(130, 51);
            this.serverId_textBox.MaxLength = 64;
            this.serverId_textBox.Name = "serverId_textBox";
            this.serverId_textBox.Size = new System.Drawing.Size(219, 20);
            this.serverId_textBox.TabIndex = 0;
            this.serverId_textBox.Leave += new System.EventHandler(this.serverID_textBox_Leave);
            // 
            // TestsTab
            // 
            this.TestsTab.Controls.Add(this.cstaHoldButton);
            this.TestsTab.Controls.Add(this.deflectCallButton);
            this.TestsTab.Controls.Add(this.cstaConsultantCallButton);
            this.TestsTab.Controls.Add(this.cstaConferenceCallButton);
            this.TestsTab.Controls.Add(this.cstaAnswerCallButton);
            this.TestsTab.Controls.Add(this.cstaAlternateCallButton);
            this.TestsTab.Controls.Add(this.cstaQueryCallMonitorButton);
            this.TestsTab.Controls.Add(this.cstaGetAPICapsButton);
            this.TestsTab.Controls.Add(this.acsSetHeartbeatIntervalButton);
            this.TestsTab.Controls.Add(this.acsQueryAuthInfoButton);
            this.TestsTab.Controls.Add(this.acsFlushEventQueueButton);
            this.TestsTab.Controls.Add(this.cstaGetDeviceListButton);
            this.TestsTab.Controls.Add(this.label7);
            this.TestsTab.Controls.Add(this.streamCheckbox);
            this.TestsTab.Controls.Add(this.deviceLabel);
            this.TestsTab.Controls.Add(this.deviceTextBox);
            this.TestsTab.Controls.Add(this.snapShotDeviceButton);
            this.TestsTab.Location = new System.Drawing.Point(4, 22);
            this.TestsTab.Name = "TestsTab";
            this.TestsTab.Padding = new System.Windows.Forms.Padding(3);
            this.TestsTab.Size = new System.Drawing.Size(940, 501);
            this.TestsTab.TabIndex = 0;
            this.TestsTab.Text = "Tests";
            this.TestsTab.UseVisualStyleBackColor = true;
            // 
            // deflectCallButton
            // 
            this.deflectCallButton.Location = new System.Drawing.Point(225, 51);
            this.deflectCallButton.Name = "deflectCallButton";
            this.deflectCallButton.Size = new System.Drawing.Size(75, 23);
            this.deflectCallButton.TabIndex = 20;
            this.deflectCallButton.Text = "DeflectCall";
            this.deflectCallButton.UseVisualStyleBackColor = true;
            this.deflectCallButton.Click += new System.EventHandler(this.deflectCallButton_Click);
            // 
            // cstaConsultantCallButton
            // 
            this.cstaConsultantCallButton.Location = new System.Drawing.Point(132, 108);
            this.cstaConsultantCallButton.Name = "cstaConsultantCallButton";
            this.cstaConsultantCallButton.Size = new System.Drawing.Size(87, 23);
            this.cstaConsultantCallButton.TabIndex = 19;
            this.cstaConsultantCallButton.Text = "ConsultantCall";
            this.cstaConsultantCallButton.UseVisualStyleBackColor = true;
            this.cstaConsultantCallButton.Click += new System.EventHandler(this.cstaConsultantCallButton_Click);
            // 
            // cstaConferenceCallButton
            // 
            this.cstaConferenceCallButton.Location = new System.Drawing.Point(132, 79);
            this.cstaConferenceCallButton.Name = "cstaConferenceCallButton";
            this.cstaConferenceCallButton.Size = new System.Drawing.Size(87, 23);
            this.cstaConferenceCallButton.TabIndex = 18;
            this.cstaConferenceCallButton.Text = "ConferenceCall";
            this.cstaConferenceCallButton.UseVisualStyleBackColor = true;
            this.cstaConferenceCallButton.Click += new System.EventHandler(this.cstaConferenceCallButton_Click);
            // 
            // cstaAnswerCallButton
            // 
            this.cstaAnswerCallButton.Location = new System.Drawing.Point(132, 51);
            this.cstaAnswerCallButton.Name = "cstaAnswerCallButton";
            this.cstaAnswerCallButton.Size = new System.Drawing.Size(87, 23);
            this.cstaAnswerCallButton.TabIndex = 17;
            this.cstaAnswerCallButton.Text = "AnswerCall";
            this.cstaAnswerCallButton.UseVisualStyleBackColor = true;
            this.cstaAnswerCallButton.Click += new System.EventHandler(this.cstaAnswerCallButton_Click);
            // 
            // cstaAlternateCallButton
            // 
            this.cstaAlternateCallButton.Location = new System.Drawing.Point(26, 109);
            this.cstaAlternateCallButton.Name = "cstaAlternateCallButton";
            this.cstaAlternateCallButton.Size = new System.Drawing.Size(98, 23);
            this.cstaAlternateCallButton.TabIndex = 16;
            this.cstaAlternateCallButton.Text = "AlternateCall";
            this.cstaAlternateCallButton.UseVisualStyleBackColor = true;
            this.cstaAlternateCallButton.Click += new System.EventHandler(this.cstaAlternateCallButton_Click);
            // 
            // cstaQueryCallMonitorButton
            // 
            this.cstaQueryCallMonitorButton.Location = new System.Drawing.Point(141, 371);
            this.cstaQueryCallMonitorButton.Name = "cstaQueryCallMonitorButton";
            this.cstaQueryCallMonitorButton.Size = new System.Drawing.Size(113, 23);
            this.cstaQueryCallMonitorButton.TabIndex = 15;
            this.cstaQueryCallMonitorButton.Text = "QueryCallMonitor";
            this.cstaQueryCallMonitorButton.UseVisualStyleBackColor = true;
            this.cstaQueryCallMonitorButton.Click += new System.EventHandler(this.cstaQueryCallMonitorButton_Click);
            // 
            // cstaGetAPICapsButton
            // 
            this.cstaGetAPICapsButton.Location = new System.Drawing.Point(141, 306);
            this.cstaGetAPICapsButton.Name = "cstaGetAPICapsButton";
            this.cstaGetAPICapsButton.Size = new System.Drawing.Size(113, 23);
            this.cstaGetAPICapsButton.TabIndex = 14;
            this.cstaGetAPICapsButton.Text = "GetAPICaps";
            this.cstaGetAPICapsButton.UseVisualStyleBackColor = true;
            this.cstaGetAPICapsButton.Click += new System.EventHandler(this.cstaGetAPICapsButton_Click);
            // 
            // acsSetHeartbeatIntervalButton
            // 
            this.acsSetHeartbeatIntervalButton.Location = new System.Drawing.Point(22, 365);
            this.acsSetHeartbeatIntervalButton.Name = "acsSetHeartbeatIntervalButton";
            this.acsSetHeartbeatIntervalButton.Size = new System.Drawing.Size(113, 34);
            this.acsSetHeartbeatIntervalButton.TabIndex = 13;
            this.acsSetHeartbeatIntervalButton.Text = "Set Heartbeat Interval";
            this.acsSetHeartbeatIntervalButton.UseVisualStyleBackColor = true;
            this.acsSetHeartbeatIntervalButton.Click += new System.EventHandler(this.acsSetHeartbeatIntervalButton_Click);
            // 
            // acsQueryAuthInfoButton
            // 
            this.acsQueryAuthInfoButton.Location = new System.Drawing.Point(22, 335);
            this.acsQueryAuthInfoButton.Name = "acsQueryAuthInfoButton";
            this.acsQueryAuthInfoButton.Size = new System.Drawing.Size(113, 23);
            this.acsQueryAuthInfoButton.TabIndex = 12;
            this.acsQueryAuthInfoButton.Text = "QueryAuthInfo";
            this.acsQueryAuthInfoButton.UseVisualStyleBackColor = true;
            this.acsQueryAuthInfoButton.Click += new System.EventHandler(this.acsQueryAuthInfoButton_Click);
            // 
            // acsFlushEventQueueButton
            // 
            this.acsFlushEventQueueButton.Location = new System.Drawing.Point(22, 306);
            this.acsFlushEventQueueButton.Name = "acsFlushEventQueueButton";
            this.acsFlushEventQueueButton.Size = new System.Drawing.Size(113, 23);
            this.acsFlushEventQueueButton.TabIndex = 5;
            this.acsFlushEventQueueButton.Text = "FlushEventQueue";
            this.acsFlushEventQueueButton.UseVisualStyleBackColor = true;
            this.acsFlushEventQueueButton.Click += new System.EventHandler(this.flushEventQueueButton_Click);
            // 
            // cstaGetDeviceListButton
            // 
            this.cstaGetDeviceListButton.Location = new System.Drawing.Point(141, 335);
            this.cstaGetDeviceListButton.Name = "cstaGetDeviceListButton";
            this.cstaGetDeviceListButton.Size = new System.Drawing.Size(113, 23);
            this.cstaGetDeviceListButton.TabIndex = 11;
            this.cstaGetDeviceListButton.Text = "GetDeviceList";
            this.cstaGetDeviceListButton.UseVisualStyleBackColor = true;
            this.cstaGetDeviceListButton.Click += new System.EventHandler(this.cstaGetDeviceListButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 452);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "ACS stream status:";
            // 
            // streamCheckbox
            // 
            this.streamCheckbox.AutoSize = true;
            this.streamCheckbox.Location = new System.Drawing.Point(22, 468);
            this.streamCheckbox.Name = "streamCheckbox";
            this.streamCheckbox.Size = new System.Drawing.Size(95, 17);
            this.streamCheckbox.TabIndex = 9;
            this.streamCheckbox.Text = "not connected";
            this.streamCheckbox.UseVisualStyleBackColor = true;
            this.streamCheckbox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.connectionCheckbox_MouseClick);
            // 
            // deviceLabel
            // 
            this.deviceLabel.AutoSize = true;
            this.deviceLabel.Location = new System.Drawing.Point(23, 37);
            this.deviceLabel.Name = "deviceLabel";
            this.deviceLabel.Size = new System.Drawing.Size(72, 13);
            this.deviceLabel.TabIndex = 6;
            this.deviceLabel.Text = "Device Name";
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
            // snapShotDeviceButton
            // 
            this.snapShotDeviceButton.Enabled = false;
            this.snapShotDeviceButton.Location = new System.Drawing.Point(26, 79);
            this.snapShotDeviceButton.Name = "snapShotDeviceButton";
            this.snapShotDeviceButton.Size = new System.Drawing.Size(98, 23);
            this.snapShotDeviceButton.TabIndex = 4;
            this.snapShotDeviceButton.Text = "SnapShotDevice";
            this.snapShotDeviceButton.UseVisualStyleBackColor = true;
            this.snapShotDeviceButton.Click += new System.EventHandler(this.snapShotDeviceButton_Click);
            // 
            // mainTabs
            // 
            this.mainTabs.Controls.Add(this.TestsTab);
            this.mainTabs.Controls.Add(this.configTab);
            this.mainTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTabs.Location = new System.Drawing.Point(0, 0);
            this.mainTabs.Name = "mainTabs";
            this.mainTabs.SelectedIndex = 0;
            this.mainTabs.Size = new System.Drawing.Size(948, 527);
            this.mainTabs.TabIndex = 4;
            this.mainTabs.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.mainTabs_Selecting);
            // 
            // cstaHoldButton
            // 
            this.cstaHoldButton.Location = new System.Drawing.Point(225, 79);
            this.cstaHoldButton.Name = "cstaHoldButton";
            this.cstaHoldButton.Size = new System.Drawing.Size(75, 23);
            this.cstaHoldButton.TabIndex = 21;
            this.cstaHoldButton.Text = "HoldCall";
            this.cstaHoldButton.UseVisualStyleBackColor = true;
            this.cstaHoldButton.Click += new System.EventHandler(this.cstaHoldButton_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 527);
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
        private System.Windows.Forms.TextBox serverId_textBox;
        private System.Windows.Forms.TabPage TestsTab;
        private System.Windows.Forms.CheckBox streamCheckbox;
        private System.Windows.Forms.Label deviceLabel;
        private System.Windows.Forms.TextBox deviceTextBox;
        private System.Windows.Forms.Button snapShotDeviceButton;
        private System.Windows.Forms.TabControl mainTabs;
        public bool configured = false;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button cstaGetDeviceListButton;
        private System.Windows.Forms.Button acsFlushEventQueueButton;
        private System.Windows.Forms.Button enumServerNamesButton;
        private System.Windows.Forms.Button acsQueryAuthInfoButton;
        private System.Windows.Forms.Button acsSetHeartbeatIntervalButton;
        private System.Windows.Forms.Button cstaGetAPICapsButton;
        private System.Windows.Forms.Button cstaQueryCallMonitorButton;
        private System.Windows.Forms.Button cstaAlternateCallButton;
        private System.Windows.Forms.Button cstaAnswerCallButton;
        private System.Windows.Forms.Button cstaConferenceCallButton;
        private System.Windows.Forms.Button cstaConsultantCallButton;
        private System.Windows.Forms.Button deflectCallButton;
        private System.Windows.Forms.Button cstaHoldButton;



    }
}

