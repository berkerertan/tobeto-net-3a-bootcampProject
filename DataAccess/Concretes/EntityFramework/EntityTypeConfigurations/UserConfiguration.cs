using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.EntityFramework.EntityTypeConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users").HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.UserId).HasColumnName("Id");
            builder.Property(x => x.UserName).HasColumnName("Id");
            builder.Property(x => x.FirstName).HasColumnName("Id");
            builder.Property(x => x.LastName).HasColumnName("Id");
            builder.Property(x => x.DateOfBirth).HasColumnName("Id");
            builder.Property(x => x.NationalIdentity).HasColumnName("Id");
            builder.Property(x => x.Email).HasColumnName("Id");
            builder.Property(x => x.Password).HasColumnName("Id");

        }
    }
}
