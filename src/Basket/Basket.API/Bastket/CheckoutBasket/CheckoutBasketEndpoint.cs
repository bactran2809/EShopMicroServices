using Basket.API.Bastket.GetBastket;

namespace Basket.API.Bastket.CheckoutBastket
{
    public record CheckoutBasketRequest(BasketCheckoutDto BasketCheckoutDto);
    public record CheckoutBasketResponse(bool IsSuccess);
    public class CheckoutBasketEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/bastket/checkout", async (CheckoutBasketRequest request, ISender sender) =>
            {
                var command = request.Adapt<CheckoutBasketCommand>();
                var res = await sender.Send(command);
                var result = res.Adapt<CheckoutBasketResponse>();
                return Results.Ok(result);
            })
            .WithName("CheckoutBastket")
            .Produces<CheckoutBasketResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Checkout Bastket")
            .WithDescription("Checkout Bastket");
        }
    }
}
