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
    public class UserImageConfiguration
    {
        public void Configure(EntityTypeBuilder<UserImage> builder)
        {
            builder.ToTable("UserImages").HasKey(x=>x.Id);
            builder.Property(x=>x.Id).HasColumnName("Id");
            builder.Property(x=>x.UserId).HasColumnName("UserId").IsRequired();
            builder.Property(x=>x.ImagePath).HasColumnName("ImagePath").IsRequired();
            builder.Property(x=>x.CreatedDate).HasColumnName("CreatedDate");
            builder.Property(x=>x.UpdatedDate).HasColumnName("UpdateDate");
            builder.Property(x=>x.DeletedDate).HasColumnName("DeletedDate");

            builder.HasOne(x => x.User);
        }
    }
}
