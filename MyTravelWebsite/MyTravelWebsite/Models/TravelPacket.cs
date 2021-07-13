using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyTravelWebsite.Models
{
    public class TravelPacket
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Destination { get; set; }
        [Required]
        public string Company { get; set; }
        [Required]
        public string Departure { get; set; }
        [Required]
        public string Return { get; set; }
        [Required]
        public string Tranportation { get; set; }
        [Required]
        public int Price { get; set; }
    }
}