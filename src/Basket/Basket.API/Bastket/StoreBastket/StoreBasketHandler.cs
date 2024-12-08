
using FluentValidation;

namespace Basket.API.Bastket.StoreBastket
{
    public record StoreBastketCommand(ShoppingCart Cart) : ICommand<StoreBasketResult>;
    public record StoreBasketResult(string UserName);
    public class StoreBasketCommandValidator : AbstractValidator<StoreBastketCommand>
    {
        public StoreBasketCommandValidator()
        {
            RuleFor(x => x.Cart).NotNull().WithMessage("Cart is requied");
            RuleFor(x => x.Cart.UserName).NotEmpty().WithMessage("UserName is requied");
        }
    }
    public class StoreBasketHandler(IBastketRepository repository) : ICommandHanler<StoreBastketCommand, StoreBasketResult>
    {
        public async  Task<StoreBasketResult> Handle(StoreBastketCommand request, CancellationToken cancellationToken)
        {
            ShoppingCart cart = request.Cart;
            await repository.StoreBastket(cart, cancellationToken);
            return new StoreBasketResult(cart.UserName);
        }
    }
}
