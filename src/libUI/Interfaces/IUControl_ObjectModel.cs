namespace Lamedal_UIWinForms.libUI.Interfaces
{
    public interface IUControl_ObjectModel
    {
        string Field_Name { get; set; }

        string Field_Value { get; set; }

        //#region IUControl_ObjectModel implementation

        //[Category("\tFields")]
        //[Description("Set the Field Name")]
        //public string Field_Name
        //{
        //    get { return _Field_Name; }
        //    set { _Field_Name = value; }
        //}

        //private string _Field_Name;

        //[Category("\tFields")]
        //[Description("Edit the Text Value")]
        //public string Field_Value
        //{
        //    get { return Value_Get(); }
        //    set { Value_Set(value); }
        //}

        //private string Value_Get()
        //{
        //    return this.Text; //<=========================[Modify this
        //}

        //private void Value_Set(string value)
        //{
        //    // Add code here to set the value
        //    // =============================
        //    this.Text = value;
        //}

        //#endregion

    }
}