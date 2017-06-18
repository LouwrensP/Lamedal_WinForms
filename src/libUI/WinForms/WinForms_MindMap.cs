using System.Collections.Generic;
using System.IO;
using System.Linq;
using LamedalCore;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.lib;

namespace Lamedal_UIWinForms.libUI.WinForms
{
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.Node_Action)]
    public sealed class WinForms_MindMap
    {
        private readonly LamedalCore_ _lamed = LamedalCore_.Instance; // system library

        /// <summary>
        /// Converts the file list to XML file.
        /// </summary>
        /// <param name="fileTreeList">The file list</param>
        /// <param name="outputFilename">The output file</param>
        public void FileList_ToXMLFile(List<string> fileTreeList, string outputFilename)
        {
            var xDoc_mm = _lamed.lib.XML.Mindmap.XDoc_FromNodeStringList(fileTreeList);
            string XML = xDoc_mm.ToString();
            1f.zIO().RW.File_Write(outputFilename, XML,true);
        }

        /// <summary>
        /// Creates the file list from the file path.
        /// </summary>
        /// <param name="filePath">The file path</param>
        /// <param name="rootName">The root name setting. Default value = &quot;&quot;.</param>
        /// <returns>List<string/></returns>
        public List<string> FileList_FromFilepath(string filePath, string rootName = "")
        {
            if (rootName == "") rootName = filePath;
            var files = Directory.GetFiles(filePath, "*", SearchOption.AllDirectories).Select(x => x.Replace(filePath, rootName).Replace(@"\", ":")).ToList();
            files.Insert(0, rootName);
            return files;
        }

    }
}
