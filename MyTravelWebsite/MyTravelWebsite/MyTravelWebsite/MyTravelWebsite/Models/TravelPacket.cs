using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyTravelWebsite.Models
{
    public class TravelPacket
    {
        public int Id { get; set; }

        public string Destination { get; set; }

        public string Company { get; set; }

        public string Departure { get; set; }

        public string Return { get; set; }

        public string Tranportation { get; set; }

        public int Price { get; set; }
    }
}