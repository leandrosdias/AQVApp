using AQVApp.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

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

        public DashboardPageViewModel(INavigationService navigationService)
        {
            Bubbles = new ObservableCollection<BubbleHeader>()
            {
                new BubbleHeader{Icon="marker.png", Title = "158 km", Description="Distância Percorrida"},
                new BubbleHeader{Icon="check.png", Title = "3", Description="Viagens Finalizadas"},
            };
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            throw new NotImplementedException();
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            var data = parameters?.GetValue<NetworkAuthData>("NetworkAuthData");
            _helloString = $"Olá, {data?.Name}!";
        }
    }
}
