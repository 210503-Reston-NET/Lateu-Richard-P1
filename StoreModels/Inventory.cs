using System;
namespace StoreModels
{
    public class Inventory
    {
        // public Product Location;
        //public int location_id{set;get;}
        //public Location Location{set;get;}
        //public Product Product{set;get;}
        public int Id { get; set; }
        public int LocationId { get; set; }
        public int ProductId { get; set; }

        public int Quantity { set; get; }
        public DateTime OrderDate { get; set; }
        public string Inventorytype { get; set; }

        public Inventory() { }

        public override string ToString()
        {
          //  return base.ToString();
             return $"ProductId:{ProductId} \tQuantity: {Quantity} \t OrderDate: {OrderDate} \t Inventorytype: {Inventorytype}\n";
        }
    }
    
}