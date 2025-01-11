using Ordering.Application.Orders.Commands.DeleteOrder;
namespace Ordering.API.Endpoints
{
    public record DeleteOrderResponse(bool IsSuccess);
    public class DeleteOrder : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/orders/{id}", async (Guid id, ISender sender) =>
            {
                var command = new DeleteOrderCommand(id);
                var res = await sender.Send(command);
                var response = res.Adapt<DeleteOrderResponse>();
                return Results.Ok(response);
            })
            .WithName("Delete Order")
            .Produces<DeleteOrderResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Delete Order")
            .WithDescription("Delete Order");
        }
    }
}
