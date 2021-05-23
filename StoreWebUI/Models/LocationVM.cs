using StoreModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StoreWebUI.Models
{
    public class LocationVM
    {
        [Required]
        public string Address { get; set; }
        [Required]
        public string Name { get; set; }
        public int Id { get; set; }
        public LocationVM(){ }
            public LocationVM(Location l)
        {
            Id = l.Id;
            Address = l.Address;
            Name = l.Name;
        }


    }
}
