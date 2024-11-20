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
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsPresent")
                        .HasColumnType("bit");

                    b.Property<int>("TimetableId")
                        .HasColumnType("int");

                    b.Property<string>("UTNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("TimetableId");

                    b.HasIndex("UTNumber");

                    b.ToTable("Attendances");
                });

            modelBuilder.Entity("StudentManagement_System_API.Entity.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EnrolledDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("StudentUTNumber")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("StudentUTNumber");

                    b.ToTable("Enrollments");
                });

            modelBuilder.Entity("StudentManagement_System_API.Entity.Exam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int?>("CutOffMarks")
                        .HasColumnType("int");

                    b.Property<DateTime>("ExamDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("MaximumMarks")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Exams");
                });

            modelBuilder.Entity("StudentManagement_System_API.Entity.Marks", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ExamId")
                        .HasColumnType("int");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("bit");

                    b.Property<int?>("MarksObtained")
                        .HasColumnType("int");

                    b.Property<string>("UTNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ExamId");

                    b.HasIndex("UTNumber");

                    b.ToTable("Marks");
                });

            modelBuilder.Entity("StudentManagement_System_API.Entity.Student", b =>
                {
                    b.Property<string>("UTNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Batch")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("UserId1")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UTNumber");

                    b.HasIndex("UserId1");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("StudentManagement_System_API.Entity.Timetable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("time");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Timetables");
                });

            modelBuilder.Entity("StudentManagement_System_API.Entity.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserRole")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("StudentManagement_System_API.Entity.Attendance", b =>
                {
                    b.HasOne("StudentManagement_System_API.Entity.Timetable", "Timetable")
                        .WithMany("Attendances")
                        .HasForeignKey("TimetableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentManagement_System_API.Entity.Student", "Student")
                        .WithMany("Attendances")
                        .HasForeignKey("UTNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Timetable");
                });

            modelBuilder.Entity("StudentManagement_System_API.Entity.Enrollment", b =>
                {
                    b.HasOne("StudentManagement_System_API.Entity.Course", "course")
                        .WithMany("Enrollments")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentManagement_System_API.Entity.Student", null)
                        .WithMany("Enrollments")
                        .HasForeignKey("StudentUTNumber");

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
                        .HasForeignKey("UTNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exam");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("StudentManagement_System_API.Entity.Student", b =>
                {
                    b.HasOne("StudentManagement_System_API.Entity.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId1");

                    b.Navigation("User");
                });

            modelBuilder.Entity("StudentManagement_System_API.Entity.Timetable", b =>
                {
                    b.HasOne("StudentManagement_System_API.Entity.Course", "Course")
                        .WithMany("Timetables")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("StudentManagement_System_API.Entity.Course", b =>
                {
                    b.Navigation("Enrollments");

                    b.Navigation("Exams");

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

            modelBuilder.Entity("StudentManagement_System_API.Entity.Timetable", b =>
                {
                    b.Navigation("Attendances");
                });
#pragma warning restore 612, 618
        }
    }
}
