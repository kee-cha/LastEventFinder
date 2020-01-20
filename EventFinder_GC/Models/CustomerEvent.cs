using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EventFinder_GC.Models
{
    public class CustomerEvent
    {
        [ForeignKey("Event")]
        public int EventId { get; set; }
        public Event Event { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}