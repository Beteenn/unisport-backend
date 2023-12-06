namespace Application.DTO
{
    public class CadastroUsuarioDTO
    {
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Password { get; set; }
        public bool Admin { get; set; }
    }
}
