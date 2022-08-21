using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_STUDIES.Models.Viewmodels
{
    public class FeedBack_ViewModel
    {


        [Key]

        public int Feedback_id { get; set; }

        [Display(Name = "Subject")]
        [Required]
     
        public string Subjects { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "message")]
        [Required]
        public string Feedback_messages { get; set; }

        public virtual User User { get; set; }
    }
}