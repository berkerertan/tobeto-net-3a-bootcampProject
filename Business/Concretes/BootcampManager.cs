using AutoMapper;
using Business.Abstracts;
using Business.Requests.Bootcamps;
using Business.Response.Bootcamps;
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

        public BootcampManager(IBootcampRepository bootcampRepository, IMapper mapper)
        {
            _bootcampRepository = bootcampRepository;
            _mapper = mapper;
        }

        public async Task<IDataResult<CreateBootcampResponse>> AddAsync(CreateBootcampRequest request)
        {
            Bootcamp bootcamp = _mapper.Map<Bootcamp>(request);
            await _bootcampRepository.AddAsync(bootcamp);
            return new SuccessDataResult<CreateBootcampResponse>("Added Succesfuly");
        }

        public async Task<IResult> DeleteAsync(DeleteBootcampRequest request)
        {
            var item = await _bootcampRepository.GetAsync(p => p.Id == request.Id);
            if (item != null)
            {
                await _bootcampRepository.DeleteAsync(item);
                return new SuccessResult("Deleted Succesfuly");
            }

            return new ErrorResult("Delete Failed!");
        }

        public async Task<IDataResult<List<GetBootcampResponse>>> GetAllAsync()
        {
            var list = await _bootcampRepository.GetAllAsync(include: x => x.Include(p => p.Instructor).Include(p => p.BootcampState));

            List<GetBootcampResponse> responseList = _mapper.Map<List<GetBootcampResponse>>(list);
            return new SuccessDataResult<List<GetBootcampResponse>>(responseList, "Listed Succesfuly.");
        }

        public async Task<IDataResult<GetBootcampResponse>> GetByIdAsync(GetBootcampRequest request)
        {
            var item = await _bootcampRepository.GetAsync(p => p.Id == request.Id, include: x => x.Include(p => p.Instructor).Include(p => p.BootcampState));
            GetBootcampResponse response = _mapper.Map<GetBootcampResponse>(item);

            if (item != null)
            {
                return new SuccessDataResult<GetBootcampResponse>(response, "found Succesfuly.");
            }
            return new ErrorDataResult<GetBootcampResponse>("Bootcamp could not be found.");
        }

        public async Task<IDataResult<UpdateBootcampResponse>> UpdateAsync(UpdateBootcampRequest request)
        {
            var item = await _bootcampRepository.GetAsync(p => p.Id == request.Id);
            if (request.Id == 0 || item == null)
            {
                return new ErrorDataResult<UpdateBootcampResponse>("Bootcamp could not be found.");
            }

            _mapper.Map(request, item);
            await _bootcampRepository.UpdateAsync(item);

            UpdateBootcampResponse response = _mapper.Map<UpdateBootcampResponse>(item);
            return new SuccessDataResult<UpdateBootcampResponse>(response, "Bootcamp succesfully updated!");
        }
    }
}
