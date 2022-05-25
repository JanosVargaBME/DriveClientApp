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
        /// <summary>
        /// Call's the view's OnAppearing() function.
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();
            (this.BindingContext as DataListViewModel).OnAppearing();
        }

        /// <summary>
        /// Handle's the RightClick -> Open option on the MenuItems.
        /// If it's a folder, than the actualpath changes to it's path.
        /// If it's a file, nothing happens.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Handle's the RightClick -> Open option on the MenuItems.
        /// Deletes the file or folder from the API, calling the BasicITemService class.
        /// Displays alert for the deleted Object.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void MenuItem_Clicked_Delete(object sender, EventArgs e)
        {
            var mi = sender as MenuItem;

            BasicItem bi = (BasicItem)mi.CommandParameter;

            var result = await BasicItemService.Instance.DeleteBasicItem(bi);

            if (result)
                await DisplayAlert("Alert", $"{bi?.Name} deleted!", "OK");

            await (this.BindingContext as DataListViewModel).LoadData(BasicItemService.Instance.actualPath);
        }

        /// <summary>
        /// Handle's the "Add Folder" button's onclick event.
        /// Tries to Create a folder, it's name is given by the user in a pop-up dialog.
        /// Usis the BasicItemService.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Add_Button_Clicked(object sender, EventArgs e)
        {
            string folderName = await DisplayPromptAsync("Trying to create folder!", "What's the name of the folder?");

            var result = await BasicItemService.Instance.CreateFolder(folderName);

            if (result)
                await DisplayAlert("Alert", $"{folderName} created!", "OK");

            await (this.BindingContext as DataListViewModel).LoadData(BasicItemService.Instance.actualPath);
        }


        //TODO
        private async void MenuItem_Clicked_Download(object sender, EventArgs e)
        {
            var mi = sender as MenuItem;

            BasicItem bi = (BasicItem)mi.CommandParameter;

            await BasicItemService.Instance.DownloadBasicItem(bi);
        }
    }
}