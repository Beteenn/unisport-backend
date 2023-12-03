namespace Domain.AggregateModels.CampeonatoModels
{
    public class Chave
    {
        public Partida PartidaA { get; private set; }
        public Partida PartidaB { get; private set; }

        public Chave(Partida partidaA, Partida partidaB)
        {
            PartidaA = partidaA;
            PartidaB = partidaB;
        }
    }
}
