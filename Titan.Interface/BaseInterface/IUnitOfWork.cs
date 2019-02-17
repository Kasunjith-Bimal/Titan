using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Titan.Entity;


namespace Titan.Interface.BaseInterface
{
    public interface IUnitOfWork: IDisposable
    {
        DbContext _dbContextInstance { get; set; }
        Task Save();
    }
}
