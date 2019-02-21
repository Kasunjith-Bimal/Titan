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
        Task<TestDto> Add(TestDto entity);

        Task<IEnumerable<TestDto>> Get();

        Task<TestDto> GetById(int id);

        Task<bool> Update(TestDto entity);

        Task<bool> Delete(int id);
    }
}
