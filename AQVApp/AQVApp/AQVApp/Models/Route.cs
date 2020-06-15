using System;
using System.Collections.Generic;
using System.Text;

namespace AQVApp.Models
{
    public class Route
    {
        internal string Type;

        public string Source { get; set; }
        public string Target { get; set; }
        public string Weight { get; set; }
        public bool LoadHour { get; set; }
        public List<Notification> Notifications { get; set; }

    }
    public class Notification
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public string Hour { get; set; }
        public string Label { get; internal set; }
    }

}
