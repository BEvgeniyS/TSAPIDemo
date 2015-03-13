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
    public partial class cstaSetAgentStatePopupForm : Form
    {
        public Csta.AgentMode_t agentMode;
        public Att.ATTWorkMode_t workMode;
        public Csta.AgentID_t agentId;
        public int reasonCode;
        public bool enablePending;
        public cstaSetAgentStatePopupForm()
        {
            InitializeComponent();
        }

        private void Go_Button_Click(object sender, EventArgs e)
        {
            if (!Int32.TryParse(this.reasonCodeTextBox.Text, out this.reasonCode) &&
                reasonCode >= 0 &&
                reasonCode <= 99)
            {
                MessageBox.Show("Wrong reason code. Valid reason codes: 0-99");
                return;
            }
            if (this.agentIdTextBox.TextLength == 0)
            {
                MessageBox.Show("Please enter AgentID");
                return;
            }
            this.agentId = this.agentIdTextBox.Text;
            this.enablePending = this.enablePendingCheckBox.Checked;
            GetAgentMode();
            GetWorkMode();
           
        }

        private void GetWorkMode()
        {
            var checkedWorkModeButton = this.workModeGroupBox.Controls.OfType<RadioButton>()
                                      .FirstOrDefault(rb => rb.Checked);
            if (checkedWorkModeButton == this.WM_AUX_WORKRadioButton)
                this.workMode = Att.ATTWorkMode_t.WM_AUX_WORK;
            else if (checkedWorkModeButton == this.WM_AFTCAL_WKRadioButton)
                this.workMode = Att.ATTWorkMode_t.WM_AFTCAL_WK;
            else if (checkedWorkModeButton == this.WM_AUTO_INRadioButton)
                this.workMode = Att.ATTWorkMode_t.WM_AUTO_IN;
            else if (checkedWorkModeButton == this.WM_MANUAL_INRadioButton)
                this.workMode = Att.ATTWorkMode_t.WM_MANUAL_IN;
            else
                this.workMode = Att.ATTWorkMode_t.WM_NONE;
        }

        private void GetAgentMode()
        {
            var checkedButton = this.agentModeGroupBox.Controls.OfType<RadioButton>()
                                      .FirstOrDefault(rb => rb.Checked);
            if (checkedButton == this.AM_LOG_INRadioButton)
            {
                this.agentMode = Csta.AgentMode_t.AM_LOG_IN;
                this.DialogResult = DialogResult.OK;
            }
            else if (checkedButton == this.AM_LOG_OUTRadioButton)
            {
                this.agentMode = Csta.AgentMode_t.AM_LOG_OUT;
                this.DialogResult = DialogResult.OK;
            }
            else if (checkedButton == this.AM_NOT_READYRadioButton)
            {
                this.agentMode = Csta.AgentMode_t.AM_NOT_READY;
                this.DialogResult = DialogResult.OK;
            }
            else if (checkedButton == this.AM_READYRadioButton)
            {
                this.agentMode = Csta.AgentMode_t.AM_READY;
                this.DialogResult = DialogResult.OK;
            }
            else if (checkedButton == this.AM_WORK_NOT_READYRadioButton)
            {
                this.agentMode = Csta.AgentMode_t.AM_WORK_NOT_READY;
                this.DialogResult = DialogResult.OK;
            }
            else
                this.DialogResult = DialogResult.Cancel;
        }

        private void AgentModeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            var checkedAgentModeButton = this.agentModeGroupBox.Controls.OfType<RadioButton>()
                                      .FirstOrDefault(rb => rb.Checked);
            var checkedWorkModeButton = this.workModeGroupBox.Controls.OfType<RadioButton>()
                                      .FirstOrDefault(rb => rb.Checked);
            if (checkedAgentModeButton == this.AM_LOG_INRadioButton)
            {
                this.WM_AUX_WORKRadioButton.Enabled = true;
                this.WM_AUX_WORKRadioButton.Checked = true;
                this.WM_AFTCAL_WKRadioButton.Enabled = true;
                this.WM_AUTO_INRadioButton.Enabled = true;
                this.WM_MANUAL_INRadioButton.Enabled = true;
                if (checkedWorkModeButton == this.WM_AUX_WORKRadioButton)
                    this.reasonCodeTextBox.Enabled = true;
                else
                    this.reasonCodeTextBox.Enabled = false;
                this.enablePendingCheckBox.Enabled = false;
            }
            else if (checkedAgentModeButton == this.AM_LOG_OUTRadioButton)
            {
                this.WM_AUX_WORKRadioButton.Checked = false;
                this.WM_AUX_WORKRadioButton.Enabled = false;
                this.WM_AFTCAL_WKRadioButton.Checked = false;
                this.WM_AFTCAL_WKRadioButton.Enabled = false;
                this.WM_AUTO_INRadioButton.Checked = false;
                this.WM_AUTO_INRadioButton.Enabled = false;
                this.WM_MANUAL_INRadioButton.Checked = false;
                this.WM_MANUAL_INRadioButton.Enabled = false;
                this.reasonCodeTextBox.Enabled = true;
                this.enablePendingCheckBox.Enabled = false;
            }
            else if (checkedAgentModeButton == this.AM_NOT_READYRadioButton)
            {
                this.WM_AUX_WORKRadioButton.Checked = false;
                this.WM_AUX_WORKRadioButton.Enabled = false;
                this.WM_AFTCAL_WKRadioButton.Checked = false;
                this.WM_AFTCAL_WKRadioButton.Enabled = false;
                this.WM_AUTO_INRadioButton.Checked = false;
                this.WM_AUTO_INRadioButton.Enabled = false;
                this.WM_MANUAL_INRadioButton.Checked = false;
                this.WM_MANUAL_INRadioButton.Enabled = false;
                this.reasonCodeTextBox.Enabled = true;
                this.enablePendingCheckBox.Enabled = true;
            }
            else if (checkedAgentModeButton == this.AM_READYRadioButton)
            {
                this.WM_AUX_WORKRadioButton.Checked = false;
                this.WM_AUX_WORKRadioButton.Enabled = false;
                this.WM_AFTCAL_WKRadioButton.Checked = false;
                this.WM_AFTCAL_WKRadioButton.Enabled = false;
                this.WM_AUTO_INRadioButton.Enabled = true;
                this.WM_AUTO_INRadioButton.Checked = true;
                this.WM_MANUAL_INRadioButton.Enabled = true;
                this.reasonCodeTextBox.Enabled = false;
                this.enablePendingCheckBox.Enabled = true;
            }
            else if (checkedAgentModeButton == this.AM_WORK_NOT_READYRadioButton)
            {
                this.WM_AUX_WORKRadioButton.Checked = false;
                this.WM_AUX_WORKRadioButton.Enabled = false;
                this.WM_AFTCAL_WKRadioButton.Checked = false;
                this.WM_AFTCAL_WKRadioButton.Enabled = false;
                this.WM_AUTO_INRadioButton.Checked = false;
                this.WM_AUTO_INRadioButton.Enabled = false;
                this.WM_MANUAL_INRadioButton.Checked = false;
                this.WM_MANUAL_INRadioButton.Enabled = false;
                this.reasonCodeTextBox.Enabled = false;
                this.enablePendingCheckBox.Enabled = true;
            }
        }

        private void WorkModeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            var checkedAgentModeButton = this.agentModeGroupBox.Controls.OfType<RadioButton>()
                          .FirstOrDefault(rb => rb.Checked);
            var checkedWorkModeButton = this.workModeGroupBox.Controls.OfType<RadioButton>()
                                      .FirstOrDefault(rb => rb.Checked);
            if (checkedWorkModeButton == this.WM_AUX_WORKRadioButton)
                this.reasonCodeTextBox.Enabled = true;
            else
                this.reasonCodeTextBox.Enabled = false;
        }
    }
}
