using AQVApp.Helpers;
using AQVApp.ViewModels;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AQVApp.Views
{
    public partial class PlanningPage : ContentPage
    {
        public PlanningPage()
        {
            InitializeComponent();
            Task.Run(SpeakScreenAsync);
        }

        private async Task SpeakScreenAsync()
        {
            try
            {
                await SpeechHelper.SpeakNow(Constants.PrepareToInitializeRoute());
                await stPage.FadeTo(0, 1000, Easing.SinInOut);
                await Task.Delay(100);
                await stPage.FadeTo(1, 1000, Easing.SinInOut);

                await SpeechHelper.SpeakNow(Constants.QuestionSource());
                await Task.Delay(400);
                await stPage.FadeTo(0, 1000, Easing.SinInOut);
                await Task.Delay(100);
                await stPage.FadeTo(1, 1000, Easing.SinInOut);

                await SpeechHelper.SpeakNow(Constants.Undestand());
                await SpeechHelper.SpeakNow(Constants.QuestionTarget());
                await Task.Delay(400);
                await stPage.FadeTo(0, 1000, Easing.SinInOut);
                await Task.Delay(100);
                await stPage.FadeTo(1, 1000, Easing.SinInOut);

                await SpeechHelper.SpeakNow(Constants.Undestand());
                await SpeechHelper.SpeakNow(Constants.QuestionWeight());
                await Task.Delay(400);
                await stPage.FadeTo(0, 1000, Easing.SinInOut);
                await Task.Delay(100);
                await stPage.FadeTo(1, 1000, Easing.SinInOut);

                await SpeechHelper.SpeakNow(Constants.Undestand());
                await SpeechHelper.SpeakNow(Constants.QuestionHour());
            }
            catch (Exception e)
            {

            }
            
        }

    }
}
