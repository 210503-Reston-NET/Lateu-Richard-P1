using System.Collections.Generic;
using Model = StoreModels;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using StoreModels;

namespace StoreDL
{
    public class OrderDL : IOrderDL
    {


        private StoreDBContext _context;
        public OrderDL() { }
        public OrderDL(StoreDBContext context)
        {
            this._context = context;
        }

        public Model.Order FindOrderByName(string orderName)
        {
            Model.Order response = _context.Orders.FirstOrDefault(order => order.Name == orderName);
            if (response == null) return null;
            return new Model.Order(response.Id, response.CustomerId, response.LocationId, response.OrderDate, response.OrderTotal, response.Name,response.Status);

        }


        public List<Model.OrderItem> DisplayOrderDetails(int order_id)
        {
            return _context.Items.Where(
                    item => item.OrderId == order_id
                ).Select(
                    item => new Model.OrderItem
                    {
                        OrderId = item.OrderId,
                        ProductId = item.ProductId,
                        Quantity = item.Quantity,
                        UnitPrice = item.UnitPrice,
                        

                    }
                ).ToList();

        }

        public List<Model.Order> ViewOrderHistoryByLocation(int location_id)
        {
            return _context.Orders.Where(
                     order => order.LocationId == location_id
                 ).Select(
                     order => new Model.Order
                     {
                         Id = order.Id,
                         CustomerId = order.CustomerId,
                         OrderDate = order.OrderDate,
                         OrderTotal = order.OrderTotal,
                         LocationId = order.LocationId,

                     }
                 ).ToList();
        }

        public List<Model.Order> ViewOrderHistoryByCustomer(int customer_id)
        {
            return _context.Orders.Where(
                    order => order.CustomerId == customer_id
                ).Select(
                    order => new Model.Order
                    {
                        Id = order.Id,
                        CustomerId = order.CustomerId,
                        OrderDate = order.OrderDate,
                        OrderTotal = order.OrderTotal,
                        LocationId = order.LocationId,

                    }
                ).ToList();
        }

        public Model.Order AddOrder(Model.Order order)
        {
            _context.Orders.Add(
                           new Model.Order
                           {

                               OrderDate = order.OrderDate,
                               OrderTotal = order.OrderTotal,
                               CustomerId = order.CustomerId,
                               LocationId = order.LocationId,
                               Name = order.Name,
                               Status="Draft",




                           }
                       );

            _context.SaveChanges();
            return order;
        }
        public Model.OrderItem AddItem(Model.OrderItem item)
        {
            _context.Items.Add(
                new Model.OrderItem
                {
                    OrderId = item.OrderId,
                    ProductId = item.ProductId,
                    UnitPrice = item.UnitPrice,
                    Quantity = item.Quantity,

                }
            );
            _context.SaveChanges();
            return item;
        }


        public Model.Inventory AddToInventory(Model.Inventory inv)
        {
            _context.Inventories.Add(
                new Model.Inventory
                {
                    Quantity = inv.Quantity,
                    LocationId = inv.LocationId,
                    ProductId = inv.ProductId,
                    OrderDate = inv.OrderDate,
                    Inventorytype = inv.Inventorytype,
                }
            );

            _context.SaveChanges();
            return inv;

        }

        public void UpdateStock(int pid, int qty){
           // Model.Product nwp=new Model.Product();
            Model.Product oldP= _context.Products.Find(pid);
            int newstock=oldP.AvailableStock-qty;
            //nwp=oldP.Clone();
            //nwp.AvailableStock=newstock;
           //nwp.Id=pid;
            _context.Entry(oldP).CurrentValues.SetValues(new Model.Product(oldP.Id,oldP.Name,oldP.Price,oldP.Barcode,newstock));
            _context.SaveChanges();
           // _context.ChangeTracker.Clear();   

        }

        public void PlaceOrder(Model.Customer customer, Model.Location location, List<Model.OrderItem> items)
        {

        }

        public List<Order> FindAllOrders()
        {
         return  _context.Orders.Select(
               order=>order).ToList();
        }

       public Order FindOrderById(int id) {
            return _context.Orders.Find(id);
        }
    }
}