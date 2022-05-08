using System;
using System.Runtime.InteropServices;

namespace thesisUI
{
    internal static class NativeMethods
    {
        [DllImport("thesis.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "imageProcess"
            , ExactSpelling = true, SetLastError = false, CharSet = CharSet.Ansi)]
        //[DllImport("thesis.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        //[DllImport("thesis.dll", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.SysInt)]
        public static extern IntPtr imageProcess([MarshalAs(UnmanagedType.AnsiBStr)] string filename);
        //internal static extern IntPtr imageProcess();

    }
}
