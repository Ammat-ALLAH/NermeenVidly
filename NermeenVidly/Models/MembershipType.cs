﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NermeenVidly.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        public short SignUpFee{ get; set; }
        public byte DuraitionInMonth { get; set; }
        public byte DiscountRate { get; set; }

    }
}