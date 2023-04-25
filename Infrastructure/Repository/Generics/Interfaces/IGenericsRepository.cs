using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Generics.Interfaces
{
	public interface IGenericsRepository<T> where T : class
	{
		Task Add(T entity);
		Task Update(T entity);
		Task Delete(T entity);
		Task<T> GetEntityById(int id);
		Task<List<T>> GetAll();
	}
}
