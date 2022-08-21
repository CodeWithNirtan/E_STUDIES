using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_STUDIES.Models.Students_data_viewmodels
{
    public enum Gender { Male=1,Female=2 }
    public class Teacher_DataViewmodel
    {

        [Key]

        public int Teacher_data_id { get; set; }

        [Display(Name ="Full Name")]
        [Required]
        public string Fullname { get; set; }



        //[Display(Name = "Teacher Name")]
        //[Required]
        //public string Teacher_image { get; set; }

        [Display(Name = "Teacher Phone Number")]
        [Required]
        public Nullable<long> phone { get; set; }


        //hardcodded deni hai

        //[Display(Name = "Your Child Student Id")]
        //[Required]
        //public Nullable<int> userid { get; set; }



        [Display(Name = "Your Address")]
        [Required]
        public string Teacher_address { get; set; }

        [Display(Name = "Martial Status")]
        [Required]
        public string Marital_status { get; set; }

        [Display(Name = "Your Age")]
        [Required]
        public Nullable<int> age { get; set; }

        [Display(Name = "Your Gender")]
        [Required]
        public string gender { get; set; }

        [Display(Name = "Your Qualification")]
        [Required]
        public string Qualification { get; set; }


        [Display(Name = "Your Experience")]
        [Required]
        public string Experience { get; set; }













        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Student_data> Student_data { get; set; }
        public virtual User User { get; set; }




       
    }
}