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
    public partial class attSetBillRatePopupForm : Form
    {
        public Att.ATTBillType_t billType;
        public float billRate;
        public attSetBillRatePopupForm()
        {
            InitializeComponent();
        }

        private Att.ATTBillType_t GetBillType()
        {
            var checkedBillTypeButton = this.billTypeGroupBox.Controls.OfType<RadioButton>()
                                      .FirstOrDefault(rb => rb.Checked);
            if (checkedBillTypeButton == this.BT_NEW_RATERadioButton)
                return Att.ATTBillType_t.BT_NEW_RATE;
            else if (checkedBillTypeButton == this.BT_FLAT_RATERadioButton)
                return Att.ATTBillType_t.BT_FLAT_RATE;
            else if (checkedBillTypeButton == this.BT_PREMIUM_CHARGERadioButton)
                return Att.ATTBillType_t.BT_PREMIUM_CHARGE;
            else if (checkedBillTypeButton == this.BT_PREMIUM_CREDITRadioButton)
                return Att.ATTBillType_t.BT_PREMIUM_CREDIT;
            else if (checkedBillTypeButton == this.BT_FREE_CALLRadioButton)
                return Att.ATTBillType_t.BT_FREE_CALL;
            return Att.ATTBillType_t.BT_FREE_CALL;
        }

        private void goButton_Click(object sender, EventArgs e)
        {
            this.billType = GetBillType();
            if (!float.TryParse(this.billRateTextBox.Text, out this.billRate))
            {
                MessageBox.Show("Please enter the correct bill rate");
                return;
            }
            this.DialogResult = DialogResult.OK;
        }
    }
}
