using System.Windows.Input;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xinder.Views.PopUps
{
    public partial class NoInternetPopup : Rg.Plugins.Popup.Pages.PopupPage
    {
        public NoInternetPopup()
        {
            InitializeComponent();
        }
        protected override bool OnBackButtonPressed()
        {
            return base.OnBackButtonPressed();
        }

        private void OKClicked(object sender, System.EventArgs e)
        {
            PopupNavigation.Instance.PopAsync();
            Application.Current.MainPage = new LoginPage();
        }
    }
}