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
    public partial class SnapShotDeviceForm : Form
    {
        internal mainForm parentForm;
        internal SnapShotDeviceForm()
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
                Csta.EventBuffer_t evtbuf = clearCall(ref selectedConnId);
                snapShotDataTree.Nodes.Remove(tmpNode);
            };

            cstaClearConnectionContextMenuItem.Click += (s, ev) =>
            {
                Csta.EventBuffer_t evtbuf = clearConnection(ref selectedConnId);
                snapShotDataTree.Nodes.Remove(tmpNode);
            };

            snapShotDataTreeContextMenu.Show(Cursor.Position);
        }

        private Csta.EventBuffer_t clearCall(ref Csta.ConnectionID_t cId)
        {
            Csta.EventBuffer_t evtBuf = new Csta.EventBuffer_t();
            Acs.InvokeID_t invokeId = new Acs.InvokeID_t();
            Acs.RetCode_t retCode = Csta.cstaClearCall(parentForm.acsHandle,
                                                 invokeId,
                                                 ref cId,
                                                 parentForm.privData);
            if (retCode._value < 0)
            {
                MessageBox.Show("cstaClearCall error: " + retCode);
                return null;
            }
            parentForm.privData.length = Att.ATT_MAX_PRIVATE_DATA;
            ushort eventBufSize = Csta.CSTA_MAX_HEAP;
            ushort numEvents;
            retCode = Acs.acsGetEventBlock(parentForm.acsHandle,
                                          evtBuf,
                                          ref eventBufSize,
                                          parentForm.privData,
                                          out numEvents);
            if (retCode._value < 0)
            {
                MessageBox.Show("acsGetEventBlock error: " + retCode);
                return null;
            }
            if (evtBuf.evt.eventHeader.eventClass.eventClass != Csta.CSTACONFIRMATION ||
                evtBuf.evt.eventHeader.eventType.eventType != Csta.CSTA_CLEAR_CALL_CONF)
            {
                if (evtBuf.evt.eventHeader.eventClass.eventClass == Csta.CSTACONFIRMATION
                    && evtBuf.evt.eventHeader.eventType.eventType == Csta.CSTA_UNIVERSAL_FAILURE_CONF)
                {
                    MessageBox.Show("Clear call failed. Error: " + evtBuf.evt.cstaConfirmation.universalFailure.error);
                }
            }
            return evtBuf;
        }
        private Csta.EventBuffer_t clearConnection(ref Csta.ConnectionID_t cId)
        {
            Csta.EventBuffer_t evtBuf = new Csta.EventBuffer_t();
            Acs.InvokeID_t invokeId = new Acs.InvokeID_t();
            Acs.RetCode_t retCode = Csta.cstaClearConnection(parentForm.acsHandle,
                                                 invokeId,
                                                 ref cId,
                                                 parentForm.privData);
            if (retCode._value < 0)
            {
                MessageBox.Show("cstaClearCall error: " + retCode);
                return null;
            }
            parentForm.privData.length = Att.ATT_MAX_PRIVATE_DATA;
            ushort eventBufSize = Csta.CSTA_MAX_HEAP;
            ushort numEvents;
            retCode = Acs.acsGetEventBlock(parentForm.acsHandle,
                                          evtBuf,
                                          ref eventBufSize,
                                          parentForm.privData,
                                          out numEvents);
            if (retCode._value < 0)
            {
                MessageBox.Show("acsGetEventBlock error: " + retCode);
                return null;
            }
            if (evtBuf.evt.eventHeader.eventClass.eventClass != Csta.CSTACONFIRMATION ||
                evtBuf.evt.eventHeader.eventType.eventType != Csta.CSTA_CLEAR_CALL_CONF)
            {
                if (evtBuf.evt.eventHeader.eventClass.eventClass == Csta.CSTACONFIRMATION
                    && evtBuf.evt.eventHeader.eventType.eventType == Csta.CSTA_UNIVERSAL_FAILURE_CONF)
                {
                    MessageBox.Show("Clear call failed. Error: " + evtBuf.evt.cstaConfirmation.universalFailure.error);
                }
            }
            return evtBuf;
        }
    }
}
