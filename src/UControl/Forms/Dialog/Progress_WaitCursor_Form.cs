using System;
using System.Windows.Forms;
using Lamedal_UIWinForms.zzz;

namespace Lamedal_UIWinForms.UControl.Forms.Dialog
{
    /// <summary>
    /// Progress form
    /// </summary>
    public sealed partial class Progress_WaitCursor_Form : Form
    {
        private readonly UIWindows _uiWindows = UIWindows.Instance;   // Instance to UIWindows

        private DateTime _StartupTime;
        private int _TimeoutSeconds = 7;   // User should not wait longer than 7 seconds 
        private int _ActivateMinSeconds = 1;

        /// <summary>
        /// Initializes a new instance of the <see cref="Progress_WaitCursor_Form"/> class.
        /// </summary>
        public Progress_WaitCursor_Form()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Form setups the waits cursor form.
        /// </summary>
        public void Setup()
        {
            //300.zExecute_Async(StartTimer);
            StartTimer();
            _uiWindows.libUI.WinForms.Tools.DoEvents();
        }

        #region private
        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value = 100;
            Invalidate(this);
            var secondsFromStartup = DateTime.UtcNow.Subtract(_StartupTime).Seconds;
            if ((Cursor.Current != Cursors.WaitCursor || secondsFromStartup > _TimeoutSeconds ) && secondsFromStartup >= _ActivateMinSeconds)
            {
                100.zExecute_Async(HideMe);
            }
        }

        private void StartTimer()
        {
            progressBar1.Value = 0;
            this.Visible = true;
            this.TopMost = true;
            Invalidate(this);
            this.Invalidate(true);

            timer1.Enabled = true;
            _StartupTime = DateTime.UtcNow;   // Utc is faster method

        }
        private void HideMe()
        {
            this.Visible = false;
            timer1.Enabled = false;
        }

        /// <summary>
        /// Invalidate forms giving it time to redraw itself.
        /// </summary>
        /// <param name="form">The form</param>
        private void Invalidate(Form form)
        {
            _uiWindows.libUI.WinForms.Tools.DoEvents();
            form.Invalidate(true);
            _uiWindows.libUI.WinForms.Tools.DoEvents();
        }
        #endregion

    }
}
