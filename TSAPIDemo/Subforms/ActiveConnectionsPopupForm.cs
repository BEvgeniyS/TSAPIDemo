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
    public partial class ActiveConnectionsPopupForm : Form
    {
        public ActiveConnectionsPopupForm()
        {
            InitializeComponent();
        }

        public ActiveConnectionsPopupForm(Csta.ConnectionID_t[] conns)
        {
            InitializeComponent();
            this.connections = conns;
            foreach (Csta.ConnectionID_t conn in conns)
            {
                this.connectionListBox.Items.Add(conn);
            }
            
        }

        private void selectHoldButton_Click(object sender, EventArgs e)
        {
            Csta.ConnectionID_t[] selectedConns = this.connectionListBox.CheckedItems.OfType<Csta.ConnectionID_t>().ToArray();
            Att.attSelectiveListeningHold(this._parent.privData, this.connections[0], true, new Csta.ConnectionID_t());
            Csta.cstaEscapeService(this._parent.acsHandle, new Acs.InvokeID_t(), this._parent.privData);

        }
    }
}
