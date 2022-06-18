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
    public class Review
    {
        public int ReviewId { get; set; }
        public int Rate { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [StringLength(500)]
        public string Comment { get; set; }

        public DateTime DateTime { get; set; }
        public int BusinessId { get; set; }
        public int UserId { get; set; }


    }
}
