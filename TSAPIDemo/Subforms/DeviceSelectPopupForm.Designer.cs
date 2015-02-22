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
    partial class DeviceSelectPopupForm
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
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(73, 48);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // DeviceSelectSubform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 87);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.deviceIDLabel);
            this.Controls.Add(this.deviceIdTextBox);
            this.Name = "DeviceSelectSubform";
            this.Text = "Select Device";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox deviceIdTextBox;
        private System.Windows.Forms.Label deviceIDLabel;
        private System.Windows.Forms.Button okButton;
    }
}