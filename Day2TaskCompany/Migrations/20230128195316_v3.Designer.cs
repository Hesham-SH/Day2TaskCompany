﻿// <auto-generated />
using System;
using Day2TaskCompany.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Day2TaskCompany.Migrations
{
    [DbContext(typeof(CompanyDBContext))]
    [Migration("20230128195316_v3")]
    partial class v3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Day2TaskCompany.Models.Department", b =>
                {
                    b.Property<int>("Number")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Number"));

                    b.Property<int?>("EmpSSN")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Number");

                    b.HasIndex("EmpSSN")
                        .IsUnique()
                        .HasFilter("[EmpSSN] IS NOT NULL");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Day2TaskCompany.Models.DepartmentLocation", b =>
                {
                    b.Property<int>("DeptNumber")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("DeptNumber", "Location");

                    b.ToTable("DepartmentLocation");
                });

            modelBuilder.Entity("Day2TaskCompany.Models.Dependent", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("EmpSSN")
                        .HasColumnType("int");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("Relationship")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Name", "EmpSSN");

                    b.HasIndex("EmpSSN");

                    b.ToTable("Dependent");
                });

            modelBuilder.Entity("Day2TaskCompany.Models.Employee", b =>
                {
                    b.Property<int>("SSN")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SSN"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("date");

                    b.Property<int?>("DeptId")
                        .HasColumnType("int");

                    b.Property<string>("Fname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Minit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Salary")
                        .HasColumnType("money");

                    b.Property<string>("Sex")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SupervisorSSN")
                        .HasColumnType("int");

                    b.HasKey("SSN");

                    b.HasIndex("DeptId");

                    b.HasIndex("SupervisorSSN");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Day2TaskCompany.Models.Project", b =>
                {
                    b.Property<int>("Number")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Number"));

                    b.Property<int?>("DepartmentNumber")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("department")
                        .HasColumnType("int");

                    b.HasKey("Number");

                    b.HasIndex("DepartmentNumber");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Day2TaskCompany.Models.WorksOnProject", b =>
                {
                    b.Property<int?>("EmpSSN")
                        .HasColumnType("int");

                    b.Property<int?>("projNum")
                        .HasColumnType("int");

                    b.Property<string>("Hours")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmpSSN", "projNum");

                    b.HasIndex("projNum");

                    b.ToTable("WorksOnProjects");
                });

            modelBuilder.Entity("Day2TaskCompany.Models.Department", b =>
                {
                    b.HasOne("Day2TaskCompany.Models.Employee", "EmployeeManage")
                        .WithOne("Deptmanage")
                        .HasForeignKey("Day2TaskCompany.Models.Department", "EmpSSN");

                    b.Navigation("EmployeeManage");
                });

            modelBuilder.Entity("Day2TaskCompany.Models.DepartmentLocation", b =>
                {
                    b.HasOne("Day2TaskCompany.Models.Department", "Department")
                        .WithMany("DepartmentLocations")
                        .HasForeignKey("DeptNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Day2TaskCompany.Models.Dependent", b =>
                {
                    b.HasOne("Day2TaskCompany.Models.Employee", "Employee")
                        .WithMany("Dependents")
                        .HasForeignKey("EmpSSN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Day2TaskCompany.Models.Employee", b =>
                {
                    b.HasOne("Day2TaskCompany.Models.Department", "department")
                        .WithMany("Employees")
                        .HasForeignKey("DeptId");

                    b.HasOne("Day2TaskCompany.Models.Employee", "Supervisor")
                        .WithMany("Employees")
                        .HasForeignKey("SupervisorSSN");

                    b.Navigation("Supervisor");

                    b.Navigation("department");
                });

            modelBuilder.Entity("Day2TaskCompany.Models.Project", b =>
                {
                    b.HasOne("Day2TaskCompany.Models.Department", "Department")
                        .WithMany("Projects")
                        .HasForeignKey("DepartmentNumber");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Day2TaskCompany.Models.WorksOnProject", b =>
                {
                    b.HasOne("Day2TaskCompany.Models.Employee", "Employee")
                        .WithMany("WorksOnProjects")
                        .HasForeignKey("EmpSSN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Day2TaskCompany.Models.Project", "Project")
                        .WithMany("WorksOnProjects")
                        .HasForeignKey("projNum")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Day2TaskCompany.Models.Department", b =>
                {
                    b.Navigation("DepartmentLocations");

                    b.Navigation("Employees");

                    b.Navigation("Projects");
                });

            modelBuilder.Entity("Day2TaskCompany.Models.Employee", b =>
                {
                    b.Navigation("Dependents");

                    b.Navigation("Deptmanage");

                    b.Navigation("Employees");

                    b.Navigation("WorksOnProjects");
                });

            modelBuilder.Entity("Day2TaskCompany.Models.Project", b =>
                {
                    b.Navigation("WorksOnProjects");
                });
#pragma warning restore 612, 618
        }
    }
}