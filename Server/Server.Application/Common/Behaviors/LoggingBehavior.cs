using MediatR;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.Common.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse>
        : IPipelineBehavior <TRequest, TResponse> where TRequest
        : IRequest<TResponse>
    {
        public async Task<TResponse> Handle(TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            var RequestName = typeof(TRequest).Name;

            Log.Information("Request: {Name} {@Request}",
                RequestName, request);

            var response = await next();
            return response;
        }
    }
}
