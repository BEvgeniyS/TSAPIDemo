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

namespace Tsapi
{
    public static partial class Csta
    {
        #region CSTA event types

        public const int CSTA_ALTERNATE_CALL = 1;
        public const int CSTA_ALTERNATE_CALL_CONF = 2;
        public const int CSTA_ANSWER_CALL = 3;
        public const int CSTA_ANSWER_CALL_CONF = 4;
        public const int CSTA_CALL_COMPLETION = 5;
        public const int CSTA_CALL_COMPLETION_CONF = 6;
        public const int CSTA_CLEAR_CALL = 7;
        public const int CSTA_CLEAR_CALL_CONF = 8;
        public const int CSTA_CLEAR_CONNECTION = 9;
        public const int CSTA_CLEAR_CONNECTION_CONF = 10;
        public const int CSTA_CONFERENCE_CALL = 11;
        public const int CSTA_CONFERENCE_CALL_CONF = 12;
        public const int CSTA_CONSULTATION_CALL = 13;
        public const int CSTA_CONSULTATION_CALL_CONF = 14;
        public const int CSTA_DEFLECT_CALL = 15;
        public const int CSTA_DEFLECT_CALL_CONF = 16;
        public const int CSTA_PICKUP_CALL = 17;
        public const int CSTA_PICKUP_CALL_CONF = 18;
        public const int CSTA_GROUP_PICKUP_CALL = 19;
        public const int CSTA_GROUP_PICKUP_CALL_CONF = 20;
        public const int CSTA_HOLD_CALL = 21;
        public const int CSTA_HOLD_CALL_CONF = 22;
        public const int CSTA_MAKE_CALL = 23;
        public const int CSTA_MAKE_CALL_CONF = 24;
        public const int CSTA_MAKE_PREDICTIVE_CALL = 25;
        public const int CSTA_MAKE_PREDICTIVE_CALL_CONF = 26;
        public const int CSTA_QUERY_MWI = 27;
        public const int CSTA_QUERY_MWI_CONF = 28;
        public const int CSTA_QUERY_DND = 29;
        public const int CSTA_QUERY_DND_CONF = 30;
        public const int CSTA_QUERY_FWD = 31;
        public const int CSTA_QUERY_FWD_CONF = 32;
        public const int CSTA_QUERY_AGENT_STATE = 33;
        public const int CSTA_QUERY_AGENT_STATE_CONF = 34;
        public const int CSTA_QUERY_LAST_NUMBER = 35;
        public const int CSTA_QUERY_LAST_NUMBER_CONF = 36;
        public const int CSTA_QUERY_DEVICE_INFO = 37;
        public const int CSTA_QUERY_DEVICE_INFO_CONF = 38;
        public const int CSTA_RECONNECT_CALL = 39;
        public const int CSTA_RECONNECT_CALL_CONF = 40;
        public const int CSTA_RETRIEVE_CALL = 41;
        public const int CSTA_RETRIEVE_CALL_CONF = 42;
        public const int CSTA_SET_MWI = 43;
        public const int CSTA_SET_MWI_CONF = 44;
        public const int CSTA_SET_DND = 45;
        public const int CSTA_SET_DND_CONF = 46;
        public const int CSTA_SET_FWD = 47;
        public const int CSTA_SET_FWD_CONF = 48;
        public const int CSTA_SET_AGENT_STATE = 49;
        public const int CSTA_SET_AGENT_STATE_CONF = 50;
        public const int CSTA_TRANSFER_CALL = 51;
        public const int CSTA_TRANSFER_CALL_CONF = 52;
        public const int CSTA_UNIVERSAL_FAILURE_CONF = 53;
        public const int CSTA_CALL_CLEARED = 54;
        public const int CSTA_CONFERENCED = 55;
        public const int CSTA_CONNECTION_CLEARED = 56;
        public const int CSTA_DELIVERED = 57;
        public const int CSTA_DIVERTED = 58;
        public const int CSTA_ESTABLISHED = 59;
        public const int CSTA_FAILED = 60;
        public const int CSTA_HELD = 61;
        public const int CSTA_NETWORK_REACHED = 62;
        public const int CSTA_ORIGINATED = 63;
        public const int CSTA_QUEUED = 64;
        public const int CSTA_RETRIEVED = 65;
        public const int CSTA_SERVICE_INITIATED = 66;
        public const int CSTA_TRANSFERRED = 67;
        public const int CSTA_CALL_INFORMATION = 68;
        public const int CSTA_DO_NOT_DISTURB = 69;
        public const int CSTA_FORWARDING = 70;
        public const int CSTA_MESSAGE_WAITING = 71;
        public const int CSTA_LOGGED_ON = 72;
        public const int CSTA_LOGGED_OFF = 73;
        public const int CSTA_NOT_READY = 74;
        public const int CSTA_READY = 75;
        public const int CSTA_WORK_NOT_READY = 76;
        public const int CSTA_WORK_READY = 77;
        public const int CSTA_ROUTE_REGISTER_REQ = 78;
        public const int CSTA_ROUTE_REGISTER_REQ_CONF = 79;
        public const int CSTA_ROUTE_REGISTER_CANCEL = 80;
        public const int CSTA_ROUTE_REGISTER_CANCEL_CONF = 81;
        public const int CSTA_ROUTE_REGISTER_ABORT = 82;
        public const int CSTA_ROUTE_REQUEST = 83;
        public const int CSTA_ROUTE_SELECT_REQUEST = 84;
        public const int CSTA_RE_ROUTE_REQUEST = 85;
        public const int CSTA_ROUTE_USED = 86;
        public const int CSTA_ROUTE_END = 87;
        public const int CSTA_ROUTE_END_REQUEST = 88;
        public const int CSTA_ESCAPE_SVC = 89;
        public const int CSTA_ESCAPE_SVC_CONF = 90;
        public const int CSTA_ESCAPE_SVC_REQ = 91;
        public const int CSTA_ESCAPE_SVC_REQ_CONF = 92;
        public const int CSTA_PRIVATE = 93;
        public const int CSTA_PRIVATE_STATUS = 94;
        public const int CSTA_SEND_PRIVATE = 95;
        public const int CSTA_BACK_IN_SERVICE = 96;
        public const int CSTA_OUT_OF_SERVICE = 97;
        public const int CSTA_REQ_SYS_STAT = 98;
        public const int CSTA_SYS_STAT_REQ_CONF = 99;
        public const int CSTA_SYS_STAT_START = 100;
        public const int CSTA_SYS_STAT_START_CONF = 101;
        public const int CSTA_SYS_STAT_STOP = 102;
        public const int CSTA_SYS_STAT_STOP_CONF = 103;
        public const int CSTA_CHANGE_SYS_STAT_FILTER = 104;
        public const int CSTA_CHANGE_SYS_STAT_FILTER_CONF = 105;
        public const int CSTA_SYS_STAT = 106;
        public const int CSTA_SYS_STAT_ENDED = 107;
        public const int CSTA_SYS_STAT_REQ = 108;
        public const int CSTA_REQ_SYS_STAT_CONF = 109;
        public const int CSTA_SYS_STAT_EVENT_SEND = 110;
        public const int CSTA_MONITOR_DEVICE = 111;
        public const int CSTA_MONITOR_CALL = 112;
        public const int CSTA_MONITOR_CALLS_VIA_DEVICE = 113;
        public const int CSTA_MONITOR_CONF = 114;
        public const int CSTA_CHANGE_MONITOR_FILTER = 115;
        public const int CSTA_CHANGE_MONITOR_FILTER_CONF = 116;
        public const int CSTA_MONITOR_STOP = 117;
        public const int CSTA_MONITOR_STOP_CONF = 118;
        public const int CSTA_MONITOR_ENDED = 119;
        public const int CSTA_SNAPSHOT_CALL = 120;
        public const int CSTA_SNAPSHOT_CALL_CONF = 121;
        public const int CSTA_SNAPSHOT_DEVICE = 122;
        public const int CSTA_SNAPSHOT_DEVICE_CONF = 123;
        public const int CSTA_GETAPI_CAPS = 124;
        public const int CSTA_GETAPI_CAPS_CONF = 125;
        public const int CSTA_GET_DEVICE_LIST = 126;
        public const int CSTA_GET_DEVICE_LIST_CONF = 127;
        public const int CSTA_QUERY_CALL_MONITOR = 128;
        public const int CSTA_QUERY_CALL_MONITOR_CONF = 129;
        public const int CSTA_ROUTE_REQUEST_EXT = 130;
        public const int CSTA_ROUTE_USED_EXT = 131;
        public const int CSTA_ROUTE_SELECT_INV_REQUEST = 132;
        public const int CSTA_ROUTE_END_INV_REQUEST = 133;

        #endregion

        public enum CSTAUniversalFailure_t
        {
            GENERIC_UNSPECIFIED = 0,
            GENERIC_OPERATION = 1,
            REQUEST_INCOMPATIBLE_WITH_OBJECT = 2,
            VALUE_OUT_OF_RANGE = 3,
            OBJECT_NOT_KNOWN = 4,
            INVALID_CALLING_DEVICE = 5,
            INVALID_CALLED_DEVICE = 6,
            INVALID_FORWARDING_DESTINATION = 7,
            PRIVILEGE_VIOLATION_ON_SPECIFIED_DEVICE = 8,
            PRIVILEGE_VIOLATION_ON_CALLED_DEVICE = 9,
            PRIVILEGE_VIOLATION_ON_CALLING_DEVICE = 10,
            INVALID_CSTA_CALL_IDENTIFIER = 11,
            INVALID_CSTA_DEVICE_IDENTIFIER = 12,
            INVALID_CSTA_CONNECTION_IDENTIFIER = 13,
            INVALID_DESTINATION = 14,
            INVALID_FEATURE = 15,
            INVALID_ALLOCATION_STATE = 16,
            INVALID_CROSS_REF_ID = 17,
            INVALID_OBJECT_TYPE = 18,
            SECURITY_VIOLATION = 19,
            GENERIC_STATE_INCOMPATIBILITY = 21,
            INVALID_OBJECT_STATE = 22,
            INVALID_CONNECTION_ID_FOR_ACTIVE_CALL = 23,
            NO_ACTIVE_CALL = 24,
            NO_HELD_CALL = 25,
            NO_CALL_TO_CLEAR = 26,
            NO_CONNECTION_TO_CLEAR = 27,
            NO_CALL_TO_ANSWER = 28,
            NO_CALL_TO_COMPLETE = 29,
            GENERIC_SYSTEM_RESOURCE_AVAILABILITY = 31,
            SERVICE_BUSY = 32,
            RESOURCE_BUSY = 33,
            RESOURCE_OUT_OF_SERVICE = 34,
            NETWORK_BUSY = 35,
            NETWORK_OUT_OF_SERVICE = 36,
            OVERALL_MONITOR_LIMIT_EXCEEDED = 37,
            CONFERENCE_MEMBER_LIMIT_EXCEEDED = 38,
            GENERIC_SUBSCRIBED_RESOURCE_AVAILABILITY = 41,
            OBJECT_MONITOR_LIMIT_EXCEEDED = 42,
            EXTERNAL_TRUNK_LIMIT_EXCEEDED = 43,
            OUTSTANDING_REQUEST_LIMIT_EXCEEDED = 44,
            GENERIC_PERFORMANCE_MANAGEMENT = 51,
            PERFORMANCE_LIMIT_EXCEEDED = 52,
            UNSPECIFIED_SECURITY_ERROR = 60,
            SEQUENCE_NUMBER_VIOLATED = 61,
            TIME_STAMP_VIOLATED = 62,
            PAC_VIOLATED = 63,
            SEAL_VIOLATED = 64,
            GENERIC_UNSPECIFIED_REJECTION = 70,
            GENERIC_OPERATION_REJECTION = 71,
            DUPLICATE_INVOCATION_REJECTION = 72,
            UNRECOGNIZED_OPERATION_REJECTION = 73,
            MISTYPED_ARGUMENT_REJECTION = 74,
            RESOURCE_LIMITATION_REJECTION = 75,
            ACS_HANDLE_TERMINATION_REJECTION = 76,
            SERVICE_TERMINATION_REJECTION = 77,
            REQUEST_TIMEOUT_REJECTION = 78,
            REQUESTS_ON_DEVICE_EXCEEDED_REJECTION = 79,
            UNRECOGNIZED_APDU_REJECTION = 80,
            MISTYPED_APDU_REJECTION = 81,
            BADLY_STRUCTURED_APDU_REJECTION = 82,
            INITIATOR_RELEASING_REJECTION = 83,
            UNRECOGNIZED_LINKEDID_REJECTION = 84,
            LINKED_RESPONSE_UNEXPECTED_REJECTION = 85,
            UNEXPECTED_CHILD_OPERATION_REJECTION = 86,
            MISTYPED_RESULT_REJECTION = 87,
            UNRECOGNIZED_ERROR_REJECTION = 88,
            UNEXPECTED_ERROR_REJECTION = 89,
            MISTYPED_PARAMETER_REJECTION = 90,
            NON_STANDARD = 100
        };

        public enum CSTAEventCause_t
        {
            EC_NONE = -1,
            EC_ACTIVE_MONITOR = 1,
            EC_ALTERNATE = 2,
            EC_BUSY = 3,
            EC_CALL_BACK = 4,
            EC_CALL_CANCELLED = 5,
            EC_CALL_FORWARD_ALWAYS = 6,
            EC_CALL_FORWARD_BUSY = 7,
            EC_CALL_FORWARD_NO_ANSWER = 8,
            EC_CALL_FORWARD = 9,
            EC_CALL_NOT_ANSWERED = 10,
            EC_CALL_PICKUP = 11,
            EC_CAMP_ON = 12,
            EC_DEST_NOT_OBTAINABLE = 13,
            EC_DO_NOT_DISTURB = 14,
            EC_INCOMPATIBLE_DESTINATION = 15,
            EC_INVALID_ACCOUNT_CODE = 16,
            EC_KEY_CONFERENCE = 17,
            EC_LOCKOUT = 18,
            EC_MAINTENANCE = 19,
            EC_NETWORK_CONGESTION = 20,
            EC_NETWORK_NOT_OBTAINABLE = 21,
            EC_NEW_CALL = 22,
            EC_NO_AVAILABLE_AGENTS = 23,
            EC_OVERRIDE = 24,
            EC_PARK = 25,
            EC_OVERFLOW = 26,
            EC_RECALL = 27,
            EC_REDIRECTED = 28,
            EC_REORDER_TONE = 29,
            EC_RESOURCES_NOT_AVAILABLE = 30,
            EC_SILENT_MONITOR = 31,
            EC_TRANSFER = 32,
            EC_TRUNKS_BUSY = 33,
            EC_VOICE_UNIT_INITIATOR = 34,
            EC_NETWORKSIGNAL = 46,
            EC_ALERTTIMEEXPIRED = 60,
            EC_DESTOUTOFORDER = 65,
            EC_NOTSUPPORTEDBEARERSERVICE = 80,
            EC_UNASSIGNED_NUMBER = 81,
            EC_INCOMPATIBLE_BEARER_SERVICE = 87
        };

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct DeviceID_t
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
            private string device;

            public DeviceID_t(string value)
            {
                device = value;
            }

            public static implicit operator DeviceID_t(string value)
            {
                return new DeviceID_t(value);
            }

            public override string ToString()
            {
                return device;
            }
        }

        public enum DeviceIDType_t
        {
            DEVICE_IDENTIFIER = 0,
            IMPLICIT_PUBLIC = 20,
            EXPLICIT_PUBLIC_UNKNOWN = 30,
            EXPLICIT_PUBLIC_INTERNATIONAL = 31,
            EXPLICIT_PUBLIC_NATIONAL = 32,
            EXPLICIT_PUBLIC_NETWORK_SPECIFIC = 33,
            EXPLICIT_PUBLIC_SUBSCRIBER = 34,
            EXPLICIT_PUBLIC_ABBREVIATED = 35,
            IMPLICIT_PRIVATE = 40,
            EXPLICIT_PRIVATE_UNKNOWN = 50,
            EXPLICIT_PRIVATE_LEVEL3_REGIONAL_NUMBER = 51,
            EXPLICIT_PRIVATE_LEVEL2_REGIONAL_NUMBER = 52,
            EXPLICIT_PRIVATE_LEVEL1_REGIONAL_NUMBER = 53,
            EXPLICIT_PRIVATE_PTN_SPECIFIC_NUMBER = 54,
            EXPLICIT_PRIVATE_LOCAL_NUMBER = 55,
            EXPLICIT_PRIVATE_ABBREVIATED = 56,
            OTHER_PLAN = 60,
            TRUNK_IDENTIFIER = 70,
            TRUNK_GROUP_IDENTIFIER = 71,
        };

        public enum DeviceIDStatus_t
        {
            ID_PROVIDED = 0,
            ID_NOT_KNOWN = 1,
            ID_NOT_REQUIRED = 2,
        };

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct ExtendedDeviceID_t
        {
            public DeviceID_t deviceID;
            public DeviceIDType_t deviceIDType;
            public DeviceIDStatus_t deviceIDStatus;
        };

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct CallingDeviceID_t
        {
            public ExtendedDeviceID_t dev;
        };

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct CalledDeviceID_t
        {
            public ExtendedDeviceID_t dev;
        };

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct SubjectDeviceID_t
        {
            public ExtendedDeviceID_t dev;
        };

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct RedirectionDeviceID_t
        {
            public ExtendedDeviceID_t dev;
        };

        public enum ConnectionID_Device_t
        {
            STATIC_ID = 0,
            DYNAMIC_ID = 1
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public class ConnectionID_t
        {
            public int callID;
            public DeviceID_t deviceID;
            public ConnectionID_Device_t devIDType;


            public override string ToString()
            {
                return string.Format("Connection ID:{0}; Device:{1}; Type:{2}", callID, deviceID, devIDType);
            }
        };

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct Connection_t
        {
            ConnectionID_t party;
            SubjectDeviceID_t staticDevice;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public class ConnectionList_t
        {
            int count;
            IntPtr connection; //pointer to Connection_t[]
            //Connection_t    FAR *connection;

        }

        public enum LocalConnectionState_t
        {
            CS_NONE = -1,
            CS_NULL = 0,
            CS_INITIATE = 1,
            CS_ALERTING = 2,
            CS_CONNECT = 3,
            CS_HOLD = 4,
            CS_QUEUED = 5,
            CS_FAIL = 6,
        };

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct CSTAMonitorCrossRefID_t
        {
            private int cstaMonitorCrossRefID;

            private CSTAMonitorCrossRefID_t(int value)
            {
                cstaMonitorCrossRefID = value;
            }

            public static implicit operator CSTAMonitorCrossRefID_t(int value)
            {
                return new CSTAMonitorCrossRefID_t(value);
            }

            public override string ToString()
            {
                return cstaMonitorCrossRefID.ToString();
            }
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct CSTACallFilter_t
        {
            private ushort filter;

            private CSTACallFilter_t(ushort value)
            {
                filter = value;
            }

            public static implicit operator CSTACallFilter_t(ushort value)
            {
                return new CSTACallFilter_t(value);
            }

            public override string ToString()
            {
                return filter.ToString();
            }
        }
 
        public const int CF_CALL_CLEARED = 0x8000;
        public const int CF_CONFERENCED = 0x4000;
        public const int CF_CONNECTION_CLEARED = 0x2000;
        public const int CF_DELIVERED = 0x1000;
        public const int CF_DIVERTED = 0x0800;
        public const int CF_ESTABLISHED = 0x0400;
        public const int CF_FAILED = 0x0200;
        public const int CF_HELD = 0x0100;
        public const int CF_NETWORK_REACHED = 0x0080;
        public const int CF_ORIGINATED = 0x0040;
        public const int CF_QUEUED = 0x0020;
        public const int CF_RETRIEVED = 0x0010;
        public const int CF_SERVICE_INITIATED = 0x0008;
        public const int CF_TRANSFERRED = 0x0004;


        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct CSTAFeatureFilter_t
        {
            private byte filter;

            private CSTAFeatureFilter_t(byte value)
            {
                filter = value;
            }

            public static implicit operator CSTAFeatureFilter_t(byte value)
            {
                return new CSTAFeatureFilter_t(value);
            }

            public override string ToString()
            {
                return filter.ToString();
            }
        }
        public const byte FF_CALL_INFORMATION = 0x80;
        public const byte FF_DO_NOT_DISTURB = 0x40;
        public const byte FF_FORWARDING = 0x20;
        public const byte FF_MESSAGE_WAITING = 0x10;

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct CSTAAgentFilter_t
        {
            private byte filter;

            private CSTAAgentFilter_t(byte value)
            {
                filter = value;
            }

            public static implicit operator CSTAAgentFilter_t(byte value)
            {
                return new CSTAAgentFilter_t(value);
            }

            public override string ToString()
            {
                return filter.ToString();
            }
        }
       
        public const byte AF_LOGGED_ON = 0x80;
        public const byte AF_LOGGED_OFF = 0x40;
        public const byte AF_NOT_READY = 0x20;
        public const byte AF_READY  = 0x10;
        public const byte AF_WORK_NOT_READY = 0x08;
        public const byte AF_WORK_READY = 0x04;

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct CSTAMaintenanceFilter_t
        {
            private byte filter;

            private CSTAMaintenanceFilter_t(byte value)
            {
                filter = value;
            }

            public static implicit operator CSTAMaintenanceFilter_t(byte value)
            {
                return new CSTAMaintenanceFilter_t(value);
            }

            public override string ToString()
            {
                return filter.ToString();
            }
        }
        public const byte MF_BACK_IN_SERVICE = 0x80;
        public const byte MF_OUT_OF_SERVICE = 0x40;

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct CSTAMonitorFilter_t
        {
            CSTACallFilter_t call;
            CSTAFeatureFilter_t feature;
            CSTAAgentFilter_t agent;
            CSTAMaintenanceFilter_t maintenance;
            int privateFilter;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct CSTACallState_t
        {
            public int count;
            public IntPtr pState; //pointer to LocalConnectionState_t
        };

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct CSTASnapshotDeviceResponseInfo_t
        {
            public ConnectionID_t callIdentifier;
            public CSTACallState_t localCallState;
        };

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public class CSTASnapshotDeviceData_t
        {
            public int count;
            public IntPtr pInfo; //pointer to CSTASnapshotDeviceResponseInfo_t[]
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct CSTASnapshotCallResponseInfo_t
        {
            public ExtendedDeviceID_t deviceOnCall;
            public ConnectionID_t callIdentifier;
            public LocalConnectionState_t localConnectionState;
        };

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct CSTASnapshotCallData_t
        {
            public int count;
            public IntPtr pInfo; //Pointer to CSTASnapshotCallResponseInfo_t[]
        };

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct AccountInfo_t
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            private string _value;

            public AccountInfo_t(string value)
            {
                _value = value;
            }

            public static implicit operator AccountInfo_t(string value)
            {
                return new AccountInfo_t(value);
            }

            public override string ToString()
            {
                return _value;
            }
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public class AgentID_t
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            private string _value;

            public AgentID_t(string value)
            {
                _value = value;
            }

            public static implicit operator AgentID_t(string value)
            {
                return new AgentID_t(value);
            }

            public override string ToString()
            {
                return _value;
            }
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public class AgentGroup_t
        {
            internal DeviceID_t _value;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public class AgentPassword_t
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            private string _value;

            public AgentPassword_t(string value)
            {
                _value = value;
            }

            public static implicit operator AgentPassword_t(string value)
            {
                return new AgentPassword_t(value);
            }

            public override string ToString()
            {
                return _value;
            }
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct AuthCode_t
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            private string _value;

            public AuthCode_t(string value)
            {
                _value = value;
            }

            public static implicit operator AuthCode_t(string value)
            {
                return new AuthCode_t(value);
            }

            public override string ToString()
            {
                return _value;
            }
        }

        public enum ForwardingType_t
        {
            FWD_IMMEDIATE = 0,
            FWD_BUSY = 1,
            FWD_NO_ANS = 2,
            FWD_BUSY_INT = 3,
            FWD_BUSY_EXT = 4,
            FWD_NO_ANS_INT = 5,
            FWD_NO_ANS_EXT = 6
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct ForwardingInfo_t
        {
            ForwardingType_t forwardingType;
            bool forwardingOn;
            DeviceID_t forwardDN;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct ListForwardParameters_t
        {
            short count;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            ForwardingInfo_t[] param;
        }

        public enum SelectValue_t
        {
            SV_NORMAL = 0,
            SV_LEAST_COST = 1,
            SV_EMERGENCY = 2,
            SV_ACD = 3,
            SV_USER_DEFINED = 4
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct SetUpValues_t
        {
            int length;
            IntPtr value; // pointer to byte[]
            //unsigned char   FAR *value;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct RetryValue_t
        {
            private short _value;

            private RetryValue_t(short value)
            {
                _value = value;
            }

            public static implicit operator RetryValue_t(short value)
            {
                return new RetryValue_t(value);
            }

            public override string ToString()
            {
                return _value.ToString();
            }
        }
        public const short noListAvailable = -1;
        public const short noCountAvailable = -2;

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct RoutingCrossRefID_t
        {
            private int _value;

            private RoutingCrossRefID_t(int value)
            {
                _value = value;
            }

            public static implicit operator RoutingCrossRefID_t(int value)
            {
                return new RoutingCrossRefID_t(value);
            }

            public override string ToString()
            {
                return _value.ToString();
            }
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct RouteRegisterReqID_t
        {
            private int _value;

            private RouteRegisterReqID_t(int value)
            {
                _value = value;
            }

            public static implicit operator RouteRegisterReqID_t(int value)
            {
                return new RouteRegisterReqID_t(value);
            }

            public override string ToString()
            {
                return _value.ToString();
            }
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct CSTAAlternateCall_t
        {
            ConnectionID_t activeCall;
            ConnectionID_t otherCall;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct CSTAAlternateCallConfEvent_t
        {
            Acs.Nulltype dummy;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct CSTAAnswerCall_t
        {
            ConnectionID_t alertingCall;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct CSTAAnswerCallConfEvent_t
        {
            Acs.Nulltype dummy;
        }

        public enum Feature_t
        {
            FT_CAMP_ON = 0,
            FT_CALL_BACK = 1,
            FT_INTRUDE = 2
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct CSTACallCompletion_t
        {
            Feature_t feature;
            ConnectionID_t call;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct CSTACallCompletionConfEvent_t
        {
            Acs.Nulltype dummy;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct CSTAClearCall_t
        {
            ConnectionID_t call;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct CSTAClearCallConfEvent_t
        {
            Acs.Nulltype dummy;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct CSTAClearConnection_t
        {
            ConnectionID_t call;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct CSTAClearConnectionConfEvent_t
        {
            Acs.Nulltype dummy;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct CSTAConferenceCall_t
        {
            ConnectionID_t heldCall;
            ConnectionID_t activeCall;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct CSTAConferenceCallConfEvent_t
        {
            ConnectionID_t newCall;
            ConnectionList_t connList;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct CSTAConsultationCall_t
        {
            ConnectionID_t activeCall;
            DeviceID_t calledDevice;
        }

        public struct CSTAConsultationCallConfEvent_t
        {
            ConnectionID_t newCall;
        }

        public struct CSTADeflectCall_t
        {
            ConnectionID_t deflectCall;
            DeviceID_t calledDevice;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct CSTADeflectCallConfEvent_t
        {
            Acs.Nulltype dummy;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct CSTAPickupCall_t
        {
            ConnectionID_t deflectCall;
            DeviceID_t calledDevice;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct CSTAPickupCallConfEvent_t
        {
            Acs.Nulltype dummy;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct CSTAGroupPickupCall_t
        {
            ConnectionID_t deflectCall;
            DeviceID_t pickupDevice;
        }


        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct CSTAGroupPickupCallConfEvent_t
        {
            Acs.Nulltype dummy;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct CSTAHoldCall_t
        {
            ConnectionID_t activeCall;
            bool reservation;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct CSTAHoldCallConfEvent_t
        {
            Acs.Nulltype dummy;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct CSTAMakeCall_t
        {
            DeviceID_t callingDevice;
            DeviceID_t calledDevice;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct CSTAMakeCallConfEvent_t
        {
            ConnectionID_t newCall;
        }

        public enum AllocationState_t
        {
            AS_CALL_DELIVERED = 0,
            AS_CALL_ESTABLISHED = 1
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct CSTAMakePredictiveCall_t
        {
            DeviceID_t callingDevice;
            DeviceID_t calledDevice;
            AllocationState_t allocationState;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct CSTAMakePredictiveCallConfEvent_t
        {
            ConnectionID_t newCall;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct CSTAQueryMwi_t
        {
            DeviceID_t device;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct CSTAQueryMwiConfEvent_t
        {
            bool messages;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct CSTAQueryDnd_t
        {
            DeviceID_t device;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct CSTAQueryDndConfEvent_t
        {
            public bool doNotDisturb;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct CSTAQueryFwd_t
        {
            DeviceID_t device;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct CSTAQueryFwdConfEvent_t
        {
            ListForwardParameters_t forward;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct CSTAQueryAgentState_t
        {
            DeviceID_t device;
        }

        public enum AgentState_t
        {
            AG_NOT_READY = 0,
            AG_NULL = 1,
            AG_READY = 2,
            AG_WORK_NOT_READY = 3,
            AG_WORK_READY = 4
        };

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct CSTAQueryAgentStateConfEvent_t
        {
            public AgentState_t agentState;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct CSTAQueryLastNumber_t
        {
            DeviceID_t device;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct CSTAQueryLastNumberConfEvent_t
        {
            DeviceID_t lastNumber;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct CSTAQueryDeviceInfo_t
        {
            DeviceID_t device;
        }

        public enum DeviceType_t
        {
            DT_STATION = 0,
            DT_LINE = 1,
            DT_BUTTON = 2,
            DT_ACD = 3,
            DT_TRUNK = 4,
            DT_OPERATOR = 5,
            DT_STATION_GROUP = 16,
            DT_LINE_GROUP = 17,
            DT_BUTTON_GROUP = 18,
            DT_ACD_GROUP = 19,
            DT_TRUNK_GROUP = 20,
            DT_OPERATOR_GROUP = 21,
            DT_OTHER = 255
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct DeviceClass_t
        {
            byte _value;
            public override string ToString()
            {
                string s;
                switch (_value)
                {
                    case DC_VOICE:
                        return "DC_VOICE";
                    case DC_DATA:
                        return "DC_DATA";
                    case DC_IMAGE:
                        return "DC_IMAGE";
                    case DC_OTHER:
                        return "DC_OTHER";
                    default:
                        return _value.ToString();
                }
            }
        }
       
        public const byte DC_VOICE = 0x80;
        public const byte DC_DATA = 0x40;
        public const byte DC_IMAGE = 0x20;
        public const byte DC_OTHER = 0x10;

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct CSTAQueryDeviceInfoConfEvent_t
        {
            public DeviceID_t device;
            public DeviceType_t deviceType;
            public DeviceClass_t deviceClass;
        }

        public struct CSTAReconnectCall_t
        {
            ConnectionID_t activeCall;
            ConnectionID_t heldCall;
        }
        
        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct CSTAReconnectCallConfEvent_t
        {
            Acs.Nulltype dummy;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct CSTARetrieveCall_t
        {
            ConnectionID_t heldCall;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct CSTARetrieveCallConfEvent_t
        {
            Acs.Nulltype dummy;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct CSTASetMwi_t
        {
            DeviceID_t device;
            bool messages;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct CSTASetMwiConfEvent_t
        {
            Acs.Nulltype dummy;
        }

        public struct CSTASetDnd_t
        {
            DeviceID_t device;
            bool doNotDisturb;
        }

        public struct CSTASetDndConfEvent_t
        {
            Acs.Nulltype dummy;
        }

        public struct CSTASetFwd_t
        {
            DeviceID_t device;
            ForwardingInfo_t forward;
        }

        public struct CSTASetFwdConfEvent_t
        {
            Acs.Nulltype dummy;
        }

        public enum AgentMode_t
        {
            AM_LOG_IN = 0,
            AM_LOG_OUT = 1,
            AM_NOT_READY = 2,
            AM_READY = 3,
            AM_WORK_NOT_READY = 4,
            AM_WORK_READY = 5
        }

        public struct CSTASetAgentState_t
        {
            DeviceID_t device;
            AgentMode_t agentMode;
            AgentID_t agentID;
            AgentGroup_t agentGroup;
            AgentPassword_t agentPassword;
        }

        public struct CSTASetAgentStateConfEvent_t
        {
            Acs.Nulltype dummy;
        }

        public struct CSTATransferCall_t
        {
            ConnectionID_t heldCall;
            ConnectionID_t activeCall;
        }

        public struct CSTATransferCallConfEvent_t
        {
            ConnectionID_t newCall;
            ConnectionList_t connList;
        }

        public struct CSTAUniversalFailureConfEvent_t
        {
            public CSTAUniversalFailure_t error;
        }

        public struct CSTACallClearedEvent_t
        {
            ConnectionID_t clearedCall;
            LocalConnectionState_t localConnectionInfo;
            CSTAEventCause_t cause;
        }

        public struct CSTAConferencedEvent_t
        {
            ConnectionID_t primaryOldCall;
            ConnectionID_t secondaryOldCall;
            SubjectDeviceID_t confController;
            SubjectDeviceID_t addedParty;
            ConnectionList_t conferenceConnections;
            LocalConnectionState_t localConnectionInfo;
            CSTAEventCause_t cause;
        }

        public struct CSTAConnectionClearedEvent_t
        {
            ConnectionID_t droppedConnection;
            SubjectDeviceID_t releasingDevice;
            LocalConnectionState_t localConnectionInfo;
            CSTAEventCause_t cause;
        }

        public struct CSTADeliveredEvent_t
        {
            ConnectionID_t connection;
            SubjectDeviceID_t alertingDevice;
            CallingDeviceID_t callingDevice;
            CalledDeviceID_t calledDevice;
            RedirectionDeviceID_t lastRedirectionDevice;
            LocalConnectionState_t localConnectionInfo;
            CSTAEventCause_t cause;
        }

        public struct CSTADivertedEvent_t
        {
            ConnectionID_t connection;
            SubjectDeviceID_t divertingDevice;
            CalledDeviceID_t newDestination;
            LocalConnectionState_t localConnectionInfo;
            CSTAEventCause_t cause;
        }

        public struct CSTAEstablishedEvent_t
        {
            ConnectionID_t establishedConnection;
            SubjectDeviceID_t answeringDevice;
            CallingDeviceID_t callingDevice;
            CalledDeviceID_t calledDevice;
            RedirectionDeviceID_t lastRedirectionDevice;
            LocalConnectionState_t localConnectionInfo;
            CSTAEventCause_t cause;
        }

        public struct CSTAFailedEvent_t
        {
            ConnectionID_t failedConnection;
            SubjectDeviceID_t failingDevice;
            CalledDeviceID_t calledDevice;
            LocalConnectionState_t localConnectionInfo;
            CSTAEventCause_t cause;
        }

        public struct CSTAHeldEvent_t
        {
            ConnectionID_t heldConnection;
            SubjectDeviceID_t holdingDevice;
            LocalConnectionState_t localConnectionInfo;
            CSTAEventCause_t cause;
        }

        public struct CSTANetworkReachedEvent_t
        {
            ConnectionID_t connection;
            SubjectDeviceID_t trunkUsed;
            CalledDeviceID_t calledDevice;
            LocalConnectionState_t localConnectionInfo;
            CSTAEventCause_t cause;
        }

        public struct CSTAOriginatedEvent_t
        {
            ConnectionID_t originatedConnection;
            SubjectDeviceID_t callingDevice;
            CalledDeviceID_t calledDevice;
            LocalConnectionState_t localConnectionInfo;
            CSTAEventCause_t cause;
        }

        public struct CSTAQueuedEvent_t
        {
            ConnectionID_t queuedConnection;
            SubjectDeviceID_t queue;
            CallingDeviceID_t callingDevice;
            CalledDeviceID_t calledDevice;
            RedirectionDeviceID_t lastRedirectionDevice;
            short numberQueued;
            LocalConnectionState_t localConnectionInfo;
            CSTAEventCause_t cause;
        }

        public struct CSTARetrievedEvent_t
        {
            ConnectionID_t retrievedConnection;
            SubjectDeviceID_t retrievingDevice;
            LocalConnectionState_t localConnectionInfo;
            CSTAEventCause_t cause;
        }

        public struct CSTAServiceInitiatedEvent_t
        {
            ConnectionID_t initiatedConnection;
            LocalConnectionState_t localConnectionInfo;
            CSTAEventCause_t cause;
        }

        public struct CSTATransferredEvent_t
        {
            ConnectionID_t primaryOldCall;
            ConnectionID_t secondaryOldCall;
            SubjectDeviceID_t transferringDevice;
            SubjectDeviceID_t transferredDevice;
            ConnectionList_t transferredConnections;
            LocalConnectionState_t localConnectionInfo;
            CSTAEventCause_t cause;
        }

        public struct CSTACallInformationEvent_t
        {
            ConnectionID_t connection;
            SubjectDeviceID_t device;
            AccountInfo_t accountInfo;
            AuthCode_t authorisationCode;
        }

        public struct CSTADoNotDisturbEvent_t
        {
            SubjectDeviceID_t device;
            bool doNotDisturbOn;
        }

        public struct CSTAForwardingEvent_t
        {
            SubjectDeviceID_t device;
            ForwardingInfo_t forwardingInformation;
        }

        public struct CSTAMessageWaitingEvent_t
        {
            CalledDeviceID_t deviceForMessage;
            SubjectDeviceID_t invokingDevice;
            bool messageWaitingOn;
        }

        public struct CSTALoggedOnEvent_t
        {
            SubjectDeviceID_t agentDevice;
            AgentID_t agentID;
            AgentGroup_t agentGroup;
            AgentPassword_t password;
        }

        public struct CSTALoggedOffEvent_t
        {
            SubjectDeviceID_t agentDevice;
            AgentID_t agentID;
            AgentGroup_t agentGroup;
        }

        public struct CSTANotReadyEvent_t
        {
            SubjectDeviceID_t agentDevice;
            AgentID_t agentID;
        }

        public struct CSTAReadyEvent_t
        {
            SubjectDeviceID_t agentDevice;
            AgentID_t agentID;
        }
        
        public struct CSTAWorkNotReadyEvent_t
        {
            SubjectDeviceID_t agentDevice;
            AgentID_t agentID;
        }

        public struct CSTAWorkReadyEvent_t
        {
            SubjectDeviceID_t agentDevice;
            AgentID_t agentID;
        }

        public struct CSTARouteRegisterReq_t
        {
            DeviceID_t routingDevice;
        }

        public struct CSTARouteRegisterReqConfEvent_t
        {
            RouteRegisterReqID_t registerReqID;
        }

        public struct CSTARouteRegisterCancel_t
        {
            RouteRegisterReqID_t routeRegisterReqID;
        }

        public struct CSTARouteRegisterCancelConfEvent_t
        {
            RouteRegisterReqID_t routeRegisterReqID;
        }

        public struct CSTARouteRegisterAbortEvent_t
        {
            RouteRegisterReqID_t routeRegisterReqID;
        }

        public struct CSTARouteRequestEvent_t
        {
            RouteRegisterReqID_t routeRegisterReqID;
            RoutingCrossRefID_t routingCrossRefID;
            DeviceID_t currentRoute;
            DeviceID_t callingDevice;
            ConnectionID_t routedCall;
            SelectValue_t routedSelAlgorithm;
            bool priority;
            SetUpValues_t setupInformation;
        }

        public struct CSTARouteSelectRequest_t
        {
            RouteRegisterReqID_t routeRegisterReqID;
            RoutingCrossRefID_t routingCrossRefID;
            DeviceID_t routeSelected;
            RetryValue_t remainRetry;
            SetUpValues_t setupInformation;
            bool routeUsedReq;
        }

        public struct CSTAReRouteRequest_t
        {
            RouteRegisterReqID_t routeRegisterReqID;
            RoutingCrossRefID_t routingCrossRefID;
        }

        public struct CSTARouteUsedEvent_t
        {
            RouteRegisterReqID_t routeRegisterReqID;
            RoutingCrossRefID_t routingCrossRefID;
            DeviceID_t routeUsed;
            DeviceID_t callingDevice;
            bool domain;
        }

        public struct CSTARouteEndEvent_t
        {
            RouteRegisterReqID_t routeRegisterReqID;
            RoutingCrossRefID_t routingCrossRefID;
            CSTAUniversalFailure_t errorValue;
        }

        public struct CSTARouteEndRequest_t
        {
            RouteRegisterReqID_t routeRegisterReqID;
            RoutingCrossRefID_t routingCrossRefID;
            CSTAUniversalFailure_t errorValue;
        }
        
        public struct CSTAEscapeSvc_t {
            Acs.Nulltype        dummy;
        }

        public struct CSTAEscapeSvcConfEvent_t
        {
            Acs.Nulltype dummy;
        }

        public struct CSTAEscapeSvcReqEvent_t
        {
            Acs.Nulltype dummy;
        }

        public struct CSTAEscapeSvcReqConf_t
        {
            CSTAUniversalFailure_t errorValue;
        }

        public struct CSTAPrivateEvent_t
        {
            Acs.Nulltype dummy;
        }

        public struct CSTAPrivateStatusEvent_t
        {
            Acs.Nulltype dummy;
        }

        public struct CSTASendPrivateEvent_t
        {
            Acs.Nulltype dummy;
        }

        public struct CSTABackInServiceEvent_t
        {
            DeviceID_t device;
            CSTAEventCause_t cause;
        }

        public struct CSTAOutOfServiceEvent_t
        {
            DeviceID_t device;
            CSTAEventCause_t cause;
        }

        public enum SystemStatus_t
        {
            SS_INITIALIZING = 0,
            SS_ENABLED = 1,
            SS_NORMAL = 2,
            SS_MESSAGES_LOST = 3,
            SS_DISABLED = 4,
            SS_OVERLOAD_IMMINENT = 5,
            SS_OVERLOAD_REACHED = 6,
            SS_OVERLOAD_RELIEVED = 7
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct SystemStatusFilter_t
        {
            byte _value;
        }
   
        public const byte SF_INITIALIZING = 0x80;
        public const byte SF_ENABLED = 0x40;
        public const byte SF_NORMAL = 0x20;
        public const byte SF_MESSAGES_LOST = 0x10;
        public const byte SF_DISABLED = 0x08;
        public const byte SF_OVERLOAD_IMMINENT = 0x04;
        public const byte SF_OVERLOAD_REACHED = 0x02;
        public const byte SF_OVERLOAD_RELIEVED = 0x01;

        public struct CSTAReqSysStat_t
        {
            Acs.Nulltype dummy;
        }

        public struct CSTASysStatReqConfEvent_t
        {
            SystemStatus_t systemStatus;
        }

        public struct CSTASysStatStart_t
        {
            SystemStatusFilter_t statusFilter;
        }

        public struct CSTASysStatStartConfEvent_t
        {
            SystemStatusFilter_t statusFilter;
        }

        public struct CSTASysStatStop_t
        {
            Acs.Nulltype dummy;
        }

        public struct CSTASysStatStopConfEvent_t
        {
            Acs.Nulltype dummy;
        }

        public struct CSTAChangeSysStatFilter_t
        {
            SystemStatusFilter_t statusFilter;
        }

        public struct CSTAChangeSysStatFilterConfEvent_t
        {
            SystemStatusFilter_t statusFilterSelected;
            SystemStatusFilter_t statusFilterActive;
        }

        public struct CSTASysStatEvent_t
        {
            SystemStatus_t systemStatus;
        }

        public struct CSTASysStatEndedEvent_t
        {
            Acs.Nulltype dummy;
        }

        public struct CSTASysStatReqEvent_t
        {
            Acs.Nulltype dummy;
        }

        public struct CSTAReqSysStatConf_t
        {
            SystemStatus_t systemStatus;
        }

        public struct CSTASysStatEventSend_t
        {
            SystemStatus_t systemStatus;
        }

        public struct CSTAMonitorDevice_t
        {
            DeviceID_t deviceID;
            CSTAMonitorFilter_t monitorFilter;
        }

        public struct CSTAMonitorCall_t
        {
            ConnectionID_t call;
            CSTAMonitorFilter_t monitorFilter;
        }

        public struct CSTAMonitorCallsViaDevice_t
        {
            DeviceID_t deviceID;
            CSTAMonitorFilter_t monitorFilter;
        }

        public struct CSTAMonitorConfEvent_t
        {
            CSTAMonitorCrossRefID_t monitorCrossRefID;
            CSTAMonitorFilter_t monitorFilter;
        }

        public struct CSTAChangeMonitorFilter_t
        {
            CSTAMonitorCrossRefID_t monitorCrossRefID;
            CSTAMonitorFilter_t monitorFilter;
        }

        public struct CSTAChangeMonitorFilterConfEvent_t
        {
            CSTAMonitorFilter_t monitorFilter;
        }

        public struct CSTAMonitorStop_t
        {
            CSTAMonitorCrossRefID_t monitorCrossRefID;
        }

        public struct CSTAMonitorStopConfEvent_t
        {
            Acs.Nulltype dummy;
        }

        public struct CSTAMonitorEndedEvent_t
        {
            CSTAEventCause_t cause;
        }

        public struct CSTASnapshotCall_t
        {
            ConnectionID_t snapshotObject;
        }
        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public class CSTASnapshotCallConfEvent_t
        {
            public CSTASnapshotCallData_t snapshotData;
        }

        public struct CSTASnapshotDevice_t
        {
            DeviceID_t snapshotObject;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public class CSTASnapshotDeviceConfEvent_t
        {
            public CSTASnapshotDeviceData_t snapshotData;
        }

        public struct CSTAGetAPICaps_t
        {
            Acs.Nulltype dummy;
        }

        public struct CSTAGetAPICapsConfEvent_t
        {
            public short alternateCall;
            public short answerCall;
            public short callCompletion;
            public short clearCall;
            public short clearConnection;
            public short conferenceCall;
            public short consultationCall;
            public short deflectCall;
            public short pickupCall;
            public short groupPickupCall;
            public short holdCall;
            public short makeCall;
            public short makePredictiveCall;
            public short queryMwi;
            public short queryDnd;
            public short queryFwd;
            public short queryAgentState;
            public short queryLastNumber;
            public short queryDeviceInfo;
            public short reconnectCall;
            public short retrieveCall;
            public short setMwi;
            public short setDnd;
            public short setFwd;
            public short setAgentState;
            public short transferCall;
            public short eventReport;
            public short callClearedEvent;
            public short conferencedEvent;
            public short connectionClearedEvent;
            public short deliveredEvent;
            public short divertedEvent;
            public short establishedEvent;
            public short failedEvent;
            public short heldEvent;
            public short networkReachedEvent;
            public short originatedEvent;
            public short queuedEvent;
            public short retrievedEvent;
            public short serviceInitiatedEvent;
            public short transferredEvent;
            public short callInformationEvent;
            public short doNotDisturbEvent;
            public short forwardingEvent;
            public short messageWaitingEvent;
            public short loggedOnEvent;
            public short loggedOffEvent;
            public short notReadyEvent;
            public short readyEvent;
            public short workNotReadyEvent;
            public short workReadyEvent;
            public short backInServiceEvent;
            public short outOfServiceEvent;
            public short privateEvent;
            public short routeRequestEvent;
            public short reRoute;
            public short routeSelect;
            public short routeUsedEvent;
            public short routeEndEvent;
            public short monitorDevice;
            public short monitorCall;
            public short monitorCallsViaDevice;
            public short changeMonitorFilter;
            public short monitorStop;
            public short monitorEnded;
            public short snapshotDeviceReq;
            public short snapshotCallReq;
            public short escapeService;
            public short privateStatusEvent;
            public short escapeServiceEvent;
            public short escapeServiceConf;
            public short sendPrivateEvent;
            public short sysStatReq;
            public short sysStatStart;
            public short sysStatStop;
            public short changeSysStatFilter;
            public short sysStatReqEvent;
            public short sysStatReqConf;
            public short sysStatEvent;
        }

        public enum CSTALevel_t
        {
            CSTA_HOME_WORK_TOP = 1,
            CSTA_AWAY_WORK_TOP = 2,
            CSTA_DEVICE_DEVICE_MONITOR = 3,
            CSTA_CALL_DEVICE_MONITOR = 4,
            CSTA_CALL_CONTROL = 5,
            CSTA_ROUTING = 6,
            CSTA_CALL_CALL_MONITOR = 7
        }

        public enum SDBLevel_t
        {
            NO_SDB_CHECKING = -1,
            ACS_ONLY = 1,
            ACS_AND_CSTA_CHECKING = 0
        }

        public struct CSTAGetDeviceList_t
        {
            long index;
            CSTALevel_t level;
        }
        
        public struct DeviceList_t {
            public short count;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
            public DeviceID_t[] device;
        }

        public struct CSTAGetDeviceListConfEvent_t
        {
            public SDBLevel_t driverSdbLevel;
            public CSTALevel_t level;
            public int index;
            public DeviceList_t devList;
        }

        public struct CSTAQueryCallMonitor_t
        {
            Acs.Nulltype dummy;
        }
        
        public struct CSTAQueryCallMonitorConfEvent_t 
        {
           public bool callMonitor;
        }

        public struct CSTARouteRequestExtEvent_t 
        {
            RouteRegisterReqID_t routeRegisterReqID;
            RoutingCrossRefID_t routingCrossRefID;
            CalledDeviceID_t currentRoute;
            CallingDeviceID_t callingDevice;
            ConnectionID_t  routedCall;
            SelectValue_t   routedSelAlgorithm;
            bool         priority;
            SetUpValues_t   setupInformation;
        }
        
        public struct CSTARouteUsedExtEvent_t 
        {
            RouteRegisterReqID_t routeRegisterReqID;
            RoutingCrossRefID_t routingCrossRefID;
            CalledDeviceID_t routeUsed;
            CallingDeviceID_t callingDevice;
            bool         domain;
        }

        public struct CSTARouteSelectInvRequest_t 
        {
            CSTARouteSelectRequest_t _value;
        }

        public struct CSTARouteEndInvRequest_t
        {
            CSTARouteEndRequest_t _value;
        }  
    }
}
