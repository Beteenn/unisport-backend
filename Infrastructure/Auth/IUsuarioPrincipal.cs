using System.Security.Principal;

namespace Infrastructure.Auth
{
    public interface IUsuarioPrincipal : IPrincipal
    {
        long Id { get; }
        string Email { get; }
        long FaculdadeId { get; }
        bool TokenValido { get; }
        ICollection<string> Roles { get; }

        void AddRole(string role);
        void SetAuthenticated(IIdentity identity);
        void SetAuthenticated(string name, string type);
        void SetId(long id);
        void SetEmail(string email);
        void SetFaculdadeId(long faculdadeId);
        void SetStatusTokenInvalido(bool status);
    }
}
