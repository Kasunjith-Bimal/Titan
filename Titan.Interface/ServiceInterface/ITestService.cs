using System;
using System.Collections.Generic;
using System.Text;
using Titan.Entity;
using Titan.Model;

namespace Titan.Interface.ServiceInterface
{
    public interface ITestService
    {
        void Add(TestDto entity);

        IEnumerable<TestDto> Get();

        TestDto GetById(int id);

        void Update(TestDto entity);

        void Delete(int id);
    }
}
