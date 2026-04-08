using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    
    public class User : IdentityUser
    {
        public string DisplayName { get; set; }
        public Address Address { get; set; }

        public string Role { get; set; } // Restaurant/Consumer/Charity/Admin
        public string Phone { get; set; }
        public string Status { get; set; } // Active/Inactive
        public string AddressText { get; set; }

        // Navigation Properties


        public Restaurant Restaurant { get; set; }
        public Charity Charity { get; set; }
        public Consumer Consumer { get; set; }
        public DeliveryPartner DeliveryPartner { get; set; }


    }
}
