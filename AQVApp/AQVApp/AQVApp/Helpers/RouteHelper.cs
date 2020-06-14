﻿using AQVApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.GoogleMaps;

namespace AQVApp.Helpers
{
    class RouteHelper
    {
        public static async Task<GoogleDirections.Rootobject> GetGoogleDirectionsAsync(string source, string target)
        {
            return await GetGoogleDirectionsStringAsync(source, target);
        }

        private static async Task<GoogleDirections.Rootobject> GetGoogleDirectionsStringAsync(string source, string target)
        {
            var url = GetWebUrlRoute(source, target, new List<string>());

            var client = new HttpClient();

            using (var request = new HttpRequestMessage(new HttpMethod("GET"), url))
            {
                var response = await client.SendAsync(request);
                var jsonResponse = await response.Content.ReadAsStringAsync();

                return !response.IsSuccessStatusCode ? null : JsonConvert.DeserializeObject<GoogleDirections.Rootobject>(jsonResponse);
            }
        }

        public static Polyline GetPolylines(GoogleDirections.Rootobject root)
        {
            if (root == null)
                return null;

            var polsString = new List<string>();

            foreach (var route in root.routes)
            {
                polsString.Add(route.overview_polyline.points);
            }

            var positions = new List<Position>();

            foreach (var polString in polsString)
            {
                var posList = DecodePolyline(polString);

                foreach (var pos in posList)
                {
                    positions.Add(pos);
                }
            }

            var result = new Polyline();
            foreach (var position in positions)
            {
                result.Positions.Add(position);
            }

            result.StrokeColor = Color.Red;
            result.StrokeWidth = 5;
            return result;
        }

        public static List<Position> DecodePolyline(string encodedPoints)
        {
            if (string.IsNullOrWhiteSpace(encodedPoints)) return null;

            var polylineChars = encodedPoints.ToCharArray();
            var positionList = new List<Position>();
            int index = 0, currentLat = 0, currentLng = 0;

            while (index < polylineChars.Length)
            {
                // Latitude
                int sum = 0, shifter = 0;

                int next5Bits;
                do
                {
                    next5Bits = polylineChars[index++] - 63;
                    sum |= (next5Bits & 31) << shifter;
                    shifter += 5;
                }
                while (next5Bits >= 32 && index < polylineChars.Length);

                if (index >= polylineChars.Length) break;

                currentLat += (sum & 1) == 1 ? ~(sum >> 1) : (sum >> 1);

                // Longitude
                sum = 0;
                shifter = 0;

                do
                {
                    next5Bits = polylineChars[index++] - 63;
                    sum |= (next5Bits & 31) << shifter;
                    shifter += 5;
                }
                while (next5Bits >= 32 && index < polylineChars.Length);

                if (index >= polylineChars.Length && next5Bits >= 32) break;

                currentLng += (sum & 1) == 1 ? ~(sum >> 1) : (sum >> 1);

                var oPosition = new Position(Convert.ToDouble(currentLat) / 100000.0, Convert.ToDouble(currentLng) / 100000.0);
                positionList.Add(oPosition);
            }

            return positionList;
        }

        public static string GetWebUrlRoute(string source, string target, List<string> wayPointList)
        {
            var webAddress = @"https://maps.googleapis.com/maps/api/directions/json"
                             + "?origin=" + source + "&"
                             + "destination=" + target;

            var wayPoints = (wayPointList != null && wayPointList.Count > 0)
                ? "&waypoints=" + string.Join("|", wayPointList)
                : "";

            return webAddress + wayPoints + "&key=AIzaSyDNaB0zBNVbJC0qYptExly2uJmSiK703uo";
        }

    }
}
