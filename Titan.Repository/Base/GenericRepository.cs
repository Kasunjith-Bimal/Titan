using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Titan.Entity;
using Titan.Interface.BaseInterface;

namespace UnitOfWorkWithRepositoryPartens.Repository.Base
{
    public class GenericRepository<T> : IRepository<T>  where T : class
    {
        private readonly IUnitOfWork _unitOfWork;

        public GenericRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(T entity)
        {
            try
            {
                _unitOfWork._dbContextInstance.Set<T>().Add(entity);
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }

        public void Delete(T entity)
        {
            try
            {
                T existing = _unitOfWork._dbContextInstance.Set<T>().Find(entity);
                if (existing != null) _unitOfWork._dbContextInstance.Set<T>().Remove(existing);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

 
        public void Update(T entity)
        {
            try
            {
                _unitOfWork._dbContextInstance.Entry(entity).State = EntityState.Modified;
                _unitOfWork._dbContextInstance.Set<T>().Attach(entity);
            }
            catch (Exception ex)
            {

                throw ex;
            }
          
        }

        public IEnumerable<T> Get()
        {
            try
            {
                return this._unitOfWork._dbContextInstance.Set<T>().AsEnumerable<T>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }
    }
}
