namespace StoreModels
{
    /// <summary>
    /// This data structure models a product and its quantity. The quantity was separated from the product as it could vary from orders and locations.  
    /// </summary>
    public class Item
    {
        public int Id { get; set; }
        public double UnitPrice { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public Item() { }
        public Item(int orderId, int productId, int qty, double unitPrice)
        {
            this.OrderId = orderId;
            this.ProductId = productId;
            this.Quantity = qty;
            this.UnitPrice = unitPrice;
        }

        public override string ToString()
        {
            return $"\t Product ID: {ProductId} \t Quantity: {Quantity} \t Unit Price: {UnitPrice}";
        }
    }
}