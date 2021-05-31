using System;
using StoreModels;
using StoreDL;
using System.Collections.Generic;
namespace StoreBL
{
    public class CustomerBL:ICustomerBL
    {
        private ICustomerDL _dataAccess;
        private ILocationDL  _locationDL;
        //public CustomerBL(){}
        public CustomerBL(ICustomerDL iCustomerDL,ILocationDL ldl )
        {
            this._dataAccess=iCustomerDL;
            this._locationDL=ldl;
        }

        public Customer AddCustomer(Customer c){
                    c.LocationId=_locationDL.GetAllLocations()[0].Id;
                   _dataAccess.AddCustomer(c);
             return c;
         }

           public Customer GetCustomerByName(string name){
               return _dataAccess.GetCustomerByName(name);
           }

      public List<Customer> GetAllCustomers(){
          return _dataAccess.GetAllCustomers();
      }

      public Customer FindCustomerById(int customer_id){
          return _dataAccess.FindCustomerById(customer_id);
      }

     public Customer DeleteCustomer(Customer customer){
         return _dataAccess.DeleteCustomer(customer);
     }

        public List<Order> ViewOrderHistoryByCustomer(int customerId){
            return _dataAccess.ViewOrderHistoryByCustomer(customerId);
        }

        
    }
}
