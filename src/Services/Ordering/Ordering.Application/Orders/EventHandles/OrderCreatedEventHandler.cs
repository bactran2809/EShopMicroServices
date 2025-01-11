﻿namespace Ordering.Application.Orders.EventHandles
{
    public class OrderCreatedEventHandler (ILogger<OrderCreatedEventHandler> logger)
        : INotificationHandler<OrderCreatedEvent>
    {
        public Task Handle(OrderCreatedEvent notification, CancellationToken cancellationToken)
        {

            logger.LogInformation("OrderCreatedEventHandler {domainEvent}", notification.GetType().Name);
            return Task.CompletedTask;
        }
    }
}
