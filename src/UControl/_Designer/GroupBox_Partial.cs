using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Lamedal_UIWinForms.zzz;

namespace Lamedal_UIWinForms.UControl._Designer
{
    public partial class GroupBox_
    {
        #region Init

        private readonly UIWindows IamWindows = UIWindows.Instance; // Set reference to Blueprint Windows lib
        private DateTime FiveSecondsAfterStartup;
        /// <summary>
        /// Initializes a new instance of the <see cref="UserControl_"/> class.
        /// </summary>
        protected void Initialize()
        {
            FiveSecondsAfterStartup = DateTime.UtcNow.AddSeconds(5);
            //InitializeComponent();

            // Notify clients that parent is loaded
            this.ParentChanged -= OnParentChanged;
            this.ParentChanged += OnParentChanged;
        }

        private void OnParentChanged(object sender, EventArgs e)
        {
            WaitForParentFormToLoad();
        }

        private void WaitForParentFormToLoad()
        {
            if (DateTime.UtcNow > FiveSecondsAfterStartup)
            {
                Debug.Print("Parent form never loaded for usercontrol: '" + this.GetType() + "'");   // This should never happen 
                return;
            }
            if (FindForm() == null)
            {
                200.zExecute_Async(WaitForParentFormToLoad);  // Call recursively after few milliseconds
                return;
            }
            Notify_ParentFormIsLoaded();
        }
        #endregion

        /// <summary>
        /// Notify client that the parent form is loaded for this control.
        /// </summary>
        protected virtual void Notify_ParentFormIsLoaded()
        {
            // Place custom code here that (like Control_Dock())
        }
        
        /// <summary>
        /// The dock command.
        /// </summary>
        /// <param name="dockStyle">The dock style.</param>
        /// <param name="ifParentIsInThisTypes">The if parent is in this types array.</param>
        protected void Command_Dock(DockStyle dockStyle = DockStyle.Top, params Type[] ifParentIsInThisTypes)
        {
            if (Ask_IsParentFormLoaded() == false) return;
            IamWindows.libUI.WinForms.Controls.Control.Dock(this, dockStyle, ifParentIsInThisTypes);
        }

        /// <summary>
        /// The dock in panel command.
        /// </summary>
        /// <param name="dockStyle">The dock style.</param>
        protected void Command_DockInPanel(DockStyle dockStyle = DockStyle.Top)
        {
            Command_Dock(dockStyle, typeof(Panel), typeof(GroupBox));
        }

        /// <summary>
        /// Ask whether the parent form loaded.
        /// </summary>
        /// <param name="showMsg">The show msg.</param>
        /// <returns><c>true</c> if is parent form loaded ask, <c>false</c> otherwise.</returns>
        protected bool Ask_IsParentFormLoaded(bool showMsg = false)
        {
            if (FindForm() == null)
            {
                if (showMsg) "The parent form is not loaded! You can use Notify_ParentFormIsLoaded() method to fix this.".zOk();
                return false;
            }
            return true;
        }

        /// <summary>
        /// Determines whether is hosted in designer ask.
        /// </summary>
        /// <returns><c>true</c> if is hosted in designer ask, <c>false</c> otherwise.</returns>
        protected bool Ask_IsHostedInDesigner()
        {

            return IamWindows.libUI.WinForms.Controls.Control.IsHostedInDesigner(this);
        }

        /// <summary>
        /// Ask if this control is on the main form.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <returns></returns>
        protected bool Ask_IsParentFormTheMainForm(Control control = null)
        {
            if (control == null) control = this;
            Form myForm = control.FindForm();
            return UIWindows.Instance.libUI.WinForms.Tools.Form_IsMainForm(myForm);
        }

        /// <summary>
        /// Requests all sub components.
        /// </summary>
        /// <param name="forTheseControls">For these controls.</param>
        /// <param name="filterForTypes">The filter for types.</param>
        /// <returns></returns>
        public List<Component> Request_AllSubComponents(IList forTheseControls = null, params Type[] filterForTypes)
        {
            if (forTheseControls == null) forTheseControls = this.Controls;
            return IamWindows.libUI.WinForms.Controls.Control.FindComponents(forTheseControls, true, filterForTypes);
        }

        /// <summary>
        /// Requests all parent sub components.
        /// </summary>
        /// <param name="redoAction">if set to <c>true</c> [redo action].</param>
        /// <param name="filterForTypes">The filter for types.</param>
        /// <returns></returns>
        public List<Component> Request_AllParentSubComponents(bool redoAction = false, params Type[] filterForTypes)
        {
            if (!Ask_IsParentFormLoaded()) return null;

            Form frmParent = this.FindForm();
            if (redoAction || _parentSubComponents == null) _parentSubComponents = IamWindows.libUI.WinForms.Controls.Control.FindComponents(frmParent, true, filterForTypes);
            return _parentSubComponents;
        }
        private List<Component> _parentSubComponents;


        #region Hide
        #region Hide Properties Not Used
        /// <summary>
        /// Gets or sets a value indicating whether the container enables the user to scroll to any controls placed outside of its visible boundaries.
        /// </summary>
        /// <returns>true if the container enables auto-scrolling; otherwise, false. The default value is false. </returns>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public bool AutoScroll { get; set; }

        ///// <summary>
        ///// Gets or sets a value indicating whether [auto size].
        ///// </summary>
        ///// <value>
        /////   <c>true</c> if [auto size]; otherwise, <c>false</c>.
        ///// </value>
        //[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        //[Obsolete("just cast me to avoid all this hiding...", true)]
        //public new bool AutoSize { get; set; }

        ///// <summary>
        ///// Gets or sets how the control will resize itself.
        ///// </summary>
        ///// <returns>A value from the <see cref="T:System.Windows.Forms.AutoSizeMode" /> enumeration. The default is <see cref="F:System.Windows.Forms.AutoSizeMode.GrowOnly" />.</returns>
        //[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        //public new AutoSizeMode AutoSizeMode { get; set; }

        ///// <summary>
        ///// Gets or sets the border style of the user control.
        ///// </summary>
        ///// <returns>One of the <see cref="T:System.Windows.Forms.BorderStyle" /> values. The default is <see cref="F:System.Windows.Forms.BorderStyle.Fixed3D" />.</returns>
        /////   <PermissionSet>
        /////   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /////   </PermissionSet>
        //[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        //[Obsolete("just cast me to avoid all this hiding...", true)]
        //public new BorderStyle BorderStyle { get; set; }

        /// <summary>
        /// Gets or sets the description of the control used by accessibility client applications.
        /// </summary>
        /// <returns>The description of the control used by accessibility client applications. The default is null.</returns>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new string AccessibleDescription { get; set; }

        /// <summary>
        /// Gets or sets the name of the control used by accessibility client applications.
        /// </summary>
        /// <returns>The name of the control used by accessibility client applications. The default is null.</returns>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new string AccessibleName { get; set; }

        /// <summary>
        /// Gets or sets the accessible role of the control
        /// </summary>
        /// <returns>One of the values of <see cref="T:System.Windows.Forms.AccessibleRole" />. The default is Default.</returns>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new AccessibleRole AccessibleRole { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the control can accept data that the user drags onto it.
        /// </summary>
        /// <returns>true if drag-and-drop operations are allowed in the control; otherwise, false. The default is false.</returns>
        ///   <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
        ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        ///   </PermissionSet>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new bool AllowDrop { get; set; }

        /// <summary>
        /// Gets or sets the size of the auto-scroll margin.
        /// </summary>
        /// <returns>A <see cref="T:System.Drawing.Size" /> that represents the height and width of the auto-scroll margin in pixels.</returns>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public Size AutoScrollMargin { get; set; }

        /// <summary>
        /// Gets or sets the minimum size of the auto-scroll.
        /// </summary>
        /// <returns>A <see cref="T:System.Drawing.Size" /> that determines the minimum size of the virtual area through which the user can scroll.</returns>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public Size AutoScrollMinSize { get; set; }

        ///// <summary>
        ///// Gets or sets how the control performs validation when the user changes focus to another control.
        ///// </summary>
        ///// <returns>A member of the <see cref="T:System.Windows.Forms.AutoValidate" /> enumeration. The default value for <see cref="T:System.Windows.Forms.UserControl" /> is <see cref="F:System.Windows.Forms.AutoValidate.EnablePreventFocusChange" />.</returns>
        //[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        //[Obsolete("just cast me to avoid all this hiding...", true)]
        //public new virtual AutoValidate AutoValidate { get; set; }

        /// <summary>
        /// Gets or sets the Input Method Editor (IME) mode of the control.
        /// </summary>
        /// <returns>One of the <see cref="T:System.Windows.Forms.ImeMode" /> values. The default is <see cref="F:System.Windows.Forms.ImeMode.Inherit" />.</returns>
        ///   <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
        ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        ///   </PermissionSet>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new ImeMode ImeMode { get; set; }

        /// <summary>
        /// Gets or sets the space between controls.
        /// </summary>
        /// <returns>A <see cref="T:System.Windows.Forms.Padding" /> representing the space between controls.</returns>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new Padding Margin { get; set; }

        /// <summary>
        /// Gets or sets the size that is the upper limit that <see cref="M:System.Windows.Forms.Control.GetPreferredSize(System.Drawing.Size)" /> can specify.
        /// </summary>
        /// <returns>An ordered pair of type <see cref="T:System.Drawing.Size" /> representing the width and height of a rectangle.</returns>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        //[Obsolete("just cast me to avoid all this hiding...", true)]
        public new virtual Size MaximumSize { get; set; }

        /// <summary>
        /// Gets or sets the size that is the lower limit that <see cref="M:System.Windows.Forms.Control.GetPreferredSize(System.Drawing.Size)" /> can specify.
        /// </summary>
        /// <returns>An ordered pair of type <see cref="T:System.Drawing.Size" /> representing the width and height of a rectangle.</returns>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        //[Obsolete("just cast me to avoid all this hiding...", true)]
        public new virtual Size MinimumSize { get; set; }

        ///// <summary>
        ///// Gets or sets padding within the control.
        ///// </summary>
        ///// <returns>A <see cref="T:System.Windows.Forms.Padding" /> representing the control's internal spacing characteristics.</returns>
        /////   <PermissionSet>
        /////   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /////   </PermissionSet>
        //[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        //[Obsolete("just cast me to avoid all this hiding...", true)]
        //public new Padding Padding { get; set; }

        ///// <summary>
        ///// Gets or sets a value indicating whether control's elements are aligned to support locales using right-to-left fonts.
        ///// </summary>
        ///// <returns>One of the <see cref="T:System.Windows.Forms.RightToLeft" /> values. The default is <see cref="F:System.Windows.Forms.RightToLeft.Inherit" />.</returns>
        /////   <PermissionSet>
        /////   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /////   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /////   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
        /////   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /////   </PermissionSet>
        //[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        //[Obsolete("just cast me to avoid all this hiding...", true)]
        //public new virtual RightToLeft RightToLeft { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to use the wait cursor for the current control and all child controls.
        /// </summary>
        /// <returns>true to use the wait cursor for the current control and all child controls; otherwise, false. The default is false.</returns>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new bool UseWaitCursor { get; set; }
        #endregion

        #region Hide Main Properties
        /// <summary>
        /// Gets or sets the background image displayed in the control.
        /// </summary>
        /// <returns>An <see cref="T:System.Drawing.Image" /> that represents the image to display in the background of the control.</returns>
        ///   <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        ///   </PermissionSet>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        //[Obsolete("just cast me to avoid all this hiding...", true)]
        public new virtual Image BackgroundImage { get; set; }

        /// <summary>
        /// Gets or sets the background image layout as defined in the <see cref="T:System.Windows.Forms.ImageLayout" /> enumeration.
        /// </summary>
        /// <returns>One of the values of <see cref="T:System.Windows.Forms.ImageLayout" /> (<see cref="F:System.Windows.Forms.ImageLayout.Center" /> , <see cref="F:System.Windows.Forms.ImageLayout.None" />, <see cref="F:System.Windows.Forms.ImageLayout.Stretch" />, <see cref="F:System.Windows.Forms.ImageLayout.Tile" />, or <see cref="F:System.Windows.Forms.ImageLayout.Zoom" />). <see cref="F:System.Windows.Forms.ImageLayout.Tile" /> is the default value.</returns>
        ///   <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        ///   </PermissionSet>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new virtual ImageLayout BackgroundImageLayout { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the control causes validation to be performed on any controls that require validation when it receives focus.
        /// </summary>
        /// <returns>true if the control causes validation to be performed on any controls requiring validation when it receives focus; otherwise, false. The default is true.</returns>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new bool CausesValidation { get; set; }

        ///// <summary>
        ///// Gets or sets the shortcut menu associated with the control.
        ///// </summary>
        ///// <returns>A <see cref="T:System.Windows.Forms.ContextMenu" /> that represents the shortcut menu associated with the control.</returns>
        //[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        //[Obsolete("just cast me to avoid all this hiding...", true)]
        //public new virtual ContextMenu ContextMenu { get; set; }

        /// <summary>
        /// Gets or sets the cursor that is displayed when the mouse pointer is over the control.
        /// </summary>
        /// <returns>A <see cref="T:System.Windows.Forms.Cursor" /> that represents the cursor to display when the mouse pointer is over the control.</returns>
        ///   <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
        ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        ///   </PermissionSet>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new virtual Cursor Cursor { get; set; }

        /// <summary>
        /// Gets or sets the foreground color of the control.
        /// </summary>
        /// <returns>The foreground <see cref="T:System.Drawing.Color" /> of the control. The default is the value of the <see cref="P:System.Windows.Forms.Control.DefaultForeColor" /> property.</returns>
        ///   <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        ///   </PermissionSet>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        //[Obsolete("just cast me to avoid all this hiding...", true)]
        public new virtual Color ForeColor { get; set; }

        ///// <summary>
        ///// Gets or sets the <see cref="T:System.Windows.Forms.ContextMenuStrip" /> associated with this control.
        ///// </summary>
        ///// <returns>The <see cref="T:System.Windows.Forms.ContextMenuStrip" /> for this control, or null if there is no <see cref="T:System.Windows.Forms.ContextMenuStrip" />. The default is null.</returns>
        //[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        //[Obsolete("just cast me to avoid all this hiding...", true)]
        //public new virtual ContextMenuStrip ContextMenuStrip { get; set; }

        //[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]        
        //public new ControlBindingsCollection DataBindings { get; set; }

        //[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]        
        //public new virtual Color BackColor { get; set; }

        ///// <summary>
        ///// Gets or sets the font of the text displayed by the control.
        ///// </summary>
        ///// <returns>The <see cref="T:System.Drawing.Font" /> to apply to the text displayed by the control. The default is the value of the <see cref="P:System.Windows.Forms.Control.DefaultFont" /> property.</returns>
        /////   <PermissionSet>
        /////   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /////   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /////   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
        /////   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /////   </PermissionSet>
        //[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        //[Obsolete("just cast me to avoid all this hiding...", true)]
        //public new virtual Font Font { get; set; }

        #endregion

        #region Hide Events
#pragma warning disable 67
        // ChangeUICues
        /// <summary>
        /// Occurs when [change UI cues].
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new event UICuesEventHandler ChangeUICues;

        // ControlAdded
        /// <summary>
        /// Occurs when [control added].
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new event ControlEventHandler ControlAdded;

        // ControlRemoved
        /// <summary>
        /// Occurs when [control removed].
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new event ControlEventHandler ControlRemoved;

        // HelpRequested
        /// <summary>
        /// Occurs when [help requested].
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new event HelpEventHandler HelpRequested;

        // QueryAccessibilityHelp
        /// <summary>
        /// Occurs when [query accessibility help].
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new event QueryAccessibilityHelpEventHandler QueryAccessibilityHelp;

        // StyleChanged
        /// <summary>
        /// Occurs when [style changed].
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new event EventHandler StyleChanged;

        // SystemColorsChanged
        /// <summary>
        /// Occurs when [system colors changed].
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new event EventHandler SystemColorsChanged;

        #region DragEvents
        //DragDrop
        /// <summary>
        /// Occurs when [drag drop].
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new event DragEventHandler DragDrop;

        // DragEnter
        /// <summary>
        /// Occurs when [drag enter].
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new event DragEventHandler DragEnter;

        // DragLeave
        /// <summary>
        /// Occurs when [drag leave].
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new event EventHandler DragLeave;

        //DragOver
        /// <summary>
        /// Occurs when [drag over].
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new event DragEventHandler DragOver;

        //GiveFeedback
        /// <summary>
        /// Occurs when [give feedback].
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new event GiveFeedbackEventHandler GiveFeedback;

        //QueryContinueDrag
        /// <summary>
        /// Occurs when [query continue drag].
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new event QueryContinueDragEventHandler QueryContinueDrag;

        #endregion

        #region FocusEvents
        //Leave
        /// <summary>
        /// Occurs when [leave].
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new event EventHandler Leave;

        //Validating
        //    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        //    [Obsolete("just cast me to avoid all this hiding...", true)]
        //    public new event CancelEventHandler Validating;

        #endregion

        #region KeyEvents
        //    //KeyDown
        //    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        //    [Obsolete("just cast me to avoid all this hiding...", true)]
        //    public new event KeyEventHandler KeyDown;

        //    //KeyUp
        //    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        //    [Obsolete("just cast me to avoid all this hiding...", true)]
        //    public new event KeyEventHandler KeyUp;

        //    //PrewiewKeyDown
        //    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        //    [Obsolete("just cast me to avoid all this hiding...", true)]
        //    public new event PreviewKeyDownEventHandler PreviewKeyDown;

        #endregion

        #region Layout
        //Layout
        /// <summary>
        /// Occurs when [layout].
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new event LayoutEventHandler Layout;

        //MarginChanged
        /// <summary>
        /// Occurs when [margin changed].
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new event EventHandler MarginChanged;

        //Move
        /// <summary>
        /// Occurs when [move].
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new event EventHandler Move;

        //PaddingChanged
        /// <summary>
        /// Occurs when [padding changed].
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new event EventHandler PaddingChanged;

        //Resize
        //[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        //[Obsolete("just cast me to avoid all this hiding...", true)]
        //public new event EventHandler Resize;

        # endregion

        #region Mouse
        //MouseDown
        /// <summary>
        /// Occurs when [mouse down].
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new event MouseEventHandler MouseDown;

        //MouseUp
        /// <summary>
        /// Occurs when [mouse up].
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new event MouseEventHandler MouseUp;

        //MouseHover
        /// <summary>
        /// Occurs when [mouse hover].
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new event EventHandler MouseHover;

        //MouseEnter
        /// <summary>
        /// Occurs when [mouse enter].
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new event EventHandler MouseEnter;

        //MouseLeave
        /// <summary>
        /// Occurs when [mouse leave].
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new event EventHandler MouseLeave;

        #endregion

        #region onPropertyChanged
        //AutoSizeChanged
        /// <summary>
        /// Occurs when [auto size changed].
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new event EventHandler AutoSizeChanged;

        //   //AutoValidateChanged
        //   [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        //   [Obsolete("just cast me to avoid all this hiding...", true)] 



        //BackColourChanged
        /// <summary>
        /// Occurs when [back color changed].
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new event EventHandler BackColorChanged;

        //BackgroundImageChange
        /// <summary>
        /// Occurs when [background image changed].
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new event EventHandler BackgroundImageChanged;

        //BackgroundImageLayoutChanged
        /// <summary>
        /// Occurs when [background image layout changed].
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new event EventHandler BackgroundImageLayoutChanged;

        //BindingContextChanged
        /// <summary>
        /// Occurs when [binding context changed].
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new event EventHandler BindingContextChanged;

        //CausesValidationChanged
        /// <summary>
        /// Occurs when [causes validation changed].
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new event EventHandler CausesValidationChanged;

        //ClientSizeChanged
        /// <summary>
        /// Occurs when [client size changed].
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new event EventHandler ClientSizeChanged;

        //ContextMenueStripChanged
        /// <summary>
        /// Occurs when [context menu strip changed].
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new event EventHandler ContextMenuStripChanged;

        //CursorChanged
        /// <summary>
        /// Occurs when [cursor changed].
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new event EventHandler CursorChanged;

        ////DockChanged
        ///// <summary>
        ///// Occurs when [dock changed].
        ///// </summary>
        //[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        //[Obsolete("just cast me to avoid all this hiding...", true)]
        //public new event EventHandler DockChanged;

        //EnabledChanged
        /// <summary>
        /// Occurs when [enabled changed].
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new event EventHandler EnabledChanged;

        //FontChanged
        /// <summary>
        /// Occurs when [font changed].
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new event EventHandler FontChanged;

        //ForeColourChanged
        /// <summary>
        /// Occurs when [fore color changed].
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new event EventHandler ForeColorChanged;

        //LocationChanged
        /// <summary>
        /// Occurs when [location changed].
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new event EventHandler LocationChanged;

        ////ParentChanged
        ///// <summary>
        ///// Occurs when [parent changed].
        ///// </summary>
        //[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        //[Obsolete("just cast me to avoid all this hiding...", true)]
        //public new event EventHandler ParentChanged;

        //RegionChanged
        /// <summary>
        /// Occurs when [region changed].
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new event EventHandler RegionChanged;

        //RighttoLeftChanged
        /// <summary>
        /// Occurs when [right to left changed].
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new event EventHandler RightToLeftChanged;

        //SizeChanged
        /// <summary>
        /// Occurs when [size changed].
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new event EventHandler SizeChanged;

        //TabIndexChanged
        /// <summary>
        /// Occurs when [tab index changed].
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new event EventHandler TabIndexChanged;

        //TabStopChanged
        /// <summary>
        /// Occurs when [tab stop changed].
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new event EventHandler TabStopChanged;

        #endregion


#pragma warning restore 67
        #endregion
        #endregion
    }
}
