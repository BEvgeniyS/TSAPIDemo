namespace TSAPIDemo
{
    partial class attSetBillRatePopupForm
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
            this.billTypeGroupBox = new System.Windows.Forms.GroupBox();
            this.billRateTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.goButton = new System.Windows.Forms.Button();
            this.BT_NEW_RATERadioButton = new System.Windows.Forms.RadioButton();
            this.BT_FLAT_RATERadioButton = new System.Windows.Forms.RadioButton();
            this.BT_PREMIUM_CHARGERadioButton = new System.Windows.Forms.RadioButton();
            this.BT_PREMIUM_CREDITRadioButton = new System.Windows.Forms.RadioButton();
            this.BT_FREE_CALLRadioButton = new System.Windows.Forms.RadioButton();
            this.billTypeGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // billTypeGroupBox
            // 
            this.billTypeGroupBox.Controls.Add(this.BT_FREE_CALLRadioButton);
            this.billTypeGroupBox.Controls.Add(this.BT_PREMIUM_CREDITRadioButton);
            this.billTypeGroupBox.Controls.Add(this.BT_PREMIUM_CHARGERadioButton);
            this.billTypeGroupBox.Controls.Add(this.BT_FLAT_RATERadioButton);
            this.billTypeGroupBox.Controls.Add(this.BT_NEW_RATERadioButton);
            this.billTypeGroupBox.Location = new System.Drawing.Point(12, 12);
            this.billTypeGroupBox.Name = "billTypeGroupBox";
            this.billTypeGroupBox.Size = new System.Drawing.Size(162, 144);
            this.billTypeGroupBox.TabIndex = 0;
            this.billTypeGroupBox.TabStop = false;
            this.billTypeGroupBox.Text = "Bill type";
            // 
            // billRateTextBox
            // 
            this.billRateTextBox.Location = new System.Drawing.Point(82, 162);
            this.billRateTextBox.Name = "billRateTextBox";
            this.billRateTextBox.Size = new System.Drawing.Size(64, 20);
            this.billRateTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Bill Rate";
            // 
            // goButton
            // 
            this.goButton.Location = new System.Drawing.Point(59, 197);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(75, 23);
            this.goButton.TabIndex = 3;
            this.goButton.Text = "GO";
            this.goButton.UseVisualStyleBackColor = true;
            this.goButton.Click += new System.EventHandler(this.goButton_Click);
            // 
            // BT_NEW_RATERadioButton
            // 
            this.BT_NEW_RATERadioButton.AutoSize = true;
            this.BT_NEW_RATERadioButton.Checked = true;
            this.BT_NEW_RATERadioButton.Location = new System.Drawing.Point(6, 19);
            this.BT_NEW_RATERadioButton.Name = "BT_NEW_RATERadioButton";
            this.BT_NEW_RATERadioButton.Size = new System.Drawing.Size(106, 17);
            this.BT_NEW_RATERadioButton.TabIndex = 0;
            this.BT_NEW_RATERadioButton.TabStop = true;
            this.BT_NEW_RATERadioButton.Text = "BT_NEW_RATE";
            this.BT_NEW_RATERadioButton.UseVisualStyleBackColor = true;
            // 
            // BT_FLAT_RATERadioButton
            // 
            this.BT_FLAT_RATERadioButton.AutoSize = true;
            this.BT_FLAT_RATERadioButton.Location = new System.Drawing.Point(6, 42);
            this.BT_FLAT_RATERadioButton.Name = "BT_FLAT_RATERadioButton";
            this.BT_FLAT_RATERadioButton.Size = new System.Drawing.Size(106, 17);
            this.BT_FLAT_RATERadioButton.TabIndex = 1;
            this.BT_FLAT_RATERadioButton.TabStop = true;
            this.BT_FLAT_RATERadioButton.Text = "BT_FLAT_RATE";
            this.BT_FLAT_RATERadioButton.UseVisualStyleBackColor = true;
            // 
            // BT_PREMIUM_CHARGERadioButton
            // 
            this.BT_PREMIUM_CHARGERadioButton.AutoSize = true;
            this.BT_PREMIUM_CHARGERadioButton.Location = new System.Drawing.Point(6, 65);
            this.BT_PREMIUM_CHARGERadioButton.Name = "BT_PREMIUM_CHARGERadioButton";
            this.BT_PREMIUM_CHARGERadioButton.Size = new System.Drawing.Size(147, 17);
            this.BT_PREMIUM_CHARGERadioButton.TabIndex = 2;
            this.BT_PREMIUM_CHARGERadioButton.TabStop = true;
            this.BT_PREMIUM_CHARGERadioButton.Text = "BT_PREMIUM_CHARGE";
            this.BT_PREMIUM_CHARGERadioButton.UseVisualStyleBackColor = true;
            // 
            // BT_PREMIUM_CREDITRadioButton
            // 
            this.BT_PREMIUM_CREDITRadioButton.AutoSize = true;
            this.BT_PREMIUM_CREDITRadioButton.Location = new System.Drawing.Point(6, 88);
            this.BT_PREMIUM_CREDITRadioButton.Name = "BT_PREMIUM_CREDITRadioButton";
            this.BT_PREMIUM_CREDITRadioButton.Size = new System.Drawing.Size(142, 17);
            this.BT_PREMIUM_CREDITRadioButton.TabIndex = 3;
            this.BT_PREMIUM_CREDITRadioButton.TabStop = true;
            this.BT_PREMIUM_CREDITRadioButton.Text = "BT_PREMIUM_CREDIT";
            this.BT_PREMIUM_CREDITRadioButton.UseVisualStyleBackColor = true;
            // 
            // BT_FREE_CALLRadioButton
            // 
            this.BT_FREE_CALLRadioButton.AutoSize = true;
            this.BT_FREE_CALLRadioButton.Location = new System.Drawing.Point(6, 111);
            this.BT_FREE_CALLRadioButton.Name = "BT_FREE_CALLRadioButton";
            this.BT_FREE_CALLRadioButton.Size = new System.Drawing.Size(105, 17);
            this.BT_FREE_CALLRadioButton.TabIndex = 4;
            this.BT_FREE_CALLRadioButton.TabStop = true;
            this.BT_FREE_CALLRadioButton.Text = "BT_FREE_CALL";
            this.BT_FREE_CALLRadioButton.UseVisualStyleBackColor = true;
            // 
            // attSetBillRatePopupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(186, 232);
            this.Controls.Add(this.goButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.billRateTextBox);
            this.Controls.Add(this.billTypeGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "attSetBillRatePopupForm";
            this.Text = "Set Bill Rate";
            this.billTypeGroupBox.ResumeLayout(false);
            this.billTypeGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox billTypeGroupBox;
        private System.Windows.Forms.RadioButton BT_FREE_CALLRadioButton;
        private System.Windows.Forms.RadioButton BT_PREMIUM_CREDITRadioButton;
        private System.Windows.Forms.RadioButton BT_PREMIUM_CHARGERadioButton;
        private System.Windows.Forms.RadioButton BT_FLAT_RATERadioButton;
        private System.Windows.Forms.RadioButton BT_NEW_RATERadioButton;
        private System.Windows.Forms.TextBox billRateTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button goButton;
    }
}