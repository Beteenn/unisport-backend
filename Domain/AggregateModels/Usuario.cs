using Microsoft.AspNetCore.Identity;

namespace Domain.AggregateModels
{
    public class Usuario : IdentityUser<long>
	{
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public bool Ativo { get; private set; }
        public long FaculdadeId { get; private set; }
        public Faculdade Faculdade { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public virtual ICollection<Perfil> UserRoles { get; private set; }

        public Usuario()
        {
            UserRoles = new List<Perfil>();
            Ativo = true;
        }

        public Usuario(string nome, string sobrenome, string email, long faculdadeId, DateTime dataNascimento) : base()
        {
            UserName = $"{nome}.{sobrenome}";
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
            FaculdadeId = faculdadeId;
            DataNascimento = dataNascimento;
        }

        public Usuario(long id, string email, long faculdadeId) : base()
        {
            Id = id;
            Email = email;
            FaculdadeId = faculdadeId;
        }

        public Usuario(long id, string perfil)
        {
            Id = id;
            UserRoles = new List<Perfil>() { new Perfil(perfil) };
        }
    }
}
