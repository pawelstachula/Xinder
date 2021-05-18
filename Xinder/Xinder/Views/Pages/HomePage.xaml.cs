using System;
using MLToolkit.Forms.SwipeCardView.Core;
using Xamarin.Forms;
using Xinder.Models;
using Xinder.ViewModels;

namespace Xinder.Views
{
    public partial class HomePage : ContentPage
    {
        private HomeViewModel _vm;
        public HomePage()
        {
            InitializeComponent();

            _vm = new HomeViewModel();
            BindingContext = _vm;
        }

        protected override void OnAppearing()
        {
            _vm.LoadUsers();
        }

        private void OnDragging(object sender, DraggingCardEventArgs e)
        {
            var view = (View)sender;
            var nopeFrame = view.FindByName<Frame>("NopeFrame");
            var likeFrame = view.FindByName<Frame>("LikeFrame");

            switch (e.Position)
            {
                case DraggingCardPosition.Start:
                case DraggingCardPosition.FinishedUnderThreshold:
                case DraggingCardPosition.FinishedOverThreshold:
                    nopeFrame.Opacity = 0;
                    likeFrame.Opacity = 0;
                    break;
                case DraggingCardPosition.UnderThreshold:
                case DraggingCardPosition.OverThreshold:
                    if (e.Direction == SwipeCardDirection.Left)
                    {
                        likeFrame.Opacity = 0;
                        nopeFrame.Opacity = 1;
                    }
                    else if (e.Direction == SwipeCardDirection.Right)
                    {
                        nopeFrame.Opacity = 0;
                        likeFrame.Opacity = 1;
                    }
                    break;
            }
        }

        private void OnLikeClicked(object sender, EventArgs e)
        {
            SwipeView.InvokeSwipe(SwipeCardDirection.Right);
        }

        private void OnNopeClicked(object sender, EventArgs e)
        {
            SwipeView.InvokeSwipe(SwipeCardDirection.Left);
        }

        private void OnSwiped(object sender, EventArgs e)
        {
            var topUser = (UserDTO)SwipeView.TopItem;

            if (topUser.Id == _vm.Users.Count)
            {
                NoMatchLabel.IsVisible = true;
                LikeButton.IsEnabled = false;
                NopeButton.IsEnabled = false;
            }
        }
    }
}