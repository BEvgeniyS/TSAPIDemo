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

namespace TSAPIDemo.Subforms
{
    partial class SnapShotDeviceForm
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
            this.snapShotDataTree = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // snapShotDataTree
            // 
            this.snapShotDataTree.BackColor = System.Drawing.SystemColors.Window;
            this.snapShotDataTree.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.snapShotDataTree.Location = new System.Drawing.Point(34, 21);
            this.snapShotDataTree.Name = "snapShotDataTree";
            this.snapShotDataTree.Size = new System.Drawing.Size(488, 352);
            this.snapShotDataTree.TabIndex = 8;
            this.snapShotDataTree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.snapShotDataTree_NodeMouseClick);
            // 
            // SnapShotDeviceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 408);
            this.Controls.Add(this.snapShotDataTree);
            this.Name = "SnapShotDeviceForm";
            this.Text = "SnapShotDeviceResults";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TreeView snapShotDataTree;
    }
}