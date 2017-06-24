using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using LamedalCore;
using LamedalCore.zz;
using Lamedal_UIWinForms.libUI.Win32;
using Lamedal_UIWinForms.UControl.Forms;
using Lamedal_UIWinForms.zzz;

namespace Lamedal_UIWinForms.libUI.WinForms
{
    /// <summary>
    /// Form methods
    /// </summary>
    /// <remarks DefaultType="Form"></remarks>
    /// <code CTI_Timestamp="2015/02/19" DefaultType="Form" Group="Forms" CTI_Status="Unchecked;">CTI;</code>
    public sealed class WinForms2_Form
    {
        private readonly Lamedal_WinForms _lamedWin = Lamedal_WinForms.Instance;
        private readonly LamedalCore_ _lamed = LamedalCore_.Instance; // system library

        public Forms_ Factory
        {
            get { return _Windows_Forms ?? (_Windows_Forms = new Forms_()); }
        }
        private Forms_ _Windows_Forms;


        /// <summary>Invalidate the form. This will give the form time to redraw itself.</summary>
        /// <param name="form">The form</param>
        public void Invalidate(Form form)
        {
            1.zDoEvents();
            form.Invalidate(true);
            1.zDoEvents();
        }

        /// <summary>Sets the icon and the caption of the form. This is especially important for the main form</summary>
        /// <param name="frmType">Type of the FRM.</param>
        /// <param name="newIcon">News the icon</param>
        /// <param name="appName">Name of the application.</param>
        /// <param name="runThisFormAsTheMainForm">Run this form as the main form the indicator. Default value = ' true'.</param>
        public void Mainform_Open(Type frmType, Icon newIcon, string appName = "", bool runThisFormAsTheMainForm = true)
        {
            // Create the form
            Form frm = CreateForm2(frmType);
            if (frm == null)
            {
                ("Error! Unable to create main form '{0}'.".NL(2) + "Application will terminate.").zFormat(frmType.ToString()).zOk();
                return;
            }

            Mainform_Icon(newIcon);

            // Show the form
            if (runThisFormAsTheMainForm)
            {
                try
                {
                    if (appName != "") frm.Text = appName;
                    Application.Run(frm);
                } catch (Exception)
                {
                    if ("Error in main form. Exit application?".zDialog().MessageBox_YesNo() == false)
                    {
                        Mainform_Open(frmType, newIcon, appName, runThisFormAsTheMainForm);
                    }
                    else throw;
                }
            }
        }

        /// <summary>Sets the default icon for all  forms.</summary>
        public void Mainform_Icon(Icon newIcon)
        {
            FieldInfo fieldInfo = typeof(Form).GetField("defaultIcon", BindingFlags.NonPublic | BindingFlags.Static);
            if (fieldInfo != null && newIcon != null) fieldInfo.SetValue(null, newIcon);
        }
       

        ///// <summary>
        ///// Opens the form from the form.
        ///// </summary>
        ///// <param name="form">The form</param>
        ///// <param name="dte">The Development Tools Environment to</param>
        ///// <param name="caption">The caption setting. Default value = "".</param>
        ///// <param name="isTopMost">Is top most indicator. Default value = false.</param>
        ///// <returns>
        ///// Form
        ///// </returns>
        //public Form CreateForm(Form form, DTE2 dte, string caption = "", bool isTopMost = false)
        //{
        //    form = CreateForm(form, caption, isTopMost);
        //    var dte2 = form.zObject().State_Get<DTE2>();
        //    if (dte2 == null) form.zObject().State_Set(dte, false);

        //    return form;
        //}

        /// <summary>
        /// Opens the form from the form.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="form">The form</param>
        /// <param name="caption">The caption setting. Default value = "".</param>
        /// <param name="isTopMost">Is top most indicator. Default value = false.</param>
        /// <param name="onClosed">The on closed.</param>
        /// <returns>
        /// Form
        /// </returns>
        public T CreateForm<T>(T form, string caption = "", bool isTopMost = false, EventHandler onClosed = null) where T : Form
        {
            if (form == null || form.IsDisposed)
            {
                true.zWaitCursor();
                var form1 = CreateForm2(typeof(T));
                form = form1 as T;
            }

            //form._dte = dte;
            if (form != null)
            {
                form.TopMost = isTopMost;
                if (caption != "") form.Text = caption;
                form.Show();

                if (onClosed != null)
                {
                    form.Closed -= onClosed;
                    form.Closed += onClosed;
                }
            }

            return form;
        }

        /// <summary>Creates a form from the type (using reflection).</summary>
        /// <param name="frmType">Type of the FRM.</param>
        /// <returns></returns>
        /// <remarks>Recall</remarks>
        public Form CreateForm2(Type frmType)
        {
            // Use reflection to create the main form
            // ConstructorInfo constructor = frmType.GetConstructor(new[] { typeof(int) });    // Sample creation of form with custom constructor
            Form newForm = null;
            var constructor = frmType.GetConstructor(Type.EmptyTypes);
            if (constructor != null) newForm = (Form)Activator.CreateInstance(frmType); // Simple constructor

            //constructor = frmType.GetConstructor(new[] { typeof(Form3T_MainMenu) });               // Find constructors that has FormT3_MainMenu as parameter
            //if (constructor != null) newForm = (Form)constructor.Invoke(new object[] { this });

            return newForm;
        }


        /// <summary>Move form to the right edge of the screen.</summary>
        /// <param name="form">The form.</param>
        public void Screen_MoveRightEdge(Form form)
        {
            var screen = Screen.FromControl(form);
            var screen2 = Screen.PrimaryScreen;
            int left = 0;
            if (screen.Equals(screen2) == false) left = screen2.WorkingArea.Width;

            form.Left = left + screen.WorkingArea.Width - form.Width;
        }

        /// <summary>Move form to the top or bottom edge screen. If form is at the top it will be moved to the bottom and visa versa.</summary>
        /// <param name="form">The form.</param>
        /// <param name="defaultTop">The default top.</param>
        public void Screen_MoveTopBottomEdge(Form form, int defaultTop = 70)
        {
            var screen = Screen.FromControl(form);

            if (form.Top > 250) form.Top = defaultTop;  // Go top
            else form.Top = screen.WorkingArea.Height - form.Height - 40;  // Go Bottom
        }

        /// <summary>Set the Form to the full height of the screen.</summary>
        /// <param name="form">The form.</param>
        public void Size_FullHeight(Form form)
        {
            var screen = Screen.FromControl(form);
            form.Top = 10;
            form.Height = screen.WorkingArea.Height - 10;
        }

        /// <summary>If you have two screens then the form will change to the other screen.</summary>
        /// <param name="form">The form</param>
        public void Screen_Change(Form form)
        {
            var screen = Screen.FromControl(form);
            var screenP = Screen.PrimaryScreen;
            Screen[] screens = Screen.AllScreens;
            foreach (Screen screen_ in screens)
            {
                if (screen.Equals(screen_) == false)
                {
                    if (screen_.Equals(screenP)) form.Left = 100;
                    else form.Left = screenP.WorkingArea.Width + 100;

                    break;
                }
            }
        }

        /// <summary>Move form to the left edge screen.</summary>
        /// <param name="form">The form.</param>
        public void Screen_MoveLeftEdge(Form form)
        {
            var screen = Screen.FromControl(form);
            var screen2 = Screen.PrimaryScreen;
            int left = 0;
            if (screen.Equals(screen2) == false) left = screen2.WorkingArea.Width;

            form.Left = left + 10;
        }

        /// <summary>
        ///     A Form extension method that set the window form to full screen mode to the specified screen.
        /// </summary>
        /// <param name="form">The form to act on.</param>
        /// <param name="screen">(Optional) the screen to act on.</param>
        public void Size_FullScreen(Form form, int screen = 0)
        {
            form.StartPosition = FormStartPosition.Manual;
            form.Bounds = Screen.AllScreens[screen].Bounds;
        }

        /// <summary>Bring window to front.</summary>
        /// <param name="formCaption">The form caption</param>
        /// <param name="loadAppName">Load this application if the window was not found</param>
        public void Order_BringToFront(string formCaption, string loadAppName = "")
        {
            IntPtr wdwIntPtr = user32.FindWindow(null, formCaption);
            if (wdwIntPtr.ToInt64() == 0)
            {
                (formCaption + " not running.").zOk();
                if (loadAppName.zIsNullOrEmpty() == false)
                {
                    string path = Lamedal_WinForms.Instance.lib.Registry.Application_PathGet(loadAppName);
                    if (path != null)
                    {
                        _lamedWin.libUI.WinForms.Console.Execute(path);
                    }
                }
                return;  // <=================================================================
            }

            //get the hWnd of the process
            var placement = new user32.Windowplacement();
            user32.GetWindowPlacement(wdwIntPtr, ref placement);

            // Check if window is minimized
            //if (placement.showCmd == 2)
            {
                //the window is hidden so we restore it
                user32.ShowWindow(wdwIntPtr, user32.ShowWindowEnum.Restore);
            }

            //set user's focus to the window
            user32.SetForegroundWindow(wdwIntPtr);
        }

    }
}
