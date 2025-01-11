using BuildingBlocks.Pagination;
using Ordering.Application.Orders.Queries.GetOrders;

namespace Ordering.API.Endpoints
{
    public record GetOrderResponse(PaginatedResult<OrderDto> Orders);
    public class GetOrders : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/orders", async([AsParameters] PaginationRequest request, ISender sender) =>
            {
                var res = await sender.Send(new GetOrderQuery(request));
                var response = res.Adapt<GetOrderResponse>();
                return Results.Ok(response);
            }).WithName("GetOrders")
            .Produces<CreateOrderResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("GetOrders")
            .WithDescription("GetOrders");
        }
    }
}
