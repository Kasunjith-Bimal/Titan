using System;
using System.Collections.Generic;
using System.Text;
using Titan.Entity;
using Titan.Interface.BaseInterface;
using Titan.Interface.RepositoryInterface;
using UnitOfWorkWithRepositoryPartens.Repository.Base;

namespace Titan.Repository
{
    public class TestRepository : GenericRepository<TestEntity>, ITestRepository
    {

        public TestRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
