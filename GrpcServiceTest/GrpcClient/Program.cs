using Grpc.Core;
using Grpc.Net.Client;
using GrpcServiceTest;
using GrpcServiceTest.Protos;
using System;
using System.Threading.Tasks;

namespace GrpcClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                AppContext.SetSwitch(
                    "System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);

                var channel = GrpcChannel.ForAddress("http://localhost:5000");

                var input = new HelloRequest { Name = "Tim" };

                var client = new Greeter.GreeterClient(channel);


                var reply = await client.SayHelloAsync(input);

                Console.WriteLine("El mensaje: " + reply.Message);




                var customerClient = new Customer.CustomerClient(channel);

                var clientRequested = new CustomerLookupModel { UserId = 2 };

                var customer = await customerClient.GetCustomerInfoAsync(clientRequested);

                Console.WriteLine($"{customer.FirstName } {customer.Lastname} ");

                Console.WriteLine();
                Console.WriteLine("************************Customer List******************");
                Console.WriteLine();

                using (var call = customerClient.GetNewCustomers(new NewCustomerRequest()))
                {
                    while (await call.ResponseStream.MoveNext())
                    {
                        var currentCustomer = call.ResponseStream.Current;

                        Console.WriteLine($"{currentCustomer.FirstName } {currentCustomer.Lastname} {currentCustomer.EmailAdderss } {currentCustomer.Age}");
                    }
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine("Error: " + ex);
            }

            Console.ReadLine();
        }
    }
}
