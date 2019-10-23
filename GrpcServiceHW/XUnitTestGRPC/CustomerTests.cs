using GrpcServiceHW;
using GrpcServiceHW.CustomerOperations;
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
            CustomerLookupModel customer = new CustomerLookupModel { UserId = 1 };
            var response = await CustomerGenralOperations.GetCustomerInfoByID(customer);

            //Assert

            Assert.Equal(expectedName,response.FirstName);

            Assert.Equal(expectedLastName, response.Lastname);
        }
    }
}
