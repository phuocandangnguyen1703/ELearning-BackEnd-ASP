﻿// <auto-generated />
using System;
using ELearning.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ELearning.Migrations
{
    [DbContext(typeof(ElearningContext))]
    [Migration("20230419172805_Edit_Table_Users")]
    partial class Edit_Table_Users
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("utf8mb4_unicode_520_ci")
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ELearning.Models.Approval", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateTime>("ApproveTime")
                        .HasColumnType("datetime")
                        .HasColumnName("approve_time");

                    b.Property<int>("CourseID")
                        .HasColumnType("int")
                        .HasColumnName("course_id");

                    b.Property<bool>("IsAccepted")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("is_accepted");

                    b.Property<bool>("Reason")
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("tinyint(200)")
                        .HasColumnName("reason");

                    b.Property<int>("UserID")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.HasKey("ID");

                    b.HasIndex("CourseID");

                    b.HasIndex("UserID");

                    b.ToTable("approvals", (string)null);
                });

            modelBuilder.Entity("ELearning.Models.Chapter", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("ChapterName")
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("chapter_name");

                    b.Property<int>("CourseID")
                        .HasColumnType("int")
                        .HasColumnName("course_id");

                    b.HasKey("ID");

                    b.HasIndex("CourseID");

                    b.ToTable("chapters", (string)null);
                });

            modelBuilder.Entity("ELearning.Models.Course", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int>("AuthorID")
                        .HasColumnType("int");

                    b.Property<int>("Commission")
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("int")
                        .HasColumnName("commission");

                    b.Property<int>("CourseFee")
                        .HasColumnType("int")
                        .HasColumnName("course_fee");

                    b.Property<string>("CourseImage")
                        .HasMaxLength(2000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(2000)")
                        .HasColumnName("course_image");

                    b.Property<string>("CourseName")
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("course_name");

                    b.Property<int>("CourseState")
                        .HasColumnType("int")
                        .HasColumnName("course_state");

                    b.Property<int>("CourseTypeID")
                        .HasColumnType("int")
                        .HasColumnName("course_type_id");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<int?>("LessonNavigationID")
                        .HasColumnType("int");

                    b.Property<int?>("UserNavigationID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("AuthorID");

                    b.HasIndex("CourseTypeID");

                    b.HasIndex("LessonNavigationID");

                    b.HasIndex("UserNavigationID");

                    b.ToTable("course", (string)null);
                });

            modelBuilder.Entity("ELearning.Models.Learning", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateTime>("LearnTime")
                        .HasColumnType("datetime")
                        .HasColumnName("learn_time");

                    b.Property<int>("LessonID")
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("int")
                        .HasColumnName("lesson_id");

                    b.Property<int>("UserID")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.HasKey("ID");

                    b.HasIndex("LessonID")
                        .IsUnique();

                    b.HasIndex("UserID");

                    b.ToTable("leanings", (string)null);
                });

            modelBuilder.Entity("ELearning.Models.Lesson", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int>("ChapterID")
                        .HasColumnType("int")
                        .HasColumnName("chapter_id");

                    b.Property<int>("Duration")
                        .HasColumnType("int")
                        .HasColumnName("duration");

                    b.Property<string>("LessonName")
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("lesson_name");

                    b.Property<string>("LessonURL")
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("lesson _url");

                    b.HasKey("ID");

                    b.HasIndex("ChapterID");

                    b.ToTable("lessons", (string)null);
                });

            modelBuilder.Entity("ELearning.Models.MainType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("TypeName")
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("type_name");

                    b.HasKey("ID");

                    b.ToTable("main_types", (string)null);
                });

            modelBuilder.Entity("ELearning.Models.Require", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Content")
                        .HasMaxLength(2000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(2000)")
                        .HasColumnName("reason");

                    b.Property<int>("CourseID")
                        .HasColumnType("int")
                        .HasColumnName("course_id");

                    b.HasKey("ID");

                    b.HasIndex("CourseID")
                        .IsUnique();

                    b.ToTable("requires", (string)null);
                });

            modelBuilder.Entity("ELearning.Models.Review", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Content")
                        .HasMaxLength(2000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(2000)")
                        .HasColumnName("content");

                    b.Property<int>("CourseID")
                        .HasColumnType("int")
                        .HasColumnName("course_id");

                    b.Property<int>("CourseReviewState")
                        .HasColumnType("int")
                        .HasColumnName("course_review_state");

                    b.Property<int>("UserID")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("reviews", (string)null);
                });

            modelBuilder.Entity("ELearning.Models.Role", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("RoleDescription")
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("role_description");

                    b.Property<string>("RoleName")
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("role_name");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("roles", (string)null);
                });

            modelBuilder.Entity("ELearning.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Biography")
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)")
                        .HasColumnName("biography");

                    b.Property<DateTime>("Birthday")
                        .IsUnicode(false)
                        .HasColumnType("datetime(6)")
                        .HasColumnName("birthday");

                    b.Property<DateTime>("Create_at")
                        .ValueGeneratedOnAdd()
                        .IsUnicode(false)
                        .HasColumnType("datetime(6)")
                        .HasDefaultValue(new DateTime(2023, 4, 20, 0, 28, 5, 22, DateTimeKind.Local).AddTicks(8766))
                        .HasColumnName("create_at");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("email");

                    b.Property<string>("Facebook")
                        .HasMaxLength(11)
                        .IsUnicode(false)
                        .HasColumnType("varchar(11)")
                        .HasColumnName("facebook");

                    b.Property<string>("Fullname")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(true)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("fullname");

                    b.Property<int>("Is_active")
                        .ValueGeneratedOnAdd()
                        .IsUnicode(false)
                        .HasColumnType("int")
                        .HasDefaultValue(1)
                        .HasColumnName("is_active");

                    b.Property<int>("Is_deleted")
                        .ValueGeneratedOnAdd()
                        .IsUnicode(false)
                        .HasColumnType("int")
                        .HasDefaultValue(0)
                        .HasColumnName("is_deleted");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(true)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("password");

                    b.Property<string>("Phone")
                        .HasMaxLength(11)
                        .IsUnicode(false)
                        .HasColumnType("varchar(11)")
                        .HasColumnName("phone");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<DateTime>("Update_at")
                        .ValueGeneratedOnAdd()
                        .IsUnicode(false)
                        .HasColumnType("datetime(6)")
                        .HasDefaultValue(new DateTime(2023, 4, 20, 0, 28, 5, 22, DateTimeKind.Local).AddTicks(9035))
                        .HasColumnName("update_at");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("username");

                    b.HasKey("ID");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("ELearning.Models.Approval", b =>
                {
                    b.HasOne("ELearning.Models.Course", "CourseNavigation")
                        .WithMany("Approvals")
                        .HasForeignKey("CourseID")
                        .IsRequired();

                    b.HasOne("ELearning.Models.User", "UserNavigation")
                        .WithMany("Approvals")
                        .HasForeignKey("UserID")
                        .IsRequired();

                    b.Navigation("CourseNavigation");

                    b.Navigation("UserNavigation");
                });

            modelBuilder.Entity("ELearning.Models.Chapter", b =>
                {
                    b.HasOne("ELearning.Models.Course", "CourseNavigation")
                        .WithMany("Chapters")
                        .HasForeignKey("CourseID")
                        .IsRequired();

                    b.Navigation("CourseNavigation");
                });

            modelBuilder.Entity("ELearning.Models.Course", b =>
                {
                    b.HasOne("ELearning.Models.User", "AuthorNavigation")
                        .WithMany("Courses")
                        .HasForeignKey("AuthorID")
                        .IsRequired();

                    b.HasOne("ELearning.Models.MainType", "MainTypeNavigation")
                        .WithMany("Courses")
                        .HasForeignKey("CourseTypeID")
                        .IsRequired();

                    b.HasOne("ELearning.Models.Lesson", "LessonNavigation")
                        .WithMany()
                        .HasForeignKey("LessonNavigationID");

                    b.HasOne("ELearning.Models.User", "UserNavigation")
                        .WithMany()
                        .HasForeignKey("UserNavigationID");

                    b.Navigation("AuthorNavigation");

                    b.Navigation("LessonNavigation");

                    b.Navigation("MainTypeNavigation");

                    b.Navigation("UserNavigation");
                });

            modelBuilder.Entity("ELearning.Models.Learning", b =>
                {
                    b.HasOne("ELearning.Models.Lesson", "LessonNavigation")
                        .WithOne("LearningNavigation")
                        .HasForeignKey("ELearning.Models.Learning", "LessonID")
                        .IsRequired();

                    b.HasOne("ELearning.Models.User", "UserNavigation")
                        .WithMany("Learnings")
                        .HasForeignKey("UserID")
                        .IsRequired();

                    b.Navigation("LessonNavigation");

                    b.Navigation("UserNavigation");
                });

            modelBuilder.Entity("ELearning.Models.Lesson", b =>
                {
                    b.HasOne("ELearning.Models.Chapter", "ChapterNavigation")
                        .WithMany("Lessons")
                        .HasForeignKey("ChapterID")
                        .IsRequired();

                    b.Navigation("ChapterNavigation");
                });

            modelBuilder.Entity("ELearning.Models.Require", b =>
                {
                    b.HasOne("ELearning.Models.Course", "CourseNavigation")
                        .WithOne("RequireNavigation")
                        .HasForeignKey("ELearning.Models.Require", "CourseID")
                        .IsRequired();

                    b.Navigation("CourseNavigation");
                });

            modelBuilder.Entity("ELearning.Models.Review", b =>
                {
                    b.HasOne("ELearning.Models.Course", "CourseNavigation")
                        .WithMany("Reviews")
                        .HasForeignKey("UserID")
                        .IsRequired();

                    b.HasOne("ELearning.Models.User", "UserNavigation")
                        .WithMany("Reviews")
                        .HasForeignKey("UserID")
                        .IsRequired();

                    b.Navigation("CourseNavigation");

                    b.Navigation("UserNavigation");
                });

            modelBuilder.Entity("ELearning.Models.Chapter", b =>
                {
                    b.Navigation("Lessons");
                });

            modelBuilder.Entity("ELearning.Models.Course", b =>
                {
                    b.Navigation("Approvals");

                    b.Navigation("Chapters");

                    b.Navigation("RequireNavigation");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("ELearning.Models.Lesson", b =>
                {
                    b.Navigation("LearningNavigation");
                });

            modelBuilder.Entity("ELearning.Models.MainType", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("ELearning.Models.User", b =>
                {
                    b.Navigation("Approvals");

                    b.Navigation("Courses");

                    b.Navigation("Learnings");

                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
