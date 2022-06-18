// Mohammad Jokar Konavi, Behrooz Kazemi, Tonya Martinez ,and Andrea Griffis
// 06/17/2022
// Module 3 Project Deliverable Assignment


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
