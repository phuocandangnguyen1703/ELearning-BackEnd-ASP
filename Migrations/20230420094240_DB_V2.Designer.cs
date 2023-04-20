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
    [Migration("20230420094240_DB_V2")]
    partial class DB_V2
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

                    b.Property<DateTime>("Create_at")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasColumnName("create_at")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<bool>("IsAccepted")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("is_accepted");

                    b.Property<int>("Is_active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("is_active")
                        .HasDefaultValueSql("'1'");

                    b.Property<int>("Is_deleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("is_deleted")
                        .HasDefaultValueSql("'0'");

                    b.Property<bool>("Reason")
                        .HasMaxLength(200)
                        .IsUnicode(true)
                        .HasColumnType("tinyint(200)")
                        .HasColumnName("reason");

                    b.Property<DateTime>("Update_at")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp")
                        .HasColumnName("update_at")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

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
                        .IsUnicode(true)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("chapter_name");

                    b.Property<int>("CourseID")
                        .HasColumnType("int")
                        .HasColumnName("course_id");

                    b.Property<DateTime>("Create_at")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasColumnName("create_at")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int>("Is_active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("is_active")
                        .HasDefaultValueSql("'1'");

                    b.Property<int>("Is_deleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("is_deleted")
                        .HasDefaultValueSql("'0'");

                    b.Property<DateTime>("Update_at")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp")
                        .HasColumnName("update_at")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

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
                        .IsUnicode(true)
                        .HasColumnType("int")
                        .HasColumnName("commission");

                    b.Property<int>("CourseFee")
                        .HasColumnType("int")
                        .HasColumnName("course_fee");

                    b.Property<string>("CourseImage")
                        .HasMaxLength(2000)
                        .IsUnicode(true)
                        .HasColumnType("varchar(2000)")
                        .HasColumnName("course_image");

                    b.Property<string>("CourseName")
                        .HasMaxLength(200)
                        .IsUnicode(true)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("course_name");

                    b.Property<int>("CourseState")
                        .HasColumnType("int")
                        .HasColumnName("course_state");

                    b.Property<int>("CourseTypeID")
                        .HasColumnType("int")
                        .HasColumnName("course_type_id");

                    b.Property<DateTime>("Create_at")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasColumnName("create_at")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<int>("Is_active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("is_active")
                        .HasDefaultValueSql("'1'");

                    b.Property<int>("Is_deleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("is_deleted")
                        .HasDefaultValueSql("'0'");

                    b.Property<int?>("LessonNavigationID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Update_at")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp")
                        .HasColumnName("update_at")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

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

                    b.Property<DateTime>("Create_at")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasColumnName("create_at")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int>("Is_deleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("is_deleted")
                        .HasDefaultValueSql("'0'");

                    b.Property<TimeSpan>("LearnTime")
                        .HasColumnType("time")
                        .HasColumnName("learn_time");

                    b.Property<int>("LessonID")
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("int")
                        .HasColumnName("lesson_id");

                    b.Property<DateTime>("Update_at")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp")
                        .HasColumnName("update_at")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

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

                    b.Property<DateTime>("Create_at")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasColumnName("create_at")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time")
                        .HasColumnName("duration");

                    b.Property<int>("Is_active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("is_active")
                        .HasDefaultValueSql("'1'");

                    b.Property<int>("Is_deleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("is_deleted")
                        .HasDefaultValueSql("'0'");

                    b.Property<string>("LessonName")
                        .HasMaxLength(200)
                        .IsUnicode(true)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("lesson_name");

                    b.Property<string>("LessonURL")
                        .HasMaxLength(200)
                        .IsUnicode(true)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("lesson _url");

                    b.Property<DateTime>("Update_at")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp")
                        .HasColumnName("update_at")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

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

                    b.Property<DateTime>("Create_at")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasColumnName("create_at")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int>("Is_active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("is_active")
                        .HasDefaultValueSql("'1'");

                    b.Property<int>("Is_deleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("is_deleted")
                        .HasDefaultValueSql("'0'");

                    b.Property<string>("TypeName")
                        .HasMaxLength(200)
                        .IsUnicode(true)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("type_name");

                    b.Property<DateTime>("Update_at")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp")
                        .HasColumnName("update_at")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

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
                        .IsUnicode(true)
                        .HasColumnType("varchar(2000)")
                        .HasColumnName("content");

                    b.Property<int>("CourseID")
                        .HasColumnType("int")
                        .HasColumnName("course_id");

                    b.Property<DateTime>("Create_at")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasColumnName("create_at")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int>("Is_active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("is_active")
                        .HasDefaultValueSql("'1'");

                    b.Property<int>("Is_deleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("is_deleted")
                        .HasDefaultValueSql("'0'");

                    b.Property<DateTime>("Update_at")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp")
                        .HasColumnName("update_at")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

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
                        .IsUnicode(true)
                        .HasColumnType("varchar(2000)")
                        .HasColumnName("content");

                    b.Property<int>("CourseID")
                        .HasColumnType("int")
                        .HasColumnName("course_id");

                    b.Property<int>("CourseReviewState")
                        .HasColumnType("int")
                        .HasColumnName("course_review_state");

                    b.Property<DateTime>("Create_at")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasColumnName("create_at")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int>("Is_deleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("is_deleted")
                        .HasDefaultValueSql("'0'");

                    b.Property<DateTime>("Update_at")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp")
                        .HasColumnName("update_at")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int>("UserID")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.HasKey("ID");

                    b.HasIndex("CourseID");

                    b.HasIndex("UserID");

                    b.ToTable("reviews", (string)null);
                });

            modelBuilder.Entity("ELearning.Models.Role", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateTime>("Create_at")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasColumnName("create_at")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int>("Is_active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("is_active")
                        .HasDefaultValueSql("'1'");

                    b.Property<int>("Is_deleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("is_deleted")
                        .HasDefaultValueSql("'0'");

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

                    b.Property<DateTime>("Update_at")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp")
                        .HasColumnName("update_at")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("ID");

                    b.ToTable("roles", (string)null);
                });

            modelBuilder.Entity("ELearning.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Avt_img")
                        .HasMaxLength(2000)
                        .IsUnicode(true)
                        .HasColumnType("varchar(2000)")
                        .HasColumnName("avt_img");

                    b.Property<string>("Background_img")
                        .HasMaxLength(2000)
                        .IsUnicode(true)
                        .HasColumnType("varchar(2000)")
                        .HasColumnName("background_img");

                    b.Property<string>("Biography")
                        .HasMaxLength(250)
                        .IsUnicode(true)
                        .HasColumnType("varchar(250)")
                        .HasColumnName("biography");

                    b.Property<DateTime?>("Birthday")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("datetime(6)")
                        .HasColumnName("birthday");

                    b.Property<DateTime>("Create_at")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasColumnName("create_at")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("email");

                    b.Property<string>("Email_verified_at")
                        .HasColumnType("longtext");

                    b.Property<string>("Facebook")
                        .HasMaxLength(250)
                        .IsUnicode(true)
                        .HasColumnType("varchar(250)")
                        .HasColumnName("facebook");

                    b.Property<string>("Fullname")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(true)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("fullname");

                    b.Property<int>("Is_active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("is_active")
                        .HasDefaultValueSql("'1'");

                    b.Property<int>("Is_deleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("is_deleted")
                        .HasDefaultValueSql("'0'");

                    b.Property<string>("Job")
                        .HasMaxLength(250)
                        .IsUnicode(true)
                        .HasColumnType("varchar(250)")
                        .HasColumnName("job");

                    b.Property<string>("Linkedin")
                        .HasMaxLength(250)
                        .IsUnicode(true)
                        .HasColumnType("varchar(250)")
                        .HasColumnName("linkedin");

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
                        .HasColumnType("int")
                        .HasColumnName("role_id");

                    b.Property<DateTime>("Update_at")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp")
                        .HasColumnName("update_at")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

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
                        .HasForeignKey("CourseID")
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
