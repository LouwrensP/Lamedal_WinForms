using System;
using System.Windows.Forms;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;

namespace Lamedal_UIWinForms.State
{
    /// <summary>
    /// Save timer Information
    /// </summary>
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.Node_State)]
    public sealed class stateCallback : IDisposable
    {
        /// <summary>
        /// The timer
        /// </summary>
        public Timer Timer_;
        /// <summary>
        /// The method to execute
        /// </summary>
        public MethodInvoker Execute;
        /// <summary>
        /// The method call stack
        /// </summary>
        public readonly string MethodStack;

        /// <summary>
        /// Initializes a new instance of the <see cref="stateCallback"/> class.
        /// </summary>
        /// <param name="timer">The timer</param>
        /// <param name="execute">The execute</param>
        /// <param name="methodStack">The method stack</param>
        public stateCallback(Timer timer, MethodInvoker execute, string methodStack)
        {
            Timer_ = timer;
            Execute = execute;
            MethodStack = methodStack;
        }

        /// <summary>
        /// Dispose timer information.
        /// </summary>
        public void Dispose()
        {
            Timer_.Dispose();
            Timer_ = null;
            Execute = null;
        }
    }
}
