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
    public class BusinessDetailsViewModel
    {
        public int BusinessId { get; set; }
        public int CategoryId { get; set; }
        public int AddressId { get; set; }
        public int UserId { get; set; }
        [Required(ErrorMessage = "Please enter a English title.")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string TitleEnglish { get; set; }

        public string UserEmail { get; set; }

        public string UserDisplayName { get; set; }

        [Required(ErrorMessage = "Please enter a Persian title.")]
        [Column(TypeName = "NVARCHAR")]
        [StringLength(100)]
        public string TitlePersian { get; set; }

        [Required(ErrorMessage = "Please enter the English description.")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(1000)]
        public string DescriptionEnglish { get; set; }

        [Required(ErrorMessage = "Please enter the Persian description.")]
        [Column(TypeName = "NVARCHAR")]
        [StringLength(1000)]
        public string DescriptionPersian { get; set; }

        [Required(ErrorMessage = "Please enter a phone number.")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(15)]
        public string Phone1 { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(15)]
        public string Phone2 { get; set; }

        [Required(ErrorMessage = "Please enter a website address.")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string Website { get; set; }

        [Required(ErrorMessage = "Please enter a email address.")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string Email { get; set; }
        public bool Verified { get; set; }

        [Required(ErrorMessage = "Please enter an address.")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string AddressLine1 { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string AddressLine2 { get; set; }

        [Required(ErrorMessage = "Please enter the google map link.")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(400)]
        public string GoogleMapLink { get; set; }

        [Required(ErrorMessage = "Please enter five digits zipcode.")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(5, MinimumLength = 5)]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Please enter the city name.")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(25)]
        public string City { get; set; }


        [Required(ErrorMessage = "Please enter the state abbreviation.")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(2, MinimumLength = 2)]
        public string State { get; set; }

        [Required(ErrorMessage = "Please enter the category name.")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(30)]
        public string CategoryName { get; set; }
        public decimal RateAverage { get; set; }
        public string PageTitle { get; set; }

    }
}
