
namespace Basket.API.Bastket.DeleteBastket
{
    public record DeleteBastketEndpointRequest(string UserName);
    public record DeleteBastketEndpointResponse(bool IsSuccess);
    public class DeleteBastketEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/bastket/{UserName}", async (DeleteBastketEndpointRequest request, ISender sender) =>
            {
                var command = request.Adapt<DeleteBastketCommand>();
                var res = await sender.Send(command);
                var response = res.Adapt<DeleteBastketEndpointResponse>();

                return Results.Ok(response);
            });
        }
    }
}
