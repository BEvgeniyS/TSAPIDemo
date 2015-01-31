using System;
using System.Runtime.InteropServices;

namespace Tsapi
{
    public static partial class Acs
    {
        public const int ACS_MAX_SERVICEID = 48;    // maximum size name of the 
								                    // advertized service name

        public const int ACS_MAX_LOGINID = 48;      // maximum size login name of
								                    // a user

        public const int ACS_MAX_PASSWORD = 48;     // maximum size password name
								                    // of a user
        
        public const int ACS_MAX_APPNAME = 20;      // maximum size application name of 
					 			                    // a user

        public const int MAX_VERSION_LEN = 20;

        public const int MAX_SDB_DEVICE = 15;	    // Size of device ID in SDB
    }
}
