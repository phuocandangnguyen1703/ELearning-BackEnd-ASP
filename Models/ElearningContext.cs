using System;
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
        public virtual DbSet<Tag> Tag { get; set; }
        public virtual DbSet<Chapter> Chapters { get; set; }
        public virtual DbSet<Lesson> Lessons{ get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<CourseMix> CourseMix { get; set; }



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

                entity.Property(e => e.Is_active)
                    .HasDefaultValueSql("1")
                    .HasColumnName("is_active");

                entity.Property(e => e.Is_deleted)
                    .HasColumnName("is_deleted")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Create_at)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasColumnType("timestamp")
                    .HasColumnName("create_at");

                entity.Property(e => e.Update_at)
                    .ValueGeneratedOnAddOrUpdate()
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasColumnType("timestamp")
                    .HasColumnName("update_at");

            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID).HasColumnName("id");

                entity.Property(e => e.Role).
                    HasColumnName("role_id");

                entity.Property(e => e.Username)
                    .HasMaxLength(200)
                    .IsRequired(true)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.Property(e => e.Email)
                    .HasMaxLength(200)
                    .IsRequired(true)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Password)
                   .HasMaxLength(200)
                   .IsRequired(true)
                   .IsUnicode(true)
                   .HasColumnName("password");

                entity.Property(e => e.Fullname)
                   .HasMaxLength(200)
                   .IsRequired(true)
                   .IsUnicode(true)
                   .HasColumnName("fullname");

                entity.Property(e => e.Phone)
                    .HasMaxLength(11)
                    .IsUnicode(false)

                    .HasColumnName("phone");

                entity.Property(e => e.Biography)
                    .HasMaxLength(250)
                    .IsUnicode(true)
                    .IsRequired(false)
                    .HasColumnName("biography");

                entity.Property(e => e.Birthday)
                    .HasMaxLength(6)
                    .IsRequired(true)
                    .HasColumnName("birthday");

                entity.Property(e => e.Facebook)
                    .HasMaxLength(250)
                    .IsUnicode(true)
                    .IsRequired(false)
                    .HasColumnName("facebook");

                entity.Property(e => e.Linkedin)
                   .HasMaxLength(250)
                   .IsUnicode(true)
                   .IsRequired(false)
                   .HasColumnName("linkedin");

                entity.Property(e => e.Job)
                   .HasMaxLength(250)
                   .IsUnicode(true)
                   .IsRequired(false)
                   .HasColumnName("job");

                entity.Property(e => e.Avt_img)
                   .HasMaxLength(2000)
                   .IsUnicode(true)
                   .IsRequired(false)
                   .HasColumnName("avt_img");

                entity.Property(e => e.Background_img)
                   .HasMaxLength(2000)
                   .IsUnicode(true)
                   .IsRequired(false)
                   .HasColumnName("background_img");

                entity.Property(e => e.Is_active)
                    .HasDefaultValueSql("1")
                    .HasColumnName("is_active");

                entity.Property(e => e.Is_deleted)
                    .HasColumnName("is_deleted")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Create_at)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasColumnType("timestamp")
                    .HasColumnName("create_at");

                entity.Property(e => e.Update_at)
                    .ValueGeneratedOnAddOrUpdate()
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasColumnType("timestamp")
                    .HasColumnName("update_at");

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
                    .HasColumnType("time")
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

                entity.Property(e => e.Is_deleted)
                    .HasColumnName("is_deleted")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Create_at)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasColumnType("timestamp")
                    .HasColumnName("create_at");

                entity.Property(e => e.Update_at)
                    .ValueGeneratedOnAddOrUpdate()
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasColumnType("timestamp")
                    .HasColumnName("update_at");

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
                  .IsUnicode(true)
                  .HasColumnName("lesson_name");

                entity.Property(e => e.LessonURL)
                  .HasMaxLength(200)
                  .IsUnicode(true)
                  .HasColumnName("lesson _url");

                entity.Property(e => e.Duration)
                   .HasColumnName("duration");

                entity.HasOne(d => d.ChapterNavigation)
                 .WithMany(f => f.Lessons)
                 .HasForeignKey(d => d.ChapterID)
                 .OnDelete(DeleteBehavior.ClientSetNull);
                //.HasConstraintName("FK_LESSON_REFERENCE_CHAPTER");

                entity.Property(e => e.Is_active)
                    .HasDefaultValueSql("1")
                    .HasColumnName("is_active");

                entity.Property(e => e.Is_deleted)
                    .HasColumnName("is_deleted")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Create_at)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasColumnType("timestamp")
                    .HasColumnName("create_at");

                entity.Property(e => e.Update_at)
                    .ValueGeneratedOnAddOrUpdate()
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasColumnType("timestamp")
                    .HasColumnName("update_at");

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
                  .IsUnicode(true)
                  .HasColumnName("content");


                entity.HasOne(d => d.UserNavigation)
                 .WithMany(f => f.Reviews)
                 .HasForeignKey(d => d.UserID)
                 .OnDelete(DeleteBehavior.ClientSetNull);
                //.HasConstraintName("FK_REVIEW_REFERENCE_USER");

                entity.Property(e => e.Is_deleted)
                    .HasColumnName("is_deleted")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Create_at)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasColumnType("timestamp")
                    .HasColumnName("create_at");

                entity.Property(e => e.Update_at)
                    .ValueGeneratedOnAddOrUpdate()
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasColumnType("timestamp")
                    .HasColumnName("update_at");

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
                  .IsUnicode(true)
                  .HasColumnName("reason");


                entity.HasOne(d => d.UserNavigation)
                 .WithMany(f => f.Approvals)
                 .HasForeignKey(d => d.UserID)
                 .OnDelete(DeleteBehavior.ClientSetNull);
                //.HasConstraintName("FK_APPROVAL_REFERENCE_USER");

                entity.Property(e => e.Is_active)
                    .HasDefaultValueSql("1")
                    .HasColumnName("is_active");

                entity.Property(e => e.Is_deleted)
                    .HasColumnName("is_deleted")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Create_at)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasColumnType("timestamp")
                    .HasColumnName("create_at");

                entity.Property(e => e.Update_at)
                    .ValueGeneratedOnAddOrUpdate()
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasColumnType("timestamp")
                    .HasColumnName("update_at");

            });

            modelBuilder.Entity<Tag>(entity =>
            {

                entity.ToTable("tag");

                entity.HasKey(e => e.ID);

                entity.Property(p => p.ID)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CourseID)
                    .HasColumnName("course_id");

                entity.Property(e => e.TagName)
                  .HasMaxLength(2000)
                  .HasColumnName("tag_name");


                entity.Property(e => e.Is_deleted)
                    .HasColumnName("is_deleted")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Create_at)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasColumnType("timestamp")
                    .HasColumnName("create_at");

                entity.Property(e => e.Update_at)
                    .ValueGeneratedOnAddOrUpdate()
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasColumnType("timestamp")
                    .HasColumnName("update_at");


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
                    .IsUnicode(true)
                    .HasColumnName("chapter_name");


                entity.Property(e => e.Is_active)
                    .HasDefaultValueSql("1")
                    .HasColumnName("is_active");

                entity.Property(e => e.Is_deleted)
                    .HasColumnName("is_deleted")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Create_at)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasColumnType("timestamp")
                    .HasColumnName("create_at");

                entity.Property(e => e.Update_at)
                    .ValueGeneratedOnAddOrUpdate()
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasColumnType("timestamp")
                    .HasColumnName("update_at");

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
                    .IsUnicode(true)
                    .HasColumnName("type_name");

                entity.Property(e => e.Is_active)
                    .HasDefaultValueSql("1")
                    .HasColumnName("is_active");

                entity.Property(e => e.Is_deleted)
                    .HasColumnName("is_deleted")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Create_at)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasColumnType("timestamp")
                    .HasColumnName("create_at");

                entity.Property(e => e.Update_at)
                    .ValueGeneratedOnAddOrUpdate()
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasColumnType("timestamp")
                    .HasColumnName("update_at");


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

                entity.Property(e => e.CourseAuthorID)
                    .HasColumnName("course_author_id");

                entity.Property(e => e.CourseLevelID)
                    .HasColumnName("course_level_id");

                entity.Property(e => e.CourseLanguageID)
                  .HasColumnName("course_language_id");

                entity.Property(e => e.ApprovalStatus)
                 .HasColumnName("approval_status");

                entity.Property(e => e.CourseName)
                    .HasMaxLength(200)
                    .HasColumnName("course_name");

                entity.Property(e => e.CourseImage)
                    .HasMaxLength(2000)
                    .HasColumnName("course_image");


                entity.Property(e => e.CourseFee)
                    .HasColumnName("course_fee");

                entity.Property(e => e.Description)
                    .HasColumnName("description");


                entity.Property(e => e.CourseStatus)
                 .HasColumnName("course_status");


                entity.Property(e => e.Is_active)
                   .HasDefaultValueSql("1")
                   .HasColumnName("is_active");

                entity.Property(e => e.Is_deleted)
                    .HasColumnName("is_deleted")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Create_at)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasColumnType("timestamp")
                    .HasColumnName("create_at");

                entity.Property(e => e.Update_at)
                    .ValueGeneratedOnAddOrUpdate()
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasColumnType("timestamp")
                    .HasColumnName("update_at");

            });

            modelBuilder.Entity<CourseMix>(entity =>
            {

                entity.HasKey(e => e.ID);

                entity.Property(p => p.ID)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CourseName)
                    .HasColumnName("course_name");

                entity.Property(e => e.TypeName)
                    .HasColumnName("type_name");

                entity.Property(e => e.StatusName)
                    .HasColumnName("status_name");

                entity.Property(e => e.AuthorName)
                  .HasColumnName("author_name");

                entity.Property(e => e.ReviewStar)
                 .HasColumnName("average_review_star");

                entity.Property(e => e.CourseImage)
                    .HasMaxLength(2000)
                    .HasColumnName("course_image");

                entity.Property(e => e.LevelName)
                   .HasMaxLength(2000)
                   .HasColumnName("level_name");

                entity.Property(e => e.LanguageName)
                   .HasMaxLength(2000)
                   .HasColumnName("language_name");

                entity.Property(e => e.CourseFee)
                    .HasColumnName("course_fee");

                entity.Property(e => e.Tags)
                    .HasColumnName("tags");

                entity.Property(e => e.EnrollmentCount)
                    .HasColumnName("enrollment_count");

                entity.Property(e => e.Description)
                    .HasColumnName("description");

                entity.Property(e => e.Create_at)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasColumnType("timestamp")
                    .HasColumnName("create_at");

                entity.Property(e => e.Update_at)
                    .ValueGeneratedOnAddOrUpdate()
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasColumnType("timestamp")
                    .HasColumnName("update_at");

            });

            OnModelCreatingPartial(modelBuilder);

        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
