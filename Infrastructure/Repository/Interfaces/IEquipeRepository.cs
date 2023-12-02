﻿using Domain.AggregateModels;

namespace Infrastructure.Repository.Interfaces
{
    public interface IEquipeRepository : IBaseRepository<Equipe>
    {
        Task CriarEquipe(Equipe equipe);
        Task AtualizarEquipe(Equipe equipe);
        Task<Equipe> ObterEquipePorId(long id);
        Task<IEnumerable<Equipe>> ListarEquipes();
        Task DeletarEquipe(Equipe equipe);
    }
}
