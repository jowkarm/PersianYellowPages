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
    public class Business
    {
        public int BusinessId { get; set; }

        [Required(ErrorMessage = "Please enter the English title.")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string TitleEnglish { get; set; }

        [Required(ErrorMessage = "Please enter the Persian title.")]
        [Column(TypeName = "NVARCHAR")]
        [StringLength(100)]
        public string TitlePersian { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(1000)]
        public string DescriptionEnglish { get; set; }

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

        [Required(ErrorMessage = "Please enter an email address.")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string Email { get; set; }


        public int CategoryId { get; set; }


        public int AddressId { get; set; }

        public int UserId { get; set; }

        public bool Verified { get; set; }


        public Category Categories { get; set; }


        public UserProfile UserProfiles { get; set; }

        public Address Addresses { get; set; }



    }
}
