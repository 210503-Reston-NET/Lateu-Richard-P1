using StoreModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreDL
{
    public class ItemDL : OrderItemDL
    {
        private StoreDBContext _context;

        public ItemDL(StoreDBContext e) { this._context = e; }
        public OrderItem AddItem(OrderItem e)
        {
            _context.OrderItems.Add(e);
            return e;
        }

        public OrderItem FindItemById(int id)
        {
          return _context.OrderItems.Find(id);
        }
    }
}
