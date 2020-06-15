using AQVApp.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace AQVApp.ViewModels
{
    public class MapPageViewModel : BindableBase, INavigatedAware
    {
        private ObservableCollection<Notification> _notifications;
        public ObservableCollection<Notification> Notifications
        {
            get { return _notifications; }
            set { SetProperty(ref _notifications, value); }
        }

        public ICommand BackCommand { get; set; }
        private INavigationService _navigationService;
        public MapPageViewModel(INavigationService navigationService)
        {
            BackCommand = new Command(BackScreenAsync);
            _navigationService = navigationService;
        }

        private async void BackScreenAsync()
        {
            await _navigationService.NavigateAsync("RouteDetailPage");
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            throw new NotImplementedException();
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            Notifications = new ObservableCollection<Notification>();
            var plannedRoute = parameters?.GetValue<Route>("PlannedRoute");

            foreach(var notification in plannedRoute.Notifications)
            {
                Notifications.Add(notification);
            }
        }
    }
}
