using System;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Lamedal_UIWinForms.lib.system
{
    public sealed class system_Registry
    {
        // The path to the key where Windows looks for startup applications
        public static RegistryKey regKeyAppAutoRun = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        public static RegistryKey regKeyLaMedal = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Lamedal");
       

        /// <summary>Saves the application value.</summary>
        /// <param name="appName">The application name</param>
        /// <param name="field">The field</param>
        /// <param name="value">The valueue</param>
        public void Application_ValueSave(string appName, string field, string value)
        {
            var regAppKey = regKeyLaMedal.CreateSubKey(appName);
            regAppKey.SetValue(field, value);
        }

        /// <summary>Gets the application field value.</summary>
        /// <param name="appName">The application name</param>
        /// <param name="field">The field</param>
        /// <returns>string</returns>
        public string Application_ValueGet(string appName, string field)
        {
            RegistryKey regAppKey = regKeyLaMedal.CreateSubKey(appName);
            string value;
            try
            {
                value = regAppKey.GetValue(field).ToString();
               return value;
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
                return null;
            }
        }

        /// <summary>Saves the application path.</summary>
        /// <param name="appName">The application name</param>
        /// <param name="path">The path setting. Default value = "".</param>
        public void Application_PathSave(string appName, string path = "")
        {
            if (path == "") path = Application.ExecutablePath;
            Application_ValueSave(appName, "Path", path);
        }

        /// <summary>Gets the application path .</summary>
        /// <param name="appName">The application name</param>
        /// <returns>string</returns>
        public string Application_PathGet(string appName)
        {
            string path = Application_ValueGet(appName, "Path");
            return path;
        }

        /// <summary>Determines whether the application will start automatically.</summary>
        /// <param name="AppName">The application name</param>
        /// <returns>bool</returns>
        public bool Application_Startup(string AppName)
        {
            // Check to see the current state (running at startup or not)
            if (regKeyAppAutoRun.GetValue(AppName) == null) return false;  // The value doesn't exist, the application is not set to run at startup
            else return true; // The value exists, the application is set to run at startup
        }

        /// <summary>Setups the application startup setting.</summary>
        /// <param name="AppName">The application name</param>
        /// <param name="setting">Setting indicator</param>
        public void Application_StartupSetup(string AppName, bool setting)
        {
            if (setting) regKeyAppAutoRun.SetValue(AppName, Application.ExecutablePath);  // Add the value in the registry so that the application runs at startup
            else regKeyAppAutoRun.DeleteValue(AppName, false);  // Remove the value from the registry so that the application doesn't start
        }

       
    }
}
