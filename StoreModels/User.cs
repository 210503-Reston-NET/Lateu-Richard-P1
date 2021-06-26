using System;
using Microsoft.AspNetCore.Identity;
namespace StoreModels
{
    public class User:IdentityUser<int>
    {
        [PersonalData]
        public string FirstName{set;get;}

        [PersonalData]
        public string LastName{set;get;}
        //public string Password{set;get;}
        public bool Active{get;set;}


          public override string ToString()
        {
            return $"\t  Name: {FirstName} \t Login: {LastName} \t Active:{Active}";
        }
    }
}