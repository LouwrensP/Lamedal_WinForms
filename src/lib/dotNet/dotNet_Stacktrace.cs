using System.Diagnostics;
using System.Reflection;
using LamedalCore;
using LamedalCore.zz;

namespace Lamedal_UIWinForms.lib.dotNet
{
    public sealed class dotNet_Stacktrace : LamedalCore_Exceptions
    {

        #region Method_Stacktrace_AsStr (not available on .Net Core standard 1.6)
        /// <summary>
        /// Return a Stack trace of the calling methods as string.
        /// </summary>
        /// <param name="showParameters">if set to <c>true</c> [show parameters].</param>
        /// <param name="method"></param>
        /// <returns></returns>
        public string Method_Stacktrace_AsStr(bool showParameters = false, string method = "zException_Show")
        {
            StackFrame[] stackFrames = new StackTrace().GetFrames();
            if (stackFrames == null) return "";

            // Calculate the level where zException_Show() was called
            string className;
            string methodName;
            string parameters;
            int levels = stackFrames.Length - 1;
            for (int ii = 0; ii < levels; ii++)
            {
                Stacktrace_CallingMethod(stackFrames, out className, out methodName, out parameters, ii);
                if (methodName == method)
                {
                    levels = ii + 1;
                    if (levels > stackFrames.Length) levels = stackFrames.Length;
                    break;
                }
            }

            // Show the calling method info
            string result = "Method:".NL();
            Stacktrace_CallingMethod(stackFrames, out className, out methodName, out parameters, levels, showParameters);
            result += className + "." + methodName + "(";
            if (showParameters) result += parameters;
            result += ")".NL();
            return result;
        }

        private MethodBase Stacktrace_CallingMethod(StackFrame[] stackFrames, out string className,
            out string methodName, out string parameters, int levelNo = 2, bool showParameters = false)
        {
            MethodBase method = stackFrames[levelNo].GetMethod();
            methodName = method.Name;
            className = (method.ReflectedType == null) ? "" : method.ReflectedType.FullName;
            parameters = "";

            if (showParameters)
            {
                ParameterInfo[] parms = method.GetParameters();
                var total = parms.Length;
                for (int ii = 0; ii < total; ii++)
                {
                    if (parameters != "") parameters += ", ";
                    parameters += parms[ii].ParameterType.ToString() + " " + parms[ii].Name;
                }
            }
            return method;
        }
        #endregion


    }
}