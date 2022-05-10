using DriveClient.Models;
using DriveClient.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace DriveClient.ViewModels
{
    internal class DataListViewModel : BaseViewModel
    {
        public ObservableCollection<BasicItem> BasicItems{ get; set; }

        public string URLposition = "/";

        public string FullURLposition { get { return "Your current position: " + URLposition; } }

        public ICommand DeleteCommand { get; set; }
        public ICommand OpenCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand ChangeViewCommand { get; set; }
        public ICommand BackCommand { get; set; }

        public DataListViewModel(INavigation navigation) : base(navigation)
        {
            LoadData();

            DeleteCommand = new Command(DeleteCommandExecute);
            OpenCommand = new Command(OpenCommandExecute);
            AddCommand = new Command(AddCommandExecute);
            ChangeViewCommand = new Command(ChangeViewCommandExecute);
            BackCommand = new Command(BackCommandExecute);
        }

        public async Task LoadData()
        {
            var data = await BasicItemService.Instance.GetThings();
            BasicItems = new ObservableCollection<BasicItem>(data);
            this.OnAppearing();
        }


        //TODO: Go back to previous folder
        private async void BackCommandExecute(object obj)
        {
            this.OnAppearing();
        }

        //TODO: Change to other view
        private void ChangeViewCommandExecute(object obj)
        {
            this.OnAppearing();
        }

        //TODO: Add new item to drive
        private void AddCommandExecute(object obj)
        {
            this.OnAppearing();
        }

        //TODO: Delete file/folder command
        private void DeleteCommandExecute()
        {
            this.OnAppearing();
        }

        //TODO: Open file/folder command
        private void OpenCommandExecute()
        {
            this.OnAppearing();
        }

        public override void OnAppearing()
        {
            base.OnAppearing();
            OnPropertyChanged(nameof(BasicItems));
            OnPropertyChanged(nameof(URLposition));
            OnPropertyChanged(nameof(FullURLposition));
        }
    }
}
