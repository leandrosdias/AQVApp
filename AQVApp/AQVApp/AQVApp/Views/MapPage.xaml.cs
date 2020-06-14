using AQVApp.Helpers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;

namespace AQVApp.Views
{
    public partial class MapPage : ContentPage
    {
        public MapPage()
        {
            InitializeComponent();

            map.MyLocationEnabled = true;
            map.UiSettings.MyLocationButtonEnabled = true;

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await OpenMapAsync();
        }
        private async Task OpenMapAsync()
        {
            try
            {
                string source = "Plastiplan Industria e Embalagem";
                string target = "Frigoeste";
                var route = await RouteHelper.GetGoogleDirectionsAsync(source, target);

                var leg = route.routes[0].legs[0];
                Pin start = new Pin()
                {
                    Type = PinType.Place,
                    Position = new Position(leg.start_location.lat, leg.start_location.lng),
                    Label = source
                };


                Pin end = new Pin()
                {
                    Type = PinType.Generic,
                    Position = new Position(leg.end_location.lat, leg.end_location.lng),
                    Label = target,
                };

                Pin posto = new Pin()
                {
                    Type = PinType.Generic,
                    Position = new Position(-20.675093, -54.557254),
                    Label = "Posto Platinão",
                };

                Pin restaurante = new Pin()
                {
                    Type = PinType.Generic,
                    Position = new Position(-23.493388, -54.185739),
                    Label = "Restaurante Sabor Mineiro",
                };


                map.Pins.Add(start);
                map.Pins.Add(end);
                map.Pins.Add(restaurante);
                map.Pins.Add(posto);

                var centerPosition = RouteHelper.GetCenterPosition(start.Position, end.Position);
                map.MoveToRegion(MapSpan.FromCenterAndRadius(centerPosition, Distance.FromMeters(RouteHelper.GetDistance(start.Position, end.Position))), true);

                map.Polylines.Add(RouteHelper.GetPolylines(route));
            }
            catch(Exception e)
            {

            }
        }
    }
}

