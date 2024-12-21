﻿namespace Ordering.Domain.Models
{
    public class Customer: Entity<CustomerId>
    {
        public static Customer Create(CustomerId id, string name, string email)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(name);
            ArgumentException.ThrowIfNullOrWhiteSpace(email);
            var customer = new Customer()
            {
                Id = id,
                Name = name,
                Email = email
            };
            return customer;
        }
        public string Name { get; private set; } = default!;   
        public string Email { get; private set; } = default!;
    }
}
