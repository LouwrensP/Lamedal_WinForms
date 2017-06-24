using System;
using LamedalCore;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.lib;
using LamedalCore.Types;
using Lamedal_UIWinForms.lib;
using Lamedal_UIWinForms.libUI;
using Lamedal_UIWinForms.libUI.WinForms.UIDesigner;

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
        public lib2_ lib
        {
            get { return _lib ?? (_lib = new lib2_()); }
        }
        private lib2_ _lib;
        #endregion

        #region libUI
        /// <summary>
        /// Gets the lib library methods.
        /// </summary>
        public libUI2_ libUI
        {
            get { return _libUI ?? (_libUI = new libUI2_()); }
        }
        private libUI2_ _libUI;
        #endregion



        #region UIDesigner
        /// <summary>
        /// Gets the UIDesigner library methods.
        /// </summary>
        public UIDesigner_ UIDesigner
        {
            get { return _UIDesigner ?? (_UIDesigner = new UIDesigner_()); }
        }
        private UIDesigner_ _UIDesigner;
        #endregion


        #region About messages
        /// <summary>Shows an about message of the LamedaL library.</summary>
        /// <returns></returns>
        public string About_()
        {
            return LamedalCore_.Instance.lib.Console.IO.About_();
        }

        /// <summary>Writes to the console an about message of the LamedaL library.</summary>
        public void About_WriteLine()
        {
            LamedalCore_.Instance.lib.Console.IO.About_WriteLine();
        }

        /// <summary>
        /// Writes a hello world message to the console
        /// </summary>
        /// <returns></returns>
        public string HelloWorld_()
        {
            return LamedalCore_.Instance.lib.Console.IO.About_HelloWorld_();
        }

        /// <summary>
        /// Writes a hello world message to the console
        /// </summary>
        /// <returns></returns>
        public void HelloWorld_WriteLine()
        {
            LamedalCore_.Instance.lib.Console.IO.About_HelloWorld_WriteLine();
        }

        /// <summary>
        /// Shows a error message. This is for testing purposes.
        /// </summary>
        [Test_IgnoreCoverage(enCode_TestIgnore.CodeIsUsedForTesting)]
        public void Error_Test()
        {
            throw new NotImplementedException("Hello. This is a test error message.");
        }

        /// <summary>Exits the application.</summary>
        /// <param name="exitCode">The exit code.</param>
        [Test_IgnoreCoverage(enCode_TestIgnore.CodeIsUsedForTesting)]
        public void Exit(int exitCode = 0)
        {
            Environment.Exit(exitCode);
        }

        /// <summary>Exits the application and write message on the event log.</summary>
        /// <param name="eventlogMsg">The eventlog MSG.</param>
        [Test_IgnoreCoverage(enCode_TestIgnore.CodeIsUsedForTesting)]
        public void Exit_Fast(string eventlogMsg = "")
        {
            Environment.FailFast(eventlogMsg);
        }

        #endregion

        #region Types
        /// <summary>
        /// Gets the Types library methods.
        /// </summary>
        public Types_ Types
        {
            get { return _Types ?? (_Types = new Types_()); }
        }
        private Types_ _Types;
        #endregion


    }
}
