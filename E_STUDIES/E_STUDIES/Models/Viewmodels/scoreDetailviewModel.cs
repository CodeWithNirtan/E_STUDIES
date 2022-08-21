using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_STUDIES.Models.Viewmodels
{
    public class scoreDetailviewModel
    {

        public int scoreid { get; set; }


        public string Subjects { get; set; }
        public int mark { get; set; }
        public int obtainMarks { get; set; }
        public long Userid { get; set; }
    }
}