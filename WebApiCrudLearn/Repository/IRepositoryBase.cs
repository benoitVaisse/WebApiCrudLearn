using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCrudLearn.Repository
{
    public interface IRepositoryBase <T>
    {
        Task<IEnumerable<T>> FindAll();

        Task<T> Get();

        Task<T> Create(T entity);

        Task<T> Update(T entity);

        Task<T> Delete(T entity);
    }
}
