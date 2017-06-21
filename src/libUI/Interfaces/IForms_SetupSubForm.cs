namespace Lamedal_UIWinForms.libUI.Interfaces
{
    public interface IForms_SetupSubForm : IForms_Setup
    {
        System.Windows.Forms.GroupBox _groupMain { get; }
        System.Windows.Forms.GroupBox _groupSetup { get; }
        System.Windows.Forms.Splitter _splitter { get;  }

        /// <summary>
        /// Setup the main form.
        /// </summary>
        /// <param name="tabIndex">Index of the tab.</param>
        /// <param name="status">The status.</param>
        /// <returns>true if main form exists</returns>
        bool Setup_FormMain(int tabIndex = -1, string status = null);

        
        void Show();
    }
}
