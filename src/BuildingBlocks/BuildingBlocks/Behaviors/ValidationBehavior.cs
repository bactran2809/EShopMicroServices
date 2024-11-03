using BuildingBlocks.CQRS;
using FluentValidation;
using MediatR;

namespace BuildingBlocks.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators) 
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : ICommand<TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);
            var validationResults = await Task.WhenAll(validators.Select(s => s.ValidateAsync(context, cancellationToken)));

            var errors = validationResults.Where(w => !w.IsValid).SelectMany(s => s.Errors).ToList();
            if (errors.Count != 0)           
                throw new ValidationException(errors);          
            return await next();
        }
    }
}
