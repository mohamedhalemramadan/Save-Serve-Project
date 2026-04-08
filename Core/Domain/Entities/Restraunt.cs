using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{

    public class Restaurant : BaseEntity<int>
    {
        public string OpeningHours { get; set; }
        public string Type { get; set; } // Restaurant/Hotel/Cafe
        public decimal Rating { get; set; }
        public string ClosingHours { get; set; }

        // Navigation
        public User User { get; set; }
        public string UserId { get; set; } // FK to User

        public ICollection<FoodItem> FoodItems { get; set; }
    }
}
