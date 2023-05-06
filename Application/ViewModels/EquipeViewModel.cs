namespace Application.ViewModels
{
    public class EquipeViewModel
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public UsuarioViewModel Gerente { get; set; }
        public ICollection<UsuarioViewModel> Jogadores { get; set; }
    }
}