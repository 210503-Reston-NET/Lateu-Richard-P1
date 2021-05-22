using StoreModels;
using System.Collections.Generic;
namespace StoreDL
{
    public interface IOrderDL
    {

        Order FindOrderByName(string orderName);
        Order AddOrder(Order order);
        Item AddItem(Item item);
        List<Item> DisplayOrderDetails(int order_id);
        List<Order> ViewOrderHistoryByLocation(int location_id);
        List<Order> ViewOrderHistoryByCustomer(int customer_id);
        void PlaceOrder(Customer customer, Location l, List<Item> items);

        Inventory AddToInventory(Inventory nv);

        void updateStock(int pid, int qty);

    }
}