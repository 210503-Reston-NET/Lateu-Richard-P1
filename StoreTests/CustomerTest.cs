using System;
using StoreModels;
using System.Text.RegularExpressions;
using Xunit;

namespace StoreTests
{
    public class CustomerTest
    {
        public bool AddressStartingPoint(string address){
            string temp=address.Substring(0,2);
            return Regex.IsMatch(temp, @"^\d+$");
        }
        [Fact]
        public void AddressShouldSetValidateData()
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
        [InlineData("")]
        [InlineData("California")]
        [InlineData(null)]
        [InlineData("1007 Smyrna GA")]

        public void AddressShouldNotSetInvalideData(string input){
            Assert.True(AddressStartingPoint(input));
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
