namespace Application.ViewModels.CampeonatosVm
{
    public class CampeonatoViewModel
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public TipoCampeonatoViewModel TipoCampeonato { get; set; }
        public ModalidadeCampeonatoViewModel ModalidadeCampeonato { get; set; }
        public StatusCampeonatoViewModel StatusCampeonato { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public UsuarioViewModel Organizador { get; set; }
        public InscricaoViewModel Inscricao { get; set; }
    }
}
