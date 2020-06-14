using AQVApp.Helpers;
using System.Collections.Generic;
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

        private async void Button_Clicked(object sender, System.EventArgs e)
        {
            string source = "Mundo Novo, MS, 79980-000";
            string target = "Campo Grande, MS";
            var route = await RouteHelper.GetGoogleDirectionsAsync(source, target);

            var leg = route.routes[0].legs[0];
            Pin start = new Pin()
            {
                Type = PinType.Place,
                Address = source,
                Position = new Position(leg.start_location.lat, leg.start_location.lng),
                Label = source
            };


            Pin end = new Pin()
            {
                Icon = BitmapDescriptorFactory.DefaultMarker(Color.Gray),
                Type = PinType.Place,
                Position = new Position(leg.end_location.lat, leg.end_location.lng),
                Label = target
            };

            map.Pins.Add(start);
            map.Pins.Add(end);
            map.SelectedPin = start;
            map.MoveToRegion(MapSpan.FromCenterAndRadius(start.Position, Distance.FromMeters(5000)), true);

            map.Polylines.Add(RouteHelper.GetPolylines(route));
        }
    }
}

