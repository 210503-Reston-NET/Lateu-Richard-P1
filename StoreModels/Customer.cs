using System;

namespace StoreModels
{
    /// <summary>
    /// This class should contain necessary properties and fields for customer info.
    /// </summary>
    public class Customer
    {
        private string PhoneNumber;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone
        {
            get{ return PhoneNumber;}
            set
            {
                if (value == null || value.Equals(""))
                {
                    throw new ArgumentNullException("Customer Phone Number can't be empty or null");
                }
                PhoneNumber = value;
            }
        }
        public string Address { get; set; }
        public int LocationId { get; set; }
        public Customer() { }

        public Customer(string name, string email, string phone, string address)
        {


            this.Name = name;
            this.Email = email;
            this.Phone = phone;
            this.Address = address;
        }

        public Customer(int Id, string name, string email, string phone, string address) : this(name, email, phone, address)
        {

            this.Id = Id;
            this.Name = name;
            this.Email = email;
            this.Phone = phone;
            this.Address = address;
        }

        public override string ToString()
        {
            //  return base.ToString();
            return $" Name: {Name} \t Email: {Email} \t Phone: {Phone} \t Address:{Address} \n";
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
