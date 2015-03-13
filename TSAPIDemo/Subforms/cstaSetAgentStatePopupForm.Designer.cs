namespace TSAPIDemo
{
    partial class cstaSetAgentStatePopupForm
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
            this.agentIdTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.goButton = new System.Windows.Forms.Button();
            this.agentModeGroupBox = new System.Windows.Forms.GroupBox();
            this.AM_WORK_NOT_READYRadioButton = new System.Windows.Forms.RadioButton();
            this.AM_READYRadioButton = new System.Windows.Forms.RadioButton();
            this.AM_NOT_READYRadioButton = new System.Windows.Forms.RadioButton();
            this.AM_LOG_OUTRadioButton = new System.Windows.Forms.RadioButton();
            this.AM_LOG_INRadioButton = new System.Windows.Forms.RadioButton();
            this.workModeGroupBox = new System.Windows.Forms.GroupBox();
            this.WM_MANUAL_INRadioButton = new System.Windows.Forms.RadioButton();
            this.WM_AUTO_INRadioButton = new System.Windows.Forms.RadioButton();
            this.WM_AFTCAL_WKRadioButton = new System.Windows.Forms.RadioButton();
            this.WM_AUX_WORKRadioButton = new System.Windows.Forms.RadioButton();
            this.enablePendingCheckBox = new System.Windows.Forms.CheckBox();
            this.reasonCodeTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.agentModeGroupBox.SuspendLayout();
            this.workModeGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // agentIdTextBox
            // 
            this.agentIdTextBox.Location = new System.Drawing.Point(134, 12);
            this.agentIdTextBox.Name = "agentIdTextBox";
            this.agentIdTextBox.Size = new System.Drawing.Size(100, 20);
            this.agentIdTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(82, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "AgentID";
            // 
            // goButton
            // 
            this.goButton.Location = new System.Drawing.Point(109, 218);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(161, 23);
            this.goButton.TabIndex = 2;
            this.goButton.Text = "GO";
            this.goButton.UseVisualStyleBackColor = true;
            this.goButton.Click += new System.EventHandler(this.Go_Button_Click);
            // 
            // agentModeGroupBox
            // 
            this.agentModeGroupBox.Controls.Add(this.AM_WORK_NOT_READYRadioButton);
            this.agentModeGroupBox.Controls.Add(this.AM_READYRadioButton);
            this.agentModeGroupBox.Controls.Add(this.AM_NOT_READYRadioButton);
            this.agentModeGroupBox.Controls.Add(this.AM_LOG_OUTRadioButton);
            this.agentModeGroupBox.Controls.Add(this.AM_LOG_INRadioButton);
            this.agentModeGroupBox.Location = new System.Drawing.Point(12, 38);
            this.agentModeGroupBox.Name = "agentModeGroupBox";
            this.agentModeGroupBox.Size = new System.Drawing.Size(165, 139);
            this.agentModeGroupBox.TabIndex = 7;
            this.agentModeGroupBox.TabStop = false;
            this.agentModeGroupBox.Text = "AgentMode";
            // 
            // AM_WORK_NOT_READYRadioButton
            // 
            this.AM_WORK_NOT_READYRadioButton.AutoSize = true;
            this.AM_WORK_NOT_READYRadioButton.Location = new System.Drawing.Point(7, 110);
            this.AM_WORK_NOT_READYRadioButton.Name = "AM_WORK_NOT_READYRadioButton";
            this.AM_WORK_NOT_READYRadioButton.Size = new System.Drawing.Size(153, 17);
            this.AM_WORK_NOT_READYRadioButton.TabIndex = 4;
            this.AM_WORK_NOT_READYRadioButton.Text = "AM_WORK_NOT_READY";
            this.AM_WORK_NOT_READYRadioButton.UseVisualStyleBackColor = true;
            this.AM_WORK_NOT_READYRadioButton.CheckedChanged += new System.EventHandler(this.AgentModeRadioButton_CheckedChanged);
            // 
            // AM_READYRadioButton
            // 
            this.AM_READYRadioButton.AutoSize = true;
            this.AM_READYRadioButton.Location = new System.Drawing.Point(7, 87);
            this.AM_READYRadioButton.Name = "AM_READYRadioButton";
            this.AM_READYRadioButton.Size = new System.Drawing.Size(84, 17);
            this.AM_READYRadioButton.TabIndex = 3;
            this.AM_READYRadioButton.Text = "AM_READY";
            this.AM_READYRadioButton.UseVisualStyleBackColor = true;
            this.AM_READYRadioButton.CheckedChanged += new System.EventHandler(this.AgentModeRadioButton_CheckedChanged);
            // 
            // AM_NOT_READYRadioButton
            // 
            this.AM_NOT_READYRadioButton.AutoSize = true;
            this.AM_NOT_READYRadioButton.Location = new System.Drawing.Point(7, 64);
            this.AM_NOT_READYRadioButton.Name = "AM_NOT_READYRadioButton";
            this.AM_NOT_READYRadioButton.Size = new System.Drawing.Size(113, 17);
            this.AM_NOT_READYRadioButton.TabIndex = 2;
            this.AM_NOT_READYRadioButton.Text = "AM_NOT_READY";
            this.AM_NOT_READYRadioButton.UseVisualStyleBackColor = true;
            this.AM_NOT_READYRadioButton.CheckedChanged += new System.EventHandler(this.AgentModeRadioButton_CheckedChanged);
            // 
            // AM_LOG_OUTRadioButton
            // 
            this.AM_LOG_OUTRadioButton.AutoSize = true;
            this.AM_LOG_OUTRadioButton.Location = new System.Drawing.Point(7, 43);
            this.AM_LOG_OUTRadioButton.Name = "AM_LOG_OUTRadioButton";
            this.AM_LOG_OUTRadioButton.Size = new System.Drawing.Size(98, 17);
            this.AM_LOG_OUTRadioButton.TabIndex = 1;
            this.AM_LOG_OUTRadioButton.Text = "AM_LOG_OUT";
            this.AM_LOG_OUTRadioButton.UseVisualStyleBackColor = true;
            this.AM_LOG_OUTRadioButton.CheckedChanged += new System.EventHandler(this.AgentModeRadioButton_CheckedChanged);
            // 
            // AM_LOG_INRadioButton
            // 
            this.AM_LOG_INRadioButton.AutoSize = true;
            this.AM_LOG_INRadioButton.Checked = true;
            this.AM_LOG_INRadioButton.Location = new System.Drawing.Point(7, 20);
            this.AM_LOG_INRadioButton.Name = "AM_LOG_INRadioButton";
            this.AM_LOG_INRadioButton.Size = new System.Drawing.Size(86, 17);
            this.AM_LOG_INRadioButton.TabIndex = 0;
            this.AM_LOG_INRadioButton.TabStop = true;
            this.AM_LOG_INRadioButton.Text = "AM_LOG_IN";
            this.AM_LOG_INRadioButton.UseVisualStyleBackColor = true;
            this.AM_LOG_INRadioButton.CheckedChanged += new System.EventHandler(this.AgentModeRadioButton_CheckedChanged);
            // 
            // workModeGroupBox
            // 
            this.workModeGroupBox.Controls.Add(this.WM_MANUAL_INRadioButton);
            this.workModeGroupBox.Controls.Add(this.WM_AUTO_INRadioButton);
            this.workModeGroupBox.Controls.Add(this.WM_AFTCAL_WKRadioButton);
            this.workModeGroupBox.Controls.Add(this.WM_AUX_WORKRadioButton);
            this.workModeGroupBox.Location = new System.Drawing.Point(183, 38);
            this.workModeGroupBox.Name = "workModeGroupBox";
            this.workModeGroupBox.Size = new System.Drawing.Size(165, 115);
            this.workModeGroupBox.TabIndex = 8;
            this.workModeGroupBox.TabStop = false;
            this.workModeGroupBox.Text = "WorkMode";
            // 
            // WM_MANUAL_INRadioButton
            // 
            this.WM_MANUAL_INRadioButton.AutoSize = true;
            this.WM_MANUAL_INRadioButton.Location = new System.Drawing.Point(7, 89);
            this.WM_MANUAL_INRadioButton.Name = "WM_MANUAL_INRadioButton";
            this.WM_MANUAL_INRadioButton.Size = new System.Drawing.Size(113, 17);
            this.WM_MANUAL_INRadioButton.TabIndex = 3;
            this.WM_MANUAL_INRadioButton.Text = "WM_MANUAL_IN";
            this.WM_MANUAL_INRadioButton.UseVisualStyleBackColor = true;
            this.WM_MANUAL_INRadioButton.CheckedChanged += new System.EventHandler(this.WorkModeRadioButton_CheckedChanged);
            // 
            // WM_AUTO_INRadioButton
            // 
            this.WM_AUTO_INRadioButton.AutoSize = true;
            this.WM_AUTO_INRadioButton.Location = new System.Drawing.Point(7, 66);
            this.WM_AUTO_INRadioButton.Name = "WM_AUTO_INRadioButton";
            this.WM_AUTO_INRadioButton.Size = new System.Drawing.Size(98, 17);
            this.WM_AUTO_INRadioButton.TabIndex = 2;
            this.WM_AUTO_INRadioButton.Text = "WM_AUTO_IN";
            this.WM_AUTO_INRadioButton.UseVisualStyleBackColor = true;
            this.WM_AUTO_INRadioButton.CheckedChanged += new System.EventHandler(this.WorkModeRadioButton_CheckedChanged);
            // 
            // WM_AFTCAL_WKRadioButton
            // 
            this.WM_AFTCAL_WKRadioButton.AutoSize = true;
            this.WM_AFTCAL_WKRadioButton.Location = new System.Drawing.Point(7, 43);
            this.WM_AFTCAL_WKRadioButton.Name = "WM_AFTCAL_WKRadioButton";
            this.WM_AFTCAL_WKRadioButton.Size = new System.Drawing.Size(115, 17);
            this.WM_AFTCAL_WKRadioButton.TabIndex = 1;
            this.WM_AFTCAL_WKRadioButton.Text = "WM_AFTCAL_WK";
            this.WM_AFTCAL_WKRadioButton.UseVisualStyleBackColor = true;
            this.WM_AFTCAL_WKRadioButton.CheckedChanged += new System.EventHandler(this.WorkModeRadioButton_CheckedChanged);
            // 
            // WM_AUX_WORKRadioButton
            // 
            this.WM_AUX_WORKRadioButton.AutoSize = true;
            this.WM_AUX_WORKRadioButton.Checked = true;
            this.WM_AUX_WORKRadioButton.Location = new System.Drawing.Point(7, 20);
            this.WM_AUX_WORKRadioButton.Name = "WM_AUX_WORKRadioButton";
            this.WM_AUX_WORKRadioButton.Size = new System.Drawing.Size(113, 17);
            this.WM_AUX_WORKRadioButton.TabIndex = 0;
            this.WM_AUX_WORKRadioButton.TabStop = true;
            this.WM_AUX_WORKRadioButton.Text = "WM_AUX_WORK";
            this.WM_AUX_WORKRadioButton.UseVisualStyleBackColor = true;
            this.WM_AUX_WORKRadioButton.CheckedChanged += new System.EventHandler(this.WorkModeRadioButton_CheckedChanged);
            // 
            // enablePendingCheckBox
            // 
            this.enablePendingCheckBox.AutoSize = true;
            this.enablePendingCheckBox.Enabled = false;
            this.enablePendingCheckBox.Location = new System.Drawing.Point(183, 159);
            this.enablePendingCheckBox.Name = "enablePendingCheckBox";
            this.enablePendingCheckBox.Size = new System.Drawing.Size(101, 17);
            this.enablePendingCheckBox.TabIndex = 9;
            this.enablePendingCheckBox.Text = "Enable Pending";
            this.enablePendingCheckBox.UseVisualStyleBackColor = true;
            // 
            // reasonCodeTextBox
            // 
            this.reasonCodeTextBox.Location = new System.Drawing.Point(145, 184);
            this.reasonCodeTextBox.Name = "reasonCodeTextBox";
            this.reasonCodeTextBox.Size = new System.Drawing.Size(57, 20);
            this.reasonCodeTextBox.TabIndex = 10;
            this.reasonCodeTextBox.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(70, 187);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "ReasonCode";
            // 
            // cstaSetAgentStatePopupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 256);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.reasonCodeTextBox);
            this.Controls.Add(this.enablePendingCheckBox);
            this.Controls.Add(this.workModeGroupBox);
            this.Controls.Add(this.agentModeGroupBox);
            this.Controls.Add(this.goButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.agentIdTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "cstaSetAgentStatePopupForm";
            this.Text = "Set Agent State";
            this.agentModeGroupBox.ResumeLayout(false);
            this.agentModeGroupBox.PerformLayout();
            this.workModeGroupBox.ResumeLayout(false);
            this.workModeGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox agentIdTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button goButton;
        private System.Windows.Forms.GroupBox agentModeGroupBox;
        private System.Windows.Forms.GroupBox workModeGroupBox;
        private System.Windows.Forms.CheckBox enablePendingCheckBox;
        private System.Windows.Forms.TextBox reasonCodeTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton AM_WORK_NOT_READYRadioButton;
        private System.Windows.Forms.RadioButton AM_READYRadioButton;
        private System.Windows.Forms.RadioButton AM_NOT_READYRadioButton;
        private System.Windows.Forms.RadioButton AM_LOG_OUTRadioButton;
        private System.Windows.Forms.RadioButton AM_LOG_INRadioButton;
        private System.Windows.Forms.RadioButton WM_MANUAL_INRadioButton;
        private System.Windows.Forms.RadioButton WM_AUTO_INRadioButton;
        private System.Windows.Forms.RadioButton WM_AFTCAL_WKRadioButton;
        private System.Windows.Forms.RadioButton WM_AUX_WORKRadioButton;
    }
}