using System;
using System.Windows.Forms;
using LamedalCore.zz;
using Lamedal_UIWinForms.libUI.Interfaces;

namespace Lamedal_UIWinForms.UControl.Forms
{
    public sealed class Forms_
    {
        private readonly Lamedal_WinForms IamWindows = Lamedal_WinForms.Instance;  // Set reference to Blueprint Windows lib

        /// <summary>
        /// Setup the SubForm.
        /// </summary>
        /// <param name="frmI">The form interface.</param>
        /// <param name="tabPage">The tab tabPage.</param>
        public static void SubForm_Setup(IForms_SetupSubForm frmI, TabPage tabPage)
        {
            if (frmI == null) throw  new ArgumentException("Error! The sub-form needs to inherit from SubForm_Interface",nameof(frmI));
            if (tabPage == null) frmI.Show();
            else
            {
                Lamedal_WinForms.Instance.libUI.WinForms.Controls.Control.MoveToContainer(frmI._groupMain, tabPage, true);  // Move subform controls to tab 
                frmI._groupSetup.Visible = false;
                frmI._splitter.Left--; // Refresh the form
                frmI._splitter.Left++;
            }
        }

        public void SubForm_Get<T>(Form thisForm, ref T subForm, TabControl tab = null, int tabNo = -1)
        {
            if (subForm == null)
            {
                var frm = Form_Create(typeof(T), thisForm);
                var frmI = frm as IForms_SetupSubForm;
                if (frmI == null)
                {
                    if (frm != null) throw new ArgumentException("Error! The sub-form needs to inherit from SubForm_Interface", nameof(frm));
                    throw new InvalidOperationException("Error! Cannot create sub-form");
                }
                tab.SelectedIndex = tabNo;
                TabPage page = tab.SelectedTab;
                IamWindows.libUI.WinForms.Controls.Control.MoveToContainer(frmI._groupMain, page); // Move subform controls to tab 
                frmI._groupSetup.Visible = false;
            }
        }

        public Form Form_Create(Type frmType, Form parentFormAsParameter = null, bool showDialog = false)
        {
            // Use reflection to create the  form
            // ConstructorInfo constructor = frmType.GetConstructor(new[] { typeof(int) });
            Form newForm = null;
            var constructor = frmType.GetConstructor(Type.EmptyTypes);
            if (constructor != null) newForm = (Form)Activator.CreateInstance(frmType); // Simple constructor

            if (parentFormAsParameter != null)
            {
                //constructor = frmType.GetConstructor(new[] { typeof(Form3T_MainMenu) });   // Find constructors that has FormT3_MainMenu as parameter
                constructor = frmType.GetConstructor(new[] { parentFormAsParameter.GetType() });  // Find constructors that has FormT3_MainMenu as parameter
                if (constructor != null) newForm = (Form)constructor.Invoke(new object[] { this });
            }

            return newForm;
        }
    }
}
