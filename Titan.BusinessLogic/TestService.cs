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

        public async Task<bool> Add(TestDto entity)
        {
            bool isTrue = false;
            try
            {
                TestEntity testEntity = new TestEntity();
                testEntity = _mapper.Map<TestEntity>(entity);
                await _ITestRepository.Add(testEntity);
                await _unitOfWork.Save();
                isTrue = true;
                return isTrue;

            }
            catch (Exception ex)
            {
                return isTrue;
                throw ex;    
            }
            
        }

        public async Task<bool> Delete(int id)
        {
            bool isTrue = false;
            try
            {
                TestEntity entity = await _ITestRepository.GetById(id);
                await _ITestRepository.Delete(entity);
                await _unitOfWork.Save();
                isTrue = true;
                return isTrue;
            }
            catch (Exception ex)
            {
                isTrue = false;
                return isTrue;
                throw ex;
            }
        }

        public async Task<IEnumerable<TestDto>> Get()
        {

            try
            {
                IEnumerable<TestEntity> EntityList = await _ITestRepository.Get();
                if (EntityList != null)
                {
                    IEnumerable<TestDto> TestDtoList = _mapper.Map<IEnumerable<TestDto>>(EntityList);
                    return await Task.FromResult<IEnumerable<TestDto>>(TestDtoList);
                }
                else
                {
                    return await Task.FromResult<IEnumerable<TestDto>>(null);
                }
               

            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
           

        }

        public async Task<TestDto> GetById(int id)
        {
            try
            {
                TestEntity entity = await _ITestRepository.GetById(id);
                if(entity != null)
                {
                    return _mapper.Map<TestDto>(entity);
                }
                else
                {
                    return null;
                }
               
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> Update(TestDto entity)
        {
            bool isTrue = false;
            try
            {
                
             TestEntity entitydata = _mapper.Map<TestEntity>(entity);
             await _ITestRepository.Update(entitydata);
             await _unitOfWork.Save();
             isTrue = true;
             return isTrue;


            }
            catch (Exception ex)
            {
                isTrue = false;
                return isTrue;
                throw ex;
            }
        }
    }
}
