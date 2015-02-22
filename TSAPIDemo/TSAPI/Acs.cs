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
    using HWND = System.IntPtr;
    public static partial class Acs
    {
        public const int TSERV_SAP_CSTA = 0x0559;	// For CSTA TServers

        // SAP advertising number client uses to find the Tserver is the same number
        // which has first been byte swapped.
        public const int CLIENT_SAP_CSTA = 0x5905;  // For CSTA Clients 

        // SAP advertising for Name Server Queries
        public const int TSERV_SAP_NMSRV = 0x055B;	// For Name Services on Tsrv 

        // SAP advertising number client uses to find the Name Server is the same number
        // which has first been byte swapped.
        public const int CLIENT_SAP_NMSRV = 0x5B05;  // For Name Service Clients

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct RetCode_t
        {
            public short _value;

            public RetCode_t(short value)
            {
                _value = value;
            }

            public static implicit operator RetCode_t(short value)
            {
                return new RetCode_t(value);
            }

            public override string ToString()
            {
                return _value.ToString();
            }

        }

        public const int	ACSPOSITIVE_ACK = 0;	// The function was successful 					

        #region ACS Error Codes

        public const int	ACSERR_APIVERDENIED	= -1;	// This return indicates that the 
                                                        // API Version requested is invalid
                                                        // and not supported by the
                                                        // existing API Client Library.

        public const int	ACSERR_BADPARAMETER = -2;	// One or more of the parameters is
                                                        // invalid

        public const int	ACSERR_DUPSTREAM = -3;	// This return indicates that an
                                                    // ACS Stream is already established
                                                    // with the requested Server.

        public const int	ACSERR_NODRIVER = -4;	// This error return value indicates 
                                                    // that no API Client Library Driver
                                                    // was found or installed on the system.

        public const int	ACSERR_NOSERVER	= -5;	// This indicates that the requested 
                                                    // Server is not present in the network.

        public const int	ACSERR_NORESOURCE = -6;	// This return value indicates that 
                                                    // there are insufficient resources
                                                    // to open a ACS Stream.

        public const int	ACSERR_UBUFSMALL = -7;	// The user buffer size was smaller 
                                                    // than the size of the next available
                                                    // event.									         

        public const int	ACSERR_NOMESSAGE = -8;	// There were no messages available to 
                                                    // return to the application.
									         
        public const int	ACSERR_UNKNOWN = -9;    // The ACS Stream has encountered
                                                    // an unspecified error.

        public const int	ACSERR_BADHDL = -10;    // The ACS Handle is invalid 

        public const int	ACSERR_STREAM_FAILED = -11;	// The ACS Stream has failed
                                                        // due to network problems.
                                                        // No further operations are
                                                        // possible on this stream.

        public const int	ACSERR_NOBUFFERS = -12;	// There were not enough buffers 
                                                    // available to place an outgoing
                                                    // message on the send queue.
                                                    // No message has been sent.

        public const int	ACSERR_QUEUE_FULL = -13;    // The send queue is full. 
                                                        // No message has been sent.

        #endregion

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct InvokeID_t
        {
            private uint invokeID;

            public override string ToString()
            {
                return invokeID.ToString();
            }
        };

        public enum InvokeIDType_t
        {
            APP_GEN_ID,		/* application will provide invokeIDs; any 4-byte value is legal */
            LIB_GEN_ID		/* library will generate invokeIDs in the range 1-32767 */
        };

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct EventClass_t
        {
            public ushort eventClass;
            public override string ToString()
            {
                return eventClass.ToString();
            }
        };
        
        // defines for ACS event classes 
        public const int ACSREQUEST = 0;
        public const int ACSUNSOLICITED = 1;
        public const int ACSCONFIRMATION = 2;

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct EventType_t
        {
            public ushort eventType;
            public override string ToString()
            {
                return eventType.ToString();
            }
        };

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct ACSEventHeader_t
        {
            public ACSHandle_t acsHandle; // 4 bytes
            public EventClass_t eventClass; // 2 bytes
            public EventType_t eventType; // 2 bytes
        };

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct ACSUnsolicitedEvent
        {
            ACSUniversalFailureEvent_t failureEvent;
        };

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct ACSConfirmationEvent
        {
            InvokeID_t invokeID;   // 4 bytes
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = (ACS_MAX_HEAP - 12))]
            private byte[] heap;
            public ACSOpenStreamConfEvent_t acsopen
            {
                get
                {
                    return Aux.ByteArrayToStructure<ACSOpenStreamConfEvent_t>(heap);
                }
            }
            public ACSCloseStreamConfEvent_t acsclose
            {
                get
                {
                    return Aux.ByteArrayToStructure<ACSCloseStreamConfEvent_t>(heap);
                }
            }
            public ACSUniversalFailureConfEvent_t failureEvent
            {
                get
                {
                    return Aux.ByteArrayToStructure<ACSUniversalFailureConfEvent_t>(heap);
                }
            }
        }

        public const int ACS_MAX_HEAP = 1024;

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct Passwd_t
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = ACS_MAX_PASSWORD)]
            private string passwd;

            public Passwd_t(string value)
            {
                passwd = value;
            }

            public static implicit operator Passwd_t(string value)
            {
                return new Passwd_t(value);
            }

            public override string ToString()
            {
                return passwd.ToString();
            }
        };

        public const int PRIVATE_VENDOR_SIZE = 32;

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public class PrivateData_t
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = PRIVATE_VENDOR_SIZE)]
            public string vendor;
            public ushort length;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
            public byte[] data;
        };
        
        public const int PRIVATE_DATA_ENCODING = 0;

        [DllImport("csta32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern RetCode_t acsOpenStream(
                            out ACSHandle_t acsHandle,
                            InvokeIDType_t invokeIDType,
                            InvokeID_t invokeID,
                            StreamType_t streamType,
                            ref ServerID_t serverID,
                            ref LoginID_t loginID,
                            ref Passwd_t passwd,
                            ref AppName_t applicationName,
                            Level_t acsLevelReq,
                            ref Version_t apiVer,
                            ushort sendQSize,
                            ushort sendExtraBufs,
                            ushort recvQSize,
                            ushort recvExtraBufs,
                            PrivateData_t priv);

        [DllImport("csta32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern RetCode_t acsCloseStream(
                            ACSHandle_t acsHandle,
                            InvokeID_t invokeID,
                            PrivateData_t priv);

        [DllImport("csta32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern RetCode_t acsAbortStream(
                            ACSHandle_t acsHandle,
                            PrivateData_t privateData);


        [DllImport("csta32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern RetCode_t acsFlushEventQueue(
                            ACSHandle_t acsHandle);
        
        [DllImport("csta32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern RetCode_t acsGetEventPoll(
                            ACSHandle_t acsHandle,
                            [In, Out, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Csta.EventBuffer_t))] Csta.EventBuffer_t eventBuf,
                            ref ushort eventBufSize,
                            PrivateData_t privData,
                            out ushort numEvents);

        [DllImport("csta32.dll", CharSet = CharSet.Ansi)]
        public static extern RetCode_t acsGetEventBlock(
                            ACSHandle_t acsHandle,
                            [In, Out, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Csta.EventBuffer_t))] Csta.EventBuffer_t eventBuf,
                            ref ushort eventBufSize,
                            [In, Out]
                            PrivateData_t privData,
                            out ushort numEvents);


        [DllImport("csta32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern RetCode_t acsEventNotify(
                            ACSHandle_t acsHandle,
                            HWND hwnd,
                            uint msg,
                            bool notifyAll);

        [DllImport("csta32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern RetCode_t acsQueryAuthInfo(
                            ref ServerID_t serverID,
                            ref ACSAuthInfo_t authInfo);

        [DllImport("csta32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern RetCode_t acsSetESR(
                            ACSHandle_t acsHandle,
                            //[MarshalAs(UnmanagedType.FunctionPtr)]
                            EsrDelegate esr,
                            uint esrparam,
                            bool notifyAll);

        //[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void EsrDelegate(uint esrparam);

        public delegate bool EnumServerNamesCB(
                            [MarshalAs(UnmanagedType.LPStr)]
                            System.Text.StringBuilder serverName,
                            uint lParam
                            );

        [DllImport("csta32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern RetCode_t acsEnumServerNames(
                            StreamType_t streamType,
                            EnumServerNamesCB callback,
                            uint lParam);

        [DllImport("csta32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern RetCode_t acsSetHeartbeatInterval(
                            ACSHandle_t acsHandle,
                            InvokeID_t invokeID,
                            ushort heartbeatInterval,
                            PrivateData_t privateData);
    }
    public class EnumServerHandler
    {
        private string _serverName;
        public string serverName 
        { 
            get
            {
                return _serverName;
            }
        }
        public bool acsEnumServerNamesCallbackHandler(System.Text.StringBuilder serverNameSB, uint lParam)
        {
            System.Diagnostics.Debug.WriteLine("[acsEnumServerNames Test] server = " + serverNameSB);
            string serverName = serverNameSB.ToString();
            if (serverName != string.Empty)
            {
                this._serverName = serverName;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}