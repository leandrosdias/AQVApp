using AQVApp.Helpers;
using AQVApp.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AQVApp.ViewModels
{
    public class PlanningPageViewModel : BindableBase, INavigatedAware
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private bool _isVisible;
        public bool IsVisible
        {
            get { return _isVisible; }
            set { SetProperty(ref _isVisible, value); }
        }
        private INavigationService _navigationService;
        public ICommand TapCommand { get; set; }
        private NetworkAuthData _data;
        public PlanningPageViewModel(INavigationService navigationService)
        {
            IsVisible = true;
            _navigationService = navigationService;
            TapCommand = new Command(TapAsync);
        }

        private async void TapAsync()
        {
            await _navigationService.NavigateAsync("PlanningDetailPage");
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            throw new NotImplementedException();
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            //var data = parameters?.GetValue<NetworkAuthData>("NetworkAuthData");
            //_data = data;
            Task.Run(SpeakScreenAsync);

            Title = Constants.PrepareToInitializeRoute();
        }

        private async Task SpeakScreenAsync()
        {
            try
            {
                await Task.Delay(5600);

                Title = Constants.QuestionSource();
                await Task.Delay(5000);

                Title = Constants.QuestionTarget();
                await Task.Delay(5000);

                Title = Constants.QuestionWeight();
                await Task.Delay(5200);

                Title = Constants.QuestionHour();
                await Task.Delay(1000);

                //await _navigationService.NavigateAsync("PlanningDetailPage");
            }
            catch (Exception e)
            {

            }

        }

    }
}
