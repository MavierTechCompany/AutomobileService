﻿// <auto-generated />
using AutomobileWebService.Business_Logic.Repositories.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace AutomobileWebService.Migrations
{
    [DbContext(typeof(AutomobileContext))]
    [Migration("20171225185654_MigrationV2")]
    partial class MigrationV2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Automobile")
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AutomobileWebService.Business_Logic.Models.Brand", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("EndDate")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("AutomobileWebService.Business_Logic.Models.Car", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("BrandId");

                    b.Property<string>("BrandName")
                        .IsRequired();

                    b.Property<int>("Generation");

                    b.Property<int>("Horsepower");

                    b.Property<string>("Model")
                        .IsRequired();

                    b.Property<DateTime>("ProdutionDate");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("AutomobileWebService.Business_Logic.Models.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CommentText")
                        .IsRequired();

                    b.Property<Guid>("CommenterId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<bool>("Deleted");

                    b.Property<Guid>("ProjectId");

                    b.HasKey("Id");

                    b.HasIndex("CommenterId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("AutomobileWebService.Business_Logic.Models.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CompanyAddressId");

                    b.Property<bool>("Deleted");

                    b.Property<DateTime>("FoundationDate");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Phone")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("AutomobileWebService.Business_Logic.Models.CompanyAddress", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BuildingNumber");

                    b.Property<Guid>("CompanyId");

                    b.Property<string>("Country")
                        .IsRequired();

                    b.Property<bool>("Deleted");

                    b.Property<int>("FlatNumber");

                    b.Property<string>("State")
                        .IsRequired();

                    b.Property<string>("Street")
                        .IsRequired();

                    b.Property<string>("Town")
                        .IsRequired();

                    b.Property<string>("ZipCode")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("CompanyId")
                        .IsUnique();

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("AutomobileWebService.Business_Logic.Models.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CarId");

                    b.Property<string>("Category")
                        .IsRequired();

                    b.Property<bool>("Deleted");

                    b.Property<string>("EngineModel")
                        .IsRequired();

                    b.Property<bool>("HasSupercharger");

                    b.Property<bool>("HasTurbochager");

                    b.Property<int>("Horsepower");

                    b.Property<string>("ProjectName")
                        .IsRequired();

                    b.Property<float>("TopSpeedInKilometers");

                    b.Property<float>("TopSpeedInMiles");

                    b.Property<Guid>("UserId");

                    b.Property<float>("ZeroToHundreds");

                    b.Property<float>("ZeroToSixty");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("UserId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("AutomobileWebService.Business_Logic.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<bool>("Deleted");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("HashedPassword")
                        .IsRequired();

                    b.Property<string>("Login")
                        .IsRequired();

                    b.Property<string>("MobilePhone")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AutomobileWebService.Business_Logic.Models.Car", b =>
                {
                    b.HasOne("AutomobileWebService.Business_Logic.Models.Brand", "Brand")
                        .WithMany("Cars")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("AutomobileWebService.Business_Logic.Models.Comment", b =>
                {
                    b.HasOne("AutomobileWebService.Business_Logic.Models.User", "Commenter")
                        .WithMany("Comments")
                        .HasForeignKey("CommenterId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("AutomobileWebService.Business_Logic.Models.Project", "Project")
                        .WithMany("Comments")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("AutomobileWebService.Business_Logic.Models.CompanyAddress", b =>
                {
                    b.HasOne("AutomobileWebService.Business_Logic.Models.Company", "Company")
                        .WithOne("CompanyAddress")
                        .HasForeignKey("AutomobileWebService.Business_Logic.Models.CompanyAddress", "CompanyId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("AutomobileWebService.Business_Logic.Models.Project", b =>
                {
                    b.HasOne("AutomobileWebService.Business_Logic.Models.Car", "Car")
                        .WithMany("Projects")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("AutomobileWebService.Business_Logic.Models.User", "User")
                        .WithMany("Projects")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
