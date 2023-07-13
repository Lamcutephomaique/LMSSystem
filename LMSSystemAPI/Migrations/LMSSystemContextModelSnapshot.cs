﻿// <auto-generated />
using System;
using LMSSystemAPI.Dbcontext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LMSSystemAPI.Migrations
{
    [DbContext(typeof(LMSSystemContext))]
    partial class LMSSystemContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LMSSystemAPI.Models.Answer", b =>
                {
                    b.Property<int>("AnswerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AnswerId"));

                    b.Property<string>("AnswerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("AnswerId");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answer");
                });

            modelBuilder.Entity("LMSSystemAPI.Models.Class", b =>
                {
                    b.Property<int>("ClassId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClassId"));

                    b.Property<string>("ClassName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClassId");

                    b.ToTable("Class");
                });

            modelBuilder.Entity("LMSSystemAPI.Models.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .HasColumnType("int");

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TopicId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CommentId");

                    b.HasIndex("TopicId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("LMSSystemAPI.Models.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseId"));

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("CourseId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("LMSSystemAPI.Models.Exam", b =>
                {
                    b.Property<int>("ExamId")
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ExamName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.Property<int>("Time")
                        .HasColumnType("int");

                    b.HasKey("ExamId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Exam");
                });

            modelBuilder.Entity("LMSSystemAPI.Models.Faculty", b =>
                {
                    b.Property<int>("FacultytId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FacultytId"));

                    b.Property<string>("FacultytName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FacultytId");

                    b.ToTable("Faculty");
                });

            modelBuilder.Entity("LMSSystemAPI.Models.Lesson", b =>
                {
                    b.Property<int>("LessonID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LessonID"));

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LessonName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Time")
                        .HasColumnType("int");

                    b.Property<int>("TopicId")
                        .HasColumnType("int");

                    b.HasKey("LessonID");

                    b.HasIndex("TopicId");

                    b.ToTable("Lesson");
                });

            modelBuilder.Entity("LMSSystemAPI.Models.Notification", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "TeacherId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Notification");
                });

            modelBuilder.Entity("LMSSystemAPI.Models.Question", b =>
                {
                    b.Property<int>("QuestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QuestionId"));

                    b.Property<int>("ExamId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("QuestionId");

                    b.HasIndex("ExamId");

                    b.ToTable("Question");
                });

            modelBuilder.Entity("LMSSystemAPI.Models.Reply", b =>
                {
                    b.Property<int>("ReplyId")
                        .HasColumnType("int");

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CommentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ReplyId");

                    b.HasIndex("CommentId");

                    b.ToTable("Reply");
                });

            modelBuilder.Entity("LMSSystemAPI.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"));

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("LMSSystemAPI.Models.Teacher", b =>
                {
                    b.Property<int>("TeacherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeacherId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("TeacherName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TeacherId");

                    b.HasIndex("RoleId");

                    b.ToTable("Teacher");
                });

            modelBuilder.Entity("LMSSystemAPI.Models.Topic", b =>
                {
                    b.Property<int>("TopicId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TopicId"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("TopicName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TopicId");

                    b.HasIndex("CourseId");

                    b.ToTable("Topic");
                });

            modelBuilder.Entity("LMSSystemAPI.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FacultytId")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex("ClassId");

                    b.HasIndex("FacultytId");

                    b.HasIndex("RoleId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("LMSSystemAPI.Models.UserCourse", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "CourseId");

                    b.HasIndex("CourseId");

                    b.ToTable("UserCourse");
                });

            modelBuilder.Entity("LMSSystemAPI.Models.Answer", b =>
                {
                    b.HasOne("LMSSystemAPI.Models.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("LMSSystemAPI.Models.Comment", b =>
                {
                    b.HasOne("LMSSystemAPI.Models.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("CommentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("LMSSystemAPI.Models.Topic", "Topic")
                        .WithMany("Comments")
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Topic");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LMSSystemAPI.Models.Course", b =>
                {
                    b.HasOne("LMSSystemAPI.Models.Teacher", "Teacher")
                        .WithMany("Courses")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("LMSSystemAPI.Models.Exam", b =>
                {
                    b.HasOne("LMSSystemAPI.Models.Course", "Course")
                        .WithMany("Exams")
                        .HasForeignKey("ExamId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("LMSSystemAPI.Models.Teacher", "Teacher")
                        .WithMany("Exams")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("LMSSystemAPI.Models.Lesson", b =>
                {
                    b.HasOne("LMSSystemAPI.Models.Topic", "Topic")
                        .WithMany("Lessons")
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Topic");
                });

            modelBuilder.Entity("LMSSystemAPI.Models.Notification", b =>
                {
                    b.HasOne("LMSSystemAPI.Models.Teacher", "Teacher")
                        .WithMany("Notifications")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("LMSSystemAPI.Models.User", "User")
                        .WithMany("Notifications")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Teacher");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LMSSystemAPI.Models.Question", b =>
                {
                    b.HasOne("LMSSystemAPI.Models.Exam", "Exam")
                        .WithMany("Questions")
                        .HasForeignKey("ExamId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Exam");
                });

            modelBuilder.Entity("LMSSystemAPI.Models.Reply", b =>
                {
                    b.HasOne("LMSSystemAPI.Models.Comment", "Comment")
                        .WithMany("Replys")
                        .HasForeignKey("CommentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("LMSSystemAPI.Models.User", "User")
                        .WithMany("Replys")
                        .HasForeignKey("ReplyId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Comment");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LMSSystemAPI.Models.Teacher", b =>
                {
                    b.HasOne("LMSSystemAPI.Models.Role", "Role")
                        .WithMany("Teachers")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("LMSSystemAPI.Models.Topic", b =>
                {
                    b.HasOne("LMSSystemAPI.Models.Course", "Course")
                        .WithMany("Topics")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("LMSSystemAPI.Models.User", b =>
                {
                    b.HasOne("LMSSystemAPI.Models.Class", "Class")
                        .WithMany("Users")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("LMSSystemAPI.Models.Faculty", "Faculty")
                        .WithMany("Users")
                        .HasForeignKey("FacultytId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("LMSSystemAPI.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("Faculty");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("LMSSystemAPI.Models.UserCourse", b =>
                {
                    b.HasOne("LMSSystemAPI.Models.Course", "Course")
                        .WithMany("UserCourses")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("LMSSystemAPI.Models.User", "User")
                        .WithMany("UserCourses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LMSSystemAPI.Models.Class", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("LMSSystemAPI.Models.Comment", b =>
                {
                    b.Navigation("Replys");
                });

            modelBuilder.Entity("LMSSystemAPI.Models.Course", b =>
                {
                    b.Navigation("Exams");

                    b.Navigation("Topics");

                    b.Navigation("UserCourses");
                });

            modelBuilder.Entity("LMSSystemAPI.Models.Exam", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("LMSSystemAPI.Models.Faculty", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("LMSSystemAPI.Models.Question", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("LMSSystemAPI.Models.Role", b =>
                {
                    b.Navigation("Teachers");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("LMSSystemAPI.Models.Teacher", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("Exams");

                    b.Navigation("Notifications");
                });

            modelBuilder.Entity("LMSSystemAPI.Models.Topic", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Lessons");
                });

            modelBuilder.Entity("LMSSystemAPI.Models.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Notifications");

                    b.Navigation("Replys");

                    b.Navigation("UserCourses");
                });
#pragma warning restore 612, 618
        }
    }
}
