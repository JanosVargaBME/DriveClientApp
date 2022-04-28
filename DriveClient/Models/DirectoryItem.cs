using System;
using System.Collections.Generic;
using System.Text;

namespace DriveClient.Models
{
    /// <summary>
    /// Calss <c>DirectoryItem</c> represents a folder fram the Drive API.
    /// If the mimeType is: 'application/vnd.google-apps.folder', then it's a folder.
    /// </summary>
    public class DirectoryItem
    {
        /// <summary>
        /// The id property of the file taken from the API data.
        /// </summary>
        public string ID { get; set; } = string.Empty;
        /// <summary>
        /// The name property of the file taken from the API data.
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// The Description property of the file taken from the API data.
        /// </summary>
        public string Description { get; set; } = string.Empty;
    }
}
