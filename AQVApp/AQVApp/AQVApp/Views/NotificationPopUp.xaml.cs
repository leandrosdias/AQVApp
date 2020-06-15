using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AQVApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotificationPopUp : PopupPage
    {
        private string _title;
        private string _description;
        public NotificationPopUp(string title, string description)
        {
            _title = title;
            _description = description;
            InitializeComponent();
            lbTitle.Text = title;
            lbDescription.Text = description;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await Helpers.SpeechHelper.SpeakNow(_description);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PopPopupAsync().ConfigureAwait(true);
        }
    }
}