using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Titan.Interface.BaseInterface;

namespace UnitOfWorkWithRepositoryPartens.Repository.Base
{
    public class GenericRepository<T> : IRepository<T>  where T : class
    {
        public GenericRepository(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.dbset = unitOfWork.DbContext.Set<T>();
        }

        private DbSet<T> dbset;
     

        public IUnitOfWork unitOfWork { get; private set; }

        public void Add(T entity)
        {
            try
            {
                this.dbset.Add(entity);
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
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public void SaveChanges()
        {
            try
            {
                this.unitOfWork.DbContext.SaveChanges();
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
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {

                throw ex;
            }
          
        }

        public IEnumerable<T> getAll()
        {
            try
            {
                return this.dbset.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }
    }
}
