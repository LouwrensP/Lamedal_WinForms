using LamedalCore.lib;
using Lamedal_UIWinForms.libUI;

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
        public libUI2_ libUI
        {
            get { return _lib ?? (_lib = new libUI2_()); }
        }
        private libUI2_ _lib;
        #endregion

        #region Exceptions
        /// <summary>
        /// Gets the Exceptions library methods. 
        /// </summary>
        public Lamedal_WinForms_Exceptions Exceptions
        {
            get { return _Exceptions ?? (_Exceptions = new Lamedal_WinForms_Exceptions()); }
        }
        private Lamedal_WinForms_Exceptions _Exceptions;
        #endregion


    }
}
