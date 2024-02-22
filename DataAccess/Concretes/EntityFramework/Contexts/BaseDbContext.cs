using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.EntityFramework.Contexts
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<ApplicationState> ApplicationStates { get; set; }
        public DbSet<Bootcamp> Bootcamps { get; set; }
        public DbSet<BootcampState> BootcampStates { get; set; }

        public BaseDbContext()
        {
            
        }
        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            // (entity configurations) uygular. Bu yapılandırmalar, veritabanındaki varlıkların nasıl oluşturulacağını belirtir.
            // Özellikle, varlık türleri arasındaki ilişkileri, anahtarları ve diğer özellikleri tanımlar.

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
                //Restrict = DeleteBehavior.Restrict ilişkili bir varlık silinmeye çalışıldığında silme işlemini engellerken,
                //DeleteBehavior.Cascade ilişkili bir varlık silindiğinde, bu varlıkla ilişkilendirilmiş
                //olan diğer varlıkların da otomatik olarak silinmesini sağlar.

                //NoAction ise müdahale etmez.

                // CASCADE Bu, bir varlık silindiğinde ilişkili varlıkların da silineceği anlamına gelir.
                // Yani, ilişkili varlık silindiğinde, diğer varlık otomatik olarak silinir, bu da ilişkili verilerin tutarlılığını sağlar.

            }
        }
    }
}
