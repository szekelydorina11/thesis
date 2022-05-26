using System;
using System.Runtime.InteropServices;

namespace thesisUI
{
    internal static class NativeMethods
    {
        [DllImport("thesis.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "imageProcess"
            , ExactSpelling = true, SetLastError = false, CharSet = CharSet.Ansi)]
        //[DllImport("thesis.dll", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.SysInt)]
        //[return: MarshalAs(UnmanagedType.AnsiBStr)]
        public static extern IntPtr imageProcess([MarshalAs(UnmanagedType.AnsiBStr)] string filename);

    }
}
