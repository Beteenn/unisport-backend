using Infrastructure.AuxiliaryClasses;

namespace Infrastructure.Repository.Interfaces
{
    public interface IBaseRepository<T>
       where T : class
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
