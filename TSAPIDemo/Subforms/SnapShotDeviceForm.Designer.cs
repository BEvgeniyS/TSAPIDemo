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