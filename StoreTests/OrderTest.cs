using System;
using StoreModels;
using Xunit;

namespace StoreTests
{
    public class OrderTest
    {
      
        [Fact]
        public void OrderShouldContentItems()
        {
            //Arrange
            //Item item
            Order order=new Order();
            order.OrderDate=DateTime.Now;

            //Act

            //Assert
            Assert.Throws<NullReferenceException>(() => order.OrderItems.Count > 0);
          

        }

        [Fact]
         public void ItemPriceShouldValidate()
        {
            //Arrange
            int price=20;
            OrderItem item=new OrderItem();      

            //Act
            item.UnitPrice=price;           

            //Assert
            Assert.True(price>0);

        }


         [Fact]
         public void ItemQuantityShouldValidate()
        {
            //Arrange
           
            Product p1=new Product();
            Inventory inventory=new Inventory();           
            OrderItem item=new OrderItem();      

            //Act
            int quantityOrder=20000;
            //inventory.product=p1;
            inventory.Quantity=5000;
                

            //Assert
            Assert.False(quantityOrder<=inventory.Quantity);

        }



    }
}
