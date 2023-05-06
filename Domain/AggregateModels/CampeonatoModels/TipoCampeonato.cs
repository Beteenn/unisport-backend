namespace Domain.AggregateModels.CampeonatoModels
{
    public class TipoCampeonato
    {
        public int Id { get; private set; }
        public string Descricao { get; private set; }

        public TipoCampeonato() { }

        public TipoCampeonato(string descricao)
        {
            Descricao = descricao;
        }
    }
}
