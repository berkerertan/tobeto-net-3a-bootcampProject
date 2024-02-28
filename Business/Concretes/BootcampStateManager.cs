using AutoMapper;
using Business.Abstracts;
using Business.Requests.BootcampStates;
using Business.Responses.BootcampStates;
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

    public BootcampStateManager(IBootcampStateRepository bootcampStateRepository, IMapper mapper)
    {
        _bootcampStateRepository = bootcampStateRepository;
        _mapper = mapper;
    }

    public async Task<IDataResult<CreateBootcampStateResponse>> AddAsync(CreateBootcampStateRequest request)
    {
        BootcampState bootcampState = _mapper.Map<BootcampState>(request);
        await _bootcampStateRepository.AddAsync(bootcampState);
        return new SuccessDataResult<CreateBootcampStateResponse>("Added Succesfuly");
    }

    public async Task<IResult> DeleteAsync(DeleteBootcampStateRequest request)
    {
        await CheckIfIdNotExist(request.Id);
        var item = await _bootcampStateRepository.GetAsync(p => p.Id == request.Id);

        await _bootcampStateRepository.DeleteAsync(item);
        return new SuccessResult("Deleted Succesfuly");

    }

    public async Task<IDataResult<List<GetBootcampStateResponse>>> GetAllAsync()
    {
        var list = await _bootcampStateRepository.GetAllAsync();
        List<GetBootcampStateResponse> responseList = _mapper.Map<List<GetBootcampStateResponse>>(list);
        return new SuccessDataResult<List<GetBootcampStateResponse>>(responseList, "Listed Succesfuly.");
    }

    public async Task<IDataResult<GetBootcampStateResponse>> GetByIdAsync(GetBootcampStateRequest request)
    {
        await CheckIfIdNotExist(request.Id);
        var item = await _bootcampStateRepository.GetAsync(p => p.Id == request.Id);
        GetBootcampStateResponse response = _mapper.Map<GetBootcampStateResponse>(item);

        return new SuccessDataResult<GetBootcampStateResponse>(response, "found Succesfuly.");
    }

    public async Task<IDataResult<UpdateBootcampStateResponse>> UpdateAsync(UpdateBootcampStateRequest request)
    {
        await CheckIfIdNotExist(request.Id);
        var item = await _bootcampStateRepository.GetAsync(p => p.Id == request.Id);

        _mapper.Map(request, item);
        await _bootcampStateRepository.UpdateAsync(item);

        UpdateBootcampStateResponse response = _mapper.Map<UpdateBootcampStateResponse>(item);
        return new SuccessDataResult<UpdateBootcampStateResponse>(response, "BootcampState succesfully updated!");
    }
    private async Task CheckIfIdNotExist(Guid id)
    {
        var isExist = await _bootcampStateRepository.GetAsync(user => user.Id == id);
        if (isExist is null) throw new BusinessException("Id not null");
    }
}