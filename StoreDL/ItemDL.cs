using StoreModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreDL
{
    public class ItemDL : IItemDL
    {
        private StoreDBContext _context;

        public ItemDL(StoreDBContext e) { this._context = e; }
        public Item AddItem(Item e)
        {
            _context.Items.Add(e);
            return e;
        }

        public Item FindItemById(int id)
        {
          return _context.Items.Find(id);
        }
    }
}
