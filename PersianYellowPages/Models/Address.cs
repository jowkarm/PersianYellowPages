// Mohammad Jokar Konavi, Behrooz Kazemi, Tonya Martinez ,and Andrea Griffis
// 06/17/2022
// Module 3 Project Deliverable Assignment


using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PersianYellowPages.Models
{
    public class Address
    {
        public int AddressId { get; set; }

        [Required(ErrorMessage = "Please enter the address.")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string AddressLine1 { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string AddressLine2 { get; set; }

        [Required(ErrorMessage = "Please enter the city name.")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(25)]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter the state abbreviation.")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(2, MinimumLength = 2)]
        public string State { get; set; }

        [Required(ErrorMessage = "Please enter five digits zipcode.")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(5, MinimumLength = 5)]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Please enter the google map link.")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(400)]
        public string GoogleMapLink { get; set; }

        public virtual ICollection<Business> Business { get; set; }
    }
}
