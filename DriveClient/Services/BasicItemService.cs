using DriveClient.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DriveClient.Services
{
    /// <summary>
    /// <c>BasicItemService</c> manages the List of the files and directories, calls the DropBoxService class's functions
    /// </summary>
    internal class BasicItemService
    {
        /// <summary>
        /// Contains the current full path of the directory in in Dropbox API
        /// </summary>
        public string actualPath = "";
        /// <summary>
        /// Contains the file and directory items from the API.
        /// </summary>
        private List<BasicItem> basicItems = new List<BasicItem>();
        /// <summary>
        /// For singleton purpose
        /// </summary>
        public static BasicItemService Instance { get; private set; } = new BasicItemService();

        /// <summary>
        /// Initializes the basicItems list by calling the DropBox class's functions
        /// </summary>
        /// <param name="path">The path of the folder we want to get the elements of</param>
        /// <returns>The List of BasicItems from the API</returns>
        public async Task<List<BasicItem>> InitList(string path)
        {
            actualPath = path;

            basicItems = new List<BasicItem>();

            var directories = await DropBoxService.Instance.GetDirectories(actualPath);

            var files = await DropBoxService.Instance.GetFiles(actualPath);

            basicItems.AddRange(directories);

            basicItems.AddRange(files);

            return basicItems;
        }

        /// <summary>
        /// Creates folder at the current path with the given name, by calling the DropBox's functions
        /// </summary>
        /// <param name="name">The name of the new folder</param>
        /// <returns>Returns true if the folder is created and false if there was an error</returns>
        public async Task<bool> CreateFolder(string name)
        {
            bool result = false;
            if (actualPath == "")
                result = await DropBoxService.Instance.CreateFolder("/" + name);
            else
                result = await DropBoxService.Instance.CreateFolder(actualPath + "/" + name);

            return result;
        }

        /// <summary>
        /// Deletes the given file or folder from the API
        /// (Moves it to the trash)
        /// </summary>
        /// <param name="basicItem"></param>
        /// <returns></returns>
        public async Task<bool> DeleteBasicItem(BasicItem basicItem)
        {
            bool result = false;
            if (basicItem.Type.Contains("Folder"))
                result = await DropBoxService.Instance.DeleteFolderOrFile(((DirectoryItem)basicItem).FullPath);
            else
                result = await DropBoxService.Instance.DeleteFolderOrFile(actualPath + "/" + basicItem.Name);

            return result;
        }

        /// <summary>
        /// Downloads the given item from the API to the local machine
        /// </summary>
        /// <param name="bi">The clicked item object</param>
        /// <returns>True if it was successful</returns>
        public async Task<bool> DownloadBasicItem(BasicItem bi)
        {
            bool result = false;



            return result;
        }
    }
}
