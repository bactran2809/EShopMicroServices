using MassTransit;
using Microsoft.FeatureManagement;
using Ordering.Application.Extensions;

namespace Ordering.Application.Orders.EventHandles.Domain
{
    public class OrderCreatedEventHandler(IPublishEndpoint publishEndpoint, IFeatureManager featureManager, ILogger<OrderCreatedEventHandler> logger)
        : INotificationHandler<OrderCreatedEvent>
    {
        public async Task Handle(OrderCreatedEvent domainEvent, CancellationToken cancellationToken)
        {

            logger.LogInformation("OrderCreatedEventHandler {domainEvent}", domainEvent.GetType().Name);
            if (await featureManager.IsEnabledAsync("OrderFullfillment"))
            {
                var orderCreatedIntergrationEvent = domainEvent.order.ToOrderDto();
                await publishEndpoint.Publish(orderCreatedIntergrationEvent, cancellationToken);
            }


        }
    }
}
