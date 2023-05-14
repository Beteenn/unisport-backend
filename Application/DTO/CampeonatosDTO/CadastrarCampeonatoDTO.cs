namespace Application.DTO.CampeonatosDTO
{
    public class CadastrarCampeonatoDTO
    {
        public string Nome { get; set; }
        public int TipoId { get; set; }
        public int ModalidadeId { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public DateTime DataInicioInscricao { get; set; }
        public DateTime DataFimInscricao { get; set; }
        public long OrganizadorId { get; set; }
    }
}
