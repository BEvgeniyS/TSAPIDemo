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
using System.Runtime.InteropServices;

namespace Tsapi
{
    public static partial class Csta
    {
        public const string CSTA_API_VERSION = "TS2"; // Current version number of CSTA API

        // defines for CSTA event classes 
        public const int CSTAREQUEST = 3;
        public const int CSTAUNSOLICITED = 4;
        public const int CSTACONFIRMATION = 5;
        public const int CSTAEVENTREPORT = 6;

        public const int CSTA_MAX_GET_DEVICE = 20;  // Maximum number of devices
                                                    // a CSTAGetDevice call can
                                                    // return
        
    [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)] 
    public struct CSTARequestEvent
    {
        Acs.InvokeID_t invokeID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Csta.CSTA_MAX_HEAP)]
        private byte[] heap;
        public CSTARouteRequestEvent_t routeRequest
        {
            get
            {
                return (CSTARouteRequestEvent_t)Aux.ByteArrayToStructure<CSTARouteRequestEvent_t>(heap);
            }
        }
            public CSTARouteRequestExtEvent_t routeRequestExt
        {
            get
            {
                return (CSTARouteRequestExtEvent_t)Aux.ByteArrayToStructure<CSTARouteRequestExtEvent_t>(heap);
            }
        }
            public CSTAReRouteRequest_t reRouteRequest
        {
            get
            {
                return (CSTAReRouteRequest_t)Aux.ByteArrayToStructure<CSTAReRouteRequest_t>(heap);
            }
        }
            public CSTAEscapeSvcReqEvent_t escapeSvcReqeust
        {
            get
            {
                return (CSTAEscapeSvcReqEvent_t)Aux.ByteArrayToStructure<CSTAEscapeSvcReqEvent_t>(heap);
            }
        }
            public CSTASysStatReqEvent_t sysStatRequest
        {
            get
            {
                return (CSTASysStatReqEvent_t)Aux.ByteArrayToStructure<CSTASysStatReqEvent_t>(heap);
            }
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)] 
    public struct CSTAEventReport
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = CSTA_MAX_HEAP)]
        private byte[] heap;
        public CSTARouteRegisterAbortEvent_t registerAbort
        {
            get
            {
                return (CSTARouteRegisterAbortEvent_t)Aux.ByteArrayToStructure<CSTARouteRegisterAbortEvent_t>(heap);
            }
        }
        public CSTARouteUsedEvent_t routeUsed
        {
            get
            {
                return (CSTARouteUsedEvent_t)Aux.ByteArrayToStructure<CSTARouteUsedEvent_t>(heap);
            }
        }
        public CSTARouteUsedExtEvent_t routeUsedExt
        {
            get
            {
                return (CSTARouteUsedExtEvent_t)Aux.ByteArrayToStructure<CSTARouteUsedExtEvent_t>(heap);
            }
        }
        public CSTARouteEndEvent_t routeEnd
        {
            get
            {
                return (CSTARouteEndEvent_t)Aux.ByteArrayToStructure<CSTARouteEndEvent_t>(heap);
            }
        }
        public CSTAPrivateEvent_t privateEvent
        {
            get
            {
                return (CSTAPrivateEvent_t)Aux.ByteArrayToStructure<CSTAPrivateEvent_t>(heap);
            }
        }
        public CSTASysStatEvent_t sysStat
        {
            get
            {
                return (CSTASysStatEvent_t)Aux.ByteArrayToStructure<CSTASysStatEvent_t>(heap);
            }
        }
        public CSTASysStatEndedEvent_t sysStatEnded
        {
            get
            {
                return (CSTASysStatEndedEvent_t)Aux.ByteArrayToStructure<CSTASysStatEndedEvent_t>(heap);
            }
        }
    };

    [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
    public struct CSTAUnsolicitedEvent
    {
        CSTAMonitorCrossRefID_t monitorCrossRefId;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = CSTA_MAX_HEAP)]
        public byte[] heap;
        public CSTACallClearedEvent_t callCleared
        {
            get
            {
                return (CSTACallClearedEvent_t)Aux.ByteArrayToStructure<CSTACallClearedEvent_t>(heap);
            }
        }
        public CSTAConferencedEvent_t conferenced
        {
            get
            {
                return (CSTAConferencedEvent_t)Aux.ByteArrayToStructure<CSTAConferencedEvent_t>(heap);
            }
        }
        public CSTAConnectionClearedEvent_t connectionCleared
        {
            get
            {
                return (CSTAConnectionClearedEvent_t)Aux.ByteArrayToStructure<CSTAConnectionClearedEvent_t>(heap);
            }
        }
        public CSTADeliveredEvent_t delivered
        {
            get
            {
                return (CSTADeliveredEvent_t)Aux.ByteArrayToStructure<CSTADeliveredEvent_t>(heap);
            }
        }
        public CSTADivertedEvent_t diverted
        {
            get
            {
                return (CSTADivertedEvent_t)Aux.ByteArrayToStructure<CSTADivertedEvent_t>(heap);
            }
        }
        public CSTAEstablishedEvent_t established
        {
            get
            {
                return (CSTAEstablishedEvent_t)Aux.ByteArrayToStructure<CSTAEstablishedEvent_t>(heap);
            }
        }
        public CSTAFailedEvent_t failed
        {
            get
            {
                return (CSTAFailedEvent_t)Aux.ByteArrayToStructure<CSTAFailedEvent_t>(heap);
            }
        }
        public CSTAHeldEvent_t held
        {
            get
            {
                return (CSTAHeldEvent_t)Aux.ByteArrayToStructure<CSTAHeldEvent_t>(heap);
            }
        }
        public CSTANetworkReachedEvent_t networkReached
        {
            get
            {
                return (CSTANetworkReachedEvent_t)Aux.ByteArrayToStructure<CSTANetworkReachedEvent_t>(heap);
            }
        }
        public CSTAOriginatedEvent_t originated
        {
            get
            {
                return (CSTAOriginatedEvent_t)Aux.ByteArrayToStructure<CSTAOriginatedEvent_t>(heap);
            }
        }
        public CSTAQueuedEvent_t queued
        {
            get
            {
                return (CSTAQueuedEvent_t)Aux.ByteArrayToStructure<CSTAQueuedEvent_t>(heap);
            }
        }
        public CSTARetrievedEvent_t retrieved
        {
            get
            {
                return (CSTARetrievedEvent_t)Aux.ByteArrayToStructure<CSTARetrievedEvent_t>(heap);
            }
        }
        public CSTAServiceInitiatedEvent_t serviceInitiated
        {
            get
            {
                return (CSTAServiceInitiatedEvent_t)Aux.ByteArrayToStructure<CSTAServiceInitiatedEvent_t>(heap);
            }
        }
        public CSTATransferredEvent_t transferred
        {
            get
            {
                return (CSTATransferredEvent_t)Aux.ByteArrayToStructure<CSTATransferredEvent_t>(heap);
            }
        }
        public CSTACallInformationEvent_t callInformation
        {
            get
            {
                return (CSTACallInformationEvent_t)Aux.ByteArrayToStructure<CSTACallInformationEvent_t>(heap);
            }
        }
        public CSTADoNotDisturbEvent_t doNotDisturb
        {
            get
            {
                return (CSTADoNotDisturbEvent_t)Aux.ByteArrayToStructure<CSTADoNotDisturbEvent_t>(heap);
            }
        }
        public CSTAForwardingEvent_t forwarding
        {
            get
            {
                return (CSTAForwardingEvent_t)Aux.ByteArrayToStructure<CSTAForwardingEvent_t>(heap);
            }
        }
        public CSTAMessageWaitingEvent_t messageWaiting
        {
            get
            {
                return (CSTAMessageWaitingEvent_t)Aux.ByteArrayToStructure<CSTAMessageWaitingEvent_t>(heap);
            }
        }
        public CSTALoggedOnEvent_t loggedOn
        {
            get
            {
                return (CSTALoggedOnEvent_t)Aux.ByteArrayToStructure<CSTALoggedOnEvent_t>(heap);
            }
        }
        public CSTALoggedOffEvent_t loggedOff
        {
            get
            {
                return (CSTALoggedOffEvent_t)Aux.ByteArrayToStructure<CSTALoggedOffEvent_t>(heap);
            }
        }
        public CSTANotReadyEvent_t notReady
        {
            get
            {
                return (CSTANotReadyEvent_t)Aux.ByteArrayToStructure<CSTANotReadyEvent_t>(heap);
            }
        }
        public CSTAReadyEvent_t ready
        {
            get
            {
                return (CSTAReadyEvent_t)Aux.ByteArrayToStructure<CSTAReadyEvent_t>(heap);
            }
        }
        public CSTAWorkNotReadyEvent_t workNotReady
        {
            get
            {
                return (CSTAWorkNotReadyEvent_t)Aux.ByteArrayToStructure<CSTAWorkNotReadyEvent_t>(heap);
            }
        }
        public CSTAWorkReadyEvent_t workReady
        {
            get
            {
                return (CSTAWorkReadyEvent_t)Aux.ByteArrayToStructure<CSTAWorkReadyEvent_t>(heap);
            }
        }
        public CSTABackInServiceEvent_t backInService
        {
            get
            {
                return (CSTABackInServiceEvent_t)Aux.ByteArrayToStructure<CSTABackInServiceEvent_t>(heap);
            }
        }
        public CSTAOutOfServiceEvent_t outOfService
        {
            get
            {
                return (CSTAOutOfServiceEvent_t)Aux.ByteArrayToStructure<CSTAOutOfServiceEvent_t>(heap);
            }
        }
        public CSTAPrivateStatusEvent_t privateStatus
        {
            get
            {
                return (CSTAPrivateStatusEvent_t)Aux.ByteArrayToStructure<CSTAPrivateStatusEvent_t>(heap);
            }
        }
        public CSTAMonitorEndedEvent_t monitorEnded
        {
            get
            {
                return (CSTAMonitorEndedEvent_t)Aux.ByteArrayToStructure<CSTAMonitorEndedEvent_t>(heap);
            }
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
    public class CSTAConfirmationEvent
    {
        Acs.InvokeID_t invokeID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = CSTA_MAX_HEAP)]
        internal byte[] heap;
        public CSTAAlternateCallConfEvent_t alternateCall
        {
            get
            {
                return (CSTAAlternateCallConfEvent_t)Aux.ByteArrayToStructure<CSTAAlternateCallConfEvent_t>(heap);
            }
        }
        public CSTAAnswerCallConfEvent_t answerCall
        {
            get
            {
                return (CSTAAnswerCallConfEvent_t)Aux.ByteArrayToStructure<CSTAAnswerCallConfEvent_t>(heap);
            }
        }
        public CSTACallCompletionConfEvent_t callCompletion
        {
            get
            {
                return (CSTACallCompletionConfEvent_t)Aux.ByteArrayToStructure<CSTACallCompletionConfEvent_t>(heap);
            }
        }
        public CSTAClearCallConfEvent_t clearCall
        {
            get
            {
                return (CSTAClearCallConfEvent_t)Aux.ByteArrayToStructure<CSTAClearCallConfEvent_t>(heap);
            }
        }
        public CSTAClearConnectionConfEvent_t clearConnection
        {
            get
            {
                return (CSTAClearConnectionConfEvent_t)Aux.ByteArrayToStructure<CSTAClearConnectionConfEvent_t>(heap);
            }
        }
        public CSTAConferenceCallConfEvent_t conferenceCall
        {
            get
            {
                return (CSTAConferenceCallConfEvent_t)Aux.ByteArrayToStructure<CSTAConferenceCallConfEvent_t>(heap);
            }
        }
        public CSTAConsultationCallConfEvent_t consultationCall
        {
            get
            {
                return (CSTAConsultationCallConfEvent_t)Aux.ByteArrayToStructure<CSTAConsultationCallConfEvent_t>(heap);
            }
        }
        public CSTADeflectCallConfEvent_t deflectCall
        {
            get
            {
                return (CSTADeflectCallConfEvent_t)Aux.ByteArrayToStructure<CSTADeflectCallConfEvent_t>(heap);
            }
        }
        public CSTAPickupCallConfEvent_t pickupCall
        {
            get
            {
                return (CSTAPickupCallConfEvent_t)Aux.ByteArrayToStructure<CSTAPickupCallConfEvent_t>(heap);
            }
        }
        public CSTAGroupPickupCallConfEvent_t groupPickupCall
        {
            get
            {
                return (CSTAGroupPickupCallConfEvent_t)Aux.ByteArrayToStructure<CSTAGroupPickupCallConfEvent_t>(heap);
            }
        }
        public CSTAHoldCallConfEvent_t holdCall
        {
            get
            {
                return (CSTAHoldCallConfEvent_t)Aux.ByteArrayToStructure<CSTAHoldCallConfEvent_t>(heap);
            }
        }
        public CSTAMakeCallConfEvent_t makeCall
        {
            get
            {
                return (CSTAMakeCallConfEvent_t)Aux.ByteArrayToStructure<CSTAMakeCallConfEvent_t>(heap);
            }
        }
        public CSTAMakePredictiveCallConfEvent_t makePredictiveCall
        {
            get
            {
                return (CSTAMakePredictiveCallConfEvent_t)Aux.ByteArrayToStructure<CSTAMakePredictiveCallConfEvent_t>(heap);
            }
        }
        public CSTAQueryMwiConfEvent_t queryMwi
        {
            get
            {
                return (CSTAQueryMwiConfEvent_t)Aux.ByteArrayToStructure<CSTAQueryMwiConfEvent_t>(heap);
            }
        }
        public CSTAQueryDndConfEvent_t queryDnd
        {
            get
            {
                return (CSTAQueryDndConfEvent_t)Aux.ByteArrayToStructure<CSTAQueryDndConfEvent_t>(heap);
            }
        }
        public CSTAQueryFwdConfEvent_t queryFwd
        {
            get
            {
                return (CSTAQueryFwdConfEvent_t)Aux.ByteArrayToStructure<CSTAQueryFwdConfEvent_t>(heap);
            }
        }
        public CSTAQueryAgentStateConfEvent_t queryAgentState
        {
            get
            {
                return (CSTAQueryAgentStateConfEvent_t)Aux.ByteArrayToStructure<CSTAQueryAgentStateConfEvent_t>(heap);
            }
        }
        public CSTAQueryLastNumberConfEvent_t queryLastNumber
        {
            get
            {
                return (CSTAQueryLastNumberConfEvent_t)Aux.ByteArrayToStructure<CSTAQueryLastNumberConfEvent_t>(heap);
            }
        }
        public CSTAQueryDeviceInfoConfEvent_t queryDeviceInfo
        {
            get
            {
                return (CSTAQueryDeviceInfoConfEvent_t)Aux.ByteArrayToStructure<CSTAQueryDeviceInfoConfEvent_t>(heap);
            }
        }
        public CSTAReconnectCallConfEvent_t reconnectCall
        {
            get
            {
                return (CSTAReconnectCallConfEvent_t)Aux.ByteArrayToStructure<CSTAReconnectCallConfEvent_t>(heap);
            }
        }
        public CSTARetrieveCallConfEvent_t retrieveCall
        {
            get
            {
                return (CSTARetrieveCallConfEvent_t)Aux.ByteArrayToStructure<CSTARetrieveCallConfEvent_t>(heap);
            }
        }
        public CSTASetMwiConfEvent_t setMwi
        {
            get
            {
                return (CSTASetMwiConfEvent_t)Aux.ByteArrayToStructure<CSTASetMwiConfEvent_t>(heap);
            }
        }
        public CSTASetDndConfEvent_t setDnd
        {
            get
            {
                return (CSTASetDndConfEvent_t)Aux.ByteArrayToStructure<CSTASetDndConfEvent_t>(heap);
            }
        }
        public CSTASetFwdConfEvent_t setFwd
        {
            get
            {
                return (CSTASetFwdConfEvent_t)Aux.ByteArrayToStructure<CSTASetFwdConfEvent_t>(heap);
            }
        }
        public CSTASetAgentStateConfEvent_t setAgentState
        {
            get
            {
                return (CSTASetAgentStateConfEvent_t)Aux.ByteArrayToStructure<CSTASetAgentStateConfEvent_t>(heap);
            }
        }
        public CSTATransferCallConfEvent_t transferCall
        {
            get
            {
                return (CSTATransferCallConfEvent_t)Aux.ByteArrayToStructure<CSTATransferCallConfEvent_t>(heap);
            }
        }
        public CSTAUniversalFailureConfEvent_t universalFailure
        {
            get
            {
                return (CSTAUniversalFailureConfEvent_t)Aux.ByteArrayToStructure<CSTAUniversalFailureConfEvent_t>(heap);
            }
        }
        public CSTAMonitorConfEvent_t monitorStart
        {
            get
            {
                return (CSTAMonitorConfEvent_t)Aux.ByteArrayToStructure<CSTAMonitorConfEvent_t>(heap);
            }
        }
        public CSTAChangeMonitorFilterConfEvent_t changeMonitorFilter
        {
            get
            {
                return (CSTAChangeMonitorFilterConfEvent_t)Aux.ByteArrayToStructure<CSTAChangeMonitorFilterConfEvent_t>(heap);
            }
        }
        public CSTAMonitorStopConfEvent_t monitorStop
        {
            get
            {
                return (CSTAMonitorStopConfEvent_t)Aux.ByteArrayToStructure<CSTAMonitorStopConfEvent_t>(heap);
            }
        }
        public CSTASnapshotDeviceConfEvent_t snapshotDevice;
        public CSTASnapshotCallConfEvent_t snapshotCall;
        public CSTARouteRegisterReqConfEvent_t routeRegister
        {
            get
            {
                return (CSTARouteRegisterReqConfEvent_t)Aux.ByteArrayToStructure<CSTARouteRegisterReqConfEvent_t>(heap);
            }
        }
        public CSTARouteRegisterCancelConfEvent_t routeCancel
        {
            get
            {
                return (CSTARouteRegisterCancelConfEvent_t)Aux.ByteArrayToStructure<CSTARouteRegisterCancelConfEvent_t>(heap);
            }
        }
        public CSTAEscapeSvcConfEvent_t escapeService
        {
            get
            {
                return (CSTAEscapeSvcConfEvent_t)Aux.ByteArrayToStructure<CSTAEscapeSvcConfEvent_t>(heap);
            }
        }
        public CSTASysStatReqConfEvent_t sysStatReq
        {
            get
            {
                return (CSTASysStatReqConfEvent_t)Aux.ByteArrayToStructure<CSTASysStatReqConfEvent_t>(heap);
            }
        }
        public CSTASysStatStartConfEvent_t sysStatStart
        {
            get
            {
                return (CSTASysStatStartConfEvent_t)Aux.ByteArrayToStructure<CSTASysStatStartConfEvent_t>(heap);
            }
        }
        public CSTASysStatStopConfEvent_t sysStatStop
        {
            get
            {
                return (CSTASysStatStopConfEvent_t)Aux.ByteArrayToStructure<CSTASysStatStopConfEvent_t>(heap);
            }
        }
        public CSTAChangeSysStatFilterConfEvent_t changeSysStatFilter
        {
            get
            {
                return (CSTAChangeSysStatFilterConfEvent_t)Aux.ByteArrayToStructure<CSTAChangeSysStatFilterConfEvent_t>(heap);
            }
        }
        public CSTAGetAPICapsConfEvent_t getAPICaps
        {
            get
            {
                return (CSTAGetAPICapsConfEvent_t)Aux.ByteArrayToStructure<CSTAGetAPICapsConfEvent_t>(heap);
            }
        }
        public CSTAGetDeviceListConfEvent_t getDeviceList
        {
            get
            {
                return (CSTAGetDeviceListConfEvent_t)Aux.ByteArrayToStructure<CSTAGetDeviceListConfEvent_t>(heap);
            }
        }
        public CSTAQueryCallMonitorConfEvent_t queryCallMonitor
        {
            get
            {
                return (CSTAQueryCallMonitorConfEvent_t)Aux.ByteArrayToStructure<CSTAQueryCallMonitorConfEvent_t>(heap);
            }
        }
    };

    public const int CSTA_MAX_HEAP = 2048;

    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class EventBuffer_t : ICustomMarshaler
    {
        public CSTAEvent_t evt;
        public Dictionary<string, object> auxData;

        public EventBuffer_t()
        {
            this.evt = new CSTAEvent_t();
            this.auxData = new Dictionary<string, object>();
        }

        //Custom marshaller
        [ThreadStatic]
        private Csta.EventBuffer_t marshaledObj;
        private static Csta.EventBuffer_t instance = null;
        public static ICustomMarshaler GetInstance(string cookie)
        {
            if (instance == null)
            {
                instance = new EventBuffer_t();
            }
            return instance;
        }

        public int GetNativeDataSize()
        {
            int size = Marshal.SizeOf(typeof(Csta.CSTAEvent_t)); 
            //return Marshal.SizeOf(typeof(Csta.CSTAEvent_t));
            return size;
        }

        public object MarshalNativeToManaged(System.IntPtr pNativeData)
        {
            Marshal.PtrToStructure(pNativeData, this.marshaledObj.evt);

            if (this.marshaledObj.evt.eventHeader.eventClass.eventClass == Csta.CSTACONFIRMATION)
            {
                this.marshaledObj.evt.cstaConfirmation = (CSTAConfirmationEvent)Aux.ByteArrayToStructure<CSTAConfirmationEvent>(this.marshaledObj.evt.heap);
            }

            // Marshal SnapShotCall Event
            if (this.marshaledObj.evt.eventHeader.eventClass.eventClass == Csta.CSTACONFIRMATION &&
                this.marshaledObj.evt.eventHeader.eventType.eventType == Csta.CSTA_SNAPSHOT_CALL_CONF)
            {
                this.marshaledObj.evt.cstaConfirmation.snapshotCall = (Csta.CSTASnapshotCallConfEvent_t)Aux.ByteArrayToStructure<Csta.CSTASnapshotCallConfEvent_t>(this.marshaledObj.evt.cstaConfirmation.heap);
                int infoCount = this.marshaledObj.evt.cstaConfirmation.snapshotCall.snapshotData.count;
                IntPtr pInfo = this.marshaledObj.evt.cstaConfirmation.snapshotCall.snapshotData.pInfo;
                Csta.CSTASnapshotCallResponseInfo_t[] infoArray = new CSTASnapshotCallResponseInfo_t[infoCount];
                int infoSize = Marshal.SizeOf(new CSTASnapshotCallResponseInfo_t());
                for (int i = 0; i < infoCount; i++)
                {
                    infoArray[i] = (CSTASnapshotCallResponseInfo_t)Marshal.PtrToStructure(new IntPtr(pInfo.ToInt32() + infoSize * i), typeof(CSTASnapshotCallResponseInfo_t));
                }
                this.marshaledObj.auxData.Add("snapCallInfo", infoArray);
            }

            // Marshal SnapShotDevice Event
            if (this.marshaledObj.evt.eventHeader.eventClass.eventClass == Csta.CSTACONFIRMATION &&
                this.marshaledObj.evt.eventHeader.eventType.eventType == Csta.CSTA_SNAPSHOT_DEVICE_CONF)
            {
                this.marshaledObj.evt.cstaConfirmation.snapshotDevice = (CSTASnapshotDeviceConfEvent_t)Aux.ByteArrayToStructure<CSTASnapshotDeviceConfEvent_t>(this.marshaledObj.evt.cstaConfirmation.heap);
                int infoCount = this.marshaledObj.evt.cstaConfirmation.snapshotDevice.snapshotData.count;
                IntPtr pInfo = this.marshaledObj.evt.cstaConfirmation.snapshotDevice.snapshotData.pInfo;
                Csta.CSTASnapshotDeviceResponseInfo_t[] infoArray = new CSTASnapshotDeviceResponseInfo_t[infoCount];
                int infoSize = Marshal.SizeOf(new CSTASnapshotDeviceResponseInfo_t());
                for (int i = 0; i < infoCount; i++)
                {
                    infoArray[i] = (CSTASnapshotDeviceResponseInfo_t)Marshal.PtrToStructure(new IntPtr(pInfo.ToInt32() + infoSize * i), typeof(CSTASnapshotDeviceResponseInfo_t));
                    int stateCount = infoArray[i].localCallState.count;
                    IntPtr pState = infoArray[i].localCallState.pState;
                    LocalConnectionState_t[] stateArray = new LocalConnectionState_t[stateCount];
                    for (int j = 0; j < stateCount; j++)
                    {
                        stateArray[j] = (LocalConnectionState_t)Marshal.ReadInt32(pState, (sizeof(int) * j));
                    }
                    this.marshaledObj.auxData.Add("snapDeviceState" + i, stateArray);
                }
                this.marshaledObj.auxData.Add("snapDeviceInfo", infoArray);
            }
            return this.marshaledObj;
        }

        public System.IntPtr MarshalManagedToNative(object managedObj)
        {
            if (!(managedObj is Csta.EventBuffer_t))
            {
                throw new ArgumentException("Specified object is not a Csta.EventBuffer_t object.", "managedObj");
            }
            else
            {
                this.marshaledObj = (Csta.EventBuffer_t)managedObj;
            }

            IntPtr ptr = Marshal.AllocHGlobal(this.GetNativeDataSize());
            if (ptr == IntPtr.Zero)
            {
                throw new Exception("Unable to allocate memory to.");
            }
            // We need to pass only CSTAEvent_t part
            Marshal.StructureToPtr(this.marshaledObj.evt, ptr, false);

            return ptr;
        }

        public void CleanUpManagedData(object managedObj)
        {
        }

        public void CleanUpNativeData(System.IntPtr pNativeData)
        {
            Marshal.FreeHGlobal(pNativeData);
        }
    };

    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class CSTAEvent_t
    {
        public Acs.ACSEventHeader_t eventHeader; // 8 bytes
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = CSTA_MAX_HEAP)]
        internal byte[] heap;

        public Acs.ACSUnsolicitedEvent acsUnsolicited
        {
            get
            {
                return (Acs.ACSUnsolicitedEvent)Aux.ByteArrayToStructure<Acs.ACSUnsolicitedEvent>(heap);
            }
        }
        public Acs.ACSConfirmationEvent acsConfirmation
        {
            get
            {
                return (Acs.ACSConfirmationEvent)Aux.ByteArrayToStructure<Acs.ACSConfirmationEvent>(heap);
            }
        }
        public CSTARequestEvent cstaRequest
        {
            get
            {
                return (CSTARequestEvent)Aux.ByteArrayToStructure<CSTARequestEvent>(heap);
            }
        }
        public CSTAUnsolicitedEvent cstaUnsolicited
        {
            get
            {
                return (CSTAUnsolicitedEvent)Aux.ByteArrayToStructure<CSTAUnsolicitedEvent>(heap);
            }
        }
        public CSTAConfirmationEvent cstaConfirmation;
        public CSTAEventReport cstaEventReport
        {
            get
            {
                return (CSTAEventReport)Aux.ByteArrayToStructure<CSTAEventReport>(heap);
            }
        }
    };

    [DllImport("csta32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t cstaAlternateCall(
                        Acs.ACSHandle_t acsHandle,
                        Acs.InvokeID_t invokeID,
                        Csta.ConnectionID_t activeCall,
                        Csta.ConnectionID_t otherCall,
                        Acs.PrivateData_t privateData);   

    [DllImport("csta32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t cstaAnswerCall(
                        Acs.ACSHandle_t acsHandle,
                        Acs.InvokeID_t activeCall,
                        Csta.ConnectionID_t alertingCall,
                        Acs.PrivateData_t privateData);   

    [DllImport("csta32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t cstaCallCompletion(
                        Acs.ACSHandle_t acsHandle,
                        Acs.InvokeID_t activeCall,
                        Feature_t feature,
                        Csta.ConnectionID_t call,
                        Acs.PrivateData_t privateData);  

    [DllImport("csta32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t cstaClearCall(
                        Acs.ACSHandle_t acsHandle,
                        Acs.InvokeID_t invokeID,
                        Csta.ConnectionID_t call,
                        Acs.PrivateData_t privateData);  

    [DllImport("csta32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t cstaClearConnection(
                        Acs.ACSHandle_t acsHandle,
                        Acs.InvokeID_t invokeID,
                        Csta.ConnectionID_t call,
                        Acs.PrivateData_t privateData);  

    [DllImport("csta32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t cstaConferenceCall(
                        Acs.ACSHandle_t acsHandle,
                        Acs.InvokeID_t invokeID,
                        Csta.ConnectionID_t heldCall,
                        Csta.ConnectionID_t activeCall,
                        Acs.PrivateData_t privateData);  

    [DllImport("csta32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t cstaConsultationCall(
                        Acs.ACSHandle_t acsHandle,
                        Acs.InvokeID_t invokeID,
                        Csta.ConnectionID_t activeCall,
                        [In, Out] DeviceID_t calledDevice,
                        Acs.PrivateData_t privateData); 

    [DllImport("csta32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t cstaDeflectCall(
                        Acs.ACSHandle_t acsHandle,
                        Acs.InvokeID_t invokeID,
                        Csta.ConnectionID_t deflectCall,
                        [In, Out] DeviceID_t calledDevice,
                        Acs.PrivateData_t privateData);

    [DllImport("csta32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t cstaGroupPickupCall(
                        Acs.ACSHandle_t acsHandle,
                        Acs.InvokeID_t invokeID,
                        Csta.ConnectionID_t deflectCall,
                        [In, Out] DeviceID_t pickupDevice,
                        Acs.PrivateData_t privateData);

    [DllImport("csta32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t cstaHoldCall(
                        Acs.ACSHandle_t acsHandle,
                        Acs.InvokeID_t invokeID,
                        Csta.ConnectionID_t activeCall,
                        bool reservation,
                        Acs.PrivateData_t privateData);

    [DllImport("csta32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t cstaMakeCall(
                        Acs.ACSHandle_t acsHandle,
                        Acs.InvokeID_t invokeID,
                        [In, Out] DeviceID_t callingDevice,
                        [In, Out] DeviceID_t calledDevice,
                        Acs.PrivateData_t privateData);

    [DllImport("csta32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t cstaMakePredictiveCall(
                        Acs.ACSHandle_t acsHandle,
                        Acs.InvokeID_t invokeID,
                        [In, Out] DeviceID_t callingDevice,
                        [In, Out] DeviceID_t calledDevice,
                        Csta.AllocationState_t allocationState,
                        Acs.PrivateData_t privateData);

    [DllImport("csta32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t cstaPickupCall(
                        Acs.ACSHandle_t acsHandle,
                        Acs.InvokeID_t invokeID,
                        Csta.ConnectionID_t deflectCall,
                        [In, Out] DeviceID_t calledDevice,
                        Acs.PrivateData_t privateData);

    [DllImport("csta32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t cstaReconnectCall(
                        Acs.ACSHandle_t acsHandle,
                        Acs.InvokeID_t invokeID,
                        Csta.ConnectionID_t activeCall,
                        Csta.ConnectionID_t heldCall,
                        Acs.PrivateData_t privateData);

    [DllImport("csta32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t cstaRetrieveCall(
                        Acs.ACSHandle_t acsHandle,
                        Acs.InvokeID_t invokeID,
                        Csta.ConnectionID_t heldCall,
                        Acs.PrivateData_t privateData);

    [DllImport("csta32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t cstaTransferCall(
                        Acs.ACSHandle_t acsHandle,
                        Acs.InvokeID_t invokeID,
                        Csta.ConnectionID_t heldCall,
                        Csta.ConnectionID_t activeCall,
                        Acs.PrivateData_t privateData);

    // Telephony Supplementary Services 
    [DllImport("csta32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t cstaSetMsgWaitingInd(
                        Acs.ACSHandle_t acsHandle,
                        Acs.InvokeID_t invokeID,
                        [In, Out] DeviceID_t device,
                        bool messages,
                        Acs.PrivateData_t privateData);

    [DllImport("csta32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t cstaSetDoNotDisturb(
                        Acs.ACSHandle_t acsHandle,
                        Acs.InvokeID_t invokeID,
                        [In, Out] DeviceID_t device,
                        bool doNotDisturb,
                        Acs.PrivateData_t privateData);

    [DllImport("csta32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t cstaSetForwarding(
                        Acs.ACSHandle_t acsHandle,
                        Acs.InvokeID_t invokeID,
                        [In, Out] DeviceID_t device,
                        ForwardingType_t forwardingType,
                        bool forwardingOn,
                        [In, Out] DeviceID_t forwardingDestination,
                        Acs.PrivateData_t privateData);

    [DllImport("csta32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t cstaSetAgentState(
                        Acs.ACSHandle_t acsHandle,
                        Acs.InvokeID_t invokeID,
                        [In, Out] DeviceID_t device,
                        AgentMode_t agentMode,
                        AgentID_t agentID,
                        AgentGroup_t agentGroup,
                        AgentPassword_t agentPassword,
                        Acs.PrivateData_t privateData);

    [DllImport("csta32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t cstaQueryMsgWaitingInd(
                        Acs.ACSHandle_t acsHandle,
                        Acs.InvokeID_t invokeID,
                        [In, Out] DeviceID_t device,
                        Acs.PrivateData_t privateData);

    [DllImport("csta32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t cstaQueryDoNotDisturb(
                        Acs.ACSHandle_t acsHandle,
                        Acs.InvokeID_t invokeID,
                        [In, Out] DeviceID_t device,
                        Acs.PrivateData_t privateData);

    [DllImport("csta32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t cstaQueryForwarding(
                        Acs.ACSHandle_t acsHandle,
                        Acs.InvokeID_t invokeID,
                        [In, Out] DeviceID_t device,
                        Acs.PrivateData_t privateData);

    [DllImport("csta32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t cstaQueryAgentState(
                        Acs.ACSHandle_t acsHandle,
                        Acs.InvokeID_t invokeID,
                        [In, Out] DeviceID_t device,
                        Acs.PrivateData_t privateData);

    [DllImport("csta32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t cstaQueryLastNumber(
                        Acs.ACSHandle_t acsHandle,
                        Acs.InvokeID_t invokeID,
                        [In, Out] DeviceID_t device,
                        Acs.PrivateData_t privateData);

    [DllImport("csta32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t cstaQueryDeviceInfo(
                        Acs.ACSHandle_t acsHandle,
                        Acs.InvokeID_t invokeID,
                        [In, Out] DeviceID_t device,
                        Acs.PrivateData_t privateData);

    // Monitor Services 
    [DllImport("csta32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t cstaMonitorDevice(
                        Acs.ACSHandle_t acsHandle,
                        Acs.InvokeID_t invokeID,
                        [In, Out] DeviceID_t deviceID,
                        ref CSTAMonitorFilter_t monitorFilter,
                        Acs.PrivateData_t privateData);

    [DllImport("csta32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t cstaMonitorCall(
                        Acs.ACSHandle_t acsHandle,
                        Acs.InvokeID_t invokeID,
                        Csta.ConnectionID_t call,
                        ref CSTAMonitorFilter_t monitorFilter,
                        Acs.PrivateData_t privateData);

    [DllImport("csta32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t cstaMonitorCallsViaDevice(
                        Acs.ACSHandle_t acsHandle,
                        Acs.InvokeID_t invokeID,
                        [In, Out] DeviceID_t deviceID,
                        ref CSTAMonitorFilter_t monitorFilter,
                        Acs.PrivateData_t privateData);

    [DllImport("csta32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t cstaChangeMonitorFilter(
                        Acs.ACSHandle_t acsHandle,
                        Acs.InvokeID_t invokeID,
                        CSTAMonitorCrossRefID_t monitorCrossRefID,
                        ref CSTAMonitorFilter_t filterlist,
                        Acs.PrivateData_t privateData);

    [DllImport("csta32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t cstaChangeMonitorFilter(
                        Acs.ACSHandle_t acsHandle,
                        Acs.InvokeID_t invokeID,
                        CSTAMonitorCrossRefID_t monitorCrossRefID,
                        Acs.PrivateData_t privateData);

    // Snapshot Services 
    [DllImport("csta32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t cstaSnapshotCallReq(
                        Acs.ACSHandle_t acsHandle,
                        Acs.InvokeID_t invokeID,
                        ConnectionID_t snapshotObj,
                        Acs.PrivateData_t privateData);

    [DllImport("csta32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t cstaSnapshotDeviceReq(
                        Acs.ACSHandle_t acsHandle,
                        Acs.InvokeID_t invokeID,
                        [In, Out] DeviceID_t snapshotObj,
                        Acs.PrivateData_t privateData);

    // Routing Services 
    [DllImport("csta32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t cstaRouteRegisterReq(
                        Acs.ACSHandle_t acsHandle,
                        Acs.InvokeID_t invokeID,
                        [In, Out] DeviceID_t routingDevice,
                        Acs.PrivateData_t privateData);
    [DllImport("csta32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t cstaRouteRegisterCancel(
                        Acs.ACSHandle_t acsHandle,
                        Acs.InvokeID_t invokeID,
                        RouteRegisterReqID_t routeRegisterReqID,
                        Acs.PrivateData_t privateData);

    // Release 1 calls, w/o invokeID, for backward compatibility 
    [DllImport("csta32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t cstaRouteSelect(
                        Acs.ACSHandle_t acsHandle,
                        RouteRegisterReqID_t routeRegisterReqID,
                        RoutingCrossRefID_t routingCrossRefID,
                        [In, Out] DeviceID_t routeSelected,
                        RetryValue_t remainRetry,
                        ref SetUpValues_t setupInformation,
                        bool routeUsedReq,
                        Acs.PrivateData_t privateData);

    [DllImport("csta32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t cstaRouteEnd(
                        Acs.ACSHandle_t acsHandle,
                        RouteRegisterReqID_t routeRegisterReqID,
                        RoutingCrossRefID_t routingCrossRefID,
                        CSTAUniversalFailure_t errorValue,
                        Acs.PrivateData_t privateData);

    // Release 2 calls, with invokeID 
    [DllImport("csta32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t cstaRouteSelectInv(
                        Acs.ACSHandle_t acsHandle,
                        Acs.InvokeID_t invokeID,
                        RouteRegisterReqID_t routeRegisterReqID,
                        RoutingCrossRefID_t routingCrossRefID,
                        [In, Out] DeviceID_t routeSelected,
                        RetryValue_t remainRetry,
                        ref SetUpValues_t setupInformation,
                        bool routeUsedReq,
                        Acs.PrivateData_t privateData);
 
    [DllImport("csta32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t cstaRouteEndInv(
                        Acs.ACSHandle_t acsHandle,
                        Acs.InvokeID_t invokeID,
                        RouteRegisterReqID_t routeRegisterReqID,
                        RoutingCrossRefID_t routingCrossRefID,
                        CSTAUniversalFailure_t errorValue,
                        Acs.PrivateData_t privateData);

    // Escape Services 
    [DllImport("csta32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t cstaEscapeService(
                        Acs.ACSHandle_t acsHandle,
                        Acs.InvokeID_t invokeID,
                        Acs.PrivateData_t privateData);

    [DllImport("csta32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t cstaEscapeServiceConf(
                        Acs.ACSHandle_t acsHandle,
                        Acs.InvokeID_t invokeID,
                        CSTAUniversalFailure_t error,
                        Acs.PrivateData_t privateData);

    [DllImport("csta32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t cstaSendPrivateEvent(
                        Acs.ACSHandle_t acsHandle,
                        Acs.PrivateData_t privateData);

    // Maintenance Services 
    [DllImport("csta32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t cstaSysStatReq(
                        Acs.ACSHandle_t acsHandle,
                        Acs.InvokeID_t invokeID,
                        Acs.PrivateData_t privateData);

    [DllImport("csta32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t cstaSysStatStart(
                        Acs.ACSHandle_t acsHandle,
                        Acs.InvokeID_t invokeID,
                        SystemStatusFilter_t statusFilter,
                        Acs.PrivateData_t privateData);

    [DllImport("csta32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t cstaSysStatStop(
                        Acs.ACSHandle_t acsHandle,
                        Acs.InvokeID_t invokeID,
                        Acs.PrivateData_t privateData);

    [DllImport("csta32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t cstaChangeSysStatFilter(
                        Acs.ACSHandle_t acsHandle,
                        Acs.InvokeID_t invokeID,
                        SystemStatusFilter_t statusFilter,
                        Acs.PrivateData_t privateData);


    [DllImport("csta32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t cstaSysStatReqConf(
                        Acs.ACSHandle_t acsHandle,
                        Acs.InvokeID_t invokeID,
                        SystemStatus_t systemStatus,
                        Acs.PrivateData_t privateData);

    [DllImport("csta32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t cstaSysStatEvent(
                        Acs.ACSHandle_t acsHandle,
                        SystemStatus_t systemStatus,
                        Acs.PrivateData_t privateData);

    [DllImport("csta32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t cstaGetAPICaps(
                        Acs.ACSHandle_t acsHandle,
                        Acs.InvokeID_t invokeID);

    [DllImport("csta32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t cstaGetDeviceList(
                        Acs.ACSHandle_t acsHandle,
                        Acs.InvokeID_t invokeID,
                        int index,
                        CSTALevel_t level);

    [DllImport("csta32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t cstaQueryCallMonitor(
                        Acs.ACSHandle_t acsHandle,
                        Acs.InvokeID_t invokeID);









    public static Csta.EventBuffer_t clearCall(Acs.ACSHandle_t acsHandle, Csta.ConnectionID_t cId)
    {
        Csta.EventBuffer_t evtBuf = new Csta.EventBuffer_t();
        Acs.InvokeID_t invokeId = new Acs.InvokeID_t();
        Acs.RetCode_t retCode = Csta.cstaClearCall(acsHandle,
                                             invokeId,
                                             cId,
                                             null);
        if (retCode._value < 0)
        {
            System.Windows.Forms.MessageBox.Show("cstaClearCall error: " + retCode);
            return null;
        }
        ushort eventBufSize = Csta.CSTA_MAX_HEAP;
        ushort numEvents;
        retCode = Acs.acsGetEventBlock(acsHandle,
                                      evtBuf,
                                      ref eventBufSize,
                                      null,
                                      out numEvents);
        if (retCode._value < 0)
        {
            System.Windows.Forms.MessageBox.Show("acsGetEventBlock error: " + retCode);
            return null;
        }
        if (evtBuf.evt.eventHeader.eventClass.eventClass != Csta.CSTACONFIRMATION ||
            evtBuf.evt.eventHeader.eventType.eventType != Csta.CSTA_CLEAR_CALL_CONF)
        {
            if (evtBuf.evt.eventHeader.eventClass.eventClass == Csta.CSTACONFIRMATION
                && evtBuf.evt.eventHeader.eventType.eventType == Csta.CSTA_UNIVERSAL_FAILURE_CONF)
            {
                System.Windows.Forms.MessageBox.Show("Clear call failed. Error: " + evtBuf.evt.cstaConfirmation.universalFailure.error);
            }
        }
        return evtBuf;
    }




    }
}
