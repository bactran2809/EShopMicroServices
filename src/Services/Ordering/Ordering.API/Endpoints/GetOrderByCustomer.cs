
using Ordering.Application.Orders.Queries.GetOrdersByCustomer;

namespace Ordering.API.Endpoints
{
    public record GetOrderByCustomerResponse(IEnumerable<OrderDto> OrderDtos);
    public class GetOrderByCustomer : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/orders/customer/{customerId}", async (Guid cutomerId, ISender sender) =>
            {
                var result = await sender.Send(new GetOrdersByCustomerQuery(cutomerId));
                var response = result.Adapt<GetOrderByCustomerResponse>();
                return Results.Ok(response);
            })
            .WithName("GetOrderByCustomer")
            .Produces<CreateOrderResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("GetOrderByCustomer")
            .WithDescription("GetOrderByCustomer");
        }
    }
}
