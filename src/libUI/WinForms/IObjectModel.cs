namespace Lamedal_UIWinForms.libUI.WinForms
{
    /// <summary>
    /// This interface set a marker to identify types that can be generated.
    /// </summary>
    public interface IObjectModel
    {
        // This type is important to filter between object and classes you want to generate.
        // It has no methods so other classes should be able to generate to this one.
        // Code generation should not be dependable on this interface
    }
}