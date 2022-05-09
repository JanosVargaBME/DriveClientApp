using System;
using System.Collections.Generic;
using System.Text;

namespace DriveClient.Models
{
    /// <summary>
    /// Calss <c>DirectoryItem</c> represents a folder from the Drive API.
    /// If the mimeType is: 'application/vnd.google-apps.folder', then it's a folder.
    /// </summary>
    public class DirectoryItem : BasicItem
    {
        /// <summary>
        /// The full Path of this folder, calculated field.
        /// </summary>
        public string FullPath { get; set; } = string.Empty;
        /// <summary>
        /// Number of files in this directory.
        /// </summary>
        public int FileCount { get; set; } = 0;

        /*
        public DirectoryItem(string _ID, string _Name, string _Desc, string _Type, DateTime _created, string _fullpath, int _fileCount)
            : base(_ID, _Name, _Desc, _Type, _created)
        {
            FullPath = _ID;
            FileCount = _fileCount;
        }*/
    }
}
