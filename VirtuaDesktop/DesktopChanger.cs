﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace VirtuaDesktop
{
    class DesktopChanger
    {

            private static class KnownFolder
            {
                public static Guid Desktop = new Guid("B4BFCC3A-DB2C-424C-B029-7FE99A87C641");
            }

            [DllImport("shell32.dll")]
            private extern static int SHSetKnownFolderPath(ref Guid folderId, uint flags, IntPtr token, [MarshalAs(UnmanagedType.LPWStr)] string path);
            [DllImport("Shell32.dll")]
            private static extern int SHChangeNotify(int eventId, int flags, IntPtr item1, IntPtr item2);

            public static void Change_Desktop(string newPath)
            {
                int flags = 0;
                SHSetKnownFolderPath(ref KnownFolder.Desktop, (uint)flags, IntPtr.Zero, newPath);
                SHChangeNotify(0x8000000, 0x1000, IntPtr.Zero, IntPtr.Zero);
            }

    }
}
