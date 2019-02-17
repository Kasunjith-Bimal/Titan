using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Titan.Entity;


namespace Titan.Interface.BaseInterface
{
    public interface IUnitOfWork: IDisposable
    {
        DbContext _dbContextInstance { get; set; }
        int Save();
    }
}
