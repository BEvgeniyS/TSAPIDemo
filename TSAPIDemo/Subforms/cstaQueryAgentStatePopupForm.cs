using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Tsapi;

namespace TSAPIDemo
{
    public partial class cstaQueryAgentStatePopupForm : Form
    {
        public Csta.DeviceID_t device;
        public Csta.DeviceID_t split;

        public cstaQueryAgentStatePopupForm()
        {
            InitializeComponent();
        }

        private void goButton_Click(object sender, EventArgs e)
        {
            this.device = DeviceTextBox.Text;
            this.split = splitTextBox.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void PressEnter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                goButton_Click(sender, e);
            }
        }
    }
}
