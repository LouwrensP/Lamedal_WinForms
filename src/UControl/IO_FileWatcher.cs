using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using LamedalCore;
using LamedalCore.zz;
using Lamedal_UIWinForms.zzz;

namespace Lamedal_UIWinForms.UControl
{
    /// <summary>
    /// 
    /// </summary>
    /// <code>CTI_Ignore;</code>
    public sealed class IO_FileWatcher
    {
        private readonly FileSystemWatcher _watcher;
        private readonly EventHandler _notifyHandler;
        private readonly TextBox _textNotify;
        private readonly HashSet<string> _fileChangeList = new HashSet<string>();
        private string[] _ignoreFilter;
        private DateTime _timer;

        /// <summary>
        /// Initializes a new instance of the <see cref="IO_FileWatcher" /> class.
        /// </summary>
        /// <param name="path">The path</param>
        /// <param name="syncroComponent">The syncro component</param>
        /// <param name="includeSubFolders">Include sub folders indicator. Default value = false.</param>
        /// <param name="watchFolders">Watch folders indicator. Default value = false.</param>
        /// <param name="notifyHandler">The notify handler setting. Default value = null.</param>
        /// <param name="ignoreFilter">The ignore filter.</param>
        public IO_FileWatcher(string path, Control syncroComponent, bool includeSubFolders = false, bool watchFolders = false, EventHandler notifyHandler = null, params string[] ignoreFilter)
        {
            _timer = DateTime.UtcNow;
            // Create a new FileSystemWatcher and set its properties.
            _watcher = new FileSystemWatcher();
            _watcher.Path = path;
            _notifyHandler = notifyHandler;
            _ignoreFilter = ignoreFilter;

            //_watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            if (watchFolders)
                _watcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.DirectoryName;
            else _watcher.NotifyFilter = NotifyFilters.LastWrite;

            // Only watch these files.
            //_watcher.Filter = "*.cs|*.csproj";  // Does not work because VS do not save in this way

            // Add event handlers.
            _watcher.Changed += watch_OnChanged;
            _watcher.Created += watch_OnChanged;
            _watcher.Deleted += watch_OnChanged;
            _watcher.Renamed += watch_OnRenamed;

            // Begin watching.
            _watcher.IncludeSubdirectories = includeSubFolders;
            _watcher.InternalBufferSize = 4096 * 5;  // Increase the buffer size
            if (syncroComponent != null)
            {
                _watcher.SynchronizingObject = syncroComponent;
                var textBox = syncroComponent as TextBox;
                if (textBox != null)
                {
                    _textNotify = textBox;
                    _textNotify.Text = path.NL();
                }
            }
            _watcher.EnableRaisingEvents = true;
        }

        /// <summary>
        /// Resets the specified ignore filter.
        /// </summary>
        /// <param name="ignoreFilter">The ignore filter.</param>
        public void Reset(params string[] ignoreFilter)
        {
            if (ignoreFilter.Length > 0) _ignoreFilter = ignoreFilter;
            _fileChangeList.Clear();
            _timer = DateTime.UtcNow;
            _notifyHandler(this, null);
        }

        /// <summary>
        /// Gets the change list.
        /// </summary>
        public HashSet<string> ChangeList
        {
            get { return _fileChangeList; }
        }

        /// <summary>
        /// Gets the total files  changed as int.
        /// </summary>
        public int Change_Total
        {
            get { return _fileChangeList.Count; }
        }

        /// <summary>
        /// Gets the change list as string.
        /// </summary>
        public string ChangeList_AsStr
        {
            get
            {
                return LamedalCore_.Instance.Types.List.String.ToString(_fileChangeList.ToList(), "".NL());
            }
        }

        /// <summary>
        /// Gets the start time.
        /// </summary>
        public DateTime StartTime
        {
            get { return _timer; }
        }

        /// <summary>
        /// On renamed file watcher event.
        /// </summary>
        /// <param name="sender">The source of the event method</param>
        /// <param name="e">The renamed event arguments</param>
        private void watch_OnRenamed(object sender, RenamedEventArgs e)
        {
            string msg = String.Format("File: {0} renamed to {1}".NL(),e.OldFullPath, e.FullPath);
            Console.WriteLine(msg);
            watch_Notify(e.FullPath);
        }

        /// <summary>
        /// On changed file watcher event.
        /// </summary>
        /// <param name="sender">The source of the event method</param>
        /// <param name="e">The file system event arguments</param>
        private void watch_OnChanged(object sender, FileSystemEventArgs e)
        {
            string msg = ("File: " + e.FullPath + " " + e.ChangeType).NL();
            Console.WriteLine(msg);
            watch_Notify(e.FullPath);
        }

        /// <summary>
        /// Notifies the client of file watcher watch changes.
        /// </summary>
        /// <param name="path">The path</param>
        private void watch_Notify(string path)
        {
            if (_notifyHandler != null)
            {
                if (path.Contains("~")) return;
                foreach (string ignore in _ignoreFilter)
                {
                    if (path.Contains(ignore)) return;
                }

                _fileChangeList.Add(path);  // Add the new path

                if (_textNotify != null) _textNotify.Text += path.NL();

                500.zExecute_Async( () =>_notifyHandler(this, null), "fileChanges", true);   // Only fire the event at most once every 500 milli seconds
            }

        }

    }
}
