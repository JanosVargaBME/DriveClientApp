using DriveClient.Models;
using DriveClient.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace DriveClient.ViewModels
{
    internal class DataListViewModel : BaseViewModel
    {
        public ObservableCollection<BasicItem> BasicItems{ get; set; }

        public string FullURLposition { get { return "Your current position: " + BasicItemService.Instance.actualPath; } }

        public ICommand DeleteCommand { get; set; }
        public ICommand OpenCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand ChangeViewCommand { get; set; }
        public ICommand BackCommand { get; set; }

        public DataListViewModel(INavigation navigation) : base(navigation)
        {
            LoadData(string.Empty);

            DeleteCommand = new Command(DeleteCommandExecute);
            OpenCommand = new Command(OpenCommandExecute);
            AddCommand = new Command(AddCommandExecute);
            ChangeViewCommand = new Command(ChangeViewCommandExecute);
            BackCommand = new Command(BackCommandExecute);
        }

        public async Task LoadData(string path)
        {
            var data = await BasicItemService.Instance.InitList(path);
            BasicItems = new ObservableCollection<BasicItem>(data);

            this.OnAppearing();
        }

        //DONE
        private async void BackCommandExecute(object obj)
        {
            string path = BasicItemService.Instance.actualPath;

            int freq = path.Count(p => (p == '/'));
            if (freq > 0)
            {
                if(freq == 1)
                    await LoadData(string.Empty);
                else {
                    int index = path.LastIndexOf('/');
                    path = path.Substring(0, index);

                    await LoadData(path);
                }
            }
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
            OnPropertyChanged(nameof(FullURLposition));
        }
    }
}
