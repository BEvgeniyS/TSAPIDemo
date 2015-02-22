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
    partial class acsSetHeartbeatIntervalPopupForm
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
            this.heartBeatIntervalTextBox = new System.Windows.Forms.TextBox();
            this.okButtton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // heartBeatIntervalTextBox
            // 
            this.heartBeatIntervalTextBox.Location = new System.Drawing.Point(57, 33);
            this.heartBeatIntervalTextBox.Name = "heartBeatIntervalTextBox";
            this.heartBeatIntervalTextBox.Size = new System.Drawing.Size(106, 20);
            this.heartBeatIntervalTextBox.TabIndex = 0;
            this.heartBeatIntervalTextBox.Text = "20";
            // 
            // okButtton
            // 
            this.okButtton.Location = new System.Drawing.Point(187, 31);
            this.okButtton.Name = "okButtton";
            this.okButtton.Size = new System.Drawing.Size(75, 23);
            this.okButtton.TabIndex = 1;
            this.okButtton.Text = "OK";
            this.okButtton.UseVisualStyleBackColor = true;
            this.okButtton.Click += new System.EventHandler(this.okButtton_Click);
            // 
            // acsSetHeartbeatIntervalPopupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 93);
            this.Controls.Add(this.okButtton);
            this.Controls.Add(this.heartBeatIntervalTextBox);
            this.Name = "acsSetHeartbeatIntervalPopupForm";
            this.Text = "Please enter heartbeat interval in seconds";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox heartBeatIntervalTextBox;
        private System.Windows.Forms.Button okButtton;
    }
}