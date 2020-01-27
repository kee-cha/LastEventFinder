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
        [Display(Name ="Event Name")]
        public string EventName { get; set; }
        [Display(Name ="Venue Name")]
        public string VenueName { get; set; }
        public string Date { get; set; }
        public string Category { get; set; }
        [Display(Name ="Sub Category")]
        public string SubCategory { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        [Display(Name ="Zip Code")]
        public string ZipCode { get; set; }
        [ForeignKey("Host")]
        public int? HostId { get; set; }
        public Host Host { get; set; }
        public object PayPal { get; internal set; }
    }
}