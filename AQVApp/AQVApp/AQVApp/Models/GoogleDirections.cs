using System;
using System.Collections.Generic;
using System.Text;

namespace AQVApp.Models
{
    public static class GoogleDirections
    {
        public class Rootobject
        {
            public Route[] routes { get; set; }
            public string status { get; set; }
        }


        public class Route
        {
            public Overview_Polyline overview_polyline { get; set; }
            public Legs[] legs { get; set; }
        }


        public class Overview_Polyline
        {
            public string points { get; set; }
        }

        public class Legs
        {
            public Distance distance { get; set; }
            public Start_Location start_location { get; set; }
            public End_Location end_location { get; set; }
        }

        public class Distance
        {
            public string text { get; set; }
            public decimal distance { get; set; }
        }

        public class Durante
        {
            public string text { get; set; }
            public decimal distance { get; set; }
        }

        public class Start_Location
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }

        public class End_Location
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }
    }
}
