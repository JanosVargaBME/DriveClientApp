using DriveClient.Services;
using DriveClient.Views;
using System;
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
            string testToken = "sl.BHWWMwTSWxwBJZUazDh-6PFbe11f2J88Tc0jDnMTkAeJJ-81s74VEZSeQxnTEDEeM3OwBd9wFNtQ5xcRcCybvm29H8BushB1X3Fo_CoMukUn8zqjtCRPMq2D2gyu5TzMPTLlZqI_i66N";

            try
            {
                if (await DropBoxService.Instance.IsValidLogin(testToken))
                {
                    await Navigation.PushAsync(new DataListView(), true);
                }
            }catch (Exception)
            {
                await App.Current.MainPage.DisplayAlert("Error", "There was an error with Logging in, try again!", "OK");
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
                await App.Current.MainPage.DisplayAlert("Error", "Please fill the token input!", "OK");
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
                await App.Current.MainPage.DisplayAlert("Error", "There was an error with Logging in, try again!", "OK");
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
