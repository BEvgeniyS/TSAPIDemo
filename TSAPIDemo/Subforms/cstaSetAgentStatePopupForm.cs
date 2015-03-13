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
        public Csta.AgentID_t agentId;
        public cstaSetAgentStatePopupForm()
        {
            InitializeComponent();
        }

        private void AM_LOG_IN_Button_Click(object sender, EventArgs e)
        {
            this.agentId = this.agentIdTextBox.Text;
            var checkedButton = this.agentModeGroupBox.Controls.OfType<RadioButton>()
                                      .FirstOrDefault(rb => rb.Checked);
            if (checkedButton == this.AM_LOG_INRadioButton)
            {
                this.agentMode = Csta.AgentMode_t.AM_LOG_IN;
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
                this.WM_AUX_WORKRadioButton.Checked = true;
                this.WM_AUX_WORKRadioButton.Enabled = true;
                this.WM_AFTCAL_WKRadioButton.Checked = true;
                this.WM_AFTCAL_WKRadioButton.Enabled = true;
                this.WM_AUTO_INRadioButton.Checked = true;
                this.WM_AUTO_INRadioButton.Enabled = true;
                this.WM_MANUAL_INRadioButton.Checked = true;
                this.WM_MANUAL_INRadioButton.Enabled = true;
                if (checkedWorkModeButton != this.WM_AUX_WORKRadioButton)
                    this.reasonCodeTextBox.Enabled = false;
                else
                    this.reasonCodeTextBox.Enabled = true;
                this.enablePendingCheckBox.Enabled = false;
            }
            else if (checkedAgentModeButton == this.AM_LOG_INRadioButton)
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
                this.WM_AUTO_INRadioButton.Checked = true;
                this.WM_AUTO_INRadioButton.Enabled = true;
                this.WM_MANUAL_INRadioButton.Checked = true;
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

    }
}
