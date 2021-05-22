using System.Collections.Generic;
using StoreModels;
namespace StoreBL
{
    public interface ICustomerBL
    {
         Customer AddCustomer(Customer c);
         Customer GetCustomerByName(string name);

       List<Customer> GetAllCustomers();

     //public  Customer FindCustomerById(int customer_id);

 
         void ViewOrderHistoryByCustomer(Customer customer);

         
    }
}