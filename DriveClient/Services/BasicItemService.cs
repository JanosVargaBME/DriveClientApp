using DriveClient.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DriveClient.Services
{
    internal class BasicItemService
    {
        public string actualPath = "";

        private List<BasicItem> basicItems = new List<BasicItem>();
        public static BasicItemService Instance { get; private set; } = new BasicItemService();

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
        public async Task<bool> CreateFolder(string name)
        {
            bool result = false;
            if (actualPath == "")
                result = await DropBoxService.Instance.CreateFolder("/" + name);
            else
                result = await DropBoxService.Instance.CreateFolder(actualPath + "/" + name);

            return result;
        }

        public async Task<bool> DeleteBasicItem(BasicItem basicItem)
        {
            bool result = false;
            if (basicItem.Type.Contains("Folder"))
                result = await DropBoxService.Instance.DeleteFolderOrFile(((DirectoryItem)basicItem).FullPath);
            else
                result = await DropBoxService.Instance.DeleteFolderOrFile(actualPath + "/" + basicItem.Name);

            return result;
        }

        public async Task DownloadBasicItem(BasicItem bi)
        {
            
        }
    }
}
