using System;
using System.Runtime.InteropServices;

namespace Tsapi
{
    public static partial class Acs
    {
        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct ACSHandle_t
        {
            public uint _value;
            public override string ToString()
            {
                return _value.ToString();
            }
        };

        public struct Nulltype
        {
            byte dummy;
        }
    }
}
