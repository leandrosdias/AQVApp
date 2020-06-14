using AQVApp.Helpers;
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
    public class PlanningDetailPageViewModel : BindableBase
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


        private INavigationService _navigationService;
        public ICommand PlanningCommand { get; set; }
        public PlanningDetailPageViewModel(INavigationService navigationService)
        {
            PlanningCommand = new Command(PlanningAsync);
            _navigationService = navigationService;

            Source = Constants.AnswerSource();
            Target = Constants.AnswerTarget();
            Weight = Constants.AnswerWeight();
            Hour = "Não";
        }

        private async void PlanningAsync()
        {
            await _navigationService.NavigateAsync("RouteDetailPage", animated: false);
        }
    }
}
