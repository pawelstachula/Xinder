using System.Threading.Tasks;
using System.Windows.Input;
using Plugin.Toast;
using PropertyChanged;
using Rg.Plugins.Popup.Services;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xinder.Models;
using Xinder.Models.DTOs;
using Xinder.Models.Helpers;
using Xinder.Resources;
using Xinder.Validators;
using Xinder.Views;
using Xinder.Views.PopUps;

namespace Xinder.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool ActivityIndicatorRunning { get; set; }
        public ICommand LoginCommand { get; set; }

        public LoginViewModel()
        {
            LoginCommand = new Command(() => Login());
        }

        private async void Login()
        {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
            {
                CrossToastPopUp.Current.ShowToastError(AppResources.EmptyFields);
                return;
            }

            if (!LoginValidator.EmailValidator(Email))
            {
                CrossToastPopUp.Current.ShowToastError(AppResources.InvalidEmail);
                return;
            }

            ActivityIndicatorRunning = true;

            bool connected = IsConnected;

            if (connected)
            {
                bool loginResponse = await LoginRequest();

                if (loginResponse)
                {
                    Application.Current.MainPage = new HomePage();
                }
                else
                {
                    ActivityIndicatorRunning = false;
                    CrossToastPopUp.Current.ShowToastError(AppResources.Error);
                }
            }
            else
            {
                if (PopupNavigation.PopupStack.Count == 0)
                {
                    PopupNavigation.Instance.PushAsync(new NoInternetPopup());
                }
            }
        }


        private async Task<bool> LoginRequest()
        {
            LogInResponseDTO response = await APIHelper.Post<LogInResponseDTO>(
                Configuration.API_URL_LOGIN,
                new LogInRequestDTO()
                {
                    Email = Email,
                    Password = Password
                });

            if (response != null)
            {
                APIHelper.Token = response.Token;
                return true;
            }

            return false;
        }
    }
}
