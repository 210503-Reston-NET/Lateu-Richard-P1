using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using StoreModels;
namespace StoreWebUI.Models
{
    public class CustomerVM
    {
        private string PhoneNumber;
        public int Id { get; set; }

        [Required]
        [DisplayName("Customer Name")]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Address { get; set; }
        public CustomerVM() { }
        public CustomerVM(Customer customer)
           
        {
            this.Id = customer.Id;
            this.Name = customer.Name;
            this.Email = customer.Email;
            this.Phone = customer.Phone;
            this.Address = customer.Address;

        }
    }
}
