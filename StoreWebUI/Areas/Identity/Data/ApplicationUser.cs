using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Lateu_Richard_P1.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
       // [Column(TypeName="varchar(50)")]
        public string FirstName { set; get; }

        [PersonalData]
       // [Column(TypeName = "varchar(50)")]
        public string LastName { set; get; }
        //public string Password{set;get;}
        public bool Active { get; set; }


        public override string ToString()
        {
            return $"\t  Name: {FirstName} \t Login: {LastName} \t Active:{Active}";
        }
    }
}
