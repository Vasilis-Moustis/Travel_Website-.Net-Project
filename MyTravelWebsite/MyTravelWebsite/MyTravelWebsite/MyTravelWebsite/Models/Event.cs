using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyTravelWebsite.Models
{
    public class Event
    {
        public int Id { get; set; }

        public string Place { get; set; }

        public string Company { get; set; }

        public string Date { get; set; }

        public int Duration { get; set; }

        public string Notes { get; set; }
    }
}