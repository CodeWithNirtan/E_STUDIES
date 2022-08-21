using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_STUDIES.Models.Viewmodels
{
    public class Parent_dataViewModel

    {
       [Key]
        public int Parents_data_id { get; set; }


            [Display(Name = "Parent Name")]
            [Required]
    //    public string Parents_address { get; set; }
            public string Parent_Name { get; set; }


        [Display(Name = "Address")]
        [Required]
        public string Parents_address { get; set; }


        [Display(Name = "Cnic")]
        [Required]
        public string Cnic { get; set; }


        [Display(Name = "Parents Phone Number")]
        [Required]
        public Nullable<long> phone { get; set; }


        public virtual User User { get; set; }



    }
}