﻿using StoreModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreDL
{
   public interface IItemDL
    {
       Item FindItemById(int id);

        Item AddItem(Item e);
    }
}
