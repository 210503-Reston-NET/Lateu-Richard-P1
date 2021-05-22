using System;
namespace StoreDL
{
    public class User
    {
        public int Id{get;set;}
        public string Username{get;set;}
        public string Name{get;set;}
        public string Password{get;set;}
        public DateTime LastAuth{get;set;}
        public bool Active{get;set;}


          public override string ToString()
        {
            return $"\t  Name: {Name} \t Login: {Username} \t Last Authentification: {LastAuth} Active:{Active}";
        }
    }
}