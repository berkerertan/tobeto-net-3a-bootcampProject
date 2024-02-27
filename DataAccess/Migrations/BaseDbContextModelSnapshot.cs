﻿// <auto-generated />
using System;
using DataAccess.Concretes.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(BaseDbContext))]
    partial class BaseDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entities.Concretes.Application", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<Guid>("ApplicantId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ApplicantId");

                    b.Property<Guid>("ApplicationStateId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ApplicationStateId");

                    b.Property<Guid>("BootcampId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("BootcampId");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ApplicantId");

                    b.HasIndex("ApplicationStateId");

                    b.HasIndex("BootcampId");

                    b.ToTable("Aplications", (string)null);
                });

            modelBuilder.Entity("Entities.Concretes.ApplicationState", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("ApplicationStates", (string)null);
                });

            modelBuilder.Entity("Entities.Concretes.Blacklist", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<Guid>("ApplicantId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("AplicantId");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2")
                        .HasColumnName("Date");

                    b.Property<DateTime>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Reason");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ApplicantId")
                        .IsUnique();

                    b.ToTable("Blacklists", (string)null);
                });

            modelBuilder.Entity("Entities.Concretes.Bootcamp", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<Guid>("BootcampStateId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("BootcampStateId");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("EndDate");

                    b.Property<Guid>("InstructorId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("InstructorId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("StartDate");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BootcampStateId");

                    b.HasIndex("InstructorId");

                    b.ToTable("Bootcamps", (string)null);
                });

            modelBuilder.Entity("Entities.Concretes.BootcampState", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("BootcampStates", (string)null);
                });

            modelBuilder.Entity("Entities.Concretes.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2")
                        .HasColumnName("DateOfBirth");

                    b.Property<DateTime>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("FirstName");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("LastName");

                    b.Property<string>("NationalIdentity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NationalIdentity");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Password");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("UserName");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("Entities.Concretes.UserImage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserImages");
                });

            modelBuilder.Entity("Entities.Concretes.Applicant", b =>
                {
                    b.HasBaseType("Entities.Concretes.User");

                    b.Property<string>("About")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("About");

                    b.ToTable("Applicants", (string)null);
                });

            modelBuilder.Entity("Entities.Concretes.Employee", b =>
                {
                    b.HasBaseType("Entities.Concretes.User");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Position");

                    b.ToTable("Employees", (string)null);
                });

            modelBuilder.Entity("Entities.Concretes.Instructor", b =>
                {
                    b.HasBaseType("Entities.Concretes.User");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CompanyName");

                    b.ToTable("Instructors", (string)null);
                });

            modelBuilder.Entity("Entities.Concretes.Application", b =>
                {
                    b.HasOne("Entities.Concretes.Applicant", "Applicant")
                        .WithMany("Applications")
                        .HasForeignKey("ApplicantId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Entities.Concretes.ApplicationState", "ApplicationState")
                        .WithMany()
                        .HasForeignKey("ApplicationStateId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Entities.Concretes.Bootcamp", "Bootcamp")
                        .WithMany("Applications")
                        .HasForeignKey("BootcampId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Applicant");

                    b.Navigation("ApplicationState");

                    b.Navigation("Bootcamp");
                });

            modelBuilder.Entity("Entities.Concretes.Blacklist", b =>
                {
                    b.HasOne("Entities.Concretes.Applicant", "Applicant")
                        .WithOne("Blacklist")
                        .HasForeignKey("Entities.Concretes.Blacklist", "ApplicantId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Applicant");
                });

            modelBuilder.Entity("Entities.Concretes.Bootcamp", b =>
                {
                    b.HasOne("Entities.Concretes.BootcampState", "BootcampState")
                        .WithMany()
                        .HasForeignKey("BootcampStateId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Entities.Concretes.Instructor", "Instructor")
                        .WithMany("Bootcamps")
                        .HasForeignKey("InstructorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("BootcampState");

                    b.Navigation("Instructor");
                });

            modelBuilder.Entity("Entities.Concretes.UserImage", b =>
                {
                    b.HasOne("Entities.Concretes.User", "User")
                        .WithMany("UserImages")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Entities.Concretes.Applicant", b =>
                {
                    b.HasOne("Entities.Concretes.User", null)
                        .WithOne()
                        .HasForeignKey("Entities.Concretes.Applicant", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Concretes.Employee", b =>
                {
                    b.HasOne("Entities.Concretes.User", null)
                        .WithOne()
                        .HasForeignKey("Entities.Concretes.Employee", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Concretes.Instructor", b =>
                {
                    b.HasOne("Entities.Concretes.User", null)
                        .WithOne()
                        .HasForeignKey("Entities.Concretes.Instructor", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Concretes.Bootcamp", b =>
                {
                    b.Navigation("Applications");
                });

            modelBuilder.Entity("Entities.Concretes.User", b =>
                {
                    b.Navigation("UserImages");
                });

            modelBuilder.Entity("Entities.Concretes.Applicant", b =>
                {
                    b.Navigation("Applications");

                    b.Navigation("Blacklist")
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Concretes.Instructor", b =>
                {
                    b.Navigation("Bootcamps");
                });
#pragma warning restore 612, 618
        }
    }
}
