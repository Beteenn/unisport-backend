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
        public long OrganizadorId { get; private set; }
        public Usuario Organizador { get; private set; }
        public Inscricao Inscricao { get; private set; }

        public Campeonato() { }

        public Campeonato(string nome, int tipoId, int modalidadeId, DateTime dataInicio, DateTime dataFim,
            long organizadorId, DateTime dataInicioInscricao, DateTime dataFimInscricao)
        {
            Nome = nome;
            TipoCampeonatoId = tipoId;
            ModalidadeCampeonatoId = modalidadeId;
            DataInicio = dataInicio;
            DataFim = dataFim;
            OrganizadorId = organizadorId;
            AdicionarStatusNovoCampeonato(dataInicioInscricao);
            Inscricao = new Inscricao(dataInicioInscricao, dataFimInscricao);
        }

        private void AdicionarStatusNovoCampeonato(DateTime dataInicioInscricao)
        {
            if (DateTime.Now.Date >= dataInicioInscricao.Date)
            {
                StatusCampeonatoId = 2;
                return;
            }

            StatusCampeonatoId = 1;
        }

        public void AdicionarEquipe(long equipeId)
        {
            Inscricao.AdicionarEquipe(equipeId);
        }
    }
}
