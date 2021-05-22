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
            Assert.True(order.Items.Count>0);

        }

        [Fact]
         public void ItemPriceShouldValidate()
        {
            //Arrange
            int price=20;
            Item item=new Item();      

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
            Item item=new Item();      

            //Act
            int quantityOrder=20000;
            //inventory.product=p1;
            inventory.quantity=5000;
                

            //Assert
            Assert.False(quantityOrder<=inventory.quantity);

        }



    }
}
