using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_STUDIES.Models
{
    public class Convertions
    {
        public  static int ToEnum(string role) {
            if (role == "Student")
            {
                return 1;
            }
            else if (role == "Parent")
            {
                return 2;
            }
            else {
                return 3;
             }
        }
    }
}