using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventFinderAPI.Models
{
    public class Events
    {
        [Key]
        public int EventId { get; set; }
        public string EventName { get; set; }
        public string VenueName { get; set; }
        public string Date { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
    }
}