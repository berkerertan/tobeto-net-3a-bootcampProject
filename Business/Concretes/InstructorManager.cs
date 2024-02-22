﻿using AutoMapper;
using Business.Abstracts;
using Business.Requests.Instructors;
using Business.Responses.Instructors;
using Business.Responses.Users;
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
        private readonly IInstructorRepository _ınstructorRepository;
        private readonly IMapper _mapper;

        public InstructorManager(IInstructorRepository ınstructorRepository, IMapper mapper)
        {
            _ınstructorRepository = ınstructorRepository;
            _mapper = mapper;
        }

        public async Task<IDataResult<CreateInstructorResponse>> AddAsync(CreateInstructorRequest request)
        {
            Instructor user = _mapper.Map<Instructor>(request);
            await _ınstructorRepository.AddAsync(user);
            CreateInstructorResponse response = _mapper.Map<CreateInstructorResponse>(user);

            return new SuccessDataResult<CreateInstructorResponse>(response, "Added Succesfuly");
        }

        public async Task<IResult> DeleteAsync(DeleteInstructorRequest request)
        {
            var item = await _ınstructorRepository.GetAsync(p => p.Id == request.Id);
            if (item != null)
            {
                await _ınstructorRepository.DeleteAsync(item);
                return new SuccessResult("Deleted Succesfuly");
            }
            return new ErrorResult("Delete Failed!");
        }

        public async Task<IDataResult<List<GetInstructorResponse>>> GetAll()
        {
            var list = await _ınstructorRepository.GetAllAsync();
            List<GetInstructorResponse> responselist = _mapper.Map<List<GetInstructorResponse>>(list);

            return new SuccessDataResult<List<GetInstructorResponse>>(responselist, "Listed Succesfuly.");
        }

        public async Task<IDataResult<GetInstructorResponse>> GetByIdAsync(GetInstructorRequest request)
        {
            var item = await _ınstructorRepository.GetAsync(p => p.Id == request.Id);
            if (item != null)
            {
                GetInstructorResponse response = _mapper.Map<GetInstructorResponse>(item);
                return new SuccessDataResult<GetInstructorResponse>(response, "found Succesfuly.");
            }
            return new ErrorDataResult<GetInstructorResponse>("User could not be found.");
        }

        public async Task<IDataResult<UpdateInstructorResponse>> UpdateAsync(UpdateInstructorRequest request)
        {
            var item = await _ınstructorRepository.GetAsync(p => p.Id == request.Id);

            if (item != null)
            {
                _mapper.Map(request, item);
                await _ınstructorRepository.UpdateAsync(item);
                UpdateInstructorResponse response = _mapper.Map<UpdateInstructorResponse>(item);

                return new SuccessDataResult<UpdateInstructorResponse>(response, "User succesfully updated!");
            }

            return new ErrorDataResult<UpdateInstructorResponse>("User could not be found.");
        }
    }
}
