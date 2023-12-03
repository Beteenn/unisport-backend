namespace Application.ViewModels
{
    public class PartidaViewModel
    {
        public long Id { get; set; }
        public long CampeonatoId { get; set; }
        public EquipeViewModel EquipeA { get;  set; }
        public long? EquipeAId { get; set; }
        public EquipeViewModel EquipeB { get; set; }
        public long? EquipeBId { get; set; }
        public EquipeViewModel EquipeVencedora { get; set; }
        public long? EquipeVencedoraId { get; set; }
        public DateTime DataInicio { get; private set; }
        public DateTime DataFim { get; private set; }
        public PartidaViewModel ProximaPartida { get; private set; }
        public int Rodada { get; private set; }
    }
}
