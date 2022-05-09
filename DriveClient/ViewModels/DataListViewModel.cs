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
        public List<BasicItem> BasicItems => BasicItemService.Instance.GetThings();

        public string URLposition = "/";

        public string FullURLposition { get { return "Your current position: " + URLposition; } }

        public ICommand DeleteCommand { get; set; }
        public ICommand OpenCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand ChangeViewCommand { get; set; }
        public ICommand BackCommand { get; set; }

        public DataListViewModel(INavigation navigation) : base(navigation)
        {
            DeleteCommand = new Command(DeleteCommandExecute);
            OpenCommand = new Command(OpenCommandExecute);
            AddCommand = new Command(AddCommandExecute);
            ChangeViewCommand = new Command(ChangeViewCommandExecute);
            BackCommand = new Command(BackCommandExecute);
        }

        //TODO: Go back to previous folder
        private void BackCommandExecute(object obj)
        {
            URLposition = "/back";
            this.OnAppearing();
        }

        //TODO: Change to other view
        private void ChangeViewCommandExecute(object obj)
        {
            URLposition = "/change";
            this.OnAppearing();
        }

        //TODO: Add new item to drive
        private void AddCommandExecute(object obj)
        {
            URLposition = "/add";
            this.OnAppearing();
        }

        //TODO: Delete file/folder command
        private void DeleteCommandExecute()
        {
            URLposition = "/delete";
            this.OnAppearing();
        }

        //TODO: Open file/folder command
        private void OpenCommandExecute()
        {
            URLposition = "/open";
            this.OnAppearing();
        }

        public override void OnAppearing()
        {
            base.OnAppearing();
            OnPropertyChanged(nameof(Files));
            OnPropertyChanged(nameof(URLposition));
            OnPropertyChanged(nameof(FullURLposition));
        }
    }
}
