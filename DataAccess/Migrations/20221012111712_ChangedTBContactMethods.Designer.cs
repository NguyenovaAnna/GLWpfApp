﻿// <auto-generated />
using System;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(EmployeesContext))]
    [Migration("20221012111712_ChangedTBContactMethods")]
    partial class ChangedTBContactMethods
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ContactMethodEmployee", b =>
                {
                    b.Property<int>("ContactMethodsId")
                        .HasColumnType("int");

                    b.Property<int>("EmployeesEmployeeNumber")
                        .HasColumnType("int");

                    b.HasKey("ContactMethodsId", "EmployeesEmployeeNumber");

                    b.HasIndex("EmployeesEmployeeNumber");

                    b.ToTable("ContactMethodEmployee");
                });

            modelBuilder.Entity("DataAccess.Entities.ContactMethod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ContactMethodType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactMethodValue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsSelected")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("ContactMethods");
                });

            modelBuilder.Entity("DataAccess.Entities.Employee", b =>
                {
                    b.Property<int>("EmployeeNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeNumber"), 1L, 1);

                    b.Property<DateTime>("ActivationTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ExpirationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NationalIdNumber")
                        .HasColumnType("int");

                    b.Property<int>("PersonellNumber")
                        .HasColumnType("int");

                    b.Property<int>("PreviousIdNumber")
                        .HasColumnType("int");

                    b.HasKey("EmployeeNumber");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("ContactMethodEmployee", b =>
                {
                    b.HasOne("DataAccess.Entities.ContactMethod", null)
                        .WithMany()
                        .HasForeignKey("ContactMethodsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccess.Entities.Employee", null)
                        .WithMany()
                        .HasForeignKey("EmployeesEmployeeNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}