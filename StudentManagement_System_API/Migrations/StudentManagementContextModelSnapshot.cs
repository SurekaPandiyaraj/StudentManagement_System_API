﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentManagement_System_API.Database;

#nullable disable

namespace StudentManagement_System_API.Migrations
{
    [DbContext(typeof(StudentManagementContext))]
    partial class StudentManagementContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StudentManagement_System_API.Entity.Attendance", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsPresent")
                        .HasColumnType("bit");

                    b.Property<string>("StudentUTNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("TimeSlotId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UTNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("StudentUTNumber");

                    b.HasIndex("TimeSlotId");

                    b.ToTable("Attendances");
                });

            modelBuilder.Entity("StudentManagement_System_API.Entity.Course", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("StudentManagement_System_API.Entity.Enrollment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EnrolledDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("StudentId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("StudentId");

                    b.ToTable("Enrollments");
                });

            modelBuilder.Entity("StudentManagement_System_API.Entity.Exam", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("CutOffMarks")
                        .HasColumnType("int");

                    b.Property<DateTime>("ExamDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Exams");
                });

            modelBuilder.Entity("StudentManagement_System_API.Entity.Marks", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ExamId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("bit");

                    b.Property<int?>("MarksObtained")
                        .HasColumnType("int");

                    b.Property<string>("StudentUTNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UTNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ExamId");

                    b.HasIndex("StudentUTNumber");

                    b.ToTable("Marks");
                });

            modelBuilder.Entity("StudentManagement_System_API.Entity.Student", b =>
                {
                    b.Property<string>("UTNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Batch")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UTNumber");

                    b.HasIndex("UserId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("StudentManagement_System_API.Entity.TimeSlot", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("ClassType")
                        .HasColumnType("int");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("time");

                    b.Property<Guid>("TimeTableId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("TimeTableId");

                    b.ToTable("TimeSlots");
                });

            modelBuilder.Entity("StudentManagement_System_API.Entity.Timetable", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Batch")
                        .HasColumnType("int");

                    b.Property<Guid?>("CourseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Day")
                        .HasColumnType("datetime2");

                    b.Property<int>("Week")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Timetables");
                });

            modelBuilder.Entity("StudentManagement_System_API.Entity.User", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NICNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserRole")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("StudentManagement_System_API.Entity.Attendance", b =>
                {
                    b.HasOne("StudentManagement_System_API.Entity.Student", "Student")
                        .WithMany("Attendances")
                        .HasForeignKey("StudentUTNumber");

                    b.HasOne("StudentManagement_System_API.Entity.TimeSlot", "TimeSlot")
                        .WithMany("Attendances")
                        .HasForeignKey("TimeSlotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("TimeSlot");
                });

            modelBuilder.Entity("StudentManagement_System_API.Entity.Enrollment", b =>
                {
                    b.HasOne("StudentManagement_System_API.Entity.Course", "course")
                        .WithMany("Enrollments")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentManagement_System_API.Entity.Student", "Student")
                        .WithMany("Enrollments")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("course");
                });

            modelBuilder.Entity("StudentManagement_System_API.Entity.Exam", b =>
                {
                    b.HasOne("StudentManagement_System_API.Entity.Course", "Course")
                        .WithMany("Exams")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("StudentManagement_System_API.Entity.Marks", b =>
                {
                    b.HasOne("StudentManagement_System_API.Entity.Exam", "Exam")
                        .WithMany("Marks")
                        .HasForeignKey("ExamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentManagement_System_API.Entity.Student", "Student")
                        .WithMany("Marks")
                        .HasForeignKey("StudentUTNumber");

                    b.Navigation("Exam");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("StudentManagement_System_API.Entity.Student", b =>
                {
                    b.HasOne("StudentManagement_System_API.Entity.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("StudentManagement_System_API.Entity.TimeSlot", b =>
                {
                    b.HasOne("StudentManagement_System_API.Entity.Course", "Course")
                        .WithMany("TimeSlotId")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentManagement_System_API.Entity.Timetable", "Timetable")
                        .WithMany("TimeSlot")
                        .HasForeignKey("TimeTableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Timetable");
                });

            modelBuilder.Entity("StudentManagement_System_API.Entity.Timetable", b =>
                {
                    b.HasOne("StudentManagement_System_API.Entity.Course", null)
                        .WithMany("Timetables")
                        .HasForeignKey("CourseId");
                });

            modelBuilder.Entity("StudentManagement_System_API.Entity.Course", b =>
                {
                    b.Navigation("Enrollments");

                    b.Navigation("Exams");

                    b.Navigation("TimeSlotId");

                    b.Navigation("Timetables");
                });

            modelBuilder.Entity("StudentManagement_System_API.Entity.Exam", b =>
                {
                    b.Navigation("Marks");
                });

            modelBuilder.Entity("StudentManagement_System_API.Entity.Student", b =>
                {
                    b.Navigation("Attendances");

                    b.Navigation("Enrollments");

                    b.Navigation("Marks");
                });

            modelBuilder.Entity("StudentManagement_System_API.Entity.TimeSlot", b =>
                {
                    b.Navigation("Attendances");
                });

            modelBuilder.Entity("StudentManagement_System_API.Entity.Timetable", b =>
                {
                    b.Navigation("TimeSlot");
                });
#pragma warning restore 612, 618
        }
    }
}
