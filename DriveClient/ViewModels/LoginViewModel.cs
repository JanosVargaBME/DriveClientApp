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

        public ICommand LoginCommand { get; set; }
        public ICommand TestLoginCommand { get; set; }

        public LoginViewModel(INavigation navigation) : base(navigation)
        {
            LoginCommand = new Command(LoginCommandExecute);
            TestLoginCommand = new Command(TestLoginCommandExecute);
        }

        private async void TestLoginCommandExecute(object obj)
        {
            string testToken = "sl.BHXyjOoCK77McXEiRCVO65DaVRiYm_VZ6BlNM6ZaX1r2udWeSn-blrftCiIYBtY6MDDuXqOvQNXJgIx1Lpy_PGgmk3PO7MXoYSXId4TiF2cvCifAj0F59FD4xMiVKNayaKg4_OqZWwJs";

            if(await DropBoxService.Instance.IsValidLogin(testToken))
            {
                await Navigation.PushAsync(new DataListView(), true);
                
            }
        }

        private async void LoginCommandExecute()
        {
            //TODO: Get token from input
            string token = "";

            if (await DropBoxService.Instance.IsValidLogin(token))
            {
                await Navigation.PushAsync(new DataListView(), true);
            }
        }

        public override void OnAppearing()
        {
            base.OnAppearing();
            OnPropertyChanged(nameof(Users));
        }
    }
}
