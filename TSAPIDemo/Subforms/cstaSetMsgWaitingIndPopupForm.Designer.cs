namespace TSAPIDemo
{
    partial class cstaSetMsgWaitingIndPopupForm
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
            this.MWIGroupBox = new System.Windows.Forms.GroupBox();
            this.enabledMWIRadioButton = new System.Windows.Forms.RadioButton();
            this.disabledMWIRadioButton = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.MWIGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // MWIGroupBox
            // 
            this.MWIGroupBox.Controls.Add(this.button1);
            this.MWIGroupBox.Controls.Add(this.enabledMWIRadioButton);
            this.MWIGroupBox.Controls.Add(this.disabledMWIRadioButton);
            this.MWIGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MWIGroupBox.Location = new System.Drawing.Point(0, 0);
            this.MWIGroupBox.Name = "MWIGroupBox";
            this.MWIGroupBox.Size = new System.Drawing.Size(186, 66);
            this.MWIGroupBox.TabIndex = 0;
            this.MWIGroupBox.TabStop = false;
            // 
            // enabledMWIRadioButton
            // 
            this.enabledMWIRadioButton.AutoSize = true;
            this.enabledMWIRadioButton.Location = new System.Drawing.Point(12, 39);
            this.enabledMWIRadioButton.Name = "enabledMWIRadioButton";
            this.enabledMWIRadioButton.Size = new System.Drawing.Size(84, 17);
            this.enabledMWIRadioButton.TabIndex = 1;
            this.enabledMWIRadioButton.Text = "Enable MWI";
            this.enabledMWIRadioButton.UseVisualStyleBackColor = true;
            // 
            // disabledMWIRadioButton
            // 
            this.disabledMWIRadioButton.AutoSize = true;
            this.disabledMWIRadioButton.Checked = true;
            this.disabledMWIRadioButton.Location = new System.Drawing.Point(12, 16);
            this.disabledMWIRadioButton.Name = "disabledMWIRadioButton";
            this.disabledMWIRadioButton.Size = new System.Drawing.Size(86, 17);
            this.disabledMWIRadioButton.TabIndex = 0;
            this.disabledMWIRadioButton.TabStop = true;
            this.disabledMWIRadioButton.Text = "Disable MWI";
            this.disabledMWIRadioButton.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(102, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cstaSetMsgWaitingIndPopupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(186, 66);
            this.Controls.Add(this.MWIGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "cstaSetMsgWaitingIndPopupForm";
            this.Text = "Select MWI State";
            this.MWIGroupBox.ResumeLayout(false);
            this.MWIGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox MWIGroupBox;
        private System.Windows.Forms.RadioButton disabledMWIRadioButton;
        private System.Windows.Forms.RadioButton enabledMWIRadioButton;
        private System.Windows.Forms.Button button1;
    }
}