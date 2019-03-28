using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMAH1
{
    public static class RunningEnvironment
    {
        private enum MonoDetect
        {
            Unknown,
            Yes,
            No
        }

        private static MonoDetect runningOnMono = MonoDetect.Unknown;

        public static bool IsLinux
        {
            get
            {
                OperatingSystem os = Environment.OSVersion;

                if (os.Platform == PlatformID.Unix)
                    return true;

                return false;
            }
        }

        public static bool IsWindows
        {
            get
            {
                OperatingSystem os = Environment.OSVersion;

                if (os.Platform == PlatformID.Win32NT)
                    return true;
                if (os.Platform == PlatformID.Win32S)
                    return true;
                if (os.Platform == PlatformID.Win32Windows)
                    return true;
                if (os.Platform == PlatformID.WinCE)
                    return true;

                return false;
            }
        }

        public static bool IsRunningOnMono
        {
            get
            {
                if (runningOnMono == MonoDetect.Unknown)
                {
                    if (Type.GetType("Mono.Runtime") != null)
                        runningOnMono = MonoDetect.Yes;
                    else
                        runningOnMono = MonoDetect.No;
                }
                return (runningOnMono == MonoDetect.Yes);
            }
        }
    }
}
