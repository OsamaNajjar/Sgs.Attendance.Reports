﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sgs.Attendance.Reports.Data;

namespace Sgs.Attendance.Reports.Migrations
{
    [DbContext(typeof(AttendanceReportsDb))]
    partial class AttendanceReportsDbModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("Sgs.Attendance.Reports.Models.EmployeeDayReport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("ActualCheckInDateTime");

                    b.Property<DateTime?>("ActualCheckOutDateTime");

                    b.Property<double>("ActualWorkDuration");

                    b.Property<TimeSpan>("ActualWorkDurationTime");

                    b.Property<int>("AttendanceProof");

                    b.Property<DateTime?>("CheckInDateTime");

                    b.Property<bool>("CheckInExcuse");

                    b.Property<double>("CheckInExcuseHours");

                    b.Property<double>("CheckInLateDuration");

                    b.Property<TimeSpan>("CheckInLateDurationTime");

                    b.Property<DateTime?>("CheckOutDateTime");

                    b.Property<double>("CheckOutEarlyDuration");

                    b.Property<TimeSpan>("CheckOutEarlyDurationTime");

                    b.Property<bool>("CheckOutExcuse");

                    b.Property<double>("CheckOutExcuseHours");

                    b.Property<DateTime?>("ContractCheckInDateTime");

                    b.Property<DateTime?>("ContractCheckOutDateTime");

                    b.Property<double>("ContractWorkDuration");

                    b.Property<TimeSpan>("ContractWorkDurationTime");

                    b.Property<DateTime>("DayDate");

                    b.Property<DateTime?>("DelegationRegisterDate");

                    b.Property<int>("EmployeeId");

                    b.Property<bool>("IsAbsentEmployee");

                    b.Property<bool>("IsDelegationRequest");

                    b.Property<bool>("IsVacation");

                    b.Property<DateTime>("ProcessingDate");

                    b.Property<DateTime?>("VacationRegisterDate");

                    b.Property<string>("VacationTypeName");

                    b.Property<double>("WasteDuration");

                    b.Property<TimeSpan>("WasteDurationTime");

                    b.Property<double>("WorkDuration");

                    b.Property<TimeSpan>("WorkDurationTime");

                    b.HasKey("Id");

                    b.ToTable("EmployeeDaysReports");
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

            modelBuilder.Entity("Sgs.Attendance.Reports.Models.WorkCalendar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ContractWorkTime");

                    b.Property<DateTime?>("EndDate");

                    b.Property<bool>("IsVacationCalendar");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Note");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.ToTable("WorkCalendars");
                });

            modelBuilder.Entity("Sgs.Attendance.Reports.Models.WorkShift", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DayOffDescription");

                    b.Property<string>("DayOffDescriptionInRamadan");

                    b.Property<bool>("IsDayOff");

                    b.Property<bool?>("IsDayOffInRamadan");

                    b.Property<double?>("ShiftEnd");

                    b.Property<double?>("ShiftEndInRamadan");

                    b.Property<int>("ShiftOrder");

                    b.Property<bool>("ShiftRepeat");

                    b.Property<double?>("ShiftStart");

                    b.Property<double?>("ShiftStartInRamadan");

                    b.Property<int>("WorkCalendarId");

                    b.HasKey("Id");

                    b.HasIndex("WorkCalendarId");

                    b.ToTable("WorkShifts");
                });

            modelBuilder.Entity("Sgs.Attendance.Reports.Models.WorkShift", b =>
                {
                    b.HasOne("Sgs.Attendance.Reports.Models.WorkCalendar", "WorkCalendar")
                        .WithMany("WorkShifts")
                        .HasForeignKey("WorkCalendarId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
