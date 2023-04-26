using Application.Configuration.Identity.Interfaces;

namespace WebAPI.Middleware
{
    public class AuthMiddleware : IAuthMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await AuthenticateAsync(context);
            await next.Invoke(context);
        }

        private static async Task AuthenticateAsync(HttpContext context)
        {
            await Task.Run(() =>
            {
                var httpContext = context as DefaultHttpContext;

                try
                {
                    if (!context.Request.Headers.ContainsKey("Authorization"))
                        throw new UnauthorizedAccessException();

                    var token = context.Request.Headers["Authorization"][0];

                    if (!string.IsNullOrEmpty(token))
                    {
                        var tokenService = httpContext.RequestServices.GetService<ITokenService>();
                        var jwtTokenResult = tokenService.ObterConteudoTokenJWT(token).Result;
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    //httpContext.Response.Clear();
                    //httpContext.Response.ContentType = "application/json";
                    //httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    //httpContext.Response.WriteAsync("Unauthorized");
                }
                catch (Exception)
                {

                }
            });
        }
    }
}
