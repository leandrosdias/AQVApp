using AQVApp.Helpers;
using AQVApp.Models;
using Newtonsoft.Json;
using Plugin.FacebookClient;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AQVApp.ViewModels
{
    public class LoginPageViewModel : BindableBase
    {
        public LoginPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            OnLoginWithFacebookCommand = new Command(async () => await LoginFacebookAsync());
        }

        public ICommand OnLoginWithFacebookCommand { get; set; }
        IFacebookClient _facebookService = CrossFacebookClient.Current;
        protected INavigationService _navigationService { get; private set; }
        async Task LoginFacebookAsync()
        {
            try
            {
                if (_facebookService.IsLoggedIn)
                {
                    _facebookService.Logout();
                }

                EventHandler<FBEventArgs<string>> userDataDelegate = null;

                userDataDelegate = async (object sender, FBEventArgs<string> e) =>
                {
                    if (e == null) return;

                    switch (e.Status)
                    {
                        case FacebookActionStatus.Completed:
                            var facebookProfile = await Task.Run(() => JsonConvert.DeserializeObject<FacebookProfile>(e.Data));
                            var socialLoginData = new NetworkAuthData
                            {
                                Email = facebookProfile.Email,
                                Name = $"{facebookProfile.FirstName}",
                                LastName = $"{facebookProfile.LastName}",
                                Id = facebookProfile.Id,
                                Picture = "http://graph.facebook.com/" + facebookProfile.Id + "/picture?type=normal"
                            };

                            var navigationParams = new NavigationParameters
                            {
                                { "NetworkAuthData", socialLoginData }
                            };

                            await _navigationService.NavigateAsync("DashboardPage", navigationParams);
                            break;
                        case FacebookActionStatus.Canceled:
                            break;
                    }

                    _facebookService.OnUserData -= userDataDelegate;
                };

                _facebookService.OnUserData += userDataDelegate;

                string[] fbRequestFields = { "email", "first_name", "gender", "last_name" };
                string[] fbPermisions = { "email" };
                await _facebookService.RequestUserDataAsync(fbRequestFields, fbPermisions);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }
    }
}

