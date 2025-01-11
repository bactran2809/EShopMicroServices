﻿
using Ordering.Application.Orders.Commands.UpdateOrder;

namespace Ordering.API.Endpoints
{
    public record UpdateOrderRequest(OrderDto Order);
    public record UpdateOrderResponse(bool IsSuccess);
    public class UpdateOrder : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/orders", async (UpdateOrderRequest request, ISender sender) =>
            {
                var command = request.Adapt<UpdateOrderCommand>();
                var res = await sender.Send(command);
                var response = res.Adapt<UpdateOrderResponse>();

                return Results.Ok(response);
            });
        }
    }
}
