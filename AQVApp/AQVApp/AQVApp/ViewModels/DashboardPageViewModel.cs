using AQVApp.Controllers;
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
    public class DashboardPageViewModel : BindableBase, INavigatedAware
    {
        public class BubbleHeader
        {
            public string Icon { get; set; }
            public string IconColor { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
        }

        private NetworkAuthData _data;

        private string _helloString;
        public string HelloString
        {
            get { return _helloString; }
            set { SetProperty(ref _helloString, value); }
        }

        private ObservableCollection<BubbleHeader> _bubbles;
        public ObservableCollection<BubbleHeader> Bubbles
        {
            get { return _bubbles; }
            set { SetProperty(ref _bubbles, value); }
        }

        private INavigationService _navigationService;
        public ICommand NewPlanningCommand { get; set; }
        public DashboardPageViewModel(INavigationService navigationService)
        {
            NewPlanningCommand = new Command(GoToPlanningScreenAsync);
            _navigationService = navigationService;
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            var data = parameters?.GetValue<NetworkAuthData>("NetworkAuthData");
            _data = data;
            HelloString = $"Olá, {data?.Name}!";

            var user = UserController.GetUserByEmail(data.Email);
            Bubbles = new ObservableCollection<BubbleHeader>()
            {
                new BubbleHeader{Icon="Marker", Title = $"{user.TotalDistance} km", Description="Distância Percorrida", IconColor="#00C1D4"},
                new BubbleHeader{Icon="Check", Title = user.TotalTrip, Description="Viagens Finalizadas", IconColor="#33AC2E"},
            };
        }

        private async void GoToPlanningScreenAsync()
        {
            var navigationParams = new NavigationParameters
                            {
                                { "NetworkAuthData", _data }
                            };
            await _navigationService.NavigateAsync("PlanningPage", navigationParams);
        }
    }
}
