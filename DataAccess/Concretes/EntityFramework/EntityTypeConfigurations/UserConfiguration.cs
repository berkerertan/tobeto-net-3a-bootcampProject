﻿using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concretes.EntityFramework.EntityTypeConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users").HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.UserName).HasColumnName("UserName");
            builder.Property(x => x.FirstName).HasColumnName("FirstName");
            builder.Property(x => x.LastName).HasColumnName("LastName");
            builder.Property(x => x.DateOfBirth).HasColumnName("DateOfBirth");
            builder.Property(x => x.NationalIdentity).HasColumnName("NationalIdentity");
            builder.Property(x => x.Email).HasColumnName("Email");
            builder.Property(x => x.PasswordHash).HasColumnName("PasswordHash");
            builder.Property(x => x.PasswordSalt).HasColumnName("PasswordSalt");


            //builder.HasMany(x => x.UserImage);
            builder.HasMany(t => t.UserOperationClaims);

        }
    }
}
