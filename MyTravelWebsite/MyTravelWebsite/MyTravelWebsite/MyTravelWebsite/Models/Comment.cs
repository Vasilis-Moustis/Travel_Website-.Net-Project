using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyTravelWebsite.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public string user { get; set; }

        public string content { get; set; }
    }
}