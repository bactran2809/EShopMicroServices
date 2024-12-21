using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordering.Domain.Models;
using Ordering.Domain.ValueObjects;

namespace Ordering.Infrastructure.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasConversion(
                 orderId => orderId.Value,
                 dbId => OrderId.Of(dbId));

            builder.HasOne<Customer>()
                .WithMany()
                .HasForeignKey(x => x.CustomerId)
                .IsRequired();

            builder.HasMany(o => o.OrderItems)
                .WithOne()
                .HasForeignKey(oi => oi.OrderId);

            builder.ComplexProperty(o =>
                o.OrderName, nameBuilder =>
                {
                    nameBuilder.Property(n => n.Value)
                        .HasColumnName(nameof(Order.OrderName))
                        .HasMaxLength(100)
                        .IsRequired();
                }

            );

            builder.ComplexProperty(o =>
                o.ShippingAddress, addressBuilder =>
                {
                    addressBuilder.Property(a => a.FirstName).HasMaxLength(100).IsRequired();
                    addressBuilder.Property(a => a.LastName).HasMaxLength(100).IsRequired();
                    addressBuilder.Property(a => a.Email).HasMaxLength(100);
                    addressBuilder.Property(a => a.AddressLine).HasMaxLength(200);
                    addressBuilder.Property(a => a.Country).HasMaxLength(100);
                    addressBuilder.Property(a => a.State).HasMaxLength(100);
                    addressBuilder.Property(a => a.ZipCode).HasMaxLength(5).IsRequired();
                });

            builder.ComplexProperty(o =>
                  o.BillingAddress, addressBuilder =>
                  {
                      addressBuilder.Property(a => a.FirstName).HasMaxLength(100).IsRequired();
                      addressBuilder.Property(a => a.LastName).HasMaxLength(100).IsRequired();
                      addressBuilder.Property(a => a.Email).HasMaxLength(100);
                      addressBuilder.Property(a => a.AddressLine).HasMaxLength(200);
                      addressBuilder.Property(a => a.Country).HasMaxLength(100);
                      addressBuilder.Property(a => a.State).HasMaxLength(100);
                      addressBuilder.Property(a => a.ZipCode).HasMaxLength(5).IsRequired();
                  });

            builder.ComplexProperty(o =>
                 o.Payment, paymentBuilder =>
                 {
                     paymentBuilder.Property(a => a.CardName).HasMaxLength(100);
                     paymentBuilder.Property(a => a.CardNumber).HasMaxLength(24).IsRequired();
                     paymentBuilder.Property(a => a.Expiration).HasMaxLength(10);
                     paymentBuilder.Property(a => a.CVV).HasMaxLength(3);
                     paymentBuilder.Property(a => a.PaymentMethod);
                  
                 });

            builder.Property(o => o.Status)
                .HasDefaultValue(OrderStatus.Draft)
                .HasConversion(
                    s => s.ToString(),
                    dbStatus => (OrderStatus)Enum.Parse(typeof(OrderStatus), dbStatus)
                );

            builder.Property(o => o.TotalPrice);
        }
    }
}
