using System;
using System.Runtime.InteropServices;
using System.Runtime.Loader;

namespace ClassLibraryTest
{
    public static class TestEg
    {// CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall
        [DllImport("BenDing.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int Test(int a, int b);

        public static int Ceishi(int a, int b)
        {
            
            return a + b;
        }
    }
}
