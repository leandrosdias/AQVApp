using AQVApp.Controllers;
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

        private bool _imageVisible;
        public bool ImageVisible
        {
            get { return _imageVisible; }
            set { SetProperty(ref _imageVisible, value); }
        }

        private Route _route;
        private INavigationService _navigationService;
        public PlanningPageViewModel(INavigationService navigationService)
        {
            IsVisible = true;
            _navigationService = navigationService;
            Task.Run(ProcessConversation);
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            throw new NotImplementedException();
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            ImageVisible = false;
        }

        public async Task ProcessConversation()
        {
            await SpeechHelper.QuestionSource();
            var source = await SpeechHelper.GetUserResponseAsync();

            await SpeechHelper.QuestionTarget();
            var target = await SpeechHelper.GetUserResponseAsync();

            await SpeechHelper.QuestionWeight();
            var weight = await SpeechHelper.GetUserResponseAsync();

            await SpeechHelper.QuestionType();
            var type = await SpeechHelper.GetUserResponseAsync();

            await SpeechHelper.QuestionSource();
            var isLoadHour = await SpeechHelper.GetIntentByResponseAsync() == SpeechHelper.Intent.AfirmativeAnswer;

            _route = new Route
            {
                Source = source,
                Target = target,
                Weight = weight,
                Type = type,
                LoadHour = isLoadHour
            };

          
            var navigationParams = new NavigationParameters
                            {
                                { "Route", _route }
                            };

            await _navigationService.NavigateAsync("PlanningDetailPage", navigationParams);
        }
    }
}
