namespace TSAPIDemo
{
    partial class DTMFSelectSubForm
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
            this.okButton = new System.Windows.Forms.Button();
            this.DTMFSequenceLabel = new System.Windows.Forms.Label();
            this.DTMFSequenceTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(92, 47);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 5;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // DTMFSequenceLabel
            // 
            this.DTMFSequenceLabel.AutoSize = true;
            this.DTMFSequenceLabel.Location = new System.Drawing.Point(19, 19);
            this.DTMFSequenceLabel.Name = "DTMFSequenceLabel";
            this.DTMFSequenceLabel.Size = new System.Drawing.Size(90, 13);
            this.DTMFSequenceLabel.TabIndex = 4;
            this.DTMFSequenceLabel.Text = "DTMF sequence:";
            // 
            // DTMFSequenceTextBox
            // 
            this.DTMFSequenceTextBox.Location = new System.Drawing.Point(115, 16);
            this.DTMFSequenceTextBox.Name = "DTMFSequenceTextBox";
            this.DTMFSequenceTextBox.Size = new System.Drawing.Size(100, 20);
            this.DTMFSequenceTextBox.TabIndex = 3;
            // 
            // DTMFSelectSubForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 87);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.DTMFSequenceLabel);
            this.Controls.Add(this.DTMFSequenceTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DTMFSelectSubForm";
            this.Text = "DTMF signal";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label DTMFSequenceLabel;
        internal System.Windows.Forms.TextBox DTMFSequenceTextBox;
    }
}