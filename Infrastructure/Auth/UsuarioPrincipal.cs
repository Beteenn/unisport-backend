using System.Security.Principal;

namespace Infrastructure.Auth
{
    public class UsuarioPrincipal : IUsuarioPrincipal
    {
        public long Id { get; private set; }

        public string Email { get; private set; }

        public long FaculdadeId { get; private set;}

        public bool TokenValido { get; private set;}

        public ICollection<string> Roles { get; private set; }

        public IIdentity? Identity { get; private set;}

        public bool IsInRole(string role)
        {
            throw new NotImplementedException();
        }

        public void SetAuthenticated(IIdentity identity) => Identity = identity;

        public void SetAuthenticated(string name, string type) => SetAuthenticated(new GenericIdentity(name, type));

        public void SetId(long id) => Id = id;

        public void SetEmail(string email) => Email = email;

        public void SetFaculdadeId(long faculdadeId) => FaculdadeId = faculdadeId;

        public void SetStatusTokenInvalido(bool status) => TokenValido = status;

        public void AddRole(string role)
        {
            if (string.IsNullOrEmpty(role)) return;

            if (!Roles.Any(x => x == role))
                Roles.Add(role);
        }
    }
}
