namespace Domain.AggregateModels
{
    public class Faculdade
    {
        public long Id { get; private set; }
        public string Nome { get; private set; }
        public string DominioEmail { get; private set; }

        public Faculdade() { }

        public Faculdade(string nome, string dominio)
        {
            Nome = nome;
            DominioEmail = dominio;
        }
    }
}
