using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_STUDIES.Models.Students_data_viewmodels
{
    public class Student_dataViewModel
    {

        [Key]
        public int Student_data_id { get; set; }

        [Display(Name ="Full Name")]
        [Required]
        public string Fullname { get; set; }


        [DataType(DataType.Date)]
        [Display(Name = "Enrollment Date")]
        [Required]
        public Nullable<System.DateTime> Enrollment_date { get; set; }

        [Required]
        public string Student_address { get; set; }


        [Required]
        public Nullable<int> Student_age { get; set; }

        [Required]
        public Nullable<long> phone { get; set; }

        [Required]
        public string Student_image { get; set; }

        //public Nullable<int> Teacher_data_id { get; set; }
        //public Nullable<int> userid { get; set; }

        //public virtual Teacher_data Teacher_data { get; set; }
        //public virtual User User { get; set; }
    }
}