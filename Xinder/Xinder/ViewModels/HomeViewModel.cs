using System.Collections.ObjectModel;
using System.Threading.Tasks;
using PropertyChanged;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms.Internals;
using Xinder.Models;
using Xinder.Models.DTOs;
using Xinder.Models.Helpers;
using Xinder.Views.PopUps;

namespace Xinder.ViewModels
{
    public class HomeViewModel : BaseViewModel 
    {
        public ObservableCollection<UserDTO> Users { get; set; }
        public bool LookingForNewPeople { get; set; } = true;
        public HomeViewModel()
        {
            Users = new ObservableCollection<UserDTO>();
        }

        public async void LoadUsers()
        {
            bool connected = IsConnected;

            if (connected)
            {
                await FetchUsers();
            }
            else
            {
                if (PopupNavigation.PopupStack.Count == 0)
                {
                    PopupNavigation.Instance.PushAsync(new NoInternetPopup());
                }
            }
            
        }

        private async Task FetchUsers()
        {
            UsersResponseDTO response = await APIHelper.Get<UsersResponseDTO>(
                Configuration.API_URL_LIST_USERS);

            if (response != null)
            {
                var users = new ObservableCollection<UserDTO>(response.Data);
                users.ForEach(Users.Add);
                LookingForNewPeople = false;
            }
        }
    }
}
