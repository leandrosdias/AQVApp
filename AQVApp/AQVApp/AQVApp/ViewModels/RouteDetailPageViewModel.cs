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
        public ICommand TapCommand { get; set; }
        public ICommand TapCommand1 { get; set; }
        public ICommand TapCommand2 { get; set; }
        public RouteDetailPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            MapCommand = new Command(GoToMap);
            TapCommand = new Command(Tap);
            TapCommand1 = new Command(Tap1);
            TapCommand2 = new Command(Tap2);
        }

        private async void GoToMap()
        {
            await _navigationService.NavigateAsync("MapPage", animated: false);
        }
        private async void Tap()
        {
            var popUp = new NotificationPopUp("Estrada para saúde", "Você conhece o programa estrada para saúde? O programa oferece acompanhamento contínuo e gratuito aos caminhoneiros, por meio de exames médicos,tratamento odontológico e outros serviços para melhorar a qualidade de vida e o bem-estar. Para saber mais, ao estiver parado, toque na notificação.");
            await PopupNavigation.Instance.PushAsync(popUp);
        }
        private async void Tap1()
        {
            var popUp = new NotificationPopUp("Hora do almoço!", "Estamos há 5 km do Restaurante Sabor Mineiro. Nossa parada planejada para o almoço. Lembre-se de descansar um pouco antes de retomar a viagem.");
            await PopupNavigation.Instance.PushAsync(popUp);
        }

        private async void Tap2()
        {
            var popUp = new NotificationPopUp("Hora do alongamento!", "Estamos há 2 quilômetros do Autoposto Platinão. Nossa parada planejada para alongamento e exercício");
            await PopupNavigation.Instance.PushAsync(popUp);
        }

    }
}
