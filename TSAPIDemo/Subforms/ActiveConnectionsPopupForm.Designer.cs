using Tsapi;
namespace TSAPIDemo
{
    partial class ActiveConnectionsPopupForm
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
            this.connectionListBox = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.selectHoldButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // connectionListBox
            // 
            this.connectionListBox.CheckOnClick = true;
            this.connectionListBox.FormattingEnabled = true;
            this.connectionListBox.Location = new System.Drawing.Point(29, 42);
            this.connectionListBox.Name = "connectionListBox";
            this.connectionListBox.Size = new System.Drawing.Size(292, 259);
            this.connectionListBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Connections";
            // 
            // selectHoldButton
            // 
            this.selectHoldButton.Location = new System.Drawing.Point(350, 52);
            this.selectHoldButton.Name = "selectHoldButton";
            this.selectHoldButton.Size = new System.Drawing.Size(75, 23);
            this.selectHoldButton.TabIndex = 2;
            this.selectHoldButton.Text = "SelectHold";
            this.selectHoldButton.UseVisualStyleBackColor = true;
            this.selectHoldButton.Click += new System.EventHandler(this.selectHoldButton_Click);
            // 
            // ActiveConnectionsPopupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 327);
            this.Controls.Add(this.selectHoldButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.connectionListBox);
            this.Name = "ActiveConnectionsPopupForm";
            this.Text = "ActiveConnectionsPopupForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox connectionListBox;
        private System.Windows.Forms.Label label1;
        internal Csta.ConnectionID_t[] connections;
        internal mainForm _parent;
        private System.Windows.Forms.Button selectHoldButton;
    }
}