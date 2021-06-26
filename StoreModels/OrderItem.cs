namespace StoreModels
{
    /// <summary>
    /// 
    /// </summary>
    public class OrderItem
    {
        public int Id { get; set; }
        public double UnitPrice { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public OrderItem() { }
        public OrderItem(int orderId, int productId, int qty, double unitPrice)
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