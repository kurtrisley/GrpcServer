using Grpc.Net.Client;
using GrpcServer;
using System;

namespace GrpcClient
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            Console.WriteLine("Calling GRPC Service");
            Console.Write("Hit enter to do the deed");
            Console.ReadLine();
            using var channel = GrpcChannel.ForAddress("https://localhost:5001"); 
            var client = new Greeter.GreeterClient(channel);

            var reply = await client.SayHelloAsync(new HelloRequest { Name = "Putintane" });

            Console.WriteLine($"Got the response {reply.Message}");

            Console.WriteLine($"Got the response {reply.Message}");

            Console.WriteLine("Planning your route ...");

            var clientRouting = new DrivingRouter.DrivingRouterClient(channel);
            var request = new RouteRequest { Street = "555 Mockingbird Ct.", City = "Des Moines", Zip = "23892" };
            var replyRoute = await clientRouting.PlanRouteAsync(request);

            Console.WriteLine("Arriving at " + replyRoute.ArrivalTime);
            Console.WriteLine("Miles: " + replyRoute.Miles);
            foreach(var step in replyRoute.Steps)
            {
                Console.WriteLine($"\t{step}");
            }
        }
    }
}
