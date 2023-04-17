﻿using System;
using System.ComponentModel.DataAnnotations.Schema;
using ELearning.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
//using MySql.Data.EntityFrameworkCore.Extensions;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;


#nullable disable

namespace ELearning.Models
{
    public partial class ElearningContext : DbContext
    {       
        public ElearningContext()
        {
        }

        public ElearningContext(DbContextOptions<ElearningContext> options)
            : base(options)
        {

        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Learning> Learnings { get; set; }
        public virtual DbSet<MainType> MainTypes { get; set; }
        public virtual DbSet<Require> Requires { get; set; }


        private const string connectionString = @"Server = 112.78.4.41; Port = 3306; UserID = ftisu;Password = ftisu@2022; Database=elearning;";

        // Phương thức OnConfiguring gọi mỗi khi một đối tượng DbContext được tạo
        // Nạp chồng nó để thiết lập các cấu hình, như thiết lập chuỗi kết nối
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new System.Version(8, 0, 31)));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "utf8mb4_unicode_520_ci");

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("roles");

                entity.HasKey(e => e.ID);

                entity.Property(p => p.ID)
                 .HasColumnName("id")
                 .ValueGeneratedOnAdd();

                entity.Property(e => e.RoleName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("role_name");

                entity.Property(e => e.RoleDescription)
                   .HasMaxLength(200)
                   .IsUnicode(false)
                   .HasColumnName("role_description");

            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID).HasColumnName("id");

                entity.Property(e => e.Username)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.Property(e => e.Email)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Password)
                   .HasMaxLength(200)
                   .IsUnicode(true)
                   .HasColumnName("password");

                entity.Property(e => e.Fullname)
                .HasMaxLength(200)
                   .IsUnicode(true)
                   .HasColumnName("fullname");

                entity.Property(e => e.Phone)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                // entity.HasOne(d => d.RoleNavigation)
                //.WithMany(p => p.Users)
                //.HasForeignKey(d => d.RoleID)
                //.OnDelete(DeleteBehavior.ClientSetNull)
                //.HasConstraintName("FK_user_REFERENCE_role");
            });

            modelBuilder.Entity<Learning>(entity =>
            {

                entity.ToTable("leanings");

                entity.HasKey(e => e.ID);

                entity.Property(p => p.ID)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.LessonID)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("lesson_id");

                entity.Property(e => e.UserID).HasColumnName("user_id");

                entity.Property(e => e.LearnTime)
                    .HasColumnType("datetime")
                    .HasColumnName("learn_time");

                entity.HasOne(d => d.UserNavigation)
                   .WithMany(p => p.Learnings)
                   .HasForeignKey(d => d.UserID)
                   .OnDelete(DeleteBehavior.ClientSetNull);
                   //.HasConstraintName("FK_LEARNING_REFERENCE_USER");

                entity.HasOne(d => d.LessonNavigation)
                 .WithOne(f => f.LearningNavigation)
                 .HasForeignKey<Learning>(d => d.LessonID)
                 .OnDelete(DeleteBehavior.ClientSetNull);
                 //.HasConstraintName("FK_LEARNING_REFERENCE_LESSON");
            });

            modelBuilder.Entity<Lesson>(entity =>
            {

                entity.ToTable("lessons");

                entity.HasKey(e => e.ID);

                entity.Property(p => p.ID)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ChapterID)
                    .HasColumnName("chapter_id");

                entity.Property(e => e.LessonName)
                  .HasMaxLength(200)
                  .IsUnicode(false)
                  .HasColumnName("lesson_name");

                entity.Property(e => e.LessonURL)
                  .HasMaxLength(200)
                  .IsUnicode(false)
                  .HasColumnName("lesson _url");

                entity.Property(e => e.Duration).HasColumnName("duration");

                entity.HasOne(d => d.ChapterNavigation)
                 .WithMany(f => f.Lessons)
                 .HasForeignKey(d => d.ChapterID)
                 .OnDelete(DeleteBehavior.ClientSetNull);
                 //.HasConstraintName("FK_LESSON_REFERENCE_CHAPTER");

            });

            modelBuilder.Entity<Review>(entity =>
            {

                entity.ToTable("reviews");

                entity.HasKey(e => e.ID);

                entity.Property(p => p.ID)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.UserID)
                    .HasColumnName("user_id");

                entity.Property(e => e.CourseID)
                    .HasColumnName("course_id");

                entity.Property(e => e.CourseReviewState)
                    .HasColumnName("course_review_state");

                entity.Property(e => e.Content)
                  .HasMaxLength(2000)
                  .IsUnicode(false)
                  .HasColumnName("content");


                entity.HasOne(d => d.UserNavigation)
                 .WithMany(f => f.Reviews)
                 .HasForeignKey(d => d.UserID)
                 .OnDelete(DeleteBehavior.ClientSetNull);
                 //.HasConstraintName("FK_REVIEW_REFERENCE_USER");

                entity.HasOne(d => d.CourseNavigation)
                 .WithMany(f => f.Reviews)
                 .HasForeignKey(d => d.UserID)
                 .OnDelete(DeleteBehavior.ClientSetNull);
                 //.HasConstraintName("FK_REVIEW_REFERENCE_COURSE");

            });

            modelBuilder.Entity<Approval>(entity =>
            {

                entity.ToTable("approvals");

                entity.HasKey(e => e.ID);

                entity.Property(p => p.ID)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CourseID)
                    .HasColumnName("course_id");

                entity.Property(e => e.UserID)
                    .HasColumnName("user_id");

                entity.Property(e => e.ApproveTime)
                .HasColumnType("datetime")
                .HasColumnName("approve_time");

                entity.Property(e => e.IsAccepted)
               .HasColumnName("is_accepted");

                entity.Property(e => e.Reason)
                  .HasMaxLength(200)
                  .IsUnicode(false)
                  .HasColumnName("reason");


                entity.HasOne(d => d.UserNavigation)
                 .WithMany(f => f.Approvals)
                 .HasForeignKey(d => d.UserID)
                 .OnDelete(DeleteBehavior.ClientSetNull);
                 //.HasConstraintName("FK_APPROVAL_REFERENCE_USER");

                entity.HasOne(d => d.CourseNavigation)
                 .WithMany(f => f.Approvals)
                 .HasForeignKey(d => d.CourseID)
                 .OnDelete(DeleteBehavior.ClientSetNull);
                 //.HasConstraintName("FK_APPROVAL_REFERENCE_COURSE");

            });

            modelBuilder.Entity<Require>(entity =>
            {

                entity.ToTable("requires");

                entity.HasKey(e => e.ID);

                entity.Property(p => p.ID)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CourseID)
                    .HasColumnName("course_id");

                entity.Property(e => e.Content)
                  .HasMaxLength(2000)
                  .IsUnicode(false)
                  .HasColumnName("reason");


                entity.HasOne(d => d.CourseNavigation)
                 .WithOne(f => f.RequireNavigation)
                 .HasForeignKey<Require>(d => d.CourseID)
                 .OnDelete(DeleteBehavior.ClientSetNull);
                 //.HasConstraintName("FK_REQUIRE_REFERENCE_COURSE");

            });

            modelBuilder.Entity<Chapter>(entity =>
            {

                entity.ToTable("chapters");

                entity.HasKey(e => e.ID);

                entity.Property(p => p.ID)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CourseID)
                    .HasColumnName("course_id");

                entity.Property(e => e.ChapterName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("chapter_name");

                entity.HasOne(d => d.CourseNavigation)
                 .WithMany(f => f.Chapters)
                 .HasForeignKey(d => d.CourseID)
                 .OnDelete(DeleteBehavior.ClientSetNull);
                 //.HasConstraintName("FK_CHAPTER_REFERENCE_COURSE");

            });

            modelBuilder.Entity<MainType>(entity =>
            {

                entity.ToTable("main_types");

                entity.HasKey(e => e.ID);

                entity.Property(p => p.ID)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.TypeName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("type_name");


            });

            modelBuilder.Entity<Course>(entity =>
            {

                entity.ToTable("course");

                entity.HasKey(e => e.ID);

                entity.Property(p => p.ID)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CourseTypeID)
                    .HasColumnName("course_type_id");


                entity.Property(e => e.CourseName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("course_name");

                entity.Property(e => e.CourseImage)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("course_image");


                entity.Property(e => e.CourseFee)
                    .HasColumnName("course_fee");

                entity.Property(e => e.CourseState)
                   .HasColumnName("course_state");

                entity.Property(e => e.Commission)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("commission");

                entity.HasOne(d => d.AuthorNavigation)
                 .WithMany(f => f.Courses)
                 .HasForeignKey(d => d.AuthorID)
                 .OnDelete(DeleteBehavior.ClientSetNull);
                 //.HasConstraintName("FK_COURSE_REFERENCE_USER");

                entity.HasOne(d => d.MainTypeNavigation)
                 .WithMany(f => f.Courses)
                 .HasForeignKey(d => d.CourseTypeID)
                 .OnDelete(DeleteBehavior.ClientSetNull);
                 //.HasConstraintName("FK_COURSE_REFERENCE_MAINTYPE");

            });


            OnModelCreatingPartial(modelBuilder);

        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
