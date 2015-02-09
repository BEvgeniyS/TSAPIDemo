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
    public partial class acsSetHeartbeatIntervalPopupForm : Form
    {
        public ushort ReturnValue { get; set; } 
        public acsSetHeartbeatIntervalPopupForm()
        {
            InitializeComponent();
        }

        private void okButtton_Click(object sender, EventArgs e)
        {
            int hbInterval;
            Int32.TryParse(this.heartBeatIntervalTextBox.Text, out hbInterval);
            if (hbInterval >= 5 && hbInterval <= 60)
            {
                this.ReturnValue = (ushort)hbInterval;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.None;
            }
        }
    }
}
