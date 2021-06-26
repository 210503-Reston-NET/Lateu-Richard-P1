using StoreModels;

namespace StoreDL
{
    public interface OrderItemDL
    {
        OrderItem FindItemById(int id);

        OrderItem AddItem(OrderItem e);
    }
}
