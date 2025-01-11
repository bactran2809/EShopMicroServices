using Ordering.Domain.Models;
using System.Security;

namespace Ordering.Application.Extensions
{
    public static class OrderExtensions
    {
        public static IEnumerable<OrderDto> ToListOrderDto(this IEnumerable<Order> orders) {

            return orders.Select(order => new OrderDto(
                        Id: order.Id.Value,
                                    CustomerId: order.CustomerId.Value,
                                    OrderName: order.OrderName.Value,
                                    ShippingAddress: new AddressDto(
                                            order.ShippingAddress.FirstName,
                                            order.ShippingAddress.LastName,
                                            order.ShippingAddress.Email,
                                            order.ShippingAddress.AddressLine,
                                            order.ShippingAddress.Country,
                                            order.ShippingAddress.State,
                                            order.ShippingAddress.ZipCode
                                    ),
                                    BillingAddress: new AddressDto(
                                            order.BillingAddress.FirstName,
                                            order.BillingAddress.LastName,
                                            order.BillingAddress.Email,
                                            order.BillingAddress.AddressLine,
                                            order.BillingAddress.Country,
                                            order.BillingAddress.State,
                                            order.BillingAddress.ZipCode
                                    ),
                                    Payment: new PaymentDto(
                                            order.Payment.CardName,
                                            order.Payment.CardNumber,
                                            order.Payment.Expiration,
                        order.Payment.CVV,
                                            order.Payment.PaymentMethod
                                    ),
                        Status: order.Status,
                        OrderItems: order.OrderItems.Select(o => new OrderItemDto(o.OrderId.Value, o.ProductId.Value, o.Quantity, o.Price)).ToList()
            ));
        
        }

        public static OrderDto ToOrderDto(this Order order)
        {
            return DtoFromOrder(order);
        }

        private static OrderDto DtoFromOrder(Order order)
        {
            return new OrderDto(
                     Id: order.Id.Value,
                                    CustomerId: order.CustomerId.Value,
                                    OrderName: order.OrderName.Value,
                                    ShippingAddress: new AddressDto(
                                            order.ShippingAddress.FirstName,
                                            order.ShippingAddress.LastName,
                                            order.ShippingAddress.Email,
                                            order.ShippingAddress.AddressLine,
                                            order.ShippingAddress.Country,
                                            order.ShippingAddress.State,
                                            order.ShippingAddress.ZipCode
                                    ),
                                    BillingAddress: new AddressDto(
                                            order.BillingAddress.FirstName,
                                            order.BillingAddress.LastName,
                                            order.BillingAddress.Email,
                                            order.BillingAddress.AddressLine,
                                            order.BillingAddress.Country,
                                            order.BillingAddress.State,
                                            order.BillingAddress.ZipCode
                                    ),
                                    Payment: new PaymentDto(
                                            order.Payment.CardName,
                                            order.Payment.CardNumber,
                                            order.Payment.Expiration,
                        order.Payment.CVV,
                                            order.Payment.PaymentMethod
                                    ),
                        Status: order.Status,
                        OrderItems: order.OrderItems.Select(o => new OrderItemDto(o.OrderId.Value, o.ProductId.Value, o.Quantity, o.Price)).ToList()
                );
        }
    }
}
