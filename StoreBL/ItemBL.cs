using StoreDL;
using StoreModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreBL
{
   public  class ItemBL : IItemBL
    {
        private OrderItemDL _itemDL;

        public ItemBL(OrderItemDL e) { this._itemDL = e; }
        public OrderItem AddItem(OrderItem e)
        {
            return _itemDL.AddItem(e);
        }

        public OrderItem FindItemById(int id)
        {
            return _itemDL.FindItemById(id);
        }
    }
}
