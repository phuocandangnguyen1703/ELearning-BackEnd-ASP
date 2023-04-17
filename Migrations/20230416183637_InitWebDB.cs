using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ELearning.Migrations
{
    /// <inheritdoc />
    public partial class InitWebDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "main_types",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    type_name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true, collation: "utf8mb4_unicode_520_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_main_types", x => x.id);
                })
                .Annotation("Relational:Collation", "utf8mb4_unicode_520_ci");

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<int>(type: "int", nullable: false),
                    role_name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true, collation: "utf8mb4_unicode_520_ci"),
                    role_description = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true, collation: "utf8mb4_unicode_520_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.id);
                })
                .Annotation("Relational:Collation", "utf8mb4_unicode_520_ci");

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Role = table.Column<int>(type: "int", nullable: false),
                    username = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true, collation: "utf8mb4_unicode_520_ci"),
                    email = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true, collation: "utf8mb4_unicode_520_ci"),
                    password = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true, collation: "utf8mb4_unicode_520_ci"),
                    fullname = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true, collation: "utf8mb4_unicode_520_ci"),
                    phone = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: true, collation: "utf8mb4_unicode_520_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                })
                .Annotation("Relational:Collation", "utf8mb4_unicode_520_ci");

            migrationBuilder.CreateTable(
                name: "approvals",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    course_id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    approve_time = table.Column<DateTime>(type: "datetime", nullable: false),
                    is_accepted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    reason = table.Column<bool>(type: "tinyint(200)", unicode: false, maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_approvals", x => x.id);
                    table.ForeignKey(
                        name: "FK_approvals_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id");
                })
                .Annotation("Relational:Collation", "utf8mb4_unicode_520_ci");

            migrationBuilder.CreateTable(
                name: "chapters",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    course_id = table.Column<int>(type: "int", nullable: false),
                    chapter_name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true, collation: "utf8mb4_unicode_520_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chapters", x => x.id);
                })
                .Annotation("Relational:Collation", "utf8mb4_unicode_520_ci");

            migrationBuilder.CreateTable(
                name: "lessons",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    chapter_id = table.Column<int>(type: "int", nullable: false),
                    lesson_name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true, collation: "utf8mb4_unicode_520_ci"),
                    lesson_url = table.Column<string>(name: "lesson _url", type: "varchar(200)", unicode: false, maxLength: 200, nullable: true, collation: "utf8mb4_unicode_520_ci"),
                    duration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lessons", x => x.id);
                    table.ForeignKey(
                        name: "FK_lessons_chapters_chapter_id",
                        column: x => x.chapter_id,
                        principalTable: "chapters",
                        principalColumn: "id");
                })
                .Annotation("Relational:Collation", "utf8mb4_unicode_520_ci");

            migrationBuilder.CreateTable(
                name: "course",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AuthorID = table.Column<int>(type: "int", nullable: false),
                    course_type_id = table.Column<int>(type: "int", nullable: false),
                    course_name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true, collation: "utf8mb4_unicode_520_ci"),
                    course_image = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: true, collation: "utf8mb4_unicode_520_ci"),
                    course_fee = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb4_unicode_520_ci"),
                    course_state = table.Column<int>(type: "int", nullable: false),
                    commission = table.Column<int>(type: "int", unicode: false, maxLength: 200, nullable: false),
                    UserNavigationID = table.Column<int>(type: "int", nullable: true),
                    LessonNavigationID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_course", x => x.id);
                    table.ForeignKey(
                        name: "FK_course_lessons_LessonNavigationID",
                        column: x => x.LessonNavigationID,
                        principalTable: "lessons",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_course_main_types_course_type_id",
                        column: x => x.course_type_id,
                        principalTable: "main_types",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_course_users_AuthorID",
                        column: x => x.AuthorID,
                        principalTable: "users",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_course_users_UserNavigationID",
                        column: x => x.UserNavigationID,
                        principalTable: "users",
                        principalColumn: "id");
                })
                .Annotation("Relational:Collation", "utf8mb4_unicode_520_ci");

            migrationBuilder.CreateTable(
                name: "leanings",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    lesson_id = table.Column<int>(type: "int", unicode: false, maxLength: 200, nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    learn_time = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_leanings", x => x.id);
                    table.ForeignKey(
                        name: "FK_leanings_lessons_lesson_id",
                        column: x => x.lesson_id,
                        principalTable: "lessons",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_leanings_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id");
                })
                .Annotation("Relational:Collation", "utf8mb4_unicode_520_ci");

            migrationBuilder.CreateTable(
                name: "requires",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    course_id = table.Column<int>(type: "int", nullable: false),
                    reason = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: true, collation: "utf8mb4_unicode_520_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_requires", x => x.id);
                    table.ForeignKey(
                        name: "FK_requires_course_course_id",
                        column: x => x.course_id,
                        principalTable: "course",
                        principalColumn: "id");
                })
                .Annotation("Relational:Collation", "utf8mb4_unicode_520_ci");

            migrationBuilder.CreateTable(
                name: "reviews",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    course_id = table.Column<int>(type: "int", nullable: false),
                    course_review_state = table.Column<int>(type: "int", nullable: false),
                    content = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: true, collation: "utf8mb4_unicode_520_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reviews", x => x.id);
                    table.ForeignKey(
                        name: "FK_reviews_course_user_id",
                        column: x => x.user_id,
                        principalTable: "course",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_reviews_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id");
                })
                .Annotation("Relational:Collation", "utf8mb4_unicode_520_ci");

            migrationBuilder.CreateIndex(
                name: "IX_approvals_course_id",
                table: "approvals",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "IX_approvals_user_id",
                table: "approvals",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_chapters_course_id",
                table: "chapters",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "IX_course_AuthorID",
                table: "course",
                column: "AuthorID");

            migrationBuilder.CreateIndex(
                name: "IX_course_course_type_id",
                table: "course",
                column: "course_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_course_LessonNavigationID",
                table: "course",
                column: "LessonNavigationID");

            migrationBuilder.CreateIndex(
                name: "IX_course_UserNavigationID",
                table: "course",
                column: "UserNavigationID");

            migrationBuilder.CreateIndex(
                name: "IX_leanings_lesson_id",
                table: "leanings",
                column: "lesson_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_leanings_user_id",
                table: "leanings",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_lessons_chapter_id",
                table: "lessons",
                column: "chapter_id");

            migrationBuilder.CreateIndex(
                name: "IX_requires_course_id",
                table: "requires",
                column: "course_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_reviews_user_id",
                table: "reviews",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_approvals_course_course_id",
                table: "approvals",
                column: "course_id",
                principalTable: "course",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_chapters_course_course_id",
                table: "chapters",
                column: "course_id",
                principalTable: "course",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_chapters_course_course_id",
                table: "chapters");

            migrationBuilder.DropTable(
                name: "approvals");

            migrationBuilder.DropTable(
                name: "leanings");

            migrationBuilder.DropTable(
                name: "requires");

            migrationBuilder.DropTable(
                name: "reviews");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "course");

            migrationBuilder.DropTable(
                name: "lessons");

            migrationBuilder.DropTable(
                name: "main_types");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "chapters");
        }
    }
}
