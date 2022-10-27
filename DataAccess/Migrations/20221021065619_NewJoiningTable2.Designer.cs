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
    [Migration("20221021065619_NewJoiningTable2")]
    partial class NewJoiningTable2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DataAccess.Entities.ContactMethod", b =>
                {
                    b.Property<int>("ContactMethodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContactMethodId"), 1L, 1);

                    b.Property<string>("ContactMethodType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ContactMethodId");

                    b.ToTable("ContactMethod");
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

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("DataAccess.Entities.EmployeeContactMethod", b =>
                {
                    b.Property<int>("EmployeeNumber")
                        .HasColumnType("int");

                    b.Property<int>("ContactMethodId")
                        .HasColumnType("int");

                    b.Property<string>("ContactMethodValue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsSelected")
                        .HasColumnType("bit");

                    b.HasKey("EmployeeNumber", "ContactMethodId");

                    b.HasIndex("ContactMethodId");

                    b.ToTable("EmployeeContactMethod");
                });

            modelBuilder.Entity("DataAccess.Entities.EmployeeContactMethod", b =>
                {
                    b.HasOne("DataAccess.Entities.ContactMethod", "ContactMethod")
                        .WithMany("Employees")
                        .HasForeignKey("ContactMethodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccess.Entities.Employee", "Employee")
                        .WithMany("EmployeeContactMethods")
                        .HasForeignKey("EmployeeNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ContactMethod");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("DataAccess.Entities.ContactMethod", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("DataAccess.Entities.Employee", b =>
                {
                    b.Navigation("EmployeeContactMethods");
                });
#pragma warning restore 612, 618
        }
    }
}
