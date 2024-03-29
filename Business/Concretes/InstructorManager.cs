﻿using AutoMapper;
using Business.Abstracts;
using Business.Constants;
using Business.Requests.Instructors;
using Business.Responses.Instructors;
using Business.Responses.Users;
using Business.Rules;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Exceptions.Types;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using DataAccess.Repositories;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class InstructorManager : IInstructorService
    {
        private readonly IInstructorRepository _instructorRepository;
        private readonly IMapper _mapper;
        private readonly InstructorBusinessRules _rules;

        public InstructorManager(IInstructorRepository instructorRepository, IMapper mapper, InstructorBusinessRules rules)
        {
            _instructorRepository = instructorRepository;
            _mapper = mapper;
            _rules = rules;
        }

        //[LogAspect(typeof(MssqlLogger))]
        public async Task<IDataResult<CreateInstructorResponse>> AddAsync(CreateInstructorRequest request)
        {
            await _rules.CheckIfInstructorUserNameNotExist(request.UserName);
            Instructor user = _mapper.Map<Instructor>(request);
            await _instructorRepository.AddAsync(user);
            CreateInstructorResponse response = _mapper.Map<CreateInstructorResponse>(user);
            return new SuccessDataResult<CreateInstructorResponse>(response, BaseMessages.Added);
        }

        public async Task<IResult> DeleteAsync(DeleteInstructorRequest request)
        {
            await _rules.CheckIfInstructorIdNotExist(request.Id);
            var item = await _instructorRepository.GetAsync(p => p.Id == request.Id);
            await _instructorRepository.DeleteAsync(item);
            return new SuccessResult(BaseMessages.Deleted);
        }

        public async Task<IDataResult<List<GetInstructorResponse>>> GetAll()
        {
            var list = await _instructorRepository.GetAllAsync();
            List<GetInstructorResponse> responselist = _mapper.Map<List<GetInstructorResponse>>(list);
            return new SuccessDataResult<List<GetInstructorResponse>>(responselist, BaseMessages.GetAll);
        }

        public async Task<IDataResult<GetInstructorResponse>> GetByIdAsync(Guid id)
        {
            await _rules.CheckIfInstructorIdNotExist(id);
            var item = await _instructorRepository.GetAsync(p => p.Id == id);
            GetInstructorResponse response = _mapper.Map<GetInstructorResponse>(item);
            return new SuccessDataResult<GetInstructorResponse>(response, BaseMessages.GetById);
        }

        public async Task<IDataResult<UpdateInstructorResponse>> UpdateAsync(UpdateInstructorRequest request)
        {
            await _rules.CheckIfInstructorIdNotExist(request.Id);
            var item = await _instructorRepository.GetAsync(p => p.Id == request.Id);
            _mapper.Map(request, item);
            await _instructorRepository.UpdateAsync(item);
            UpdateInstructorResponse response = _mapper.Map<UpdateInstructorResponse>(item);
            return new SuccessDataResult<UpdateInstructorResponse>(response, BaseMessages.Updated);
        }

        
    }
}
