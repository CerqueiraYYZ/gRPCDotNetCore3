using GrpcServiceHW;
using GrpcServiceHW.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTestGRPC
{
    public class CustomerTests
    {

        [Fact]
        public async Task Show_Customer_FirstName_LastNameAsync()
        {
            //Arrange 
            string expectedName = "Alfredo";
            string expectedLastName= "Cerqueira";
            //Act
            CustomersService customersService = new CustomersService();
            CustomerLookupModel customer = new CustomerLookupModel { UserId = 1 };


            var response = await customersService.GetCustomerInfo(customer,null);

            //Assert

            Assert.Equal(expectedName,response.FirstName);

            Assert.Equal(expectedLastName, response.Lastname);
        }
    }
}
