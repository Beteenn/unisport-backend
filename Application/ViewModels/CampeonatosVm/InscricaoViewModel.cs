namespace Application.ViewModels.CampeonatosVm
{
    public class InscricaoViewModel
    {
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public IEnumerable<EquipeViewModel> Equipes { get; set; }
    }
}
