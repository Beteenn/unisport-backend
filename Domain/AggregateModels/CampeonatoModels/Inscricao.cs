namespace Domain.AggregateModels.CampeonatoModels
{
    public class Inscricao
    {
        public long Id { get; private set; }
        public long? CampeonatoId { get; private set; }
        public Campeonato Campeonato { get; private set; }
        public DateTime DataInicio { get; private set; }
        public DateTime DataFim { get; private set; }
        public ICollection<EquipeInscricao> Equipes { get; private set; }

        public Inscricao() { Equipes = new List<EquipeInscricao>(); }

        public Inscricao(DateTime dataInicio, DateTime dataFim)
        {
            DataInicio = dataInicio;
            DataFim = dataFim;
        }

        public void AdicionarEquipe(long equipeId)
        {
            Equipes.Add(new EquipeInscricao(equipeId));
        }
    }
}
