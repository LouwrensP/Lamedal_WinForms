using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Windows.Forms;
using LamedalCore.zz;
using Lamedal_UIWinForms.zzz;

namespace Lamedal_UIWinForms.libUI.WinForms
{
    /// <code CTI_Timestamp="2015/02/18" CTI_Status="Unchecked;">CTI;</code>
    public sealed class WinForms2_Console
    {
        /// <summary>Executes the command on the console and provide ability to show the output.</summary>
        /// <param name="exeName">The executable name</param>
        /// <param name="arguments">The arguments</param>
        /// <param name="OnOutputFromProcess">The on output from process setting. Default value = null.</param>
        /// <param name="OnErrorFromProcess">The on error from process setting. Default value = null.</param>
        /// <param name="Object">The object setting. Default value = null.</param>
        public void Execute(string exeName, string arguments = "",
                DataReceivedEventHandler OnOutputFromProcess = null, DataReceivedEventHandler OnErrorFromProcess = null,
                object Object = null)
        {
            //var outputStr = new StringBuilder();
            if (exeName == null)
            {
                "Error! exeName can not be null!".zException_Show();
                return;
            }

            var processInfo = new ProcessStartInfo();
            processInfo.CreateNoWindow = true;
            processInfo.RedirectStandardInput = true;
            processInfo.RedirectStandardOutput = true;
            processInfo.UseShellExecute = false;
            processInfo.FileName = exeName;
            processInfo.Arguments = arguments;

            var process = new Process();
            var state = process.zzState();
            state.TextBox = Object as TextBox;

            process.StartInfo = processInfo;
            process.EnableRaisingEvents = true;
            if (OnOutputFromProcess != null)
            {
                process.OutputDataReceived -= OnOutputFromProcess;
                process.OutputDataReceived += OnOutputFromProcess;
            }

            if (OnErrorFromProcess != null)
            {
                process.ErrorDataReceived -= OnErrorFromProcess;
                process.ErrorDataReceived += OnErrorFromProcess;
            }

            process.Start();
            process.BeginOutputReadLine();

            //process.WaitForExit();
            //while (process.StandardOutput.EndOfStream == false)
            //{
            //    Thread.Sleep(100);
            //}
            //process.CancelOutputRead();

        }


        /// <summary>Executes the command on the console and show the output in a textbox</summary>
        /// <param name="exeName">Name of the executable.</param>
        /// <param name="arguments">The arguments.</param>
        /// <param name="textBox">The text box.</param>
        public void Execute(string exeName, string arguments, TextBox textBox)
        {
            textBox.Text = "";
            Execute(exeName, arguments, Handle_TextboxOutput, Object: textBox);
        }

        /// <summary>
        /// Application objects for the search for application setting. Default value = "!VisualStudio.DTE.12.0:"
        /// </summary>
        /// <param name="searchForApp">The search for application setting. Default value = "!VisualStudio.DTE.12.0:".</param>
        /// <param name="waitForApplication">Wait for application to refresh indicator. Default value = true.</param>
        /// <returns></returns>
        public Dictionary<string, object> ApplicationCOM_Objects(string searchForApp = "!VisualStudio.DTE.12.0:", bool waitForApplication = true)
        {
            if (waitForApplication) 3.zDoEvents(100);  // Wait a bit to give the environment time to catch up
            var result = new Dictionary<string, object>();
            IRunningObjectTable runningObjectTable;
            GetRunningObjectTable(0, out runningObjectTable);
            IEnumMoniker enumMoniker;
            runningObjectTable.EnumRunning(out enumMoniker);
            enumMoniker.Reset();

            var zeroPointer = IntPtr.Zero;
            var moniker = new IMoniker[1];
            while (enumMoniker.Next(1, moniker, zeroPointer) == 0)
            {
                IBindCtx bindCtx;
                CreateBindCtx(0, out bindCtx);
                string displayName;
                moniker[0].GetDisplayName(bindCtx, null, out displayName);
                if (displayName.Contains(searchForApp))
                {
                    object comObject;
                    runningObjectTable.GetObject(moniker[0], out comObject);
                    result.Add(displayName, comObject);
                }
            }
            return result;
        }


        #region Private

        private void Handle_TextboxOutput(object sender, DataReceivedEventArgs e)
        {
            var process = sender as Process;
            var state = process.zzState();
            if (state.TextBox != null)
            {
                var frm = state.TextBox.FindForm();
                Lamedal_WinForms.Instance.libUI.WinForms.Callback.Method_Move2UI_Thread(frm, () => Textbox_set(state.TextBox, e.Data));
            } else
            {
                "Error! Cannot provide feedback for command.".zOk();
            }
        }

        private void Textbox_set(TextBox textBox, string newValue)
        {
            textBox.Text += newValue;
        }

        [DllImport("ole32.dll")]
        private static extern void CreateBindCtx(int reserved, out IBindCtx ppbc);

        /// <summary>
        /// Gets index of first non-equal char for two strings
        /// Not case sensitive.
        /// </summary>
        private static int GetMatchingCharsFromStart(string a, string b)
        {
            a = (a ?? string.Empty).ToLower();
            b = (b ?? string.Empty).ToLower();
            int matching = 0;
            for (int i = 0; i < Math.Min(a.Length, b.Length); i++)
            {
                if (!char.Equals(a[i], b[i]))
                    break;

                matching++;
            }
            return matching;
        }

        [DllImport("ole32.dll")]
        private static extern void GetRunningObjectTable(int reserved, out IRunningObjectTable prot);
        #endregion
    }
}
