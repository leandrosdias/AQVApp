using System;
using System.Collections.Generic;
using System.Text;

namespace AQVApp.Helpers
{
    public class Constants
    {
        public static string PrepareToInitializeRoute(string name = "")
        {
            return @"Vamos iniciar sua viagem";
        }

        public static string QuestionSource(string name = "")
        {
            return @"Qual é a sua origem?";
        }

        public static string AnswerSource(string name = "")
        {
            return @"Plastiplan Indústria de Embalagens Plásticas, 4, S/N - Industrial, Planalto - PR, 85750-000";
        }

        public static string Undestand(string name = "")
        {
            return @"Ok, entendi.";
        }

        public static string QuestionTarget(string name = "")
        {
            return @"Qual é o seu destino?";
        }

        public static string AnswerTarget(string name = "")
        {
            return @"FRIGOESTE - Núcleo Industrial, Campo Grande - MS";
        }

        public static string QuestionWeight(string name = "")
        {
            return @" Qual o peso da carga?";
        }

        public static string AnswerWeight(string name = "")
        {
            return @"6 toneladas";
        }

        public static string QuestionType(string name = "")
        {
            return @"Qual o tipo de carroceria?";
        }

        public static string AnswerType(string name = "")
        {
            return @"Baú";
        }

        public static string QuestionHour(string name = "")
        {
            return @"A carga possui horário?";
        }

        public static string GetNotification(string name = "")
        {
            return @"Estamos há dois quilômetros da nossa parada planejada para alongar e se exercitar. É no KM 454 à direita";
        }
        
    }
}
