using Microsoft.AspNetCore.Builder;

namespace Passenger.Api.Framework
{
    public static class Extensions
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
            => builder.UseMiddleware(typeof(ExceptionHandlerMiddleware));
            
    }
}