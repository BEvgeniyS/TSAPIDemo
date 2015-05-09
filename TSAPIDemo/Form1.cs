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
using System.Configuration;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using Tsapi;

namespace TSAPIDemo
{
    public partial class mainForm : Form
    {
        private const int WM_USER = 0x0400;
        private const int WM_TSAPI_EVENT = WM_USER + 99;
        private Acs.EsrDelegate eventReaction;
        private Queue<string> logQueue = new Queue<string>();
        private const int logMax = 2000;

        public mainForm()
        {
            InitializeComponent();
            try
            {
                if (config.AppSettings.Settings["ServerID"].Value != "" ||
                    config.AppSettings.Settings["ServerID"].Value != "AVAYA#Switch_Connection#Service_Type#AE_Service")
                {
                    config.AppSettings.Settings["ServerID"].Value = getServerId();
                }
                this.configured = true;
                try { this.serverId_textBox.Text = config.AppSettings.Settings["ServerID"].Value; }
                catch { this.configured = false; }
                try { this.login_textBox.Text = config.AppSettings.Settings["TSAPI login"].Value; }
                catch { this.configured = false; }
                try { this.password_textBox.Text = config.AppSettings.Settings["Password"].Value; }
                catch { this.configured = false; }
                try { this.appName_textBox.Text = config.AppSettings.Settings["ApplicationName"].Value; }
                catch { this.configured = false; }
                try { this.apiVer_textBox.Text = config.AppSettings.Settings["ApiVersion"].Value; }
                catch { this.configured = false; }
            }
            catch
            {
                this.configured = false;
            }
            if (!this.configured) { this.mainTabs.SelectTab(configTab); }
        }

        private void snapShotDeviceButton_Click(object sender, EventArgs e)
        {
            if (!this.configured)
            {
                MessageBox.Show("Application is not configured");
                this.mainTabs.SelectTab(configTab);
                return;
            }
            if (!streamCheckbox.Checked || deviceTextBox.Text.Length == 0 || deviceTextBox.Text.Length > 5 || !streamCheckbox.Checked) { return; }
            Csta.DeviceID_t currentDevice = deviceTextBox.Text;
            Acs.InvokeID_t invokeId = new Acs.InvokeID_t();
            Acs.RetCode_t retCode = Csta.cstaSnapshotDeviceReq(this.acsHandle,
                                                 invokeId,
                                                 ref currentDevice,
                                                 privData);
            if (retCode._value < 0)
            {
                MessageBox.Show("cstaSnapshotDeviceReq error: " + retCode);
                return;
            }
            Csta.EventBuffer_t evtBuf = new Csta.EventBuffer_t();
            this.privData.length = Att.ATT_MAX_PRIVATE_DATA;
            ushort eventBufSize = Csta.CSTA_MAX_HEAP;
            ushort numEvents;
            retCode = Acs.acsGetEventBlock(this.acsHandle,
                                          evtBuf,
                                          ref eventBufSize,
                                          privData,
                                          out numEvents);
            if (retCode._value < 0)
            {
                MessageBox.Show("acsGetEventBlock error: " + retCode);
                return;
            }
            if (evtBuf.evt.eventHeader.eventClass.eventClass != Csta.CSTACONFIRMATION || evtBuf.evt.eventHeader.eventType.eventType != Csta.CSTA_SNAPSHOT_DEVICE_CONF)
            {
                if (evtBuf.evt.eventHeader.eventClass.eventClass == Csta.CSTACONFIRMATION && evtBuf.evt.eventHeader.eventType.eventType == Csta.CSTA_UNIVERSAL_FAILURE_CONF)
                {
                    MessageBox.Show("Snapshot device failed. Error: " + evtBuf.evt.cstaConfirmation.universalFailure.error);
                }
                return;
            }
            int callCountForSnapshotDevice = evtBuf.evt.cstaConfirmation.snapshotDevice.snapshotData.count;
            if (callCountForSnapshotDevice < 1)
            {
                MessageBox.Show("No active calls");
                return;
            }

            Csta.ConnectionID_t tmpConn;

            TSAPIDemo.Subforms.SnapShotDevicePopup snapShotDevicePop = new Subforms.SnapShotDevicePopup();
            snapShotDevicePop.parentForm = this;

            snapShotDevicePop.snapShotDataTree.Nodes.Clear();
            for (int i = 0; i < callCountForSnapshotDevice; i++)
            {
                var snapDeviceInfoArray = (Csta.CSTASnapshotDeviceResponseInfo_t[])evtBuf.auxData["snapDeviceInfo"];
                tmpConn = snapDeviceInfoArray[i].callIdentifier;
                CallNode callNode = new CallNode();
                callNode.Text = GetUcid(tmpConn).ToString();
                snapShotDevicePop.snapShotDataTree.Nodes.Add(callNode);

                callNode.connection = tmpConn;
                snapShotDevicePop.snapShotDataTree.Nodes[i].Text += ". States: ";
                for (int j = 0; j < snapDeviceInfoArray[i].localCallState.count; j++)
                {
                    var snapDeviceStateArray = (Csta.LocalConnectionState_t[])evtBuf.auxData["snapDeviceState" + i];
                    snapShotDevicePop.snapShotDataTree.Nodes[i].Text += "#" + (j + 1) + ": " + snapDeviceStateArray[j] + " ";
                }
                Csta.EventBuffer_t snapCallEvt = snapshotCall(tmpConn);
                snapShotDevicePop.snapShotDataTree.Nodes[i].Nodes.Clear();
                int callCountForSnapshotCall = snapCallEvt.evt.cstaConfirmation.snapshotCall.snapshotData.count;
                var snapCallInfoArray = (Csta.CSTASnapshotCallResponseInfo_t[])snapCallEvt.auxData["snapCallInfo"];
                for (int j = 0; j < callCountForSnapshotCall; j++)
                {
                    TreeNode t = new TreeNode(snapCallInfoArray[j].deviceOnCall.deviceID.ToString() + "; " + snapCallInfoArray[j].deviceOnCall.deviceIDType + "; " + snapCallInfoArray[j].deviceOnCall.deviceIDStatus);
                    snapShotDevicePop.snapShotDataTree.Nodes[i].Nodes.Add(t);
                }
                snapShotDevicePop.snapShotDataTree.Nodes[i].Expand();
            }
            snapShotDevicePop.ShowDialog();
        }

        private void deviceTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                snapShotDeviceButton_Click(sender, e);
            }
        }

        public void Log(string logText)
        {
            while (logQueue.Count > logMax - 1)
                logQueue.Dequeue();

            logQueue.Enqueue(DateTime.Now.ToString() + ": " + logText);
            this.logTextBox.Text = string.Join(Environment.NewLine, logQueue.ToArray());
            this.logTextBox.SelectionStart = this.logTextBox.Text.Length - logText.Length;
            this.logTextBox.ScrollToCaret();
        }

        private void EventReactionHandler(uint esrparam)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(delegate
                {
                    string logMsg = "[acsSetESR Test] Event detected. acsHandle = " + esrparam;
                    //this.logTextBox.AppendText(logMsg); 
                    Log(logMsg);
                }));
            }
            Debug.WriteLine("[acsSetESR Test] Event detected. acsHandle = " + esrparam);
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            if (this.configured)
            {
                openStream();
            }
            else
            {
                this.configTab.Select();
            }
        }

        private void ESRRegister()
        {
            this.eventReaction = new Acs.EsrDelegate(EventReactionHandler);
            Acs.RetCode_t returnCode = Acs.acsSetESR(this.acsHandle, eventReaction, this.acsHandle._value, false);
            if (returnCode._value == Acs.ACSPOSITIVE_ACK)
            {
                this.esrCheckBox.Checked = true;
                this.esrCheckBox.Text = "Enabled";
            }
        }

        private void ESRDeRegister()
        {
            Acs.EsrDelegate eventReaction = null;
            Acs.RetCode_t returnCode = Acs.acsSetESR(this.acsHandle, eventReaction, this.acsHandle._value, false);
            if (returnCode._value == Acs.ACSPOSITIVE_ACK)
            {
                this.esrCheckBox.Checked = false;
                this.esrCheckBox.Text = "Disabled";
            }
        }

        private void EventNotifyRegister()
        {
            Acs.RetCode_t returnCode = Acs.acsEventNotify(this.acsHandle, this.Handle, WM_TSAPI_EVENT, false);
            if (returnCode._value == Acs.ACSPOSITIVE_ACK)
            {
                this.wmEventNotifyCheckBox.Checked = true;
                this.wmEventNotifyCheckBox.Text = "Enabled";
            }
        }

        private void EventNotifyDeRegister()
        {
            IntPtr nullPtr = IntPtr.Zero;
            Acs.RetCode_t returnCode = Acs.acsEventNotify(this.acsHandle, nullPtr, WM_TSAPI_EVENT, false);
            if (returnCode._value == Acs.ACSPOSITIVE_ACK)
            {
                this.wmEventNotifyCheckBox.Checked = false;
                this.wmEventNotifyCheckBox.Text = "Disabled";
            }
        }


        private void openStream()
        {
            this.acsHandle = new Acs.ACSHandle_t();
            var invokeIdType = Acs.InvokeIDType_t.LIB_GEN_ID;
            var invokeId = new Acs.InvokeID_t();
            var streamType = Acs.StreamType_t.ST_CSTA;
            Acs.ServerID_t serverId = config.AppSettings.Settings["ServerID"].Value;
            Acs.LoginID_t loginId = config.AppSettings.Settings["TSAPI login"].Value;
            Acs.Passwd_t passwd = config.AppSettings.Settings["Password"].Value;
            Acs.AppName_t appName = config.AppSettings.Settings["ApplicationName"].Value;
            Acs.Level_t acsLevelReq = Acs.Level_t.ACS_LEVEL1;
            Acs.Version_t apiVer = config.AppSettings.Settings["ApiVersion"].Value;
            ushort sendQSize = 0;
            ushort sendExtraBufs = 0;
            ushort recvQSize = 0;
            ushort recvExtraBufs = 0;
            var currentDevice = deviceTextBox.Text;
            // Get supportedVersion string
            string requestedVersion = "3-10";
            System.Text.StringBuilder supportedVersion = new System.Text.StringBuilder();
            Acs.RetCode_t attrc = Att.attMakeVersionString(requestedVersion, supportedVersion);
            // Set PrivateData request
            this.privData = new Acs.PrivateData_t();
            this.privData.vendor = "VERSION";
            this.privData.data = new byte[Att.ATT_MAX_PRIVATE_DATA];
            this.privData.data[0] = Acs.PRIVATE_DATA_ENCODING;
            for (int i = 0; i < supportedVersion.Length; i++)
            {
                privData.data[i + 1] = (byte)supportedVersion[i];
            }
            privData.length = Att.ATT_MAX_PRIVATE_DATA;
            Acs.RetCode_t retCode = Acs.acsOpenStream(out this.acsHandle,
                                                          invokeIdType,
                                                          invokeId,
                                                          streamType,
                                                          ref serverId,
                                                          ref loginId,
                                                          ref passwd,
                                                          ref appName,
                                                          acsLevelReq,
                                                          ref apiVer,
                                                          sendQSize,
                                                          sendExtraBufs,
                                                          recvQSize,
                                                          recvExtraBufs,
                                                          this.privData);
            Csta.EventBuffer_t evtBuf = new Csta.EventBuffer_t();
            ushort eventBufSize = Csta.CSTA_MAX_HEAP;
            ushort numEvents = 0;

            retCode = Acs.acsGetEventBlock(this.acsHandle,
                                     evtBuf,
                                     ref eventBufSize,
                                     this.privData,
                                     out numEvents);
            if (evtBuf.evt.eventHeader.eventClass.eventClass != 2 || evtBuf.evt.eventHeader.eventType.eventType != 2)
            {
                MessageBox.Show("Could not open stream. ErrorCode = " + evtBuf.evt.acsConfirmation.failureEvent.error);
                streamCheckbox.Checked = false;
                this.snapShotDeviceButton.Enabled = false;
                return;
            }
            else
            {
                streamCheckbox.Text = "Connected to AES server. Handle = " + this.acsHandle;
                streamCheckbox.Checked = true;
                this.snapShotDeviceButton.Enabled = true;
            }
        }


        public Att.ATTUCID_t GetUcid(Csta.ConnectionID_t conn)
        {
            Acs.InvokeID_t invokeId = new Acs.InvokeID_t();
            Csta.EventBuffer_t evtBuf = new Csta.EventBuffer_t();
            ushort eventBufSize = Csta.CSTA_MAX_HEAP;
            ushort numEvents = 0;
            Acs.RetCode_t retCode = Att.attQueryUCID(this.privData, conn);
            retCode = Csta.cstaEscapeService(acsHandle, invokeId, this.privData);
            this.privData.length = Att.ATT_MAX_PRIVATE_DATA;
            retCode = Acs.acsGetEventBlock(acsHandle,
                                         evtBuf,
                                         ref eventBufSize,
                                         this.privData,
                                         out numEvents);

            Att.ATTEvent_t attEvt = new Att.ATTEvent_t();
            retCode = Att.attPrivateData(this.privData, attEvt);
            Debug.WriteLine("attPrivateData retCode = " + retCode._value);
            return attEvt.queryUCID.ucid;
        }



        private void mainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Acs.acsAbortStream(this.acsHandle, null);
            WriteConfig();
        }

        private void WriteConfig()
        {
            try
            {
                config.Save(ConfigurationSaveMode.Modified);
            }
            catch { }
        }


        private void serverID_textBox_Leave(object sender, EventArgs e)
        {
            if (serverId_textBox.Text == string.Empty) this.configured = false;
            if (config.AppSettings.Settings["ServerID"] == null)
            {
                config.AppSettings.Settings.Add("ServerID", serverId_textBox.Text);
            }
            else
            {
                config.AppSettings.Settings["ServerID"].Value = serverId_textBox.Text;
            }
        }

        private void login_textBox_Leave(object sender, EventArgs e)
        {
            if (login_textBox.Text == string.Empty) this.configured = false;
            if (config.AppSettings.Settings["TSAPI login"] == null)
            {
                config.AppSettings.Settings.Add("TSAPI login", login_textBox.Text);
            }
            else
            {
                config.AppSettings.Settings["TSAPI login"].Value = login_textBox.Text;
            }
        }

        private void password_textBox_Leave(object sender, EventArgs e)
        {
            if (config.AppSettings.Settings["Password"] == null)
            {
                config.AppSettings.Settings.Add("Password", password_textBox.Text);
            }
            else
            {
                config.AppSettings.Settings["Password"].Value = password_textBox.Text;
            }
        }

        private void appName_textBox_Leave(object sender, EventArgs e)
        {
            if (appName_textBox.Text == string.Empty) this.configured = false;
            if (config.AppSettings.Settings["ApplicationName"] == null)
            {
                config.AppSettings.Settings.Add("ApplicationName", appName_textBox.Text);
            }
            else
            {
                config.AppSettings.Settings["ApplicationName"].Value = appName_textBox.Text;
            }
        }

        private void apiVer_textBox_Leave(object sender, EventArgs e)
        {
            if (apiVer_textBox.Text == string.Empty) this.configured = false;
            if (config.AppSettings.Settings["ApiVersion"] == null)
            {
                config.AppSettings.Settings.Add("ApiVersion", apiVer_textBox.Text);
            }
            else
            {
                config.AppSettings.Settings["ApiVersion"].Value = apiVer_textBox.Text;
            }
        }

        private void connectionCheckbox_MouseClick(object sender, MouseEventArgs e)
        {
            if (!this.configured)
            {
                this.streamCheckbox.Checked = false;
                MessageBox.Show("Application is not configured");
                this.mainTabs.SelectTab(configTab);
                return;
            }
            if (!this.streamCheckbox.Checked)
            {
                closeStream(this.acsHandle);
                streamCheckbox.Text = "Disconnected from AES server";
                this.snapShotDeviceButton.Enabled = false;
                this.esrCheckBox.Enabled = false;
                this.esrCheckBox.Checked = false;
                this.wmEventNotifyCheckBox.Enabled = false;
                this.wmEventNotifyCheckBox.Checked = false;
            }
            else
            {
                openStream();
                this.esrCheckBox.Enabled = true;
                this.wmEventNotifyCheckBox.Enabled = true;
            }
        }


        private Csta.EventBuffer_t snapshotCall(Csta.ConnectionID_t cId)
        {
            Csta.EventBuffer_t evtBuf = new Csta.EventBuffer_t();
            Acs.InvokeID_t invokeId = new Acs.InvokeID_t();
            Acs.RetCode_t retCode = Csta.cstaSnapshotCallReq(this.acsHandle,
                                                 invokeId,
                                                 cId,
                                                 this.privData);
            if (retCode._value < 0)
            {
                MessageBox.Show("cstaSnapshotCallReq error: " + retCode);
                return null;
            }
            this.privData.length = Att.ATT_MAX_PRIVATE_DATA;
            ushort eventBufSize = Csta.CSTA_MAX_HEAP;
            ushort numEvents;
            retCode = Acs.acsGetEventBlock(this.acsHandle,
                                          evtBuf,
                                          ref eventBufSize,
                                          privData,
                                          out numEvents);
            if (retCode._value < 0)
            {
                MessageBox.Show("acsGetEventBlock error: " + retCode);
                return null;
            }
            if (evtBuf.evt.eventHeader.eventClass.eventClass != Csta.CSTACONFIRMATION ||
                evtBuf.evt.eventHeader.eventType.eventType != Csta.CSTA_SNAPSHOT_CALL_CONF)
            {
                if (evtBuf.evt.eventHeader.eventClass.eventClass == Csta.CSTACONFIRMATION
                    && evtBuf.evt.eventHeader.eventType.eventType == Csta.CSTA_UNIVERSAL_FAILURE_CONF)
                {
                    MessageBox.Show("Snapshot call failed. Error: " + evtBuf.evt.cstaConfirmation.universalFailure.error);
                }
            }
            return evtBuf;
        }



        private Csta.EventBuffer_t closeStream(Acs.ACSHandle_t acsHandle)
        {
            Csta.EventBuffer_t evtBuf = new Csta.EventBuffer_t();
            Acs.RetCode_t retCode = Acs.acsCloseStream(acsHandle, new Acs.InvokeID_t(), null);
            ushort eventBufSize = Csta.CSTA_MAX_HEAP;
            ushort numEvents;
            retCode = Acs.acsGetEventBlock(this.acsHandle,
                                          evtBuf,
                                          ref eventBufSize,
                                          null,
                                          out numEvents);
            if (retCode._value < 0)
            {
                MessageBox.Show("acsGetEventBlock error: " + retCode);
                return null;
            }
            if (evtBuf.evt.eventHeader.eventClass.eventClass != Acs.ACSCONFIRMATION ||
                evtBuf.evt.eventHeader.eventType.eventType != Acs.ACS_CLOSE_STREAM_CONF)
            {
                if (evtBuf.evt.eventHeader.eventClass.eventClass == Acs.ACSCONFIRMATION
                    && evtBuf.evt.eventHeader.eventType.eventType == Acs.ACS_UNIVERSAL_FAILURE_CONF)
                {
                    MessageBox.Show("Clear call failed. Error: " + evtBuf.evt.cstaConfirmation.universalFailure.error);
                }
            }
            return evtBuf;
        }

        private Csta.EventBuffer_t getDeviceList(Acs.ACSHandle_t acsHandle)
        {
            Csta.EventBuffer_t evtBuf = new Csta.EventBuffer_t();
            Acs.PrivateData_t privData = new Acs.PrivateData_t();
            int idx = -1;
            Acs.RetCode_t retCode = Csta.cstaGetDeviceList(acsHandle, new Acs.InvokeID_t(), idx, Csta.CSTALevel_t.CSTA_HOME_WORK_TOP);
            this.privData.length = Att.ATT_MAX_PRIVATE_DATA;
            ushort eventBufSize = Csta.CSTA_MAX_HEAP * 2;
            ushort numEvents;
            Acs.acsGetEventBlock(this.acsHandle,
                                          evtBuf,
                                          ref eventBufSize,
                                          privData,
                                          out numEvents);

            idx = evtBuf.evt.cstaConfirmation.getDeviceList.index;
            retCode = Csta.cstaGetDeviceList(acsHandle, new Acs.InvokeID_t(), idx, Csta.CSTALevel_t.CSTA_HOME_WORK_TOP);

            this.privData.length = Att.ATT_MAX_PRIVATE_DATA;
            eventBufSize = Csta.CSTA_MAX_HEAP;
            Acs.acsGetEventBlock(this.acsHandle,
                                          evtBuf,
                                          ref eventBufSize,
                                          privData,
                                          out numEvents);
            return evtBuf;
        }

        private void mainTabs_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage != this.configTab)
            {
                this.configured = false;
                if (serverId_textBox.Text != string.Empty &&
                    login_textBox.Text != string.Empty &&
                    password_textBox.Text != string.Empty &&
                    appName_textBox.Text != string.Empty &&
                    apiVer_textBox.Text != string.Empty)
                {
                    this.configured = true;
                }
                WriteConfig();
            }
        }



        private void cstaGetDeviceListButton_Click(object sender, EventArgs e)
        {
            Csta.EventBuffer_t evtbuf = getDeviceList(this.acsHandle);
            MessageBox.Show("Number of devices = " + evtbuf.evt.cstaConfirmation.getDeviceList.devList.count);
        }

        //[System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_TSAPI_EVENT:
                    {
                        short[] wmEventData = Aux.SplitPtr(m.LParam);
                        string logMsg = string.Format("[acsEventNotify Test] Got event: AcsHandle = {0}, EventClass = {1}, EventType = {2}", m.WParam, wmEventData[0], wmEventData[1]);
                        Log(logMsg);
                        break;
                    }
            }
            base.WndProc(ref m);
        }

        private void flushEventQueueButton_Click(object sender, EventArgs e)
        {
            Acs.RetCode_t retCode = Acs.acsFlushEventQueue(this.acsHandle);
            if (retCode._value == 0)
            {
                MessageBox.Show("Events flushed successfully!");
            }
            else if (retCode._value > 0)
            {
                MessageBox.Show("acsFlushEventQueue result: " + retCode._value);
            }
            else
            {
                MessageBox.Show("acsFlushEventQueue failed. Error: " + retCode._value);
            }
        }

        private void enumServerNamesButton_Click(object sender, EventArgs e)
        {
            var enumServerHandler = new EnumServerHandler();
            Acs.EnumServerNamesCB callback = new Acs.EnumServerNamesCB(enumServerHandler.acsEnumServerNamesCallbackHandler);
            Acs.acsEnumServerNames(Acs.StreamType_t.ST_CSTA, callback, 0);
            this.serverId_textBox.Text = enumServerHandler.serverName;
            if (config.AppSettings.Settings["ServerID"] == null)
            {
                config.AppSettings.Settings.Add("ServerID", enumServerHandler.serverName);
            }
            else
            {
                config.AppSettings.Settings["ServerID"].Value = enumServerHandler.serverName;
            }
            //MessageBox.Show("Found server:\n" + enumServerHandler.serverName);
        }

        private string getServerId()
        {
            var enumServerHandler = new EnumServerHandler();
            Acs.EnumServerNamesCB callback = new Acs.EnumServerNamesCB(enumServerHandler.acsEnumServerNamesCallbackHandler);
            Acs.acsEnumServerNames(Acs.StreamType_t.ST_CSTA, callback, 0);
            Log("[acsEnumServerNames Test] server = " + enumServerHandler.serverName);
            if (enumServerHandler.serverName != string.Empty)
            {
                return enumServerHandler.serverName;
            }
            else
            {
                return config.AppSettings.Settings["ServerID"].Value;
            }
        }

        private void acsQueryAuthInfoButton_Click(object sender, EventArgs e)
        {
            Acs.ServerID_t serverID = config.AppSettings.Settings["ServerID"].Value;
            Acs.ACSAuthInfo_t authInfo = new Acs.ACSAuthInfo_t();
            Acs.RetCode_t retCode = Acs.acsQueryAuthInfo(ref serverID, ref authInfo);
            if (retCode._value >= 0)
            {
                MessageBox.Show("Authentication type: " + authInfo.authType + "\n LoginId = " + authInfo.authLoginID);
            }
            else
            {
                MessageBox.Show("There was an error during acsQueryAuthInfo. Code = " + retCode._value);
            }
        }

        private void acsSetHeartbeatIntervalButton_Click(object sender, EventArgs e)
        {
            acsSetHeartbeatIntervalPopupForm subform = new acsSetHeartbeatIntervalPopupForm();
            subform.ShowDialog();
            if (subform.DialogResult == DialogResult.OK)
            {
                ushort hbInterval = subform.ReturnValue;
                var invoikeId = new Acs.InvokeID_t();
                Acs.RetCode_t retCode = Acs.acsSetHeartbeatInterval(this.acsHandle, invoikeId, hbInterval, null);
                if (retCode._value > 0)
                {
                    Csta.EventBuffer_t evtBuf = new Csta.EventBuffer_t();
                    ushort numEvents;
                    ushort eventBufSize = Csta.CSTA_MAX_HEAP;
                    Acs.acsGetEventBlock(this.acsHandle, evtBuf, ref eventBufSize, null, out numEvents);
                    if (evtBuf.evt.eventHeader.eventClass.eventClass == Acs.ACSCONFIRMATION && evtBuf.evt.eventHeader.eventType.eventType == Acs.ACS_UNIVERSAL_FAILURE_CONF)
                    {
                        MessageBox.Show("Could not change HeartbeatInterval. Error: " + evtBuf.evt.acsConfirmation.failureEvent.error);
                    }
                }
                else
                {
                    MessageBox.Show("There was an error during acsSetHeartbeatInterval. Code = " + retCode._value);
                }
            }
        }

        private void cstaGetAPICapsButton_Click(object sender, EventArgs e)
        {
            var invoikeId = new Acs.InvokeID_t();
            Acs.RetCode_t retCode = Csta.cstaGetAPICaps(this.acsHandle, invoikeId);
            if (retCode._value >= 0)
            {
                Csta.EventBuffer_t evtBuf = new Csta.EventBuffer_t();
                ushort numEvents;
                ushort eventBufSize = Csta.CSTA_MAX_HEAP;
                this.privData.length = Att.ATT_MAX_PRIVATE_DATA;
                Acs.acsGetEventBlock(this.acsHandle, evtBuf, ref eventBufSize, this.privData, out numEvents);
                if (evtBuf.evt.eventHeader.eventClass.eventClass == Csta.CSTACONFIRMATION && evtBuf.evt.eventHeader.eventType.eventType == Csta.CSTA_GETAPI_CAPS_CONF)
                {
                    System.Reflection.FieldInfo[] _PropertyInfos = evtBuf.evt.cstaConfirmation.getAPICaps.GetType().GetFields();
                    var sb = new StringBuilder();
                    sb.Append(Environment.NewLine);
                    sb.Append("Received API caps:" + Environment.NewLine);
                    foreach (var info in _PropertyInfos)
                    {
                        var value = info.GetValue(evtBuf.evt.cstaConfirmation.getAPICaps);
                        sb.Append(info.Name + "=" + value.ToString() + Environment.NewLine);
                    }
                    sb.Append(Environment.NewLine);
                    sb.Append("ATT Private API caps:" + Environment.NewLine);
                    var attEvt = new Att.ATTEvent_t();
                    retCode = Att.attPrivateData(this.privData, attEvt);
                    _PropertyInfos = attEvt.attV10GetApiCaps.GetType().GetFields();
                    foreach (var info in _PropertyInfos)
                    {
                        var value = info.GetValue(attEvt.attV10GetApiCaps);
                        sb.Append(info.Name + "=" + value.ToString() + Environment.NewLine);
                    }

                    Log(sb.ToString());
                    MessageBox.Show("Got API caps. Please refer to the log.");

                }
                else if (evtBuf.evt.eventHeader.eventClass.eventClass == Csta.CSTACONFIRMATION && evtBuf.evt.eventHeader.eventType.eventType == Csta.CSTA_UNIVERSAL_FAILURE_CONF)
                {
                    MessageBox.Show("Could not get API caps. Error: " + evtBuf.evt.cstaConfirmation.universalFailure.error);
                }
            }
        }

        private void cstaQueryCallMonitorButton_Click(object sender, EventArgs e)
        {
            Acs.RetCode_t retCode = Csta.cstaQueryCallMonitor(this.acsHandle, new Acs.InvokeID_t());
            if (retCode._value >= 0)
            {
                Csta.EventBuffer_t evtBuf = new Csta.EventBuffer_t();
                ushort numEvents;
                ushort eventBufSize = Csta.CSTA_MAX_HEAP;
                Acs.acsGetEventBlock(this.acsHandle, evtBuf, ref eventBufSize, null, out numEvents);
                if (evtBuf.evt.eventHeader.eventClass.eventClass == Csta.CSTACONFIRMATION && evtBuf.evt.eventHeader.eventType.eventType == Csta.CSTA_QUERY_CALL_MONITOR_CONF)
                {
                    if (evtBuf.evt.cstaConfirmation.queryCallMonitor.callMonitor)
                    {
                        MessageBox.Show("ACS stream has permission in the security database to do call/call monitoring.");
                    }
                    else
                    {
                        MessageBox.Show("ACS stream has NO permission in the security database to do call/call monitoring.");
                    }
                }
                else if (evtBuf.evt.eventHeader.eventClass.eventClass == Csta.CSTACONFIRMATION && evtBuf.evt.eventHeader.eventType.eventType == Csta.CSTA_UNIVERSAL_FAILURE_CONF)
                {
                    MessageBox.Show("Could not determine queryCallMonitor permissions. Error: " + evtBuf.evt.cstaConfirmation.universalFailure.error);
                }
            }
        }

        private void cstaAlternateCallButton_Click(object sender, EventArgs e)
        {

            if (!streamCheckbox.Checked || deviceTextBox.Text.Length == 0 || deviceTextBox.Text.Length > 5 || !streamCheckbox.Checked) { return; }

            Csta.ConnectionID_t[] conns = GetCurrentConnections(this.deviceTextBox.Text);
            if (conns == null || conns.Length == 0)
            {
                MessageBox.Show("No active calls");
                return;
            }
            if (conns == null || conns.Length < 2)
            {
                MessageBox.Show("We need more than 2 calls on device");
                return;
            }

            var invokeId = new Acs.InvokeID_t();
            Acs.RetCode_t retCode = Csta.cstaAlternateCall(this.acsHandle, invokeId, conns[0], conns[1], null);
            Debug.WriteLine("cstaAlternateCall result = " + retCode._value);

            var evtBuf = new Csta.EventBuffer_t();
            this.privData.length = Att.ATT_MAX_PRIVATE_DATA;
            ushort eventBufSize = Csta.CSTA_MAX_HEAP;
            ushort numEvents;
            retCode = Acs.acsGetEventBlock(this.acsHandle,
                                          evtBuf,
                                          ref eventBufSize,
                                          privData,
                                          out numEvents);
            if (evtBuf.evt.eventHeader.eventClass.eventClass == Csta.CSTACONFIRMATION && evtBuf.evt.eventHeader.eventType.eventType == Csta.CSTA_ALTERNATE_CALL_CONF)
            {
                MessageBox.Show("AlternateCall Succeded");
            }
            else
            {
                MessageBox.Show("AlternateCall Failed. Error was: " + evtBuf.evt.cstaConfirmation.universalFailure.error);
            }
        }

        private Csta.ConnectionID_t[] GetCurrentConnections(Csta.DeviceID_t device)
        {
            if (!this.configured)
            {
                MessageBox.Show("Application is not configured");
                this.mainTabs.SelectTab(configTab);
                return null;
            }
            if (!streamCheckbox.Checked || deviceTextBox.Text.Length == 0 || deviceTextBox.Text.Length > 5 || !streamCheckbox.Checked) { return null; }
            Csta.DeviceID_t currentDevice = device;
            Acs.InvokeID_t invokeId = new Acs.InvokeID_t();
            Acs.RetCode_t retCode = Csta.cstaSnapshotDeviceReq(this.acsHandle,
                                                 invokeId,
                                                 ref currentDevice,
                                                 privData);
            if (retCode._value < 0)
            {
                MessageBox.Show("cstaSnapshotDeviceReq error: " + retCode);
                return null;
            }
            var evtBuf = new Csta.EventBuffer_t();
            this.privData.length = Att.ATT_MAX_PRIVATE_DATA;
            ushort eventBufSize = Csta.CSTA_MAX_HEAP;
            ushort numEvents;
            retCode = Acs.acsGetEventBlock(this.acsHandle,
                                          evtBuf,
                                          ref eventBufSize,
                                          privData,
                                          out numEvents);

            if (retCode._value != Acs.ACSPOSITIVE_ACK)
            {
                MessageBox.Show("acsGetEventBlock error: " + retCode);
                return null;
            }
            if (evtBuf.evt.eventHeader.eventClass.eventClass != Csta.CSTACONFIRMATION || evtBuf.evt.eventHeader.eventType.eventType != Csta.CSTA_SNAPSHOT_DEVICE_CONF)
            {
                if (evtBuf.evt.eventHeader.eventClass.eventClass == Csta.CSTACONFIRMATION && evtBuf.evt.eventHeader.eventType.eventType == Csta.CSTA_UNIVERSAL_FAILURE_CONF)
                {
                    MessageBox.Show("Snapshot device failed. Error: " + evtBuf.evt.cstaConfirmation.universalFailure.error);
                }
                return null;
            }
            int callCount = evtBuf.evt.cstaConfirmation.snapshotDevice.snapshotData.count;
            Csta.ConnectionID_t[] conns = new Csta.ConnectionID_t[callCount];
            for (int i = 0; i < callCount; i++)
            {
                var snapDeviceInfoArray = (Csta.CSTASnapshotDeviceResponseInfo_t[])evtBuf.auxData["snapDeviceInfo"];
                conns[i] = snapDeviceInfoArray[i].callIdentifier;
            }
            return conns;
        }

        private void cstaAnswerCallButton_Click(object sender, EventArgs e)
        {
            if (!streamCheckbox.Checked || deviceTextBox.Text.Length == 0 || deviceTextBox.Text.Length > 5 || !streamCheckbox.Checked) { return; }
            Csta.ConnectionID_t[] conns = GetCurrentConnections(this.deviceTextBox.Text);
            if (conns == null || conns.Length == 0)
            {
                MessageBox.Show("No active calls");
                return;
            }
            var invokeId = new Acs.InvokeID_t();
            Acs.RetCode_t retCode = Csta.cstaAnswerCall(this.acsHandle, invokeId, conns[0], null);
            Debug.WriteLine("cstaAnswerCall result = " + retCode._value);

            var evtBuf = new Csta.EventBuffer_t();
            this.privData.length = Att.ATT_MAX_PRIVATE_DATA;
            ushort eventBufSize = Csta.CSTA_MAX_HEAP;
            ushort numEvents;
            retCode = Acs.acsGetEventBlock(this.acsHandle,
                                          evtBuf,
                                          ref eventBufSize,
                                          privData,
                                          out numEvents);
            if (evtBuf.evt.eventHeader.eventClass.eventClass == Csta.CSTACONFIRMATION && evtBuf.evt.eventHeader.eventType.eventType == Csta.CSTA_ANSWER_CALL_CONF)
            {
                MessageBox.Show("cstaAnswerCall Succeded");
            }
            else
            {
                MessageBox.Show("cstaAnswerCall Failed. Error was: " + evtBuf.evt.cstaConfirmation.universalFailure.error);
            }
        }

        private void cstaConferenceCallButton_Click(object sender, EventArgs e)
        {
            if (!streamCheckbox.Checked || deviceTextBox.Text.Length == 0 || deviceTextBox.Text.Length > 5 || !streamCheckbox.Checked) { return; }
            Csta.ConnectionID_t[] conns = GetCurrentConnections(this.deviceTextBox.Text);

            if (conns == null || conns.Length < 2)
            {
                MessageBox.Show("Need 2 calls on the device to connect them in conference");
                return;
            }
            var invokeId = new Acs.InvokeID_t();
            Acs.RetCode_t retCode = Csta.cstaConferenceCall(this.acsHandle, invokeId, conns[0], conns[1], this.privData);
            Debug.WriteLine("cstaConferenceCall result = " + retCode._value);

            var evtBuf = new Csta.EventBuffer_t();
            this.privData.length = Att.ATT_MAX_PRIVATE_DATA;
            ushort eventBufSize = Csta.CSTA_MAX_HEAP;
            ushort numEvents;
            retCode = Acs.acsGetEventBlock(this.acsHandle,
                                          evtBuf,
                                          ref eventBufSize,
                                          privData,
                                          out numEvents);
            if (evtBuf.evt.eventHeader.eventClass.eventClass == Csta.CSTACONFIRMATION && evtBuf.evt.eventHeader.eventType.eventType == Csta.CSTA_CONFERENCE_CALL_CONF)
            {
                Att.ATTEvent_t attEvt = new Att.ATTEvent_t();
                retCode = Att.attPrivateData(this.privData, attEvt);
                Debug.WriteLine("attPrivateData retCode = " + retCode._value);
                MessageBox.Show("cstaConferenceCall Succeded. UCID of the new call = " + attEvt.conferenceCall.ucid);
            }
            else
            {
                MessageBox.Show("cstaConferenceCall Failed. Error was: " + evtBuf.evt.cstaConfirmation.universalFailure.error);
            }

        }

        private void cstaConsultantCallButton_Click(object sender, EventArgs e)
        {
            if (!streamCheckbox.Checked || deviceTextBox.Text.Length == 0 || deviceTextBox.Text.Length > 5 || !streamCheckbox.Checked) { return; }

            cstaConsultationCallPopupForm subform = new cstaConsultationCallPopupForm();
            subform.ShowDialog();
            if (subform.DialogResult == DialogResult.OK)
            {
                if (subform.consultationCallRadioButton.Checked)
                {
                    Csta.DeviceID_t dev = subform.ReturnDeviceId;
                    Acs.InvokeID_t invoikeId = new Acs.InvokeID_t();
                    Csta.ConnectionID_t[] conns = GetCurrentConnections(this.deviceTextBox.Text);

                    if (conns == null || conns.Length == 0)
                    {
                        MessageBox.Show("No active calls");
                        return;
                    }

                    // Define private data
                    var u2uString = "Hello, I AM test u2u string";
                    var u2uInfo = new Att.ATTUserToUserInfo_t();
                    // fixed u2u size
                    int u2uSize = Att.ATT_MAX_UUI_SIZE;
                    u2uInfo.length = (short)u2uString.Length;
                    u2uInfo.type = Att.ATTUUIProtocolType_t.UUI_IA5_ASCII;
                    u2uInfo.value = Encoding.ASCII.GetBytes(u2uString);
                    Array.Resize(ref u2uInfo.value, u2uSize);
                    var dummyDev = new Csta.DeviceID_t();

                    Att.attV6ConsultationCall(this.privData, ref dummyDev, false, ref u2uInfo);


                    Acs.RetCode_t retCode = Csta.cstaConsultationCall(this.acsHandle, invoikeId, conns[0], ref dev, this.privData);
                    if (retCode._value > 0)
                    {
                        Csta.EventBuffer_t evtBuf = new Csta.EventBuffer_t();
                        ushort numEvents;
                        ushort eventBufSize = Csta.CSTA_MAX_HEAP;
                        Acs.acsGetEventBlock(this.acsHandle, evtBuf, ref eventBufSize, this.privData, out numEvents);
                        if (evtBuf.evt.eventHeader.eventClass.eventClass == Csta.CSTACONFIRMATION && evtBuf.evt.eventHeader.eventType.eventType == Csta.CSTA_CONSULTATION_CALL_CONF)
                        {
                            Att.ATTEvent_t attEvt = new Att.ATTEvent_t();
                            retCode = Att.attPrivateData(this.privData, attEvt);
                            Debug.WriteLine("attPrivateData retCode = " + retCode._value);
                            if (attEvt.eventType.eventType == Att.ATT_CONSULTATION_CALL_CONF)
                                MessageBox.Show(String.Format("Consultant Call to {0} successfull! Ucid of new call = {1}", dev.ToString(), attEvt.consultationCall.ucid));
                            else
                                MessageBox.Show("Got wrong ATT Event... " + attEvt.eventType.eventType);
                        }
                        else if (evtBuf.evt.eventHeader.eventClass.eventClass == Csta.CSTACONFIRMATION && evtBuf.evt.eventHeader.eventType.eventType == Csta.CSTA_UNIVERSAL_FAILURE_CONF)
                        {
                            MessageBox.Show("Could not perform ConsultantCall. Error: " + evtBuf.evt.cstaConfirmation.universalFailure.error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("There was an error during cstaConsultantCall. Code = " + retCode._value);
                    }
                }
                else if (subform.DirectAgentCallRadioButton.Checked)
                {
                    Csta.DeviceID_t dev = subform.ReturnDeviceId;
                    Acs.InvokeID_t invoikeId = new Acs.InvokeID_t();
                    Csta.ConnectionID_t[] conns = GetCurrentConnections(this.deviceTextBox.Text);

                    if (conns == null || conns.Length == 0)
                    {
                        MessageBox.Show("No active calls");
                        return;
                    }

                    // Define private data
                    var u2uString = "Hello, I AM test u2u string";
                    var u2uInfo = new Att.ATTUserToUserInfo_t();
                    // fixed u2u size
                    int u2uSize = Att.ATT_MAX_UUI_SIZE;
                    u2uInfo.length = (short)u2uString.Length;
                    u2uInfo.type = Att.ATTUUIProtocolType_t.UUI_IA5_ASCII;
                    u2uInfo.value = Encoding.ASCII.GetBytes(u2uString);
                    Array.Resize(ref u2uInfo.value, u2uSize);
                    Csta.DeviceID_t split = subform.ReturnDeviceId;

                    Att.attV6DirectAgentCall(this.privData, ref split, false, ref u2uInfo);


                    Acs.RetCode_t retCode = Csta.cstaConsultationCall(this.acsHandle, invoikeId, conns[0], ref dev, this.privData);
                    if (retCode._value > 0)
                    {
                        Csta.EventBuffer_t evtBuf = new Csta.EventBuffer_t();
                        ushort numEvents;
                        ushort eventBufSize = Csta.CSTA_MAX_HEAP;
                        Acs.acsGetEventBlock(this.acsHandle, evtBuf, ref eventBufSize, this.privData, out numEvents);
                        if (evtBuf.evt.eventHeader.eventClass.eventClass == Csta.CSTACONFIRMATION && evtBuf.evt.eventHeader.eventType.eventType == Csta.CSTA_CONSULTATION_CALL_CONF)
                        {
                            Att.ATTEvent_t attEvt = new Att.ATTEvent_t();
                            retCode = Att.attPrivateData(this.privData, attEvt);
                            if (attEvt.eventType.eventType == Att.ATT_DIRECT_AGENT_CALL)
                                MessageBox.Show(String.Format("Consultant Call to {0} successfull! Ucid of new call = {1}", dev.ToString(), attEvt.consultationCall.ucid));
                            else
                                MessageBox.Show("Got wrong ATT Event... " + attEvt.eventType.eventType);
                            Debug.WriteLine("attPrivateData retCode = " + retCode._value);
                            MessageBox.Show(String.Format("Consultant Call to {0} successfull! Ucid of new call = {1}", dev.ToString(), attEvt.conferenceCall.ucid));
                        }
                        else if (evtBuf.evt.eventHeader.eventClass.eventClass == Csta.CSTACONFIRMATION && evtBuf.evt.eventHeader.eventType.eventType == Csta.CSTA_UNIVERSAL_FAILURE_CONF)
                        {
                            MessageBox.Show("Could not perform ConsultantCall. Error: " + evtBuf.evt.cstaConfirmation.universalFailure.error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("There was an error during cstaConsultantCall. Code = " + retCode._value);
                    }
                }
                else if (subform.supervisorAssistCallRadioButton.Checked)
                {
                    Csta.DeviceID_t dev = subform.ReturnDeviceId;
                    Acs.InvokeID_t invoikeId = new Acs.InvokeID_t();
                    Csta.ConnectionID_t[] conns = GetCurrentConnections(this.deviceTextBox.Text);
        
                    if (conns == null || conns.Length == 0)
                    {
                        MessageBox.Show("No active calls");
                        return;
                    }

                    // Define private data
                    var u2uString = "Hello, I AM test u2u string";
                    var u2uInfo = new Att.ATTUserToUserInfo_t();
                    // fixed u2u size
                    int u2uSize = Att.ATT_MAX_UUI_SIZE;
                    u2uInfo.length = (short)u2uString.Length;
                    u2uInfo.type = Att.ATTUUIProtocolType_t.UUI_IA5_ASCII;
                    u2uInfo.value = Encoding.ASCII.GetBytes(u2uString);
                    Array.Resize(ref u2uInfo.value, u2uSize);
                    Csta.DeviceID_t split = subform.ReturnDeviceId;

                    Att.attV6SupervisorAssistCall(this.privData, ref split, ref u2uInfo);


                    Acs.RetCode_t retCode = Csta.cstaConsultationCall(this.acsHandle, invoikeId, conns[0], ref dev, this.privData);
                    if (retCode._value > 0)
                    {
                        Csta.EventBuffer_t evtBuf = new Csta.EventBuffer_t();
                        ushort numEvents;
                        ushort eventBufSize = Csta.CSTA_MAX_HEAP;
                        Acs.acsGetEventBlock(this.acsHandle, evtBuf, ref eventBufSize, this.privData, out numEvents);
                        if (evtBuf.evt.eventHeader.eventClass.eventClass == Csta.CSTACONFIRMATION && evtBuf.evt.eventHeader.eventType.eventType == Csta.CSTA_CONSULTATION_CALL_CONF)
                        {
                            Att.ATTEvent_t attEvt = new Att.ATTEvent_t();
                            retCode = Att.attPrivateData(this.privData, attEvt);
                            if (attEvt.eventType.eventType == Att.ATT_DIRECT_AGENT_CALL)
                                MessageBox.Show(String.Format("Consultant Call to {0} successfull! Ucid of new call = {1}", dev.ToString(), attEvt.consultationCall.ucid));
                            else
                                MessageBox.Show("Got wrong ATT Event... " + attEvt.eventType.eventType);
                            Debug.WriteLine("attPrivateData retCode = " + retCode._value);
                            MessageBox.Show(String.Format("Consultant Call to {0} successfull! Ucid of new call = {1}", dev.ToString(), attEvt.conferenceCall.ucid));
                        }
                        else if (evtBuf.evt.eventHeader.eventClass.eventClass == Csta.CSTACONFIRMATION && evtBuf.evt.eventHeader.eventType.eventType == Csta.CSTA_UNIVERSAL_FAILURE_CONF)
                        {
                            MessageBox.Show("Could not perform ConsultantCall. Error: " + evtBuf.evt.cstaConfirmation.universalFailure.error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("There was an error during cstaConsultantCall. Code = " + retCode._value);
                    }
                }
            }
        }

        private void deflectCallButton_Click(object sender, EventArgs e)
        {
            if (!streamCheckbox.Checked || deviceTextBox.Text.Length == 0 || deviceTextBox.Text.Length > 5 || !streamCheckbox.Checked) { return; }
            Csta.ConnectionID_t[] conns = GetCurrentConnections(this.deviceTextBox.Text);

            if (conns == null || conns.Length == 0)
            {
                MessageBox.Show("No active calls");
                return;
            }
            var invokeId = new Acs.InvokeID_t();

            var deviceSelectDialog = new DeviceSelectPopupForm();
            deviceSelectDialog.ShowDialog();
            DialogResult deviceSelectResult = deviceSelectDialog.DialogResult;
            if (deviceSelectResult != DialogResult.OK)
            {
                //MessageBox.Show("No device selected");
                return;
            }
            Csta.DeviceID_t calledDevice = deviceSelectDialog.deviceIdTextBox.Text;

            Acs.RetCode_t retCode = Csta.cstaDeflectCall(this.acsHandle, invokeId, conns[0], ref calledDevice, null);
            Debug.WriteLine("cstaDeflectCall result = " + retCode._value);

            var evtBuf = new Csta.EventBuffer_t();
            ushort eventBufSize = Csta.CSTA_MAX_HEAP;
            ushort numEvents;
            retCode = Acs.acsGetEventBlock(this.acsHandle,
                                          evtBuf,
                                          ref eventBufSize,
                                          privData,
                                          out numEvents);
            if (evtBuf.evt.eventHeader.eventClass.eventClass == Csta.CSTACONFIRMATION && evtBuf.evt.eventHeader.eventType.eventType == Csta.CSTA_DEFLECT_CALL_CONF)
            {
                MessageBox.Show("cstaDeflectCall Succeded");
            }
            else
            {
                MessageBox.Show("cstaDeflectCall Failed. Error was: " + evtBuf.evt.cstaConfirmation.universalFailure.error);
            }
        }

        private void cstaHoldButton_Click(object sender, EventArgs e)
        {
            if (!streamCheckbox.Checked || deviceTextBox.Text.Length == 0 || deviceTextBox.Text.Length > 5 || !streamCheckbox.Checked) { return; }

            Csta.ConnectionID_t[] conns = GetCurrentConnections(this.deviceTextBox.Text);

            if (conns == null || conns.Length == 0)
            {
                MessageBox.Show("No active calls");
                return;
            }

            var invokeId = new Acs.InvokeID_t();

            Acs.RetCode_t retCode = Csta.cstaHoldCall(this.acsHandle, invokeId, conns[0], false, null);
            Debug.WriteLine("cstaHoldCall result = " + retCode._value);

            var evtBuf = new Csta.EventBuffer_t();
            ushort eventBufSize = Csta.CSTA_MAX_HEAP;
            ushort numEvents;
            retCode = Acs.acsGetEventBlock(this.acsHandle,
                                          evtBuf,
                                          ref eventBufSize,
                                          privData,
                                          out numEvents);
            if (evtBuf.evt.eventHeader.eventClass.eventClass == Csta.CSTACONFIRMATION && evtBuf.evt.eventHeader.eventType.eventType == Csta.CSTA_HOLD_CALL_CONF)
            {
                MessageBox.Show("cstaHoldCall Succeded");
            }
            else
            {
                MessageBox.Show("cstaHoldCall Failed. Error was: " + evtBuf.evt.cstaConfirmation.universalFailure.error);
            }
        }

        private void cstaMakeCallButton_Click(object sender, EventArgs e)
        {
            if (!streamCheckbox.Checked || deviceTextBox.Text.Length == 0 || deviceTextBox.Text.Length > 5 || !streamCheckbox.Checked) { return; }

            var invokeId = new Acs.InvokeID_t();
            Csta.DeviceID_t callingDevice = this.deviceTextBox.Text;

            var deviceSelectDialog = new cstaMakeCallPopupForm();
            deviceSelectDialog.ShowDialog();
            DialogResult deviceSelectResult = deviceSelectDialog.DialogResult;
            if (deviceSelectResult != DialogResult.OK)
            {
                //MessageBox.Show("No device selected");
                return;
            }
            Csta.DeviceID_t calledDevice = deviceSelectDialog.deviceIdTextBox.Text;

            var u2uString = "Hello, I AM test u2u string";
            var u2uInfo = new Att.ATTUserToUserInfo_t();
            // fixed u2u size
            int u2uSize = Att.ATT_MAX_UUI_SIZE;
            u2uInfo.length = (short)u2uString.Length;
            u2uInfo.type = Att.ATTUUIProtocolType_t.UUI_IA5_ASCII;
            u2uInfo.value = Encoding.ASCII.GetBytes(u2uString);
            Array.Resize(ref u2uInfo.value, u2uSize);
            Csta.DeviceID_t destRouteOrSplit;
            if (deviceSelectDialog.destRouteOrSplitTextBox.Text == string.Empty)
                destRouteOrSplit = null;
            else
                destRouteOrSplit = deviceSelectDialog.destRouteOrSplitTextBox.Text;

            if (deviceSelectDialog.normalCallRadio.Checked)
                Att.attV6MakeCall(this.privData, ref destRouteOrSplit, false, ref u2uInfo);
            else if (deviceSelectDialog.directAgentCallRadio.Checked)
                Att.attV6DirectAgentCall(this.privData, ref destRouteOrSplit, false, ref u2uInfo);
            else if (deviceSelectDialog.supervisorAssistCallRadio.Checked)
                Att.attV6SupervisorAssistCall(this.privData, ref destRouteOrSplit, ref u2uInfo);

            Acs.RetCode_t retCode = Csta.cstaMakeCall(this.acsHandle, invokeId, ref callingDevice, ref calledDevice, this.privData);
            Debug.WriteLine("cstaMakeCall result = " + retCode._value);

            var evtBuf = new Csta.EventBuffer_t();
            ushort eventBufSize = Csta.CSTA_MAX_HEAP;
            ushort numEvents;
            retCode = Acs.acsGetEventBlock(this.acsHandle,
                                          evtBuf,
                                          ref eventBufSize,
                                          privData,
                                          out numEvents);
            if (evtBuf.evt.eventHeader.eventClass.eventClass == Csta.CSTACONFIRMATION && evtBuf.evt.eventHeader.eventType.eventType == Csta.CSTA_MAKE_CALL_CONF)
            {
                Att.ATTEvent_t attEvt = new Att.ATTEvent_t();
                retCode = Att.attPrivateData(this.privData, attEvt);
                Debug.WriteLine("attPrivateData retCode = " + retCode._value);
                if (attEvt.eventType.eventType == Att.ATT_MAKE_CALL_CONF)
                    MessageBox.Show(String.Format("Make Call from {0} to {1} is successfull! Ucid of new call = {2}", callingDevice.ToString(), calledDevice.ToString(), attEvt.consultationCall.ucid));
                else
                    MessageBox.Show("Got wrong ATT Event... " + attEvt.eventType.eventType);
            }
            else
            {
                MessageBox.Show("cstaMakeCall Failed. Error was: " + evtBuf.evt.cstaConfirmation.universalFailure.error);
            }
        }

        private void cstaMakePredictiveCallButton_Click(object sender, EventArgs e)
        {
            if (!streamCheckbox.Checked || deviceTextBox.Text.Length == 0 || deviceTextBox.Text.Length > 5 || !streamCheckbox.Checked) { return; }

            var invokeId = new Acs.InvokeID_t();
            Csta.DeviceID_t callingDevice = this.deviceTextBox.Text;
            DeviceSelectPopupForm deviceSelect = new DeviceSelectPopupForm();
            DialogResult deviceSelectDialog = deviceSelect.ShowDialog();
            if (deviceSelectDialog != DialogResult.OK) return;

            Csta.DeviceID_t calledDevice = deviceSelect.deviceIdTextBox.Text;
            var u2uString = "Hello, I AM test u2u string";
            var u2uInfo = new Att.ATTUserToUserInfo_t();
            // fixed u2u size
            int u2uSize = Att.ATT_MAX_UUI_SIZE;
            u2uInfo.length = (short)u2uString.Length;
            u2uInfo.type = Att.ATTUUIProtocolType_t.UUI_IA5_ASCII;
            u2uInfo.value = Encoding.ASCII.GetBytes(u2uString);
            Array.Resize(ref u2uInfo.value, u2uSize);
            Att.ATTAnswerTreat_t at = Att.ATTAnswerTreat_t.AT_NONE;
            var dummyDev = new Csta.DeviceID_t();

            Att.attV6MakePredictiveCall(this.privData, false, 2, at, ref dummyDev, ref u2uInfo);

            Csta.AllocationState_t allocState = Csta.AllocationState_t.AS_CALL_ESTABLISHED;
            Acs.RetCode_t retCode = Csta.cstaMakePredictiveCall(this.acsHandle, invokeId, ref callingDevice, ref calledDevice, allocState, this.privData);
            Debug.WriteLine("cstaMakePredictiveCall result = " + retCode._value);

            var evtBuf = new Csta.EventBuffer_t();
            ushort eventBufSize = Csta.CSTA_MAX_HEAP;
            ushort numEvents;
            retCode = Acs.acsGetEventBlock(this.acsHandle,
                                          evtBuf,
                                          ref eventBufSize,
                                          privData,
                                          out numEvents);
            if (evtBuf.evt.eventHeader.eventClass.eventClass == Csta.CSTACONFIRMATION && evtBuf.evt.eventHeader.eventType.eventType == Csta.CSTA_MAKE_PREDICTIVE_CALL_CONF)
            {
                Att.ATTEvent_t attEvt = new Att.ATTEvent_t();
                retCode = Att.attPrivateData(this.privData, attEvt);
                Debug.WriteLine("attPrivateData retCode = " + retCode._value);
                if (attEvt.eventType.eventType == Att.ATT_MAKE_PREDICTIVE_CALL_CONF)
                    MessageBox.Show(String.Format("Make Predictive Call from {0} to {1} is successfull! Ucid of new call = {2}", callingDevice.ToString(), calledDevice.ToString(), attEvt.makePredictiveCall.ucid));
                else
                    MessageBox.Show("Got wrong ATT Event... " + attEvt.eventType.eventType);

                MessageBox.Show("cstaMakePredictiveCall Succeded");
            }
            else
            {
                MessageBox.Show("cstaMakePredictiveCall Failed. Error was: " + evtBuf.evt.cstaConfirmation.universalFailure.error);
            }
        }

        private void cstaPickupCallButton_Click(object sender, EventArgs e)
        {
            if (!streamCheckbox.Checked || deviceTextBox.Text.Length == 0 || deviceTextBox.Text.Length > 5 || !streamCheckbox.Checked) { return; }

            var invokeId = new Acs.InvokeID_t();
            var deviceSelectDialog = new DeviceSelectPopupForm();
            deviceSelectDialog.ShowDialog();
            DialogResult deviceSelectResult = deviceSelectDialog.DialogResult;
            if (deviceSelectResult != DialogResult.OK)
            {
                //MessageBox.Show("No device selected");
                return;
            }
            Csta.DeviceID_t calledDevice = this.deviceTextBox.Text;
            Csta.ConnectionID_t[] conns = GetCurrentConnections(deviceSelectDialog.deviceIdTextBox.Text);
            if (conns == null || conns.Length == 0)
            {
                MessageBox.Show("No active calls");
                return;
            }

            Acs.RetCode_t retCode = Csta.cstaPickupCall(this.acsHandle, invokeId, conns[0], ref calledDevice, null);
            Debug.WriteLine("cstaPickupCall result = " + retCode._value);

            var evtBuf = new Csta.EventBuffer_t();
            ushort eventBufSize = Csta.CSTA_MAX_HEAP;
            ushort numEvents;
            retCode = Acs.acsGetEventBlock(this.acsHandle,
                                          evtBuf,
                                          ref eventBufSize,
                                          privData,
                                          out numEvents);
            if (evtBuf.evt.eventHeader.eventClass.eventClass == Csta.CSTACONFIRMATION && evtBuf.evt.eventHeader.eventType.eventType == Csta.CSTA_PICKUP_CALL_CONF)
            {
                MessageBox.Show("cstaPickupCall Succeded");
            }
            else
            {
                MessageBox.Show("cstaPickupCall Failed. Error was: " + evtBuf.evt.cstaConfirmation.universalFailure.error);
            }
        }

        private void cstaReconnectCallButton_Click(object sender, EventArgs e)
        {
            if (!streamCheckbox.Checked || deviceTextBox.Text.Length == 0 || deviceTextBox.Text.Length > 5 || !streamCheckbox.Checked) { return; }
            Csta.ConnectionID_t[] conns = GetCurrentConnections(this.deviceTextBox.Text);

            if (conns == null || conns.Length < 2)
            {
                MessageBox.Show("Need 2 calls to reconnect them");
                return;
            }

            var invokeId = new Acs.InvokeID_t();

            var u2uString = "Hello, I AM test u2u string";
            var u2uInfo = new Att.ATTUserToUserInfo_t();
            int u2uSize = Att.ATT_MAX_UUI_SIZE;
            u2uInfo.length = (short)u2uString.Length;
            u2uInfo.type = Att.ATTUUIProtocolType_t.UUI_IA5_ASCII;
            u2uInfo.value = Encoding.ASCII.GetBytes(u2uString);
            Array.Resize(ref u2uInfo.value, u2uSize);
            var dropResource = Att.ATTDropResource_t.DR_NONE;

            Att.attV6ReconnectCall(this.privData, dropResource, ref u2uInfo);

            Acs.RetCode_t retCode = Csta.cstaReconnectCall(this.acsHandle, invokeId, conns[0], conns[1], this.privData);
            Debug.WriteLine("cstaReconnectCall result = " + retCode._value);

            var evtBuf = new Csta.EventBuffer_t();
            ushort eventBufSize = Csta.CSTA_MAX_HEAP;
            ushort numEvents;
            retCode = Acs.acsGetEventBlock(this.acsHandle,
                                          evtBuf,
                                          ref eventBufSize,
                                          privData,
                                          out numEvents);
            if (evtBuf.evt.eventHeader.eventClass.eventClass == Csta.CSTACONFIRMATION && evtBuf.evt.eventHeader.eventType.eventType == Csta.CSTA_RECONNECT_CALL_CONF)
            {
                MessageBox.Show("cstaReconnectCall Succeded");
            }
            else
            {
                MessageBox.Show("cstaReconnectCall Failed. Error was: " + evtBuf.evt.cstaConfirmation.universalFailure.error);
            }
        }

        private void esrCheckBox_Click(object sender, EventArgs e)
        {
            if (this.esrCheckBox.Checked)
            {
                ESRRegister();
            }
            else
            {
                ESRDeRegister();
            }
        }

        private void wmEventNotifyCheckBox_Click(object sender, EventArgs e)
        {
            if (this.wmEventNotifyCheckBox.Checked)
            {
                EventNotifyRegister();
            }
            else
            {
                EventNotifyDeRegister();
            }
        }

        private void cstaRetrieveCallButton_Click(object sender, EventArgs e)
        {
            if (!streamCheckbox.Checked || deviceTextBox.Text.Length == 0 || deviceTextBox.Text.Length > 5 || !streamCheckbox.Checked) { return; }
            Csta.ConnectionID_t[] conns = GetCurrentConnections(this.deviceTextBox.Text);

            if (conns == null || conns.Length == 0)
            {
                MessageBox.Show("No active calls");
                return;
            }

            var invokeId = new Acs.InvokeID_t();
            Acs.RetCode_t retCode = Csta.cstaRetrieveCall(this.acsHandle, invokeId, conns[0], null);
            Debug.WriteLine("cstaRetrieveCall result = " + retCode._value);

            var evtBuf = new Csta.EventBuffer_t();
            ushort eventBufSize = Csta.CSTA_MAX_HEAP;
            ushort numEvents;
            retCode = Acs.acsGetEventBlock(this.acsHandle,
                                          evtBuf,
                                          ref eventBufSize,
                                          privData,
                                          out numEvents);
            if (evtBuf.evt.eventHeader.eventClass.eventClass == Csta.CSTACONFIRMATION && evtBuf.evt.eventHeader.eventType.eventType == Csta.CSTA_RETRIEVE_CALL_CONF)
            {
                MessageBox.Show("cstaRetrieveCall Succeded");
            }
            else
            {
                MessageBox.Show("cstaRetrieveCall Failed. Error was: " + evtBuf.evt.cstaConfirmation.universalFailure.error);
            }
        }

        private void SendDTMFToneButton_Click(object sender, EventArgs e)
        {
            if (!streamCheckbox.Checked || deviceTextBox.Text.Length == 0 || deviceTextBox.Text.Length > 5 || !streamCheckbox.Checked) { return; }
            Csta.ConnectionID_t[] conns = GetCurrentConnections(this.deviceTextBox.Text);

            if (conns == null || conns.Length == 0)
            {
                MessageBox.Show("No active calls");
                return;
            }

            var dtmfSelect = new DTMFSelectSubForm();
            DialogResult dtmfSelectDialog = dtmfSelect.ShowDialog();
            if (dtmfSelectDialog != DialogResult.OK) return;
            string tones = dtmfSelect.DTMFSequenceTextBox.Text;

            var ignored = new Att.ATTConnIDList_t();
            Acs.RetCode_t retCode = Att.attSendDTMFToneExt(this.privData, conns[0], ref ignored, tones, 0, 0);
            if (retCode._value != Acs.ACSPOSITIVE_ACK) return;

            var invokeId = new Acs.InvokeID_t();
            retCode = Csta.cstaEscapeService(this.acsHandle, invokeId, this.privData);

            var evtBuf = new Csta.EventBuffer_t();
            ushort eventBufSize = Csta.CSTA_MAX_HEAP;
            ushort numEvents;
            retCode = Acs.acsGetEventBlock(this.acsHandle,
                                          evtBuf,
                                          ref eventBufSize,
                                          privData,
                                          out numEvents);
            if (evtBuf.evt.eventHeader.eventClass.eventClass == Csta.CSTACONFIRMATION && evtBuf.evt.eventHeader.eventType.eventType == Csta.CSTA_ESCAPE_SVC_CONF)
            {
                MessageBox.Show("attSendDTMFToneExt Succeded");
            }
            else
            {
                MessageBox.Show("attSendDTMFToneExt Failed. Error was: " + evtBuf.evt.cstaConfirmation.universalFailure.error);
            }
        }

        private void attSelectiveListeningHoldButton_Click(object sender, EventArgs e)
        {
            if (!streamCheckbox.Checked || deviceTextBox.Text.Length == 0 || deviceTextBox.Text.Length > 5 || !streamCheckbox.Checked) { return; }

            Csta.DeviceID_t currentDevice = deviceTextBox.Text;
            Acs.InvokeID_t invokeId = new Acs.InvokeID_t();
            Acs.RetCode_t retCode = Csta.cstaSnapshotDeviceReq(this.acsHandle,
                                                 invokeId,
                                                 ref currentDevice,
                                                 this.privData);
            if (retCode._value < 0)
            {
                MessageBox.Show("cstaSnapshotDeviceReq error: " + retCode);
                return;
            }
            Csta.EventBuffer_t evtBuf = new Csta.EventBuffer_t();
            this.privData.length = Att.ATT_MAX_PRIVATE_DATA;
            ushort eventBufSize = Csta.CSTA_MAX_HEAP;
            ushort numEvt;
            retCode = Acs.acsGetEventBlock(this.acsHandle,
                                          evtBuf,
                                          ref eventBufSize,
                                          privData,
                                          out numEvt);
            if (retCode._value < 0)
            {
                MessageBox.Show("acsGetEventBlock error: " + retCode);
                return;
            }
            if (evtBuf.evt.eventHeader.eventClass.eventClass != Csta.CSTACONFIRMATION || evtBuf.evt.eventHeader.eventType.eventType != Csta.CSTA_SNAPSHOT_DEVICE_CONF)
            {
                if (evtBuf.evt.eventHeader.eventClass.eventClass == Csta.CSTACONFIRMATION && evtBuf.evt.eventHeader.eventType.eventType == Csta.CSTA_UNIVERSAL_FAILURE_CONF)
                {
                    MessageBox.Show("Snapshot device failed. Error: " + evtBuf.evt.cstaConfirmation.universalFailure.error);
                }
                return;
            }
            int callCountForSnapshotDevice = evtBuf.evt.cstaConfirmation.snapshotDevice.snapshotData.count;
            if (callCountForSnapshotDevice < 1)
            {
                MessageBox.Show("No active calls");
                return;
            }
            var snapDeviceInfoArray = (Csta.CSTASnapshotDeviceResponseInfo_t[])evtBuf.auxData["snapDeviceInfo"];
            var firstConn = snapDeviceInfoArray[0].callIdentifier;
            Csta.EventBuffer_t snapCallEvt = snapshotCall(firstConn);
            int callCountForSnapshotCall = snapCallEvt.evt.cstaConfirmation.snapshotCall.snapshotData.count;
            var snapCallInfoArray = (Csta.CSTASnapshotCallResponseInfo_t[])snapCallEvt.auxData["snapCallInfo"];

            var snapCallConnsArray = new Csta.ConnectionID_t[snapCallInfoArray.Length];
            for (int i = 0; i < snapCallInfoArray.Length; i++)
            {
                snapCallConnsArray[i] = snapCallInfoArray[i].callIdentifier;
            }

            var selectiveListeningHoldPopup = new attSelectiveListeningHoldPopupForm(snapCallConnsArray);
            selectiveListeningHoldPopup._parent = this;
            selectiveListeningHoldPopup.ShowDialog();
        }

        private void attSelectiveListeningRetrieveButton_Click(object sender, EventArgs e)
        {
            if (!streamCheckbox.Checked || deviceTextBox.Text.Length == 0 || deviceTextBox.Text.Length > 5 || !streamCheckbox.Checked) { return; }

            Csta.DeviceID_t currentDevice = deviceTextBox.Text;
            Acs.InvokeID_t invokeId = new Acs.InvokeID_t();
            Acs.RetCode_t retCode = Csta.cstaSnapshotDeviceReq(this.acsHandle,
                                                 invokeId,
                                                 ref currentDevice,
                                                 this.privData);
            if (retCode._value < 0)
            {
                MessageBox.Show("cstaSnapshotDeviceReq error: " + retCode);
                return;
            }
            Csta.EventBuffer_t evtBuf = new Csta.EventBuffer_t();
            this.privData.length = Att.ATT_MAX_PRIVATE_DATA;
            ushort eventBufSize = Csta.CSTA_MAX_HEAP;
            ushort numEvt;
            retCode = Acs.acsGetEventBlock(this.acsHandle,
                                          evtBuf,
                                          ref eventBufSize,
                                          privData,
                                          out numEvt);
            if (retCode._value < 0)
            {
                MessageBox.Show("acsGetEventBlock error: " + retCode);
                return;
            }
            if (evtBuf.evt.eventHeader.eventClass.eventClass != Csta.CSTACONFIRMATION || evtBuf.evt.eventHeader.eventType.eventType != Csta.CSTA_SNAPSHOT_DEVICE_CONF)
            {
                if (evtBuf.evt.eventHeader.eventClass.eventClass == Csta.CSTACONFIRMATION && evtBuf.evt.eventHeader.eventType.eventType == Csta.CSTA_UNIVERSAL_FAILURE_CONF)
                {
                    MessageBox.Show("Snapshot device failed. Error: " + evtBuf.evt.cstaConfirmation.universalFailure.error);
                }
                return;
            }
            int callCountForSnapshotDevice = evtBuf.evt.cstaConfirmation.snapshotDevice.snapshotData.count;
            if (callCountForSnapshotDevice < 1)
            {
                MessageBox.Show("No active calls");
                return;
            }
            var snapDeviceInfoArray = (Csta.CSTASnapshotDeviceResponseInfo_t[])evtBuf.auxData["snapDeviceInfo"];
            var firstConn = snapDeviceInfoArray[0].callIdentifier;
            Csta.EventBuffer_t snapCallEvt = snapshotCall(firstConn);
            int callCountForSnapshotCall = snapCallEvt.evt.cstaConfirmation.snapshotCall.snapshotData.count;
            var snapCallInfoArray = (Csta.CSTASnapshotCallResponseInfo_t[])snapCallEvt.auxData["snapCallInfo"];

            var snapCallConnsArray = new Csta.ConnectionID_t[snapCallInfoArray.Length];
            for (int i = 0; i < snapCallInfoArray.Length; i++)
            {
                snapCallConnsArray[i] = snapCallInfoArray[i].callIdentifier;
            }

            var selectiveListeningRetruevePopup = new attSelectiveListeningRetrievePopupForm(snapCallConnsArray);
            selectiveListeningRetruevePopup._parent = this;
            selectiveListeningRetruevePopup.ShowDialog();
        }

        private void attSingleStepConferenceCallButton_Click(object sender, EventArgs e)
        {
            if (!streamCheckbox.Checked || deviceTextBox.Text.Length == 0 || deviceTextBox.Text.Length > 5 || !streamCheckbox.Checked) { return; }
            Csta.DeviceID_t currentDevice = deviceTextBox.Text;
            Csta.ConnectionID_t[] conns = GetCurrentConnections(this.deviceTextBox.Text);

            if (conns == null || conns.Length == 0)
            {
                MessageBox.Show("No active calls");
                return;
            }
            var devicePopup = new DeviceSelectPopupForm();
            devicePopup._parent = this;
            var dialogResult = devicePopup.ShowDialog();
            if (dialogResult != DialogResult.OK) return;
            Csta.DeviceID_t deviceToBeJoin = devicePopup.deviceIdTextBox.Text;
            var activeCall = conns[0];


            Acs.RetCode_t retCode = Att.attSingleStepConferenceCall(this.privData, activeCall, ref deviceToBeJoin, Att.ATTParticipationType_t.PT_ACTIVE, false);
            Log("attSingleStepConferenceCall result = " + retCode._value);


            if (retCode._value < 0) return;
            var invokeId = new Acs.InvokeID_t();
            retCode = Csta.cstaEscapeService(this.acsHandle, invokeId, this.privData);

            if (retCode._value < 0)
            {
                this.Log("cstaEscapeService result = " + retCode._value);
                return;
            }
            ushort eventBufferSize = Csta.CSTA_MAX_HEAP;
            this.privData.length = Att.ATT_MAX_PRIVATE_DATA;
            var eventBuf = new Csta.EventBuffer_t();
            ushort numEvents;
            retCode = Acs.acsGetEventBlock(this.acsHandle, eventBuf, ref eventBufferSize, this.privData, out numEvents);
            this.Log("acsGetEventBlock result = " + retCode._value);
            if (retCode._value < 0) return;

            if (eventBuf.evt.eventHeader.eventClass.eventClass == Csta.CSTACONFIRMATION && eventBuf.evt.eventHeader.eventType.eventType == Csta.CSTA_ESCAPE_SVC_CONF)
            {
                Att.ATTEvent_t attEvt = new Att.ATTEvent_t();
                retCode = Att.attPrivateData(this.privData, attEvt);
                Debug.WriteLine("attPrivateData retCode = " + retCode._value);
                if (attEvt.eventType.eventType == Att.ATT_SINGLE_STEP_CONFERENCE_CALL_CONF)
                    MessageBox.Show("attSingleStepConference Succeded. New call UCID = " + attEvt.ssconference.ucid);
                else
                    MessageBox.Show("Got wrong ATT Event... " + attEvt.eventType.eventType);
            }
            else
            {
                MessageBox.Show("attSingleStepConference Failed. Error was: " + eventBuf.evt.cstaConfirmation.universalFailure.error);
            }

        }

        private void attSingleStepTransferCallButton_Click(object sender, EventArgs e)
        {
            if (!streamCheckbox.Checked || deviceTextBox.Text.Length == 0 || deviceTextBox.Text.Length > 5 || !streamCheckbox.Checked) { return; }
            Csta.DeviceID_t currentDevice = deviceTextBox.Text;
            Csta.ConnectionID_t[] conns = GetCurrentConnections(this.deviceTextBox.Text);

            if (conns == null || conns.Length == 0)
            {
                MessageBox.Show("No active calls");
                return;
            }

            var devicePopup = new DeviceSelectPopupForm();
            devicePopup._parent = this;
            var dialogResult = devicePopup.ShowDialog();
            if (dialogResult != DialogResult.OK) return;
            Csta.DeviceID_t transferredTo = devicePopup.deviceIdTextBox.Text;
            var activeCall = conns[0];

            Acs.RetCode_t retCode = Att.attSingleStepTransferCall(this.privData, activeCall, ref transferredTo);
            Log("attSingleStepTransferCall result = " + retCode._value);

            if (retCode._value < 0) return;
            var invokeId = new Acs.InvokeID_t();
            retCode = Csta.cstaEscapeService(this.acsHandle, invokeId, this.privData);

            if (retCode._value < 0)
            {
                this.Log("cstaEscapeService result = " + retCode._value);
                return;
            }

            ushort eventBufferSize = Csta.CSTA_MAX_HEAP;
            this.privData.length = Att.ATT_MAX_PRIVATE_DATA;
            var eventBuf = new Csta.EventBuffer_t();
            ushort numEvents;
            retCode = Acs.acsGetEventBlock(this.acsHandle, eventBuf, ref eventBufferSize, this.privData, out numEvents);
            this.Log("acsGetEventBlock result = " + retCode._value);
            if (retCode._value < 0) return;

            if (eventBuf.evt.eventHeader.eventClass.eventClass == Csta.CSTACONFIRMATION && eventBuf.evt.eventHeader.eventType.eventType == Csta.CSTA_ESCAPE_SVC_CONF)
            {
                Att.ATTEvent_t attEvt = new Att.ATTEvent_t();
                retCode = Att.attPrivateData(this.privData, attEvt);
                Debug.WriteLine("attPrivateData retCode = " + retCode._value);
                if (attEvt.eventType.eventType == Att.ATT_SINGLE_STEP_TRANSFER_CALL_CONF)
                    MessageBox.Show("attSingleStepTransfer Succeded. New device = " + attEvt.ssTransferCallConf.transferredCall.deviceID);
                else
                    MessageBox.Show("Got wrong ATT Event... " + attEvt.eventType.eventType);
            }
            else
            {
                MessageBox.Show("attSingleStepConference Failed. Error was: " + eventBuf.evt.cstaConfirmation.universalFailure.error);
            }
        }

        private void cstaTransferCallButton_Click(object sender, EventArgs e)
        {
            if (!streamCheckbox.Checked || deviceTextBox.Text.Length == 0 || deviceTextBox.Text.Length > 5 || !streamCheckbox.Checked) { return; }
            Csta.DeviceID_t currentDevice = deviceTextBox.Text;
            Csta.ConnectionID_t[] conns = GetCurrentConnections(this.deviceTextBox.Text);

            if (conns == null || conns.Length == 0)
            {
                MessageBox.Show("No active calls");
                return;
            }

            Acs.RetCode_t retCode = Csta.cstaTransferCall(this.acsHandle, new Acs.InvokeID_t(), conns[1], conns[0], this.privData);

            ushort eventBufferSize = Csta.CSTA_MAX_HEAP;
            this.privData.length = Att.ATT_MAX_PRIVATE_DATA;
            var eventBuf = new Csta.EventBuffer_t();
            ushort numEvents;
            retCode = Acs.acsGetEventBlock(this.acsHandle, eventBuf, ref eventBufferSize, this.privData, out numEvents);
            this.Log("acsGetEventBlock result = " + retCode._value);
            if (retCode._value < 0) return;

            if (eventBuf.evt.eventHeader.eventClass.eventClass == Csta.CSTACONFIRMATION && eventBuf.evt.eventHeader.eventType.eventType == Csta.CSTA_TRANSFER_CALL_CONF)
            {
                Att.ATTEvent_t attEvt = new Att.ATTEvent_t();
                retCode = Att.attPrivateData(this.privData, attEvt);
                Debug.WriteLine("attPrivateData retCode = " + retCode._value);
                if (attEvt.eventType.eventType == Att.ATT_TRANSFER_CALL_CONF)
                    MessageBox.Show("TransferCall Succeded. New call UCID = " + attEvt.transferCall.ucid);
                else
                    MessageBox.Show("Got wrong ATT Event... " + attEvt.eventType.eventType);
            }
            else
            {
                MessageBox.Show("TransferCall Failed. Error was: " + eventBuf.evt.cstaConfirmation.universalFailure.error);
            }
        }

        private void cstaClearCallButton_Click(object sender, EventArgs e)
        {
            if (!streamCheckbox.Checked || deviceTextBox.Text.Length == 0 || deviceTextBox.Text.Length > 5 || !streamCheckbox.Checked) { return; }
            Csta.DeviceID_t currentDevice = deviceTextBox.Text;
            Csta.ConnectionID_t[] conns = GetCurrentConnections(this.deviceTextBox.Text);

            if (conns == null || conns.Length == 0)
            {
                MessageBox.Show("No active calls");
                return;
            }
            Csta.EventBuffer_t eventBuf = Csta.clearCall(this.acsHandle, conns[0]);
            if (eventBuf.evt.eventHeader.eventClass.eventClass == Csta.CSTACONFIRMATION && 
                eventBuf.evt.eventHeader.eventType.eventType == Csta.CSTA_CLEAR_CALL_CONF)
                MessageBox.Show("Call Clear succeded!");
            else
                MessageBox.Show("Call Clear failed. Error was: " + eventBuf.evt.cstaConfirmation.universalFailure.error);
        }

        private void cstaClearConnectionButton_Click(object sender, EventArgs e)
        {
            if (!streamCheckbox.Checked || deviceTextBox.Text.Length == 0 || deviceTextBox.Text.Length > 5 || !streamCheckbox.Checked) { return; }
            Csta.DeviceID_t currentDevice = deviceTextBox.Text;
            Csta.ConnectionID_t[] conns = GetCurrentConnections(this.deviceTextBox.Text);

            if (conns == null || conns.Length == 0)
            {
                MessageBox.Show("No active calls");
                return;
            }
            Csta.EventBuffer_t eventBuf = Csta.clearConnection(this.acsHandle, this.privData, conns[0]);
            if (eventBuf.evt.eventHeader.eventClass.eventClass == Csta.CSTACONFIRMATION && 
                eventBuf.evt.eventHeader.eventType.eventType == Csta.CSTA_CLEAR_CONNECTION_CONF)
                MessageBox.Show("Connection clear succeded!");
            else
                MessageBox.Show("Connection clear failed. Error was: " + eventBuf.evt.cstaConfirmation.universalFailure.error);
        }

        private void attSetAdviceOfChargeButton_Click(object sender, EventArgs e)
        {
            Acs.RetCode_t retCode = Att.attSetAdviceOfCharge(this.privData, true);
            
            var invokeId = new Acs.InvokeID_t();
            retCode = Csta.cstaEscapeService(this.acsHandle, invokeId, this.privData);

            ushort eventBufferSize = Csta.CSTA_MAX_HEAP;
            this.privData.length = Att.ATT_MAX_PRIVATE_DATA;
            var eventBuf = new Csta.EventBuffer_t();
            ushort numEvents;
            retCode = Acs.acsGetEventBlock(this.acsHandle, eventBuf, ref eventBufferSize, this.privData, out numEvents);
            this.Log("acsGetEventBlock result = " + retCode._value);
            if (retCode._value < 0) return;
            if (eventBuf.evt.eventHeader.eventClass.eventClass == Csta.CSTACONFIRMATION && eventBuf.evt.eventHeader.eventType.eventType == Csta.CSTA_ESCAPE_SVC_CONF)
            {
                Att.ATTEvent_t attEvt = new Att.ATTEvent_t();
                retCode = Att.attPrivateData(this.privData, attEvt);
                Debug.WriteLine("attPrivateData retCode = " + retCode._value);
                if (attEvt.eventType.eventType == Att.ATT_SET_ADVICE_OF_CHARGE_CONF)
                    MessageBox.Show("AdviceOfCharge is set");
                else
                    MessageBox.Show("Got wrong ATT Event... " + attEvt.eventType.eventType);
            }
            else
            {
                MessageBox.Show("SetAdviceOfCharge Failed. Error was: " + eventBuf.evt.cstaConfirmation.universalFailure.error);
            }
        }

        private void cstaSetAgentStateButton_Click(object sender, EventArgs e)
        {
            if (!streamCheckbox.Checked || deviceTextBox.Text.Length == 0 || deviceTextBox.Text.Length > 5 || !streamCheckbox.Checked) { return; }
            Csta.DeviceID_t currentDevice = deviceTextBox.Text;

            var popup = new cstaSetAgentStatePopupForm();
            DialogResult dialogResult = popup.ShowDialog();

            if (dialogResult != DialogResult.OK) return;
            Csta.AgentID_t agentId = popup.agentId;
            Csta.AgentMode_t agentMode = popup.agentMode;
            Att.ATTWorkMode_t workMode = popup.workMode;
            int reasonCode = popup.reasonCode;
            bool enablePending = popup.enablePending;
            Csta.AgentGroup_t agentGroup = new Csta.AgentGroup_t();
            Csta.AgentPassword_t agentPass = "";

            Acs.RetCode_t retCode = Att.attV6SetAgentState(this.privData, workMode, reasonCode, enablePending);
            Log("attV6SetAgentState result = " + retCode._value);

            retCode = Csta.cstaSetAgentState(this.acsHandle, new Acs.InvokeID_t(), ref currentDevice, agentMode, agentId, agentGroup, agentPass, this.privData);
            this.Log("cstaSetAgentState result = " + retCode._value);
            if (retCode._value < 0) return;

            ushort eventBufferSize = Csta.CSTA_MAX_HEAP;
            this.privData.length = Att.ATT_MAX_PRIVATE_DATA;
            var eventBuf = new Csta.EventBuffer_t();
            ushort numEvents;
            retCode = Acs.acsGetEventBlock(this.acsHandle, eventBuf, ref eventBufferSize, this.privData, out numEvents);
            this.Log("acsGetEventBlock result = " + retCode._value);
            if (retCode._value < 0) return;

            if (eventBuf.evt.eventHeader.eventClass.eventClass == Csta.CSTACONFIRMATION && eventBuf.evt.eventHeader.eventType.eventType == Csta.CSTA_SET_AGENT_STATE_CONF)
            {
                Att.ATTEvent_t attEvt = new Att.ATTEvent_t();
                retCode = Att.attPrivateData(this.privData, attEvt);
                Debug.WriteLine("attPrivateData retCode = " + retCode._value);
                if (attEvt.eventType.eventType == Att.ATT_SET_AGENT_STATE_CONF)
                    MessageBox.Show(string.Format("cstaSetAgentState {0} succeded. Pending? {1}", agentMode, attEvt.setAgentState.isPending));
                else
                    MessageBox.Show("Got wrong ATT Event... " + attEvt.eventType.eventType);
            }
            else
            {
                MessageBox.Show("cstaSetAgentState Failed. Error was: " + eventBuf.evt.cstaConfirmation.universalFailure.error);
            }

        }

        private void attSetBillRateButton_Click(object sender, EventArgs e)
        {
            if (!streamCheckbox.Checked || deviceTextBox.Text.Length == 0 || deviceTextBox.Text.Length > 5 || !streamCheckbox.Checked) { return; }
            Csta.DeviceID_t currentDevice = deviceTextBox.Text;
            Csta.ConnectionID_t[] conns = GetCurrentConnections(this.deviceTextBox.Text);

            if (conns == null || conns.Length == 0)
            {
                MessageBox.Show("No active calls");
                return;
            }

            var popup = new attSetBillRatePopupForm();
            DialogResult dialogResult = popup.ShowDialog();
            if (dialogResult != DialogResult.OK) return;

            Att.ATTBillType_t billType = popup.billType;
            float billRate = popup.billRate;

            Acs.RetCode_t retCode = Att.attSetBillRate(this.privData, conns[0], billType, billRate);
            retCode = Csta.cstaEscapeService(this.acsHandle, new Acs.InvokeID_t(), this.privData);

            ushort eventBufferSize = Csta.CSTA_MAX_HEAP;
            this.privData.length = Att.ATT_MAX_PRIVATE_DATA;
            var eventBuf = new Csta.EventBuffer_t();
            ushort numEvents;
            retCode = Acs.acsGetEventBlock(this.acsHandle, eventBuf, ref eventBufferSize, this.privData, out numEvents);
            this.Log("acsGetEventBlock result = " + retCode._value);
            if (retCode._value < 0) return;
            if (eventBuf.evt.eventHeader.eventClass.eventClass == Csta.CSTACONFIRMATION && eventBuf.evt.eventHeader.eventType.eventType == Csta.CSTA_ESCAPE_SVC_CONF)
            {
                Att.ATTEvent_t attEvt = new Att.ATTEvent_t();
                retCode = Att.attPrivateData(this.privData, attEvt);
                Debug.WriteLine("attPrivateData retCode = " + retCode._value);
                if (attEvt.eventType.eventType == Att.ATT_SET_BILL_RATE_CONF)
                    MessageBox.Show("Bill rate is set");
                else
                    MessageBox.Show("Got wrong ATT Event... " + attEvt.eventType.eventType);
            }
            else
            {
                MessageBox.Show("attSetBillRate Failed. Error was: " + eventBuf.evt.cstaConfirmation.universalFailure.error);
            }
        }

        private void cstaSetDoNotDisturbButton_Click(object sender, EventArgs e)
        {
            if (!streamCheckbox.Checked || deviceTextBox.Text.Length == 0 || deviceTextBox.Text.Length > 5 || !streamCheckbox.Checked) { return; }
            Csta.DeviceID_t currentDevice = deviceTextBox.Text;
            Acs.RetCode_t retCode = Csta.cstaSetDoNotDisturb(this.acsHandle, new Acs.InvokeID_t(), ref currentDevice, true, this.privData);
            ushort eventBufferSize = Csta.CSTA_MAX_HEAP;
            this.privData.length = Att.ATT_MAX_PRIVATE_DATA;
            var eventBuf = new Csta.EventBuffer_t();
            ushort numEvents;
            retCode = Acs.acsGetEventBlock(this.acsHandle, eventBuf, ref eventBufferSize, this.privData, out numEvents);
            this.Log("acsGetEventBlock result = " + retCode._value);
            if (retCode._value < 0) return;

            if (eventBuf.evt.eventHeader.eventClass.eventClass == Csta.CSTACONFIRMATION && eventBuf.evt.eventHeader.eventType.eventType == Csta.CSTA_SET_DND_CONF)
                MessageBox.Show("cstaSetDoNotDisturb succeded");
            else
                MessageBox.Show("cstaSetDoNotDisturb Failed. Error was: " + eventBuf.evt.cstaConfirmation.universalFailure.error);
        }

        private void cstaSetForwardingButton_Click(object sender, EventArgs e)
        {
            if (!streamCheckbox.Checked || deviceTextBox.Text.Length == 0 || deviceTextBox.Text.Length > 5 || !streamCheckbox.Checked) { return; }
            Csta.DeviceID_t currentDevice = deviceTextBox.Text;

            var popup = new cstaSetForwardingPopupForm();
            var dialogResult = popup.ShowDialog();
            if (dialogResult != DialogResult.OK) return;
            Csta.DeviceID_t destDevice = popup.deviceId;
            bool enableForwarding = !popup.disableForwarding;

            Acs.RetCode_t retCode = Csta.cstaSetForwarding(this.acsHandle, new Acs.InvokeID_t(), ref currentDevice, Csta.ForwardingType_t.FWD_IMMEDIATE, enableForwarding, ref destDevice, this.privData);
            if (retCode._value < 0) return;

            ushort eventBufferSize = Csta.CSTA_MAX_HEAP;
            this.privData.length = Att.ATT_MAX_PRIVATE_DATA;
            var eventBuf = new Csta.EventBuffer_t();
            ushort numEvents;
            retCode = Acs.acsGetEventBlock(this.acsHandle, eventBuf, ref eventBufferSize, this.privData, out numEvents);
            this.Log("acsGetEventBlock result = " + retCode._value);
            if (retCode._value < 0) return;

            if (eventBuf.evt.eventHeader.eventClass.eventClass == Csta.CSTACONFIRMATION && eventBuf.evt.eventHeader.eventType.eventType == Csta.CSTA_SET_FWD_CONF)
                MessageBox.Show("cstaSetForwarding succeded");
            else
                MessageBox.Show("cstaSetForwarding Failed. Error was: " + eventBuf.evt.cstaConfirmation.universalFailure.error);
        }

        private void cstaSetMsgWaitingIndButton_Click(object sender, EventArgs e)
        {
            if (!streamCheckbox.Checked || deviceTextBox.Text.Length == 0 || deviceTextBox.Text.Length > 5 || !streamCheckbox.Checked) { return; }
            Csta.DeviceID_t currentDevice = deviceTextBox.Text;

            var popup = new cstaSetMsgWaitingIndPopupForm();
            var dialogResult = popup.ShowDialog();
            if (dialogResult != DialogResult.OK) return;
            bool mwiEnabled = popup.mwiEnabled;
            Acs.RetCode_t retCode = Csta.cstaSetMsgWaitingInd(this.acsHandle, new Acs.InvokeID_t(), ref currentDevice, mwiEnabled, this.privData);
            if (retCode._value < 0) return;

            ushort eventBufferSize = Csta.CSTA_MAX_HEAP;
            this.privData.length = Att.ATT_MAX_PRIVATE_DATA;
            var eventBuf = new Csta.EventBuffer_t();
            ushort numEvents;
            retCode = Acs.acsGetEventBlock(this.acsHandle, eventBuf, ref eventBufferSize, this.privData, out numEvents);
            this.Log("acsGetEventBlock result = " + retCode._value);
            if (retCode._value < 0) return;

            if (eventBuf.evt.eventHeader.eventClass.eventClass == Csta.CSTACONFIRMATION && eventBuf.evt.eventHeader.eventType.eventType == Csta.CSTA_SET_MWI_CONF)
                MessageBox.Show("cstaSetMsgWaitingInd succeded");
            else
                MessageBox.Show("cstaSetMsgWaitingInd Failed. Error was: " + eventBuf.evt.cstaConfirmation.universalFailure.error);

        }

        private void querySplitButton_Click(object sender, EventArgs e)
        {
            Csta.DeviceID_t currentDevice = this.deviceTextBox.Text;
            Acs.RetCode_t retCode = Att.attQueryAcdSplit(this.privData, ref currentDevice);
            var escapeData = new Att.CstaEscapeData();
            escapeData.GetAttEvents(this.acsHandle, this.privData);
            if (escapeData.cstaReturnCode._value < 0)
            {
                MessageBox.Show("Could not get CSTA event. Error code = " + escapeData.cstaReturnCode._value);
                return;
            }
            if (escapeData.attReturnCode._value < 0)
            {
                MessageBox.Show("Could not get ATT event. Error code = " + escapeData.attReturnCode._value);
                return;
            }
            if (escapeData.attEvts == null)
            {
                MessageBox.Show("ATT method failed. Error was: " + escapeData.cstaError.error);
                return;
            }
           if (escapeData.attEvts[0].eventType.eventType == Att.ATT_QUERY_ACD_SPLIT_CONF)
           {
               Log("ATTQueryAcdSplit data:");
               Log("availableAgents " + escapeData.attEvts[0].queryAcdSplit.availableAgents);
               Log("callsInQueue  " + escapeData.attEvts[0].queryAcdSplit.callsInQueue);
               Log("agentsLoggedIn  " + escapeData.attEvts[0].queryAcdSplit.agentsLoggedIn);
               MessageBox.Show("ATTQueryAcdSplit succeded. Look in the log for details.");
           }
        }

        private void attQueryAgentLoginButton_Click(object sender, EventArgs e)
        {
            Csta.DeviceID_t currentDevice = this.deviceTextBox.Text;
            Acs.RetCode_t retCode = Att.attQueryAgentLogin(this.privData, ref currentDevice);
            var escapeData = new Att.CstaEscapeData();
            escapeData.GetAttEvents(this.acsHandle, this.privData);
            if (escapeData.cstaReturnCode._value < 0)
            {
                MessageBox.Show("Could not get CSTA event. Error code = " + escapeData.cstaReturnCode._value);
                return;
            }
            if (escapeData.attReturnCode._value < 0)
            {
                MessageBox.Show("Could not get ATT event. Error code = " + escapeData.attReturnCode._value);
                return;
            }
            if (escapeData.attEvts == null)
            {
                MessageBox.Show("ATT method failed. Error was: " + escapeData.cstaError.error);
                return;
            }
            if (escapeData.attEvts[0].eventType.eventType == Att.ATT_QUERY_AGENT_LOGIN_CONF)
            {
                Att.ATTPrivEventCrossRefID_t privEventCrossRefID = escapeData.attEvts[0].queryAgentLogin.privEventCrossRefID;
                Log("attQueryAgentLogin results:");
                Log("List of logged in agents:");
                Log("__________________________________________________________");
                foreach (Att.ATTEvent_t attEvt in escapeData.attEvts)
                {
                    if (attEvt.eventType.eventType == Att.ATT_QUERY_AGENT_LOGIN_RESP &&
                        attEvt.queryAgentLoginResp.count > 0 &&
                        attEvt.queryAgentLoginResp.privEventCrossRefID._value == privEventCrossRefID._value)
                    {
                        string s = "";
                        for (int i = 0; i < attEvt.queryAgentLoginResp.count; i++)
                            s += attEvt.queryAgentLoginResp.device[i] + "\t ";
                        Log(s);
                    }
                }

                MessageBox.Show("attQueryAgentLogin succeded. Look in the log for details.");
            }
        }

        private void cstaQueryAgentStateButton_Click(object sender, EventArgs e)
        {
            var popup = new cstaQueryAgentStatePopupForm();
            popup.ShowDialog();
            if (popup.DialogResult != DialogResult.OK) return;
            var agentId = popup.device;
            var split = popup.split;

            // Prepare ATT request
            Acs.RetCode_t retCode = Att.attQueryAgentState(this.privData, ref split);
            if (retCode._value < 0 )
            {
                Log ("ATT error during attQueryAgentState. Error = " + retCode._value);
                return;
            }
            
            // Make CSTA call
            retCode = Csta.cstaQueryAgentState(this.acsHandle, new Acs.InvokeID_t(), ref agentId, this.privData);
            if (retCode._value < 0)
            {
                Log("CSTA  error during cstaQueryAgentState. Error = " + retCode._value);
                return;
            }

            // Get CSTA results
            ushort eventBufferSize = Csta.CSTA_MAX_HEAP;
            this.privData.length = Att.ATT_MAX_PRIVATE_DATA;
            var eventBuf = new Csta.EventBuffer_t();
            ushort numEvents;
            retCode = Acs.acsGetEventBlock(this.acsHandle, eventBuf, ref eventBufferSize, this.privData, out numEvents);
            this.Log("acsGetEventBlock result = " + retCode._value);
            if (retCode._value < 0)
            {
                Log("CSTA  error during acsGetEventBlock. Error = " + retCode._value);
                return;
            }
            if (eventBuf.evt.eventHeader.eventClass.eventClass != Csta.CSTACONFIRMATION || eventBuf.evt.eventHeader.eventType.eventType != Csta.CSTA_QUERY_AGENT_STATE_CONF )
            {
                Log("cstaQueryAgentState failed. Error = " + eventBuf.evt.cstaConfirmation.universalFailure.error);
                return;
            }
            if (eventBuf.evt.cstaConfirmation.queryAgentState.agentState == Csta.AgentState_t.AG_NULL)
            {
                Log("AgentID status:" + eventBuf.evt.cstaConfirmation.queryAgentState.agentState);
                return;
            }

            // Decode ATT Results
            var attEvt = new Att.ATTEvent_t();
            retCode = Att.attPrivateData(this.privData, attEvt);
            if (retCode._value < 0)
            {
                Log("ATT error during attPrivateData. Error = " + retCode._value);
                return;
            }
            if (attEvt.eventType.eventType != Att.ATT_QUERY_AGENT_STATE_CONF)
                if (retCode._value < 0)
                {
                    Log("Wrong ATT Event recieved: " + retCode._value);
                    return;
                }

            // Get the output
            Log("AgentID status:" + eventBuf.evt.cstaConfirmation.queryAgentState.agentState);
            Log("Work mode: " + attEvt.queryAgentState.workMode);
            Log("Talk state: " + attEvt.queryAgentState.talkState);
            Log("Reason code: " + attEvt.queryAgentState.reasonCode);
            Log("Pending work mode: " + attEvt.queryAgentState.pendingWorkMode);
            Log("Pending reason code: " + attEvt.queryAgentState.pendingReasonCode);
        }

        private void attQueryCallClassifierButton_Click(object sender, EventArgs e)
        {
            Acs.RetCode_t retCode = Att.attQueryCallClassifier(this.privData);
            var escapeData = new Att.CstaEscapeData();
            escapeData.GetAttEvents(this.acsHandle, this.privData);
            if (escapeData.attEvts[0].eventType.eventType != Att.ATT_QUERY_CALL_CLASSIFIER_CONF) return;
            Log("attQueryCallClassifier results:");
            Log("Available ports:" + escapeData.attEvts[0].queryCallClassifier.numAvailPorts);
            Log("InUse ports:" + escapeData.attEvts[0].queryCallClassifier.numInUsePorts);
            MessageBox.Show("attQueryCallClassifier succeded. Look in the log for details.");
        }

        private void cstaQueryDeviceInfoButton_Click(object sender, EventArgs e)
        {
            if (!streamCheckbox.Checked || deviceTextBox.Text.Length == 0 || deviceTextBox.Text.Length > 5 || !streamCheckbox.Checked) { return; }
            Csta.DeviceID_t currentDevice = deviceTextBox.Text;
            Acs.RetCode_t retCode = Csta.cstaQueryDeviceInfo(this.acsHandle, new Acs.InvokeID_t(), ref currentDevice, this.privData);
            if (retCode._value < 0) return;
            ushort eventBufferSize = Csta.CSTA_MAX_HEAP;
            this.privData.length = Att.ATT_MAX_PRIVATE_DATA;
            var eventBuf = new Csta.EventBuffer_t();
            ushort numEvents;
            retCode = Acs.acsGetEventBlock(this.acsHandle, eventBuf, ref eventBufferSize, this.privData, out numEvents);
            if (retCode._value < 0) return;
            if (eventBuf.evt.eventHeader.eventClass.eventClass == Csta.CSTACONFIRMATION && eventBuf.evt.eventHeader.eventType.eventType == Csta.CSTA_QUERY_DEVICE_INFO_CONF)
            {
                Log("Device: " + eventBuf.evt.cstaConfirmation.queryDeviceInfo.device);
                Log("Device Class: " + eventBuf.evt.cstaConfirmation.queryDeviceInfo.deviceClass);
                Log("Device Type: " + eventBuf.evt.cstaConfirmation.queryDeviceInfo.deviceType);

                Att.ATTEvent_t attEvt = new Att.ATTEvent_t();
                retCode = Att.attPrivateData(this.privData, attEvt);
                if (attEvt.eventType.eventType == Att.ATT_QUERY_DEVICE_INFO_CONF)
                {
                    Log("Associated Class: " + attEvt.queryDeviceInfo.associatedClass);
                    Log("Associated Device: " + attEvt.queryDeviceInfo.associatedDevice);
                    Log("Extension Class: " + attEvt.queryDeviceInfo.extensionClass);
                }

                MessageBox.Show("cstaQueryDeviceInfo succeded. Look into the log for details");
            }
            else
                MessageBox.Show("cstaQueryDeviceInfo Failed. Error was: " + eventBuf.evt.cstaConfirmation.universalFailure.error);

        }

        private void attQueryDeviceNameButton_Click(object sender, EventArgs e)
        {
            if (!streamCheckbox.Checked || deviceTextBox.Text.Length == 0 || deviceTextBox.Text.Length > 5 || !streamCheckbox.Checked) { return; }
            Csta.DeviceID_t currentDevice = deviceTextBox.Text;
            Acs.RetCode_t retCode = Att.attQueryDeviceName(this.privData, ref currentDevice);
            if (retCode._value < 0) return;
            var escapeData = new Att.CstaEscapeData();
            escapeData.GetAttEvents(this.acsHandle, this.privData);
            if (escapeData.attEvts[0].eventType.eventType != Att.ATT_QUERY_DEVICE_NAME_CONF) return;
            Log("attQueryDeviceName results:");
            Log("Device Type: " + escapeData.attEvts[0].queryDeviceName.deviceType);
            Log("Device: " + escapeData.attEvts[0].queryDeviceName.device);
            Log("Name: " + escapeData.attEvts[0].queryDeviceName.name);
            Log("Unicode Name: " + escapeData.attEvts[0].queryDeviceName.uname);
            MessageBox.Show("attQueryDeviceName succeded. Look in the log for details.");
        }

        private void cstaQueryDoNotDisturbButton_Click(object sender, EventArgs e)
        {
            if (!streamCheckbox.Checked || deviceTextBox.Text.Length == 0 || deviceTextBox.Text.Length > 5 || !streamCheckbox.Checked) { return; }
            Csta.DeviceID_t currentDevice = deviceTextBox.Text;
            Acs.RetCode_t retCode = Csta.cstaQueryDoNotDisturb(this.acsHandle, new Acs.InvokeID_t(), ref currentDevice, this.privData);
            if (retCode._value < 0) return;
            ushort eventBufferSize = Csta.CSTA_MAX_HEAP;
            this.privData.length = Att.ATT_MAX_PRIVATE_DATA;
            var eventBuf = new Csta.EventBuffer_t();
            ushort numEvents;
            retCode = Acs.acsGetEventBlock(this.acsHandle, eventBuf, ref eventBufferSize, this.privData, out numEvents);
            if (retCode._value < 0) return;
            if (eventBuf.evt.eventHeader.eventClass.eventClass == Csta.CSTACONFIRMATION && eventBuf.evt.eventHeader.eventType.eventType == Csta.CSTA_QUERY_DND_CONF)
            {
                Log("DND on " + currentDevice + ": " + eventBuf.evt.cstaConfirmation.queryDnd.doNotDisturb);
                MessageBox.Show("cstaQueryDeviceInfo succeded. Look into the log for details");
            }
            else
                MessageBox.Show("cstaQueryDeviceInfo Failed. Error was: " + eventBuf.evt.cstaConfirmation.universalFailure.error);
        }

        private void attQueryEndpointRegistrationInfoButton_Click(object sender, EventArgs e)
        {
            if (!streamCheckbox.Checked || deviceTextBox.Text.Length == 0 || deviceTextBox.Text.Length > 5 || !streamCheckbox.Checked) { return; }
            Csta.DeviceID_t currentDevice = deviceTextBox.Text;
            Acs.RetCode_t retCode = Att.attQueryEndpointRegistrationInfo(this.privData, ref currentDevice);
            if (retCode._value < 0) return;
            var escapeData = new Att.CstaEscapeData();
            escapeData.GetAttEvents(this.acsHandle, this.privData);

            //TODO: find ATT_QUERY_ENDPOINT_REGISTRATION_INFO_CONF value
            //if (escapeData.attEvts[0].eventType.eventType != Att.ATT_QUERY_ENDPOINT_REGISTRATION_INFO_CONF) return;
            if (escapeData.attEvts == null || escapeData.attEvts.Length < 1)
            {
                MessageBox.Show("attQueryEndpointRegistrationInfo failed. Error: " + escapeData.cstaError.error);
                return;
            }
            Log("attQueryEndpointRegistrationInfo results:");
            Log("Device:" + escapeData.attEvts[0].queryEndpointRegistrationInfo.device);
            Log("Service state:" + escapeData.attEvts[0].queryEndpointRegistrationInfo.serviceState);
            Log("[STUB] ptr to registered endpoints array:" + escapeData.attEvts[0].queryEndpointRegistrationInfo.registeredEndpoints);
        }

        private void cstaQueryForwardingButton_Click(object sender, EventArgs e)
        {
            if (!streamCheckbox.Checked || deviceTextBox.Text.Length == 0 || deviceTextBox.Text.Length > 5 || !streamCheckbox.Checked) { return; }
            Csta.DeviceID_t currentDevice = deviceTextBox.Text;
            Acs.RetCode_t retCode = Csta.cstaQueryForwarding(this.acsHandle, new Acs.InvokeID_t(), ref currentDevice, this.privData);
            if (retCode._value < 0) return;
            ushort eventBufferSize = Csta.CSTA_MAX_HEAP;
            this.privData.length = Att.ATT_MAX_PRIVATE_DATA;
            var eventBuf = new Csta.EventBuffer_t();
            ushort numEvents;
            retCode = Acs.acsGetEventBlock(this.acsHandle, eventBuf, ref eventBufferSize, this.privData, out numEvents);
            if (retCode._value < 0) return;
            if (eventBuf.evt.eventHeader.eventClass.eventClass == Csta.CSTACONFIRMATION && eventBuf.evt.eventHeader.eventType.eventType == Csta.CSTA_QUERY_FWD_CONF)
            {
                Log("Fwd enabled? " + eventBuf.evt.cstaConfirmation.queryFwd.forward.param[0].forwardingOn);
                if (eventBuf.evt.cstaConfirmation.queryFwd.forward.param[0].forwardingOn != 0)
                {
                    Log("Fwd DN: " + eventBuf.evt.cstaConfirmation.queryFwd.forward.param[0].forwardDN);
                    Log("Forwarding Type: " + eventBuf.evt.cstaConfirmation.queryFwd.forward.param[0].forwardingType);
                }
                MessageBox.Show("cstaQueryForwarding succeded. Look into the log for details");
            }
            else
                MessageBox.Show("cstaQueryForwarding Failed. Error was: " + eventBuf.evt.cstaConfirmation.universalFailure.error);
        }

        private void cstaQueryMsgWaitingIndButton_Click(object sender, EventArgs e)
        {
            if (!streamCheckbox.Checked || deviceTextBox.Text.Length == 0 || deviceTextBox.Text.Length > 5 || !streamCheckbox.Checked) { return; }
            Csta.DeviceID_t currentDevice = deviceTextBox.Text;
            Acs.RetCode_t retCode = Csta.cstaQueryMsgWaitingInd(this.acsHandle, new Acs.InvokeID_t(), ref currentDevice, this.privData);
            if (retCode._value < 0) return;
            ushort eventBufferSize = Csta.CSTA_MAX_HEAP;
            this.privData.length = Att.ATT_MAX_PRIVATE_DATA;
            var eventBuf = new Csta.EventBuffer_t();
            ushort numEvents;
            retCode = Acs.acsGetEventBlock(this.acsHandle, eventBuf, ref eventBufferSize, this.privData, out numEvents);
            if (retCode._value < 0) return;
            if (eventBuf.evt.eventHeader.eventClass.eventClass == Csta.CSTACONFIRMATION && eventBuf.evt.eventHeader.eventType.eventType == Csta.CSTA_QUERY_MWI_CONF)
            {
                Log("Got messages on " + currentDevice + "? " + eventBuf.evt.cstaConfirmation.queryMwi.messages);
                if (eventBuf.evt.cstaConfirmation.queryMwi.messages == false)
                {
                    return;
                }

                Att.ATTEvent_t attEvt = new Att.ATTEvent_t();
                retCode = Att.attPrivateData(this.privData, attEvt);
                if (attEvt.eventType.eventType == Att.ATT_QUERY_MWI_CONF)
                {
                    Log("Application type = " + attEvt.queryMwi.applicationType._value);
                }
                MessageBox.Show("cstaQueryDeviceInfo succeded. Look into the log for details");

            }
            else
                MessageBox.Show("cstaQueryDeviceInfo Failed. Error was: " + eventBuf.evt.cstaConfirmation.universalFailure.error);

        }
    }


    class CallNode : TreeNode
    {
        public Csta.ConnectionID_t connection;
    }
}
