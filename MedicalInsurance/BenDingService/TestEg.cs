using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace BenDingService
{
    [StructLayout(LayoutKind.Sequential)]
    public static class TestEg
    {// CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall
        [DllImport("BenDing.dll", EntryPoint = "Test", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int Test(int a, int b);
        [DllImport("BenDing.dll", EntryPoint = "GetSqlData", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void GetSqlData(string ASource, StringBuilder ADest, int ADestSize);
        [DllImport("BenDing.dll", EntryPoint = "SayHello", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern string SayHello();
        [DllImport("BenDing.dll", EntryPoint = "GetString", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetString(StringBuilder str, int len);
        [DllImport("BenDing.dll", EntryPoint = "GetRates", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Boolean GetRates(StringBuilder str, string a);

        [DllImport("BenDing.dll", EntryPoint = "GetRatesString", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetRatesString(StringBuilder str, StringBuilder strd);
    }
}
