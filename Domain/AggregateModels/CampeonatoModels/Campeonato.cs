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
        public List<Partida> Partidas { get; private set; }
        public int QuantidadeRodadas { get; private set; }

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

        public void Atualizar(string nome, int modalidadeId, int tipoId, DateTime dataInicio, DateTime dataFim,
            DateTime dataInicioInscricao, DateTime dataFimInscricao)
        {
            Nome = nome;
            ModalidadeCampeonatoId = modalidadeId;
            TipoCampeonatoId = tipoId;
            DataInicio = dataInicio;
            DataFim = dataFim;
            Inscricao.Atualizar(dataInicioInscricao, dataFimInscricao);
        }

        public void GerarPartidas()
        {
            StatusCampeonatoId = 2;

            QuantidadeRodadas = (int)(Math.Log(Inscricao.Equipes.Count) / Math.Log(2));

            var random = new Random();
            var equipesEmbaralhadas = Inscricao.Equipes.OrderBy(e => random.Next()).Select(x => x.Equipe).ToList();
            
            GerarPartidasIniciais(equipesEmbaralhadas);
            GerarDemaisRodadas();
        }

        private void GerarDemaisRodadas()
        {
            var rodadas = QuantidadeRodadas;
            var equipesRodada = Inscricao.Equipes.Count / 2;

            for (int i = 2; i <= rodadas; i++)
            {
                var quantidadePartidas = equipesRodada / 2;

                for (int j = 0; j < quantidadePartidas; j++)
                {
                    var novaPartida = new Partida(i);

                    Partidas[j].AdicionarProximaPartida(novaPartida);
                    Partidas[j + 1].AdicionarProximaPartida(novaPartida);
                    Partidas.Add(novaPartida);
                }

                equipesRodada /= 2;
            }
        }

        private void GerarPartidasIniciais(List<Equipe> equipesEmbaralhadas)
        {
            for (int i = 0; i <= equipesEmbaralhadas.Count - 2; i += 2)
            {
                var novaPartida = new Partida(equipesEmbaralhadas[i].Id, equipesEmbaralhadas[i + 1].Id);
                Partidas.Add(novaPartida);
            }
        }

        public void VincularProximasPartidas()
        {
            for (int rodada = 2; rodada <= QuantidadeRodadas; rodada++)
            {
                var partidasRodada = Partidas.Where(x => x.Rodada == rodada).ToList();
                var quantidadePartidasRodada = partidasRodada.Count();

                for (int j = 0; j < quantidadePartidasRodada; j++)
                {
                    Partidas[j].AdicionarProximaPartida(partidasRodada[j].Id);
                    Partidas[j + 1].AdicionarProximaPartida(partidasRodada[j].Id);
                }
            }
        }

        private DateTime CalcularProximoHorario(int numeroPartida)
        {
            var horarioInicial = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 10, 0, 0);
            var horarioPausa = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 13, 0, 0);
            int duracaoPartidaEmHoras = 1;
            int duracaoPausaEmHoras = 1;
            int horarioMaximo = 18;

            var horarioPartida = horarioInicial.AddHours(numeroPartida * duracaoPartidaEmHoras);

            if (horarioPartida == horarioPausa)
            {
                horarioPartida = horarioPartida.AddHours(duracaoPausaEmHoras);
            }

            if (horarioPartida.Hour > horarioMaximo)
            {
                horarioPartida = horarioPartida.AddDays(1).Date.AddHours(10);
            }

            return horarioPartida;
        }
    }
}
