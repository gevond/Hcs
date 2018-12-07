﻿// <auto-generated />
using System;
using HardwareCheckoutSystemWebApi.Context.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HardwareCheckoutSystemWebApi.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("HardwareCheckoutSystemWebApi.Models.Brand", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("HardwareCheckoutSystemWebApi.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("HardwareCheckoutSystemWebApi.Models.Device", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("BrandId");

                    b.Property<Guid>("CategoryId");

                    b.Property<string>("Description");

                    b.Property<byte[]>("Image");

                    b.Property<int?>("MaxPeriod");

                    b.Property<string>("Model")
                        .HasMaxLength(50);

                    b.Property<int>("Permission");

                    b.Property<string>("SerialNumber")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Devices");
                });

            modelBuilder.Entity("HardwareCheckoutSystemWebApi.Models.Request", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("DeviceId");

                    b.Property<Guid?>("LastResponseId");

                    b.Property<string>("Message");

                    b.Property<DateTime?>("RentEndDate");

                    b.Property<DateTime?>("RentStartDate");

                    b.Property<DateTime>("RequestDate");

                    b.Property<int>("Status");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("DeviceId");

                    b.HasIndex("UserId");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("HardwareCheckoutSystemWebApi.Models.Response", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("Message");

                    b.Property<int>("NewStatus");

                    b.Property<Guid>("RequestId");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("RequestId");

                    b.HasIndex("UserId");

                    b.ToTable("Responses");
                });

            modelBuilder.Entity("HardwareCheckoutSystemWebApi.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<byte[]>("AvatarImage");

                    b.Property<DateTime>("Birthdate");

                    b.Property<string>("FirstName")
                        .HasMaxLength(25);

                    b.Property<string>("LastName")
                        .HasMaxLength(25);

                    b.Property<string>("Occupation")
                        .HasMaxLength(25);

                    b.Property<int>("Permission");

                    b.Property<string>("TelNumber")
                        .HasMaxLength(25);

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("HardwareCheckoutSystemWebApi.Models.Device", b =>
                {
                    b.HasOne("HardwareCheckoutSystemWebApi.Models.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HardwareCheckoutSystemWebApi.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HardwareCheckoutSystemWebApi.Models.Request", b =>
                {
                    b.HasOne("HardwareCheckoutSystemWebApi.Models.Device", "Device")
                        .WithMany()
                        .HasForeignKey("DeviceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HardwareCheckoutSystemWebApi.Models.User", "User")
                        .WithMany("Requests")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HardwareCheckoutSystemWebApi.Models.Response", b =>
                {
                    b.HasOne("HardwareCheckoutSystemWebApi.Models.Request", "Request")
                        .WithMany("Responses")
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HardwareCheckoutSystemWebApi.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
