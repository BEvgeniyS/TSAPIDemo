using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TSAPIDemo
{
    public partial class cstaSetMsgWaitingIndPopupForm : Form
    {
        internal bool mwiEnabled;
        public cstaSetMsgWaitingIndPopupForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var checkedMWIButton = this.MWIGroupBox.Controls.OfType<RadioButton>()
                          .FirstOrDefault(rb => rb.Checked);
            if (checkedMWIButton == this.disabledMWIRadioButton)
                this.mwiEnabled = false;
            else
                this.mwiEnabled = true;
            this.DialogResult = DialogResult.OK;
        }
    }
}
