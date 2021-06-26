using StoreDL;
using StoreModels;
using System;
using System.Collections.Generic;
namespace StoreBL
{
    public class OrderBL : IOrderBL
    {
        private IOrderDL _orderDLAccess;
        private ILocationDL _locationDL;
        private ICustomerDL _customerDL;
      public OrderBL() { }
        public OrderBL(IOrderDL dataAccess, ILocationDL locationDL, ICustomerDL customerDL)
        {
            this._orderDLAccess = dataAccess;
            this._locationDL = locationDL;
            this._customerDL = customerDL;
        }

        public Order AddOrder(Order order)
        {
            order.Status="Draft";
            return _orderDLAccess.AddOrder(order);
        }
        public OrderItem AddItem(OrderItem item)
        {
            return _orderDLAccess.AddItem(item);
        }

        public Order FindOrderByName(string orderName)
        {
            return _orderDLAccess.FindOrderByName(orderName);
        }

        public List<OrderItem> DisplayOrderDetails(int order_id)
        {

            return _orderDLAccess.DisplayOrderDetails(order_id);
        }

        public List<Order> ViewOrderHistoryByLocation(string locationName)
        {
            Location location = _locationDL.FindLocationByName(locationName);
            if (!location.Equals(null))
                return _orderDLAccess.ViewOrderHistoryByLocation(location.Id);
            return new List<Order>();

        }

        public List<Order> ViewOrderHistoryByCustomer(string customerName)
        {

            Customer customer = _customerDL.GetCustomerByName(customerName);
            if (!customer.Equals(null))
                return _orderDLAccess.ViewOrderHistoryByCustomer(customer.Id);
            return new List<Order>();
        }

        /*public string buildCode()
        {
            string temp = DateTime.Now.ToString();
            return temp.Substring(0, 17).Replace("/", "").Replace(":", "").Replace(" ", "");
        }*/

        public void PlaceOrder(string orderName, double orderTotal, int customerId, int  locationId, List<OrderItem> items)
        {
            Order order = new Order();
            order.OrderDate = DateTime.Now;
            order.OrderTotal = 0;
            order.CustomerId = customerId;
            order.LocationId = locationId;
            order.Name = orderName;
            order.OrderTotal = orderTotal;
            _orderDLAccess.AddOrder(order);
            Order newOrder = _orderDLAccess.FindOrderByName(order.Name);
            Inventory inv = new Inventory();
            inv.LocationId = locationId;
            inv.Inventorytype = "OUT";
            inv.OrderDate = order.OrderDate;

            foreach (OrderItem item in items)
            {
                item.OrderId = newOrder.Id;
                inv.ProductId = item.ProductId;
                inv.Quantity = item.Quantity;

                //Console.WriteLine("------------------");
                //Console.WriteLine(item.ToString());
                _orderDLAccess.AddItem(item);
                _orderDLAccess.AddToInventory(inv);
                _orderDLAccess.UpdateStock(item.ProductId, item.Quantity);
            }

        }

        public List<Order> FindAllOrders()
        {
          return  _orderDLAccess.FindAllOrders(); ;
        }

     public    Order FindOrderById(int id)
        {
            return _orderDLAccess.FindOrderById(id);
        }
    }
}