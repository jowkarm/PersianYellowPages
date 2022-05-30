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
        public int BusinessID { get; set; }

        [Required(ErrorMessage = "Please enter an English title.")]
        public string TitleEnglish { get; set; }

        [Required(ErrorMessage = "Please enter a Persian title.")]
        public string TitlePersian { get; set; }

        public string DescriptionEnglish { get; set; }

        public string DescriptionPersian { get; set; }

        [Required(ErrorMessage = "Please enter a phone number.")]
        public string Phone1 { get; set; }

        public string Phone2 { get; set; }

        [Required(ErrorMessage = "Please enter a phone number.")]
        public string Website { get; set; }

        [Required(ErrorMessage = "Please enter a phone number.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter available sqft")]
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "Please enter available sqft")]
        public int AddressID { get; set; }

        //public  Address Address { get; set; }
        public  Category Categories { get; set; }
        //public  UserProfile User { get; set; }


      
    }
}
