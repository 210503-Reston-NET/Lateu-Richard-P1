using StoreModels;
using System.Collections.Generic;
namespace StoreDL
{
    public interface IOrderDL
    {

        Order FindOrderByName(string orderName);
        Order AddOrder(Order order);
        OrderItem AddItem(OrderItem item);
        List<OrderItem> DisplayOrderDetails(int order_id);
        List<Order> ViewOrderHistoryByLocation(int location_id);
        List<Order> ViewOrderHistoryByCustomer(int customer_id);
        void PlaceOrder(Customer customer, Location l, List<OrderItem> items);
        Order FindOrderById(int id);
        Inventory AddToInventory(Inventory nv);

        void UpdateStock(int pid, int qty);

         List<Order> FindAllOrders();

    }
}