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
        public enum Intent
        {
            AfirmativeAnswer,
            NegativeAnswer,
            Undefined
        }

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

        public static async Task QuestionSource()
        {
            await SpeakNow(Constants.QuestionSource());
        }

        public static async Task QuestionTarget()
        {
            await SpeakNow(Constants.QuestionTarget());
        }

        public static async Task QuestionWeight()
        {
            await SpeakNow(Constants.QuestionWeight());
        }

        public static async Task QuestionType()
        {
            await SpeakNow(Constants.QuestionType());
        }

        public static async Task QuestionIsLoadHour()
        {
            await SpeakNow(Constants.QuestionIsLoadHour());
        }

        public  static async Task<string> GetUserResponseAsync()
        {
            var speech = GetUserSpeech();

            int tries = 0;
            while (string.IsNullOrEmpty(speech) || tries >= 3)
            {
                await SpeakNow(Constants.DontUndestand());
                speech = GetUserSpeech();
                tries++;
            }

            return speech;
        }

        private static string GetUserSpeech()
        {
            throw new NotImplementedException();
        }

        internal static async Task<Intent> GetIntentByResponseAsync()
        {
            var response = await GetUserResponseAsync();

            if (string.IsNullOrWhiteSpace(response))
                return Intent.Undefined;

            return DefineIntentByResponse(response);
        }

        private static Intent DefineIntentByResponse(string response)
        {
            throw new NotImplementedException();
        }
    }
}
