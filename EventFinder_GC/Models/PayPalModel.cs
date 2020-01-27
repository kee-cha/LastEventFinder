using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Xunit;

namespace EventFinder_GC.Models
{
    public class PayPalModel
    {
      public Nullable<int> EventId { get; set; }
      public Nullable<decimal> AmountPaid { get; set; }
   
     public string EventName { get; set; }
     public Nullable<decimal> amount { get; set; }
     public Nullable<int> Quantity { get; set; }
    public Nullable<decimal> Price { get; set; }

    }
    }

