﻿using BuildingBlocks.CQRS;
using FluentValidation;
using Ordering.Application.Dtos;

namespace Ordering.Application.Orders.Commands.UpdateOrder
{
    public record UpdateOrderCommand(OrderDto Order): ICommand<UpdateOrderResult>;
    public record UpdateOrderResult(bool IsSuccess);

    public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
    {
        public UpdateOrderCommandValidator()
        {
            RuleFor(x => x.Order.Id).NotNull().WithMessage("OrderId is not null");
            RuleFor(x => x.Order.CustomerId).NotEmpty().WithMessage("CustomerId is not null");
            RuleFor(x => x.Order.OrderName).NotEmpty().WithMessage("OrderName is not null");

        }
    }

}