using Lamedal_UIWinForms.lib;

namespace Lamedal_UIWinForms
{
    public sealed class Lamedal_WinForms
    {
        // private readonly Lamedal_WinForms _lamedWin = Lamedal_WinForms.Instance;  // Load the winforms lib

        #region Singleton of LamedalWinForms
        private static readonly Lamedal_WinForms _LamedalWinForms = new Lamedal_WinForms();  // This is the only instance of this class
        private Lamedal_WinForms()
        {
            // Private constructor prevents creation by external clients
        }

        /// <summary>
        /// Return Instance of Singleton_Pattern
        /// </summary>
        public static Lamedal_WinForms Instance
        {
            get { return _LamedalWinForms; }
        }
        #endregion

        #region lib
        /// <summary>
        /// Gets the lib library methods.
        /// </summary>
        public lib_ lib
        {
            get { return _lib ?? (_lib = new lib_()); }
        }
        private lib_ _lib;
        #endregion

    }
}
