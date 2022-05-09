using DriveClient.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DriveClient.Services
{
    internal class BasicItemService
    {

        private List<BasicItem> basicItems = new List<BasicItem>();
        public static BasicItemService Instance { get; private set; } = new BasicItemService();

        public void initList()
        {
            basicItems = new List<BasicItem>();

            basicItems.AddRange(DirectoryItemService.Instance.GetDirectories());
            basicItems.AddRange(FileItemService.Instance.GetFiles());
        }

        public List<BasicItem> GetThings()
        {
            initList();
            return basicItems;
        }
    }
}
