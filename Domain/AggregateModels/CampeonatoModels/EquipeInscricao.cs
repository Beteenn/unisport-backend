namespace Domain.AggregateModels.CampeonatoModels
{
    public class EquipeInscricao
    {
        public long Id { get; private set; }
        public long InscricaoId { get; private set; }
        public Inscricao Inscricao { get; private set; }
        public long EquipeId { get; private set; }
        public Equipe Equipe { get; private set; }

        public EquipeInscricao() { }

        public EquipeInscricao(long equipeId)
        {
            EquipeId = equipeId;
        }
    }
}
