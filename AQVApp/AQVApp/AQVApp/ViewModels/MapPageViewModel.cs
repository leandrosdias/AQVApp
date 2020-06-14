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
    public class MapPageViewModel : BindableBase
    {
        public class Notification
        {
            public string Hour { get; set; }
            public string Description { get; set; }
        }

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
            Notifications = new ObservableCollection<Notification>
            {
                new Notification{Hour="12:00", Description="Sugestão de parada para almoço por 60 minutos no restaurante "},
                new Notification{Hour="19:30", Description="Sugestão de parada no posto Platinão há 37 KM por restrição horário de Campo Grande"},
            };

            BackCommand = new Command(BackScreenAsync);
            _navigationService = navigationService;
        }

        private async void BackScreenAsync()
        {
            await _navigationService.NavigateAsync("RouteDetailPage");
        }
    }
}
