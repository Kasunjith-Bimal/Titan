using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Titan.Interface.BaseInterface
{
    public interface IRepository<T> where T : class
    {

        Task<IEnumerable<T>> Get();

        Task Add(T entity);

        Task Update(T entity);

        Task Delete(T entity);

        Task<T> GetById(int id);
    }
}
