using System;
using System.Collections.Generic;
using System.Text;

namespace DriveClient.Models
{
    /// <summary>
    /// Calss <c>FileItem</c> represents a file type with metadata, taken from the API. 
    /// </summary>
    public class FileItem
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
        /// The kind property of the file taken from the API data.
        /// </summary>
        public string Kind { get; set; } = string.Empty;
        /// <summary>
        /// In Bytes!!!!
        /// The size property of the file taken from the API data.
        /// </summary>
        public long Size { get; set; } = 0;
        /// <summary>
        /// The Description property of the file taken from the API data.
        /// </summary>
        public string Description { get; set; } = string.Empty;
        /// <summary>
        /// The mimeType property of the file taken from the API data, stores the type of data like: 'file_type/specific_type'.
        /// For example: video/mpeg, image/jpeg
        /// </summary>
        public string MimeType { get; set; } = string.Empty;
        /// <summary>
        /// The time the file was created, this is a property of the file taken from the API data.
        /// </summary>
        public DateTime createdTime { get; set; } = DateTime.Now;
        /// <summary>
        /// The time the file was last modified, this is a property of the file taken from the API data.
        /// </summary>
        public DateTime modifiedTime { get; set; } = DateTime.Now;
    }
}
