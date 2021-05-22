using System.Collections.Generic;
using System.Linq;
using Model = StoreModels;

namespace StoreDL
{
    public class CustomerDL : ICustomerDL
    {

        private StoreDBContext _context;
        public CustomerDL() { }
        public CustomerDL(StoreDBContext context)
        {
            this._context = context;
        }



        public Model.Customer AddCustomer(Model.Customer customer)
        {

            _context.Customers.Add(
                   new  Model.Customer
                   {
                       Name = customer.Name,
                       Email = customer.Email,
                       Phone = customer.Phone,
                       Address = customer.Address,
                   }
               );

            _context.SaveChanges();
            return customer;
        }


        public List<Model.Customer> GetAllCustomers()
        {

            return _context.Customers.Select(
                customer => customer
            ).ToList();
        }

        public Model.Customer FindCustomerById(int customer_id)
        {

            return new Model.Customer();
        }

        public Model.Customer GetCustomerByName(string name)
        {

            Model.Customer found = _context.Customers.FirstOrDefault(customer => customer.Name == name);
            if (found == null) return null;
            return new Model.Customer(found.Id, found.Name, found.Email, found.Phone, found.Address);

        }


        public void ViewOrderHistoryByCustomer(Model.Customer customer)
        {
            throw new System.Exception("ViewOrderHistoryByCustomer yet implemented in DL");
        }

    }
}