namespace TSAPIDemo
{
    partial class attSelectiveListeningHoldPopupForm
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
            this.connGroupBox1 = new System.Windows.Forms.GroupBox();
            this.connGroupBox2 = new System.Windows.Forms.GroupBox();
            this.blockAllCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.goButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // connGroupBox1
            // 
            this.connGroupBox1.Location = new System.Drawing.Point(13, 54);
            this.connGroupBox1.Name = "connGroupBox1";
            this.connGroupBox1.Size = new System.Drawing.Size(130, 330);
            this.connGroupBox1.TabIndex = 0;
            this.connGroupBox1.TabStop = false;
            // 
            // connGroupBox2
            // 
            this.connGroupBox2.Location = new System.Drawing.Point(168, 54);
            this.connGroupBox2.Name = "connGroupBox2";
            this.connGroupBox2.Size = new System.Drawing.Size(150, 330);
            this.connGroupBox2.TabIndex = 1;
            this.connGroupBox2.TabStop = false;
            // 
            // blockAllCheckBox
            // 
            this.blockAllCheckBox.AutoSize = true;
            this.blockAllCheckBox.Location = new System.Drawing.Point(181, 390);
            this.blockAllCheckBox.Name = "blockAllCheckBox";
            this.blockAllCheckBox.Size = new System.Drawing.Size(66, 17);
            this.blockAllCheckBox.TabIndex = 2;
            this.blockAllCheckBox.Text = "Block all";
            this.blockAllCheckBox.UseVisualStyleBackColor = true;
            this.blockAllCheckBox.CheckedChanged += new System.EventHandler(this.blockAllCheckBox_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(13, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Block this party";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(114, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "from hearing";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(178, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "this party";
            // 
            // goButton
            // 
            this.goButton.Location = new System.Drawing.Point(242, 30);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(75, 23);
            this.goButton.TabIndex = 5;
            this.goButton.Text = "Go";
            this.goButton.UseVisualStyleBackColor = true;
            this.goButton.Click += new System.EventHandler(this.goButton_Click);
            // 
            // attSelectiveListeningHoldPopupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 415);
            this.Controls.Add(this.blockAllCheckBox);
            this.Controls.Add(this.goButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.connGroupBox2);
            this.Controls.Add(this.connGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "attSelectiveListeningHoldPopupForm";
            this.Text = "Selective Listening Hold";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox connGroupBox1;
        private System.Windows.Forms.GroupBox connGroupBox2;
        private System.Windows.Forms.CheckBox blockAllCheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button goButton;
    }
}