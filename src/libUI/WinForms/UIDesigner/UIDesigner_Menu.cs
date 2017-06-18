using System.ComponentModel;
using System.ComponentModel.Design;
using Lamedal_UIWinForms.libUI.Interfaces;
using Lamedal_UIWinForms.UControl._Designer;

namespace Lamedal_UIWinForms.libUI.WinForms.UIDesigner
{
    /// <summary>
    /// Stateless methods for Controls
    /// </summary>
    public sealed class UIDesigner_Menu
    {
        /// <summary>
        /// Basic Designer Menu.
        /// </summary>
        /// <param name="items">The items.</param>
        public void Designer_Base_Setup(DesignerActionItemCollection items)
        {
            items.Add(new DesignerActionHeaderItem("Layout"));
            items.Add(new DesignerActionPropertyItem("Text", "Text", "Layout"));
            //items.Add(new DesignerActionPropertyItem("Dock", "Dock", "Layout"));
            items.Add(new DesignerActionPropertyItem("Anchor", "Anchor", "Layout"));
            items.Add(new DesignerActionPropertyItem("Top", "Top", "Layout"));
            items.Add(new DesignerActionPropertyItem("Left", "Left", "Layout"));
            items.Add(new DesignerActionHeaderItem("Action"));
            items.Add(new DesignerActionPropertyItem("ContextMenuStrip", "ContextMenuStrip", "Action"));
        }

        #region AutoSize
        /// <summary>
        /// Autosize Designer properties.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <param name="component">The component.</param>
        public void Designer_AutoSize_Setup(DesignerActionItemCollection items, IComponent component)
        {
            var controlAutoSize = component as IUControl_Autosize;
            if (controlAutoSize != null)
            {
                items.Add(new DesignerActionHeaderItem("Autosize"));
                items.Add(new DesignerActionPropertyItem("AutoSize", "AutoSize", "Extended"));
                items.Add(new DesignerActionPropertyItem("AutoSizeMode", "AutoSizeMode", "Extended"));
            }
        }

        //// Past the following code into the designer and uncomment
        //#region Autosize

        //public AutoSizeMode AutoSizeMode
        //{
        //    get
        //    {
        //        return ((UControl_BaseInterface_Autosize)_Component).AutoSizeMode;
        //    }
        //    set
        //    {
        //        FireChanging();
        //        ((UControl_BaseInterface_Autosize)_Component).AutoSizeMode = value;
        //        FireChanged();
        //    }
        //}

        //public bool AutoSize
        //{
        //    get { return ((UControl_BaseInterface_Autosize)_Component).AutoSize; }
        //    set
        //    {
        //        FireChanging();
        //        ((UControl_BaseInterface_Autosize)_Component).AutoSize = value;
        //        FireChanged();
        //    }
        //}
        //#endregion

        #endregion

        public void Designer_GroupBox_FileStructure_Setup(DesignerActionItemCollection items, IComponent component)
        {
            var controlAutoSize = component as IGroupBox_FileStructure_Interface;
            if (controlAutoSize == null) return;

            items.Add(new DesignerActionHeaderItem("Structure"));
            items.Add(new DesignerActionPropertyItem("PartSize", "PartSize", "Structure"));
            items.Add(new DesignerActionPropertyItem("PartType", "PartType", "Structure"));
            items.Add(new DesignerActionPropertyItem("PartSummary", "PartSummary", "Structure"));
            //items.Add(new DesignerActionPropertyItem("PartProcess", "PartProcess", "Structure"));
        }

        public void Designer_Docking_Setup(DesignerActionItemCollection items, IComponent component)
        {
            var controlAutoSize = component as IUControl_Docking;
            if (controlAutoSize == null) return;

            items.Add(new DesignerActionHeaderItem("Docking"));
            items.Add(new DesignerActionPropertyItem("Dock", "Dock", "Docking"));
            items.Add(new DesignerActionPropertyItem("Parent_GroupBox", "GroupBox", "Docking"));
            items.Add(new DesignerActionPropertyItem("Parent_Panel", "Panel", "Docking"));

        }

    }
}
