using Core.CrossCuttingConcerns.Rules;
using Core.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.CrossCuttingConcerns.Logging.Serilog;
using Microsoft.AspNetCore.Http;

namespace Business
{
    public static class BusinessServiceRegistration
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddSubClassesOfType(Assembly.GetExecutingAssembly(), typeof(BaseBusinessRules));

            //services.AddScoped<IUserService, UserManager>();
            //services.AddScoped<IApplicantService, ApplicantManager>();
            //services.AddScoped<IEmployeeService, EmployeeManager>();
            //services.AddScoped<IInstructorService, InstructorManager>();
            //services.AddScoped<IApplicationService, ApplicationManager>();
            //services.AddScoped<IApplicationStateService, ApplicationStateManager>();
            //services.AddScoped<IBootcampService, BootcampManager>();
            //services.AddScoped<IBootcampStateService, BootcampStateManager>();
            //services.AddScoped<IBlacklistService, BlacklistManager>();

            services.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).
            Where(t => t.ServiceType.Name.EndsWith("Manager"));

            return services;
        }
        

        
    }
}
