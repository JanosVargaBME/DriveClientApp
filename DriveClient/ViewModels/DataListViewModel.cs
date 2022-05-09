using DriveClient.Models;
using DriveClient.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace DriveClient.ViewModels
{
    internal class DataListViewModel : BaseViewModel
    {
        //CHANGE THIS SHIT
        public List<FileItem> Files => FileItemService.Instance.GetFiles();

        public string URLposition = "/";

        public string FullURLposition { get { return "Your current position: " + URLposition; } }

        public ICommand DeleteCommand { get; set; }
        public ICommand OpenCommand { get; set; }

        public DataListViewModel(INavigation navigation) : base(navigation)
        {
            DeleteCommand = new Command(DeleteCommandExecute);
            OpenCommand = new Command(OpenCommandExecute);
        }

        private void DeleteCommandExecute()
        {
            //TODO: Torolni az adott objektumot
        }

        private async void OpenCommandExecute()
        {
            //TODO: Megnyitni az adott oldalt
        }

        public override void OnAppearing()
        {
            base.OnAppearing();
            OnPropertyChanged(nameof(Files));
            OnPropertyChanged(nameof(URLposition));
        }
    }
}
