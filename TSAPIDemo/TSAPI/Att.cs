using System;
using System.Runtime.InteropServices;

namespace Tsapi
{
    using ATTPrivateData_t = Acs.PrivateData_t;
    public static partial class Att
    {

        public const int ATT_MAX_PRIVATE_DATA = 1024;
        public const int ATTPRIV_MAX_HEAP = 64;

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct ATTEventType_t
        {
            private int eventType;

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
        public struct ATTEvent_t
        {
            public ATTEventType_t eventType;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = Att.ATTPRIV_MAX_HEAP)]
            private byte[] heap;

            // private version 6 
            /*
            ATTSingleStepConferenceCallConfEvent_t      ssconference;
            ATTSelectiveListeningHoldConfEvent_t  slhold;
            ATTSelectiveListeningRetrieveConfEvent_t slretrieve;
            ATTSendDTMFToneConfEvent_t			sendDTMFTone;
            ATTQueryAcdSplitConfEvent_t			queryAcdSplit;
            ATTQueryAgentLoginConfEvent_t		queryAgentLogin;
            ATTQueryAgentLoginResp_t			queryAgentLoginResp;
            ATTQueryAgentStateConfEvent_t		queryAgentState;
            ATTQueryCallClassifierConfEvent_t	queryCallClassifier;
            ATTQueryDeviceInfoConfEvent_t		queryDeviceInfo;
            ATTQueryDeviceNameConfEvent_t		queryDeviceName;
            ATTQueryMwiConfEvent_t				queryMwi;
            ATTQueryStationStatusConfEvent_t	queryStationStatus;
            ATTQueryTodConfEvent_t				queryTod;
            ATTQueryTgConfEvent_t				queryTg;
            ATTQueryAgentMeasurementsConfEvent_t		queryAgentMeas;
            ATTQuerySplitSkillMeasurementsConfEvent_t	querySplitSkillMeas;
            ATTQueryTrunkGroupMeasurementsConfEvent_t	queryTrunkGroupMeas;
            ATTQueryVdnMeasurementsConfEvent_t			queryVdnMeas;
            ATTSnapshotDeviceConfEvent_t		snapshotDevice;
            ATTMonitorConfEvent_t		  		monitorStart;
            ATTMonitorCallConfEvent_t			monitorCallStart; 
            ATTMonitorStopOnCallConfEvent_t		monitorStopOnCall;
            ATTCallClearedEvent_t				callClearedEvent;
            ATTConferencedEvent_t				conferencedEvent;
            ATTConnectionClearedEvent_t			connectionClearedEvent;
            ATTDeliveredEvent_t					deliveredEvent;
            ATTEnteredDigitsEvent_t				enteredDigitsEvent;
            ATTEstablishedEvent_t				establishedEvent;
            ATTLoggedOnEvent_t					loggedOnEvent;
            ATTNetworkReachedEvent_t			networkReachedEvent;
            ATTOriginatedEvent_t				originatedEvent;
            ATTTransferredEvent_t				transferredEvent;
            ATTRouteRequestEvent_t				routeRequest;
            ATTRouteUsedEvent_t					routeUsed;
            ATTLinkStatusEvent_t				linkStatus;
            ATTGetAPICapsConfEvent_t			getAPICaps;
            ATTServiceInitiatedEvent_t			serviceInitiated;
            ATTChargeAdviceEvent_t				chargeAdviceEvent;
            ATTSetBillRateConfEvent_t			setBillRate;
            */
            
            public ATTQueryUcidConfEvent_t queryUCID
            {
                get
                {
                    return Aux.ByteArrayToStructure<ATTQueryUcidConfEvent_t>(heap);
                }
            }

            /*
            ATTLoggedOffEvent_t					loggedOffEvent;
            ATTConsultationCallConfEvent_t		consultationCall;
            ATTConferenceCallConfEvent_t		conferenceCall;
            ATTMakeCallConfEvent_t				makeCall;
            ATTMakePredictiveCallConfEvent_t	makePredictiveCall;
            ATTTransferCallConfEvent_t			transferCall;
            ATTSetAdviceOfChargeConfEvent_t		setAdviceOfCharge;
            ATTSetAgentStateConfEvent_t			setAgentState;

            // the following are obsolete as of protocol version 4 and should not be used 

            ATTV3ConferencedEvent_t				v3conferencedEvent;
            ATTV3DeliveredEvent_t				v3deliveredEvent;
            ATTV3EstablishedEvent_t				v3establishedEvent;
            ATTV3TransferredEvent_t				v3transferredEvent;
            ATTV3LinkStatusEvent_t				v3linkStatus;

            // version 4 events
            ATTV4QueryDeviceInfoConfEvent_t		v4queryDeviceInfo;
            ATTV4GetAPICapsConfEvent_t			v4getAPICaps;
            ATTV4SnapshotDeviceConfEvent_t		v4snapshotDevice;
            ATTV4ConferencedEvent_t				v4conferencedEvent;
            ATTV4DeliveredEvent_t				v4deliveredEvent;
            ATTV4EstablishedEvent_t				v4establishedEvent;
            ATTV4TransferredEvent_t				v4transferredEvent;
            ATTV4LinkStatusEvent_t				v4linkStatus;
            ATTV4RouteRequestEvent_t			v4routeRequest;
            ATTV4QueryAgentStateConfEvent_t		v4queryAgentState;
            ATTV4QueryDeviceNameConfEvent_t		v4queryDeviceName;
            ATTV4MonitorConfEvent_t		  		v4monitorStart;
            ATTV4MonitorCallConfEvent_t			v4monitorCallStart;
            ATTV4NetworkReachedEvent_t			v4networkReachedEvent;

            // version 5 events
            ATTV5QueryAgentStateConfEvent_t		v5queryAgentState;
            ATTV5RouteRequestEvent_t			v5routeRequest;
            ATTV5TransferredEvent_t				v5transferredEvent;
            ATTV5ConferencedEvent_t				v5conferencedEvent;
            ATTV5ConnectionClearedEvent_t		v5connectionClearedEvent;
            ATTV5OriginatedEvent_t				v5originatedEvent;
            ATTV5EstablishedEvent_t				v5establishedEvent;
            ATTV5DeliveredEvent_t				v5deliveredEvent;


            // events received by the G3PD 

            ATTClearConnection_t				clearConnectionReq;
            ATTConsultationCall_t				consultationCallReq;
            ATTMakeCall_t						makeCallReq;
            ATTDirectAgentCall_t				directAgentCallReq;
            ATTMakePredictiveCall_t				makePredictiveCallReq;
            ATTSupervisorAssistCall_t			supervisorAssistCallReq;
            ATTReconnectCall_t					reconnectCallReq;
            ATTSendDTMFTone_t					sendDTMFToneReq;
            ATTSingleStepConferenceCall_t       ssconferenceReq;
            ATTSelectiveListeningHold_t         slholdReq;
            ATTSelectiveListeningRetrieve_t     slretrieveReq;
            ATTSetAgentState_t					setAgentStateReq;
            ATTQueryAgentState_t				queryAgentStateReq;
            ATTQueryAcdSplit_t					queryAcdSplitReq;
            ATTQueryAgentLogin_t				queryAgentLoginReq;                          
            ATTQueryCallClassifier_t			queryCallClassifierReq;
            ATTQueryDeviceName_t				queryDeviceNameReq;
            ATTQueryStationStatus_t				queryStationStatusReq;
            ATTQueryTod_t						queryTodReq;
            ATTQueryTg_t						queryTgReq;
            ATTQueryAgentMeasurements_t			queryAgentMeasReq;
            ATTQuerySplitSkillMeasurements_t	querySplitSkillMeasReq;
            ATTQueryTrunkGroupMeasurements_t	queryTrunkGroupMeasReq;
            ATTQueryVdnMeasurements_t			queryVdnMeasReq;
            ATTMonitorFilter_t					monitorFilterReq;
            ATTMonitorStopOnCall_t				monitorStopOnCallReq;
            ATTRouteSelect_t					routeSelectReq;
            ATTSysStat_t						sysStatReq;
            ATTSetBillRate_t					setBillRateReq;
            ATTQueryUcid_t						queryUCIDReq;
            ATTSetAdviceOfCharge_t				adviceOfChargeReq;

            // private data version 4

            ATTV4SendDTMFTone_t					v4sendDTMFToneReq;
            ATTV4SetAgentState_t				v4setAgentStateReq;
            ATTV4MonitorFilter_t				v4monitorFilterReq;

            // version 5 of private data
            ATTV5SetAgentState_t				v5setAgentStateReq;
            ATTV5ClearConnection_t				v5clearConnectionReq;
            ATTV5ConsultationCall_t				v5consultationCallReq;
            ATTV5MakeCall_t						v5makeCallReq;
            ATTV5DirectAgentCall_t				v5directAgentCallReq;
            ATTV5MakePredictiveCall_t			v5makePredictiveCallReq;
            ATTV5SupervisorAssistCall_t			v5supervisorAssistCallReq;
            ATTV5ReconnectCall_t				v5reconnectCallReq;
            ATTV5RouteSelect_t					v5routeSelectReq;
        } u;
    */
        }

        [DllImport("ATTPRV32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Acs.RetCode_t attQueryUCID(
                            [In, Out]
                            Acs.PrivateData_t privData,
                            ref Csta.ConnectionID_t call);

        [DllImport("ATTPRV32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Acs.RetCode_t attMakeVersionString(
                            string requestedVersion,
                            System.Text.StringBuilder supportedVersion);


        // Decode ATTPrivateData
        [DllImport("ATTPRV32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Acs.RetCode_t attPrivateData(
                            [In, Out]
                            Acs.PrivateData_t privData,
                            out ATTEvent_t eventBuffer);

    }
}