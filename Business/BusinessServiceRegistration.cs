using Business.Abstracts;
using Business.Concretes;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public static class BusinessServiceRegistration
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IApplicantService, ApplicantManager>();
            services.AddScoped<IEmployeeService, EmployeeManager>();
            services.AddScoped<IInstructorService, InstructorManager>();
            services.AddScoped<IApplicationService, ApplicationManager>();
            services.AddScoped<IApplicationStateService, ApplicationStateManager>();
            services.AddScoped<IBootcampService, BootcampManager>();
            services.AddScoped<IBootcampStateService, BootcampStateManager>();
            services.AddScoped<IBlacklistService, BlacklistManager>();

            return services;
        }
    }
}
