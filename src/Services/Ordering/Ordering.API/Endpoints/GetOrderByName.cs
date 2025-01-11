
using Ordering.Application.Orders.Queries.GetOrderByName;

namespace Ordering.API.Endpoints
{
    public record GetOrerByNameResponse(IEnumerable<OrderDto> Orders);
    public class GetOrderByName : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/orders/{orderName}", async(string orderName, ISender sender) =>
            {
                var res = await sender.Send(new GetOrderByNameQuery(orderName));
                var response = res.Adapt<GetOrerByNameResponse>();
                return Results.Ok(response);
            })
            .WithName("GetOrerByNameResponse")
            .Produces<CreateOrderResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("GetOrerByNameResponse")
            .WithDescription("GetOrerByNameResponse");
        }
    }
}
