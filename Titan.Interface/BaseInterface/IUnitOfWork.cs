using System;
using System.Collections.Generic;
using System.Text;
using Titan.Entity;


namespace Titan.Interface.BaseInterface
{
    public interface IUnitOfWork
    {
         TitanDbContext DbContext { get; }
    }
}
