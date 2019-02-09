using System;
using System.Collections.Generic;
using System.Text;
using Titan.Entity;
using Titan.Interface.BaseInterface;
using Titan.Interface.RepositoryInterface;
using Titan.Interface.ServiceInterface;
using Titan.Model;

namespace Titan.Service
{
    public class TestService : ITestService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ITestRepository _ITestRepository;
        public TestService(ITestRepository ITestRepository, IUnitOfWork unitOfWork)
        {
            _ITestRepository = ITestRepository;
            _unitOfWork = unitOfWork;
        }

        public void Add(TestDto entity)
        {
            try
            {
                TestEntity testEntity = new TestEntity();

                testEntity.TestEntityId = entity.TestEntityId;
                testEntity.TestEntityName = entity.TestEntityName;

                _ITestRepository.Add(testEntity);
                _unitOfWork.Save();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public IEnumerable<TestDto> Get()
        {

            try
            {
                IEnumerable<TestEntity> EntityList = _ITestRepository.Get();

                List<TestDto> TestDtoList = new List<TestDto>();
                foreach (var item in EntityList)
                {
                    TestDto dto = new TestDto();

                    dto.TestEntityId = item.TestEntityId;
                    dto.TestEntityName = item.TestEntityName;

                    TestDtoList.Add(dto);

                }

                return TestDtoList;

            }
            catch (Exception ex)
            {

                throw ex;
            }
           

        }

       
    }
}
