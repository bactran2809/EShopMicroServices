using BuildingBlocks.Messaging.Events;
using MassTransit;

namespace Ordering.Application.Orders.EventHandles.Intergration
{
    public class BasketCheckoutEventHandler (ISender sender, ILogger<BasketCheckoutEventHandler> logger)
        : IConsumer<BasketCheckoutEvent>
    {
        public Task Consume(ConsumeContext<BasketCheckoutEvent> context)
        {
            logger.LogInformation("Intergration Event Handled {event}", context.Message.GetType().Name);
            throw new NotImplementedException();
        }
    }
}
