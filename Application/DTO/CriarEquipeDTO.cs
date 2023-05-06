namespace Application.DTO
{
    public class CriarEquipeDTO
    {
        public string Nome { get; set; }
        public long GerenteId { get; set; }
        public IEnumerable<long> JogadoresId { get; set; }
    }
}
