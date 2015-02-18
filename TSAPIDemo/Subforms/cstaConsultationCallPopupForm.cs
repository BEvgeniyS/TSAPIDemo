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
    public partial class cstaConsultationCallPopupForm : Form
    {
        public Csta.DeviceID_t ReturnDeviceId { get; set; }
        public cstaConsultationCallPopupForm()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
                this.ReturnDeviceId = this.deviceIdTextBox.Text;
                this.DialogResult = DialogResult.OK;
        }
    }
}
