using System;
using System.Collections.Generic;
namespace StoreModels
{

    /// <summary>
    /// This class should contain all the fields and properties that define a customer order. 
    /// </summary>
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int LocationId { get; set; }
        public DateTime OrderDate { get; set; }
        public double OrderTotal { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }

        public List<Item> Items { get; set; }
        public Order() { }
        public Order(int customer_id, int location_id, DateTime orderDate, double orderTotal, string name,string st) {
            this.CustomerId = customer_id;
            this.LocationId = location_id;
            this.OrderDate = orderDate;
            this.OrderTotal = orderTotal;
            this.Name = name;
            this.Status=st;
        }

        public Order(int Id, int customer_id, int location_id, DateTime orderDate, double orderTotal, string name,string status) : this(customer_id, location_id, orderDate, orderTotal, name,status) {
            this.CustomerId = customer_id;
            this.LocationId = location_id;
            this.OrderDate = orderDate;
            this.OrderTotal = orderTotal;
            this.Name = name;
            this.Status=status;
            this.Id = Id;

        }

        public virtual Customer Customer{get;set;}
          public override string ToString()
        {
          //  return base.ToString();
             return $" Name {Name}\t Customer ID: {CustomerId} \t Location ID: {LocationId}\t Date {OrderDate} \t Items: {Items}\n";
        }
    
       
    }
}