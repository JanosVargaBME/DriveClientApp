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
    internal class DropBoxService
    {
        private string accessToken = "";

        public string actualUser = "";

        public static DropBoxService Instance { get; private set; } = new DropBoxService();
        
        public async Task<bool> IsValidLogin(string token)
        {
            accessToken = token;
            using (var db = new DropboxClient(accessToken))
            {
                var id = await db.Users.GetCurrentAccountAsync();

                actualUser = id.Name.DisplayName;
            }

            if(actualUser != "")
                return true;

            return false;
        }

        public async Task<List<FileItem>> GetFiles(string actualPath)
        {
            List<FileItem> files = new List<FileItem>();

            using (var db = new DropboxClient(accessToken))
            {
                var list = await db.Files.ListFolderAsync(actualPath);

                foreach (var f in list.Entries.Where(i => i.IsFile))
                {
                    files.Add(new FileItem
                    {
                        ID = f.AsFile.Id,
                        Name = f.AsFile.Name,
                        createdTime = f.AsFile.ServerModified,
                        ModifiedTime = f.AsFile.ClientModified,
                        Size = (long)f.AsFile.Size,
                        Type = f.AsFile.MediaInfo?.ToString() ?? "Not photo/video"
                    });
                }
            }
            return files;
        }

        public async Task<List<DirectoryItem>> GetDirectories(string actualPath)
        {
            List<DirectoryItem> directories = new List<DirectoryItem>();

            using (var db = new DropboxClient(accessToken))
            {
                var list = await db.Files.ListFolderAsync(actualPath);

                foreach (var file in list.Entries.Where(i => i.IsFolder))
                {
                    directories.Add(new DirectoryItem
                    {
                        ID = file.AsFolder.Id,
                        Name = file.AsFolder.Name,
                        FullPath = file.AsFolder.PathDisplay,
                        createdTime = DateTime.Now,
                        FileCount = 0,
                        Type = "Folder",
                    });
                }
            }
            return directories;
        }

        public async Task<bool> UploadFile(string name, Stream stream)
        {
            using (var dbx = new DropboxClient(accessToken))
            {

                var response = await dbx.Files.UploadAsync(BasicItemService.Instance.actualPath + "/" + name, WriteMode.Overwrite.Instance, body: stream);

                return true;
            }
        }
    }
}
