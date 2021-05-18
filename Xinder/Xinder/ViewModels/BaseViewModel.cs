using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Plugin.Toast;
using Rg.Plugins.Popup.Services;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xinder.Resources;
using Xinder.Views;
using Xinder.Views.PopUps;

namespace Xinder.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsConnected { get; set; }
        public BaseViewModel()
        {
            Connectivity.ConnectivityChanged += ConnectivityConnectivityChanged;
            IsConnected = Connectivity.NetworkAccess == NetworkAccess.Internet;
        }

        ~BaseViewModel()
        {
            Connectivity.ConnectivityChanged -= ConnectivityConnectivityChanged;
        }

        private void ConnectivityConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            IsConnected = e.NetworkAccess == NetworkAccess.Internet;

            if (e.NetworkAccess != NetworkAccess.Internet)
            {
                if (PopupNavigation.PopupStack.Count == 0)
                {
                    PopupNavigation.Instance.PushAsync(new NoInternetPopup());
                }
            }
            else
            {
                if (PopupNavigation.PopupStack.Count > 0)
                {
                    PopupNavigation.Instance.PopAsync();
                }
                CrossToastPopUp.Current.ShowToastSuccess(AppResources.InterntIsBack);
            }
        }
    }
}
