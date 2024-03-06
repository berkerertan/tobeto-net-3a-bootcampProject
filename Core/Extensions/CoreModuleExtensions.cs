using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public static class CoreModuleExtensions
    {
        public static IServiceCollection AddCoreModule(this IServiceCollection services)
        {
            // ILogger arayüzünü uygulayan MongoDbLogger sınıfının her çağrıldığında yeni bir örneğini oluşturur.
            services.AddTransient<MongoDbLogger>(); //AddTransiet,AddSingleton,AddScoped
            services.AddTransient<MssqlLogger>();// AddTransient, bağımlılıkların her çağrıldığında yeni bir örneğinin oluşturulmasını sağlar.

            // IHttpContextAccessor arayüzüyle HttpContextAccessor sınıfının bir örneğini ekler.
            // Bu, HTTP istekleri ve yanıtları üzerindeki bilgilere erişmek için kullanılır.
            services.AddScoped<IHttpContextAccessor, HttpContextAccessor>();// AddScoped, her istemciye bir örnek oluşturur ve aynı istemciye gelen taleplerde aynı örneği kullanır.
            return services;
        }
    }
}
