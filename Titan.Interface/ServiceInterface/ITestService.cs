using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Titan.Entity;
using Titan.Model;

namespace Titan.Interface.ServiceInterface
{
    public interface ITestService
    {
        Task Add(TestDto entity);

        Task<IEnumerable<TestDto>> Get();

        Task<TestDto> GetById(int id);

        Task Update(TestDto entity);

        Task Delete(int id);
    }
}
