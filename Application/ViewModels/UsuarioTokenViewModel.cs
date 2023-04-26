namespace Application.ViewModels
{
    public class UsuarioTokenViewModel
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public long FaculdadeId { get; set; }

        public DateTime DataCriacao { get; set; }
        public DateTime DataExpiracao { get; set; }

        public bool TokenExpirado => DateTime.UtcNow >= DataExpiracao;

        public UsuarioTokenViewModel() { }
    }
}
