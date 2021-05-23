using System;
using StoreModels;
using System.Text.RegularExpressions;
using Xunit;

namespace StoreTests
{
    public class CustomerTest
    {
        public bool AddressStartingPoint(string address){
            if ((address!=null) && (!address.Equals("")))
            {
                string temp = address.Substring(0, 2);
                return Regex.IsMatch(temp, @"^\d+$");
            }
            return false;
            
        }
        [Fact]
        public void AddressShouldBeginWithDigit()
        {
            //Arrange
            string address="5620 SMYRNA GA";
            Customer customer=new Customer();      

            //Act
            customer.Address=address;           

            //Assert
            Assert.True(AddressStartingPoint(customer.Address));

        }

        [Theory]
        [InlineData("56 California")]
        [InlineData("1007 Smyrna GA")]

        public void AddressShouldSetvalideData(string input){
            Assert.True(AddressStartingPoint(input));
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
   

        public void AddressCreationShouldFailOnInvalideData(string input)
        {
            Assert.False(AddressStartingPoint(input));
            //Assert.Throws<NullReferenceException>(()=>input);
        }



        [Fact]
         public void EmailShouldValidate()
        {
            //Arrange
            string email="richardlateu@";
            Customer customer=new Customer();      

            //Act
            customer.Email=email;           

            //Assert
            Assert.Contains("@", customer.Email);

        }



    }
}
