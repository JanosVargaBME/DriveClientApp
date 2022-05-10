using System;
using System.Collections.Generic;
using System.Text;

namespace DriveClient.Models
{
    /// <summary>
    /// Calss <c>BasicItem</c> represents an object from the Drive API, can be either a folder or a file.
    /// </summary>
    public class BasicItem
    {
        /// <summary>
        /// The id property of the thing taken from the API data.
        /// </summary>
        public string ID { get; set; } = string.Empty;
        /// <summary>
        /// The name property of the thing taken from the API data.
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// The Description property of the file taken from the API data.
        /// </summary>
        public string Description { get; set; } = string.Empty;
        /// <summary>
        /// Determines whether this thing is a file or a folder.
        /// </summary>
        public string Type { get; set; } = string.Empty;
        /// <summary>
        /// The time the file was created, this is a property of the file taken from the API data.
        /// </summary>
        public DateTime createdTime { get; set; } = DateTime.Now;
        /// <summary>
        /// In Bytes!!!!
        /// The size property of the file taken from the API data.
        /// </summary>
        public long Size { get; set; } = 0;
    }
}
