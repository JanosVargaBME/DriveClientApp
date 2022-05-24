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

        public async Task DeleteBasicItem(BasicItem basicItem)
        {

        }

        internal void DownloadBasicItem(BasicItem bi)
        {
            throw new NotImplementedException();
        }
    }
}
