using DriveClient.Models;
using DriveClient.Services;
using DriveClient.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DriveClient.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DataListView : ContentPage
    {
        public DataListView()
        {
            InitializeComponent();
            this.BindingContext = new DataListViewModel(Navigation);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            (this.BindingContext as DataListViewModel).OnAppearing();
        }

        private async void MenuItem_Clicked_Open(object sender, EventArgs e)
        {
            var mi = sender as MenuItem;

            BasicItem bi = (BasicItem)mi.CommandParameter;

            if (bi != null)
            {
                if (bi.Type.Contains("Folder"))
                    await (this.BindingContext as DataListViewModel).LoadData(((DirectoryItem)bi).FullPath);
            }
        }

        //TODO
        private async void MenuItem_Clicked_Download(object sender, EventArgs e)
        {
            var mi = sender as MenuItem;

            BasicItem bi = (BasicItem)mi.CommandParameter;

            await BasicItemService.Instance.DownloadBasicItem(bi);
        }

        private void MenuItem_Clicked_Delete(object sender, EventArgs e)
        {
            var mi = sender as MenuItem;

            BasicItem bi = (BasicItem)mi.CommandParameter;

            BasicItemService.Instance.DeleteBasicItem(bi);
        }

        private async void Add_Button_Clicked(object sender, EventArgs e)
        {
            string folderName = await DisplayPromptAsync("Trying to create folder!", "What's the name of the folder?");

            await BasicItemService.Instance.CreateFolder(folderName);

            await (this.BindingContext as DataListViewModel).LoadData(BasicItemService.Instance.actualPath);
        }
    }
}