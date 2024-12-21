namespace Ordering.Domain.ValueObjects
{
    public record Address
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string AddressLine { get; set; } = default!;
        public string Country { get; set; } = default!;
        public string State { get; set; } = default!;
        public string ZipCode { get; set; } = default!;

        protected Address()
        {

        }
        private Address(string fistName, string lastName, string email, string addressLine, string country, string state, string zipCode)
        {
            FirstName = fistName;
            LastName = lastName;
            Email = email;
            AddressLine = addressLine;
            Country = country;
            State = state;
            ZipCode = zipCode;
        }

        public static Address Of(string fistName, string lastName, string emailAddress, string addressLine, string country, string state, string zipCode)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(addressLine);
            ArgumentException.ThrowIfNullOrWhiteSpace(emailAddress);
            return new Address(fistName, lastName, emailAddress, addressLine, country, state, zipCode);
        }
    }
}
