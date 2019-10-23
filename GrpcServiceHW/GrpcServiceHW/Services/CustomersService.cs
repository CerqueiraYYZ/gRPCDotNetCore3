using Grpc.Core;
using GrpcServiceHW.CustomerOperations;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcServiceHW.Services
{
    public class CustomersService : Customer.CustomerBase
    {
        private readonly ILogger<CustomersService> _logger;

        public CustomersService(ILogger<CustomersService> logger)
        {
            _logger = logger;
        }
        public override Task<CustomerModel> GetCustomerInfo(CustomerLookupModel request, ServerCallContext context)
        {
            return CustomerGenralOperations.GetCustomerInfoByID(request);

        }

        public override async Task GetNewCustomers(NewCustomerRequest request, IServerStreamWriter<CustomerModel> responseStream, ServerCallContext context)
        {
            List<CustomerModel> customers = new List<CustomerModel>
            {
                new CustomerModel
                {
                    FirstName = "Tim",
                    Lastname = "Corey",
                    EmailAdderss = "blabla@g.com",
                    Age = 32,
                    IsAlive = true
                },
                new CustomerModel
                {
                    FirstName = "Alfredo",
                    Lastname = "Cerqueira",
                    EmailAdderss = "blabla@g.com",
                    Age = 40,
                    IsAlive = false
                },
                new CustomerModel
                {
                    FirstName = "Dan",
                    Lastname = "Cork",
                    EmailAdderss = "blabla@g.com",
                    Age = 20,
                    IsAlive = false
                }
            };

            foreach (var cust in customers)
            {
                //await Task.Delay(2000);
               await responseStream.WriteAsync(cust);
            }
        }
    }
}
