namespace TSAPIDemo
{
    partial class cstaQueryAgentStatePopupForm
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
            this.DeviceTextBox = new System.Windows.Forms.TextBox();
            this.splitTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.goButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DeviceTextBox
            // 
            this.DeviceTextBox.Location = new System.Drawing.Point(65, 12);
            this.DeviceTextBox.Name = "DeviceTextBox";
            this.DeviceTextBox.Size = new System.Drawing.Size(100, 20);
            this.DeviceTextBox.TabIndex = 0;
            this.DeviceTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PressEnter);
            // 
            // splitTextBox
            // 
            this.splitTextBox.Location = new System.Drawing.Point(65, 38);
            this.splitTextBox.Name = "splitTextBox";
            this.splitTextBox.Size = new System.Drawing.Size(100, 20);
            this.splitTextBox.TabIndex = 1;
            this.splitTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PressEnter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "AgentId";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Split";
            // 
            // goButton
            // 
            this.goButton.Location = new System.Drawing.Point(65, 70);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(75, 23);
            this.goButton.TabIndex = 4;
            this.goButton.Text = "GO";
            this.goButton.UseVisualStyleBackColor = true;
            this.goButton.Click += new System.EventHandler(this.goButton_Click);
            // 
            // cstaQueryAgentStatePopupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(193, 105);
            this.Controls.Add(this.goButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.splitTextBox);
            this.Controls.Add(this.DeviceTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "cstaQueryAgentStatePopupForm";
            this.Text = "Select Agent/Split";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox DeviceTextBox;
        private System.Windows.Forms.TextBox splitTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button goButton;
    }
}