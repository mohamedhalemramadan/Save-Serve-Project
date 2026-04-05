using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Consumer : BaseEntity<int>
    {
        public string UserId { get; set; }
        public int Age { get; set; }
        public string PreferredPaymentMethod { get; set; }
        public User User { get; set; }
        public ICollection<Order> Orders { get; set; }
        public string Gender { get; set; }
    }

}
