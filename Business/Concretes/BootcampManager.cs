using AutoMapper;
using Business.Abstracts;
using Business.Constants;
using Business.Requests.Bootcamps;
using Business.Response.Bootcamps;
using Business.Rules;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Exceptions.Types;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using DataAccess.Repositories;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class BootcampManager : IBootcampService
    {
        private readonly IBootcampRepository _bootcampRepository;
        private readonly IMapper _mapper;
        private readonly BootcampBusinessRules _rules;

        public BootcampManager(IBootcampRepository bootcampRepository, IMapper mapper, BootcampBusinessRules rules)
        {
            _bootcampRepository = bootcampRepository;
            _mapper = mapper;
            _rules = rules;
        }

        //[LogAspect(typeof(MssqlLogger))]
        public async Task<IDataResult<CreateBootcampResponse>> AddAsync(CreateBootcampRequest request)
        {
            Bootcamp bootcamp = _mapper.Map<Bootcamp>(request);
            await _bootcampRepository.AddAsync(bootcamp);
            return new SuccessDataResult<CreateBootcampResponse>(BaseMessages.Added);
        }

        public async Task<IResult> DeleteAsync(DeleteBootcampRequest request)
        {
            await _rules.CheckIfBootcampIdNotExist(request.Id);
            var item = await _bootcampRepository.GetAsync(x => x.Id == request.Id);
            await _bootcampRepository.DeleteAsync(item);
            return new SuccessResult(BaseMessages.Deleted);
        }

        public async Task<IDataResult<List<GetBootcampResponse>>> GetAllAsync()
        {
            var list = await _bootcampRepository.GetAllAsync(include: x => x.Include(x => x.Instructor).Include(x => x.BootcampState));
            List<GetBootcampResponse> responseList = _mapper.Map<List<GetBootcampResponse>>(list);
            return new SuccessDataResult<List<GetBootcampResponse>>(responseList, BaseMessages.GetAll);
        }

        public async Task<IDataResult<GetBootcampResponse>> GetByIdAsync(Guid id)
        {
            await _rules.CheckIfBootcampIdNotExist(id);
            var item = await _bootcampRepository.GetAsync(x => x.Id == id, include: x => x.Include(x => x.Instructor).Include(x => x.BootcampState));
            GetBootcampResponse response = _mapper.Map<GetBootcampResponse>(item);
            return new SuccessDataResult<GetBootcampResponse>(response, BaseMessages.GetById);
        }

        public async Task<IDataResult<UpdateBootcampResponse>> UpdateAsync(UpdateBootcampRequest request)
        {
            await _rules.CheckIfBootcampIdNotExist(request.Id);
            var item = await _bootcampRepository.GetAsync(x => x.Id == request.Id);
            _mapper.Map(request, item);
            await _bootcampRepository.UpdateAsync(item);
            UpdateBootcampResponse response = _mapper.Map<UpdateBootcampResponse>(item);
            return new SuccessDataResult<UpdateBootcampResponse>(response, BaseMessages.Updated);
        }

        
    }
}
