using System;
using System.Windows.Forms;

namespace Lamedal_UIWinForms.libUI.WinForms.Controls
{
    public sealed class Controls_Create
    {

        /// <summary>
        /// Creates the type specified
        /// </summary>
        /// <returns>T</returns>
        public static object Create(Type type)
        {
            //(T)Activator.CreateInstance(typeof(T), new object[] { constructorParameter });
            var newObject_ = Activator.CreateInstance(type, new object[] { });
            return newObject_;
        }

        /// <summary>Add a new control to the form.</summary>
        public T Add2Form<T>(Control panelofForm)
        {
            if (panelofForm == null) return default(T);
            {
                var newControl_ = (T)Create(typeof(T));

                var control = newControl_ as Control;
                if (control != null)
                {
                    control.Parent = panelofForm;
                    //newControl.Text = Text != null ? Text : newControl.Name;
                    control.BringToFront();
                }

                return newControl_;
            }
        }
    }
}
