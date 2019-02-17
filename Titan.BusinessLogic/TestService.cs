using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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

        public async Task Add(TestDto entity)
        {
            try
            {
                TestEntity testEntity = new TestEntity();
                testEntity = _mapper.Map<TestEntity>(entity);
                await _ITestRepository.Add(testEntity);
                await _unitOfWork.Save();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public async Task Delete(int id)
        {
            try
            {
                TestEntity entity = await _ITestRepository.GetById(id);
                await _ITestRepository.Delete(entity);
                await _unitOfWork.Save();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<TestDto>> Get()
        {

            try
            {
                IEnumerable<TestEntity> EntityList = await _ITestRepository.Get();
                IEnumerable<TestDto> TestDtoList = _mapper.Map<IEnumerable<TestDto>>(EntityList);
                return await Task.FromResult<IEnumerable<TestDto>>(TestDtoList);

            }
            catch (Exception ex)
            {

                throw ex;
            }
           

        }

        public async Task<TestDto> GetById(int id)
        {
            try
            {
                TestEntity entity = await _ITestRepository.GetById(id);
                return _mapper.Map<TestDto>(entity);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task Update(TestDto entity)
        {
            try
            {
               TestEntity entitydata = _mapper.Map<TestEntity>(entity);
               await _ITestRepository.Update(entitydata);
               await _unitOfWork.Save();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
