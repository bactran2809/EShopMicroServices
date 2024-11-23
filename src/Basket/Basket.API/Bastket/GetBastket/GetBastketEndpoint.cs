namespace Basket.API.Bastket.GetBastket
{
    public record GetBastketResponse(ShoppingCart Cart);
    public class GetBastketEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/basket/{userName}", async (string userName, ISender sender) =>
            {
                var result = await sender.Send(new GetBastketQuery(userName));
                var res = result.Adapt<GetBastketResponse>();
                return Results.Ok(res);
            });
        }
    }
}
