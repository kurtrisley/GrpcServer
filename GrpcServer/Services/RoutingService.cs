using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using System;
using System.Threading.Tasks;

namespace GrpcServer.Services
{
    public class RoutingService : DrivingRouter.DrivingRouterBase
    {
        public override async Task<RouteResponse> PlanRoute(RouteRequest request, ServerCallContext context)
        {
            var response = new RouteResponse();
            response.Miles = new Random().Next(15, 200);
            response.Steps.Add("At the end of your driveway, go left");
            response.Steps.Add("Turn right at Darrow");
            response.Steps.Add("Keep going until you get to the Pacific");
            response.Steps.Add("You missed it - " + request.Street);
            var time = Timestamp.FromDateTime(DateTime.Now.AddHours(15));
            response.ArrivalTime = DateTime.Now.AddHours(15).ToString();
            return response;
        }
    }
}
