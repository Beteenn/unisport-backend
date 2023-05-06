namespace Domain.AggregateModels.CampeonatoModels
{
    public class Campeonato
    {
        public long Id { get; private set; }
        public string Nome { get; private set; }
        public int? TipoCampeonatoId { get; private set; }
        public TipoCampeonato TipoCampeonato { get; private set; }
        public int? StatusCampeonatoId { get; private set; }
        public StatusCampeonato StatusCampeonato { get; private set; }
        public int? ModalidadeCampeonatoId { get; private set; }
        public ModalidadeCampeonato ModalidadeCampeonato { get; private set; }
        public DateTime DataInicio { get; private set; }
        public DateTime DataFim { get; private set; }

        public Campeonato() { }

    }
}
