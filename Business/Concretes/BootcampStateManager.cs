﻿using AutoMapper;
using Business.Abstracts;
using Business.Constants;
using Business.Requests.BootcampStates;
using Business.Responses.BootcampStates;
using Business.Rules;
using Core.Exceptions.Types;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using DataAccess.Repositories;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes;

public class BootcampStateManager : IBootcampStateService
{
    private readonly IBootcampStateRepository _bootcampStateRepository;
    private readonly IMapper _mapper;
    private readonly BootcampStateBusinessRules _rules;

    public BootcampStateManager(IBootcampStateRepository bootcampStateRepository, IMapper mapper, BootcampStateBusinessRules rules)
    {
        _bootcampStateRepository = bootcampStateRepository;
        _mapper = mapper;
        _rules = rules;
    }

    public async Task<IDataResult<CreateBootcampStateResponse>> AddAsync(CreateBootcampStateRequest request)
    {
        await _rules.CheckIfBootcampStateNameHave(request.Name);
        BootcampState bootcampState = _mapper.Map<BootcampState>(request);
        await _bootcampStateRepository.AddAsync(bootcampState);
        return new SuccessDataResult<CreateBootcampStateResponse>(BaseMessages.Added);
    }

    public async Task<IResult> DeleteAsync(DeleteBootcampStateRequest request)
    {
        await _rules.CheckIfBootcampStateIdNotExist(request.Id);
        var item = await _bootcampStateRepository.GetAsync(p => p.Id == request.Id);
        await _bootcampStateRepository.DeleteAsync(item);
        return new SuccessResult(BaseMessages.Deleted);
    }

    public async Task<IDataResult<List<GetBootcampStateResponse>>> GetAllAsync()
    {
        var list = await _bootcampStateRepository.GetAllAsync();
        List<GetBootcampStateResponse> responseList = _mapper.Map<List<GetBootcampStateResponse>>(list);
        return new SuccessDataResult<List<GetBootcampStateResponse>>(responseList, BaseMessages.GetAll);
    }

    public async Task<IDataResult<GetBootcampStateResponse>> GetByIdAsync(Guid id)
    {
        await _rules.CheckIfBootcampStateIdNotExist(id);
        var item = await _bootcampStateRepository.GetAsync(p => p.Id == id);
        GetBootcampStateResponse response = _mapper.Map<GetBootcampStateResponse>(item);
        return new SuccessDataResult<GetBootcampStateResponse>(response, BaseMessages.GetById);
    }

    public async Task<IDataResult<UpdateBootcampStateResponse>> UpdateAsync(UpdateBootcampStateRequest request)
    {
        await _rules.CheckIfBootcampStateIdNotExist(request.Id);
        var item = await _bootcampStateRepository.GetAsync(p => p.Id == request.Id);
        _mapper.Map(request, item);
        await _bootcampStateRepository.UpdateAsync(item);
        UpdateBootcampStateResponse response = _mapper.Map<UpdateBootcampStateResponse>(item);
        return new SuccessDataResult<UpdateBootcampStateResponse>(response, BaseMessages.Updated);
    }
    
}