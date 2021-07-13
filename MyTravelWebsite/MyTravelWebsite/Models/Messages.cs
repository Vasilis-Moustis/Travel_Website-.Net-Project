using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyTravelWebsite.Models
{
    public class Messages
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string sender { get; set; }
        [Required]
        public string recipient { get; set; }
        [Required]
        public string content { get; set; }
    }
}