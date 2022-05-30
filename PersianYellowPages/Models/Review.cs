using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersianYellowPages.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public int Rate { get; set; }
        public string Comment { get; set; }
        public DateTime DateTime { get; set; }
        public int BusinessId { get; set; }
        public int UserId { get; set; }

        
    }
}
