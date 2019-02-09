﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sgs.Attendance.Reports.Data;

namespace Sgs.Attendance.Reports.Migrations
{
    [DbContext(typeof(AttendanceReportsDb))]
    [Migration("20190209194853_AddingProcessingRequests")]
    partial class AddingProcessingRequests
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Sgs.Attendance.Reports.Models.EmployeeCalendar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AttendanceProof");

                    b.Property<int>("ContractWorkTime");

                    b.Property<int>("EmployeeId");

                    b.Property<DateTime?>("EndDate");

                    b.Property<string>("Note");

                    b.Property<DateTime>("StartDate");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.ToTable("EmployeesCalendars");
                });

            modelBuilder.Entity("Sgs.Attendance.Reports.Models.EmployeeExcuse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmployeeId");

                    b.Property<DateTime>("ExcueseDate");

                    b.Property<double?>("ExcuseHours");

                    b.Property<int>("ExcuseType");

                    b.Property<string>("Note");

                    b.Property<DateTime>("RegisterDate");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.ToTable("EmployeesExcuses");
                });

            modelBuilder.Entity("Sgs.Attendance.Reports.Models.ProcessingRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Completed");

                    b.Property<string>("Employees");

                    b.Property<DateTime>("FromDate");

                    b.Property<DateTime>("RequestDate");

                    b.Property<DateTime>("ToDate");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.ToTable("ProcessingRequests");
                });
#pragma warning restore 612, 618
        }
    }
}
