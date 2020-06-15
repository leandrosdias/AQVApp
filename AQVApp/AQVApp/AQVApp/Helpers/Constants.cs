using System;
using System.Collections.Generic;
using System.Text;

namespace AQVApp.Helpers
{
    public class Constants
    {
        public static string PrepareToInitializeRoute(string name)
        {
            return $"Vamos planejar sua viagem {name}, necessito de alguns dados";
        }

        public static string QuestionSource()
        {
            return @"Qual é a sua origem?";
        }

        public static string Undestand()
        {
            return @"Ok, entendi.";
        }

        public static string DontUndestand()
        {
            return @"Desculpe, não entendi. Poderia repetir novamente?";
        }

        public static string QuestionTarget()
        {
            return @"Qual é o seu destino?";
        }

        public static string QuestionWeight()
        {
            return @" Qual o peso da carga?";
        }

        public static string QuestionType()
        {
            return @"Qual o tipo de carroceria?";
        }

        public static string QuestionIsLoadHour()
        {
            return @"A carga possui horário?";
        }        
    }
}
