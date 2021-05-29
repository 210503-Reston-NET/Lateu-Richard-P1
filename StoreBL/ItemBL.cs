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
        private IItemDL _itemDL;

        public ItemBL(IItemDL e) { this._itemDL = e; }
        public Item AddItem(Item e)
        {
            return _itemDL.AddItem(e);
        }

        public Item FindItemById(int id)
        {
            return _itemDL.FindItemById(id);
        }
    }
}
