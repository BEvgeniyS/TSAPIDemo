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

