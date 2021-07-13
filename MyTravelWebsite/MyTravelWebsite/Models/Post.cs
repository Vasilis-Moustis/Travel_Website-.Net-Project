using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyTravelWebsite.Models
{
    public class Post
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string user { get; set; }
        [Required]
        public string content { get; set; }
    }
}