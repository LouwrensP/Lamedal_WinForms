using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using LamedalCore;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;

namespace Lamedal_UIWinForms.zzz
{
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.Transformation_Connector)]
    public static class UIWindows_Shortcut
    {
        /// <summary>
        /// Execute the specified Methods.
        /// </summary>
        /// <param name="method">The method.</param>
        /// <param name="interval">The interval.</param>
        /// <param name="uniqueName">The unique name.</param>
        /// <param name="resetTimer">if set to <c>true</c> [reset timer].</param>
        public static void zExecute_Async(this int interval, MethodInvoker method, string uniqueName = "", bool resetTimer = false)
        {
            // 500.zExecute_Async(() => methodName(5));
            Lamedal_WinForms.Instance.libUI.WinForms.Callback.Execute(method, interval, uniqueName, resetTimer);
        }

        /// <summary>
        /// Move Method to UI Thread. If method was called on UI thread true is returned.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <param name="method">The method.</param>
        /// <returns></returns>
        public static bool zCallback_Method_Move2UI_Thread(this Control control, MethodInvoker method)
        {
            return Lamedal_WinForms.Instance.libUI.WinForms.Callback.Method_Move2UI_Thread(control, method);
        }

        /// <summary>
        /// Determines whether the control is on main thread.
        /// </summary>
        /// <param name="control">The control</param>
        /// <param name="showMsg">Show msg indicator. Default value = false.</param>
        /// <returns>bool</returns>
        /// <code>CTIN_Transformation;</code>
        public static bool zControlIsNotOnMainThread(this Control control, bool showMsg = false)
        {
            return Lamedal_WinForms.Instance.libUI.WinForms.Callback.Control_IsNotOnMainThread(control, showMsg);
        }

        /// <summary>
        /// Shows MessageBox.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <param name="title">The title.</param>
        /// <param name="buttons">The buttons.</param>
        /// <param name="icon">The icon.</param>
        /// <returns></returns>
        public static DialogResult zOk(this string msg, string title, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return Lamedal_WinForms.Instance.libUI.WinForms.Dialog_Simple.MessageBox_Ok(msg, title, buttons, icon);
        }

        /// <summary>
        /// Shows MessageBox.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <param name="title">The title.</param>
        /// <returns></returns>
        public static DialogResult zOk(this string msg, string title = "")
        {
            return Lamedal_WinForms.Instance.libUI.WinForms.Dialog_Simple.MessageBox_Ok(msg, title);
        }

        /// <summary>
        /// Simple dialog form displaying 'not implemented yet' message box.
        /// </summary>
        /// <param name="methodName">The method name</param>
        public static void zOk_NotImplementedYet(this string methodName)
        {
            Lamedal_WinForms.Instance.libUI.WinForms.Dialog_Simple.MessageBox_NotImplementedYet(methodName);
        }


        /// <summary>
        /// Determines whether the string is null or white space.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns>
        /// bool
        /// </returns>
        public static bool zIsNullOrWhiteSpace(this string str)
        {
            return String.IsNullOrWhiteSpace(str);
        }

        /// <summary>
        /// Do other events. This helps with apartment threading
        /// </summary>
        /// <param name="total">The total.</param>
        /// <param name="sleep">The sleep.</param>
        public static void zDoEvents(this int total, int sleep = 0)
        {
            Lamedal_WinForms.Instance.libUI.WinForms.Tools.DoEvents(total, sleep);
        }
    }
}
