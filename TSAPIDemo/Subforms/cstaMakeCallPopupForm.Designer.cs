/*
 Copyright 2015 TSAPI.NET project

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/

namespace TSAPIDemo
{
    partial class cstaMakeCallPopupForm
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
            this.deviceIdTextBox = new System.Windows.Forms.TextBox();
            this.deviceIDLabel = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.destRouteOrSplitLabel = new System.Windows.Forms.Label();
            this.destRouteOrSplitTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.normalCallRadio = new System.Windows.Forms.RadioButton();
            this.supervisorAssistCallRadio = new System.Windows.Forms.RadioButton();
            this.directAgentCallRadio = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // deviceIdTextBox
            // 
            this.deviceIdTextBox.Location = new System.Drawing.Point(113, 22);
            this.deviceIdTextBox.Name = "deviceIdTextBox";
            this.deviceIdTextBox.Size = new System.Drawing.Size(100, 20);
            this.deviceIdTextBox.TabIndex = 0;
            this.deviceIdTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.deviceIdTextBox_KeyDown);
            // 
            // deviceIDLabel
            // 
            this.deviceIDLabel.AutoSize = true;
            this.deviceIDLabel.Location = new System.Drawing.Point(27, 25);
            this.deviceIDLabel.Name = "deviceIDLabel";
            this.deviceIDLabel.Size = new System.Drawing.Size(80, 13);
            this.deviceIDLabel.TabIndex = 1;
            this.deviceIDLabel.Text = "Enter DeviceID";
            this.deviceIDLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(80, 211);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // destRouteOrSplitLabel
            // 
            this.destRouteOrSplitLabel.AutoSize = true;
            this.destRouteOrSplitLabel.Location = new System.Drawing.Point(21, 51);
            this.destRouteOrSplitLabel.Name = "destRouteOrSplitLabel";
            this.destRouteOrSplitLabel.Size = new System.Drawing.Size(86, 13);
            this.destRouteOrSplitLabel.TabIndex = 5;
            this.destRouteOrSplitLabel.Text = "Enter DestRoute";
            this.destRouteOrSplitLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // destRouteOrSplitTextBox
            // 
            this.destRouteOrSplitTextBox.Location = new System.Drawing.Point(113, 48);
            this.destRouteOrSplitTextBox.Name = "destRouteOrSplitTextBox";
            this.destRouteOrSplitTextBox.Size = new System.Drawing.Size(100, 20);
            this.destRouteOrSplitTextBox.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.normalCallRadio);
            this.groupBox1.Controls.Add(this.supervisorAssistCallRadio);
            this.groupBox1.Controls.Add(this.directAgentCallRadio);
            this.groupBox1.Location = new System.Drawing.Point(45, 83);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(157, 87);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "MakeCall type";
            // 
            // normalCallRadio
            // 
            this.normalCallRadio.AutoSize = true;
            this.normalCallRadio.Checked = true;
            this.normalCallRadio.Location = new System.Drawing.Point(7, 17);
            this.normalCallRadio.Name = "normalCallRadio";
            this.normalCallRadio.Size = new System.Drawing.Size(78, 17);
            this.normalCallRadio.TabIndex = 2;
            this.normalCallRadio.TabStop = true;
            this.normalCallRadio.Text = "Normal Call";
            this.normalCallRadio.UseVisualStyleBackColor = true;
            this.normalCallRadio.Click += new System.EventHandler(this.normalCallRadio_Click);
            // 
            // supervisorAssistCallRadio
            // 
            this.supervisorAssistCallRadio.AutoSize = true;
            this.supervisorAssistCallRadio.Location = new System.Drawing.Point(6, 63);
            this.supervisorAssistCallRadio.Name = "supervisorAssistCallRadio";
            this.supervisorAssistCallRadio.Size = new System.Drawing.Size(119, 17);
            this.supervisorAssistCallRadio.TabIndex = 1;
            this.supervisorAssistCallRadio.Text = "SupervisorAssistCall";
            this.supervisorAssistCallRadio.UseVisualStyleBackColor = true;
            this.supervisorAssistCallRadio.Click += new System.EventHandler(this.supervisorAssistCallRadio_Click);
            // 
            // directAgentCallRadio
            // 
            this.directAgentCallRadio.AutoSize = true;
            this.directAgentCallRadio.Location = new System.Drawing.Point(6, 40);
            this.directAgentCallRadio.Name = "directAgentCallRadio";
            this.directAgentCallRadio.Size = new System.Drawing.Size(104, 17);
            this.directAgentCallRadio.TabIndex = 0;
            this.directAgentCallRadio.Text = "Direct-Agent Call";
            this.directAgentCallRadio.UseVisualStyleBackColor = true;
            this.directAgentCallRadio.Click += new System.EventHandler(this.directAgentCallRadio_Click);
            // 
            // cstaMakeCallPopupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 274);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.destRouteOrSplitLabel);
            this.Controls.Add(this.destRouteOrSplitTextBox);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.deviceIDLabel);
            this.Controls.Add(this.deviceIdTextBox);
            this.Name = "cstaMakeCallPopupForm";
            this.Text = "Select Device";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox deviceIdTextBox;
        private System.Windows.Forms.Label deviceIDLabel;
        private System.Windows.Forms.Button okButton;
        internal System.Windows.Forms.Label destRouteOrSplitLabel;
        internal System.Windows.Forms.TextBox destRouteOrSplitTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.RadioButton supervisorAssistCallRadio;
        internal System.Windows.Forms.RadioButton directAgentCallRadio;
        internal System.Windows.Forms.RadioButton normalCallRadio;
    }
}