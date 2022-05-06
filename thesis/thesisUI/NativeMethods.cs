using System;
using System.Runtime.InteropServices;

namespace thesisUI
{
    internal static class NativeMethods
    {
        [DllImport("thesis.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = false, 
            SetLastError = false, CharSet = CharSet.Auto, ThrowOnUnmappableChar = true)]
        //[DllImport("thesis.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        //[DllImport("thesis.dll", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        //[return: MarshalAs(unmanagedType: UnmanagedType.U4)]
        internal static extern Int32 imageProcess([MarshalAs(UnmanagedType.LPStr)] string filename);

    }
}
