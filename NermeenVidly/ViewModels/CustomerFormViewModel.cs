using NermeenVidly.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NermeenVidly.ViewModels
{
    public class CustomerFormViewModel
    {
        public CustomerFormViewModel()
        {
            Id = 0;
        }
        public int? Id { get; set; }
        [Required]
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }

        [Display(Name = "Birth Date")]
        public DateTime? Birthdate { get; set; }

        [Min18YearsOldIfMember]
        [Required(ErrorMessage = "Please Choose one of the membership types")]
        public byte MembershipTypeId { get; set; }

        public List<MembershipType> MembershipTyes { get; set; }


    }
}