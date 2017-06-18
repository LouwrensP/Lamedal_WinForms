using System;
using System.Diagnostics.Contracts;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;

namespace Lamedal_UIWinForms.libUI.WinForms
{
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.Undefined)]
    public sealed class WinForms_Tools
    {
        private readonly Lamedal_WinForms _lamedWin = Lamedal_WinForms.Instance;

        /// <summary>
        /// Do other events. This helps with apartment threading
        /// </summary>
        /// <param name="total">The total.</param>
        /// <param name="sleep">The sleep.</param>
        public void DoEvents(int total = 1, int sleep = 0)
        {
            Thread.Sleep(0);
            for (int ii = 0; ii < total; ii++)
            {
                Application.DoEvents();
            }
            if (sleep > 0)
            {
                Thread.Sleep(sleep);
                Application.DoEvents();
            }
        }

        /// <summary>
        /// Return the main form for the Application.
        /// </summary>
        /// <param name="frmMain">The FRM main.</param>
        /// <returns></returns>
        public bool Form_Main(out Form frmMain)
        {
            frmMain = null;
            bool result = false;

            FormCollection openForms = Application.OpenForms;
            if (openForms.Count > 0)
            {
                frmMain = openForms[0];
                result = true;
            }
            return result;
        }

        /// <summary>
        /// Return true if this is the main Form.
        /// </summary>
        /// <param name="thisForm">The this form.</param>
        /// <returns></returns>
        public bool Form_IsMainForm(Form thisForm)
        {
            Form frmMain;
            Form_Main(out frmMain);
            if (frmMain == null || thisForm == frmMain) return true;   // If there is no forms loaded then thisForm is the main form
            return false;
        }

        /// <summary>
        /// Remove the Top most form.
        /// </summary>
        public void Form_Main_Remove_TopMost()
        {
            Form frmMain;
            if (Form_Main(out frmMain))
            {
                if (!frmMain.TopMost) return;
                frmMain.TopMost = false;
                DoEvents(100);
            }
        }

        /// <summary>
        /// Remove any topmost form setting.
        /// </summary>
        public void Form_Remove_TopMost()
        {
            try
            {
                FormCollection openForms = Application.OpenForms;
                foreach (Form form in openForms) if (form.TopMost) form.TopMost = false;
                DoEvents(100);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        /// <summary>
        /// Copy string to the Clipboard.
        /// </summary>
        /// <param name="copyStr">The copy string.</param>
        /// <param name="usedInternally">Used internally.</param>
        public void Clipboard_CopyStrTo(string copyStr, int usedInternally = 1)
        {
            if (copyStr == "") return;

            Clipboard.SetText(copyStr);
            DoEvents();
            var val = Clipboard_GetStrFrom();
            if (copyStr != val)
            {
                if (usedInternally <= 1)
                {
                    //Let us try again after we give windows some time to process
                    Application.DoEvents();
                    Thread.Sleep(10);
                    Application.DoEvents();
                    Clipboard_CopyStrTo(copyStr, ++usedInternally);
                }
                _lamedWin.libUI.WinForms.Dialog_Simple.MessageBox_Ok("Error: Clipboard copy was not successful!");
            }
        }

        /// <summary>
        /// Get string from the Clipboard.
        /// </summary>
        /// <returns></returns>
        public string Clipboard_GetStrFrom()
        {
            return Clipboard.GetText();
        }



        /// <summary>
        /// Determines if Designer is active for the control.
        /// </summary>
        /// <param name="ctrl">The control.</param>
        /// <returns></returns>
        public bool Designer_IsActive(Control ctrl)
        {
            while (ctrl != null)
            {
                if ((ctrl.Site != null) && ctrl.Site.DesignMode) return true;
                ctrl = ctrl.Parent;
            }
            return false;
        }

        /// <summary>
        /// Determines if Designer is active.
        /// </summary>
        /// <returns></returns>
        public bool Designer_IsActive()
        {
            Form mainForm;
            if (!Form_Main(out mainForm)) return true; // Assume designer if there is no main form

            return Designer_IsActive(mainForm);
        }

        /// <summary>
        /// Test if Thread is STA.
        /// </summary>
        /// <param name="errMsg">if set to <c>true</c> [error MSG].</param>
        /// <returns></returns>
        public bool ThreadIsSTA(bool errMsg = true)
        {
            // Test Threading
            if (Thread.CurrentThread.GetApartmentState() != ApartmentState.STA)
            {
                if (errMsg) Lamedal_WinForms.Instance.Exceptions.Show("The current threads apartment state is not STA");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Function to return application path.
        /// </summary>
        /// <returns>string</returns>
        [Pure]
        public string Application_Path()
        {
            return Application.ExecutablePath;
        }

        /// <summary>
        /// Return the application name.
        /// </summary>
        /// <returns>string</returns>
        [Pure]
        public string Application_Name()
        {
            return AppDomain.CurrentDomain.FriendlyName;
        }

        /// <summary>
        /// Return the version of the application.
        /// </summary>
        /// <returns></returns>
        public string Version()
        {
            //var name = assemblyName.Name;
            string name = Path.GetFileNameWithoutExtension(Application.ExecutablePath);
            string versionStr = Application.ProductVersion;

            // Days since 1.1.2000
            Version version = Assembly.GetExecutingAssembly().GetName().Version;  //Assembly.GetEntryAssembly().GetName().Version;
            DateTime buildDateTime = new DateTime(2000, 1, 1).Add(new TimeSpan(TimeSpan.TicksPerDay * version.Build  // days since 1 January 2000
                        + TimeSpan.TicksPerSecond * 2 * version.Revision)); // seconds since midnight, (multiply by 2 to get original)

            return name + " version " + versionStr + " (" + buildDateTime.ToShortDateString() + ")";
        }

        private DateTime RetrieveLinkerTimestamp()
        {
            string filePath = System.Reflection.Assembly.GetCallingAssembly().Location;
            const int c_PeHeaderOffset = 60;
            const int c_LinkerTimestampOffset = 8;
            var b = new byte[2048];
            System.IO.Stream s = null;

            try
            {
                s = new System.IO.FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                s.Read(b, 0, 2048);
            }
            finally
            {
                if (s != null)
                {
                    s.Close();
                }
            }

            int i = System.BitConverter.ToInt32(b, c_PeHeaderOffset);
            int secondsSince1970 = System.BitConverter.ToInt32(b, i + c_LinkerTimestampOffset);
            var dt = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            dt = dt.AddSeconds(secondsSince1970);
            dt = dt.ToLocalTime();
            return dt;
        }

        
    }
}
