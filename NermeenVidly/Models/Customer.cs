using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NermeenVidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }

        [Display(Name= "Birth Date")]
        public DateTime? Birthdate { get; set; } 

        public MembershipType membershipType { get; set; }
        public byte MembershipTypeId { get; set; }



    }
}