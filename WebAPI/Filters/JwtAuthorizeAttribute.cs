using Infrastructure.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebAPI.Filters
{
    public class JwtAuthorizeAttribute : ActionFilterAttribute, IAsyncAuthorizationFilter
    {
        public string[] Claims { get; set; }
        public string[] Roles { get; set; }

        private IUsuarioPrincipal UsuarioLogado;

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            if (context.IsAnonymousAllowed()) { return; }

            UsuarioLogado = context.HttpContext.RequestServices.GetRequiredService<IUsuarioPrincipal>();

            if (!UsuarioLogado.TokenValido)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            return;
        }
    }
}
