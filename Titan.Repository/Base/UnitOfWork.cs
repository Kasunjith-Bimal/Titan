using System;
using Titan.Entity;
using Titan.Interface.BaseInterface;

namespace Titan.Repository.Base
{
    public class UnitOfWork :IDisposable, IUnitOfWork
    {
        private static TitanDbContext dbContext = null;
        public bool disposed = false;
        public TitanDbContext DbContext
        {
            get
            {
                if (dbContext == null)
                {
                    dbContext = new TitanDbContext();
                }
                return dbContext;
            }
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.DbContext.Dispose();
                }
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
