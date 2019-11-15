using GrpcServiceTest.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcServiceTest.CustomerOperations
{
    public class CustomerGeneralOperations
    {
        public static Task<CustomerModel> GetCustomerInfoByID(CustomerLookupModel request)
        {
            CustomerModel output = new CustomerModel();

            if (request.UserId == 1)
            {
                output.FirstName = "Alfredo";
                output.Lastname = "Cerqueira";
            }
            else if (request.UserId == 2)
            {
                output.FirstName = "Pablo";
                output.Lastname = "El Pablo";
            }
            else
            {
                output.FirstName = "Frank";
                output.Lastname = "El Frank";
            }

            return Task.FromResult(output);
        }
    }
}
