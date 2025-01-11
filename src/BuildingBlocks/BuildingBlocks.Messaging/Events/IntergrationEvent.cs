namespace BuildingBlocks.Messaging.Events
{
    public class IntergrationEvent
    {
        public Guid Id => Guid.NewGuid();
        public DateTime OrcurredOn { get; set; }
        public string EventType => GetType().AssemblyQualifiedName;

    }
}
