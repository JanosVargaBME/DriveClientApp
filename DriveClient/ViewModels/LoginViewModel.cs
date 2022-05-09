using DriveClient.Models;
using DriveClient.Services;
using DriveClient.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace DriveClient.ViewModels
{
    internal class LoginViewModel : BaseViewModel
    {
        //CHANGE THIS SHIT
        public List<User> Users => UserService.Instance.GetUsers();

        public string LoginButtonText { get; set; } = "Log in!"; 

        public ICommand LoginCommand { get; set; }

        public LoginViewModel(INavigation navigation) : base(navigation)
        {
            LoginCommand = new Command(LoginCommandExecute);
        }

        private async void LoginCommandExecute()
        {
            /*
            LoginButtonText = "You are logged in!";
            OnPropertyChanged(nameof(LoginButtonText));
            await Navigation.PushAsync(new DataListView(), true);
            */

            OwnDriveService ownDriveService = new OwnDriveService();

            
            LoginButtonText = ownDriveService.read().ToString();
            OnPropertyChanged(nameof(LoginButtonText));

        }

        public override void OnAppearing()
        {
            base.OnAppearing();
            OnPropertyChanged(nameof(Users));
            OnPropertyChanged(nameof(LoginButtonText));
        }
    }
}
