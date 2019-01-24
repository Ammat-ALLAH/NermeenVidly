using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NermeenVidly.DTOs
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }

        [Display(Name = "Birth Date")]
        public DateTime? Birthdate { get; set; }

        //[Min18YearsOldIfMember]
        [Required(ErrorMessage = "Please Choose one of the membership types")]
        public byte MembershipTypeId { get; set; }
    }
}