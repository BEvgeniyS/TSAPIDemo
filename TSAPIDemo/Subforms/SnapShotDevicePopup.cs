/*
 Copyright 2015 TSAPI.NET project

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Tsapi;

namespace TSAPIDemo.Subforms
{
    public partial class SnapShotDevicePopup : Form
    {
        internal mainForm parentForm;
        internal SnapShotDevicePopup()
        {
            InitializeComponent();
        }

        private void snapShotDataTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button != MouseButtons.Right) { return; }
            snapShotDataTree.SelectedNode = e.Node;
            if (!(e.Node is CallNode)) return;
            CallNode tmpNode = (CallNode)e.Node;
            Csta.ConnectionID_t selectedConnId = tmpNode.connection;
            ContextMenuStrip snapShotDataTreeContextMenu = new ContextMenuStrip();
            ToolStripItem cstaClearCallContextMenuItem = snapShotDataTreeContextMenu.Items.Add("cstaClearCall");
            ToolStripItem cstaClearConnectionContextMenuItem = snapShotDataTreeContextMenu.Items.Add("cstaClearConnection");
            cstaClearCallContextMenuItem.Click += (s, ev) =>
            {
                Csta.EventBuffer_t evtbuf = Csta.clearCall(this.parentForm.acsHandle, selectedConnId);
                if (evtbuf.evt.eventHeader.eventClass.eventClass == Csta.CSTACONFIRMATION && evtbuf.evt.eventHeader.eventType.eventType == Csta.CSTA_CLEAR_CALL_CONF)
                {
                    snapShotDataTree.Nodes.Remove(tmpNode);
                }
            };

            cstaClearConnectionContextMenuItem.Click += (s, ev) =>
            {
                Csta.EventBuffer_t evtbuf = Csta.clearConnection(parentForm.acsHandle, parentForm.privData, selectedConnId);
                if (evtbuf.evt.eventHeader.eventClass.eventClass == Csta.CSTACONFIRMATION && evtbuf.evt.eventHeader.eventType.eventType == Csta.CSTA_CLEAR_CONNECTION_CONF)
                {
                    snapShotDataTree.Nodes.Remove(tmpNode);
                }
            };

            snapShotDataTreeContextMenu.Show(Cursor.Position);
        }
    }
}
