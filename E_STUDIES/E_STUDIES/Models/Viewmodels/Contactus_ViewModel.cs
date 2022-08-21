using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using E_STUDIES.Controllers;

namespace E_STUDIES.Models.Viewmodels
{
    public class Contactus_ViewModel
    {
        [Key]

        public int Contact_us_id { get; set; }

        [Display(Name = "Subject")]
        [Required]
        public string Subjects { get; set; }

        [Display(Name = "email")]
        [Required]
        public string email { get; set; }
        [DataType(DataType.MultilineText)]
        [Display(Name = "message")]
        [Required]
        public string Contact_us_messages { get; set; }

        public virtual User User { get; set; }



    }


}