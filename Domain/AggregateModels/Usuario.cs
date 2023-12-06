using Microsoft.AspNetCore.Identity;

namespace Domain.AggregateModels
{
    public class Usuario : IdentityUser<long>
    {
        public bool Ativo { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public virtual ICollection<Perfil> UserRoles { get; private set; }
        public IEnumerable<EquipeUsuario> Equipes { get; private set; }
        public ICollection<Equipe> EquipesGerenciadas { get; private set; } = new List<Equipe>();
        public bool Admin { get; private set; }

        public Usuario()
        {
            UserRoles = new List<Perfil>();
            Ativo = true;
        }

        public Usuario(long id)
        {
            Id = id;
        }

        public Usuario(string email, DateTime dataNascimento, bool admin) : base()
        {
            UserName = email;
            Email = email;
            DataNascimento = dataNascimento;
            Ativo = true;
            Admin = admin;
        }

        public Usuario(long id, string email, bool admin) : base()
        {
            Id = id;
            Email = email;
            Admin = admin;
        }

        //public Usuario(long id, string perfil)
        //{
        //    Id = id;
        //    UserRoles = new List<Perfil>() { new Perfil(perfil) };
        //}

        public void AdicionarEquipeGerenciada(Equipe equipe) => EquipesGerenciadas.Add(equipe);

    }
}
