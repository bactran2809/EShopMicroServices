namespace Ordering.Application.Orders.EventHandles
{
    public class OrderUpdatedEventHandler(ILogger<OrderUpdatedEventHandler> logger)
        : INotificationHandler<OrderUpdatedEvent>
    {
        public Task Handle(OrderUpdatedEvent notification, CancellationToken cancellationToken)
        {
            logger.LogInformation("OrderUpdatedEventHandler {domainEvent}", notification.GetType().Name);
            return Task.CompletedTask;
        }
    }
}
