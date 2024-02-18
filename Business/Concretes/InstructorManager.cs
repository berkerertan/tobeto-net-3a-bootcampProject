using Business.Abstracts;
using Business.Requests.Instructors;
using Business.Responses.Instructors;
using Business.Responses.Users;
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
        public InstructorManager(IInstructorRepository instructorRepository)
        {
            _instructorRepository = instructorRepository;
        }
        public async Task<CreateInstructorResponse> AddAsync(CreateInstructorRequest request)
        {
            Instructor instructor = new Instructor();
            instructor.FirstName = request.FirstName;
            instructor.LastName = request.LastName;
            instructor.Email = request.Email;
            instructor.NationalIdentity = request.NationalIdentity;
            instructor.Password = request.Password;
            instructor.CompanyName = request.CompanyName;
            await _instructorRepository.Add(instructor);

            CreateInstructorResponse response = new CreateInstructorResponse();
            response.FirstName = instructor.FirstName;
            response.LastName = instructor.LastName;
            response.Email = instructor.Email;
            response.NationalIdentity = instructor.NationalIdentity;
            response.CompanyName = instructor.CompanyName;
            return response;
        }


        public async Task DeleteAsync(int id)
        {
            var instructor = await _instructorRepository.Get(i => i.UserId == id);
            if (instructor != null)
            {
                await _instructorRepository.Delete(instructor);
            }
        }

        public async Task<List<Instructor>> GetAll()
        {
            return await _instructorRepository.GetAll();
        }

        public async Task<Instructor> GetByIdAsync(int id)
        {
            return await _instructorRepository.Get(i=>i.UserId == id);
        }

        public async Task<UpdateInstructorResponse> UpdateAsync(Instructor instructor)
        {
            var updatedInstructor = await _instructorRepository.Update(instructor);

            return new UpdateInstructorResponse
            {
                UserName = instructor.UserName,
                FirstName = instructor.FirstName,
                LastName = instructor.LastName,
                Email = instructor.Email,
                NationalIdentity = instructor.NationalIdentity,
                CompanyName = instructor.CompanyName,
            };
        }
    }
}
