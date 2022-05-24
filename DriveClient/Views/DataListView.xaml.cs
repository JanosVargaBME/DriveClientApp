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

        private void MenuItem_Clicked_Open(object sender, EventArgs e)
        {
            var mi = sender as MenuItem;

            BasicItem bi = (BasicItem)mi.CommandParameter;

            if(bi != null)
            {
                if (bi.Type.Contains("Folder"))
                    (this.BindingContext as DataListViewModel).LoadData(((DirectoryItem)bi).FullPath);
            }
        }

        private void MenuItem_Clicked_Download(object sender, EventArgs e)
        {
            var mi = sender as MenuItem;

            BasicItem bi = (BasicItem)mi.CommandParameter;

            BasicItemService.Instance.DownloadBasicItem(bi);
        }

        private void MenuItem_Clicked_Delete(object sender, EventArgs e)
        {
            var mi = sender as MenuItem;

            BasicItem bi = (BasicItem)mi.CommandParameter;

            BasicItemService.Instance.DeleteBasicItem(bi);
        }
    }
}