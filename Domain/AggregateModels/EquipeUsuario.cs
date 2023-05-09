namespace Domain.AggregateModels
{
    public class EquipeUsuario
    {
        public Usuario Usuario { get; private set; }
        public long UsuarioId { get; private set; }
        public Equipe Equipe { get; private set; }
        public long EquipeId { get; private set; }

        public EquipeUsuario() { }

        public EquipeUsuario(long usuarioId)
        {
            UsuarioId = usuarioId;
        }
    }
}
