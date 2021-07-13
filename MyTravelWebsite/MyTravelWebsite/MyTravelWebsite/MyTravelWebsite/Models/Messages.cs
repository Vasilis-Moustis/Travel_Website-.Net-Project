using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyTravelWebsite.Models
{
    public class Messages
    {
        public int Id { get; set; }

        public string sender { get; set; }

        public string recipient { get; set; }

        public string content { get; set; }
    }
}