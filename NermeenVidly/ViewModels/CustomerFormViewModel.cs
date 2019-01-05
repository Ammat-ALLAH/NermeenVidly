using NermeenVidly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NermeenVidly.ViewModels
{
    public class CustomerFormViewModel
    {
        public Customer customer{ get; set; }
        public List<MembershipType> MembershipTyes { get; set; }


    }
}