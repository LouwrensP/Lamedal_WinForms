using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Lamedal_UIWinForms.libUI.Win32
{
    public static class user32
    {
        /// <summary>
        /// Destroys an icon and frees any memory the icon occupied.
        /// </summary>
        /// <param name="handle">A handle to the icon to be destroyed. The icon must not be in use.</param>
        /// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero.</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public extern static bool DestroyIcon(IntPtr handle);

        #region SetWinEventHook

        [DllImport("user32.dll")]
        public static extern IntPtr SetWinEventHook(uint eventMin, uint eventMax, IntPtr hmodWinEventProc, SetWinEventHook_delegate lpfnUser32WinEventProc, uint idProcess, uint idThread, uint dwFlags);

        public delegate void SetWinEventHook_delegate(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime);

        public static IntPtr SetWinEventHook(SetWinEventHook_delegate user32WinEvent)
        {
            // user32WinEvent needs to be defined as a field as in following example:
            // _OnWindowsActivate = OnWindowsActivate;
            // user32.SetWinEventHook(_OnWindowsActivate);
            return SetWinEventHook(EVENT_SYSTEM_FOREGROUND, EVENT_SYSTEM_FOREGROUND, IntPtr.Zero, user32WinEvent, 0, 0, WINEVENT_OUTOFCONTEXT);
        }

        private const uint WINEVENT_OUTOFCONTEXT = 0;
        private const uint EVENT_SYSTEM_FOREGROUND = 3;

        #endregion

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        #region GetWindowText

        [DllImport("user32.dll")]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        private static string Window_GetText(IntPtr handle)
        {
            const int nChars = 256;
            var Buff = new StringBuilder(nChars);
            if (GetWindowText(handle, Buff, nChars) > 0) return Buff.ToString();
            return null;
        }

        /// <summary>Gets the text of the active window.</summary>
        /// <returns>string</returns>
        public static string Window_GetText_FromForgroundWindow()
        {
            IntPtr handle = GetForegroundWindow();
            return Window_GetText(handle);
        }


        #endregion

        // Sets the window to be foreground

        [DllImport("User32")]
        public static extern int SetForegroundWindow(IntPtr hwnd);

        // Activate or minimize a window

        [DllImport("User32.DLL")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        public const int SW_RESTORE = 9;
        public const int SW_SHOWNORMAL = 1;
        public const int SW_SHOWMAXIMIZED = 3;
        public const int SW_SHOW = 5;


        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string className, string windowTitle);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ShowWindow(IntPtr hWnd, ShowWindowEnum flags);

        //[DllImport("user32.dll")]
        //private static extern int SetForegroundWindow(IntPtr hwnd);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowPlacement(IntPtr hWnd, ref Windowplacement lpwndpl);

        public enum ShowWindowEnum
        {
            Hide = 0,
            ShowNormal = 1, ShowMinimized = 2, ShowMaximized = 3,
            Maximize = 3, ShowNormalNoActivate = 4, Show = 5,
            Minimize = 6, ShowMinNoActivate = 7, ShowNoActivate = 8,
            Restore = 9, ShowDefault = 10, ForceMinimized = 11
        };

        public struct Windowplacement
        {
            public int length;
            public int flags;
            public int showCmd;
            public System.Drawing.Point ptMinPosition;
            public System.Drawing.Point ptMaxPosition;
            public System.Drawing.Rectangle rcNormalPosition;
        }
    }
}
