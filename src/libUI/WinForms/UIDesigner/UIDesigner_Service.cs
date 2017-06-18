using System.CodeDom;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Windows.Forms;

namespace Lamedal_UIWinForms.libUI.WinForms.UIDesigner
{
    public sealed class UIDesigner_Service
    {
        public static CodeTypeDeclaration CodeTypeDeclaration_FromHost(IDesignerHost host)
        {
            return host.GetService(typeof(CodeTypeDeclaration)) as CodeTypeDeclaration;

        }

        /// <summary>Return the designer action UI service from the designer action list.</summary>
        public static DesignerActionUIService DesignerActionUIService_FromActionList(DesignerActionList actionList)
        {
            return actionList.GetService(typeof(DesignerActionUIService)) as DesignerActionUIService;
        }

        public static DesignerActionUIService DesignerActionUIService_FromHost(IDesignerHost host)
        {
            return host.GetService(typeof(DesignerActionUIService)) as DesignerActionUIService;
        }

        /// <summary>Return IComponentChangeService from the designer action list.</summary>
        public static IComponentChangeService IComponentChangeService_FromActionList(DesignerActionList actionList)
        {
            return actionList.GetService(typeof(IComponentChangeService)) as IComponentChangeService;
        }

        /// <summary>Return the IDesignerHost from the designer action list.</summary>
        public static IDesignerHost IDesignerHost_FromActionList(DesignerActionList actionList)
        {
            return actionList.GetService(typeof(IDesignerHost)) as IDesignerHost;
        }

        /// <summary>Return the IDesignerHost from the designer action list.</summary>
        public static IDesignerHost IDesignerHost_FromActionList(UserControl control)
        {
            return control.Site.GetService(typeof(IDesignerHost)) as IDesignerHost;
        }

        /// <summary>Return the IDesignerHost from the designer action list.</summary>
        public static IDesignerHost IDesignerHost_FromComponent(Component component)
        {
            if (component.Site == null) return null; 
            return component.Site.GetService(typeof(IDesignerHost)) as IDesignerHost;
        }

        /// <summary>Return the IDesignerHost from the designer action list.</summary>
        public static IDesignerHost IDesignerHost_FromForm(Form form)
        {
            if (form.Site == null) return null;

            return form.Site.GetService(typeof(IDesignerHost)) as IDesignerHost;
        }

        public static IEventBindingService IEventBindingService_FromHost(IDesignerHost host)
        {
            return host.GetService(typeof(IEventBindingService)) as IEventBindingService;
        }

        /// <summary>Return the ISelectionService from the idesigner host.</summary>
        public static ISelectionService ISelectionService_FromHost(IDesignerHost host)
        {
            return host.GetService(typeof(ISelectionService)) as ISelectionService;
        }

        /// <summary>Return the IDesignerHost from the designer action list.</summary>
        public static IToolboxService IToolboxService_FromActionList(DesignerActionList actionList)
        {
            return actionList.GetService(typeof(IToolboxService)) as IToolboxService;
        }
    }
}
