using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersianYellowPages.Models
{
    public class UserProfile
    {
        public int UserId { get; set; }
        public string UserEmail { get; set; }
        public string UserDisplayName { get; set; }

        public virtual ICollection<Business> Business { get; set; }
        public virtual ICollection<Review> Review { get; set; }
    }
}
