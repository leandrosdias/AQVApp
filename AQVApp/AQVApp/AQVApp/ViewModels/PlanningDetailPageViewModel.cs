using AQVApp.Controllers;
using AQVApp.Helpers;
using AQVApp.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace AQVApp.ViewModels
{
    public class PlanningDetailPageViewModel : BindableBase, INavigatedAware
    {
        private string _source;
        public string Source
        {
            get { return _source; }
            set { SetProperty(ref _source, value); }
        }

        private string _target;
        public string Target
        {
            get { return _target; }
            set { SetProperty(ref _target, value); }
        }

        private string _weight;
        public string Weight
        {
            get { return _weight; }
            set { SetProperty(ref _weight, value); }
        }

        private string _hour;
        public string Hour
        {
            get { return _hour; }
            set { SetProperty(ref _hour, value); }
        }

        private Route _route;
        private INavigationService _navigationService;
        public ICommand PlanningCommand { get; set; }
        public PlanningDetailPageViewModel(INavigationService navigationService)
        {
            PlanningCommand = new Command(PlanningAsync);
            _navigationService = navigationService;
        }

        private async void PlanningAsync()
        {
            var plannedRoute = RouteController.PlanningRoute(_route);
            var navigationParams = new NavigationParameters
                            {
                                { "PlannedRoute", plannedRoute }
                            };
            await _navigationService.NavigateAsync("RouteDetailPage", navigationParams, animated: false);
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            throw new NotImplementedException();
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            _route = parameters?.GetValue<Route>("Route");
            Source = _route.Source;
            Target = _route.Target;
            Weight = _route.Weight;
            Hour = _route.LoadHour ? "Sim" : "Não";
        }
    }
}
