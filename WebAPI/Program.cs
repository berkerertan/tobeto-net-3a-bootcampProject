using DataAccess;
using Business;
using Business.Abstracts;
using Core.Exceptions.Extensions;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddControllers();
            builder.Services.AddDataAccessServices(builder.Configuration);
            builder.Services.AddBusinessServices();


                var app = builder.Build();
                // Configure the HTTP request pipeline.
                if (app.Environment.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                    app.ConfigureCustomExceptionMiddleware();
                }

                app.UseAuthorization();


                app.MapControllers();

                app.Run();

            
        }
    }
}
