using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.ExceptionHandling;

namespace Drunk.Unicorn.RussPass.General.Middleware
{
    public class ExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<ExceptionHandler> logger;
        public ExceptionHandler(ILogger<ExceptionHandler> logger)
        {
            this.logger = logger;
        }
        public Task HandleAsync(ExceptionHandlerContext context, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {
            var exceptionMessage = exception.Message;
            logger.LogError(
                "Произошла ошибка: {exceptionMessage}, в {time}",
                exceptionMessage, DateTime.UtcNow);
            return ValueTask.FromResult(false);
        }
    }
}
