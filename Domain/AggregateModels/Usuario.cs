using Microsoft.AspNetCore.Identity;

namespace Domain.AggregateModels
{
    public class Usuario : IdentityUser<long>
    {
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public bool Ativo { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public virtual ICollection<Perfil> UserRoles { get; private set; }
        public IEnumerable<EquipeUsuario> Equipes { get; private set; }
        public Equipe EquipeGerenciada { get; private set; }

        public Usuario()
        {
            UserRoles = new List<Perfil>();
            Ativo = true;
        }

        public Usuario(long id)
        {
            Id = id;
        }

        public Usuario(string nome, string sobrenome, string email, DateTime dataNascimento) : base()
        {
            UserName = $"{nome}.{sobrenome}";
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
            DataNascimento = dataNascimento;
            Ativo = true;
        }

        public Usuario(long id, string email) : base()
        {
            Id = id;
            Email = email;
        }

        //public Usuario(long id, string perfil)
        //{
        //    Id = id;
        //    UserRoles = new List<Perfil>() { new Perfil(perfil) };
        //}

        public void AdicionarEquipeGerenciada(Equipe equipe) => EquipeGerenciada = equipe;

    }
}
