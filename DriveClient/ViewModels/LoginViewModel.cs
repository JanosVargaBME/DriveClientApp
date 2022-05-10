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
    /// <summary>
    /// Class <c>LoginViewModel</c> is responsible for the actions on the LoginView page.
    /// </summary>
    internal class LoginViewModel : BaseViewModel
    {
        /// <summary>
        /// The ICommands for the buttons. One for nomal login and one for testing.
        /// </summary>
        public ICommand LoginCommand { get; set; }
        public ICommand TestLoginCommand { get; set; }

        /// <summary>
        /// Contains the token the user writes in.
        /// </summary>
        public string TokenText { get; set; } = string.Empty;
        /// <summary>
        /// Contains a welcome text for the user, but turns to error message in case of error!
        /// </summary>
        public string WelcomeText { get; set; } = "Welcome to DropBoxClient!";

        /// <summary>
        /// Construcor, it initializes the buttons.
        /// </summary>
        public LoginViewModel(INavigation navigation) : base(navigation)
        {
            LoginCommand = new Command(LoginCommandExecute);
            TestLoginCommand = new Command(TestLoginCommandExecute);
        }

        /// <summary>
        /// Enables a Test Login for this email address: drive.test.xamarin@gmail.com, with burned in token.
        /// Handles the "Test Login" button's actions.
        /// If the testtoken is good, then it redirects to the Folder list.
        /// If not, then shows an error message for the user.
        /// </summary>
        private async void TestLoginCommandExecute()
        {
            string testToken = "sl.BHX0m0dZ1DZYGMEA7qBQTASbOlKFOQWbV9E4oyGGurLCqA57dNSektf7xvf6H4arXWpaWI1zvM1tGVmyfC4JwZi02HM81-0klNovwy9MxXW0Fm05mi70C0dER8jBGORyX8n0PKdyUKdy";

            try
            {
                if (await DropBoxService.Instance.IsValidLogin(testToken))
                {
                    await Navigation.PushAsync(new DataListView(), true);
                }
            }catch (Exception)
            {
                WelcomeText = "There was an error with Logging in, try again!";
            }
            finally
            {
                this.OnAppearing();
            }
        }

        /// <summary>
        /// Handles the "Login" button's actions.
        /// If the token is good, then it redirects to the Folder list.
        /// If not, then shows an error message for the user.
        /// </summary>
        private async void LoginCommandExecute()
        {
            if (TokenText.Equals(string.Empty))
            {
                WelcomeText = "Please fill the token input!";
                this.OnAppearing();
                return;
            }
            try
            {
                if (await DropBoxService.Instance.IsValidLogin(TokenText))
                {
                    await Navigation.PushAsync(new DataListView(), true);
                }
            }
            catch (Exception)
            {
                WelcomeText = "There was an error with Logging in, try again!";
            }
            finally
            {
                this.OnAppearing();
            }
        }

        /// <summary>
        /// Refreshes the window's properties.
        /// </summary>
        public override void OnAppearing()
        {
            base.OnAppearing();
            OnPropertyChanged(nameof(TokenText));
            OnPropertyChanged(nameof(WelcomeText));
        }
    }
}
