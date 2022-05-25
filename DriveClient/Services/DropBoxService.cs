using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DriveClient.Models;
using Dropbox.Api;
using Dropbox.Api.Files;

namespace DriveClient.Services
{
    /// <summary>
    /// <c>DropBoxService</c> is responsible for communicating with the dropbox API.
    /// </summary>
    internal class DropBoxService
    {
        /// <summary>
        /// Contains the access token the program can connect to the API
        /// </summary>
        private string accessToken = "";
        /// <summary>
        /// Contains the actual user's username.
        /// </summary>
        public string actualUser = "";
        /// <summary>
        /// For singleton pattern
        /// </summary>
        public static DropBoxService Instance { get; private set; } = new DropBoxService();
        
        /// <summary>
        /// Checks if the token is actually good or nah. Sets the actualUser by Calling the GetCurrentAccountAsync() method
        /// </summary>
        /// <param name="token">The access token we want to try</param>
        /// <returns>
        /// True: If login is okay
        /// </returns>
        public async Task<bool> IsValidLogin(string token)
        {
            accessToken = token;
            using (var db = new DropboxClient(accessToken))
            {
                try
                {
                    var id = await db.Users.GetCurrentAccountAsync();

                    if(id == null)
                        return false;

                    actualUser = id.Name.DisplayName;

                    if (actualUser == "")
                        return false;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// This method gets the files from the API. ONLY the files!
        /// </summary>
        /// <param name="actualPath">Path of the directory we want to get the files of</param>
        /// <returns>List with FileItems or an empty list, if there are no files there</returns>
        public async Task<List<FileItem>> GetFiles(string actualPath)
        {
            List<FileItem> files = new List<FileItem>();

            using (var db = new DropboxClient(accessToken))
            {
                try
                {
                    var list = await db.Files.ListFolderAsync(actualPath);

                    if(list == null)
                        return files;

                    foreach (var f in list.Entries.Where(i => i.IsFile))
                    {
                        files.Add(new FileItem
                        {
                            ID = f.AsFile.Id,
                            Name = f.AsFile.Name,
                            createdTime = f.AsFile.ServerModified,
                            ModifiedTime = f.AsFile.ClientModified,
                            Size = (long)f.AsFile.Size,
                            Type = "Assets/File.png"
                        });
                    }
                }
                catch (Exception)
                {
                    return files;
                }
            }
            return files;
        }

        /// <summary>
        /// This method gets the directories from the API. ONLY the directories!
        /// </summary>
        /// <param name="actualPath">Path of the directory we want to get the folders of</param>
        /// <returns>
        /// List with DirectoryItems or an empty list, if there are no directories there
        /// </returns>
        public async Task<List<DirectoryItem>> GetDirectories(string actualPath)
        {
            List<DirectoryItem> directories = new List<DirectoryItem>();

            using (var db = new DropboxClient(accessToken))
            {

                try
                {
                    var list = await db.Files.ListFolderAsync(actualPath);

                    if(list == null)
                        return directories;

                    foreach (var file in list.Entries.Where(i => i.IsFolder))
                    {
                        directories.Add(new DirectoryItem
                        {
                            ID = file.AsFolder.Id,
                            Name = file.AsFolder.Name,
                            FullPath = file.AsFolder.PathDisplay,
                            createdTime = DateTime.Now,
                            FileCount = 0,
                            Type = "Assets/Folder.png",
                        });
                    }
                }
                catch (Exception)
                {
                    return directories;
                }
            }
            return directories;
        }

        /// <summary>
        /// This method tries to upload a file to the dropbox, by calling the UploadAsync() function.
        /// </summary>
        /// <param name="name">The name of the file on Dropbox</param>
        /// <param name="stream">The file's stream, used to read the file</param>
        /// <returns>
        /// True: If the file was created
        /// False: If there was an error
        /// </returns>
        public async Task<bool> UploadFile(string name, Stream stream)
        {
            using (var dbx = new DropboxClient(accessToken))
            {
                try
                {
                    var response = await dbx.Files.UploadAsync(BasicItemService.Instance.actualPath + "/" + name, WriteMode.Overwrite.Instance, body: stream);

                    if(response == null)
                        return false;
                }
                catch (Exception)
                {
                    return false;
                }

                return true;
            }
        }

        /// <summary>
        /// Not used :(
        /// </summary>
        /// <param name="name"></param>
        /// <param name="stream"></param>
        /// <returns></returns>
        public async Task<bool> DownloadFile(string name, Stream stream)
        {
            using (var dbx = new DropboxClient(accessToken))
            {
                try
                {
                    var data = await dbx.Files.DownloadAsync(BasicItemService.Instance.actualPath + "/" + name);

                    Stream ds = await data.GetContentAsStreamAsync();

                    await ds.CopyToAsync(stream);

                    ds.Dispose();
                }
                catch (Exception)
                {
                    return false;
                }

                return true;
            }
        }

        /// <summary>
        /// This method tries to Create a folder in the dropbox api, by calling the CreateFolderV2Async() function.
        /// </summary>
        /// <param name="name">Name of the folder</param>
        /// <returns>
        /// True: If the folder was created
        /// False: If there was an error
        /// </returns>
        public async Task<bool> CreateFolder(string name)
        {
            using (var dbx = new DropboxClient(accessToken))
            {
                var folderArg = new CreateFolderArg(name);

                try
                {
                    var folder = await dbx.Files.CreateFolderV2Async(folderArg);

                    if (folder == null)
                        return false;
                }
                catch (Exception)
                {
                    return false;
                }
                return true;
            }
        }

        /// <summary>
        /// Deletes a folder or a file from the API, by calling the DeleteV2Async() function
        /// </summary>
        /// <param name="path">The path of the file or folder we want to delete</param>
        /// <returns>True if deleted, false if there was an error</returns>
        public async Task<bool> DeleteFolderOrFile(string path)
        {
            using (var dbx = new DropboxClient(accessToken))
            {
                DeleteArg deleteArg = new DeleteArg(path);

                try
                {
                    var result = await dbx.Files.DeleteV2Async(deleteArg);

                    if (result == null)
                        return false;
                }
                catch (Exception)
                {
                    return false;
                }

                return true;
            }
        }
    }
}
