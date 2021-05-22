using System.Collections.Generic;
using StoreModels;

namespace StoreBL
{
    public interface IOrderBL
    {

        Order FindOrderByName(string orderName);
        List<Item> DisplayOrderDetails(int order_id);
       

         List<Order> ViewOrderHistoryByLocation(string locationName);

         List<Order> ViewOrderHistoryByCustomer(string  customerName);

         Order AddOrder(Order order);
         Item AddItem(Item item);

        void PlaceOrder(Customer customer,Location location, List<Item> items);
         
    }
}