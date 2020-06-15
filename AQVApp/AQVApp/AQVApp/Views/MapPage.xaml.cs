using AQVApp.Helpers;
using AQVApp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;

namespace AQVApp.Views
{
    public partial class MapPage : ContentPage
    {
        private Route _route;
        public MapPage(Route route)
        {
            _route = route;
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
                string source = _route.Source;
                string target = _route.Target;
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

                foreach(var notification in _route.Notifications)
                {
                    var pin = new Pin()
                    {
                        Type = PinType.Generic,
                        Position = new Position(notification.Lat, notification.Long),
                        Label = notification.Label,
                    };
                    map.Pins.Add(pin);
                }

                map.Pins.Add(start);
                map.Pins.Add(end);

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

