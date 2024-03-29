﻿using Business.Abstracts;
using Business.Requests.Aplicants;
using Business.Responses.Applicants;
using Entities.Concretes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantsController : BaseController
    {
        private readonly IApplicantService _applicantService;

        public ApplicantsController(IApplicantService applicantManager)
        {
            _applicantService = applicantManager;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(CreateApplicantRequest request)
        {
            return HandleDataResult(await _applicantService.AddAsync(request));
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(DeleteApplicantRequest request)
        {
            return HandleResult(await _applicantService.DeleteAsync(request));
        }

        [HttpPost("GetById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var user = await _applicantService.GetByIdAsync(id);
            return HandleDataResult(user);
        }

        [HttpGet("GetAll")]
        [Authorize(Roles = "aplicant.list")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _applicantService.GetAllAsync();
            return HandleDataResult(users);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(UpdateApplicantRequest request)
        {
            return HandleDataResult(await _applicantService.UpdateAsync(request));
        }
    }
}
