namespace Domain.AggregateModels.CampeonatoModels
{
    public class EquipeCampeonato
    {
        public long Id { get; private set; }
        public long CampeonatoId { get; private set; }
        public Campeonato Campeonato { get; private set; }
        public long EquipeId { get; private set; }
        public Equipe Equipe { get; private set; }

        public EquipeCampeonato() { }

        public EquipeCampeonato(long equipeId)
        {
            EquipeId = equipeId;
        }
    }
}
