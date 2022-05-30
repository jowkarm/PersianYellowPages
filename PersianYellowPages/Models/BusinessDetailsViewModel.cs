using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersianYellowPages.Models
{
    public class BusinessDetailsViewModel
    {
        public int BusinessId { get; set; }
        public string TitleEnglish { get; set; }
        public string TitlePersian { get; set; }
        public string DescriptionEnglish { get; set; }
        public string DescriptionPersian { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public bool Verified { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string GoogleMapLink { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string CategoryName { get; set; }
        public decimal RateAverage { get; set; }
        public string PageTitle { get; set; }

    }
}
