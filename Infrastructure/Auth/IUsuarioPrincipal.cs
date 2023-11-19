using System.Security.Principal;

namespace Infrastructure.Auth
{
    public interface IUsuarioPrincipal : IPrincipal
    {
        long Id { get; }
        string Email { get; }
        bool TokenValido { get; }
        ICollection<string> Roles { get; }

        void AddRole(string role);
        void SetAuthenticated(IIdentity identity);
        void SetAuthenticated(string name, string type);
        void SetId(long id);
        void SetEmail(string email);
        void SetStatusTokenInvalido(bool status);
    }
}
