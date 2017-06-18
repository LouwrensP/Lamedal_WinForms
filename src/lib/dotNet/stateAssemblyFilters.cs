namespace Lamedal_UIWinForms.lib.dotNet
{
    /// <code>CTI_State</code>
    public sealed class stateAssemblyFilters
    {
        private string[] _filterOutLocations = { "Microsoft.NET\\Framework", "\\Program Files", "\\Common Files", "\\Common7\\IDE" };
        private string[] _filterOutNames = { "Microsoft.", "mscorlib", "vshost32", "JetBrains.", "DevExpress.", "Infragistics2", "NuGet.", 
                                               "SubMain.", "Muse.", "Castle.", "System.Windows.", ".CodeMaid" };

        public string[] FilterOut_Locations
        {
            get { return _filterOutLocations; }
            set { _filterOutLocations = value; }
        }

        public string[] FilterOut_Names
        {
            get { return _filterOutNames; }
            set { _filterOutNames = value; }
        }
    }
}
