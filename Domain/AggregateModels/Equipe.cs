namespace Domain.AggregateModels
{
    public class Equipe
    {
        public long Id { get; private set; }
        public string Nome { get; private set; }
        public ICollection<EquipeUsuario> Jogadores { get; private set; }
        public Usuario Gerente { get; private set; }
        public long GerenteId{ get; private set; }

        public Equipe()
        {
            Jogadores = new List<EquipeUsuario>();
        }

        public Equipe(long gerenteId, string nome)
        {
            Nome = nome;
            GerenteId = gerenteId;
            Jogadores = new List<EquipeUsuario>();
        }

        public void AdicionarJogadores(IEnumerable<long> jogadores)
        {
            Jogadores = jogadores.Select(x => new EquipeUsuario(x)).ToList();
        }

    }
}
