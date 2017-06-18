using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using LamedalCore.zz;
using Lamedal_UIWinForms.Enumerals;
using Lamedal_UIWinForms.Events;
using Lamedal_UIWinForms.libUI.Interfaces;
using Lamedal_UIWinForms.zzz;

namespace Lamedal_UIWinForms.UControl.Input
{
    [Description("Input TextBox Control")]
    [Serializable]
    [DefaultEvent("Event_OnValueChange")]
    [DefaultProperty("Name")]
    [Designer(typeof(Input_Control_Designer))]   // Link the designer
    [Docking(DockingBehavior.Ask)]
    [ToolboxItem(true)]
    public sealed partial class Input_Control : UserControl_, IUControl_Docking, IUControl_ObjectModel
    {
        #region Init
        private readonly Lamedal_WinForms IamWindows = Lamedal_WinForms.Instance;
            // Set reference to Blueprint Windows lib

        private readonly Input_Control_Controller _controller;
        private enInputControl_Type _ControlType = enInputControl_Type.Edit;
        private Button _actionEnterButton;
        private string _Edit_Mask;
        private bool _control_Sync;
        private string _Field_LookupValue_Name;
        private string _Field_LookupID_Name;

        /// <summary>
        /// Initializes a new instance of the &lt;see cref=&quot;Input_Control&quot;/&gt; class.
        /// </summary>
        [Category("\tText")]
        [Description("Set Copy2Clipboard Text property")]
        public Input_Control()
        {
            Height = 35;
            _controller = new Input_Control_Controller(this);
            InitializeComponent();
            HookupEvents();
            DockChanged += DockChanged_Handler;

            500.zExecute_Async(checkDocking);
        }

        #endregion

        #region private methods
        private void DockChanged_Handler(object sender, EventArgs e)
        {
            Refresh_Other();
        }


        /// <summary>
        /// Check the docking.
        /// </summary>
        [Category("\tText")]
        [Description("Set Copy2Clipboard Text property")]
        private void checkDocking()
        {
            try
            {
                if (Control_IsHostedInDesigner() == false) return;
                if (this.Parent == null) return;

                // If similar controls in container -> do the same docking
                List<Component> controls = GetSameControlsOnParent();
                if (controls == null) return;

                if (controls.Count < 2) return;  // ------------------------

                // Check for docking
                var control = (Control)controls[0];
                if (control.Dock != DockStyle.None)
                {
                    if (this.Dock != control.Dock)
                    {
                        this.Dock = control.Dock;
                        //control.Dock.ToString().zOk();
                    }
                }

                //control = (Control)controls[1];
                //if (control.Dock != DockStyle.None) this.Dock = control.Dock;

            }
            catch (Exception e)
            {
                throw;
            }
        }

        private void Refresh_Other()
        {
            if (!_control_Sync) return;  //-----------------------------------

            // Get all Parent Controls of same type
            var centre = _Control_Centre;
            var dock = this.Dock;
            List<Component> controls = GetSameControlsOnParent();
            if (controls == null) return;
            foreach (Input_Control control in controls)
            {
                if (control.Dock != dock) control.Dock = dock;  // If check required to break the loop
                if (control._Control_Centre != centre) control._Control_Centre = centre;  // If check required to break the loop
            }

        }

        protected override void Notify_ParentFormIsLoaded()
        {
            Input_Control_Event_ParentForm_IsLoaded(null, null);
        }
        private void Input_Control_Event_ParentForm_IsLoaded(object sender, EventArgs e)
        {
            // Save the control settings
            if (_Action_AutoSave)
            {
                Control ctrl;
                evInput_Control_EventArgs args;
                _controller.Value_Get(out ctrl, out args);
                // Todo [1d] (New) Redo the property save mechanism
                //this.ParentForm.zProperties_LoadUser(ctrl);
                //this.ParentForm.zProperties_LoadUser(Ctrls.rdoValue1, Ctrls.rdoValue2, Ctrls.rdoValue3, Ctrls.rdoValue4);
                //this.ParentForm.zProperties_LoadUser(Ctrls.chkValue1, Ctrls.chkValue2, Ctrls.chkValue3);
            }
        }

        /// <summary>
        /// Finds the same controls on parent.
        /// </summary>
        /// <returns></returns>
        private List<Component> GetSameControlsOnParent()
        {
            // Get all Parent Controls of same type
            Control parent = this.Parent;
            if (!(parent is GroupBox || parent is Panel)) return new List<Component>();  // Return nothing if parent is not panel or GroupBox

            return Components_FromParent(parent, typeof(Input_Control));
        }

        #endregion

        #region Properties
        #region Ctrls
            /// <summary>
            /// Gets the edit control TextBox.
            /// </summary>
            [Category("Controls")]
            [Description("Gets the edit control TextBox.")]
            public TextBox Ctrl_Edit
            {
                get { return _controller.txtValue; }
            }

            /// <summary>
            /// Gets the label control.
            /// </summary>
            [Category("Controls")]
            [Description("Gets the label control.")]
            public Label Ctrl_Label
            {
                get { return _controller.lblName; }
            }

            /// <summary>
            /// Gets the edit mask control Masked as TextBox.
            /// </summary>
            [Category("Controls Dynamic")]
            [Description("Gets the edit mask control Masked as TextBox.")]
            public MaskedTextBox Ctrl_EditMask
            {
                get
                {
                    if (_controller.txtValueMasked != null) return _controller.txtValueMasked;
                    return null;
                }
            }

            /// <summary>
            /// Gets the ComboBox control.
            /// </summary>
            [Category("Controls Dynamic")]
            [Description("Gets the ComboBox control.")]
            public ComboBox Ctrl_Combobox
            {
                get
                {
                    if (_controller.cboValue != null) return _controller.cboValue;
                    return null;
                }
            }

            /// <summary>
            /// Gets the ListBox control.
            /// </summary>
            [Category("Controls Dynamic")]
            [Description("Gets the ListBox control.")]
            public ListBox Ctrl_ListBox
            {
                get
                {
                    if (_controller.lstValue != null) return _controller.lstValue;
                    return null;
                }
            }

            /// <summary>
            /// Gets the date time picker control as DateTimePicker.
            /// </summary>
            [Category("Controls Dynamic")]
            [Description("Return the Edit Control")]
            public DateTimePicker Ctrl_DateTimePicker
            {
                get
                {
                    if (_controller.dtpValue != null) return _controller.dtpValue;
                    return null;
                }
            }

            /// <summary>
            /// Gets the action button control.
            /// </summary>
            [Category("Controls")]
            [Description("Gets the action button control.")]
            public Button Ctrl_Button_Action
            {
                get
                {
                    return _controller.btnAction;
                }
            }

            /// <summary>
            /// Gets the button1 control.
            /// </summary>
            [Category("Controls Dynamic")]
            [Description("Gets the button1 control.")]
            public Button Ctrl_Button1
            {
                get
                {
                    if (_controller.btnValue1 != null) return _controller.btnValue1;
                    return null;
                }
            }
            /// <summary>
            /// Gets the button2 control.
            /// </summary>
            [Category("Controls Dynamic")]
            [Description("Gets the button2 control.")]
            public Button Ctrl_Button2
            {
                get
                {
                    if (_controller.btnValue2 != null) return _controller.btnValue2;
                    return null;
                }
            }
            #endregion

        #region Control
        [Category("\tBlueprint")]
        [Description("The Control Type")]
        [NotifyParentProperty(true)]                                               
        [RefreshProperties(RefreshProperties.All)]
        public enInputControl_Type ControlType
        {
            get { return _ControlType; }
            set
            {
                _ControlType = value;
                if (value == enInputControl_Type.Listbox) Height = 20 * 3 + 13;
                else Height = 35;
                _controller.Control_Type(value, 1, Action_Button);
                Sync(value);
            }
        }

        [Category("\tBlueprint")]
        [Description("The Control rows")]
        public int _Control_Rows
        {
            get { return _controller.Rows; }
            set { _controller.Control_Rows(value); }
        }

        [Category("\tBlueprint")]
        [Description("The Control Centre")]
        public int _Control_Centre
        {
            get { return _controller.LabelWidth; }
            set
            {
                _controller.LabelWidth = value;
                _controller.pnlLabel.Width = value;
                Refresh_Other();
            }
        }

        [Category("\tBlueprint")]
        [Description("When true, sync properties with similar controls")]
        public bool _Control_Sync
        {
            get { return _control_Sync; }
            set
            {
                _control_Sync = value;
                if (value) Refresh_Other();
            }
        }

        [Category("\tBlueprint")]
        [Description("The Active Control")]
        public Control _Control_Active
        {
            get
            {
                Control ctrl;
                evInput_Control_EventArgs args;
                _controller.Value_Get(out ctrl, out args);
                return ctrl;
            }
        }

        #endregion
        #region Field
        #region Field_Caption
        [Category("\tFields")]
        [Description("Edit the Caption")]
        public string Field_Caption
        {
            get { return _controller.Control_Caption; }
            set { _controller.Control_Caption = value; }
        }
        [Category("\tFields")]
        [Description("Edit the Caption")]
        public string Field_Caption2
        {
            get { return _controller.Control_Caption2; }
            set { _controller.Control_Caption2 = value; }
        }

        [Category("\tFields")]
        [Description("Edit the Caption")]
        public string Field_Caption3
        {
            get { return _controller.Control_Caption3; }
            set { _controller.Control_Caption3 = value; }
        }

        [Category("\tFields")]
        [Description("Edit the Caption")]
        public string Field_Caption4
        {
            get { return _controller.Control_Caption4; }
            set { _controller.Control_Caption4 = value; }
        }
        #endregion

        [Category("\tFields")]
        [Description("Set the Field Name")]
        public string Field_Name
        {
            get { return _Field_Name; }
            set { _Field_Name = value; }
        }
        private string _Field_Name;

        [Category("\tFields")]
        [Description("Set the Field Description")]
        public string Field_Description
        {
            get { return _Field_Description; }
            set { _Field_Description = value; }
        }
        private string _Field_Description;

        [Category("\tFields")]
        [Description("Edit the Text Value")]
        public string Field_Value
        {
            get { return _controller.Value_Get(); }
            set 
            { 
                _controller.Value_Set(value); 
            }
        }
        [Category("\tFields")]
        [Description("Edit the Text Value")]
        public bool Field_Value1
        {
            get { return _controller.Value_Get(1); }
            set
            {
                _controller.Value_Set(1,value);
            }
        }
        [Category("\tFields")]
        [Description("Edit the Text Value")]
        public bool Field_Value2
        {
            get { return _controller.Value_Get(2); }
            set
            {
                _controller.Value_Set(2,value);
            }
        }
        [Category("\tFields")]
        [Description("Edit the Text Value")]
        public bool Field_Value3
        {
            get { return _controller.Value_Get(3); }
            set
            {
                _controller.Value_Set(3,value);
            }
        }
        [Category("\tFields")]
        [Description("Edit the Value FieldName")]
        public string Lookup_ValueName
        {
            get { return _Field_LookupValue_Name; }
            set { _Field_LookupValue_Name = value; }
        }
        [Category("\tFields")]
        [Description("Edit the Value FieldName")]
        public string Lookup_IDName
        {
            get { return _Field_LookupID_Name; }
            set { _Field_LookupID_Name = value; }
        }
        #region Filter
        [Category("\tFilter")]
        [Description("Edit the filter FieldName")]
        public string Filter_FieldName
        {
            get { return _filterFieldName; }
            set { _filterFieldName = value; }
        }
        private string _filterFieldName;

        // zFilterValue
        [Category("\tFilter")]
        [Description("Edit the Filter value")]
        public object Filter_Value
        {
            get { return _filterValue; }
            set
            {
                if (_filterValue.zObject().AsStr() != value.zObject().AsStr())
                {
                    _filterValue = value;
                    Ctrl_Combobox.SelectedIndex = -1;
                }
            }
        }
        private object _filterValue;

        [Category("\tFilter")]
        [Description("Edit the 2nd filter FieldName")]
        public string Filter_FieldName2
        {
            get { return _filterFieldName2; }
            set { _filterFieldName2 = value; }
        }
        private string _filterFieldName2;

        [Category("\tFilter")]
        [Description("the 2nd filter Field Value")]
        public object Filter_Value2
        {
            get { return _filterValue2; }
            set
            {
                if (_filterValue2.zObject().AsStr() != value.zObject().AsStr())
                {
                    _filterValue2 = value;
                    Ctrl_Combobox.SelectedIndex = -1;
                }
            }
        }
        private object _filterValue2;

        [Category("\tFilter")]
        [Description("The Table name or SQL")]
        public string Filter_TableName
        {
            get { return _filterTableName; }
            set { _filterTableName = value; }
        }
        private string _filterTableName;

        [Category("\tFilter")]
        [Description("Set the Parent control")]
        public Input_Control Filter_Control
        {
            get { return _filterControl; }
            set { _filterControl = value; }
        }
        private Input_Control _filterControl;

        //[Category("\tFilter")]
        //[Description("Set or Get the SQL")]
        //public string Filter_SQL
        //{
        //    get { return _filterSql; }
        //}
        //private string _filterSql;

        private ComboBoxStyle _DropDownStyle = ComboBoxStyle.DropDown;
        #endregion
        #endregion
        #region Appearance
        [Category("Appearance")]
        [Description("Edit the Mask")]
        public string Edit_Mask
        {
            get { return _Edit_Mask; }
            set
            {
                _Edit_Mask = value;
                Sync(enInputControl_Type.Edit_Masked);
            }
        }

        private void Sync(enInputControl_Type controlType)
        {
            if (ControlType == controlType)
            {
                switch (controlType)
                {
                    case enInputControl_Type.Edit_Masked:
                        _controller.txtValueMasked.Mask = _Edit_Mask;
                        break;
                    case enInputControl_Type.Combobox:
                        _controller.cboValue.DropDownStyle = _DropDownStyle;
                        break;
                }
            }
        }

        [Category("Appearance")]
        [Description("Edit the Caption")]
        public char Edit_PasswordChar
        {
            get { return _controller.txtValue.PasswordChar; }
            set { _controller.txtValue.PasswordChar = value;}
        }

        [Category("Appearance")]
        [Description("Edit the DropDownStyle")]
        public ComboBoxStyle Combo_DropDownStyle
        {
            get { return _DropDownStyle; }
            set
            {
                _DropDownStyle = value;
                Sync(enInputControl_Type.Combobox);
            }
        }

        [Category("Appearance")]
        [Description("Set Border of the control")]
        public bool Border
        {
            get { return _controller.Border; }
            set { _controller.Border = value; }
        }

        [Category("Appearance")]
        [Description("Set Border color of the control")]
        public Color Border_Color
        {
            get { return _controller.Border_Color; }
            set { _controller.Border_Color = value; }
        }

        [Category("Appearance")]
        [Description("Set Border color of the control")]
        public int Border_Width
        {
            get { return _controller.Border_Width; }
            set { _controller.Border_Width = value; }
        }
        #endregion
        #region Button Action
        [Category("Action")]
        [Description("Set the Button Visiblity")]
        [NotifyParentProperty(true)]
        [RefreshProperties(RefreshProperties.All)]
        public bool Action_Button
        {
            get { return _Control_Action; }
            set
            {
                _Control_Action = value;
            }
        }

        [Category("\tBlueprint")]
        [Description("Set the Action Button Visiblity")]
        [NotifyParentProperty(true)]
        [RefreshProperties(RefreshProperties.All)]
        public bool _Control_Action
        {
            get { return _controller.pAction_Button; }
            set
            {
                _controller.pAction_Button = value;
                _controller.Control_Refresh();
            }
        }

        [Category("Action")]
        [Description("Set the Button width")]
        public int Action_Width
        {
            get { return _controller.pnlButton.Width; }
            set { _controller.pnlButton.Width = value; }
        }

        [Category("Action")]
        [Description("Set the Button Text")]
        public string Action_Text
        {
            get { return _controller.btnAction.Text; }
            set { _controller.btnAction.Text = value; }
        }

        [Category("Action")]
        [Description("When user press enter - execute this button")]
        public Button Action_EnterButton
        {
            get { return _actionEnterButton; }
            set { _actionEnterButton = value; }
        }

        [Category("Action")]
        [Description("Set the autosave")]
        public bool Action_AutoSave
        {
            get { return _Action_AutoSave; }
            set
            {
                _Action_AutoSave = value;
            }
        }
        private bool _Action_AutoSave;

        [Category("Action")]
        [Description("Set the Custom action")]
        [NotifyParentProperty(true)]
        [RefreshProperties(RefreshProperties.All)]
        public enInputControl_CustomAction Action_Custom
        {
            get { return _Action_Custom; }
            set
            {
                _Action_Custom = value;
                switch (value)
                {
                    case enInputControl_CustomAction.None: break;   // Do Nothing
                    // Setup the FileOpen Action
                    case enInputControl_CustomAction.File_Open_Button:
                        ControlType = enInputControl_Type.Button1;
                        Field_Caption = "Click to select the file";
                        Action_AutoSave = true;
                        break;

                    // Setup the FileOpen Action
                    case enInputControl_CustomAction.File_Open_Edit:
                        ControlType = enInputControl_Type.Edit;
                        _Control_Action = true;
                        if (Field_Caption == "FieldName") Field_Caption = "Path:";
                        Action_AutoSave = true;
                        break;
                        
                    default: (" Type '" + value + "' not defined!").zException_Show(); break;
                }
            }
        }
        private enInputControl_CustomAction _Action_Custom = enInputControl_CustomAction.None;

        #endregion
        #region Path
        [Category("Path")]
        [Description("Edit the Filter Name")]
        public string Path_FilterName
        {
            get { return _Path_FilterName; }
            set { _Path_FilterName = value; }
        }
        private string _Path_FilterName = "All Files";

        [Category("Path")]
        [Description("Edit the Filter")]
        public string Path_Filter
        {
            get { return _Path_Filter; }
            set { _Path_Filter = value; }
        }
        private string _Path_Filter = "*.*";

        #endregion

        #region Rules
        // Visible
        [Category("\tRules")]
        [Description("Link control that will setup the rules")]
        public Input_Control VisibleSet_Control
        {
            get { return _Visible_Control; }
            set { _Visible_Control = value; }
        }
        private Input_Control _Visible_Control;

        [Category("\tRules")]
        [Description("Set the Field Index")]
        public int VisibleSet_Index
        {
            get { return _VisibleSet_Index; }
            set { _VisibleSet_Index = value; }
        }
        private int _VisibleSet_Index = 1;

        // Enabled
        [Category("\tRules")]
        [Description("Link control that will setup the rules")]
        public Input_Control EnableSet_Control
        {
            get { return _EnableSet_Control; }
            set { _EnableSet_Control = value; }
        }
        private Input_Control _EnableSet_Control;

        [Category("\tRules")]
        [Description("Set the Field Index")]
        public int EnableSet_Index
        {
            get { return _EnableSet_Index; }
            set { _EnableSet_Index = value; }
        }
        private int _EnableSet_Index = 1;

        // Value Set
        [Category("\tRules")]
        [Description("Link control that will setup the rules")]
        public Input_Control ValueSet_Control
        {
            get { return _ValueSet_Control; }
            set { _ValueSet_Control = value; }
        }
        private Input_Control _ValueSet_Control;

        #endregion
        #endregion

        #region Events
        [Category("Blueprint")]
        [Description("Fire when key is pressed")]
        public event EventHandler<evInput_Control_EventArgs> Event_OnValueChange;

        [Category("Blueprint")]
        [Description("Fire when enter is clicked in textbox and a button is assigned")]
        public event EventHandler<evInput_Control_EventArgs> Event_OnEnterPressed;

        [Category("Blueprint")]
        [Description("Fire when the action button is clicked")]
        public event EventHandler<evInput_Control_EventArgs> Event_OnActionButtonClick;
        private void HookupEvents()
        {
            Ctrl_Edit.Click += Click_Test;
            _controller.Event_OnValueChange += Event_OnValueChange_Handle;
            _controller.Event_OnEnterPressed += Event_OnEnterPressed_Handle;
            _controller.Event_OnActionButtonClick += Event_OnButtonClick_Handle;
            this.DockChanged += OnDockChanged;
        }

        private void Click_Test(object sender, EventArgs e)
        {
            // Tempory test
            this.InvokeOnClick(this,e);
        }

        private void Event_OnButtonClick_Handle(object sender, evInput_Control_EventArgs e)
        {
            // Setup default event
            EventHandler<evInput_Control_EventArgs> hookEvent = Event_OnActionButtonClick;
            var isButton = Input_Control_Tools.IsButton(_ControlType);
            if (isButton && hookEvent == null) hookEvent = Event_OnValueChange;

            // File Open Action Button
            if (Action_Custom== enInputControl_CustomAction.File_Open_Button)
            {
                // Get the button
                var button = sender as Button;
                if (button == null) return;

                string path;
                if (button.Text.zDialogFile().File_OpenDialog(out path, _Path_Filter, _Path_FilterName))
                    button.Text = path; // File open dialog
                if (hookEvent == null) return; // -------------------------------------------
            }

            // File Open Edit
            if (Action_Custom== enInputControl_CustomAction.File_Open_Edit)
            {
                string path;
                if (Field_Value.zDialogFile().File_OpenDialog(out path, _Path_FilterName, _Path_Filter))
                    Field_Value = path; // File open dialog
                if (hookEvent == null) return; // -------------------------------------------
            }


            // Call Default Event Handler
            if (hookEvent == null) hookEvent = _controller.Button_DefaultAction_Handle; // Default handle

            // Fire Event
            e.Control_ = this;
            hookEvent(sender, e);
        }

        private void Event_OnEnterPressed_Handle(object sender, evInput_Control_EventArgs e)
        {
            if (Event_OnEnterPressed != null)
            {
                e.Control_ = this;
                Event_OnEnterPressed(sender, e);
            }
        }
        private void Event_OnValueChange_Handle(object sender, evInput_Control_EventArgs e)
        {
            // Rules
            var thisIsCheckbox = Input_Control_Tools.IsCheckbox(e.ControlType);
            var thisIsRadioButton = Input_Control_Tools.IsRadioButton(e.ControlType);
            if (thisIsCheckbox || thisIsRadioButton)
            {
                // Get controls
                var control = this.Parent;
                if (control != null)
                {
                    List<Component> controls = Components_FromControls(control.Controls, typeof(Input_Control));
                    foreach (var component in controls)
                    {
                        var input = component as Input_Control; 
                        if (input == null) continue;

                        #region Visible setting
                        if (input.VisibleSet_Control != null && input.VisibleSet_Control.Name == this.Name)
                        {
                            if (thisIsCheckbox)
                            {
                                if (input.VisibleSet_Index == 1) input.Visible = this.Field_Value1;
                                if (input.VisibleSet_Index == 2) input.Visible = this.Field_Value2;
                                if (input.VisibleSet_Index == 3) input.Visible = this.Field_Value3;
                            }
                            if (thisIsRadioButton)
                            {
                                if (input.VisibleSet_Index == 1) input.Visible = (this.Field_Value == "1");
                                if (input.VisibleSet_Index == 2) input.Visible = (this.Field_Value == "2");
                                if (input.VisibleSet_Index == 3) input.Visible = (this.Field_Value == "3");
                                if (input.VisibleSet_Index == 4) input.Visible = (this.Field_Value == "4");
                            }
                        }
                        #endregion

                        #region Enable setting
                        if (input.EnableSet_Control != null && input.EnableSet_Control.Name == this.Name)
                        {
                            if (thisIsCheckbox)
                            {
                                if (input.EnableSet_Index == 1) input.Enabled = this.Field_Value1;
                                if (input.EnableSet_Index == 2) input.Enabled = this.Field_Value2;
                                if (input.EnableSet_Index == 3) input.Enabled = this.Field_Value3;
                            }
                            if (thisIsRadioButton)
                            {
                                if (input.EnableSet_Index == 1) input.Enabled = (this.Field_Value == "1");
                                if (input.EnableSet_Index == 2) input.Enabled = (this.Field_Value == "2");
                                if (input.EnableSet_Index == 3) input.Enabled = (this.Field_Value == "3");
                                if (input.EnableSet_Index == 4) input.Enabled = (this.Field_Value == "4");
                            }
                        }
                        #endregion

                    }
                }
            }

            if (Event_OnValueChange != null)
            {
                e.Control_ = this;
                Event_OnValueChange(sender, e);
            }
        }
        #endregion

        #region Setup
        /// <summary>
        /// Add the Control.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="caption">The caption.</param>
        /// <param name="value">The value.</param>
        /// <param name="parentPanel">The parent panel.</param>
        /// <param name="button">if set to <c>true</c> [button].</param>
        /// <param name="mask">The mask.</param>
        /// <returns></returns>
        public Input_Control zSetup_Edit(string name, string caption, string value = "", GroupBox parentPanel = null, 
                bool button = false, string mask = "")
        {
            //this.Name = name;

            this.Field_Caption = caption;
            this.Field_Value = value;
            this.Action_Button = button;
            if (mask != "")
            {
                this.ControlType = enInputControl_Type.Edit_Masked;
                this.Edit_Mask = mask;
            }

            if (parentPanel != null)
            {
                //this.Parent = parentPanel;
                parentPanel.Controls.Add(this);
                this.Dock = DockStyle.Top;
                this.BringToFront();
            }
            this.Refresh();
            return this;
        }
        #endregion

        #region Docking in UserControl
        // Add this code to the UserControl that needs to implement Auto Docking movement of controls

        /// <summary>
        /// Handles the OnDockChanged event. If dock change to none make sure the control is visible (on the front).
        /// </summary>
        /// <param name="sender">The parent object that called this method</param>
        /// <param name="e">The event arguments</param>
        private void OnDockChanged(object sender, EventArgs e)
        {
            if (this.Dock == DockStyle.None)
            {
                var frm = this.FindForm();
                if (frm != null)
                {
                    frm.Controls.Add(this);
                    this.BringToFront();
                }
            }
        }

        /// <summary>
        /// If the parent is a GroupBox then show it. When set then change the parent of the control
        /// </summary>
        [Category("Docking")]
        [Description("Set the parent container")]
        public GroupBox Parent_GroupBox
        {
            get { return this.Parent as GroupBox; }
            set { IamWindows.libUI.WinForms.Controls.Control.MoveToContainer(this, value); }
        }

        /// <summary>
        /// If the parent is a GroupBox then show it. When set then change the parent of the control
        /// </summary>
        [Category("Docking")]
        [Description("Set the parent container")]
        public Panel Parent_Panel
        {
            get { return this.Parent as Panel; }
            set { IamWindows.libUI.WinForms.Controls.Control.MoveToContainer(this, value); }
        }
        #endregion

    }
}
