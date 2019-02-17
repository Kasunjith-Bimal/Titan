using Microsoft.EntityFrameworkCore;
using System;
using Titan.Entity;
using Titan.Interface.BaseInterface;

namespace Titan.Repository.Base
{
    public class UnitOfWork : IUnitOfWork
    {
       

        public DbContext _dbContextInstance { get; set; } 

     
        public bool disposed = false;

        

        public UnitOfWork(TitanDbContext dbContextInstance)
        {
            _dbContextInstance = dbContextInstance;

        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this._dbContextInstance != null)
                {
                    this._dbContextInstance.Dispose();
                    this._dbContextInstance = null;
                }
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public int Save()
        {
            return this._dbContextInstance.SaveChanges();
        }

       
    }
}
