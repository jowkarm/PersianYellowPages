using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersianYellowPages.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<Business> Business { get; set; }
    }
}
