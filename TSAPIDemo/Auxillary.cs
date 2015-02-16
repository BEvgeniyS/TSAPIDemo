using System;
using System.Runtime.InteropServices;

namespace Tsapi
{
    class Aux
    {
        public static T ByteArrayToStructure<T>(byte[] bytes)// where T : struct
        {
            GCHandle handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            T data = (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));
            handle.Free();
            return data;
        }

        public static byte[] StructureToByteArray<T>(T obj)
        {
            int len = Marshal.SizeOf(typeof(T));
            var arr = new byte[len];
            IntPtr ptr = IntPtr.Zero;
            try
            {
                ptr = Marshal.AllocHGlobal(len);
                Marshal.StructureToPtr(obj, ptr, true);
                Marshal.Copy(ptr, arr, 0, len);
            }
            finally
            {
                if (ptr != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(ptr);
                }
            }
            return arr;
        }

        public static short[] SplitPtr(IntPtr dwordValue)
        {
            var result = new short[2];
            result[0] = unchecked((short)dwordValue);
            result[1] = unchecked((short)((uint)dwordValue >> 16));
            return result;
        }

    }
}

