namespace Domain.AggregateModels.CampeonatoModels
{
    public class StatusCampeonato
    {
        public int Id { get; private set; }
        public string Descricao { get; private set; }

        public StatusCampeonato() { }

        public StatusCampeonato(string descricao)
        {
            Descricao = descricao;
        }
    }
}
