using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyTravelWebsite.Models
{
    public class Event
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Place { get; set; }
        [Required]
        public string Company { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
        public int Duration { get; set; }
        [Required]
        public string Notes { get; set; }
    }
}