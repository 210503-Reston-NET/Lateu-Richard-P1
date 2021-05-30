using System.Collections.Generic;
using StoreModels;
namespace StoreBL
{
    public interface ICustomerBL
    {
         Customer AddCustomer(Customer c);
         Customer GetCustomerByName(string name);

       List<Customer> GetAllCustomers();

      Customer FindCustomerById(int customer_id);
      Customer DeleteCustomer(Customer customer);


        List<Order> ViewOrderHistoryByCustomer(int customer);

         
    }
}