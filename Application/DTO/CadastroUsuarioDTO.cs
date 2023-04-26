namespace Application.DTO
{
    public class CadastroUsuarioDTO
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Password { get; set; }
    }
}
