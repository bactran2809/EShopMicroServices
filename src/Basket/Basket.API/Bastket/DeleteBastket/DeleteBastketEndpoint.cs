
namespace Basket.API.Bastket.DeleteBastket
{
    public record DeleteBastketEndpointRequest(string UserName);
    public record DeleteBastketEndpointResponse(bool IsSuccess);
    public class DeleteBastketEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/bastket/{UserName}", async (string UserName, ISender sender) =>
            {
                var command = new DeleteBastketCommand(UserName);
                var res = await sender.Send(command);
                var response = res.Adapt<DeleteBastketEndpointResponse>();

                return Results.Ok(response);
            }).WithName("DeleteBastket")
            .Produces<DeleteBastketEndpointResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Delete Bastket")
            .WithDescription("Delete Bastket");
        }
    }
}
