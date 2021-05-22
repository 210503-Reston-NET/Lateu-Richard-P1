using System;
using StoreModels;
using StoreDL;
using System.Collections.Generic;
namespace StoreBL
{
    public class CustomerBL:ICustomerBL
    {
        private ICustomerDL _dataAccess;
        //public CustomerBL(){}
        public CustomerBL(ICustomerDL iCustomerDL )
        {
            this._dataAccess=iCustomerDL;
        }

        public Customer AddCustomer(Customer c){
                   _dataAccess.AddCustomer(c);
             return c;
         }

           public Customer GetCustomerByName(string name){
               return _dataAccess.GetCustomerByName(name);
           }

      public List<Customer> GetAllCustomers(){
          return _dataAccess.GetAllCustomers();
      }

      /*public Location FindCustomerById(int customer_id){
          return _dataAccess.FindCustomerById(customer_id);
      }*/

     
        public void ViewOrderHistoryByCustomer(Customer customer){
             _dataAccess.ViewOrderHistoryByCustomer(customer);
        }

        
    }
}
