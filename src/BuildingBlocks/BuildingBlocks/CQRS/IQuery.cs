using MediatR;

namespace BuildingBlocks.CQRS;

public interface IQuery<out TReseponse> : IRequest<TReseponse>  where TReseponse : notnull 
{
}
