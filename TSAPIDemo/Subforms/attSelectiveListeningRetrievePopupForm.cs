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
    public partial class attSelectiveListeningRetrievePopupForm : Form
    {
        internal Csta.ConnectionID_t[] _conns;
        internal mainForm _parent;

        public attSelectiveListeningRetrievePopupForm(Csta.ConnectionID_t[] conns)
        {
            this._conns = conns;
            InitializeComponent();
            for (int i = 0;(i < conns.Length) && (i < 10) ; i++)
            {
                var rb = new RadioButtonConn();
                rb.Location = new System.Drawing.Point(7, 20 * (i + 1));
                rb.TabIndex = i + 1;
                rb.Text = conns[i].deviceID.ToString();
                rb.Connection = conns[i];
                rb.CheckedChanged += new System.EventHandler(this.rb1_CheckedChanged);

                var rb2 = new RadioButtonConn();
                rb2.Location = new System.Drawing.Point(7, 20 * (i + 1));
                rb2.TabIndex = i + 1;
                rb2.Text = conns[i].deviceID.ToString();
                rb2.Connection = conns[i];
                rb2.CheckedChanged += new System.EventHandler(this.rb2_CheckedChanged);

                this.connGroupBox1.Controls.Add(rb);
                this.connGroupBox2.Controls.Add(rb2);
            }
            var selected1 = (RadioButtonConn)this.connGroupBox1.Controls[0];
            selected1.Checked = true;
            var selected2 = (RadioButtonConn)this.connGroupBox2.Controls[1];
            selected2.Checked = true;
        }

        private void blockAllCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (this.blockAllCheckBox.Checked)
            {
                this.connGroupBox2.Enabled = false;
                foreach (RadioButtonConn rb in this.connGroupBox2.Controls.OfType<RadioButtonConn>())
                    rb.Checked = false;
            }
            else
                this.connGroupBox2.Enabled = true;
        }

        private void goButton_Click(object sender, EventArgs e)
        {
            var checkedButton1 = this.connGroupBox1.Controls.OfType<RadioButtonConn>()
                                      .FirstOrDefault(rb => rb.Checked);
            var checkedButton2 = this.connGroupBox2.Controls.OfType<RadioButtonConn>()
                                      .FirstOrDefault(rb2 => rb2.Checked);
            Acs.RetCode_t rc;
            if (this.blockAllCheckBox.Checked)
                rc =  Att.attSelectiveListeningRetrieve(this._parent.privData, checkedButton1.Connection, true, checkedButton1.Connection);
            else
                rc = Att.attSelectiveListeningRetrieve(this._parent.privData, checkedButton1.Connection, false, checkedButton2.Connection);
            this._parent.Log("attSelectiveListeningRetrieve result = " + rc._value);
            if (rc._value < 0) return;
            var invokeId = new Acs.InvokeID_t();
            rc = Csta.cstaEscapeService(this._parent.acsHandle, invokeId, this._parent.privData);
            this._parent.Log("cstaEscapeService result = " + rc._value);
            if (rc._value < 0) return;

            ushort eventBufferSize = Csta.CSTA_MAX_HEAP;
            var eventBuf = new Csta.EventBuffer_t();
            ushort numEvents;
            rc = Acs.acsGetEventBlock(this._parent.acsHandle, eventBuf, ref eventBufferSize, this._parent.privData, out numEvents);
            this._parent.Log("acsGetEventBlock result = " + rc._value);
            if (rc._value < 0) return;

            if (eventBuf.evt.eventHeader.eventClass.eventClass == Csta.CSTACONFIRMATION && eventBuf.evt.eventHeader.eventType.eventType == Csta.CSTA_ESCAPE_SVC_CONF)
            {
                MessageBox.Show("attSelectiveListeningRetrieve Succeded");
            }
            else
            {
                MessageBox.Show("attSelectiveListeningRetrieve Failed. Error was: " + eventBuf.evt.cstaConfirmation.universalFailure.error);
            }
        }

        private void rb1_CheckedChanged(object sender, EventArgs e)
        {
            var checkedButton1 = this.connGroupBox1.Controls.OfType<RadioButtonConn>()
                                      .FirstOrDefault(rb => rb.Checked);
            var checkedButton2 = this.connGroupBox2.Controls.OfType<RadioButtonConn>()
                                      .FirstOrDefault(rb2 => rb2.Checked);
            if (checkedButton1 == null || checkedButton2 == null ||
                checkedButton1.Connection != checkedButton2.Connection) return;
            foreach (RadioButtonConn curRb in this.connGroupBox2.Controls.OfType<RadioButtonConn>())
            {
                if (checkedButton1 != null && curRb.Connection != checkedButton1.Connection)
                {
                    curRb.Checked = true;
                    return;
                }
                else
                    continue;
            }
        }

        private void rb2_CheckedChanged(object sender, EventArgs e)
        {
            var checkedButton1 = this.connGroupBox1.Controls.OfType<RadioButtonConn>()
                                      .FirstOrDefault(rb => rb.Checked);
            var checkedButton2 = this.connGroupBox2.Controls.OfType<RadioButtonConn>()
                                      .FirstOrDefault(rb2 => rb2.Checked);
            if (checkedButton1 == null || checkedButton2 == null ||
                checkedButton2.Connection != checkedButton1.Connection) return;
            foreach (RadioButtonConn curRb in this.connGroupBox1.Controls.OfType<RadioButtonConn>())
            {
                if (checkedButton2 != null && curRb.Connection != checkedButton2.Connection)
                {
                    curRb.Checked = true;
                    return;
                }
                else
                    continue;
            }
        }
    }

   
}
