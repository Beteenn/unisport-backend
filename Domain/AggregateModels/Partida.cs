using Domain.AggregateModels.CampeonatoModels;

namespace Domain.AggregateModels
{
    public class Partida
    {
        public long Id { get; private set; }
        public long CampeonatoId { get; private set; }
        public Campeonato Campeonato { get; private set; }

        public Equipe EquipeA { get; private set; }
        public long? EquipeAId { get; private set; }
        public Equipe EquipeB { get; private set; }
        public long? EquipeBId { get; private set; }
        public Equipe EquipeVencedora { get; private set; }
        public long? EquipeVencedoraId { get; private set; }

        public DateTime DataInicio { get; private set; }
        public DateTime DataFim { get; private set; }

        public int Rodada { get; private set; }

        public Partida ProximaPartida { get; private set; }
        public long? ProximaPartidaId { get; private set; }

        public Partida() { }

        public Partida(long equipeAId, long equipeBId)
        {
            EquipeAId = equipeAId;
            EquipeBId = equipeBId;
            Rodada = 1;
        }

        public Partida(int rodada)
        {
            Rodada = rodada;
        }

        public void AdicionarProximaPartida(long partidaId)
        {
            ProximaPartidaId = partidaId;
        }

        internal void AdicionarProximaPartida(Partida novaPartida)
        {
            ProximaPartida = novaPartida;
        }

        public void DefinirVencedor(int equipeId)
        {
            EquipeVencedoraId = equipeId;
            ProximaPartida.DefinirEquipeParticipante(equipeId);
        }

        private void DefinirEquipeParticipante(int equipeId)
        {
            if (EquipeAId == null)
            {
                EquipeAId = equipeId;
            } else if (EquipeBId == null)
            {
                EquipeBId = equipeId;
            }
        }
    }
}
