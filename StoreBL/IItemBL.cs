using StoreModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreBL
{
    public interface IItemBL
    {
        OrderItem FindItemById(int id);
        OrderItem AddItem(OrderItem e);


    }
}
