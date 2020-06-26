using System;
using System.Collections.Generic;
using System.Text;

namespace AAUtilities
{
    public static class AssemblyHelper
    {
        public static string AppPath => System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
        public static string AppPath2
        {
            get
            {
                string codeBase = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                return System.IO.Path.GetDirectoryName(Uri.UnescapeDataString((new UriBuilder(codeBase)).Path));
            }
        }

        public static string Version
        {

            get
            {
                var ver = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
                return string.Format("{0}.{1}.{2}", ver.Major, ver.Minor, ver.Build);
            }
        }

        public static string Name => System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;


    }
}
