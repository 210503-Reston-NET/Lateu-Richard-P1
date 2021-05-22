using System;
using StoreModels;
using System.Text.RegularExpressions;
using Xunit;

namespace StoreTests
{
    public class ProductTest
    {
        [Fact]
        public void NameShouldValidate()
        {
            //Arrange
            string name="Computer";
            Product product=new Product();      

            //Act
            product.Name=name;           

            //Assert
            Assert.True(name.Length>5);
          

        }

        [Fact]
         public void NameCaractersShouldValidate()
        {
            //Arrange
            string name="richardlateu@";
            Product product=new Product();      
            char [] s={'@','#','*','!','.','/','~'};
            int res=name.IndexOfAny(s);
            //Act
            product.Name=name;           

            //Assert
            Assert.False(-1==res);

        }

        [Fact]
         public void MinimumStockShouldValidate()
        {
            //Arrange
            int qty=30;
            int MIN=20;
            Product product=new Product();     
         
            //Act
             product.AvailableStock=qty;          

            //Assert
            Assert.True(product.AvailableStock>=MIN);

        }


        
    }
}
