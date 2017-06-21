using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;
using LamedalCore;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.zz;

namespace Lamedal_UIWinForms.lib.dotNet
{
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.Node_Action)]
    public sealed class dotNet_Resources
    {
        private readonly LamedalCore_ _lamed = LamedalCore_.Instance;  // Create new instance of the blueprint library

        /// <summary>
        /// Loads the assembly resource from the executable.
        /// </summary>
        /// <param name="exe">The executable</param>
        /// <param name="loadThisAssemblyName">The load this assembly name</param>
        /// <returns>Assembly_Get</returns>
        public Assembly Assembly_Load(Assembly exe, string loadThisAssemblyName)
        {
            string dllResourceName = FindName(exe, loadThisAssemblyName);
            //string[] names = exe.GetManifestResourceNames();   // Uncomment this line to debug the possible values for dllName Assembly_Get assembly;

            using (Stream stream = exe.GetManifestResourceStream(dllResourceName))
            {
                if (stream == null)
                {
                    Debug.Print("Error! Unable to find '" + dllResourceName + "'");
                    // Uncomment the next lines to show message the moment an assembly is not found. (This will also stop for .Net assemblies)
                    //MessageBox.Show("Error! Unable to find '" + dllName + "'! Application will terminate.");
                    //Environment.Exit(0);
                    return null;
                }

                byte[] buffer = new BinaryReader(stream).ReadBytes((int)stream.Length);
                Assembly assembly = Assembly.Load(buffer);
                return assembly;
            }
        }

        /// <summary>
        /// Converts the assembly resources to dictionary using reflection.
        /// </summary>
        /// <param name="assembly">The assembly</param>
        /// <param name="resourceFile">The resource file.</param>
        /// <returns></returns>
        public Dictionary<string, string> Convert_ToStrDictionary(Assembly assembly, string resourceFile = "Properties.Resources")
        {
            ResourceSet resourceSet = ResourceSet(assembly, resourceFile);
            Dictionary<string, string> resourceDictionary = Convert_ToStrDictionary(resourceSet);
            return resourceDictionary;
        }

        public Dictionary<string, string> Convert_ToStrDictionary(ResourceSet resourceSet, string findValue = "")
        {
            Dictionary<string, string> strDictionary = null;
            Convert_ToStrDictionary(resourceSet, ref strDictionary);
            return strDictionary;
        }

        public void Convert_ToStrDictionary(ResourceSet resourceSet, ref Dictionary<string, string> stringDictionary, string findValue = "")
        {
            if (stringDictionary == null) stringDictionary = new Dictionary<string, string>();
            foreach (DictionaryEntry entry in resourceSet)
            {
                var resourceKey = entry.Key as string;
                var resourceStr = entry.Value as string;
                if (resourceStr != null && resourceKey != null)
                {
                    if (findValue == "" || resourceKey.ToLower().Contains(findValue)) stringDictionary.Add(resourceKey, resourceStr);
                }
            }
        }

        /// <summary>
        /// Converts assembly resource to string list.
        /// </summary>
        /// <param name="assembly">The assembly</param>
        /// <param name="source">Return the source list</param>
        /// <param name="fileName">The file name</param>
        /// <param name="resourceFile">The resource file setting. Default value = &quot;Properties.Resources&quot;.</param>
        /// <returns>bool</returns>
        public bool Convert_ToStrList(Assembly assembly, out List<string> source, string fileName, string resourceFile = "Properties.Resources")
        {
            source = null;
            var stringDictionary = Convert_ToStrDictionary(assembly, resourceFile);
            string sourceLine;
            if (stringDictionary.TryGetValue(fileName, out sourceLine))
            {
                source = sourceLine.zConvert_Str_ToListStr("".NL());
                return true;
            }
            return false;
        }

        ///// <summary>
        ///// Return the resources from the assembly.
        ///// </summary>
        ///// <param name="assembly">The assembly</param>
        ///// <param name="filter">The filter setting. Default value = &quot;&quot;.</param>
        ///// <returns>List<string/></returns>
        //public List<string> Convert_ToStrList(Assembly_Get assembly, string filter = "")
        //{
        //    // I was not able to get this to work - need more testing
        //    var resources = assembly.GetManifestResourceNames();
        //    if (filter != "") return resources.Where(x => x.Contains(filter)).ToList();
        //    return resources.ToList();
        //}

        public string FindName(Assembly exeAssembly, string findThisAssemblyName)
        {
            if (findThisAssemblyName.Contains(".dll") == false) findThisAssemblyName += ".dll";

            foreach (string name in exeAssembly.GetManifestResourceNames())
            {
                if (name.EndsWith(findThisAssemblyName)) return name;
            }
            return findThisAssemblyName;
        }

        /// <summary>
        /// Return the resource set for the assembly.
        /// </summary>
        /// <param name="assembly">The assembly</param>
        /// <param name="resourceFile">The resource file setting. Default value = &quot;Properties.Resources&quot;.</param>
        /// <returns>ResourceSet</returns>
        public ResourceSet ResourceSet(Assembly assembly, string resourceFile = "Properties.Resources")
        {
            var rootNamespace = _lamed.Types.Assembly.To_Namespace(assembly) + "." + resourceFile;
            var resourceManager = new ResourceManager(rootNamespace, assembly);
            ResourceSet resourceSet = resourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
            return resourceSet;
        }
    }
}
