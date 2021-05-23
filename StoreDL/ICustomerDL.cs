using StoreModels;
using System.Collections.Generic;
using System;
namespace StoreDL
{
    public  interface ICustomerDL
    {
        Customer AddCustomer(Customer customer); 

       List<Customer> GetAllCustomers();

       Customer FindCustomerById(int customer_id);

       Customer GetCustomerByName(string name);

       Customer DeleteCustomer(Customer customer);
       
       void ViewOrderHistoryByCustomer(Customer c);
    }
}