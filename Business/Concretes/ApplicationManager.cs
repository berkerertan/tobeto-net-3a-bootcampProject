using AutoMapper;
using Business.Abstracts;
using Business.Requests.Applications;
using Business.Response.Applications;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class ApplicationManager : IApplicationService
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly IMapper _mapper;

        public ApplicationManager(IApplicationRepository applicationRepository, IMapper mapper)
        {
            _applicationRepository = applicationRepository;
            _mapper = mapper;
        }

        public async Task<IDataResult<CreateApplicationResponse>> AddAsync(CreateApplicationRequest request)
        {
            Application application = _mapper.Map<Application>(request);
            await _applicationRepository.AddAsync(application);
            return new SuccessDataResult<CreateApplicationResponse>("Added Succesfuly");
        }

        public async Task<IResult> DeleteAsync(DeleteApplicationRequest request)
        {
            var item = await _applicationRepository.GetAsync(p => p.Id == request.Id);
            if (item != null)
            {
                await _applicationRepository.DeleteAsync(item);
                return new SuccessResult("Deleted Succesfuly");
            }

            return new ErrorResult("Delete Failed!");
        }

        public async Task<IDataResult<List<GetApplicationResponse>>> GetAllAsync()
        {
            var list = await _applicationRepository.GetAllAsync(include: x => x.Include(p => p.Applicant).Include(p => p.Bootcamp).Include(p => p.ApplicationState));
            List<GetApplicationResponse> responseList = _mapper.Map<List<GetApplicationResponse>>(list);
            return new SuccessDataResult<List<GetApplicationResponse>>(responseList, "Listed Succesfuly.");
        }

        public async Task<IDataResult<GetApplicationResponse>> GetByIdAsync(GetApplicationRequest request)
        {
            var list = await _applicationRepository.GetAllAsync(include: x => x.Include(p => p.Applicant).Include(p => p.Bootcamp).Include(p => p.ApplicationState));
            var item = list.Where(p => p.Id == request.Id).FirstOrDefault();
            GetApplicationResponse response = _mapper.Map<GetApplicationResponse>(item);

            if (item != null)
            {
                return new SuccessDataResult<GetApplicationResponse>(response, "found Succesfuly.");
            }
            return new ErrorDataResult<GetApplicationResponse>("Application could not be found.");
        }

        public async Task<IDataResult<UpdateApplicationResponse>> UpdateAsync(UpdateApplicationRequest request)
        {
            var item = await _applicationRepository.GetAsync(p => p.Id == request.Id, include: x => x.Include(p => p.Applicant).Include(p => p.Bootcamp));
            if (request.Id == null || item == null)
            {
                return new ErrorDataResult<UpdateApplicationResponse>("Application could not be found.");
            }

            _mapper.Map(request, item);
            await _applicationRepository.UpdateAsync(item);

            UpdateApplicationResponse response = _mapper.Map<UpdateApplicationResponse>(item);
            return new SuccessDataResult<UpdateApplicationResponse>(response, "Application succesfully updated!");

        }
    }
}
