using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AQVApp.Models
{
    class User
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string SocialLoginId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string TotalDistance { get; set; }
        public string TotalTrip { get; set; }
    }
}
