using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Lamedal_UIWinForms.libUI.WinForms.UIDesigner
{
    public static class UIDesigner_Form
    {
        //private static int _FormLoadTries = 0;

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

        /// <summary>
        /// Creates the type specified
        /// </summary>
        /// <returns>T</returns>
        public static T Create<T>()
        {
            return (T)Create<T>(typeof(T));
        }

        /// <summary>
        /// Creates the type specified
        /// </summary>
        /// <returns>T</returns>
        public static T Create<T>(object Param1)
        {
            // To be tested
            //(T)Activator.CreateInstance(typeof(T), new object[] { constructorParameter });
            var newObject_ = (T)Activator.CreateInstance(typeof(T), new object[] { Param1 });
            return newObject_;
        }

        /// <summary>
        /// Return the main form for the component. It is important to delay the loading of this
        /// </summary>
        /// <param name="component">The component</param>
        /// <returns></returns>
        public static Form Form_Main(Component component)
        {
            var host = UIDesigner_Service.IDesignerHost_FromComponent(component);
            var form = UIDesigner_Tools.Host_Controls_Form(host);
            return form;
        }


    }
}
