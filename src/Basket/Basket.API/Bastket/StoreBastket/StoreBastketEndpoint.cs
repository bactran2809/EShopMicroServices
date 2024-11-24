
using Basket.API.Bastket.GetBastket;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Basket.API.Bastket.StoreBastket
{
    public record StoreBastketRequest(ShoppingCart Cart);
    public record StoreBastketResult(string  UserName);

    public class StoreBasketCommandValidator : AbstractValidator<StoreBastketRequest>
    {
        public StoreBasketCommandValidator()
        {
            RuleFor(x => x.Cart).NotNull().WithMessage("Cart is requied");
            RuleFor(x => x.Cart.UserName).NotEmpty().WithMessage("UserName is requied");
        }
    }
    public class StoreBastketEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/basket", async (StoreBastketRequest request, ISender sender) =>
            {
                var command = request.Adapt<StoreBastketCommand>(); 
                var res = await sender.Send(command);
                var result = res.Adapt<StoreBastketResult>();
                return Results.Created($"/bastket/{result.UserName}",result);  
            })
            .WithName("StoreBastket")
            .Produces<GetBastketResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Store Bastket")
            .WithDescription("Store Bastket");
        }
    }
}
