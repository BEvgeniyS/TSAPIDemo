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
    partial class cstaConsultationCallPopupForm
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
            this.deviceIdLabel = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.consultantCallTypeGroupBox = new System.Windows.Forms.GroupBox();
            this.DirectAgentCallRadioButton = new System.Windows.Forms.RadioButton();
            this.consultationCallRadioButton = new System.Windows.Forms.RadioButton();
            this.supervisorAssistCallRadioButton = new System.Windows.Forms.RadioButton();
            this.consultantCallTypeGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // deviceIdTextBox
            // 
            this.deviceIdTextBox.Location = new System.Drawing.Point(40, 29);
            this.deviceIdTextBox.Name = "deviceIdTextBox";
            this.deviceIdTextBox.Size = new System.Drawing.Size(100, 20);
            this.deviceIdTextBox.TabIndex = 0;
            this.deviceIdTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.deviceIdTextBox_KeyDown);
            // 
            // deviceIdLabel
            // 
            this.deviceIdLabel.AutoSize = true;
            this.deviceIdLabel.Location = new System.Drawing.Point(49, 9);
            this.deviceIdLabel.Name = "deviceIdLabel";
            this.deviceIdLabel.Size = new System.Drawing.Size(83, 13);
            this.deviceIdLabel.TabIndex = 1;
            this.deviceIdLabel.Text = "Enter DeviceID:";
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(146, 29);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // consultantCallTypeGroupBox
            // 
            this.consultantCallTypeGroupBox.Controls.Add(this.supervisorAssistCallRadioButton);
            this.consultantCallTypeGroupBox.Controls.Add(this.DirectAgentCallRadioButton);
            this.consultantCallTypeGroupBox.Controls.Add(this.consultationCallRadioButton);
            this.consultantCallTypeGroupBox.Location = new System.Drawing.Point(33, 55);
            this.consultantCallTypeGroupBox.Name = "consultantCallTypeGroupBox";
            this.consultantCallTypeGroupBox.Size = new System.Drawing.Size(129, 92);
            this.consultantCallTypeGroupBox.TabIndex = 3;
            this.consultantCallTypeGroupBox.TabStop = false;
            this.consultantCallTypeGroupBox.Text = "Consultant Call type";
            // 
            // DirectAgentCallRadioButton
            // 
            this.DirectAgentCallRadioButton.AutoSize = true;
            this.DirectAgentCallRadioButton.Location = new System.Drawing.Point(9, 43);
            this.DirectAgentCallRadioButton.Name = "DirectAgentCallRadioButton";
            this.DirectAgentCallRadioButton.Size = new System.Drawing.Size(98, 17);
            this.DirectAgentCallRadioButton.TabIndex = 1;
            this.DirectAgentCallRadioButton.Text = "DirectAgentCall";
            this.DirectAgentCallRadioButton.UseVisualStyleBackColor = true;
            this.DirectAgentCallRadioButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DirectAgentCallRadioButton_KeyDown);
            // 
            // consultationCallRadioButton
            // 
            this.consultationCallRadioButton.AutoSize = true;
            this.consultationCallRadioButton.Checked = true;
            this.consultationCallRadioButton.Location = new System.Drawing.Point(9, 21);
            this.consultationCallRadioButton.Name = "consultationCallRadioButton";
            this.consultationCallRadioButton.Size = new System.Drawing.Size(100, 17);
            this.consultationCallRadioButton.TabIndex = 0;
            this.consultationCallRadioButton.TabStop = true;
            this.consultationCallRadioButton.Text = "ConsultationCall";
            this.consultationCallRadioButton.UseVisualStyleBackColor = true;
            this.consultationCallRadioButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.consultationCallRadioButton_KeyDown);
            // 
            // supervisorAssistCallRadioButton
            // 
            this.supervisorAssistCallRadioButton.AutoSize = true;
            this.supervisorAssistCallRadioButton.Location = new System.Drawing.Point(9, 67);
            this.supervisorAssistCallRadioButton.Name = "supervisorAssistCallRadioButton";
            this.supervisorAssistCallRadioButton.Size = new System.Drawing.Size(119, 17);
            this.supervisorAssistCallRadioButton.TabIndex = 2;
            this.supervisorAssistCallRadioButton.Text = "SupervisorAssistCall";
            this.supervisorAssistCallRadioButton.UseVisualStyleBackColor = true;
            this.supervisorAssistCallRadioButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.supervisorAssistCallRadioButton_KeyDown);
            // 
            // cstaConsultationCallPopupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 159);
            this.Controls.Add(this.consultantCallTypeGroupBox);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.deviceIdLabel);
            this.Controls.Add(this.deviceIdTextBox);
            this.Name = "cstaConsultationCallPopupForm";
            this.Text = "Consultation Call";
            this.consultantCallTypeGroupBox.ResumeLayout(false);
            this.consultantCallTypeGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox deviceIdTextBox;
        private System.Windows.Forms.Label deviceIdLabel;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.GroupBox consultantCallTypeGroupBox;
        internal System.Windows.Forms.RadioButton DirectAgentCallRadioButton;
        internal System.Windows.Forms.RadioButton consultationCallRadioButton;
        internal System.Windows.Forms.RadioButton supervisorAssistCallRadioButton;
    }
}