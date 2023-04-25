using Infrastructure.AuxiliaryClasses;
using Infrastructure.Configuration;
using Infrastructure.Repository.Interfaces;

namespace Infrastructure.Repository
{
    public abstract class BaseRepository<T> : IBaseRepository<T>
        where T : class
    {
        protected readonly Context _context;
        //private readonly IIdentityServerLog _logger;
        public BaseRepository(Context context) //IIdentityServerLog logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            //_logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public IUnitOfWork UnitOfWork => _context;

        //public IIdentityServerLog Logger => _logger;
    }
}
