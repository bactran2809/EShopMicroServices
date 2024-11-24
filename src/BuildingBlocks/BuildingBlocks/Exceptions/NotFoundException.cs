namespace BuildingBlocks.Exceptions
{
    public class NotFoundException: Exception
    {
        public NotFoundException(string message, string name) : base($"{message} {name} NOT FOUND")
        { }
    }
}
