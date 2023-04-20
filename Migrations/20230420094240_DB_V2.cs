using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ELearning.Migrations
{
    /// <inheritdoc />
    public partial class DB_V2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.RenameColumn(
                name: "Role",
                table: "users",
                newName: "role_id");

            migrationBuilder.RenameColumn(
                name: "reason",
                table: "requires",
                newName: "content");

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                table: "users",
                type: "timestamp",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldUnicode: false,
                oldDefaultValue: new DateTime(2023, 4, 20, 0, 28, 5, 22, DateTimeKind.Local).AddTicks(9035))
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AlterColumn<int>(
                name: "is_deleted",
                table: "users",
                type: "int",
                nullable: false,
                defaultValueSql: "'0'",
                oldClrType: typeof(int),
                oldType: "int",
                oldUnicode: false,
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "is_active",
                table: "users",
                type: "int",
                nullable: false,
                defaultValueSql: "'1'",
                oldClrType: typeof(int),
                oldType: "int",
                oldUnicode: false,
                oldDefaultValue: 1);

            migrationBuilder.AlterColumn<string>(
                name: "facebook",
                table: "users",
                type: "varchar(250)",
                maxLength: 250,
                nullable: true,
                collation: "utf8mb4_unicode_520_ci",
                oldClrType: typeof(string),
                oldType: "varchar(11)",
                oldUnicode: false,
                oldMaxLength: 11,
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "utf8mb4_unicode_520_ci");

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "users",
                type: "timestamp",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldUnicode: false,
                oldDefaultValue: new DateTime(2023, 4, 20, 0, 28, 5, 22, DateTimeKind.Local).AddTicks(8766));

            migrationBuilder.AddColumn<string>(
                name: "Email_verified_at",
                table: "users",
                type: "longtext",
                nullable: true,
                collation: "utf8mb4_unicode_520_ci");

            migrationBuilder.AddColumn<string>(
                name: "avt_img",
                table: "users",
                type: "varchar(2000)",
                maxLength: 2000,
                nullable: true,
                collation: "utf8mb4_unicode_520_ci");

            migrationBuilder.AddColumn<string>(
                name: "background_img",
                table: "users",
                type: "varchar(2000)",
                maxLength: 2000,
                nullable: true,
                collation: "utf8mb4_unicode_520_ci");

            migrationBuilder.AddColumn<string>(
                name: "job",
                table: "users",
                type: "varchar(250)",
                maxLength: 250,
                nullable: true,
                collation: "utf8mb4_unicode_520_ci");

            migrationBuilder.AddColumn<string>(
                name: "linkedin",
                table: "users",
                type: "varchar(250)",
                maxLength: 250,
                nullable: true,
                collation: "utf8mb4_unicode_520_ci");

            migrationBuilder.AddColumn<DateTime>(
                name: "create_at",
                table: "roles",
                type: "timestamp",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddColumn<int>(
                name: "is_active",
                table: "roles",
                type: "int",
                nullable: false,
                defaultValueSql: "'1'");

            migrationBuilder.AddColumn<int>(
                name: "is_deleted",
                table: "roles",
                type: "int",
                nullable: false,
                defaultValueSql: "'0'");

            migrationBuilder.AddColumn<DateTime>(
                name: "update_at",
                table: "roles",
                type: "timestamp",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "create_at",
                table: "reviews",
                type: "timestamp",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddColumn<int>(
                name: "is_deleted",
                table: "reviews",
                type: "int",
                nullable: false,
                defaultValueSql: "'0'");

            migrationBuilder.AddColumn<DateTime>(
                name: "update_at",
                table: "reviews",
                type: "timestamp",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "create_at",
                table: "requires",
                type: "timestamp",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddColumn<int>(
                name: "is_active",
                table: "requires",
                type: "int",
                nullable: false,
                defaultValueSql: "'1'");

            migrationBuilder.AddColumn<int>(
                name: "is_deleted",
                table: "requires",
                type: "int",
                nullable: false,
                defaultValueSql: "'0'");

            migrationBuilder.AddColumn<DateTime>(
                name: "update_at",
                table: "requires",
                type: "timestamp",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "create_at",
                table: "main_types",
                type: "timestamp",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddColumn<int>(
                name: "is_active",
                table: "main_types",
                type: "int",
                nullable: false,
                defaultValueSql: "'1'");

            migrationBuilder.AddColumn<int>(
                name: "is_deleted",
                table: "main_types",
                type: "int",
                nullable: false,
                defaultValueSql: "'0'");

            migrationBuilder.AddColumn<DateTime>(
                name: "update_at",
                table: "main_types",
                type: "timestamp",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "duration",
                table: "lessons",
                type: "time",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "create_at",
                table: "lessons",
                type: "timestamp",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddColumn<int>(
                name: "is_active",
                table: "lessons",
                type: "int",
                nullable: false,
                defaultValueSql: "'1'");

            migrationBuilder.AddColumn<int>(
                name: "is_deleted",
                table: "lessons",
                type: "int",
                nullable: false,
                defaultValueSql: "'0'");

            migrationBuilder.AddColumn<DateTime>(
                name: "update_at",
                table: "lessons",
                type: "timestamp",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "learn_time",
                table: "leanings",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AddColumn<DateTime>(
                name: "create_at",
                table: "leanings",
                type: "timestamp",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddColumn<int>(
                name: "is_deleted",
                table: "leanings",
                type: "int",
                nullable: false,
                defaultValueSql: "'0'");

            migrationBuilder.AddColumn<DateTime>(
                name: "update_at",
                table: "leanings",
                type: "timestamp",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "create_at",
                table: "course",
                type: "timestamp",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddColumn<int>(
                name: "is_active",
                table: "course",
                type: "int",
                nullable: false,
                defaultValueSql: "'1'");

            migrationBuilder.AddColumn<int>(
                name: "is_deleted",
                table: "course",
                type: "int",
                nullable: false,
                defaultValueSql: "'0'");

            migrationBuilder.AddColumn<DateTime>(
                name: "update_at",
                table: "course",
                type: "timestamp",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "create_at",
                table: "chapters",
                type: "timestamp",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddColumn<int>(
                name: "is_active",
                table: "chapters",
                type: "int",
                nullable: false,
                defaultValueSql: "'1'");

            migrationBuilder.AddColumn<int>(
                name: "is_deleted",
                table: "chapters",
                type: "int",
                nullable: false,
                defaultValueSql: "'0'");

            migrationBuilder.AddColumn<DateTime>(
                name: "update_at",
                table: "chapters",
                type: "timestamp",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "create_at",
                table: "approvals",
                type: "timestamp",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddColumn<int>(
                name: "is_active",
                table: "approvals",
                type: "int",
                nullable: false,
                defaultValueSql: "'1'");

            migrationBuilder.AddColumn<int>(
                name: "is_deleted",
                table: "approvals",
                type: "int",
                nullable: false,
                defaultValueSql: "'0'");

            migrationBuilder.AddColumn<DateTime>(
                name: "update_at",
                table: "approvals",
                type: "timestamp",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

            migrationBuilder.CreateIndex(
                name: "IX_reviews_course_id",
                table: "reviews",
                column: "course_id");

            migrationBuilder.AddForeignKey(
                name: "FK_reviews_course_course_id",
                table: "reviews",
                column: "course_id",
                principalTable: "course",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reviews_course_course_id",
                table: "reviews");

            migrationBuilder.DropIndex(
                name: "IX_reviews_course_id",
                table: "reviews");

            migrationBuilder.DropColumn(
                name: "Email_verified_at",
                table: "users");

            migrationBuilder.DropColumn(
                name: "avt_img",
                table: "users");

            migrationBuilder.DropColumn(
                name: "background_img",
                table: "users");

            migrationBuilder.DropColumn(
                name: "job",
                table: "users");

            migrationBuilder.DropColumn(
                name: "linkedin",
                table: "users");

            migrationBuilder.DropColumn(
                name: "create_at",
                table: "roles");

            migrationBuilder.DropColumn(
                name: "is_active",
                table: "roles");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "roles");

            migrationBuilder.DropColumn(
                name: "update_at",
                table: "roles");

            migrationBuilder.DropColumn(
                name: "create_at",
                table: "reviews");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "reviews");

            migrationBuilder.DropColumn(
                name: "update_at",
                table: "reviews");

            migrationBuilder.DropColumn(
                name: "create_at",
                table: "requires");

            migrationBuilder.DropColumn(
                name: "is_active",
                table: "requires");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "requires");

            migrationBuilder.DropColumn(
                name: "update_at",
                table: "requires");

            migrationBuilder.DropColumn(
                name: "create_at",
                table: "main_types");

            migrationBuilder.DropColumn(
                name: "is_active",
                table: "main_types");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "main_types");

            migrationBuilder.DropColumn(
                name: "update_at",
                table: "main_types");

            migrationBuilder.DropColumn(
                name: "create_at",
                table: "lessons");

            migrationBuilder.DropColumn(
                name: "is_active",
                table: "lessons");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "lessons");

            migrationBuilder.DropColumn(
                name: "update_at",
                table: "lessons");

            migrationBuilder.DropColumn(
                name: "create_at",
                table: "leanings");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "leanings");

            migrationBuilder.DropColumn(
                name: "update_at",
                table: "leanings");

            migrationBuilder.DropColumn(
                name: "create_at",
                table: "course");

            migrationBuilder.DropColumn(
                name: "is_active",
                table: "course");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "course");

            migrationBuilder.DropColumn(
                name: "update_at",
                table: "course");

            migrationBuilder.DropColumn(
                name: "create_at",
                table: "chapters");

            migrationBuilder.DropColumn(
                name: "is_active",
                table: "chapters");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "chapters");

            migrationBuilder.DropColumn(
                name: "update_at",
                table: "chapters");

            migrationBuilder.DropColumn(
                name: "create_at",
                table: "approvals");

            migrationBuilder.DropColumn(
                name: "is_active",
                table: "approvals");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "approvals");

            migrationBuilder.DropColumn(
                name: "update_at",
                table: "approvals");

            migrationBuilder.RenameColumn(
                name: "role_id",
                table: "users",
                newName: "Role");

            migrationBuilder.RenameColumn(
                name: "content",
                table: "requires",
                newName: "reason");

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                table: "users",
                type: "datetime(6)",
                unicode: false,
                nullable: false,
                defaultValue: new DateTime(2023, 4, 20, 0, 28, 5, 22, DateTimeKind.Local).AddTicks(9035),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValueSql: "CURRENT_TIMESTAMP")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AlterColumn<int>(
                name: "is_deleted",
                table: "users",
                type: "int",
                unicode: false,
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValueSql: "'0'");

            migrationBuilder.AlterColumn<int>(
                name: "is_active",
                table: "users",
                type: "int",
                unicode: false,
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValueSql: "'1'");

            migrationBuilder.AlterColumn<string>(
                name: "facebook",
                table: "users",
                type: "varchar(11)",
                unicode: false,
                maxLength: 11,
                nullable: true,
                collation: "utf8mb4_unicode_520_ci",
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldMaxLength: 250,
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "utf8mb4_unicode_520_ci");

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "users",
                type: "datetime(6)",
                unicode: false,
                nullable: false,
                defaultValue: new DateTime(2023, 4, 20, 0, 28, 5, 22, DateTimeKind.Local).AddTicks(8766),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<int>(
                name: "duration",
                table: "lessons",
                type: "int",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AlterColumn<DateTime>(
                name: "learn_time",
                table: "leanings",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AddForeignKey(
                name: "FK_reviews_course_user_id",
                table: "reviews",
                column: "user_id",
                principalTable: "course",
                principalColumn: "id");
        }
    }
}
