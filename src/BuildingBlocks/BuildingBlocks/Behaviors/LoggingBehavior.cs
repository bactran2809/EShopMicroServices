using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace BuildingBlocks.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse> (ILogger<LoggingBehavior<TRequest, TResponse>> logger)
        : IPipelineBehavior<TRequest, TResponse>      
        where TRequest : notnull, IRequest<TResponse>
        where TResponse : notnull
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            logger.LogInformation("[START] Handle Request={Request} -- Response={Response} - request:{request}", typeof(TRequest), typeof(TResponse), request);
            var timer = new Stopwatch();
            timer.Start();
            var response = await next();
            timer.Stop();
            if(timer.Elapsed.TotalSeconds > 3)
            {
                logger.LogWarning("[PERFORMANCE] the request {Request} took {time} seconds", typeof(TRequest).Name, timer.Elapsed.TotalSeconds);
            }
            logger.LogWarning("[END] Handled request {Request} with {response}", typeof(TRequest).Name, response);
            return response;
        }
    }
}
