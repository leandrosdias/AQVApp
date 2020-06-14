using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace AQVApp.Helpers
{
    class SpeechHelper
    {
        public static async Task SpeakNow(string text)
        {
            var locales = await TextToSpeech.GetLocalesAsync();

            // Grab the first locale
            var localesBrazil = locales.Where(x=>x.Country == "BR");

            var locale = localesBrazil.FirstOrDefault();

            var settings = new SpeechOptions()
            {
                Volume = .75f,
                Pitch = 1.0f,
                Locale = locale
            };

            await TextToSpeech.SpeakAsync(text, settings);
        }
    }
}
