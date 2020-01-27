using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EventFinder_GC.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Display(Name ="Last Name")]
        public string LastName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        [Display(Name ="Zip Code")]
        public string ZipCode { get; set; }
        [Display(Name ="Art")]
        public bool ArtInterest { get; set; }
        [Display(Name = "Sport")]
        public bool SportInterest { get; set; }
        [Display(Name ="Food")]
        public bool FoodInterest { get; set; }
        [Display(Name = "Music")]
        public bool MusicInterest { get; set; }
        [Display(Name = "Technology")]
        public bool TechInterest { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }
}