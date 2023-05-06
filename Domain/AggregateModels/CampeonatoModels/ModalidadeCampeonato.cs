namespace Domain.AggregateModels.CampeonatoModels
{
    public class ModalidadeCampeonato
    {
        public int Id { get; private set; }
        public string Descricao { get; private set; }

        public ModalidadeCampeonato() { }

        public ModalidadeCampeonato(string descricao)
        {
            Descricao = descricao;
        }
    }
}
