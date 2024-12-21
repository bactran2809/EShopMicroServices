namespace Ordering.Domain.Exceptions
{
    public class DomainException: Exception
    {
        public DomainException(string mess): base($"Domain exception : \"{mess}\" throw from Domain Layer")
        { }
    }
}
