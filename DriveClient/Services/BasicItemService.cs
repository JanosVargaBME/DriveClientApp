using DriveClient.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DriveClient.Services
{
    internal class BasicItemService
    {

        private List<BasicItem> basicItems = new List<BasicItem>();
        public static BasicItemService Instance { get; private set; } = new BasicItemService();

        public async Task initList()
        {
            basicItems = new List<BasicItem>();

            var directories = await DropBoxService.Instance.GetDirectories(string.Empty);

            basicItems.AddRange(directories);
        }

        public async Task<List<BasicItem>> GetThings()
        {
            await initList();
            return basicItems;
        }
    }
}
