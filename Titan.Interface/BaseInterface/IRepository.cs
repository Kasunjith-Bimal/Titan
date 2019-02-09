using System;
using System.Collections.Generic;
using System.Text;

namespace Titan.Interface.BaseInterface
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> Get();

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);   
    }
}
