using Domain.AggregateModels;
using Infrastructure.Configuration;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class FaculdadeRepository : BaseRepository<Faculdade>, IFaculdadeRepository
    {
        public FaculdadeRepository(Context context) : base(context) { }

        public async Task<IEnumerable<Faculdade>> ListarFaculdades()
        {
            return await _context.Faculdade.ToListAsync();
        }

        public async Task<Faculdade> ObterFaculdadePorId(long id)
        {
            return await _context.Faculdade.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task CadastrarFaculdade(Faculdade faculdade)
        {
            await _context.AddAsync(faculdade);
        }
    }
}
