using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using LamedalCore.zz;
using Lamedal_UIWinForms.State;
using Lamedal_UIWinForms.zzz;

namespace Lamedal_UIWinForms.libUI.WinForms.Callback
{

    /// <summary>
    /// Class to implement call-back methods
    /// </summary>
    /// <code>CTI;</code>
    public sealed class Callback_
    {
        private readonly Lamedal_WinForms _lamedWin = Lamedal_WinForms.Instance;  // Load the winforms lib        
        private readonly Dictionary<string,stateCallback> CallbackMethods = new Dictionary<string, stateCallback>();

        /// <summary>
        /// Execute the specified callback method asynchronously
        /// </summary>
        /// <param name="method">The method invoker</param>
        /// <param name="interval">The interval setting. Default value = 300.</param>
        /// <param name="uniqueName">The unique name setting. Default value = &quot;&quot;.</param>
        /// <param name="resetTimer">Reset timer indicator. Default value = false.</param>
        public void Execute(MethodInvoker method, int interval = 300, string uniqueName = "", bool resetTimer = false)
        {
            // Lamedal_WinForms.Instance.Method(() => myMethod(5), 500);

            if (CallbackMethods.Count > 300)
            {
                string stack = _lamedWin.lib.dotNet.Stacktrace.Method_Stacktrace_AsStr(false, "Method");
                throw new ArgumentException("Error! Recursive method calls: " + stack);
            }

            if (uniqueName.zIsNullOrEmpty()) uniqueName = Guid.NewGuid().ToString();

            if (CallbackMethods.ContainsKey(uniqueName))
            {
                if (!resetTimer) return;  // Do Nothing

                Timer time = CallbackMethods[uniqueName].Timer_;
                time.Interval = time.Interval + 1;              // Reset the interval and increase it by 1
                time.Tick -= timerTickEvent;
                time.Tick += timerTickEvent;
                time.Enabled = true;
            }
            else
            {
                #region No timer -> create new timer
                Timer timer = null;
                lock (CallbackMethods)
                {
                    // Add the new method
                    string stack = _lamedWin.lib.dotNet.Stacktrace.Method_Stacktrace_AsStr(false, "Method");

                    
                    timer = new Timer();
                    var info = new stateCallback(timer, method, stack);
                    CallbackMethods.Add(uniqueName, info);
                }
                timer.Tag = uniqueName;
                timer.Interval = interval;
                timer.Tick -= timerTickEvent;
                timer.Tick += timerTickEvent;
                timer.Enabled = true;
                #endregion
            }
        }

        /// <summary>
        /// Move Method to UI Thread. If method was called on UI thread true is returned.
        /// </summary>
        /// <param name="control">The FRM.</param>
        /// <param name="method">The method.</param>
        /// <returns>True if the method was called on the UI threand</returns>
        public bool Method_Move2UI_Thread(Control control, MethodInvoker method)
        {
            // if (Method_Move2UI_Thread(control, methodName)) return;     // Call this method on the UI thread
            if (control.InvokeRequired)
            {
                control.Invoke(new MethodInvoker(method)); //{ sender, e }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Determines whether the control is on main thread.
        /// </summary>
        /// <param name="control">The control</param>
        /// <param name="showMsg">Show msg indicator. Default value = false.</param>
        /// <returns>bool</returns>
        public bool Control_IsNotOnMainThread(Control control, bool showMsg = false)
        {
            if (control.InvokeRequired)
            {
                if (showMsg) "Error! Not on main thread.".zOk();
                return true;
            }
            return false;
        }
        /// <summary>
        /// Timers the tick event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void timerTickEvent(object sender, EventArgs e)
        {
            // Get the timer and the command
            var timer = sender as Timer;
            if (timer == null) return;

            timer.Enabled = false;
            var uniquename = timer.Tag.ToString();
            stateCallback info = CallbackMethods[uniquename];
            lock (CallbackMethods)
            {
                CallbackMethods.Remove(uniquename);
            }
            MethodInvoker execute = info.Execute;
            var methodName = execute.Method.Name;

            // Execute the command
            try
            {
                Debug.Print("Exec Method: '" + methodName +"'  ; Unique Name: '" + uniquename + "'");
                execute();
                
            }
            catch (Exception ex)
            {
                // This is an exception on the MethodInvoker structure. We need to give more context 
                var err = "Executing method '" + methodName + "()'".NL();
                err += info.MethodStack;
                throw new Exception(err, ex);
            }

            timer.Dispose();
            info.Dispose();
        }
    }
}
