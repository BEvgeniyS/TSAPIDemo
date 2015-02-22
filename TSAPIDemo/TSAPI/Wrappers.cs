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

namespace Tsapi
{
    public static class Wrappers
    {
        public static Acs.RetCode_t OpenStream(out Acs.ACSHandle_t acsHandle, out Acs.InvokeID_t invokeId, ref Acs.PrivateData_t privData)
        {
            // Prepare 
            Acs.InvokeIDType_t invokeIdType = Acs.InvokeIDType_t.LIB_GEN_ID;
            invokeId = new Acs.InvokeID_t();
            Acs.StreamType_t streamType = Acs.StreamType_t.ST_CSTA;
            Acs.ServerID_t serverId = "AVAYA#S8720SAMSUNG#CSTA#AESSERVER1";
            Acs.LoginID_t loginId = "tsuser";
            Acs.Passwd_t passwd = "tsuser";
            Acs.AppName_t appName = "XYITA";
            Acs.Level_t acsLevelReq = Acs.Level_t.ACS_LEVEL1;
            Acs.Version_t apiVer = "TS2";
            ushort sendQSize = 0;
            ushort sendExtraBufs = 0;
            ushort recvQSize = 0;
            ushort recvExtraBufs = 0;

            Acs.RetCode_t retCode = Acs.acsOpenStream(out acsHandle,
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
                                                      ref privData);
            if (retCode._value < 0 )
            {
                return retCode;
            }
            Csta.CSTAEvent_t evt = new Csta.CSTAEvent_t();
            ushort eventBufSize = Csta.CSTA_MAX_HEAP;
            ushort numEvents = 0;
            retCode = Acs.acsGetEventBlock(acsHandle,
                                     out evt,
                                     ref eventBufSize,
                                     ref privData,
                                     out numEvents);
            //Console.WriteLine("acsGetEventBlock retCode = " + retCode + " Buffer size = " + eventBufSize + ", numEvents = " + numEvents);
            //Console.WriteLine("privData.Length = " + privData.length);

            return retCode;
        }


        public static Att.ATTUCID_t[] GetUcid(Csta.DeviceID_t device)
        {
            Acs.ACSHandle_t acsHandle;
            Acs.InvokeID_t invokeId;
            
            // Set PrivateData request
            var privData = new Acs.PrivateData_t();
            privData.vendor = "VERSION";
            privData.data = new byte[1024];
            privData.data[0] = Acs.PRIVATE_DATA_ENCODING;

            // Get supportedVersion string
            string requestedVersion = "3-7"; // Private Data version request
            System.Text.StringBuilder supportedVersion = new System.Text.StringBuilder();
            Acs.RetCode_t attrc = Att.attMakeVersionString(requestedVersion, supportedVersion);
            //Console.WriteLine("attrc = " + attrc + "; supportedVersion = " + supportedVersion);

            for (int i = 0; i < supportedVersion.Length; i++)
            {
                privData.data[i + 1] = (byte)supportedVersion[i];
            }
            privData.length = Att.ATT_MAX_PRIVATE_DATA;

            Acs.RetCode_t retCode = OpenStream(out acsHandle, out invokeId, ref privData);
            //Console.WriteLine("acsOpenStream retCode = " + retCode + ", Handle = " + acsHandle.ToString());

            retCode = Csta.cstaSnapshotDeviceReq(acsHandle,
                                     invokeId,
                                     ref device,
                                     ref privData);

            privData.length = Att.ATT_MAX_PRIVATE_DATA;
            Csta.CSTAEvent_t evt = new Csta.CSTAEvent_t();
            ushort eventBufSize = Csta.CSTA_MAX_HEAP;
            ushort numEvents = 0;
            retCode = Acs.acsGetEventBlock(acsHandle,
                                          out evt,
                                          ref eventBufSize,
                                          ref privData,
                                          out numEvents);

            int callCount = evt.cstaConfirmation.snapshotDevice.snapshotData.count;
            Csta.ConnectionID_t[] connections = new Csta.ConnectionID_t[callCount];
            for (int i = 0; i < evt.cstaConfirmation.snapshotDevice.snapshotData.count; i++)
            {
                connections[i] = evt.cstaConfirmation.snapshotDevice.snapshotData.info[i].callIdentifier;
            }

            if (callCount > 0)
            {
                //Console.WriteLine(evt.cstaConfirmation.snapshotDevice.snapshotData);
                //Console.WriteLine(evt.cstaConfirmation.snapshotDevice.snapshotData.info[1].localCallState);
                Att.ATTUCID_t[] ucids = new Att.ATTUCID_t[callCount];
                for (int i = 0; i < callCount; i++)
                {
                    //Csta.ConnectionID_t connection = evt.cstaConfirmation.snapshotDevice.snapshotData.info[i].callIdentifier;

                    retCode = Att.attQueryUCID(ref privData, ref connections[i]);
                    //Console.WriteLine("attQueryUCID retCode = " + retCode);
                    //Console.WriteLine("privData.Length = " + privData.length);

                    retCode = Csta.cstaEscapeService(acsHandle, invokeId, ref privData);
                    //Console.WriteLine("cstaEscapeService retCode = " + retCode);
                    //Console.WriteLine("privData.Length = " + privData.length);
                    // Set private data length (we'll have to call GetEventBlock otherwise)
                    privData.length = Att.ATT_MAX_PRIVATE_DATA;
                    retCode = Acs.acsGetEventBlock(acsHandle,
                                                 out evt,
                                                 ref eventBufSize,
                                                 ref privData,
                                                 out numEvents);

                    //Console.WriteLine("acsGetEventBlock retCode = " + retCode + " Buffer size = " + eventBufSize + ", numEvents = " + numEvents);
                    //Console.WriteLine("eventClass = " + evt.eventHeader.eventClass);
                    //Console.WriteLine("eventType = " + evt.eventHeader.eventType);
                    //Console.WriteLine("privData.Length = " + privData.length);

                    // Decode ATTPrivateData
                    Att.ATTEvent_t attevt;
                    retCode = Att.attPrivateData(ref privData, out attevt);
                    ucids[i] = attevt.queryUCID.ucid;
                    //Console.WriteLine("attPrivateData retCode = " + retCode);
                    //Console.WriteLine("privData.Length = " + privData.length);
                    //Console.WriteLine("ATTeventType  = " + attevt.eventType);
                    //Console.WriteLine("ucid #{0} = {1}", i + 1, attevt.queryUCID.ucid);
                }
                Acs.acsAbortStream(acsHandle, out privData);
                return ucids;
            }
            else
            {
                Console.WriteLine("No active calls");
                Acs.acsAbortStream(acsHandle, out privData);
                return new Att.ATTUCID_t[0];
            }
        }
    }
}
