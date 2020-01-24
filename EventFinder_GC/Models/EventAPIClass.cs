namespace EventFinder_GC.Models
{
    public class EventApi
    {
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
        public int? HostId { get; set; }
        public double? Rating { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

    }


}