using AQVApp.Models;
using AQVApp.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace AQVApp.ViewModels
{
    public class RouteDetailPageViewModel : BindableBase
    {
        private INavigationService _navigationService;
        public ICommand MapCommand { get; set; }
        public RouteDetailPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            MapCommand = new Command(GoToMap);
        }

        private async void GoToMap()
        {
            await _navigationService.NavigateAsync("MapPage", animated: false);
        }

        private async void CallPopUp(Notification notification)
        {
            var popUp = new NotificationPopUp(notification.Title, notification.Description);
            await PopupNavigation.Instance.PushAsync(popUp);
        }
    }
}
