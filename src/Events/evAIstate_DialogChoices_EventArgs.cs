using System;
using System.ComponentModel;

namespace Lamedal_UIWinForms.Events
{
    /// <summary>
    /// Provides data for the <see cref="E:System.Windows.Forms.Form.FormClosing"/> event.
    /// </summary>
    /// <filterpriority>2</filterpriority>
    public sealed class evAIstate_DialogChoices_EventArgs : CancelEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="evAIstate_ExitEventArgs" /> class.
        /// </summary>
        /// <param name="stateChoices">The state choices.</param>
        public evAIstate_DialogChoices_EventArgs(params Tuple<AI_StateEngine_, string>[] stateChoices)
        {
            Cancel = false;
            NewState = null;
            StateChoices = stateChoices;
        }

        /// <summary>
        /// Gets a value that indicates why the form is being closed.
        /// </summary>
        public Tuple<AI_StateEngine_, string>[] StateChoices { get; private set; }

        public AI_StateEngine_ NewState { get; set; }
    }
}