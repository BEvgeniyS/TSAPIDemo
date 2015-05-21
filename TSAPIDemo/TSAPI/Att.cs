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
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace Tsapi
{
using ATTPrivateData_t = Acs.PrivateData_t;
public static partial class Att
{

    public const int ATT_MAX_PRIVATE_DATA = 2048;
    public const int ATTPRIV_MAX_HEAP = 64;
    public const int ATT_MAX_USER_INFO = 129;
    public const int ATT_MAX_UUI_SIZE = 96;
    public const int ATTV5_MAX_UUI_SIZE = 32;

    //Additional stuff
    public enum ATTServiceState_t
    {
        SS_UNKNOWN = -1,
        SS_OUT_OF_SERVICE = 0,
        SS_IN_SERVICE = 1
    }

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct ATTQueryEndpointRegistrationInfoConfEvent_t
        {
            public Csta.DeviceID_t device;
            public ATTServiceState_t serviceState;
            public ATTRegisteredEndpointList_t registeredEndpoints;
        }

        enum ATTSignalingProtocol_t
    {
        SP_NOT_PROVIDED = -1,
        SP_H323 = 1,
        SP_SIP = 2
    };

    [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
    public struct ATTStationType_t
    {
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string _value;
    }

    public const uint US_NONE = 0x00000000;
    public const uint US_BASIC_LATIN= 0x00000001;
    public const uint US_LATIN_1_SUPPLEMENT = 0x00000002;
    public const uint US_LATIN_EXTENDED_A = 0x00000004;
    public const uint US_LATIN_EXTENDED_B = 0x00000008;
    public const uint US_GREEK_COPTIC = 0x00000010;
    public const uint US_CYRILLIC = 0x00000020;
    public const uint US_ARMENIAN = 0x00000040;
    public const uint US_HEBREW = 0x00000080;
    public const uint US_ARABIC = 0x00000100;
    public const uint US_DEVANAGARI = 0x00000200;
    public const uint US_BENGALI = 0x00000400;
    public const uint US_GURMUKHI = 0x00000800;
    public const uint US_GUJARATI = 0x00001000;
    public const uint US_ORIYA = 0x00002000;
    public const uint US_TAMIL = 0x00004000;
    public const uint US_TELUGU = 0x00008000;
    public const uint US_KANNADA = 0x00010000;
    public const uint US_MALAYALAM = 0x00020000;
    public const uint US_SINHALA = 0x00040000;
    public const uint US_THAI = 0x00080000;
    public const uint US_LAO = 0x00100000;
    public const uint US_MYANMAR = 0x00200000;
    public const uint US_GEORGIAN = 0x00400000;
    public const uint US_TAGALOG = 0x00800000;
    public const uint US_KHMER = 0x01000000;
    public const uint US_HALF_WIDTH_AND_FULL_WIDTH_KANA = 0x02000000;
    public const uint US_CJK_RADICALS_SUPPLEMENT_JAPAN = 0x04000000;
    public const uint US_CJK_RADICALS_SUPPLEMENT_CHINA_S = 0x08000000;
    public const uint US_CJK_RADICALS_SUPPLEMENT_CHINA_T = 0x10000000;
    public const uint US_CJK_RADICALS_SUPPLEMENT_KOREAN = 0x20000000;
    public const uint US_CJK_RADICALS_SUPPLEMENT_VIETNAM = 0x40000000;
    public const uint US_HANGUL_JAMO = 0x80000000;

    [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
    public struct ATTUnicodeScript_t
    {
        public uint _value;
    }

        public enum ATTDependencyMode_t
    {
        DM_OTHER = -1,
        DM_MAIN = 1,
        DM_DEPENDENT = 2,
        DM_INDEPENDENT = 3
    }

    public enum ATTMediaMode_t
    {
        MM_OTHER = -1,
        MM_NONE = 0,
        MM_CLIENT_SERVER = 1,
        MM_TELECOMMUTER = 2
    }

    [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
    public struct ATTProductID_t
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string _value;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
    public struct ATTMACAddress_t
        {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 18)]
        public string _value;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
    public struct ATTIPAddress_t
        {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 46)]
        public string _value;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
    public struct ATTEndpointAddress_t
        {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string _value;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
    public struct ATTEndpointInstanceID_t
    {
        public short _value;
    }

    public struct ATTRegisteredEndpointInfo_t
    {
        ATTEndpointInstanceID_t instanceID;
        ATTEndpointAddress_t endpointAddress;
        ATTIPAddress_t switchEndIpAddress;
        ATTMACAddress_t macAddress;
        ATTProductID_t productID;
        short networkRegion;
        ATTMediaMode_t mediaMode;
        ATTDependencyMode_t dependencyMode;
        ATTUnicodeScript_t unicodeScript;
        ATTStationType_t stationType;
        ATTSignalingProtocol_t signalingProtocol;
    }

        // TODO: Custom marshal pEndpoint array
        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct ATTRegisteredEndpointList_t
        {
            uint count;
            IntPtr pEndpoint; // ATTRegisteredEndpointInfo_t* endpoint;
        }


    [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
    public struct ATTEventType_t
    {
        internal int eventType;

        public ATTEventType_t(ushort value)
        {
            eventType = value;
        }

        public static implicit operator ATTEventType_t(ushort value)
        {
            return new ATTEventType_t(value);
        }

        public override string ToString()
        {
            return eventType.ToString();
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
    public class ATTEvent_t
    {
        public ATTEventType_t eventType;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Att.ATT_MAX_PRIVATE_DATA)]
        private byte[] heap;

        // private version 9
        public ATTSingleStepTransferCallConfEvent_t v8ssTransferCallConf
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTSingleStepTransferCallConfEvent_t>(heap);
            }
        }


        // private version 8
        public ATTV8SingleStepTransferCallConfEvent_t ssTransferCallConf
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTV8SingleStepTransferCallConfEvent_t>(heap);
            }
        }


        // private version 6 
        public ATTSingleStepConferenceCallConfEvent_t ssconference
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTSingleStepConferenceCallConfEvent_t>(heap);
            }
        }
        ATTSelectiveListeningHoldConfEvent_t slhold
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTSelectiveListeningHoldConfEvent_t>(heap);
            }
        }
        ATTSelectiveListeningRetrieveConfEvent_t slretrieve
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTSelectiveListeningRetrieveConfEvent_t>(heap);
            }
        }
        ATTSendDTMFToneConfEvent_t sendDTMFTone
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTSendDTMFToneConfEvent_t>(heap);
            }
        }
        internal ATTQueryAcdSplitConfEvent_t queryAcdSplit
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTQueryAcdSplitConfEvent_t>(heap);
            }
        }
        internal ATTQueryAgentLoginConfEvent_t queryAgentLogin
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTQueryAgentLoginConfEvent_t>(heap);
            }
        }
        internal ATTQueryAgentLoginResp_t queryAgentLoginResp
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTQueryAgentLoginResp_t>(heap);
            }
        }
        public ATTQueryAgentStateConfEvent_t queryAgentState
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTQueryAgentStateConfEvent_t>(heap);
            }
        }
        public ATTQueryCallClassifierConfEvent_t queryCallClassifier
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTQueryCallClassifierConfEvent_t>(heap);
            }
        }
        public ATTQueryDeviceInfoConfEvent_t queryDeviceInfo
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTQueryDeviceInfoConfEvent_t>(heap);
            }
        }
        public ATTQueryDeviceNameConfEvent_t queryDeviceName
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTQueryDeviceNameConfEvent_t>(heap);
            }
        }
        public ATTQueryMwiConfEvent_t queryMwi
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTQueryMwiConfEvent_t>(heap);
            }
        }
        public ATTQueryStationStatusConfEvent_t queryStationStatus
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTQueryStationStatusConfEvent_t>(heap);
            }
        }
        public ATTV9QueryStationStatusConfEvent_t queryStationStatusv9
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTV9QueryStationStatusConfEvent_t>(heap);
            }
        }
        public ATTQueryTodConfEvent_t queryTod
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTQueryTodConfEvent_t>(heap);
            }
        }
        public ATTQueryTgConfEvent_t queryTg
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTQueryTgConfEvent_t>(heap);
            }
        }
        ATTQueryAgentMeasurementsConfEvent_t queryAgentMeas
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTQueryAgentMeasurementsConfEvent_t>(heap);
            }
        }
        ATTQuerySplitSkillMeasurementsConfEvent_t querySplitSkillMeas
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTQuerySplitSkillMeasurementsConfEvent_t>(heap);
            }
        }
        ATTQueryTrunkGroupMeasurementsConfEvent_t queryTrunkGroupMeas
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTQueryTrunkGroupMeasurementsConfEvent_t>(heap);
            }
        }
        ATTQueryVdnMeasurementsConfEvent_t queryVdnMeas
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTQueryVdnMeasurementsConfEvent_t>(heap);
            }
        }
        ATTSnapshotDeviceConfEvent_t snapshotDevice
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTSnapshotDeviceConfEvent_t>(heap);
            }
        }
        ATTMonitorConfEvent_t monitorStart
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTMonitorConfEvent_t>(heap);
            }
        }
        ATTMonitorCallConfEvent_t monitorCallStart
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTMonitorCallConfEvent_t>(heap);
            }
        }
        ATTMonitorStopOnCallConfEvent_t monitorStopOnCall
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTMonitorStopOnCallConfEvent_t>(heap);
            }
        }
        ATTCallClearedEvent_t callClearedEvent
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTCallClearedEvent_t>(heap);
            }
        }
        ATTConferencedEvent_t conferencedEvent
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTConferencedEvent_t>(heap);
            }
        }
        ATTConnectionClearedEvent_t connectionClearedEvent
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTConnectionClearedEvent_t>(heap);
            }
        }
        ATTDeliveredEvent_t deliveredEvent
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTDeliveredEvent_t>(heap);
            }
        }
        ATTEnteredDigitsEvent_t enteredDigitsEvent
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTEnteredDigitsEvent_t>(heap);
            }
        }
        ATTEstablishedEvent_t establishedEvent
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTEstablishedEvent_t>(heap);
            }
        }
        ATTLoggedOnEvent_t loggedOnEvent
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTLoggedOnEvent_t>(heap);
            }
        }
        ATTNetworkReachedEvent_t networkReachedEvent
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTNetworkReachedEvent_t>(heap);
            }
        }
        ATTOriginatedEvent_t originatedEvent
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTOriginatedEvent_t>(heap);
            }
        }
        ATTTransferredEvent_t transferredEvent
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTTransferredEvent_t>(heap);
            }
        }
        ATTRouteRequestEvent_t routeRequest
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTRouteRequestEvent_t>(heap);
            }
        }
        ATTRouteUsedEvent_t routeUsed
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTRouteUsedEvent_t>(heap);
            }
        }
        ATTLinkStatusEvent_t linkStatus
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTLinkStatusEvent_t>(heap);
            }
        }
        public ATTGetAPICapsConfEvent_t getAPICaps
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTGetAPICapsConfEvent_t>(heap);
            }
        }

        public ATTV10GetAPICapsConfEvent_t attV10GetApiCaps
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTV10GetAPICapsConfEvent_t>(heap);
            }
        }
        ATTServiceInitiatedEvent_t serviceInitiated
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTServiceInitiatedEvent_t>(heap);
            }
        }
        ATTChargeAdviceEvent_t chargeAdviceEvent
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTChargeAdviceEvent_t>(heap);
            }
        }
        ATTSetBillRateConfEvent_t setBillRate
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTSetBillRateConfEvent_t>(heap);
            }
        }

        public ATTQueryUcidConfEvent_t queryUCID
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTQueryUcidConfEvent_t>(heap);
            }
        }

        ATTLoggedOffEvent_t loggedOffEvent
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTLoggedOffEvent_t>(heap);
            }
        }

        internal ATTConsultationCallConfEvent_t consultationCall
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTConsultationCallConfEvent_t>(heap);
            }
        }

        internal ATTConferenceCallConfEvent_t conferenceCall
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTConferenceCallConfEvent_t>(heap);
            }
        }

        internal ATTMakeCallConfEvent_t makeCall
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTMakeCallConfEvent_t>(heap);
            }
        }

        internal ATTMakePredictiveCallConfEvent_t makePredictiveCall
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTMakePredictiveCallConfEvent_t>(heap);
            }
        }

        internal ATTTransferCallConfEvent_t transferCall
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTTransferCallConfEvent_t>(heap);
            }
        }

        ATTSetAdviceOfChargeConfEvent_t setAdviceOfCharge
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTSetAdviceOfChargeConfEvent_t>(heap);
            }
        }

        public ATTSetAgentStateConfEvent_t setAgentState
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTSetAgentStateConfEvent_t>(heap);
            }
        }


        // the following are obsolete as of protocol version 4 and should not be used 

        ATTV3ConferencedEvent_t v3conferencedEvent
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTV3ConferencedEvent_t>(heap);
            }
        }

        ATTV3DeliveredEvent_t v3deliveredEvent
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTV3DeliveredEvent_t>(heap);
            }
        }

        ATTV3EstablishedEvent_t v3establishedEvent
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTV3EstablishedEvent_t>(heap);
            }
        }
        ATTV3TransferredEvent_t v3transferredEvent
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTV3TransferredEvent_t>(heap);
            }
        }
        ATTV3LinkStatusEvent_t v3linkStatus
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTV3LinkStatusEvent_t>(heap);
            }
        }

        // version 4 events
        public ATTV4QueryDeviceInfoConfEvent_t v4queryDeviceInfo
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTV4QueryDeviceInfoConfEvent_t>(heap);
            }
        }
        ATTV4GetAPICapsConfEvent_t v4getAPICaps
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTV4GetAPICapsConfEvent_t>(heap);
            }
        }
        ATTV4SnapshotDeviceConfEvent_t v4snapshotDevice
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTV4SnapshotDeviceConfEvent_t>(heap);
            }
        }
        ATTV4ConferencedEvent_t v4conferencedEvent
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTV4ConferencedEvent_t>(heap);
            }
        }
        ATTV4DeliveredEvent_t v4deliveredEvent
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTV4DeliveredEvent_t>(heap);
            }
        }
        ATTV4EstablishedEvent_t v4establishedEvent
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTV4EstablishedEvent_t>(heap);
            }
        }
        ATTV4TransferredEvent_t v4transferredEvent
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTV4TransferredEvent_t>(heap);
            }
        }
        ATTV4LinkStatusEvent_t v4linkStatus
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTV4LinkStatusEvent_t>(heap);
            }
        }
        ATTV4RouteRequestEvent_t v4routeRequest
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTV4RouteRequestEvent_t>(heap);
            }
        }
        ATTV4QueryAgentStateConfEvent_t v4queryAgentState
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTV4QueryAgentStateConfEvent_t>(heap);
            }
        }
        ATTV4QueryDeviceNameConfEvent_t v4queryDeviceName
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTV4QueryDeviceNameConfEvent_t>(heap);
            }
        }
        ATTV4MonitorConfEvent_t v4monitorStart
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTV4MonitorConfEvent_t>(heap);
            }
        }
        ATTV4MonitorCallConfEvent_t v4monitorCallStart
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTV4MonitorCallConfEvent_t>(heap);
            }
        }
        ATTV4NetworkReachedEvent_t v4networkReachedEvent
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTV4NetworkReachedEvent_t>(heap);
            }
        }

        // version 5 events
        ATTV5QueryAgentStateConfEvent_t v5queryAgentState
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTV5QueryAgentStateConfEvent_t>(heap);
            }
        }
        ATTV5RouteRequestEvent_t v5routeRequest
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTV5RouteRequestEvent_t>(heap);
            }
        }
        ATTV5TransferredEvent_t v5transferredEvent
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTV5TransferredEvent_t>(heap);
            }
        }
        ATTV5ConferencedEvent_t v5conferencedEvent
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTV5ConferencedEvent_t>(heap);
            }
        }
        ATTV5ConnectionClearedEvent_t v5connectionClearedEvent
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTV5ConnectionClearedEvent_t>(heap);
            }
        }
        ATTV5OriginatedEvent_t v5originatedEvent
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTV5OriginatedEvent_t>(heap);
            }
        }
        ATTV5EstablishedEvent_t v5establishedEvent
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTV5EstablishedEvent_t>(heap);
            }
        }
        ATTV5DeliveredEvent_t v5deliveredEvent
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTV5DeliveredEvent_t>(heap);
            }
        }


        // events received by the G3PD 

        public ATTClearConnection_t clearConnectionReq
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTClearConnection_t>(heap);
            }
        }

        ATTConsultationCall_t				consultationCallReq
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTConsultationCall_t>(heap);
            }
        }
        ATTMakeCall_t						makeCallReq
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTMakeCall_t>(heap);
            }
        }
        internal ATTDirectAgentCall_t directAgentCallReq
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTDirectAgentCall_t>(heap);
            }
        }
        ATTMakePredictiveCall_t				makePredictiveCallReq
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTMakePredictiveCall_t>(heap);
            }
        }
        ATTSupervisorAssistCall_t			supervisorAssistCallReq
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTSupervisorAssistCall_t>(heap);
            }
        }
        ATTReconnectCall_t					reconnectCallReq
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTReconnectCall_t>(heap);
            }
        }
        ATTSendDTMFTone_t					sendDTMFToneReq
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTSendDTMFTone_t>(heap);
            }
        }
        ATTSingleStepConferenceCall_t       ssconferenceReq
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTSingleStepConferenceCall_t>(heap);
            }
        }
        ATTSelectiveListeningHold_t         slholdReq
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTSelectiveListeningHold_t>(heap);
            }
        }
        ATTSelectiveListeningRetrieve_t     slretrieveReq
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTSelectiveListeningRetrieve_t>(heap);
            }
        }
        ATTSetAgentState_t					setAgentStateReq
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTSetAgentState_t>(heap);
            }
        }
        ATTQueryAgentState_t				queryAgentStateReq
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTQueryAgentState_t>(heap);
            }
        }
        ATTQueryAcdSplit_t					queryAcdSplitReq
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTQueryAcdSplit_t>(heap);
            }
        }
        ATTQueryAgentLogin_t				queryAgentLoginReq
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTQueryAgentLogin_t>(heap);
            }
        }
        ATTQueryCallClassifier_t			queryCallClassifierReq
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTQueryCallClassifier_t>(heap);
            }
        }
        ATTQueryDeviceName_t				queryDeviceNameReq
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTQueryDeviceName_t>(heap);
            }
        }
        ATTQueryStationStatus_t				queryStationStatusReq
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTQueryStationStatus_t>(heap);
            }
        }
        ATTQueryTod_t						queryTodReq
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTQueryTod_t>(heap);
            }
        }
        ATTQueryTg_t						queryTgReq
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTQueryTg_t>(heap);
            }
        }
        ATTQueryAgentMeasurements_t			queryAgentMeasReq
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTQueryAgentMeasurements_t>(heap);
            }
        }
        ATTQuerySplitSkillMeasurements_t	querySplitSkillMeasReq
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTQuerySplitSkillMeasurements_t>(heap);
            }
        }
        ATTQueryTrunkGroupMeasurements_t	queryTrunkGroupMeasReq
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTQueryTrunkGroupMeasurements_t>(heap);
            }
        }
        ATTQueryVdnMeasurements_t			queryVdnMeasReq
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTQueryVdnMeasurements_t>(heap);
            }
        }
        ATTMonitorFilter_t					monitorFilterReq
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTMonitorFilter_t>(heap);
            }
        }
        ATTMonitorStopOnCall_t				monitorStopOnCallReq
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTMonitorStopOnCall_t>(heap);
            }
        }
        ATTRouteSelect_t					routeSelectReq
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTRouteSelect_t>(heap);
            }
        }
        ATTSysStat_t						sysStatReq
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTSysStat_t>(heap);
            }
        }
        ATTSetBillRate_t					setBillRateReq
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTSetBillRate_t>(heap);
            }
        }
        ATTQueryUcid_t						queryUCIDReq
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTQueryUcid_t>(heap);
            }
        }
        ATTSetAdviceOfCharge_t				adviceOfChargeReq
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTSetAdviceOfCharge_t>(heap);
            }
        }

        // private data version 4

        ATTV4SendDTMFTone_t					v4sendDTMFToneReq
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTV4SendDTMFTone_t>(heap);
            }
        }
        ATTV4SetAgentState_t				v4setAgentStateReq
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTV4SetAgentState_t>(heap);
            }
        }
        ATTV4MonitorFilter_t				v4monitorFilterReq
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTV4MonitorFilter_t>(heap);
            }
        }

        // version 5 of private data
        ATTV5SetAgentState_t				v5setAgentStateReq
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTV5SetAgentState_t>(heap);
            }
        }
        ATTV5ClearConnection_t				v5clearConnectionReq
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTV5ClearConnection_t>(heap);
            }
        }
        ATTV5ConsultationCall_t				v5consultationCallReq
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTV5ConsultationCall_t>(heap);
            }
        }
        ATTV5MakeCall_t						v5makeCallReq
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTV5MakeCall_t>(heap);
            }
        }
        ATTV5DirectAgentCall_t				v5directAgentCallReq
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTV5DirectAgentCall_t>(heap);
            }
        }
        ATTV5MakePredictiveCall_t			v5makePredictiveCallReq
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTV5MakePredictiveCall_t>(heap);
            }
        }
        ATTV5SupervisorAssistCall_t			v5supervisorAssistCallReq
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTV5SupervisorAssistCall_t>(heap);
            }
        }
        ATTV5ReconnectCall_t				v5reconnectCallReq
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTV5ReconnectCall_t>(heap);
            }
        }
        ATTV5RouteSelect_t					v5routeSelectReq
        {
            get
            {
                return Aux.ByteArrayToStructure<ATTV5RouteSelect_t>(heap);
            }
        }
        public ATTQueryEndpointRegistrationInfoConfEvent_t queryEndpointRegistrationInfo
            {
                get
                {
                    return Aux.ByteArrayToStructure<ATTQueryEndpointRegistrationInfoConfEvent_t>(heap);
                }
            }
        }

    [DllImport("ATTPRV32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t attQueryUCID(
                        [In, Out]
                        Acs.PrivateData_t privData,
                        Csta.ConnectionID_t call);

    [DllImport("ATTPRV32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t attClearConnection(
                        [In, Out]
                        Acs.PrivateData_t privData,
                        ATTDropResource_t dropResource,
                        ref ATTV5UserToUserInfo_t userInfo);

    [DllImport("ATTPRV32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t attV6ClearConnection(
                        [In, Out]
                        Acs.PrivateData_t privData,
                        ATTDropResource_t dropResource,
                        ref ATTUserToUserInfo_t userInfo);

    [DllImport("ATTPRV32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t attV6ConsultationCall(
                        [In, Out]
                        Acs.PrivateData_t privData,
                        ref Csta.DeviceID_t deviceRoute,
                        bool priorityCalling,
                        ref ATTUserToUserInfo_t userInfo);

    [DllImport("ATTPRV32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t attConsultationCall(
                        [In, Out]
                        Acs.PrivateData_t privData,
                        ref Csta.DeviceID_t deviceRoute,
                        bool priorityCalling,
                        ref ATTV5UserToUserInfo_t userInfo);

    [DllImport("ATTPRV32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t attV6DirectAgentCall(
                        [In, Out]
                        Acs.PrivateData_t privData,
                        ref Csta.DeviceID_t split,
                        bool priorityCalling,
                        ref ATTUserToUserInfo_t userInfo);

    [DllImport("ATTPRV32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t attDirectAgentCall(
                        [In, Out]
                        Acs.PrivateData_t privData,
                        ref Csta.DeviceID_t split,
                        bool priorityCalling,
                        ref ATTV5UserToUserInfo_t userInfo);

    [DllImport("ATTPRV32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t attV6SupervisorAssistCall(
                        [In, Out]
                        Acs.PrivateData_t privData,
                        ref Csta.DeviceID_t deviceRoute,
                        ref ATTUserToUserInfo_t userInfo);

    [DllImport("ATTPRV32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t attSupervisorAssistCall(
                        [In, Out]
                        Acs.PrivateData_t privData,
                        ref Csta.DeviceID_t deviceRoute,
                        ref ATTV5UserToUserInfo_t userInfo);

    [DllImport("ATTPRV32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t attV6MakeCall(
                        [In, Out]
                        Acs.PrivateData_t privateData,
                        ref Csta.DeviceID_t destRoute,
                        bool priorityCalling,
                        ref ATTUserToUserInfo_t userInfo);

    [DllImport("ATTPRV32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t attMakeCall(
                        [In, Out]
                        Acs.PrivateData_t privateData,
                        ref Csta.DeviceID_t destRoute,
                        bool priorityCalling,
                        ref ATTV5UserToUserInfo_t userInfo);

    [DllImport("ATTPRV32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t attV6MakePredictiveCall(
                        [In, Out]
                        Acs.PrivateData_t privateData,
                        bool priorityCalling,
                        short maxRings,
                        ATTAnswerTreat_t answerTreat,
                        ref Csta.DeviceID_t destRoute,
                        ref ATTUserToUserInfo_t userInfo);

    [DllImport("ATTPRV32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t attMakePredictiveCall(
                        [In, Out]
                        Acs.PrivateData_t privateData,
                        bool priorityCalling,
                        short maxRings,
                        ATTAnswerTreat_t answerTreat,
                        ref Csta.DeviceID_t destRoute,
                        ref ATTV5UserToUserInfo_t userInfo);

    [DllImport("ATTPRV32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t attV6ReconnectCall(
                        [In, Out]
                        Acs.PrivateData_t privateData,
                        ATTDropResource_t dropResource,
                        ref ATTUserToUserInfo_t userInfo);

    [DllImport("ATTPRV32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t attReconnectCall(
                        [In, Out]
                        Acs.PrivateData_t privateData,
                        ATTDropResource_t dropResource,
                        ref ATTV5UserToUserInfo_t userInfo);       

    [DllImport("ATTPRV32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t attSendDTMFToneExt(
                        [In, Out]
                        Acs.PrivateData_t privateData,
                        Csta.ConnectionID_t sender,
                        ref ATTConnIDList_t receivers,
                        string tones,
                        short toneDuration,
                        short pauseDuration);

    [DllImport("ATTPRV32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t attSendDTMFTone(
                        [In, Out]
                        Acs.PrivateData_t privateData,
                        Csta.ConnectionID_t sender,
                        ref ATTConnIDList_t receivers,
                        string tones,
                        short toneDuration,
                        short pauseDuration);  

    [DllImport("ATTPRV32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t attSelectiveListeningHold(
                        [In, Out]
                        Acs.PrivateData_t privateData,
                        Csta.ConnectionID_t subjectConnection,
                        bool allParties,
                        Csta.ConnectionID_t selectedParty);

    [DllImport("ATTPRV32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t attSelectiveListeningRetrieve(
                        [In, Out]
                        Acs.PrivateData_t privateData,
                        Csta.ConnectionID_t subjectConnection,
                        bool allParties,
                        Csta.ConnectionID_t selectedParty);

    [DllImport("ATTPRV32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t attSingleStepConferenceCall(
                        [In, Out]
                        Acs.PrivateData_t privateData,
                        Csta.ConnectionID_t activeCall,
                        ref Csta.DeviceID_t deviceToBeJoin,
                        Att.ATTParticipationType_t participationType,
                        bool alertDestination);

    [DllImport("ATTPRV32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t attSingleStepTransferCall(
                        [In, Out]
                        Acs.PrivateData_t privateData,
                        Csta.ConnectionID_t activeCall,
                        ref Csta.DeviceID_t transferredTo);  

    [DllImport("ATTPRV32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t attSetAgentState(
                        [In, Out]
                        Acs.PrivateData_t privateData,
                        ATTWorkMode_t workMode,
                        int reasonCode);

    [DllImport("ATTPRV32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t attV6SetAgentState(
                        [In, Out]
                        Acs.PrivateData_t privateData,
                        ATTWorkMode_t workMode,
                        int reasonCode,
                        bool enablePending);     

    [DllImport("ATTPRV32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t attSetAdviceOfCharge(
                        [In, Out]
                        Acs.PrivateData_t privateData,
                        bool flag);

    [DllImport("ATTPRV32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t attSetBillRate(
                        [In, Out]
                        Acs.PrivateData_t privateData,
                        Csta.ConnectionID_t call,
                        Att.ATTBillType_t billType,
                        float billrate);

    [DllImport("ATTPRV32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t attQueryAcdSplit(
                        [In, Out]
                        Acs.PrivateData_t privateData,
                        ref Csta.DeviceID_t device);

    [DllImport("ATTPRV32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t attQueryAgentLogin(
                        [In, Out]
                        Acs.PrivateData_t privateData,
                        ref Csta.DeviceID_t device);

    [DllImport("ATTPRV32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t attQueryAgentState(
                        [In, Out]
                        Acs.PrivateData_t privateData,
                        ref Csta.DeviceID_t split);

    [DllImport("ATTPRV32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t attQueryCallClassifier(
                        [In, Out]
                        Acs.PrivateData_t privateData);

    [DllImport("ATTPRV32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t attQueryDeviceName(
                        [In, Out]
                        Acs.PrivateData_t privateData,
                        ref Csta.DeviceID_t split);

    [DllImport("ATTPRV32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t attQueryEndpointRegistrationInfo(
                [In, Out]
                Acs.PrivateData_t privateData,
                ref Csta.DeviceID_t device);

    [DllImport("ATTPRV32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t attV10QueryStationStatus(
            [In, Out]
            Acs.PrivateData_t privateData,
            ref Csta.DeviceID_t device);

    [DllImport("ATTPRV32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t attQueryStationStatus(
            [In, Out]
            Acs.PrivateData_t privateData,
            ref Csta.DeviceID_t device);

    [DllImport("ATTPRV32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t attQueryTimeOfDay(
            [In, Out]
            Acs.PrivateData_t privateData);

    [DllImport("ATTPRV32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t attQueryTrunkGroup(
            [In, Out]
            Acs.PrivateData_t privateData,
            ref Csta.DeviceID_t device);

    [DllImport("ATTPRV32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t attMonitorFilterExt(
            [In, Out]
            Acs.PrivateData_t privateData,
            Att.ATTPrivateFilter_t privateFilter);

    [DllImport("ATTPRV32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t attMonitorFilter(
            [In, Out]
            Acs.PrivateData_t privateData,
            Att.ATTV4PrivateFilter_t privateFilter);



        [DllImport("ATTPRV32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t attMakeVersionString(
                        string requestedVersion,
                        System.Text.StringBuilder supportedVersion);

    // Decode ATTPrivateData
    [DllImport("ATTPRV32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern Acs.RetCode_t attPrivateData(
                        [In, Out]
                        Acs.PrivateData_t privData,
                        [In, Out]
                        ATTEvent_t eventBuffer);


    public class CstaEscapeData
    {
        internal Att.ATTEvent_t[] attEvts;
        internal Acs.RetCode_t cstaReturnCode;
        internal Acs.RetCode_t attReturnCode;
        internal Csta.CSTAUniversalFailureConfEvent_t cstaError;

        public void GetAttEvents(Acs.ACSHandle_t acsHandle, Acs.PrivateData_t privData)
        {

            this.cstaReturnCode = Csta.cstaEscapeService(acsHandle, new Acs.InvokeID_t(), privData);
            if (this.cstaReturnCode._value < 0) return;

            var cstaEvtBuf = new Csta.EventBuffer_t();
            ushort eventBufferSize = Csta.CSTA_MAX_HEAP;
            privData.length = Att.ATT_MAX_PRIVATE_DATA;
            ushort numEvents;
            this.cstaReturnCode = Acs.acsGetEventBlock(acsHandle, cstaEvtBuf, ref eventBufferSize, privData, out numEvents);
            if (this.cstaReturnCode._value < 0) return;

            if (cstaEvtBuf.evt.eventHeader.eventClass.eventClass != Csta.CSTACONFIRMATION ||
                cstaEvtBuf.evt.eventHeader.eventType.eventType != Csta.CSTA_ESCAPE_SVC_CONF)
            {
                this.cstaError = cstaEvtBuf.evt.cstaConfirmation.universalFailure;
                return;
            }
            List<Att.ATTEvent_t> attEvtsList = new List<ATTEvent_t>();
            var attEvt = new Att.ATTEvent_t();
            this.attReturnCode = Att.attPrivateData(privData, attEvt);
            if (this.attReturnCode._value < 0) return;
            attEvtsList.Add(attEvt);


            if (attEvt.eventType.eventType == Att.ATT_QUERY_AGENT_LOGIN_CONF)
            {
                //  The number of events is sometimes erroneously set to 0,
                //  but there should always be at least one additional event
                //  with attQueryAgentLogin()
                numEvents = 1;
                while (numEvents > 0 || attEvt.queryAgentLoginResp.count > 0)
                {
                    attEvt = new Att.ATTEvent_t();
                    eventBufferSize = Csta.CSTA_MAX_HEAP;
                    privData.length = Att.ATT_MAX_PRIVATE_DATA;
                    this.cstaReturnCode = Acs.acsGetEventBlock(acsHandle, cstaEvtBuf, ref eventBufferSize, privData, out numEvents);
                    if (this.cstaReturnCode._value < 0) return;
                    if ((cstaEvtBuf.evt.eventHeader.eventClass.eventClass == Csta.CSTACONFIRMATION ||
                        cstaEvtBuf.evt.eventHeader.eventClass.eventClass == Csta.CSTAEVENTREPORT) &&
                        (cstaEvtBuf.evt.eventHeader.eventType.eventType == Csta.CSTA_ESCAPE_SVC_CONF ||
                        cstaEvtBuf.evt.eventHeader.eventType.eventType == Csta.CSTA_PRIVATE))
                    {
                        this.attReturnCode = Att.attPrivateData(privData, attEvt);
                        if (this.attReturnCode._value >= 0)
                            attEvtsList.Add(attEvt);
                    }
                    else
                    {
                        this.cstaError = cstaEvtBuf.evt.cstaConfirmation.universalFailure;
                        return;
                    }
                }
            }
            else
            {
                while (numEvents > 0)
                {
                    attEvt = new Att.ATTEvent_t();
                    eventBufferSize = Csta.CSTA_MAX_HEAP;
                    privData.length = Att.ATT_MAX_PRIVATE_DATA;
                    this.cstaReturnCode = Acs.acsGetEventBlock(acsHandle, cstaEvtBuf, ref eventBufferSize, privData, out numEvents);
                    if (this.cstaReturnCode._value < 0) return;
                    if ((cstaEvtBuf.evt.eventHeader.eventClass.eventClass == Csta.CSTACONFIRMATION ||
                        cstaEvtBuf.evt.eventHeader.eventClass.eventClass == Csta.CSTAEVENTREPORT) &&
                        (cstaEvtBuf.evt.eventHeader.eventType.eventType == Csta.CSTA_ESCAPE_SVC_CONF ||
                        cstaEvtBuf.evt.eventHeader.eventType.eventType == Csta.CSTA_PRIVATE))
                    {
                        this.attReturnCode = Att.attPrivateData(privData, attEvt);
                        if (this.attReturnCode._value >= 0)
                            attEvtsList.Add(attEvt);
                    }
                    else
                    {
                        this.cstaError = cstaEvtBuf.evt.cstaConfirmation.universalFailure;
                        return;
                    }
                }
            }
            this.attEvts = attEvtsList.ToArray();
        }
    }
}
}