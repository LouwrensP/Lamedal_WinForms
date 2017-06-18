using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using Lamedal_UIWinForms.zzz;

namespace Lamedal_UIWinForms.libUI.WinForms
{
    /// <summary>
    /// Idle methods
    /// </summary>
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.Node_Action)]
    public sealed class WinForms_Idle
    {
        private MethodInvoker _methodEnd;

        #region DllImport
        /// <summary>
        /// Windows import method
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        private struct NativeMessage
        {
            private readonly IntPtr Handle;
            private readonly uint Message;
            private readonly IntPtr WParameter;
            private readonly IntPtr LParameter;
            private readonly uint Time;
            private readonly Point Location;
        }

        [DllImport("user32.dll")]
        private static extern int PeekMessage(out NativeMessage message, IntPtr window, uint filterMin, uint filterMax, uint remove);


        [StructLayout(LayoutKind.Sequential)]
        struct LASTINPUTINFO
        {
            private static readonly int SizeOf = Marshal.SizeOf(typeof(LASTINPUTINFO));

            [MarshalAs(UnmanagedType.U4)]
            public UInt32 cbSize;
            [MarshalAs(UnmanagedType.U4)]
            public UInt32 dwTime;
        }

        [DllImport("user32.dll")]
        static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);
        #endregion

        /// <summary>
        /// Determines whether [is application idle].
        /// </summary>
        /// <returns></returns>
        public bool IsApplicationInactive()
        {
            NativeMessage result;
            return PeekMessage(out result, IntPtr.Zero, (uint)0, (uint)0, (uint)0) == 0;
        }

        void HandleApplicationIdle(object sender, EventArgs e)
        {
            //Application.Idle += HandleApplicationIdle;

            while (IsApplicationInactive())
            {
                //Update();
                //Render();
                1.zDoEvents();  // Excecute other events
            }
        }

        /// <summary>
        /// Time since last input from user.
        /// </summary>
        /// <returns></returns>
        public int Time_SinceLastInput()
        {
            uint idleTime = 0;
            var lastInputInfo = new LASTINPUTINFO();
            lastInputInfo.cbSize = (uint)Marshal.SizeOf(lastInputInfo);
            lastInputInfo.dwTime = 0;

            var envTicks = (uint)Environment.TickCount;

            if (GetLastInputInfo(ref lastInputInfo))
            {
                uint lastInputTick = lastInputInfo.dwTime;

                idleTime = envTicks - lastInputTick;
            }

            uint result = ((idleTime > 0) ? (idleTime / 1000) : 0);
            return (int) result;
        }

        /// <summary>
        /// Status process setup.
        /// </summary>
        /// <param name="methodStart">Method starts the</param>
        /// <param name="methodEnd">The method end</param>
        public void Process_Setup(MethodInvoker methodStart, MethodInvoker methodEnd)
        {
            if (_methodEnd != null) return;   // Cannot do status twice

            if (methodStart != null) methodStart();
            _methodEnd = methodEnd;
            Application.Idle += OnIdle;  // Add idle event
        }

        /// <summary>
        /// Status process setup.
        /// </summary>
        /// <param name="StatusLabel">The status label.</param>
        /// <param name="msgStart">The MSG start.</param>
        /// <param name="msgEnd">The MSG end.</param>
        public void Process_Setup(ToolStripStatusLabel StatusLabel, string msgStart = "Doing some work", string msgEnd = "Ready")
        {
            Process_Setup(() => Execute_Start(StatusLabel, msgStart), () => Execute_End(StatusLabel, msgEnd));
        }

        private void OnIdle(object sender, EventArgs e)
        {
            if (_methodEnd != null)
            {
                _methodEnd();
                _methodEnd = null;

            }
            Application.Idle -= OnIdle;  // Remove the event
        }

        private void Execute_Start(ToolStripStatusLabel statusLabel, string msgStart = "Doing some work")
        {
            Cursor.Current = Cursors.WaitCursor;
            statusLabel.Text = msgStart;
            1.zDoEvents();
        }

        private void Execute_End(ToolStripStatusLabel statusLabel, string msgEnd = "Ready")
        {
            statusLabel.Text = msgEnd;
            Cursor.Current = Cursors.Default;
            1.zDoEvents();
        }
    }
}
