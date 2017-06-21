using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using LamedalCore;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.zz;
using Lamedal_UIWinForms.zzz;

namespace Lamedal_UIWinForms.lib.dotNet
{
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.Node_Action, DefaultType = typeof(Assembly))]
    public sealed class dotNet_Assembly
    {
        private readonly LamedalCore_ _lamed = LamedalCore_.Instance;  // Create new instance of the blueprint library

        /// <summary>
        /// Assembly_Get gets the all from remove system assemblies indicator. Default value = true..
        /// </summary>
        /// <param name="filterAssemblies">Remove system assemblies indicator. Default value = true.</param>
        /// <param name="filters">The filters.</param>
        /// <returns>
        /// List<Assembly_Get />
        /// </returns>
        public List<Assembly> Get_All(bool filterAssemblies = true, stateAssemblyFilters filters = null)
        {
            Assembly[] assemblyArray = AppDomain.CurrentDomain.GetAssemblies();
            List<Assembly> assemblies = assemblyArray.Where(x => x.IsDynamic == false).zUnique2().ToList();
            if (filterAssemblies == false) return assemblies;
            if (filters == null) filters = new stateAssemblyFilters();

            var assemblies2 = new List<Assembly>();
            foreach (Assembly assembly1 in assemblies)
            {
                //string name = assembly1.FullName.zvar_Id(" ");
                if (assembly1.GlobalAssemblyCache) continue;   // Ignore GAC assemblies
                if (assembly1.Location.zContains_Any(filters.FilterOut_Locations)) continue;
                if (assembly1.FullName.zContains_Any(filters.FilterOut_Names)) continue;
                assemblies2.Add(assembly1);
            }

            return assemblies2;
        }

        /// <summary>
        /// Assembly_Get gets the all from remove system assemblies indicator. Default value = true..
        /// </summary>
        /// <param name="assemblyNames">The assembly names.</param>
        /// <param name="filterAssemblies">Remove system assemblies indicator. Default value = true.</param>
        /// <param name="filters">The filters.</param>
        /// <returns>
        /// List<Assembly_Get />
        /// </returns>
        public IList<Assembly> Get_All(out IList<string> assemblyNames, bool filterAssemblies = true, stateAssemblyFilters filters = null)
        {
            var result = Get_All(filterAssemblies, filters);
            assemblyNames = result.Select(x => x.FullName.zvar_Id(" ")).ToList();
            assemblyNames = assemblyNames.zUnique();
            return result;
        }

        /// <summary>
        /// From the assembly return reflection types.
        /// </summary>
        /// <param name="assembly">The assembly</param>
        /// <param name="typeNameList">The class names.</param>
        /// <param name="typeAttributeDictionary">The type attributes.</param>
        /// <param name="filterValue">Name of the filter.</param>
        /// <param name="filterForThisAttribute">The filter for this attribute</param>
        /// <returns>
        /// List<string />
        /// </returns>
        public bool Types(Assembly assembly, out List<string> typeNameList, out Dictionary<string, Tuple<Type, Attribute>> typeAttributeDictionary,
            string filterValue = "", Attribute filterForThisAttribute = null)
        {
            var result = false;
            typeNameList = new List<string>();
            typeAttributeDictionary = new Dictionary<string, Tuple<Type, Attribute>>();

            Type[] classTypes = assembly.GetTypes();

            foreach (Type classType in classTypes)
            {
                string classTypeName = classType.FullName;
                if (filterForThisAttribute == null && filterValue == "") typeNameList.Add(classTypeName);
                else
                {
                    bool found = true;
                    Attribute attribute = null;

                    // Filter for attribute
                    if (filterForThisAttribute != null)
                    {
                        if (LamedalCore_.Instance.Types.Class.ClassAttributes.Find_ForType(classType,out filterForThisAttribute) == enCode_AttributeLocation.None)
                            found = false;
                        else attribute = filterForThisAttribute;   // filter attribute was found, assign it to attribute
                    }

                    // Filter for string
                    if (found && filterValue != "")
                    {
                        if (classTypeName.Contains(filterValue) == false) found = false;
                    }

                    if (found)
                    {
                        typeNameList.Add(classTypeName);
                        typeAttributeDictionary.Add(classTypeName, new Tuple<Type, Attribute>(classType, attribute));
                        result = true;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Locate the assembly assembly types to string list.
        /// </summary>
        /// <param name="assembly">The assembly</param>
        /// <param name="filterForThisAttribute">The filter for this attribute setting. Default value = null.</param>
        /// <returns>List<string/></returns>
        public List<string> Types_AsStrList(Assembly assembly, Attribute filterForThisAttribute = null)
        {
            List<string> typeNameList;
            Dictionary<string, Tuple<Type, Attribute>> typeAttributeDictionary;
            Types(assembly, out typeNameList, out typeAttributeDictionary, "", filterForThisAttribute);
            return typeNameList;
        }

        /// <summary>
        /// Return enumeral types from the assemblies list.
        /// </summary>
        /// <param name="assemblies">The assemblies list</param>
        /// <returns>List<Type/></returns>
        public IList<Type> Types_Enumerals(IList<Assembly> assemblies)
        {
            var myTypes = new List<Type>();
            foreach (Assembly x in assemblies)
            {
                try
                {
                    foreach (Type type in x.GetTypes()) myTypes.Add(type);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    throw;
                }
            }
            IList<Type> myTypes2 = myTypes.Where(x => x.IsEnum).ToList().zUnique();
            return myTypes2;
        }

        /// <summary>
        /// Return enumeral types from the assemblies list.
        /// </summary>
        /// <param name="assemblies">The assemblies list</param>
        /// <param name="typeNames">The type names.</param>
        /// <returns>
        /// List<Type />
        /// </returns>
        public IList<Type> Types_Enumerals(IList<Assembly> assemblies, out IList<string> typeNames)
        {
            IList<Type> result = Types_Enumerals(assemblies);
            typeNames = result.Select(x => x.Name).ToList().zUnique();
            return result;
        }
    }
}
