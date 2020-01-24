using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventFinder_GC.Models
{
    public class EventGeoViewModel
    {
        public EventApi Events { get; set; }
        public GeoModel Location { get; set; }
    }
}