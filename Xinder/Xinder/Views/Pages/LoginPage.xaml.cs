using System;
using Xamarin.Forms;
using Xinder.ViewModels;

namespace Xinder.Views
{
    public partial class LoginPage : ContentPage
    {
        private LoginViewModel _vm;
        public LoginPage()
        {
            InitializeComponent();

            _vm = new LoginViewModel();
            BindingContext = _vm;
        }

        private void LoginEntryCompleted(object sender, EventArgs e)
        {
            PasswordEntry.Focus();
        }
        private void PasswordEntryCompleted(object sender, EventArgs e)
        {
            _vm.LoginCommand.Execute(null);
        }
    }
}