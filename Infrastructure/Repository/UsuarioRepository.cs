using Domain.AggregateModels;
using Infrastructure.Configuration;
using Infrastructure.Configuration.Logger;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(Context context)
            : base(context)
        {

        }

		public async Task CadastraUsuario(Usuario usuario, string password)
		{
			await _context.AddAsync(usuario);
		}
    }
}
