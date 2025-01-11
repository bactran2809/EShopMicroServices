
using BuildingBlocks.Messaging.Events;
using FluentValidation;
using MassTransit;

namespace Basket.API.Bastket.CheckoutBastket
{
    public record CheckoutBasketCommand(BasketCheckoutDto BasketCheckoutDto): ICommand<CheckoutBasketResult>;
    public record CheckoutBasketResult(bool IsSuccess);

    public class CheckoutBasketCommandValidator: AbstractValidator<CheckoutBasketCommand>
    {
        public CheckoutBasketCommandValidator()
        {
            RuleFor(x => x.BasketCheckoutDto).NotNull().WithMessage("BasketCheckoutDto is not null");
            RuleFor(x => x.BasketCheckoutDto.UserName).NotEmpty().WithMessage("UserName is not null");
        }
    }
    public class CheckoutBasketCommandHandler(IBastketRepository repository, IPublishEndpoint publishEndpoint)
        : ICommandHanler<CheckoutBasketCommand, CheckoutBasketResult>
    {
        public async Task<CheckoutBasketResult> Handle(CheckoutBasketCommand command, CancellationToken cancellationToken)
        {
            var basket = await repository.GetBastket(command.BasketCheckoutDto.UserName, cancellationToken);
            if(basket == null)
            {
                return new CheckoutBasketResult(false);  
            }

            var eventMessage = command.BasketCheckoutDto.Adapt<BasketCheckoutEvent>();
            eventMessage.TotalPrice = basket.TotalPrice;
            await publishEndpoint.Publish(basket, cancellationToken);
            await repository.DeleteBastket(command.BasketCheckoutDto.UserName, cancellationToken);

            return new CheckoutBasketResult(true);
        }
    }
}
