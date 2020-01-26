using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EventFinder_GC.Models
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }
        public string EventName { get; set; }
        public string VenueName { get; set; }
        public string Date { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        [ForeignKey("Host")]
        public int? HostId { get; set; }
        public Host Host { get; set; }


    }
}