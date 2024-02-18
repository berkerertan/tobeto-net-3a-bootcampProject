using DataAccess;
using Business;
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
                    app.UseSwaggerUI();
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
