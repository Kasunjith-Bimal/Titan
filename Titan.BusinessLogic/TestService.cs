using AutoMapper;
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
        public IMapper _mapper;
        public ITestRepository _ITestRepository;
        public TestService(ITestRepository ITestRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _ITestRepository = ITestRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Add(TestDto entity)
        {
            try
            {
                TestEntity testEntity = new TestEntity();
                testEntity = _mapper.Map<TestEntity>(entity);
                //testEntity.TestEntityId = entity.TestEntityId;
                //testEntity.TestEntityName = entity.TestEntityName;
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
                IEnumerable<TestDto> TestDtoList = _mapper.Map<IEnumerable<TestDto>>(EntityList);
                return TestDtoList;

            }
            catch (Exception ex)
            {

                throw ex;
            }
           

        }

       
    }
}
