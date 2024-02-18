using DataAccess;
using Business;
using Business.Abstracts;
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
            try
            {
                var app = builder.Build();
                // Configure the HTTP request pipeline.
                if (app.Environment.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI(c =>
                    {
                        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                        c.RoutePrefix = "swagger";
                    });
                }

                app.UseAuthorization();


                app.MapControllers();

                app.Run();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata oluþtu: " + ex.Message);
                throw; // Hatanýn daha detaylý incelenmesi için istisnayý yeniden fýrlatýn
            }

            
        }
    }
}
