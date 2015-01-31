using System;
using System.Runtime.InteropServices;

namespace Tsapi
{
    public static partial class Acs
    {
        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct ACSHandle_t
        {
            private uint acsHandle;
            public override string ToString()
            {
                return acsHandle.ToString();
            }
        };

        public struct Nulltype
        {
            byte dummy;
        }
    }
}
