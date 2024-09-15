using System.Diagnostics;

namespace TaskManager.API.Middleware
{
    public class StopWatchTrackingMiddleware : IMiddleware
    {
        private ILogger<StopWatchTrackingMiddleware> _logger;

        public StopWatchTrackingMiddleware(ILogger<StopWatchTrackingMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var requestPath = context.Request.Path;

            Stopwatch stopwatch = Stopwatch.StartNew();

            try
            {
                await next(context);
            }
            finally
            {
                stopwatch.Stop();
                _logger.LogInformation($"Request {requestPath} took {stopwatch.ElapsedMilliseconds}ms");
            }
        }
    }
}
