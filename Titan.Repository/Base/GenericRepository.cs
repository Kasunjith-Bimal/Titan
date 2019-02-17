using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public async Task Add(T entity)
        {
            try
            {
              await _unitOfWork._dbContextInstance.Set<T>().AddAsync(entity);
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }

        public async Task Delete(T entity)
        {
            try
            {
                await Task.FromResult(_unitOfWork._dbContextInstance.Set<T>().Remove(entity)); 
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

 
        public async Task Update(T entity)
        {
            try
            {
               
                await Task.FromResult(_unitOfWork._dbContextInstance.Entry(entity).State = EntityState.Modified);
                //_unitOfWork._dbContextInstance.Set<T>().Attach(entity);
              
            }
            catch (Exception ex)
            {

                throw ex;
            }
          
        }

        public async Task<IEnumerable<T>> Get()
        {
            try
            {
               return await Task.FromResult<IEnumerable<T>>(this._unitOfWork._dbContextInstance.Set<T>().AsEnumerable<T>());
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }

        public async Task<T> GetById(int id)
        {
            try
            {
                return await Task.FromResult<T>(this._unitOfWork._dbContextInstance.Set<T>().Find(id));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
