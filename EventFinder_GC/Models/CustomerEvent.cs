using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EventFinder_GC.Models
{
    public class CustomerEvent
    {
        
        
    
        [Key, Column(Order = 1), ForeignKey("Event")]
        
        public int EventId { get; set; }
        public Event Event { get; set; }
        
        [Key, Column(Order = 2), ForeignKey("Customer")]
        
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}